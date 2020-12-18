using System;
namespace exception_test
{
    public class AClassWithAThrowMethod
    {
        public AClassWithAThrowMethod()
        {
        }

        public void ThrowAnException()
        {
            throw new OutOfMemoryException();
        }
    }
}
