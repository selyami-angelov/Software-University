using _04.WildFarm.Models;

namespace _04.WildFarm.Factories
{
    public abstract class FoodFactori
    {
        public static Food CreateFood(string[] parms)
        {
            string type = parms[0];
            int quantity = int.Parse(parms[1]);
            Food food = null;

            if (type == "Fruit")
            {
                food = new Fruit(quantity);
            }
            else if (type == "Meat")
            {
                food = new Meat(quantity);
            }
            else if (type == "Vegetable")
            {
                food = new Vegetable(quantity);
            }
            else if (type == "Seeds")
            {
                food = new Seeds(quantity);
            }

            return food;
        }
    }
}
