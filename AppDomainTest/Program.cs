using System;
using System.Threading;
using System.Reflection;

namespace AppDomainTest
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                AppDomain aD2 = AppDomain.CreateDomain("AD2");
                // RefAppDomainTest radt = aD2.CreateInstanceAndUnwrap()
            }

            {
                Marshalling();
                Console.WriteLine("Hello World!");
            }
        }
        public static void Marshalling()
        {
            AppDomain currentDomain = Thread.GetDomain();

            string friendlyName = currentDomain.FriendlyName;
            Console.WriteLine("Current AppDomain's friendly name is: "+friendlyName);

            string exeAssembly = Assembly.GetEntryAssembly().FullName;

            AppDomain ad2 = AppDomain.CreateDomain("AD #2"); // The second app domain isn't supported on this platform
            MarshalByRefType mbrt = (MarshalByRefType)ad2.CreateInstanceAndUnwrap(exeAssembly, "MarshalByRefType");

            Console.WriteLine(mbrt.GetType());

            mbrt.SomeMethod();

        }

        public sealed class MarshalByRefType: MarshalByRefObject
        {
            public void SomeMethod()
            {
                Console.WriteLine("MarshalByRefObject: SomeMethod");
            }
        }

        public sealed class MarshalByValType: Object
        {

        }

        public sealed class NoMarshallableType: Object
        {

        }
    }

}
