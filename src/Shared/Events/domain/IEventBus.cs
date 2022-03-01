
namespace Shared.Events.Domain
{
    public interface IEventBus
    {
        Task Publish(string exchangeName, string queueName, Event @event);

        Task Consume<T>(string exchangeName, string queueName, string eventKey, Action<T> onEventReceived) where T : Event;

    }
}

