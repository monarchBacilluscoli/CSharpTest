using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace method_test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            {
                Base b = new Base();
                b.SomeMethod();
            }
            {// 主要想测试虚函数最终会调用到哪个层级，毕竟New把虚函数关系给断了。
                BaseBase bb1 = new BaseBase();
                Base b1 = new Base();
                Derived d1 = new Derived();
                DerivedDerived dd1 = new DerivedDerived();
                Derived dd2 = dd1;
                BaseBase bd1 = dd1;

                bd1.SomeVirtualMethod();
                bd1.SomeNewMethod(); // 调用的是Base的函数，也就是说New真的把继承关系给搞断了。

                dd2.SomeVirtualMethod();
                dd2.SomeNewMethod(); // 调用有new标记的只会硬调用。这里调用的是Derived的SomeNewMethod
                return;
            }
            {
                Derived d1 = new Derived();
                Base b1 = d1;
                b1.SomeNewMethod();
                d1.SomeNewMethod();
                Base b2 = new Base();
                b1.SomeNewMethod();
            }
            {
                Derived d1 = new Derived();
                Base b1 = d1;
                b1.SomeVirtualMethod();
                d1.SomeVirtualMethod();
                Base b2 = new Base();
                b1.SomeVirtualMethod();
                return;
            }
        }


    }
}
