using System;

namespace trans_type
{
    public partial class B {
        partial void Ring();
    }
    public class D : B { }
    class Program
    {
        static void Main(string[] args)
        {
            D d1 = (D)(new B()); // runtime exception
        }
    }
}
