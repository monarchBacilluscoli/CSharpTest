﻿using System;
using System.Reflection;
using System.Threading;


namespace GCTest
{
    class MyClass
    {
        ~MyClass()
        {
            Console.WriteLine("Finalize method");
        }
    }

    class Program
    {

        

        unsafe static void Main(string[] args)
        {

            {
                GCWatcherTest.Foo();
                
            }

            //{
            //    GCHandleTest gcht = new GCHandleTest();
            //    gcht.Foo();
            //}

            //{
            //    for (int i = 0; i < 100000; i++)
            //    {
            //        new Object();
            //    }
            //}

            //Console.WriteLine(GC.CollectionCount(0));
            //Console.WriteLine(GC.GetTotalMemory(false));

            ////GC.Collect();
            //IntPtr originalAddress;
            //Console.WriteLine(GC.CollectionCount(0));
            //Byte[] bs = new Byte[1000];
            //Console.WriteLine(GC.CollectionCount(0));
            //Console.WriteLine(GC.GetTotalMemory(false));
            //fixed(Byte* pbyte = bs)
            //{
            //    originalAddress = (IntPtr)pbyte;
            //    Console.WriteLine("original one: {0}", originalAddress);
            //}
            //Console.WriteLine(GC.CollectionCount(0));

            //GC.Collect();

            //Console.WriteLine(GC.GetTotalMemory(false));
            //Console.WriteLine(GC.CollectionCount(0));
            //fixed (Byte* pbyte = bs)
            //{
            //    Console.WriteLine("Final one: {0}", (IntPtr)pbyte);
            //}
        }

    }
}
