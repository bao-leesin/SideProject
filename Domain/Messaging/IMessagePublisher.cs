namespace Domain.Messaging
{
    public interface IMessagePublisher
    {
        Task PublishAsync(MediaMessage message);
    }
}
