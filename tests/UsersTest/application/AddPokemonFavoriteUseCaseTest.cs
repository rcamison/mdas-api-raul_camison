using System.Threading;
using MediatR;
using Moq;
using Shared.Events.Domain;
using Users.User.Application;
using Users.User.Domain;
using Users.User.Infrastructure;
using UsersTest.Domain;
using Xunit;

namespace UsersTest.Application
{
    public class AddPokemonFavoriteUseCaseTest
    {
        [Fact]
        public void Should_Add_A_PokemonFavorite()
        {
            //Given
            var userGuid = GuidCreator.Execute();
            var userId = UserIdMother.Random(userGuid);
            var user = UserMother.Random(userId, It.IsAny<UserName>());
            var pokemonId = PokemonIdMother.Random();
            var userAddPokemonFavorite = new Mock<UserAddPokemonFavorite>(It.IsAny<IUserRepository>(), It.IsAny<IMediator>());
            userAddPokemonFavorite.Setup(_ => _.Execute(It.IsAny<UserId>(), It.IsAny<PokemonFavorite>()));
            var eventBus = new Mock<IEventBus>();
            var addPokemonFavoriteUseCase = new AddPokemonFavoriteUseCase(userAddPokemonFavorite.Object, eventBus.Object);

            //When
            addPokemonFavoriteUseCase.Execute(user.Id.Value, pokemonId.Value);

            //Then
            userAddPokemonFavorite.Verify(v => v.Execute(It.IsAny<UserId>(), It.IsAny<PokemonFavorite>()));
        }

        [Fact]
        public void Should_Publish_A_PokemonFavoriteCreatedEvent()
        {
            //Given
            var eventBus = new Mock<IEventBus>();

            var pokemonFavoriteCreatedEvent = PokemonFavoriteCreatedEventMother.Random();
            CancellationToken cancellationToken = new CancellationToken();
            var userAddPokemonFavorite = new Mock<UserAddPokemonFavorite>(It.IsAny<IUserRepository>(), It.IsAny<IMediator>());
            var addPokemonFavoriteUseCase = new AddPokemonFavoriteUseCase(userAddPokemonFavorite.Object, eventBus.Object);

            //When
            addPokemonFavoriteUseCase.Handle(pokemonFavoriteCreatedEvent, cancellationToken);

            //Then
            eventBus.Verify(v => v.Publish(It.IsAny<string>(), It.IsAny<string>(), pokemonFavoriteCreatedEvent));
        }
    }
}