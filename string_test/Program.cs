using System;
using System.Text;
using System.Security;
using System.Runtime.InteropServices;

[assembly: System.Runtime.CompilerServices.CompilationRelaxations(System.Runtime.CompilerServices.CompilationRelaxations.NoStringInterning)]
namespace string_test
{
    class Program
    {
        static void EncodingTest()
        {
            // The UTF8 encoding will translate the string containing only ASCII chars to a same length byte array
            Encoding u8e = Encoding.UTF8;
            String tenCharsString = "abcdefghij";
            Byte[] bs = u8e.GetBytes(tenCharsString);
            System.Console.WriteLine("The UTF8 bytes translation result's length is: " + bs.Length);

            // The UTF32 encoding will translate the string containing only ASCII chars to a 4 times length byte array
            Encoding u32e = Encoding.UTF32;
            bs = u32e.GetBytes(tenCharsString);
            System.Console.WriteLine("The UTF32 bytes translation result's length is: " + bs.Length); // utf32确实是用4个字节在存一个char

            Decoder u32ed = u32e.GetDecoder();
            Byte[] bs1 = new Byte[tenCharsString.Length * 4 * 1 / 4 + 1];
            Byte[] bs2 = new Byte[tenCharsString.Length * 4 - bs1.Length];
            for (int i = 0; i < bs.Length; i++)
            {
                if (i < bs1.Length)
                {
                    bs1[i] = bs[i];
                }
                else
                {
                    bs2[i - bs1.Length] = bs[i];
                }
            }
            Char[] chars = new Char[tenCharsString.Length];
            int realLength = u32ed.GetChars(bs1, 0, bs1.Length, chars, 0, false); // 返回值是实际解码的字符串长度
            u32ed.GetChars(bs2, 0, bs2.Length, chars, realLength, false);
            System.Console.WriteLine("The string decoder get: "+ new string(chars));
            return;
        }
        static void StringBuilderTest()
        {
            StringBuilder sb = new StringBuilder(10);
            System.Console.WriteLine("Max Capacity: " + sb.MaxCapacity);
            System.Console.WriteLine("Capacity: " + sb.Capacity);
            System.Console.WriteLine("Length: " + sb.Length);
            sb.Append("Hello, ");
            System.Console.WriteLine(sb.ToString());
            System.Console.WriteLine("Max Capacity: " + sb.MaxCapacity);
            System.Console.WriteLine("Capacity: " + sb.Capacity);
            System.Console.WriteLine("Length: " + sb.Length);
            sb.Append("world.");
            System.Console.WriteLine("Max Capacity: " + sb.MaxCapacity);
            System.Console.WriteLine("Capacity: " + sb.Capacity);
            System.Console.WriteLine("Length: " + sb.Length);
            sb.AppendFormat("I don't know what is that {0}", sb.ToString());
            System.Console.WriteLine(sb.ToString());
            System.Console.WriteLine();
            return;
        }
        unsafe static void Main(string[] args)
        {
            {
                EncodingTest();
                return;
            }
            {
                StringBuilderTest();
                return;
            }
            {
                StringBuilder sb = new StringBuilder(100);
                sb.Append("this is a new item.").Append("And this is another.");
            }
            {// 显然字面值相同的字符串是会被留用的，并且在用的时候指向同一个对象
                String s1 = "hello";
                String s2 = "hello";
                System.Console.WriteLine("hash code: {0}, {1}", s1.GetHashCode(), s2.GetHashCode());
                System.Console.WriteLine("Are the same strings ref to the same obj: " + Object.ReferenceEquals(s1, s2));
                System.Console.WriteLine("Are the literal strings interned: " + ((String.IsInterned(s1) == null) ? "False" : "True"));

                String s3 = Console.ReadLine(); // 这就真正创建了不同的string对象
                String s4 = Console.ReadLine();

                System.Console.WriteLine("hash code: {0}, {1}", s3.GetHashCode(), s4.GetHashCode());//! 不同对象的hashcode也可能是一样的。
                System.Console.WriteLine("Are the same vstrings ref to the same obj: " + Object.ReferenceEquals(s3, s4));
                System.Console.WriteLine("Are the literal strings interned: " + ((String.IsInterned(s3) == null) ? "False" : "True"));

                return;
            }
            {
                String s1 = "This ";
                String s2 = "is ";
                String s3 = "a String.";
                string s4 = s1 + s2 + s3;
                Console.WriteLine(s4);
            }
            {
                String s1 = "MaMingqianMaMingqianMaMingqianMaMingqianMaMingqianMaMingqian";
                String s2 = "MaMingqianMaMingqianMaMingqianMaMingqianMaMingqianMaMingqian";
                String s3 = "MaMingqianMaMingqianMaMingqianMaMingqianMaMingqianMaMingqian";
                String s4 = "MaMingqianMaMingqianMaMingqianMaMingqianMaMingqianMaMingqian";
                String s5 = "MaMingqianMaMingqianMaMingqianMaMingqianMaMingqianMaMingqian";
                String s6 = "MaMingqianMaMingqianMaMingqianMaMingqianMaMingqianMaMingqian";
                String s7 = "MaMingqianMaMingqianMaMingqianMaMingqianMaMingqianMaMingqian";
                String s8 = "MaMingqianMaMingqianMaMingqianMaMingqianMaMingqianMaMingqian";
                String s9 = "MaMingqianMaMingqianMaMingqianMaMingqianMaMingqianMaMingqian";
                String s10 = "MaMingqianMaMingqianMaMingqianMaMingqianMaMingqianMaMingqian";
                String s11 = "MaMingqianMaMingqianMaMingqianMaMingqianMaMingqianMaMingqian";
                String s12 = "MaMingqianMaMingqianMaMingqianMaMingqianMaMingqianMaMingqian";
                String s13 = "MaMingqianMaMingqianMaMingqianMaMingqianMaMingqianMaMingqian";

                Encoding ec = Encoding.UTF8;
                byte[] sb = ec.GetBytes(s1);
                Console.WriteLine(sb);
                Console.WriteLine(BitConverter.ToString(sb));
                Console.WriteLine(ec.GetString(sb));

                var state_saving_decoder = ec.GetDecoder();
                char[] cs = new char[1000];
                state_saving_decoder.GetChars(sb, cs, false);

                Console.WriteLine(Object.ReferenceEquals(s1, s2)); // netcore 3.1 interns the 2 strings

                SecureString ss = new SecureString();
                for (int i = 0; i < s1.Length; i++)
                {
                    ss.AppendChar(s1[i]);
                }
                unsafe // 不safe的需要操作非托管内存的代码
                {
                    Char* pc = null;
                    pc = (Char*)Marshal.SecureStringToCoTaskMemUnicode(ss);
                    for (int i = 0; pc[i] != 0; i++)
                    {
                        Console.Write(pc[i]);
                    }
                    Console.WriteLine();
                    Marshal.ZeroFreeCoTaskMemUnicode((IntPtr)pc);
                    //for (int i = 0; i < 10; i++)
                    //{
                    //    Console.Write(pc[i]);
                    //}
                }

            }
        }
    }
}
