using System;
using System.Collections.Generic;

namespace _04.WildFarm.Models
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
            this.weightIncr = 0.10;
            this.sound = "Squeak";
            this.prefFood = new List<string>() {"Fruit", "Vegetable" };
        }

        public override string ToString()
        {
            return base.ToString() + $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }

        
    }
}
