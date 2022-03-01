using Xunit;

namespace PokemonTests.Domain
{
    public class PokemonShould
    {
        [Fact]
        public void Increase_PokemonFavouriteNumberOfTimes()
        {
            //Given

            var pokemon = PokemonMother.Random();
            var pokemonFavoriteNumberOfTimes = pokemon.PokemonFavouriteNumberOfTimes;

            //When
            pokemon.IncreasePokemonFavouriteNumberOfTimes();

            //Then
            Assert.True(pokemonFavoriteNumberOfTimes.Value + 1 == pokemon.PokemonFavouriteNumberOfTimes.Value);
        }

    }

}
