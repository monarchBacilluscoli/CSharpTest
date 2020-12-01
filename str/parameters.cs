using System;

namespace str
{
    class Program
    {
        static string Hello()
        {
            string s = "hello";
            Int32 i = 11;
            return s;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello" + "World!", "sss");
            string hello = "hello";
            string world = "world";
            Console.WriteLine(hello + Hello() + world + "111");
        }
    }
}
