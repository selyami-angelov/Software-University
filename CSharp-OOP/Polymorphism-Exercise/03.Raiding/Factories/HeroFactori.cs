using _03.Raiding.Models;

using System;

namespace _03.Raiding.Factories
{
    public abstract class HeroFactori
    {
        private const string INV_HERO = "Invalid hero!";
        public HeroFactori()
        {
            
        }

        public static BaseHero CreateHero(string name,string type)
        {
            BaseHero curHero;

            if (type == "Druid")
            {
                curHero = new Druid(name);
            }
            else if (type == "Paladin")
            {
                curHero = new Paladin(name);
            }
            else if (type == "Rogue")
            {
                curHero = new Rogue(name);
            }
            else if (type == "Warrior")
            {
                curHero = new Warrior(name);
            }
            else
            {
                throw new InvalidOperationException(INV_HERO);
            }

            return curHero;

        }
    }
}
