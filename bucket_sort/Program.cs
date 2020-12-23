using System;

namespace bucket_sort
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("sss");
            int size = Convert.ToInt32(Console.ReadLine());
            int[] inputs = new int[size];
            for (int i = 0; i < size; i++)
            {
                Int32 temp;
                try
                {
                    temp = Int32.Parse(Console.ReadLine());
                    if (temp == 10)
                    {
                        i--;
                        continue;
                    }
                    else
                    {
                        inputs[i] = temp;
                    }
                }
                catch (System.Exception ex)
                {
                    i--;
                    System.Console.WriteLine(ex.Message);
                }
            }

            foreach (var item in inputs)
            {
                System.Console.WriteLine(item);
            }

            Sort.BubbleSort(inputs);

            return;
        }
    }
}
