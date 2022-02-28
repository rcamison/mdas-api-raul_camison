using RabbitMQ.Client;
using Shared.Events.Domain;

namespace Shared.Events.Infrastructure
{
    public class RabbitHutch
    {
        public static IEventBus CreateBus(string uri)
        {
            var _factory = new ConnectionFactory()
            {
                Uri = new Uri(uri),
                DispatchConsumersAsync = true
            };
            var _connection = _factory.CreateConnection();
            var _channel = _connection.CreateModel();
            return new RabbitEventBus(_channel);
        }

    }
}