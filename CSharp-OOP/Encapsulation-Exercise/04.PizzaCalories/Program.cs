using System;

namespace _04.PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine().Split()[1];
            string[] doughInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string type = doughInfo[1];
            string tech = doughInfo[2];
            double weight = double.Parse(doughInfo[3]);
            try
            {
                Dough dought = new Dough(type, tech, weight);
                Pizza pizza = new Pizza(name, dought);

                string toppingInfo = Console.ReadLine();

                while (toppingInfo != "END")
                {
                    string topType = toppingInfo.Split(" ", StringSplitOptions.RemoveEmptyEntries)[1];
                    double topWeight = double.Parse(toppingInfo.Split(" ", StringSplitOptions.RemoveEmptyEntries)[2]);
                    Toppings topping = new Toppings(topType, topWeight);
                    pizza.AddTopping(topping);

                    toppingInfo = Console.ReadLine();
                }

                Console.WriteLine(pizza);
            }
            catch (Exception ae)
            {

                Console.WriteLine(ae.Message);
            }
            
        }
    }
}
