using System;
using System.Collections.Generic;

namespace _8.TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int carsNumberPass = int.Parse(Console.ReadLine());
            string car = Console.ReadLine();
            int carsPassCount = 0;
            Queue<string> carsInQueue = new Queue<string>();

            while (car != "end")
            {
                if (car == "green")
                {
                    for (int i = 0; i < carsNumberPass; i++)
                    {
                        if (carsInQueue.Count != 0)
                        {
                            Console.WriteLine($"{carsInQueue.Dequeue()} passed!");
                            carsPassCount++;
                        }
                        else
                        {
                            break;
                        }

                    }
                }
                else
                {
                    carsInQueue.Enqueue(car);
                }

                car = Console.ReadLine();
            }

            Console.WriteLine($"{carsPassCount} cars passed the crossroads.");
        }
    }
}
