using Domain.Messaging;
using Microsoft.AspNetCore.Http;
using Service.Interfaces;

public class MediaService : IMediaService
{
    private readonly RabbitMqPublisher _publisher;

    public MediaService(RabbitMqPublisher publisher)
    {
        _publisher = publisher;
    }

    public async Task<object> UploadFileAsync(IFormFile file)
    {
        try
        {
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var objectName = $"uploads/{fileName}";

            var tempPath = Path.Combine(Path.GetTempPath(), fileName);
            using (var fs = new FileStream(tempPath, FileMode.Create, FileAccess.Write))
            {
                await file.CopyToAsync(fs);
            }

            var message = new MediaMessage(
                TempPath: tempPath,
                ObjectName: objectName,
                ContentType: file.ContentType ?? "application/octet-stream",
                Size: file.Length
            );

            await _publisher.PublishAsync(message);

            return new
            {
                success = true,
                fileName,
                originalName = file.FileName,
                path = objectName,
                status = "Queued"
            };
        }
        catch (Exception ex)
        {
            throw new Exception($"Upload request failed: {ex.Message}");
        }
    }
}
