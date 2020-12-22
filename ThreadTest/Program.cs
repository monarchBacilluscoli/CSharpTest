using System;
using System.Threading;
using System.Diagnostics;

namespace ThreadTest
{
    class Program
    {
        static void Main(string[] args)
        {
            {

            }
            //todo how to calculate the time used.
            Stopwatch sw = new Stopwatch(); // how to say...stepwatch's syntax is much simpler than chrono in C++
            Thread t1 = new Thread(DoSomething); 

            sw.Start();
            t1.IsBackground = true;
            t1.Start(5);
            
            Console.WriteLine("Start Sleep");
            //Thread.Sleep(3000);
            Console.WriteLine("End Sleep");
            t1.Join(); // is the thread is background thread and this statment is commented, the program may be exit instantly rather than waiting the thread to finish

            sw.Stop();
            Console.WriteLine("The time used: " + sw.Elapsed); // 恩，差不多是3秒

            return;
        }

        static void DoSomething(object seconds)
        {
            Console.WriteLine("Doing...");
            Thread.Sleep((int)seconds * 1000);
            Console.WriteLine("Done");
            return;
        }
    }


}
