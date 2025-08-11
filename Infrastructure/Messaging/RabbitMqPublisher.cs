using Infrastructure.Configuration;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

public class RabbitMqPublisher : IAsyncDisposable
{
    private readonly RabbitMqConfiguration _config;
    private readonly IConnection _connection;
    private readonly IChannel _channel;

    public RabbitMqPublisher(RabbitMqConfiguration config)
    {
        _config = config;

        var factory = new ConnectionFactory
        {
            HostName = _config.HostName,
            Port = _config.Port,
            UserName = _config.UserName,
            Password = _config.Password
        };

        _connection = factory.CreateConnectionAsync().GetAwaiter().GetResult();
        _channel = _connection.CreateChannelAsync().GetAwaiter().GetResult();

        // Declare the queue once when the publisher is created
        _channel.QueueDeclareAsync(
            queue: _config.QueueName,
            durable: true,
            exclusive: false,
            autoDelete: false
        ).GetAwaiter().GetResult();
    }

    public async Task PublishAsync(object message)
    {
        var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));

        var props = new BasicProperties { DeliveryMode = DeliveryModes.Persistent };

        await _channel.BasicPublishAsync(
            exchange: "",
            routingKey: _config.QueueName,
            mandatory: false,
            basicProperties: props,
            body: body
        );
    }

    public async ValueTask DisposeAsync()
    {
        if (_channel != null) await _channel.DisposeAsync();
        if (_connection != null) await _connection.DisposeAsync();
    }
}
