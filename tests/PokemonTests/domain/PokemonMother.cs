using Pokemon.Pokemon.Domain;

namespace PokemonTests.Domain
{
    public class PokemonMother
    {
        public static Pokemon.Pokemon.Domain.Pokemon Random()
        {
            PokemonId pokemonId = PokemonIdMother.Random();
            PokemonName pokemonName = PokemonNameMother.Random();
            PokemonHeight pokemonHeight = PokemonHeightMother.Random();
            PokemonWeight pokemonWeight = PokemonWeightMother.Random();
            var pokemonFavouriteNumberOfTimes = new PokemonFavouriteNumberOfTimes(0);

            return Pokemon.Pokemon.Domain.Pokemon.Create(pokemonId, pokemonName, pokemonHeight, pokemonWeight, pokemonFavouriteNumberOfTimes);
        }

        public static Pokemon.Pokemon.Domain.Pokemon Random(PokemonId pokemonId)
        {
            PokemonName pokemonName = PokemonNameMother.Random();
            PokemonHeight pokemonHeight = PokemonHeightMother.Random();
            PokemonWeight pokemonWeight = PokemonWeightMother.Random();
            var pokemonFavouriteNumberOfTimes = new PokemonFavouriteNumberOfTimes(0);

            return Pokemon.Pokemon.Domain.Pokemon.Create(pokemonId, pokemonName, pokemonHeight, pokemonWeight, pokemonFavouriteNumberOfTimes);
        }
    }
}