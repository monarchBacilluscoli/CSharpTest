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
        public override void Foo(Object obj)
        {
            Console.WriteLine("DerivedFoo");
        }

        public virtual void Foo(Point p)
        {
            Console.WriteLine("DerivedFooPoint");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
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
