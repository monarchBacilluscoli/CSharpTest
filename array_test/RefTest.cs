using System;
using PPP;

namespace array_test
{
    public class RefTest
    {
        
        public static void StaticRefTest()
        {
            PointObject po = new PointObject();
            Refresh(ref po);
        }

        static void Refresh(ref PointObject rpo)
        {
            rpo = new PointObject();
        }
    }
}
