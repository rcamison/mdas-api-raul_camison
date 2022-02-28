using MediatR;
using Shared.Events.Domain;

namespace Users.User.Domain
{
    public class PokemonFavoriteCreatedEvent : Event, INotification
    {
        public PokemonFavoriteCreatedEvent(EventAggregateId eventAggregateId) : base(new EventMessage("Pokemon added to user Favorites"), eventAggregateId)
        {
        }
    }
}
