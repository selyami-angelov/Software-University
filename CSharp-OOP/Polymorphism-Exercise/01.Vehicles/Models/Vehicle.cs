using _01.Vehicles.Common;

using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles.Models.Contracts
{
    public abstract class Vehicle : IDriveable, IRefuelable
    {
        private const string SUCC_DRIVE_MSG = "{0} travelled {1} km";
        private double fuelQuantity;
        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        protected virtual double AirIncr { get; set; }
        public bool AirCond { get; set; }
        public double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }
            private set
            {
                if (value > this.TankCapacity)
                {
                    this.fuelQuantity = 0;
                }
                else
                {
                    this.fuelQuantity = value;
                }
            }
        }
        public virtual double FuelConsumption { get; protected set; }

        public double TankCapacity { get; private set; }

        public string Drive(double amount)
        {
            if (this.AirCond == true)
            {
                this.FuelConsumption += this.AirIncr;
            }

            double fuelNeed = amount * this.FuelConsumption;

            if (this.FuelQuantity < fuelNeed)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.NotEnoughtFuel, this.GetType().Name));
            }

            this.FuelQuantity -= fuelNeed;
            return String.Format(SUCC_DRIVE_MSG, this.GetType().Name, amount);
        }

        public virtual void Refuel(double amount)
        {
            if (amount <= 0)
            {
                throw new InvalidOperationException
                    (ExceptionMessages.NegFuel);
            }
            else if (this.fuelQuantity + amount > this.TankCapacity)
            {
                throw new InvalidOperationException
                (String.Format(ExceptionMessages.CannotFit, amount));
            }
                this.FuelQuantity += amount;

        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
