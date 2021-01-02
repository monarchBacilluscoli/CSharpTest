using System;

namespace inheritance_test
{
    internal struct Point
    {
        public Int32 x, y;
    }

    internal class Base
    {
        public virtual void Foo(Object obj)
        {
            Console.WriteLine("BaseFoo");
        }
    }

    internal class Derived : Base
    {
        public override sealed void Foo(Object obj)
        {
            Console.WriteLine("DerivedFoo");
        }

        public virtual void Foo(Point p)
        {
            Console.WriteLine("DerivedFooPoint");
        }
    }

    internal class Derived2 : Derived
    {
        public new void Foo(Object obj)
        {
            System.Console.WriteLine("Derived2Foo");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            {// 确定c#翻译到IL是调用哪个
                Derived d1 = new Derived();
                d1.Foo(new object());
            }
            {
                Derived2 d2 = new Derived2();
                Base b2 = d2;
                Object o = new object();
                b2.Foo(o);
                return;
            }
            Point p;
            p.x = 1;
            p.y = 11;
            Base b = new Derived();
            b.Foo(p); // this function call results in a boxing, this is about POLYMORPHISM

            Derived d = new Derived();
            d.Foo(d); // this function call doesn't result in a boxing. It is about the OVERLOAD
        }
    }
}
