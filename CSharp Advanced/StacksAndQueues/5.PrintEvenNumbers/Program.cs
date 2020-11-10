using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            List<int> evenNumbers = new List<int>();

            while (queue.Count != 0)
            {
                int number = queue.Dequeue();
                if (number % 2 == 0)
                {
                    evenNumbers.Add(number);
                }
            }

            Console.WriteLine(string.Join(", ", evenNumbers));
        }
    }
}
