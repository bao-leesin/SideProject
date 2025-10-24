using Domain.Messaging;
using Domain.Storage;
using Infrastructure.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace Infrastructure.Messaging
{
    public class RabbitMqConsumerService : BackgroundService
    {
        private readonly ILogger<RabbitMqConsumerService> _logger;
        private readonly IStorageService _storage;
        private readonly ConnectionFactory _factory;
        private IConnection? _connection;
        private IChannel? _channel;
        private readonly RabbitMqConfiguration _config;
        public RabbitMqConsumerService(ILogger<RabbitMqConsumerService> logger,
                                        RabbitMqConfiguration config,
                                        IStorageService storage)
        {
            _logger = logger;
            _config = config;
            _storage = storage;

            _factory = new ConnectionFactory
            {
                HostName = _config.HostName,
                Port = _config.Port,
                UserName = _config.UserName,
                Password = _config.Password
            };
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _connection = await _factory.CreateConnectionAsync();
            _channel = await _connection.CreateChannelAsync();

            await _channel.QueueDeclareAsync(
                queue: _config.QueueName,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var consumer = new AsyncEventingBasicConsumer(_channel);
            consumer.ReceivedAsync += async (sender, ea) =>
            {
                try
                {
                    var json = Encoding.UTF8.GetString(ea.Body.ToArray());
                    var msg = JsonSerializer.Deserialize<MediaMessage>(json);

                    if (msg is null)
                        throw new Exception("Invalid message format");

                    _logger.LogInformation("Processing file: {File}", msg.ObjectName);

                    using (var stream = File.OpenRead(msg.TempPath))
                    {
                        await _storage.UploadAsync(stream, msg.ObjectName, msg.ContentType, msg.Size);
                    }

                    if (File.Exists(msg.TempPath))
                        File.Delete(msg.TempPath);
                    await _channel.BasicAckAsync(ea.DeliveryTag, false);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error processing message");
                    await _channel.BasicNackAsync(ea.DeliveryTag, false, true); // requeue
                }
            };

            await _channel.BasicConsumeAsync(
                queue: _config.QueueName,
                autoAck: false,
                consumer: consumer);
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            if (_channel != null) await _channel.DisposeAsync();
            if (_connection != null) await _connection.DisposeAsync();
            await base.StopAsync(cancellationToken);
        }
    }
}
