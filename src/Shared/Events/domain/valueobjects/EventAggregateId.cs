namespace Shared.Events.Domain
{
    public class EventAggregateId
    {
        public string Value { get; }

        public EventAggregateId(string aggregateId)
        {
            Value = aggregateId;
        }
    }
}
