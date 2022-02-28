using MediatR;
using Shared.Events.Domain;
using Users.User.Domain;

namespace Users.User.Application
{
    public class AddPokemonFavoriteUseCase : INotificationHandler<PokemonFavoriteCreatedEvent>
    {
        private readonly UserAddPokemonFavorite _userAddPokemonFavorite;
        private readonly IEventBus _queue;

        public AddPokemonFavoriteUseCase(UserAddPokemonFavorite userAddPokemonFavorite, IEventBus queue)
        {
            _userAddPokemonFavorite = userAddPokemonFavorite;
            _queue = queue;
        }

        public void Execute(Guid userIdparam, int pokemonIdparam)
        {
            var userId = new UserId(userIdparam);
            var pokemonId = new PokemonId(pokemonIdparam);
            var pokemonFavorite = PokemonFavorite.Create(pokemonId);

            _userAddPokemonFavorite.Execute(userId, pokemonFavorite);
        }

        public Task Handle(PokemonFavoriteCreatedEvent notification, CancellationToken cancellationToken)
        {
            return _queue.Publish("UserExchange", "UserPokemonFavorites", notification);
        }
    }
}
