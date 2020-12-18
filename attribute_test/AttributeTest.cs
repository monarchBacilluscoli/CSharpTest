using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

[assembly:CLSCompliant(true)]
namespace attribute_test
{
    [Serializable]
    [DefaultMember("EnterPoint")]
    [DebuggerDisplay("Liu", Name ="Yongfeng", Target =typeof(AttributeTest))]
    public class AttributeTest
    {
        [Conditional("Debug")]
        [Conditional("Release")]
        public void DoSomething()
        {
        }

        [Flags(11,TestText = "A custom test text")]
        public AttributeTest()
        {

        }
        [CLSCompliant(true)]
        [STAThread]
        public static void EnterPoint()
        {
            ShowAttibutes(typeof(AttributeTest));

            //var members = typeof(AttributeTest).GetMembers().OfType

            var constructors = typeof(AttributeTest).GetTypeInfo().DeclaredConstructors;
            foreach (var ctor in constructors)
            {
                if (ctor.IsPublic)
                {
                    ShowAttibutes(ctor);
                }
            }

            //todo get all members of this type
            var methods = typeof(AttributeTest).GetTypeInfo().DeclaredMethods; // This is very useful

            foreach (var method in methods)
            {
                if (method.IsPublic)
                {
                    ShowAttibutes(method);
                }
            }
        }

        public static void ShowAttibutes(MemberInfo attribute_target)
        {
            Console.WriteLine(attribute_target.Name);

            //todo get all the attributes of the target
            var attributes = attribute_target.GetCustomAttributes();

            foreach (var attibute in attributes)
            {
                Console.WriteLine(" {0}", attibute.ToString());
                if(attibute is FlagsAttribute)
                {
                    Console.WriteLine("  TestText: {0}", ((FlagsAttribute)attibute).TestText);
                }
            }
        }
    }
}
