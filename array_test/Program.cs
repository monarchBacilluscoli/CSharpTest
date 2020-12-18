using System;

namespace array_test
{
    class Program
    {
        public Int32 x = 1;
        struct ArrayStruct
        {
            public Int32 m_x;
        }
        static void Main(string[] args)
        {
            Int32 a = 112;
            Int32[] ints = new Int32[100];
            ints[0] = 100;
            ints[1] = 2000;
            object vo = 11;
            ints[3] = (int)vo;
            ints[4] = (int)vo;
            vo = 12;

            ArrayStruct[] ast = new ArrayStruct[10];
            Object[] ast2 = new Object[ast.Length];

            Array.Copy(ast, ast2, ast.Length);
            ast[3].m_x = 100;

            Program[] pa = new [] { new Program(), new Program(), new Program() };
            Program[] pa2 = new Program[pa.Length];
            Array.Copy(pa, pa2, pa.Length);
            pa[2].x = 99;
            Console.WriteLine(pa2[2].x);

            Console.WriteLine("Hello World!");
        }
    }
}
