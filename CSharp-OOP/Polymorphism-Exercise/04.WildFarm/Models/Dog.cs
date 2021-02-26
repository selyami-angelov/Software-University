using System.Collections.Generic;

namespace _04.WildFarm.Models
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
            this.weightIncr = 0.40;
            this.sound = "Woof!";
            this.prefFood = new List<string>() { "Meat"};
        }

        public override string ToString()
        {
            return base.ToString() + $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
