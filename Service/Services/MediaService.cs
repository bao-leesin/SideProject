using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    internal class MediaService : IMediaService
    {
        public Task UploadImageAsync(string filePath, string fileName, string contentType, string folderPath)
        {
            throw new NotImplementedException();
        }
        public Task UploadVideoAsync()
        {
            throw new NotImplementedException();
        }
        public Task DeleteFileAsync(string fileUrl)
        {
            throw new NotImplementedException();
        }
    }
}
