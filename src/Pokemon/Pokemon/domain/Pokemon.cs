namespace Pokemon.Pokemon.Domain
{
    public class Pokemon
    {
        private readonly PokemonId _pokemonId;
        private readonly PokemonName _pokemonName;
        private readonly PokemonHeight _pokemonHeight;
        private readonly PokemonWeight _pokemonWeight;
        private PokemonFavouriteNumberOfTimes _pokemonFavouriteNumberOfTimes;

        private Pokemon(PokemonId pokemonId, PokemonName pokemonName, PokemonHeight pokemonHeight, PokemonWeight pokemonWeight, PokemonFavouriteNumberOfTimes pokemonFavouriteNumberOfTimes)
        {
            _pokemonId = pokemonId;
            _pokemonName = pokemonName;
            _pokemonHeight = pokemonHeight;
            _pokemonWeight = pokemonWeight;
            _pokemonFavouriteNumberOfTimes = pokemonFavouriteNumberOfTimes;
        }

        public static Pokemon Create(PokemonId pokemonId, PokemonName pokemonName, PokemonHeight pokemonHeight, PokemonWeight pokemonWeight, PokemonFavouriteNumberOfTimes pokemonFavouriteNumberOfTimes)
        {
            return new Pokemon(pokemonId, pokemonName, pokemonHeight, pokemonWeight, pokemonFavouriteNumberOfTimes);
        }

        public PokemonId PokemonId => _pokemonId;
        public PokemonName PokemonName => _pokemonName;
        public PokemonHeight PokemonHeight => _pokemonHeight;
        public PokemonWeight PokemonWeight => _pokemonWeight;
        public PokemonFavouriteNumberOfTimes PokemonFavouriteNumberOfTimes => _pokemonFavouriteNumberOfTimes;

        public void IncreasePokemonFavouriteNumberOfTimes()
        {
            _pokemonFavouriteNumberOfTimes = new PokemonFavouriteNumberOfTimes(PokemonFavouriteNumberOfTimes.Value + 1);
        }
    }
}