using System;
using System.Collections.Generic;

namespace SpeedRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            int carsNum = int.Parse(Console.ReadLine());
            Dictionary<string, Car> cars = new Dictionary<string, Car>();
            //List<Car> cars = new List<Car>();


            for (int i = 0; i < carsNum; i++)
            {

                string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = carInfo[0];
                double fuel = double.Parse(carInfo[1]);
                double fuelConsumption = double.Parse(carInfo[2]);
                Car curCar = new Car(model, fuel, fuelConsumption, 0);
                cars.Add(model, curCar);

            }

            string comand = Console.ReadLine();

            while (comand != "End")
            {
                string model = comand.Split()[1];
                int km = int.Parse(comand.Split()[2]);
                cars[model].driveCar(km);

                comand = Console.ReadLine();
            }

            foreach (var item in cars)
            {
                Console.WriteLine($"{item.Value.Model} {item.Value.FuelAmount:F2} {item.Value.TravelledDistance}");
            }
        }
    }
}
