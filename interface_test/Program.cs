using System;
using System.Collections.Generic;

namespace interface_test
{

    internal class Base : IComparable, ISimpleInterface
    {
        public Int32 m_x = 10;

        public int Data { get => 1; set => m_x = value; }

        public virtual void SomeVirtualFoo()
        {
            Console.WriteLine("base virual");
        }
        public virtual void SomeCompeleteNewFoo()
        {
            Console.WriteLine("Base New foo");
        }
        public virtual int CompareTo(Object b)
        {
            Console.WriteLine("Base compare");
            if (m_x < ((Base)b).m_x)
            {
                return 1;
            }
            else if (m_x == ((Base)b).m_x)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }

        public virtual void ShrinkAccessablity()
        {
            Console.WriteLine("Base ShrinkAccessablity");
        }

        public void SomeInterfaceMethod()
        {
            // throw new NotImplementedException();
        }

        public void SomeMethod()
        {

        }
    }
    internal class Derived : Base
    {
        public override void SomeVirtualFoo()
        {
            Console.WriteLine("Derived virtual");
        }
        public new void SomeCompeleteNewFoo()
        {
            Console.WriteLine("Derived New foo");
        }
        public override int CompareTo(Object b)
        {
            Console.WriteLine("Derived compare");
            if (m_x < ((Base)b).m_x)
            {
                return 1;
            }
            else if (m_x == ((Base)b).m_x)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
        //override void ShrinkAccessablity()
        //{
        //    Console.WriteLine("Base ShrinkAccessablity");
        //}
    }
    class Program
    {
        static void Main(string[] args)
        {
            {
                HandcraftWeapon c = new HandcraftWeapon();
                IMissileComponent imc = c;
                c.Fire();
                imc.Fire();
                return;
            }
            {
                Derived d1 = new Derived();
                d1.SomeMethod();
            }
            {
                // SimpleInterface si = new SimpleInterface(); //! can not create a interface of an interface
                Base b1 = new Base();
                ((ISimpleInterface)b1).SomeInterfaceMethod();
                return;
            }
            {
                Derived d1 = new Derived();
                d1.m_x = 1;
                Base b1 = new Derived();
                b1.m_x = 2;

                Console.WriteLine(d1.CompareTo(b1)); // d
                Console.WriteLine((IComparable)d1.CompareTo(b1)); // d
                Console.WriteLine(b1.CompareTo(d1)); // d
                Console.WriteLine((IComparable)b1.CompareTo(d1)); // d
                ((Base)b1).CompareTo(d1); // 不管怎么转型，虚调用，还是d

                b1.SomeVirtualFoo();
                d1.SomeVirtualFoo();

                b1.SomeCompeleteNewFoo(); // 纯new函数非虚调用，走var，调用b
                d1.SomeCompeleteNewFoo(); // 这显然是非虚调用，var已经是d，当然调用d
                ((Base)b1).SomeCompeleteNewFoo(); // 转型后非虚，当然调用b；
            }

            {
                Derived d1 = new Derived();
                var t = d1.GetType();
                Console.WriteLine(t);
            }


            Console.WriteLine("Hello World!");

        }
    }
}
