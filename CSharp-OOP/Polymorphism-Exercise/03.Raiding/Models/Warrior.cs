using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding.Models
{
    public class Warrior : BaseHero
    {
        private int power = 100;

        public Warrior(string name)
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
