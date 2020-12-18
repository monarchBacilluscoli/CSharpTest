using System;
using System.Runtime.CompilerServices;

namespace GCTest
{
    public class GCWatcherTest
    {
        public static void Foo()
        {
            object o = new Program();
            o.GCWatch("A");
            GC.Collect();
            GC.KeepAlive(o);
            o = null;

            GC.Collect();
            Console.WriteLine(GC.CollectionCount(0));

            Console.ReadLine();
        }
    }

    internal static class GCWatcher
    {
        private static readonly ConditionalWeakTable<object, NotifyWhenGCd<String>> m_cw = new ConditionalWeakTable<object, NotifyWhenGCd<String>>();

        private sealed class NotifyWhenGCd<T>
        {
            private readonly T m_obj;

            internal NotifyWhenGCd(T obj)
            {
                m_obj = obj;
            }

            public override String ToString()
            {
                return m_obj.ToString();
            }

            ~NotifyWhenGCd()
            {
                Console.WriteLine(m_obj.ToString());
            }
        }

        public static T GCWatch<T>(this T @object, string tag) // @ 意味拿object关键字当命名用。
        {
            m_cw.Add(@object, new NotifyWhenGCd<String>(tag));
            return @object;
        }
    }
}
