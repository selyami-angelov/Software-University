using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace SpeedRacing
{
    class Car
    {
        public Car(string model,double fuelAmount,double fuelConsumptionPerKilometer,double travelledDistance)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            TravelledDistance = travelledDistance;
        }

        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }

        public void driveCar(int km)
        {
            if (km* FuelConsumptionPerKilometer<=FuelAmount)
            {
                FuelAmount -= km * FuelConsumptionPerKilometer;
                TravelledDistance += km;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

    }
}
