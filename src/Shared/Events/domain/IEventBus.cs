
namespace Shared.Events.Domain
{
    public interface IEventBus
    {
        Task Publish(string exchangeName, string queueName, Event @event);

    }
}

