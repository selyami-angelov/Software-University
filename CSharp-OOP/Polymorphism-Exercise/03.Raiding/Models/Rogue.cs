using System;

namespace _03.Raiding.Models
{
    public class Rogue:BaseHero
    {
        private int power = 80;

        public Rogue(string name)
            : base(name)
        {
        }

        public override int Power => this.power;
        public override string CastAbility()
        {
            return base.CastAbility() + " " + String.Format(HIT, this.power);
        }
    }
}
