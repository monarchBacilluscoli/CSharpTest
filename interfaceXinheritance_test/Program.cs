using System;

namespace interfaceXinheritance_test
{
    class Program
    {
        internal interface IDisposable
        {
            void Dispose();
        }
        internal class Base : IDisposable
        {
            public void Dispose()
            {
                Console.WriteLine("Base");
            }

            public virtual void SomeMethod()
            {
                System.Console.WriteLine("Base::SomeMethod");
            }
        }
        internal class Derived : Base, IDisposable // 重新继承接口就代表重新实现，实际上Dispose是new，无论父类是否写了virtual
        {
            public void Dispose()  // 方法签名一致且public，就是接口方法的实现。
            {
                Console.WriteLine("Derived");
            }
            public new virtual void SomeMethod()
            {
                System.Console.WriteLine("Base::SomeMethod");
            }
        }
        internal class Derived2 : Base
        {
            public new void Dispose()
            {
                Console.WriteLine("Derived2");
            }
        }
        internal class Derived3 : Derived, IDisposable
        {
            public virtual void Dispose()
            {
                Console.WriteLine("Derived3");
            }
        }

        internal class Derived4 : Derived3
        {
            public override void Dispose()
            {
                System.Console.WriteLine("Derived4");
            }
        }

        internal class Another : IDisposable
        {
            public void Dispose()
            {
                System.Console.WriteLine("Another");
            }
        }



        static void Main(string[] args)
        {
            {
                Derived de = new Derived();
                Base ba = de;
                ba.SomeMethod();
            }
            // 首先明确，一旦类型对象已经被构建，它的方法表就已经定义ok了，所谓虚方法调用无非就是看obj类型的那个同签名方法就好了根本不用看别的，一点都不虚。
            // 其次，方法调用的时候分两步走：
            // 第一步从var开始，看var的类型对象方法表，如果方法表表明该方法是virtual，则去看obj类型对象；如果方法表表明该方法不是virtual，或者在该类型中sealed，则直接执行var类型的该方法
            // 第二部就是obj的类型，obj的方法表
            Derived d = new Derived();
            d.Dispose(); // 变量类型Derived，Dispose在该类型为virtual，callvirt Derived:Dispose(); Derived.
            Base b = d;
            b.Dispose(); // 变量类型Base，Dispose在该类型为virtual，callvirt Base:Dispose()；由于Dispose在该类型中为sealed，打断继承：Base。
            IDisposable id = b;
            id.Dispose(); // 变量类型IDisposable，接口，定义了Dispose，callvirt IDisposable:Dispose()；运行时根据对象类型Derived查看IVMap，Derived有实现Dispose：Derived。
            Derived2 d2 = new Derived2();
            d2.Dispose(); // 变量类型Derived2，Dispose视作接口方法重载（签名一致），带virtual，callvirt Derived2:Dispose()；运行时根据对象类型调用Derived2方法。Derived2
            Base b2 = d2;
            b2.Dispose(); // 变量类型Base，Dispose在该类型为virtual，callvirt Base::Dispose()；由于Dispose在该类型中为sealed，打断继承：Base。
            IDisposable id2 = d2;
            id2.Dispose(); //! 变量类型是IDsposable，callvirt IDispose::Dispose()；实际运行根据对象类型Derived2查看IVMap，new Dispose函数并未重载Base继承的IDisposable的Dispose，并不视作其为IDisposable的重写，故仍然调用Base的dispose：Base
            Derived3 d3 = new Derived3();
            d3.Dispose(); // 变量类型Derived3，没有virtual的Dispose，上溯到最近父类（Derived）拥有virtual字样的Dispose，callvirt Derived::Dispose()；父类Dispose有sealed字样，打断继承，Derived
            Base b3 = d3;
            b3.Dispose(); // 变量类型Base，有virtual，call Base::Dispose()；运行时由于Base的Dispose是sealed，Base
            IDisposable id3 = d3;
            id3.Dispose(); // 变量类型IDisposable，callvirt IDispose::Dispose()；运行时查IVMap，Derived2直接继承的Derived的实现，Derived

            Derived4 d4 = new Derived4();
            d4.Dispose();
            Another a = new Another();
            a.Dispose();
            IDisposable ia = a;
            ia.Dispose();
            return;
        }
    }
}
