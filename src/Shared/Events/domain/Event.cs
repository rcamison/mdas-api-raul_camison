
namespace Shared.Events.Domain
{
    public class Event
    {
        private readonly String _eventMessage;
        private readonly String _eventAggregateId;

        public Event(String eventMessage, String eventAggregateId)
        {
            _eventMessage = eventMessage;
            _eventAggregateId = eventAggregateId;
        }

        public String EventMessage { get { return _eventMessage; } }
        public String EventAggregateId { get { return _eventAggregateId; } }
    }
}
