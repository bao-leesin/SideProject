using RabbitMQ.Client;
using Application.Messaging;

namespace Infrastructure.Messaging
{
    public class RabbitMqPublisher : IMQPublisher, IAsyncDisposable
    {
        private readonly ConnectionFactory _factory;
        private IConnection? _connection;
        private IChannel? _channel;

        public RabbitMqPublisher(string hostName, string userName, string password)
        {
            _factory = new ConnectionFactory()
            {
                HostName = hostName,
                UserName = userName,
                Password = password
            };
        }

        private async Task EnsureConnectionAsync()
        {
            if (_connection == null)
            {
                _connection = await _factory.CreateConnectionAsync();
                _channel = await _connection.CreateChannelAsync();
            }
        }

        public async Task PublishAsync(string queueName, byte[] message)
        {
            await EnsureConnectionAsync();

            await _channel!.QueueDeclareAsync(
                queue: queueName,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            await _channel.BasicPublishAsync(
                exchange: "",
                routingKey: queueName,
                mandatory: false,
                body: message);
        }

        public async ValueTask DisposeAsync()
        {
            if (_channel != null) await _channel.DisposeAsync();
            if (_connection != null) await _connection.DisposeAsync();
        }
    }
}
