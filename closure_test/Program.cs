using System;

namespace closure_test
{
    class Program
    {
        static void Display<T>(T a)
        {
            System.Console.WriteLine( a.ToString() );
        }
        // static Action s_someAction;
        static void AQuestion()
        {
            int i = 2015;
            Action action1 = () =>
            {
                i += 5;
                System.Console.WriteLine("i1=" + i);
            };
            action1();
            i+=1;
            Action action2 = () =>
            {
                i -= 1;
                System.Console.WriteLine("i2=" + i);
            };
            action2();
            System.Console.WriteLine("i3=" + i);
        }
        static void Main(string[] args)
        {
            AQuestion();
            // s_someAction();
            return;
        }
    }
}
