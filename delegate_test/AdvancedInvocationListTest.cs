using System;

namespace delegate_test
{
    // GetInvocationList用于委托链不够健壮的情况，需要多个返回值的情况
    public class AdvancedInvocationListTest
    {
        public static void AdvancedInvocationTest()
        {
            // construct a delegate chain
            Func<string> f1 = new Func<string>(new Tracks().Status);
            Func<string> f2 = new Func<string>(new Canon().Status);
            Func<String> f3 = new Turret().Status;

            f1 += (f2 += f3);
            var invocationList = f1.GetInvocationList();
            foreach (Func<String> item in invocationList)
            {
                try
                {
                    System.Console.WriteLine(item());
                }
                catch (ApplicationException ae)
                {
                    System.Console.WriteLine("Error: ", ae.Message);
                }
            }

        }
        internal sealed class Tracks
        {
            public string Status()
            {
                return "tracks are OK";
            }
        }
        internal sealed class Canon
        {
            public string Status()
            {
                throw new ApplicationException("Canon is broken because of overheating");
            }
        }
        internal sealed class Turret
        {
            public String Status()
            {
                return "turret is OK";
            }
        }
    }
}