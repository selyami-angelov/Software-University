using _01.Vehicles.Common;
using _01.Vehicles.Models;
using _01.Vehicles.Models.Contracts;

using System;

namespace _01.Vehicles.Factories
{
    public class VehicleFactori
    {
        public VehicleFactori()
        {

        }
        public Vehicle CreateVehicle(string vehicleType,double fuelQuant,double fuelConsump,double tankCapacity)
        {
            Vehicle vehicle;

            if (vehicleType == "Car")
            {
                vehicle = new Car(fuelQuant, fuelConsump,tankCapacity);
            }
            else if (vehicleType == "Truck")
            {
                vehicle = new Truck(fuelQuant, fuelConsump,tankCapacity);
            }
            else if (vehicleType == "Bus")
            {
                vehicle = new Bus(fuelQuant, fuelConsump, tankCapacity);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidVehicleType);
            }

            return vehicle;
        }
    }
}
