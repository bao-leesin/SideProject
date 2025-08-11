namespace Application.Messaging
{
    public interface IMQPublisher
    {
        Task PublishAsync(string queueName, byte[] message);
    }
}
