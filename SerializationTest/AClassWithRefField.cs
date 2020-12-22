using System;
using System.Runtime.Serialization;
namespace SerializationTest
{
    [Serializable]
    public class AClassWithRefField
    {
        [NonSerialized]
        private int m_secretInfo = 0;
        private AnotherClass m_ac = new AnotherClass();

        public AClassWithRefField(int x, int ac)
        {
            m_secretInfo = x;
            m_ac.X = ac;
        }

        public int X
        {
            get { return m_secretInfo; }
            set { m_secretInfo = value; }
        }

        public AnotherClass AC
        {
            set { m_ac = value; }
            get { return m_ac; }
        }

        [OnDeserialized]
        private void CallOnDeserialize(StreamingContext sc)
        {
            m_secretInfo = 9999;
        }
    }

    [Serializable]
    public class AnotherClass
    {
        private int m_x;
        public AnotherClass()
        {
            m_x = 0;
        }
        public AnotherClass(int x)
        {
            m_x = x;
        }
        public int X
        {
            get { return m_x; }
            set { m_x = value; }
        }
    }
}
