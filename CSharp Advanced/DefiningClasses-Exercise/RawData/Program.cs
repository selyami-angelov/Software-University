using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace RawData
{
    class Program
    {
        static void Main(string[] args)
        {
            int carsNum = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < carsNum; i++)
            {
                string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = carInfo[0];
                int engineSpeed = int.Parse(carInfo[1]);
                int enginePower = int.Parse(carInfo[2]);
                int cargoWeight = int.Parse(carInfo[3]);
                string cargoType = carInfo[4];
                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoType, cargoWeight);
                List<Tire> tires = new List<Tire>();

                for (int j = 5; j < carInfo.Length; j += 2)
                {
                    double tirePressure = double.Parse(carInfo[j]);
                    int tireAge = int.Parse(carInfo[j + 1]);
                    Tire tire = new Tire(tireAge, tirePressure);
                    tires.Add(tire);
                }

                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }

            var filteredCars = new List<Car>();
            string command = Console.ReadLine();

            // "fragile" - print all cars whose cargo is "fragile" with a tire, whose pressure is < 1
            // "flamable" - print all of the cars, whose cargo is "flamable" and have engine power > 250
            if (command == "fragile")
            {
                filteredCars = cars.Where(x => x.Cargo.Type == command).Where(x => x.Tires.Any(x => x.Pressure < 1)).ToList();
            }
            else if (command == "flamable")
            {
                filteredCars = cars.Where(x => x.Cargo.Type == command).Where(x => x.Engine.Power > 250).ToList();
            }

            foreach (var item in filteredCars)
            {
                Console.WriteLine(item.Model);
            }
        }
    }
}
