using System;
using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("dotnet_test, PublicKey=0024000004800000940000000602000000240000525341310004000001000100d74df4dfb5e7102a2787fd3f25a41165ed006ebfe47f0d96bab43cee6841ac00f89200d9afc726c1f622c7c73089eb27111b2f8f3ddf4d0bdbc64c5a8a353e32e8dabbbd31f9196fc5d1e9921670084d2995395970fcb8263a7f27bdbe8e4cd714ea7caf34a6f0a08daa2f55564617ce24e6bcd9ca2518ee586852b069e5d7a0")] // set only the "dotnet_test" assembly can use the internal type of this assembly.
namespace dddd
{
    internal sealed class SomeInternalType {
        public static void Ring()
        {
            Console.WriteLine("ring--");
        }
    }

    public class SomePublicType
    {
        public static void PubRing()
        {
            Console.WriteLine("pubring--");
        }
    }
}
