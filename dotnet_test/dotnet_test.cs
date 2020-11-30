using System;
using System.Collections;
using System.Collections.Generic;
using dddd;

namespace dotnet_test
{
    class Program
    {
        static void Main(string[] args)
        {
            dddd.SomePublicType.PubRing();
            dddd.SomeInternalType.Ring();
        }
    }
}
