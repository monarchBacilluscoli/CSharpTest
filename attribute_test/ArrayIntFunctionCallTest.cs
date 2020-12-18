using System;
namespace attribute_test
{
    public class ArrayIntFunctionCallTest
    {
        public ArrayIntFunctionCallTest()
        {
            Int32[] ia = new[] { 1, 2, 5, 4, 131 };
            Console.WriteLine(((Object)ia[1]).ToString()); // ia[1]这一句会把这个元素放在Stack上。
            //使用array的value元素调用会将value类型从heap的array复制到stack上，但这应该不属于拆箱的范畴。
        }
    }
}
