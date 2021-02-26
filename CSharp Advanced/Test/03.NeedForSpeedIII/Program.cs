using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.NeedForSpeedIII
{
    class Program
    {
        static void Main(string[] args)
        {
            int carsNum = int.Parse(Console.ReadLine());
            Dictionary<string, Car> cars = new Dictionary<string, Car>();

            for (int i = 0; i < carsNum; i++)
            {
                string[] carsData = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);
                string name = carsData[0];
                int milage = int.Parse(carsData[1]);
                int fuel = int.Parse(carsData[2]);

                if (!cars.ContainsKey(name))
                {
                    Car curCar = new Car(milage, fuel);
                    cars.Add(name, curCar);
                }
            }

            string[] comandsData = Console.ReadLine().Split(" : ", StringSplitOptions.RemoveEmptyEntries);

            while (comandsData[0] != "Stop")
            {
                string comand = comandsData[0];
                string car = comandsData[1];

                if (comand == "Drive")
                {
                    int distance = int.Parse(comandsData[2]);
                    int fuel = int.Parse(comandsData[3]);

                    if (cars[car].Fuel < fuel)
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                    else
                    {
                        cars[car].Milage += distance;
                        cars[car].Fuel -= fuel;
                        Console.WriteLine($"{car} driven for {distance} kilometers. {fuel} liters of fuel consumed.");

                        if (cars[car].Milage >= 100000)
                        {
                            cars.Remove(car);
                            Console.WriteLine($"Time to sell the {car}!");
                        }
                    }
                }
                else if (comand == "Refuel")
                {
                    int fuel = int.Parse(comandsData[2]);
                    int refueledAmount = 0;

                    if ((cars[car].Fuel + fuel) > 75)
                    {
                        refueledAmount = 75 - cars[car].Fuel;
                    }
                    else
                    {
                        refueledAmount = fuel;
                    }

                    cars[car].Fuel += refueledAmount;
                    Console.WriteLine($"{car} refueled with {refueledAmount} liters");
                }
                else if (comand == "Revert")
                {
                    int km = int.Parse(comandsData[2]);

                    if ((cars[car].Milage - km) < 10000)
                    {
                        cars[car].Milage = 10000;
                    }
                    else
                    {
                        cars[car].Milage -= km;
                        Console.WriteLine($"{car} mileage decreased by {km} kilometers");
                    }
                }

                comandsData = Console.ReadLine().Split(" : ", StringSplitOptions.RemoveEmptyEntries);
            }

            var sortedCars = cars.OrderByDescending(x => x.Value.Milage).ThenBy(x => x.Key);

            foreach (var item in sortedCars)
            {
                Console.WriteLine($"{item.Key} -> Mileage: {item.Value.Milage} kms, Fuel in the tank: {item.Value.Fuel} lt.");
            }

        }
    }
    class Car
    {
        public Car(int milage, int fuel)
        {
            Milage = milage;
            Fuel = fuel;
        }

        public int Milage { get; set; }
        public int Fuel { get; set; }
    }
}
