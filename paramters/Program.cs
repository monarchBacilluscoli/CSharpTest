using System;
using default_parameters;
using point;

namespace paramters
{
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
                return;
            }
        }

        static void ParamTest()
        {
            var t = "ss";
            Console.WriteLine(t.GetType());
        }

        static void Swap(ref Object o1, ref Object o2)
        {
            Object t = o1;
            o1 = o2;
            o2 = t;
        }

        static void Swap(ref Point o1, ref Point o2)
        {
            Point t = o1;
            o1 = o2;
            o2 = t;
        }
    }
}
