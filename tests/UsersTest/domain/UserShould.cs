using Moq;
using Users.User.Domain;
using Users.User.Infrastructure;
using Xunit;

namespace UsersTest.Domain
{
    public class UserShould
    {
        [Fact]
        public void Throw_An_Exception_When_PokemonFavorite_Already_Exists()
        {
            //Given
            var pokemonId = PokemonIdMother.Random();
            var pokemonFavorite = PokemonFavoriteMother.Random(pokemonId);

            var userGuid = GuidCreator.Execute();
            var userId = UserIdMother.Random(userGuid);
            var user = UserMother.Random_With_A_Favourite(userId, It.IsAny<UserName>(), pokemonFavorite);

            //When - Then
            Assert.Throws<PokemonFavoriteAlreadyExistException>(() => user.AddPokemonFavorite( pokemonFavorite));
        }

        [Fact]
        public void Add_PokemonFavorite()
        {
            //Given
            var pokemonId = PokemonIdMother.Random();
            var pokemonFavorite = PokemonFavoriteMother.Random(pokemonId);
            
            var userGuid = GuidCreator.Execute();
            var userId = UserIdMother.Random(userGuid);
            var user = UserMother.Random(userId, It.IsAny<UserName>());

            //When
            user.AddPokemonFavorite(pokemonFavorite);

            //Then
            Assert.Contains<PokemonFavorite>(pokemonFavorite, user.PokemonFavorites);
        }
    }
}
 