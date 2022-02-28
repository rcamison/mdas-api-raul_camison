
namespace Shared.Events.Domain
{
    public class Event
    {
        private readonly EventMessage _eventMessage;
        private readonly EventAggregateId _eventAggregateId;

        public Event(EventMessage eventMessage, EventAggregateId eventAggregateId)
        {
            _eventMessage = eventMessage;
            _eventAggregateId = eventAggregateId;
        }

        public EventMessage EventMessage { get { return _eventMessage; } }
        public EventAggregateId EventAggregateId { get { return _eventAggregateId; } }
    }
}
