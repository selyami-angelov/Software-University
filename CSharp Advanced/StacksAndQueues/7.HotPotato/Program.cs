using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> kids = new Queue<string>(Console.ReadLine().Split());
            int pass = int.Parse(Console.ReadLine());

            while (kids.Count > 1)
            {
                string name = string.Empty;

                for (int i = 1; i < pass; i++)
                {
                    name = kids.Dequeue();
                    kids.Enqueue(name);
                }

                Console.WriteLine($"Removed {kids.Dequeue()}");
            }

            Console.WriteLine($"Last is {kids.Dequeue()}");
        }
    }
}
