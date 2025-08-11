using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Threading.Channels;

namespace Infrastructure.Messaging
{
    public class RabbitMqConsumerService : BackgroundService
    {
        private readonly ILogger<RabbitMqConsumerService> _logger;
        private readonly ConnectionFactory _factory;
        private IConnection? _connection;
        private IChannel? _channel;
        private const string QueueName = "media-processing";

        public RabbitMqConsumerService(ILogger<RabbitMqConsumerService> logger)
        {
            _logger = logger;
            _factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _connection = await _factory.CreateConnectionAsync();
            _channel = await _connection.CreateChannelAsync();

            await _channel.QueueDeclareAsync(
                queue: QueueName,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var consumer = new AsyncEventingBasicConsumer(_channel);
            consumer.ReceivedAsync += async (sender, ea) =>
            {
                var body = ea.Body.ToArray();
                var json = Encoding.UTF8.GetString(body);

                _logger.LogInformation("Processing: {json}", json);

                // Example: Deserialize and call MinIO upload logic here
                // var media = JsonSerializer.Deserialize<MediaMessage>(json);
                // await _minioService.UploadAsync(media.Path, media.Type);

                // ACK message after successful processing
                await _channel.BasicAckAsync(ea.DeliveryTag, multiple: false);
            };


            await _channel.BasicConsumeAsync(queue: QueueName, autoAck: true, consumer: consumer);
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            if (_channel != null) await _channel.DisposeAsync();
            if (_connection != null) await _connection.DisposeAsync();
            await base.StopAsync(cancellationToken);
        }
    }
}
