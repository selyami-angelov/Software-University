using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();

            string[] pokemonTrainerInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (pokemonTrainerInfo[0] != "Tournament")
            {
                //"{trainerName} {pokemonName} {pokemonElement} {pokemonHealth}"

                string trainerName = pokemonTrainerInfo[0];
                string pokemonName = pokemonTrainerInfo[1];
                string pokemonElem = pokemonTrainerInfo[2];
                int pokemonHealth = int.Parse(pokemonTrainerInfo[3]);
                Pokemon pokemon = new Pokemon(pokemonName, pokemonElem, pokemonHealth);

                if (!trainers.ContainsKey(trainerName))
                {
                    Trainer trainer = new Trainer(trainerName);
                    trainer.Pokemons.Add(pokemon);
                    trainers.Add(trainerName, trainer);
                }
                else
                {
                    trainers[trainerName].Pokemons.Add(pokemon);
                }

                pokemonTrainerInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            string comand = Console.ReadLine();

            while (comand != "End")
            {
                foreach (var item in trainers)
                {

                    if (item.Value.ContainsElement(comand))
                    {
                        item.Value.BadgetsNum++;
                    }
                    else
                    {
                        item.Value.PokemonsHealthDecrease();
                        item.Value.PokemonRemove();
                    }
                }

                comand = Console.ReadLine();
            }

            var orederedTrainers = trainers.OrderByDescending(x => x.Value.BadgetsNum);

            foreach (var trainer in orederedTrainers)
            {
                Console.WriteLine($"{trainer.Value.Name} {trainer.Value.BadgetsNum} {trainer.Value.Pokemons.Count}");
            }
        }
    }
}
