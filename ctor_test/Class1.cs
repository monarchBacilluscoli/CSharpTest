using System;

namespace ctor_test
{
    public struct Point
    {
        static float ms_origin;
        static Point()
        {
            ms_origin = 0.0f;
        }
        public float m_x, m_y;
        public Point(float x, float y)
        {
            m_x = x;
            m_y = y;
        }
    }
    public class Class1
    {
        public static Int32 ms_int = 5;
        public Int32 m_some_int = 1;
    }
    public class Class2: Class1
    {
        public static float ms_float = 11.0f;
    }
    public class Class3
    {
        void foo()
        {
            Class1 c1 = new Class1();
            c1.m_some_int = 11;
            Console.WriteLine(Class2.ms_int); 
        }
    }
}
