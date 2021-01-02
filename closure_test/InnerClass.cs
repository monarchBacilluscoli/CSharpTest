using System;

namespace closure_test
{
    public class InnerClass
    {
        public static Int32 m_x = 100;

        public class Inner
        {
            public Int32 m_x_ref;
            Inner()
            {
                m_x_ref = m_x;
            }

            void AddOuterVal()
            {
                m_x++;
            }

        }
    }
}
