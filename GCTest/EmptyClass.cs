using System;
using System.Runtime.InteropServices;
namespace GCTest
{
    public class GCHandleTest
    {
        public GCHandleTest()
        {

        }

        public GCHandle GetATempGCHandle()
        {
            GCHandleTest hdo = new GCHandleTest(); 
            GCHandle gchd = GCHandle.Alloc(hdo, GCHandleType.Weak);
            hdo = null;
            return gchd;
        }

        public void Foo()
        {
            GCHandle gh = GetATempGCHandle();

            GC.Collect();
            GC.Collect();

            Console.WriteLine(gh.IsAllocated);
        }
    }
}
