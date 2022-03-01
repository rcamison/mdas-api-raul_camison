
using System.Text;
using System.Text.Json;
using System.Threading.Channels;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
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

        public Task Consume<T>(string exchangeName, string queueName, string eventKey, Action<T> onEventReceived) where T : Event
        {
            _channel.ExchangeDeclare(exchangeName, ExchangeType.Direct);
            _channel.QueueDeclare(queueName, true, false, false, null);
            _channel.QueueBind(queueName, exchangeName, eventKey, null);

            var consumer = new AsyncEventingBasicConsumer(_channel);

            consumer.Received += async (model, ea) =>
            {
                var body = Encoding.UTF8.GetString(ea.Body.Span);
                var message = JsonSerializer.Deserialize<T>(body);

                onEventReceived(message);

                await Task.Yield();

            };

            _channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);

            return Task.CompletedTask;

        }

        public Task Publish(string exchangeName, string queueName, Event @event)
        {
            return PublishEvent(exchangeName, queueName, @event);
        }

        #region Metodos privados

        private async Task PublishEvent<T>(string exchangeName, string queueName, T @event) where T : Event
        {
            await Task.Run(() =>
            {
                _channel.ExchangeDeclare(exchangeName, ExchangeType.Direct);
                _channel.QueueDeclare(queueName, true, false, false, null);
                _channel.QueueBind(queueName, exchangeName, @event.EventMessage, null);
                IBasicProperties properties = _channel.CreateBasicProperties();
                properties.Type = @event.EventMessage;
                byte[] output = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(@event));
                _channel.BasicPublish(exchangeName, @event.EventMessage, properties, output);
            });
        }

        #endregion
    }
}
