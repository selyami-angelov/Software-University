using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> firsBox = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Stack<int> secondBox = new Stack<int>(Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse));

            int loot = 0;

            while (firsBox.Count != 0 && secondBox.Count != 0)
            {
                int firstItem = firsBox.Peek();
                int secondItem = secondBox.Pop();
                int sum = firstItem + secondItem;

                if (sum % 2 == 0)
                {
                    loot += sum;
                    firsBox.Dequeue();
                }
                else
                {
                    firsBox.Enqueue(secondItem);
                }
            }

            if (firsBox.Count != 0)
            {
                Console.WriteLine("Second lootbox is empty");
            }
            else
            {
                Console.WriteLine("First lootbox is empty");
            }

            if (loot >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {loot}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {loot}");
            }
        }
    }
}
