using System;
using System.IO;

namespace delegate_test
{
    internal delegate void Feedback(Int32 value);
    public class BasicDelegateUse
    {
        public static void BasicUse()
        {
            {// 一般调用
                Counter(1, 3, FeedbackToConsole);
                Counter(1, 3, FeedbackToMessageBox);
                BasicDelegateUse bdu = new BasicDelegateUse();
                Counter(1, 3, bdu.FeedbackToFile);
            }
            {// 委托链测试
                Feedback fbChain = new Feedback(FeedbackToMessageBox);
                fbChain = (Feedback)Delegate.Combine(fbChain, new Feedback(FeedbackToConsole)); // com
                fbChain += new BasicDelegateUse().FeedbackToFile;
                Counter(1, 3, fbChain);
            }
        }
        static void Counter(Int32 from, Int32 to, Feedback fb)
        {
            if (fb != null)
            {
                for (int i = from; i < to; i++)
                {
                    fb(i);
                    //or 
                    //fb.Invoke(i);
                }
            }
        }
        static void FeedbackToConsole(Int32 value)
        {
            System.Console.WriteLine("Item = " + value);
        }

        private static void FeedbackToMessageBox(Int32 value)
        {
            System.Console.WriteLine("Item = " + value);
        }
        private void FeedbackToFile(Int32 value)
        {
            // using (StreamWriter sw = new StreamWriter("./status.txt")) // try finally to release the resources.
            // {
            //     sw.WriteLine(value);
            // }
            // or 
            StreamWriter sw = new StreamWriter("./status.txt", true);
            try
            {
                sw.WriteLine(value);
            }
            finally
            {
                sw.Dispose();
            }
        }
    }


}