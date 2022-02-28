using Moq;
using Users.User.Domain;

namespace UsersTest.Domain
{

    public class UserMother 
    {
        public static User Random()
        {
            UserId userId = UserIdMother.Random();
            UserName userName = new UserName(Faker.Name.First());

            return User.Create(userId, userName); 
        }

        public static User Random(UserId userId, UserName userName)
        {
            return User.Create(userId, userName);
        }

        public static User Random_With_A_Favourite(UserId userId, UserName userName, PokemonFavorite pokemonFavorite)
        {
            var user =  User.Create(userId, userName);
            user.AddPokemonFavorite(pokemonFavorite);

            return user;
        }
    }
}
