using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Toppings
    {
        private const double MEAT_CAL = 1.2;
        private const double VEGGIES_CAL = 0.8;
        private const double CHEESE = 1.1;
        private const double SAUCE = 0.9;

        private string type;
        private double weight;
        private double calories;

        public Toppings(string type,double weight)
        {
            this.Type = type;
            this.Weight = weight;
            CaloriesCalk();
        }

        public string Type
        {
            get
            {
                return this.type;
            }
            private set
            {
                if (value.ToUpper()!= "MEAT" && value.ToUpper() != "VEGGIES" && value.ToUpper() != "CHEESE" && value.ToUpper() != "SAUCE")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                this.type = value;
            }
        }
        public double Weight
        {
            get
            {
                return this.weight;
            }
            private set
            {
                if (value < 1 || value>50)
                {
                    throw new ArgumentException($"{this.Type} weight should be in the range [1..50].");
                }

                this.weight = value;
            }
        }
        public double Calories { get { return this.calories; } }

        private void CaloriesCalk()
        {
            double extraCal = this.weight * 2;

            switch (Type.ToUpper())
            {
                case "MEAT":
                    extraCal *= MEAT_CAL;
                    break;
                case "VEGGIES":
                    extraCal *= VEGGIES_CAL;
                    break;
                case "CHEESE":
                    extraCal *= CHEESE;
                    break;
                case "SAUCE":
                    extraCal *= SAUCE;
                    break;
                default:
                    break;
            }

            this.calories = extraCal;
        }
    }
}
