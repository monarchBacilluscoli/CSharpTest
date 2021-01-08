using System.Runtime.Serialization;
using System.Reflection;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace SerializationTest
{
    [Serializable]
    internal class Base
    {
        private int m_a = 100;
    }

    [Serializable]
    internal sealed class Derived : Base, ISerializable
    {
        private DateTime m_date = DateTime.Now;

        public Derived(){
            m_date = DateTime.Now;
        }
        private Derived(SerializationInfo info, StreamingContext context)
        {
            Type baseType = this.GetType().BaseType;
            MemberInfo[] memberinfo = FormatterServices.GetSerializableMembers(baseType, context);

            for (int i = 0; i < memberinfo.Length; i++)
            {
                FieldInfo field = (FieldInfo)memberinfo[i];
                field.SetValue(this, info.GetValue(baseType.FullName + "." + field.Name, field.GetType()));
            }
            m_date = info.GetDateTime("date");
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            Type baseType = this.GetType().BaseType;
            MemberInfo[] memberInfos = FormatterServices.GetSerializableMembers(baseType, context);
            // 添加值
            for (int i = 0; i < memberInfos.Length; i++)
            {
                FieldInfo field = (FieldInfo)memberInfos[i];
                info.AddValue(baseType.FullName + "." + field.Name, field.GetValue(this)); // 注意filed可以藉由GetValue得到this的该字段值。 
            }
            info.AddValue("date", m_date);
        }

        public override String ToString()
        {
            return String.Format("Date={0}", m_date); // 如何get到父类知道名称的字段？需要再学习一下反射。
        }
    }
    public static class ASerializationdvancedTest
    {
        public static void Test()
        {
            Derived d = new Derived();
            System.Console.WriteLine(d);
            
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, d);

            stream.Position = 0;

            Thread.Sleep(3000);
            Object d2 = formatter.Deserialize(stream);
            System.Console.WriteLine(d);
        }

    }
}