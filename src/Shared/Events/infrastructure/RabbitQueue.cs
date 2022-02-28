
using Shared.Events.Domain;

namespace Shared.Events.Infrastructure
{
    public class RabbitQueue : IQueue
    {
        public Task Publish<T>(T @event) where T : Event
        {
            throw new NotImplementedException();
        }
    }
}
