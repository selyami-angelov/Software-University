using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.TheFightForGondor
{
    class Program
    {
        static void Main(string[] args)
        {
            int wavesNum = int.Parse(Console.ReadLine());
            Queue<int> plates = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> orks = new Stack<int>();

            for (int i = 1; i <= wavesNum; i++)
            {
                orks = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

                if (i % 3 == 0)
                {
                    int plate = int.Parse(Console.ReadLine());
                    plates.Enqueue(plate);
                }

                while (orks.Any() && plates.Any())
                {
                    int orkValue = orks.Pop();
                    int plateValue = plates.Dequeue();

                    if (orkValue > plateValue)
                    {
                        orkValue -= plateValue;
                        orks.Push(orkValue);
                    }
                    else if (plateValue > orkValue)
                    {
                        plateValue -= orkValue;
                        var curPlate = new Queue<int>(plates.Reverse());
                        curPlate.Enqueue(plateValue);
                        plates = new Queue<int>(curPlate.Reverse());
                    }
                }

                if (plates.Count == 0 && i % 3 != 0)
                {
                    Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                    Console.WriteLine($"Orcs left: {string.Join(", ", orks)}");
                    return;
                }




            }



            Console.WriteLine("The people successfully repulsed the orc's attack.");
            Console.WriteLine($"Plates left: {string.Join(", ", plates)}");








        }
    }
}
