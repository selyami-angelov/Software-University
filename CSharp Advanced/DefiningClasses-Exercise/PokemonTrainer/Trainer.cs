using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTrainer
{
    public class Trainer
    {
        public Trainer(string name)
        {
            Name = name;
            BadgetsNum = 0;
            Pokemons = new List<Pokemon>();
        }
        public string  Name { get; set; }
        public int  BadgetsNum { get; set; }
        public List<Pokemon>  Pokemons { get; set; }

        public bool ContainsElement(string element)
        {
            foreach (var item in Pokemons)
            {
                if (item.Element == element)
                {
                    return true;
                }
            }
                return false;
        }

        public void PokemonsHealthDecrease()
        {
            foreach (var item in Pokemons)
            {
                item.Health -= 10;
            }
        }

        public void PokemonRemove()
        {
            Pokemons.RemoveAll(x => x.Health <= 0);
        }
    }
}
