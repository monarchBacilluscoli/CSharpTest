using System;
using PPP;
namespace AppDomainTest
{
    public class RefAppDomainTest
    {
        void ChangeARefValue(ref PointObject p, int new_x)
        {
            p.X = new_x;
        }
    }
}
