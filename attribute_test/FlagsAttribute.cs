using System;
using System.Diagnostics;
namespace attribute_test
{
    [DebuggerDisplay("A flag attribute", Name = "AName", Target = typeof(FlagsAttribute),TargetTypeName = "InterestingAttribute")]
    [AttributeUsage(AttributeTargets.Constructor, AllowMultiple = false, Inherited = false)] // this attribute is used to set the behaviour of this attribute class
    public class FlagsAttribute:Attribute
    {
        public FlagsAttribute(int ss)
        {
        }

        private string m_test_text;

        public string TestText
        {
            get
            {
                return m_test_text;
            }
            set
            {
                m_test_text = value;
            }
        }
    }
}
