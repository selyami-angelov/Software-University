using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.HeroesOfCodeAndLogicVII
{
    class Program
    {
        static void Main(string[] args)
        {
            int heroesCount = int.Parse(Console.ReadLine());
            Dictionary<string, Hero> heroes = new Dictionary<string, Hero>();

            for (int i = 0; i < heroesCount; i++)
            {
                string[] heroesData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = heroesData[0];
                int hP = int.Parse(heroesData[1]);
                int mP = int.Parse(heroesData[2]);

                Hero curHero = new Hero(name, hP, mP);
                if (!heroes.ContainsKey(name))
                {
                    heroes.Add(name, curHero);
                }
            }

            string[] comandsData = Console.ReadLine().Split(" - ", StringSplitOptions.RemoveEmptyEntries);

            while (comandsData[0] != "End")
            {
                string action = comandsData[0];
                string heroName = comandsData[1];
                int numberToken = int.Parse(comandsData[2]);
                string result = string.Empty;

                if (action == "CastSpell")
                {
                    string spellName = comandsData[3];

                    if (heroes[heroName].MP >= numberToken)
                    {
                        heroes[heroName].MP -= numberToken;
                        result = $"{heroName} has successfully cast {spellName} and now has {heroes[heroName].MP} MP!";
                    }
                    else
                    {
                        result = $"{heroName} does not have enough MP to cast {spellName}!";
                    }
                }
                else if (action == "TakeDamage")
                {
                    string attacker = comandsData[3];
                    heroes[heroName].HP -= numberToken;

                    if (heroes[heroName].HP > 0)
                    {
                        result = $"{heroName} was hit for {numberToken} HP by {attacker} and now has {heroes[heroName].HP} HP left!";
                    }
                    else
                    {
                        result = $"{heroName} has been killed by {attacker}!";
                        heroes.Remove(heroName);
                    }
                }
                else if (action == "Recharge")
                {
                    

                    if ((heroes[heroName].MP + numberToken) > 200)
                    {
                        int rechargetAmount = 200 - heroes[heroName].MP;
                        heroes[heroName].MP = 200;
                        result = $"{heroName} recharged for {rechargetAmount} MP!";
                    }
                    else
                    {
                        heroes[heroName].MP += numberToken;
                        result = $"{heroName} recharged for {numberToken} MP!";
                    }

                    Console.WriteLine(result);
                }
                else if (action == "Heal")
                {

                    if ((heroes[heroName].HP + numberToken) > 100)
                    {
                        int healedAmount = 100 - heroes[heroName].HP;
                        heroes[heroName].HP = 100;
                        result = $"{heroName} healed for {healedAmount} HP!";
                    }
                    else
                    {
                        heroes[heroName].HP += numberToken;
                        result = $"{heroName} healed for {numberToken} HP!";
                    }

                    Console.WriteLine(result);
                }

                comandsData = Console.ReadLine().Split(" - ", StringSplitOptions.RemoveEmptyEntries);
            }

            var orderedHeroes = heroes.OrderByDescending(x => x.Value.HP).ThenBy(x => x.Key);

            foreach (var item in orderedHeroes)
            {
                Console.WriteLine(item.Key);
                Console.WriteLine($"  HP: {item.Value.HP}");
                Console.WriteLine($"  MP: {item.Value.MP}");
            }
        }

        class Hero
        {
            public string Name { get; set; }
            public int HP { get; set; }
            public int MP { get; set; }

            public Hero(string name, int hP, int mP)
            {
                Name = name;
                HP = hP;
                MP = mP;
            }
        }
    }
}
