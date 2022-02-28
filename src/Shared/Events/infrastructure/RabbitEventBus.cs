
using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using Shared.Events.Domain;

namespace Shared.Events.Infrastructure
{
    public class RabbitEventBus : IEventBus
    {
        private IModel _channel;

        public RabbitEventBus(IModel channel)
        {
            _channel = channel;
        }

        public async Task Publish(string exchangeName, string queueName, Event @event)
        {
            await PublishEvent(exchangeName, queueName, @event);
        }

        private async Task PublishEvent<T>(string exchangeName, string queueName, T @event) where T : Event
        {
            await Task.Run(() =>
            {
                _channel.ExchangeDeclare(exchangeName, ExchangeType.Direct);
                _channel.QueueDeclare(queueName, true, false, false, null);
                _channel.QueueBind(queueName, exchangeName, @event.EventMessage.Value, null);
                IBasicProperties properties = _channel.CreateBasicProperties();
                properties.Type = @event.EventMessage.Value;
                byte[] output = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(@event));
                _channel.BasicPublish(exchangeName, @event.EventMessage.Value, properties, output);
            });
        }
    }
}
