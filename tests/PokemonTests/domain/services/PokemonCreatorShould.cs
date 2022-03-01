using Moq;
using Pokemon.Pokemon.Domain;
using Xunit;

namespace PokemonTests.Domain
{
    public class PokemonCreatorShould
    {
        [Fact]
        public void Create_A_Pokemon()
        {
            //Given
            var pokemonRepository = new Mock<IPokemonRepository>();
            var pokemon = PokemonMother.Random();
            pokemonRepository.Setup(_ => _.Exists(It.IsAny<PokemonId>())).Returns(true);
            pokemonRepository.Setup(_ => _.Find(It.IsAny<PokemonId>())).Returns(pokemon);
            var _pokemonCreator = new PokemonCreator(pokemonRepository.Object);

            //When
            _pokemonCreator.Execute(pokemon.PokemonId);

            //Then
            pokemonRepository.Verify(v => v.Save(It.IsAny<Pokemon.Pokemon.Domain.Pokemon>()));
        }

        [Fact]
        public void Throw_An_Exception_When_Pokemon_Does_Not_Exists()
        {
            //Given
            var pokemonRepository = new Mock<IPokemonRepository>();
            pokemonRepository.Setup(_ => _.Exists(It.IsAny<PokemonId>())).Returns(false);
            var _pokemonCreator = new PokemonCreator(pokemonRepository.Object);

            //When - Then
            Assert.Throws<PokemonNotFoundException>(() => _pokemonCreator.Execute(PokemonIdMother.Random()));
            pokemonRepository.Verify(_ => _.Exists(It.IsAny<PokemonId>()), Times.Once);
            pokemonRepository.Verify(_ => _.Save(It.IsAny<Pokemon.Pokemon.Domain.Pokemon>()), Times.Never);
        }
    }
}