using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    class Tesla : ICar,IElectricCar
    {
        private string model;
        private string color;
        private int battery;

        public Tesla(string name, string color, int battery)
        {
            this.Model = name;
            this.Color = color;
            this.Battery = battery;
        }

        public string Model { get; set; }
        public string Color { get; set; }
        public int Battery { get; set; }

        public string Start()
        {
            return"Engine start";
        }

        public string Stop()
        {
            return"Breaaak!";
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"{this.Color} {this.Model} with {this.Battery} Batteries");
            result.AppendLine(this.Start());
            result.AppendLine(this.Stop());

            return result.ToString().TrimEnd();
        }
    }
}
