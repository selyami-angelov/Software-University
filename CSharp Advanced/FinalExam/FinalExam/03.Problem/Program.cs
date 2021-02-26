using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] comandsData = Console.ReadLine().Split(':', StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, Person> persons = new Dictionary<string, Person>();

            while (comandsData[0] != "Results")
            {
                string comand = comandsData[0];

                if (comand == "Add")
                {
                    string name = comandsData[1];
                    int health = int.Parse(comandsData[2]);
                    int energy = int.Parse(comandsData[3]);

                    if (!persons.ContainsKey(name))
                    {
                        Person curPerson = new Person(health, energy);
                        persons.Add(name, curPerson);
                    }
                    else
                    {
                        persons[name].Health += health;
                    }
                }
                else if (comand == "Attack")
                {
                    string atacker = comandsData[1];
                    string defender = comandsData[2];
                    int damage = int.Parse(comandsData[3]);

                    if (persons.ContainsKey(atacker) && persons.ContainsKey(defender))
                    {
                        persons[defender].Health -= damage;
                        persons[atacker].Energy--;

                        if (persons[defender].Health <= 0)
                        {
                            persons.Remove(defender);
                            Console.WriteLine($"{defender} was disqualified!");
                        }
                        if (persons[atacker].Energy <= 0)
                        {
                            persons.Remove(atacker);
                            Console.WriteLine($"{atacker} was disqualified!");
                        }
                    }
                }
                else if (comand == "Delete")
                {
                    string user = comandsData[1];

                    if (user == "All")
                    {
                        //??
                        persons.Clear();
                    }
                    else
                    {
                        if (persons.ContainsKey(user))
                        {
                            persons.Remove(user);
                        }
                    }
                }

                comandsData = Console.ReadLine().Split(':', StringSplitOptions.RemoveEmptyEntries);
            }

            if (persons.Count != 0)
            {
                var sortedPersons = persons.OrderByDescending(x => x.Value.Health).ThenBy(x => x.Key);
                Console.WriteLine($"People count: {persons.Count}");

                foreach (var item in sortedPersons)
                {
                    Console.WriteLine($"{item.Key} - {item.Value.Health} - {item.Value.Energy}");
                }
            }
        }
    }

    class Person
    {
        public Person(int health, int energy)
        {
            Health = health;
            Energy = energy;
        }

        public int Health { get; set; }
        public int Energy { get; set; }
    }
}
