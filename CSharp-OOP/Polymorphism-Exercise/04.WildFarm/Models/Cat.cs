using System.Collections.Generic;

namespace _04.WildFarm.Models
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
            this.weightIncr = 0.30;
            this.sound = "Meow";
            this.prefFood = new List<string>() { "Meat", "Vegetable" };
        }
    }
}
