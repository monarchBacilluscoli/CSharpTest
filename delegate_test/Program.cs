using System;

namespace delegate_test
{
    class Program
    {
        internal delegate void SaySomthingDelegate(String s);
        static void Main(string[] args)
        {
            SaySomthingDelegate ssd;
            ssd = SayOK;
            Program t = new Program();
            ssd = (SaySomthingDelegate)Delegate.Combine(ssd, new SaySomthingDelegate(t.SayYes));

            if (ssd != null)
            {
                ssd.DynamicInvoke(new String("This is a joke"));
            }

            LambdaWithLocals.TestLoacalsInLambda();
        }

        static void SayOK(String somebody)
        {
            Console.WriteLine("OK, {0}", somebody);
        }

        public void SayYes(string somebody)
        {
            Console.WriteLine("Yes, {0}", somebody);
        }
    }
}
