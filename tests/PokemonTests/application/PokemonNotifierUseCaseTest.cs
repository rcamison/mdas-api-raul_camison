using Moq;
using Pokemon.Pokemon.Application;
using Pokemon.Pokemon.Domain;
using PokemonTests.Domain;
using Xunit;

namespace PokemonTests.Application
{
    public class PokemonNotifierUseCaseTest
    {
        [Fact]
        public void Should_Invoke_PokemonSaver()
        {
            //Given
            var pokemonCreator = new Mock<PokemonCreator>(It.IsAny<IPokemonRepository>());
            var pokemonNotifierUseCaseTest = new PokemonNotifierUseCase(pokemonCreator.Object);
            var pokemonId = PokemonIdMother.Random();

            //When
            pokemonNotifierUseCaseTest.Execute(pokemonId.Value);

            //Then
            pokemonCreator.Verify(_ => _.Execute(It.IsAny<PokemonId>()), Times.Once);
        }
    }
}
