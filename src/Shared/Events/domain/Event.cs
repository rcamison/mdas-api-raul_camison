
namespace Shared.Events.Domain
{
    public class Event
    {
        private readonly EventInnerText _eventInnerText;

        private Event(EventInnerText eventInnerText)
        {
            _eventInnerText = eventInnerText;
        }

        public static Event Create(EventInnerText eventInnerText)
        {
            return new Event(eventInnerText);
        }
    }
}
