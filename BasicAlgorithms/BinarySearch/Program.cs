using System;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[7] { 1, 2, 3, 4, 5, 6, 7 };
            int kay = int.Parse(Console.ReadLine());

            Console.WriteLine(BinarySearch.FindIndex(arr,kay));
        }
    }
}
