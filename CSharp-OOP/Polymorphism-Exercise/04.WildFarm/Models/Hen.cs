using System.Collections.Generic;

namespace _04.WildFarm.Models
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
            this.weightIncr = 0.35;
            this.sound = "Cluck";
            this.prefFood = new List<string>() { "Meat", "Fruit", "Vegetable", "Seeds" };
        }
    }
}
