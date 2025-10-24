using Microsoft.AspNetCore.Http;

namespace Service.Interfaces
{
    public interface IMediaService
    {
        Task<object> UploadFileAsync(IFormFile file);
    }
}