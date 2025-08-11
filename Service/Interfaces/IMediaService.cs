using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IMediaService
    {
      Task UploadImageAsync(string filePath, string fileName, string contentType, string folderPath);
        Task UploadVideoAsync();
        Task DeleteFileAsync(string fileUrl);

    }
}
