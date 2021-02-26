using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private List<Pet> pets;

        public Clinic(int capacity)
        {
            this.Capacity = capacity;
            pets = new List<Pet>();
        }
        public int Capacity { get; private set; }
        public int Count { get { return pets.Count; } }

        public void Add(Pet pet)
        {
            if (this.pets.Count<this.Capacity)
            {
                pets.Add(pet);
            }
        }
        public bool Remove(string name)
        {
            Pet petToRemove = this.pets.Find(x => x.Name == name);
            return this.pets.Remove(petToRemove);
        }

        public Pet GetPet(string name, string owner)
        {
            return this.pets.Find(x => x.Name == name && x.Owner == owner);
        }

        public Pet GetOldestPet()
        {
           return pets.OrderBy(x => x.Age).Last();
        }
        public string GetStatistics()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"The clinic has the following patients:");

            foreach (var pet in this.pets)
            {
                result.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }

            return result.ToString().TrimEnd();
        }
    }
}
