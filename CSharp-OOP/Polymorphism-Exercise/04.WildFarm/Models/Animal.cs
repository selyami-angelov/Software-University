using _04.WildFarm.Models.Contracts;

using System;
using System.Collections;
using System.Collections.Generic;

namespace _04.WildFarm.Models
{
    public abstract class Animal : IAnimal
    {
        protected const string NOT_EAT = "{0} does not eat {1}!";
        protected string sound;
        protected List<string> prefFood;
        protected double weightIncr; 
        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name { get; private set; }
        public double Weight { get; protected set; }
        public int FoodEaten { get; protected set; }

        public string AskForFood()
        {
            return this.sound;
        }

        public virtual void Feed(Food food)
        {
            if (!this.prefFood.Contains(food.GetType().Name))
            {
                throw new InvalidOperationException(String.Format(NOT_EAT, this.GetType().Name, food.GetType().Name));
            }

            this.Weight += food.Quantity*this.weightIncr;
            this.FoodEaten = food.Quantity;

        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }

        public void ImHungry()
        {
            Console.WriteLine(this.sound);
        }


    }
}
