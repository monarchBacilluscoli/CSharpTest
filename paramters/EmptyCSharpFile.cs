namespace ref_and_value
{
    public static class RefAndValue
    {
        public static void Swap(object o1, object o2)
        {
            object t = o1;
            o1 = o2;
            o2 = t;
        }
        public static void Swap(ref object ro1, ref object ro2)
        {
            object t = ro1;
            ro1 = ro2;
            ro2 = t;
        }
        public static void Swap(Point p1, Point p2)
        {
            Point t = p1;
            p1 = p2;
            p2 = t;
        }
        public static void Swap(ref Point rp1, ref Point rp2)
        {
            Point t = rp1;
            rp1 = rp2;
            rp2 = t;
        }
    }

    public struct Point
    {
        public Point(int rx, int ry)
        {
            x = rx;
            y = ry;
        }
        public int x, y;
    }
}