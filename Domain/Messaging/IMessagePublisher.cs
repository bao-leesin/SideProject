namespace Domain.Messaging
{
    public interface IMessagePublisher
    {
        Task PublishAsync(string queue, MediaMessage message);
    }
}
