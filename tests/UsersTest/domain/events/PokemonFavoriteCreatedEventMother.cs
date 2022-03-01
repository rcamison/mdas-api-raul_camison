using Users.User.Domain;

namespace UsersTest.Domain
{
    public class PokemonFavoriteCreatedEventMother
    {
        public static PokemonFavoriteCreatedEvent Random()
        {
            return new PokemonFavoriteCreatedEvent(Faker.RandomNumber.Next(0, 100).ToString());

        }
    }

}
