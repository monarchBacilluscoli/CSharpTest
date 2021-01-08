using System;
using default_parameters;
using System.Collections.Generic;
using PPP;

namespace paramters
{
    class TestClass
    {
        public Int32 x=100;
        public Int32[] ir = new Int32[10000];
        public void print() { }
    }

    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            default_parameters.DefaultParameters.Ring();
            ParamTest();

            {
                Point p1 = new Point(2, 3);
                Point p2 = new Point(435, 8676);

                // if you want to use the generalized Swap
                Object o1 = p1;
                Object o2 = p2;



                Swap(ref o1, ref o2);
                p1 = (Point)o1;
                p2 = (Point)o2;

                // Or you can use the specialized Swap
                Swap(ref p1, ref p2);
            }
            {
                String[] sa = { "2131", "2132", "sdfaf" };
                Console.WriteLine(sa.GetType());
                List<String> il = new List<String>(sa);
            }
            {
                var a = GetAList();
                Console.WriteLine(a.GetType());
            }
            {
                TestClass tc1 = new TestClass(), tc2 = new TestClass();
                tc1.x = 1;
                tc2.x = 2;

                Object tco1 = tc1;
                Object tco2 = tc2;

                Swap(ref tco1, ref tco2);

                Swap(tc1, tc2);

                Console.WriteLine("ss");

            }
            {
                TestClass t1 = new TestClass();
                t1.x = 1;
                TestClass t2 = new TestClass();
                t2.x = 2;
                t1 = t2;
                t2.x = 3;
                Console.WriteLine(t1.x);
            }
            TestClass tc = new TestClass();
            tc.GetType();
            return;
        }

        static void ParamTest()
        {
            var t = "ss";
            Console.WriteLine(t.GetType());
        }

        static void Swap(ref Object o1, ref Object o2)
        {
            Console.WriteLine(o1.GetType());
            Object t = o1;
            o1 = o2;
            o2 = t;
        }

        static void Swap(ref Point o1, ref Point o2)
        {
            Console.WriteLine(o1.GetType());
            o1 = new Point();
        }

        static void Swap(TestClass o1, TestClass o2)
        {
            Console.WriteLine(o1.GetType());
            Int32 t = o1.x;
            o1.x = o2.x;
            o2.x = t;
        }

        static IList<String> GetAList()
        {
            String[] sa = { "sss", "aaaa", "21312" };
            return sa;
        }
    }
}
