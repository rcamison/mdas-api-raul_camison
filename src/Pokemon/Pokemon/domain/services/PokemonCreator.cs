
using System;

namespace Pokemon.Pokemon.Domain
{
    public class PokemonCreator
    {
        private readonly IPokemonRepository _pokemonRepository;

        public PokemonCreator(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        public virtual void Execute(PokemonId pokemonId)
        {
            if (!_pokemonRepository.Exists(pokemonId))
                throw new PokemonNotFoundException();

            var pokemon = _pokemonRepository.Find(pokemonId);
            pokemon.IncreasePokemonFavouriteNumberOfTimes();

            pokemon = Domain.Pokemon.Create(pokemonId, pokemon.PokemonName, pokemon.PokemonHeight, pokemon.PokemonWeight, pokemon.PokemonFavouriteNumberOfTimes);
            _pokemonRepository.Save(pokemon);
        }
    }
}
