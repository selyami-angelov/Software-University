using _01.Vehicles.Core.Contracts;
using _01.Vehicles.Factories;
using _01.Vehicles.Models.Contracts;

using System;

namespace _01.Vehicles.Core
{
    public class Engine : IEngine
    {
        private VehicleFactori vehicleFactori;

        public Engine()
        {
            this.vehicleFactori = new VehicleFactori();
        }
        public void Run()
        {
            Vehicle car = this.ProcessVehicleInfo();
            Vehicle truck = this.ProcessVehicleInfo();
            Vehicle bus = this.ProcessVehicleInfo();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] cmdArg = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string cmdType = cmdArg[0];
                string vehicleType = cmdArg[1];

                double argument = double.Parse(cmdArg[2]);

                try
                {

                    if (cmdType == "Drive")
                    {
                        if (vehicleType == "Car")
                        {
                            this.Drive(car, argument);
                        }
                        else if (vehicleType == "Truck")
                        {
                            this.Drive(truck, argument);
                        }
                        else if (vehicleType == "Bus")
                        {
                            bus.AirCond = true;
                            this.Drive(bus, argument);
                        }
                    }
                    else if (cmdType == "DriveEmpty")
                    {
                        bus.AirCond = false;
                        this.Drive(bus, argument);
                        
                    }
                    else if (cmdType == "Refuel")
                    {
                        if (vehicleType == "Car")
                        {
                            this.Refuel(car, argument);
                        }
                        else if (vehicleType == "Truck")
                        {
                            this.Refuel(truck, argument);
                        }
                        else if (vehicleType == "Bus")
                        {
                            this.Refuel(bus, argument);
                        }
                    }
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }

            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }

        public void Refuel(Vehicle vehicle,double amount)
        {
            vehicle.Refuel(amount);
        }
        public void Drive(Vehicle vehicle,double kilometers)
        {

            Console.WriteLine(vehicle.Drive(kilometers));
            
        }

        private Vehicle ProcessVehicleInfo()
        {
            string[] vehicleArg = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string vehicleType = vehicleArg[0];
            double fuelQuant = double.Parse(vehicleArg[1]);
            double fuelConsump = double.Parse(vehicleArg[2]);
            double tankCapacity = double.Parse(vehicleArg[3]);

            Vehicle curVehcle = this.vehicleFactori.CreateVehicle(vehicleType, fuelQuant, fuelConsump,tankCapacity);
            return curVehcle;
        }
    }
}
