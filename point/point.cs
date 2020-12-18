using System;

namespace PPP
{
    public struct Point
    {
        public Point(Int32 px, Int32 py)
        {
            x = px;
            y = py;
        }
        Int32 x, y;

        public void Change(int rx, int ry)
        {
            x = rx;
            y = ry;
        }
    }

    public class PointObject
    {
        public int m_x, m_y;
        public void Change(Int32 rx, Int32 ry)
        {
            m_x = rx;
            m_y = ry;
        }

        public int X
        {
            get { return m_x; }
            set { m_x = value; }
        }

        public int Y
        {
            get { return m_y; }
            set { m_y = value; }
        }
    }
}
