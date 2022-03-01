
using Pokemon.Pokemon.Domain;

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
