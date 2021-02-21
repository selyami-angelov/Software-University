
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<List<Tire>> tires = new List<List<Tire>>();
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            while (input != "No more tires")
            {
                double[] tiresAndPressure = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();
                List<Tire> curTires = new List<Tire>();

                for (int i = 0; i < tiresAndPressure.Length; i += 2)
                {
                    int year = (int)tiresAndPressure[i];
                    double pressure = tiresAndPressure[i + 1];
                    Tire tire = new Tire(year, pressure);
                    curTires.Add(tire);
                }

                tires.Add(curTires);

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "Engines done")
            {
                int horsePower = int.Parse(input.Split(" ", StringSplitOptions.RemoveEmptyEntries)[0]);
                double cubicCapacity = double.Parse(input.Split(" ", StringSplitOptions.RemoveEmptyEntries)[1]);
                Engine engine = new Engine(horsePower, cubicCapacity);
                engines.Add(engine);

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "Show special")
            {
                string make = input.Split(" ", StringSplitOptions.RemoveEmptyEntries)[0];
                string model = input.Split(" ", StringSplitOptions.RemoveEmptyEntries)[1];
                int year = int.Parse(input.Split(" ", StringSplitOptions.RemoveEmptyEntries)[2]);
                double fuelQuantity = double.Parse(input.Split(" ", StringSplitOptions.RemoveEmptyEntries)[3]);
                double fuelConsumption = double.Parse(input.Split(" ", StringSplitOptions.RemoveEmptyEntries)[4]);
                int engineIndex = int.Parse(input.Split(" ", StringSplitOptions.RemoveEmptyEntries)[5]);
                int tiresIndex = int.Parse(input.Split(" ", StringSplitOptions.RemoveEmptyEntries)[6]);
                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], tires[tiresIndex]);
                cars.Add(car);

                input = Console.ReadLine();
            }

            List<Car> specialCars = SpecialCars(cars);
            DriveKilometers(specialCars);

            foreach (var item in specialCars)
            {
                Console.WriteLine(Print(item));
            }

        }

        public static List<Car> SpecialCars(List<Car> cars)
        {
            List<Car> specialCars = new List<Car>();

            foreach (var item in cars)
            {
                if (item.Year >= 2017 && item.Engine.HorsePower >= 330 && item.Tires.Select(x => x.Pressure).Sum() > 9 && item.Tires.Select(x => x.Pressure).Sum() < 10)
                {
                    specialCars.Add(item);
                }
            }

            return specialCars;
        }

        public static void DriveKilometers(List<Car> cars)
        {
            foreach (var item in cars)
            {
                item.FuelQuantity -= ((item.FuelConsumption / 100) * 20);
            }
        }

        public static string Print(Car car)
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Make: {car.Make}");
            result.AppendLine($"Model: {car.Model}");
            result.AppendLine($"Year: {car.Year}");
            result.AppendLine($"HorsePowers: {car.Engine.HorsePower}");
            result.AppendLine($"FuelQuantity: {car.FuelQuantity}");

            return result.ToString().TrimEnd();
        }
    }
}
