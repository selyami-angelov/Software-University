using _04.WildFarm.Models;
using _04.WildFarm.Models.Contracts;

using System;
using System.Linq;
using System.Reflection;

namespace _04.WildFarm.Factories
{
    public abstract class AnimalFactori
    {

        public static Animal CreateAnimal(string[] parms)
        {
            Animal animal = null;
            string type = parms[0];
            string name = parms[1];
            double weight = double.Parse(parms[2]);

            if (type == "Hen")
            {
                double wingSize = double.Parse(parms[3]);

                animal = new Hen(name, weight, wingSize);
            }
            else if (type == "Owl")
            {
                double wingSize = double.Parse(parms[3]);
                animal = new Owl(name, weight, wingSize);
            }
            else if (type == "Mouse")
            {
                animal = new Mouse(name, weight,parms[3]);
            }
            else if (type == "Cat")
            {
                animal = new Cat(name, weight,parms[3],parms[4]);
            }
            else if (type == "Dog")
            {
                animal = new Dog(name, weight,parms[3]);
            }
            else if (type == "Tiger")
            {
                animal = new Tiger(name, weight,parms[3],parms[4]);
            }

            return animal;

        }
    }
}
