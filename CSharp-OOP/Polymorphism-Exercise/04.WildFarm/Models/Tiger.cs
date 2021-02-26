using System.Collections.Generic;

namespace _04.WildFarm.Models
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
            this.weightIncr = 1.00;
            this.sound = "ROAR!!!";
            this.prefFood = new List<string>() { "Meat" };
        }
    }
}
