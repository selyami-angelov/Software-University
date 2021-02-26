using System.Collections.Generic;

namespace _04.WildFarm.Models
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
            this.weightIncr = 0.25;
            this.sound = "Hoot Hoot";
            this.prefFood = new List<string>() { "Meat" };
        }
    }
}
