using MediatR;
using Shared.Events.Domain;

namespace Users.User.Domain
{
    public class PokemonFavoriteCreatedEvent : Event, INotification
    {
        public PokemonFavoriteCreatedEvent(String eventAggregateId) : base("Pokemon added to user Favorites", eventAggregateId)
        {
        }
    }
}
