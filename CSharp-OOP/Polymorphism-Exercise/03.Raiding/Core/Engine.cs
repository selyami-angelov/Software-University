using _03.Raiding.Core.Contracts;
using _03.Raiding.Factories;
using _03.Raiding.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.Raiding.Core
{
    public class Engine : IEngine
    {

        public Engine()
        {

        }

        public void Run()
        {
            int heroesNum = int.Parse(Console.ReadLine());
            List<BaseHero> heroes = new List<BaseHero>();

            while (heroes.Count != heroesNum)
            {
                try
                {
                    heroes.Add(ProcessHero());

                }
                catch (Exception ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }

            int boss = int.Parse(Console.ReadLine());
            heroes.ForEach(x => Console.WriteLine(x.CastAbility()));

            if (heroes.Sum(x => x.Power) >= boss)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }

        }

        public BaseHero ProcessHero()
        {
            string name = Console.ReadLine();
            string type = Console.ReadLine();

            return HeroFactori.CreateHero(name, type);
        }
    }
}
