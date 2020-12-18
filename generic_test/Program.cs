using System; 

namespace GenericTests
{
    class Program
    {
        static void Main(string[] args)
        {
            TypedPrint("sssss");
            TypedPrint(new Program());
            DateTime dt = DateTime.Now;
            TypedPrint(dt);

            Console.WriteLine(ConstraintTest.LessThan(1, 2));
            Object o1 = 1;
            Object o2 = 2;
            //Console.WriteLine(ConstraintTest.LessThan(o1, o2); // Can not pass the compiliation.

            Program p1 = new Program();
            Program p2 = new Program();
            var p = p1 + p2;
        }


        static void TypedPrint<T>(T s)
        {
            Object o = s;
            String temp = s as String;
            if (temp != null)
            {
                Console.WriteLine("This is a string obj");
            }
            else
            {
                Console.WriteLine("Not a string obj");
            }
            Console.WriteLine(s);
        }
        //static void TypedPrint(Program s)
        //{
        //    Console.WriteLine(s);
        //}
        //static void TypedPrint(string s)
        //{
        //    Console.WriteLine(s);
        //}

        public static Program operator+(Program p1, Program p2)
        {
            return new Program();
        }
    }
}
