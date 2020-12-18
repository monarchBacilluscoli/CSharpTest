using System;
using System.Runtime.CompilerServices;

public class TestClass
{
    private Int32[] m_a = new Int32[100];
    public Int32[] A
    {
        get { return m_a; }
    }
    [IndexerName("ChangedIndexerName")]
    public Int32 this[Int32 index]
    {
        get
        {
            if (index > 99 || index < 0)
            {
                throw new ArgumentOutOfRangeException("index out of range");
            }
            else
            {
                return m_a[index];
            }
        }
        set
        {
            if (index > 99 || index < 0)
            {
                throw new ArgumentOutOfRangeException("index out of range");
            }
            else
            {
                m_a[index] = value;
            }
        }
    }
}