using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CarSalesman
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            Dictionary<string, Engine> engines = new Dictionary<string, Engine>();

            for (int i = 0; i < n; i++)
            {
                string[] engineInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Engine engine = new Engine();

                for (int j = 0; j < engineInfo.Length; j++)
                {
                    if (j == 0)
                    {
                        engine.Model = engineInfo[j];
                    }
                    else if (j == 1)
                    {
                        engine.Power = int.Parse(engineInfo[j]);
                    }
                    else if (j == 2)
                    {
                        int displacement;

                        if (int.TryParse(engineInfo[j], out displacement))
                        {
                            engine.Displacement = displacement;
                        }
                        else
                        {
                            engine.Efficiency = engineInfo[j];
                        }
                    }
                    else if (j == 3)
                    {
                        engine.Efficiency = engineInfo[j];
                    }
                }

                engines.Add(engine.Model, engine);

            }

            int m = int.Parse(Console.ReadLine());

            for (int i = 0; i < m; i++)
            {
                string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Car car = new Car();

                for (int j = 0; j < carInfo.Length; j++)
                {
                    if (j == 0)
                    {
                        car.Model = carInfo[j];
                    }
                    else if (j == 1)
                    {
                        car.Engine = engines[carInfo[j]];
                    }
                    else if (j == 2)
                    {
                        int weight;
                        if (int.TryParse(carInfo[j], out weight))
                        {
                            car.Weight = weight;
                        }
                        else
                        {
                            car.Color = carInfo[j];
                        }
                    }
                    else if (j == 3)
                    {
                        car.Color = carInfo[j];
                    }
                }

                cars.Add(car);
            }

            foreach (var item in cars)
            {
                Console.WriteLine(item.ToString());
            }


        }
    }
}
