using System;
namespace bucket_sort
{
    public class Sort
    {
        public static void SimpleBucketSort()
        {

        }

        public static void BubbleSort(Int32[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if ((arr[j].CompareTo(arr[j+1])>0))
                    {
                        Int32 temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
            return;
        }
    }
}
