using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Storage
{
    public interface IStorageService
    {
        Task<string> UploadAsync(
            Stream stream,
            string objectName,
            string contentType,
            long size);

        Task<bool> ExistsAsync(string objectName);

        Task<string> GetFileUrlAsync(string objectName, int expirySeconds = 86400);
    }


}
