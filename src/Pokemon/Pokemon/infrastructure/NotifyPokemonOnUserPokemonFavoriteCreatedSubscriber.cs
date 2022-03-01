using Microsoft.Extensions.Hosting;
using Pokemon.Pokemon.Application;
using Shared.Events.Domain;
using System.Threading;
using System.Threading.Tasks;
using Users.User.Domain;

namespace Pokemon.Pokemon.Infrastructure
{
    public class NotifyPokemonOnUserPokemonFavoriteCreatedSubscriber : BackgroundService
    {
        private readonly PokemonNotifierUseCase _pokemonNotifierUseCase;
        private readonly IEventBus _eventBus;

        public NotifyPokemonOnUserPokemonFavoriteCreatedSubscriber(PokemonNotifierUseCase pokemonNotifierUseCase,
                                                                   IEventBus eventBus)
        {
            _pokemonNotifierUseCase = pokemonNotifierUseCase;
            _eventBus = eventBus;
        }

        public async void OnUserPokemonFavoriteCreated()
        {
            //var @event = _eventBus.Consume("", "");

            _pokemonNotifierUseCase.Execute();
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _eventBus.Consume("UserExchange", "UserPokemonFavorites", "Pokemon added to user Favorites",
                    message =>
                    {
                        Task.Run(() => { TreatEvent(@event); }, stoppingToken);
                    }
                );

            return Task.CompletedTask;
        }

        private void TreatEvent(PokemonFavoriteCreatedEvent @event)
        {
            _pokemonNotifierUseCase.Execute(int.Parse(@event.EventAggregateId.Value));
        }
    }
}
