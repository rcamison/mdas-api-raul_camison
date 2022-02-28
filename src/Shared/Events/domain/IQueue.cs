
namespace Shared.Events.Domain
{
    public interface IQueue
    {
        Task Publish<T>(T @event) where T : Event;

    }
}
