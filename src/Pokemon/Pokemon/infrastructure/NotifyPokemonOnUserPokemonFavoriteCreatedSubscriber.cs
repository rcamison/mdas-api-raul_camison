using System;
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

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _eventBus.Consume<PokemonFavoriteCreatedEvent>("UserExchange", "UserPokemonFavorites", "Pokemon added to user Favorites",
                @event =>
                {
                    Task.Run(() => { TreatEvent(@event); }, stoppingToken);
                }
                );

        }

        private void TreatEvent(PokemonFavoriteCreatedEvent @event)
        {
            _pokemonNotifierUseCase.Execute(int.Parse(@event.EventAggregateId));
        }
    }
}
