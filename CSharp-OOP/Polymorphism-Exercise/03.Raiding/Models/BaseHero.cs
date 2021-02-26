using System;

namespace _03.Raiding.Models
{
    public abstract class BaseHero
    {
        protected const string HEALED = "healed for {0}";
        protected const string HIT = "hit for {0} damage";
        protected const string TYPE_NAME = "{0} - {1}";

        public BaseHero(string name)
        {
            this.Name = name;
        }
        public string Name { get; set; }
        public virtual int Power { get; set; }


        public virtual string CastAbility()
        {
            return String.Format(TYPE_NAME,this.GetType().Name,this.Name);
        }
    }
}
