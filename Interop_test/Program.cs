using System;

namespace Interop_test
{
    class Program
    {
        struct InteropTestStruct
        {
            public Int32 data;
            public Boolean flag;
        }
        unsafe static void Main(string[] args)
        {
            var a = 1 + 2;
            InteropTestStruct i = new InteropTestStruct();
            InteropTestStruct* p = &i;
            System.Console.WriteLine((Int64)p);
            Console.WriteLine("Hello World!");
        }
    }
}
