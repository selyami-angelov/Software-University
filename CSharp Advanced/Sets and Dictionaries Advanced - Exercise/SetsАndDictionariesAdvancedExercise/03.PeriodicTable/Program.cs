using System;
using System.Collections.Generic;

namespace _03.PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            SortedSet<string> components = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] compLineRead = Console.ReadLine().Split();
                foreach (var item in compLineRead)
                {
                    components.Add(item);
                }
            }

            Console.WriteLine(string.Join(" ", components));
        }
    }
}
