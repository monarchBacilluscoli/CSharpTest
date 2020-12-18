using System;
using System.Collections.Generic;

namespace GenericTests
{
    internal struct SomeValueType:IComparable
    {
        public Int32 m_x;
        Int32 IComparable.CompareTo(Object o)
        {
            return CompareTo((SomeValueType)o);
        }
        public Int32 CompareTo(SomeValueType v)
        {
            return m_x - v.m_x;
        }
    }

    public class ConstraintTest
    {
        public ConstraintTest()
        {
            Console.WriteLine(LessThan(1,"dsdsfa"));
            SomeValueType v1 = new SomeValueType();
            SomeValueType v2 = new SomeValueType();
            v1.CompareTo(v2);
        }

        public static bool LessThan<T, T2>(T a, T2 b) where T:IComparable
        {
            if (a.CompareTo(b) < 0) // 看来comparable<T>只有Comapre<T>一种
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
