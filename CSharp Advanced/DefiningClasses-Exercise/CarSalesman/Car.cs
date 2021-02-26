using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    class Car
    {
        public Car()
        {

        }
        public Car(string model, Engine engine, int weight, string color)
        {
            Model = model;
            Engine = engine;
            Weight = weight;
            Color = color;
        }
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
            StringBuilder carInfo = new StringBuilder();

            carInfo.AppendLine($"{Model}:");
            carInfo.AppendLine($"  {Engine.Model}:");
            carInfo.AppendLine($"    Power: {Engine.Power}");

            if (Engine.Displacement == 0)
            {
                carInfo.AppendLine($"    Displacement: n/a");
            }
            else
            {
                carInfo.AppendLine($"    Displacement: {Engine.Displacement}");
            }

            if (Engine.Efficiency == null)
            {
                carInfo.AppendLine($"    Efficiency: n/a");
            }
            else
            {
                carInfo.AppendLine($"    Efficiency: {Engine.Efficiency}");

            }

            if (Weight == 0)
            {
                carInfo.AppendLine($"  Weight: n/a");
            }
            else
            {
                carInfo.AppendLine($"  Weight: {Weight}");
            }

            if (Color == null)
            {
                carInfo.AppendLine($"  Color: n/a");
            }
            else
            {
                carInfo.AppendLine($"  Color: {Color}");
            }

            return carInfo.ToString().TrimEnd();

        }
    }
}
