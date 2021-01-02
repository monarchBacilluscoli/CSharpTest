using System;

namespace assembly_test
{
    public class Program
    {
        private Int32 m_data = 100;
        static void Main(string[] args)
        {
            System.Console.WriteLine(Environment.Is64BitProcess);
            Console.WriteLine("Hello World!");
            System.Console.WriteLine((new Program()).GetType());
            var o = new Ano();
            System.Console.WriteLine(o.GetType());
        }
        static void SomeMethodWithParam(ref Int32 data)
        {
            System.Console.WriteLine(data);
            data = 1;
        }

        new public Type GetType()
        { // 新的gettype确实掩盖了老的gettype，但是用is as还是不会变。
            return typeof(Object);
        }
    }
    internal class Ano
    {

    }
}
