using System;

namespace _03.Raiding.Models
{
    public class Druid : BaseHero
    {
        
        private int power = 80;

        public Druid(string name)
            : base(name)
        {
        }

        public override int Power => this.power;

        public override string CastAbility()
        {
            return base.CastAbility() + " " + String.Format(HEALED, this.power);
        }
    }
}
