using System;
using System.Text;
using System.Security;
using System.Runtime.InteropServices;

namespace string_test
{
    class Program
    {
        static void Main(string[] args)
        {
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
                    for (int i = 0; pc[i]!=0; i++)
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
