using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenDuration = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());
            string comand = Console.ReadLine();
            string car = string.Empty;
            Queue<string> queue = new Queue<string>();

            int carsPassed = 0;

            while (comand != "END")
            {
                if (comand != "green")
                {
                    queue.Enqueue(comand);
                }
                else
                {
                    if (!queue.Any())
                    {
                        comand = Console.ReadLine();
                        continue;
                    }
                    car = queue.Dequeue();
                    carsPassed++;
                    Queue<char> carChars = new Queue<char>(car.ToCharArray());

                    for (int i = 0; i < greenDuration; i++)
                    {
                        if (carChars.Any())
                        {
                            carChars.Dequeue();
                        }
                        else
                        {
                            if (queue.Any())
                            {
                                car = queue.Dequeue();
                                carsPassed++;
                                carChars = new Queue<char>(car.ToCharArray());
                                carChars.Dequeue();
                            }

                        }
                    }

                    if (carChars.Any())
                    {
                        bool carsOut = false;

                        for (int i = 0; i < freeWindow; i++)
                        {
                            if (carChars.Any())
                            {
                                carChars.Dequeue();
                            }
                            else
                            {
                                break;

                            }
                        }

                        if (carChars.Any())
                        {
                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{car} was hit at {carChars.Peek()}.");
                            carsPassed--;
                            return;
                        }
                    }


                }
                comand = Console.ReadLine();
            }


            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{carsPassed} total cars passed the crossroads.");

        }
    }
}
