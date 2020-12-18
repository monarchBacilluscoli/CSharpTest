using System;
using System.IO;
using System.Reflection;

namespace enum_test
{
    [Flags]
    public enum TestEnum
    {
        JunkFood = 0x0001,
        HealthFood = 0x0002,
        NoFood = 0x0000,
        VoidFood = 0x0004,
        FixedFood = JunkFood | HealthFood
    }
    public class GetAttributesTest
    {
        public GetAttributesTest()
        {
            string file = Assembly.GetEntryAssembly().Location;
            var attributes = File.GetAttributes(file);
            Console.WriteLine(attributes);

            File.SetAttributes(file, FileAttributes.ReadOnly | FileAttributes.Hidden);
            //File.SetAttributes(file, ); // Wow, it hides the .dll.....

            TestEnum te = TestEnum.HealthFood;
            var is_d = Enum.IsDefined(typeof(TestEnum),1);
            var is_d2 = Enum.IsDefined(typeof(TestEnum),5);
            var is_d3 = Enum.IsDefined(typeof(TestEnum),"LowBFood");
            var is_d4 = Enum.IsDefined(typeof(TestEnum),"HealthFood, JunkFood"); // false

            var te2 = TestEnum.JunkFood;
            te2 = te2 | TestEnum.VoidFood;
            Console.WriteLine(te2);


            Console.WriteLine("exit");
        }
    }
}
