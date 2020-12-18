using System;
using System.Threading;
namespace delegate_test
{
    public class EmptyClass
    {
        public delegate void delegate_foo(Int32 value);
        delegate_foo MyDelegate;

        Action<int> action_delegate;

        Func<Int32, Int32, Int32> unary_delegate;
    }
}
