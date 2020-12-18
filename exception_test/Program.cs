using System;
using System.Reflection;
using System.Text;
using System.Runtime.Serialization;

namespace exception_test
{
    class Program
    {
        static void ExceptionTest0()
        {
            try
            {
                Console.WriteLine("try: {0}", MethodBase.GetCurrentMethod().Name);
                ExceptionTest1();
            }
            finally
            {
                Console.WriteLine("finally: {0}", MethodBase.GetCurrentMethod().Name);
            }

        }
        static void ExceptionTest1()
        {
            try
            {
                Console.WriteLine("try: {0}", MethodBase.GetCurrentMethod().Name);
                ExceptionTest2();
            }
            catch (Exception ex)
            {
                Console.WriteLine("catch: {0}", MethodBase.GetCurrentMethod().Name);
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("finally: {0}", MethodBase.GetCurrentMethod().Name);
            }
        }
        static void ExceptionTest2()
        {
            try
            {
                Console.WriteLine("try: {0}", MethodBase.GetCurrentMethod().Name);
                ExceptionTest3();
            }
            catch (Exception ex)
            {
                throw; // will not reset the StackTrace start point
                //throw ex; // reset the StackTrace start point
            }
            finally
            {
                Console.WriteLine("finally: {0}", MethodBase.GetCurrentMethod().Name);
            }
        }
        static void ExceptionTest3()
        {
            try
            {
                Console.WriteLine("try: {0}", MethodBase.GetCurrentMethod().Name);
                throw (new Exception(new string("exception: " + MethodBase.GetCurrentMethod().Name)));
            }
            finally
            {
                Console.WriteLine("finally: {0}", MethodBase.GetCurrentMethod().Name);
            }
        }
        static void Main(string[] args)
        {
            long start_memory_use = GC.GetTotalMemory(false);
            ExceptionTest0();
            Console.WriteLine("Hello World!");
            SerializationInfo si;

            AClassWithAThrowMethod acwatm = new AClassWithAThrowMethod();
            dynamic acwatmd = acwatm;
            try
            {
                acwatmd.ThrowAnException();
            }
            catch (OutOfMemoryException ex)
            {
                Console.WriteLine("It is not a targetinvokeException, Msg: {0}", ex.Message);
            }
            catch (TargetInvocationException ex)
            {
                Console.WriteLine("It is really a targetinvokeException, Msg: {0}", ex.Message);
            }

            Console.WriteLine(GC.CollectionCount(0));
            Console.WriteLine("Total memory change from start: {0}", GC.GetTotalMemory(false) - start_memory_use);
        }
    }
}
