namespace method_test
{
    internal class BaseBase
    {
        public virtual void SomeNewMethod()
        {
            System.Console.WriteLine("BaseBase.SomNewMethod()");
        }
        public virtual void SomeVirtualMethod()
        {
            System.Console.WriteLine("BaseBase.SomeVirtualMethod()");
        }
        public void SomeMethod()
        {
            System.Console.WriteLine("BaseBase.SomeMethod()");
        }
    }
    internal class Base : BaseBase
    {
        public override void SomeNewMethod()
        {
            System.Console.WriteLine("Base.SomNewMethod()");
        }
        public override void SomeVirtualMethod()
        {
            System.Console.WriteLine("Base.SomeVirtualMethod()");
        }
    }
    internal class Derived : Base
    {
        new public virtual void SomeNewMethod()
        {
            System.Console.WriteLine("Derived.SomNewMethod()");
        }
        public override void SomeVirtualMethod()
        {
            System.Console.WriteLine("Derived.SomeVirtualMethod()");
        }
    }
    internal class DerivedDerived : Derived
    {
        public virtual void SomeNewMethod()
        {
            System.Console.WriteLine("DerivedDerived.SomNewMethod()");
        }
        public override void SomeVirtualMethod()
        {
            System.Console.WriteLine("DerivedDerived.SomeVirtualMethod()");
        }
    }
}