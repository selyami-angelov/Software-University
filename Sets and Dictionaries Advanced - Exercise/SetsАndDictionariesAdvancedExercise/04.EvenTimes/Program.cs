using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int numRows = int.Parse(Console.ReadLine());
            Dictionary<int, int> nums = new Dictionary<int, int>();

            for (int i = 0; i < numRows; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (nums.ContainsKey(num))
                {
                    nums[num]++;
                }
                else
                {
                    nums.Add(num, 1);
                }

            }

            foreach (var item in nums)
            {
                if (item.Value % 2 == 0)
                {
                    Console.WriteLine(item.Key);
                }
            }

        }
    }
}
