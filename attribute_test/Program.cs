using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Linq;
using System.Text;


namespace attribute_test
{
    class Program
    {
        public void TypeTest()
        {
            if (this.GetType() == typeof(Program))
            {
                Console.WriteLine("These two types are the same");
            }
            else
            {
                Console.WriteLine("These two types are different");
            }
        }

        public static void FromWhereTest(Int32[] arr)
        {
            var isets = from item in arr where item > 50 select item; // wow, SQL form
            StringBuilder sb = new StringBuilder();
            foreach (var item in isets)
            {
                sb.Append(item.ToString()).Append("\t");
            }
            Console.WriteLine(sb.ToString());
        }

        [method:Conditional("CONDITION1")]
        static void Foo1()
        {
            Console.WriteLine("CONDITION1 is defined");
        }
        [method:Conditional("CONDITION2")]
        static void Foo2()
        {
            Console.WriteLine("CONDITION2 is defined");
        }

        static void Main(string[] args)
        {
            AttributeTest.EnterPoint();

            Foo1();
            Foo2();

            FromWhereTest(new[] { 1, 2, 3, 4, 5, 66, 72, 1231, 141, 15 });

            var p = new Program();
            p.TypeTest();

            FlagsAttribute fa = new FlagsAttribute(11);

            Console.WriteLine("Hello World!");
        }
    }
}
