using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pokemon.Pokemon.Domain;
using Pokemon.Pokemon.domain.services;

namespace Pokemon.Pokemon.Application
{
    public class PokemonNotifierUseCase
    {
        private readonly PokemonCreator _pokemonCreator;

        public PokemonNotifierUseCase(PokemonCreator pokemonCreator)
        {
            _pokemonCreator = pokemonCreator;
        }

        public void Execute(int pokemonIdparam)
        {
            var pokemonId = new PokemonId(pokemonIdparam);

            _pokemonCreator.Execute(pokemonId);
        }
    }
}
