using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> bombEfect = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Stack<int> bombCasing = new Stack<int>(Console.ReadLine()
               .Split(", ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse));

            int datura = 0;
            int cherry = 0;
            int smoke = 0;
            bool success = false;

            while (bombEfect.Count!=0 && bombCasing.Count!=0)
            {
                int efect = bombEfect.Dequeue();
                int casing = bombCasing.Pop();
                int sum = efect + casing;

                if (sum >= 120)
                {
                    smoke++;
                }
                else if (sum >= 60)
                {
                    cherry++;
                }
                else if (sum >= 40)
                {
                    datura++;
                }

                if (datura >= 3 && cherry >= 3 && smoke >= 3)
                {
                    success = true;
                    break;
                }
            }

            if (success)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (bombEfect.Count!=0)
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ",bombEfect)}");
            }
            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }

            if (bombCasing.Count != 0)
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", bombCasing)}");
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }

            Console.WriteLine($"Cherry Bombs: {cherry}");
            Console.WriteLine($"Datura Bombs: {datura}");
            Console.WriteLine($"Smoke Decoy Bombs: {smoke}");

        }
    }
}
