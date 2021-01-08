using System;

namespace delegate_test
{
    class Program
    {
        internal delegate void SaySomthingDelegate(String s);
        static void Main(string[] args)
        {

            {// Advanced invocation list test
                AdvancedInvocationListTest.AdvancedInvocationTest();
            }
            {// basic delegate useage
                BasicDelegateUse.BasicUse();
            }
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

        internal static void SayOK(String somebody)
        {
            Console.WriteLine("OK, {0}", somebody);
        }

        internal void SayYes(String somebody)
        {
            Console.WriteLine("Yes, {0}", somebody);
        }
        delegate void test_delegate(String s); // This can not defined in a function, since it is a class defination.
    }
}
