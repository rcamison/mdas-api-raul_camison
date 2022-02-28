using Shared.Events.Domain;

namespace Users.User.Domain
{
    public class User : EntityBase
    {
        private readonly UserId _userId;
        private readonly UserName _userName;
        private readonly PokemonFavoritesCollection _pokemonFavorites;

        private User(UserId userId, UserName userName)
        {
            _userId = userId;
            _userName = userName;
            _pokemonFavorites = new PokemonFavoritesCollection();
        }

        public static User Create(UserId id, UserName userName)
        {
            return new User(id, userName);
        }

        public UserId Id => _userId;
        public UserName UserName => _userName;
        public PokemonFavoritesCollection PokemonFavorites => _pokemonFavorites;

        public void AddPokemonFavorite(PokemonFavorite pokemonFavorite)
        {
            GuardAgainstPokemonFavoriteAlreadyExist(pokemonFavorite);

            _pokemonFavorites.Add(pokemonFavorite);

            AddDomainEvent(new PokemonFavoriteCreatedEvent(new EventAggregateId(pokemonFavorite.PokemonId.Value.ToString())));
        }

        #region Metodos privados

        private void GuardAgainstPokemonFavoriteAlreadyExist(PokemonFavorite favorite)
        {
            if (_pokemonFavorites.Any(p => p.PokemonId == favorite.PokemonId))
                throw new PokemonFavoriteAlreadyExistException();
        }

        #endregion

    }
}
