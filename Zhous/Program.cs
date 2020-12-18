using System;
using System.Threading;

namespace Zhous
{
    class Program
    {
        public static void TimeCallBack(object o)
        {
            Console.WriteLine("hhh");

            GC.Collect();
        }

        public static void Main(string[] arges)
        {

            Timer t = new Timer(TimeCallBack, null, 0, 2000);

            Console.ReadLine();
            
        }
    }
}