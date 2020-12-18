using System;
using System.Dynamic;
using System.Collections.Generic;


namespace property
{
    class Program
    {
        public class TestClass
        {
            public Int32 x = 100;
            private Int32[] m_a = new Int32[100];
            public Int32[] A
            {
                get { return m_a; }
            }
            public Int32 this[Int32 index]
            {
                get
                {
                    if(index>99 || index < 0)
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
        static void Main(string[] args)
        {

            {
                string name = "LiuYongfeng";
                DateTime dt = DateTime.Now;

                var unamed1 = new { name, dt.Year };
                Console.WriteLine(unamed1);
                // unamed object is immutable. So this can not pass the compiliation
                // unamed1.name = "MaMingqian";

                name = "MaMingqian";
                Console.WriteLine(unamed1);
            }

            {
                TestClass tc = new TestClass { x = 1000 };

                var unamed2 = new { tc, s = "sss" };

                Console.WriteLine(unamed2);
                Console.WriteLine(unamed2.tc.x);
                tc.x = 123151;
                Console.WriteLine(unamed2);
                Console.WriteLine(unamed2.tc.x);

            }

            {
                dynamic e = new ExpandoObject();
                e.x = "1000";
                e.n = 11;

                foreach (var item in (IDictionary<String, Object>)e)
                {
                    Console.WriteLine( "key={0}, value={1}", item.Key, item.Value);
                }

                Console.WriteLine(e.x);
            }
            {
                Console.WriteLine(1<<2);
                
            }
            {
                //TestClass tc = new TestClass();
                //tc[10] = 255;
                //foreach (var item in tc.A)
                //{
                //    //Console.WriteLine(item);
                //}
            }
            {
                GeneralTypeProp<String> sgtp = new GeneralTypeProp<string>();
                sgtp.A = "This is a general type property test obj";
                Console.WriteLine(sgtp.A);
            }
            Console.WriteLine("Hello World!");
        }
    }
}
