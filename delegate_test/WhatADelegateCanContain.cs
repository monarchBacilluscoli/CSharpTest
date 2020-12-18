using System;
namespace delegate_test
{
    public class WhatADelegateCanContain
    {
        private Delegate d;

        private static void AStaticMethod() { }

        private Int32 AMemberMethodWithReturnValue(Int32 a) { return a; }

        public WhatADelegateCanContain()
        {
            d = new Action(WhatADelegateCanContain.AStaticMethod);
            var p = new WhatADelegateCanContain();
            d = new Func<Int32, Int32>(p.AMemberMethodWithReturnValue);
        }
    }
}
