using System;
using System.Threading;

namespace TestInterlocked
{
    public class TestInterlocked
    {
        private static Int32 m_total = 0;
        private static ManualResetEvent mre = new ManualResetEvent(false);

        private static void AddToTotal()
        {
            mre.WaitOne();
            for (int i = 0; i < 100000; ++i)
            {
                Int32 initial_total;
                Int32 target_total;
                do
                {
                    initial_total = m_total;
                    target_total = initial_total + 1;
                    //result = Interlocked.CompareExchange(ref m_total, target_total, initial_total);
                } while (initial_total != Interlocked.CompareExchange(ref m_total, target_total, initial_total));
                Console.WriteLine(m_total+": "+i);
            }
        }
        public static void MultiThreadAddTotal()
        {
            Thread t1 = new Thread(AddToTotal);
            t1.Start();
            Thread t2 = new Thread(AddToTotal);
            t2.Start();
            Thread t3 = new Thread(AddToTotal);
            t3.Start();

            mre.Set();

            t1.Join();
            t2.Join();
            t3.Join();

            Console.WriteLine(m_total);
            Console.WriteLine("exit");
        }
    }
}
