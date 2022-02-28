namespace Shared.Events.Domain
{
    public class EventMessage
    {
        public string Value { get; }

        public EventMessage(string message)
        {
            Value = message;
        }
    }
}
