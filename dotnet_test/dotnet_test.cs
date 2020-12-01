using System;
using System.Collections;
using System.Collections.Generic;
using dddd;
using const_var_assemblr;

namespace dotnet_test
{
    class Program
    {
        static void Main(string[] args)
        {
            dddd.SomePublicType.PubRing();
            dddd.SomeInternalType.Ring();
            Console.WriteLine("a const var: "+ const_var_assemblr.const_var_class.some_const);

            SomeInternalType sit = new SomeInternalType();
            sit.Sing();
            SomeInternalTypeExtension.Sing(sit);

            var it1 = new SomeInternalType(2);
            var it2 = new SomeInternalType(400);
            Console.WriteLine((it1+it2).Data);
        }
    }
}
        