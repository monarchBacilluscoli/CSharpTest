using System;

namespace boxing_test
{
    internal struct SomeStruct
    {
        public Int32 X;
    }

    internal class SomeClass
    {
        public SomeStruct m_s = new SomeStruct();
    }

    class Program
    {
        static void Main(string[] args)
        {
            SomeClass sc = new SomeClass();
            System.Console.WriteLine(sc.m_s.ToString());
            return;
        }
    }
}
