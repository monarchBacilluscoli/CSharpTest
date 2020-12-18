using System;
using PPP;
namespace array_test
{
    public class BoxingAndUnboxing
    {
        public class OPoint
        {
            public int m_x, m_y;
            public void Change(Int32 rx, Int32 ry)
            {
                m_x = rx;
                m_y = ry;
            }
        }
        public BoxingAndUnboxing()
        {
            Point a = new Point(1,2);
            Object o = a;
            ((Point)o).Change(33, 33);

            OPoint op = new OPoint();
            op.Change(1, 22);
        }
    }
}
