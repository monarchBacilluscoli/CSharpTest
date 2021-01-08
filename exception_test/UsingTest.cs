using System.IO;
namespace exception_test
{
    public class UsingTest
    {
        public static void Test1()
        {
            using (StreamWriter sw = new StreamWriter("status.txt", true))
            {
                System.Console.WriteLine("Test");
            } // using 语句会自动生成调用Dispose()的IL
        }

        public static void Test2()
        {
            StreamWriter[] arr = new StreamWriter[]
            {
                new StreamWriter( "status.txt", true ),
            new StreamWriter( "status.txt", true ),
            new StreamWriter( "status.txt", true )
            };
            foreach (var item in arr)
            {
                item.ToString();
            }
        }
    }
}