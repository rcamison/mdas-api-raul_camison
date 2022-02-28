using MediatR;

namespace Users.User.Domain
{
    public class UserAddPokemonFavorite
    {
        private readonly IUserRepository _userRepository;
        private readonly IMediator _mediator;

        public UserAddPokemonFavorite(IUserRepository userRepository, IMediator mediator)
        {
            _userRepository = userRepository;
            _mediator = mediator;
        }

        public virtual void Execute(UserId userId, PokemonFavorite pokemonFavorite)
        {
            if (!_userRepository.Exists(userId))
                throw new UserDoesNotExistException();

            var user = _userRepository.Find(userId);

            user.AddPokemonFavorite(pokemonFavorite);

            var events = user.DomainEvents;
            foreach (var @event in events)
            {
                _mediator.Publish(@event);
            }
            user.ClearDomainEvents();

            _userRepository.Save(user);
        }
    }
}
