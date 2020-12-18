using System;
using System.Threading;

namespace delegate_test
{
    public class LambdaWithLocals
    {
        public static void TestLoacalsInLambda()
        {
            // store the result
            int job_size = 10;
            Int32[] results = new Int32[job_size];
            AutoResetEvent e = new AutoResetEvent(false);

            Int32 num_to_do = job_size;
            for (int i = 0; i < job_size; i++)
            {
                ThreadPool.QueueUserWorkItem(obj =>
                {
                    Int32 num = (Int32)obj; //! You must use the local num rather than the outer local i, since i is changing while the lambda is running
                    Thread.Sleep(1000);
                    results[num] = num * num;

                    if(Interlocked.Decrement(ref num_to_do) == 0)
                    {
                        e.Set();
                    }
                }, i);
            }

            e.WaitOne(); // wait all the jobs have been done

            foreach (var item in results) // output the final results;
            {
                Console.WriteLine(item);
            }
        }
    }
}
