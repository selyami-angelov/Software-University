using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySearch
{
    class BinarySearch
    {
        public static int FindIndex(int[] arr, int key)
        {
            int mid = arr.Length / 2;
            int left = 0;
            int right = arr.Length;
            int index = 0;

            while (arr[mid] != key)
            {
                if (key > arr[mid])
                {
                    left = mid;
                    mid += (right - left) / 2;
                }
                else if (key < arr[mid])
                {
                    right = mid;
                    mid = right / 2;
                }
            }

            return mid;
        }
    }
}
