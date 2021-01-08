using System;
using System.Threading;

namespace GCTest
{
    public static class GCNotification
    {
        private static Action<Int32> s_GCDone = null;
        public static event Action<Int32> GCDone
        {
            add
            {
                if (s_GCDone == null) // 只在一开始创建两个可以维持生命的对象即可。
                {
                    new GenObject(2);
                    new GenObject(0);
                }
                s_GCDone += value;
            }
            remove
            {
                s_GCDone -= value;
            }
        }

        private sealed class GenObject // 使用嵌套类：1. 使用类和实例方法可以在自己的Finalizer中实现对GC的监控。2.使用嵌套可以直接访问外部类的提醒回调。
        {
            private Int32 m_generation;
            public GenObject(Int32 generation)
            {
                m_generation = generation;
            }
            ~GenObject()
            {
                // if (GC.GetGeneration(this) >= m_generation) // 调用回调函数，报告GC //? 可能这句应该不用写吧？
                {
                    Action<Int32> temp = Volatile.Read(ref s_GCDone); // volatile保证了可见性（必须从RAM中读取）和有序性（memory barrier的存在后面的读写语句不会到这句前面去），引用类型的读写具有了原子性，所以线程安全。
                    if (temp != null)
                    {
                        temp(m_generation);
                    }
                }
                if (s_GCDone != null && !AppDomain.CurrentDomain.IsFinalizingForUnload() && !Environment.HasShutdownStarted)
                {
                    if (m_generation == 0) // 如果对象是0代提示对象，那就直接废掉这个对象，以免提升到1代后没办法提示0代。并新建另一个0代提示对象接替该对象工作。
                    {
                        new GenObject(0);
                    }
                    else // 如果对象是2代提示对象，那就可以保留，可以一直用来对2代进行提示。
                    {
                        GC.ReRegisterForFinalize(this);
                    }
                }
            }
        }
    }
}