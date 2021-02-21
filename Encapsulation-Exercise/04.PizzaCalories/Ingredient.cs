using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Ingredient
    {
        private string type;
        private double weight;
        private double calories;

        public Ingredient(string type,double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        public string Type { get; set; }
        public double Weight { get; set; }
        public double Calories
        {
            get
            {
                return this.calories;
            }
        }


    }
}
