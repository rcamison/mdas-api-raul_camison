using System;
using System.Collections.Generic;
using Pokemon.Pokemon.Domain;

namespace Pokemon.Pokemon.Infrastructure
{
    public class InMemoryPokemonFavouriteRepository
    {
        private Dictionary<int, int> _pokemons = new Dictionary<int, int>();

        public void Save(PokemonId pokemonId, PokemonFavouriteNumberOfTimes numberOfTimes)
        {
            if (!_pokemons.ContainsKey(pokemonId.Value))
                _pokemons.Add(pokemonId.Value, 0);

            _pokemons[pokemonId.Value] = numberOfTimes.Value;

        }

        public PokemonFavouriteNumberOfTimes Search(PokemonId pokemonId)
        {
            if (!_pokemons.ContainsKey(pokemonId.Value))
                return new PokemonFavouriteNumberOfTimes(0);

            return new PokemonFavouriteNumberOfTimes(_pokemons[pokemonId.Value]);
        }

    }

}