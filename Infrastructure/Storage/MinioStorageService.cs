using Domain.Storage;
using Infrastructure.Configuration;
using Minio.DataModel.Args;
using Minio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Storage
{
    public class MinioStorageService : IStorageService
    {
        private readonly MinioClient _minio;
        private readonly MinIOConfiguration _config;

        public MinioStorageService(MinioClient minio, MinIOConfiguration config)
        {
            _minio = minio;
            _config = config;
        }

        public async Task<string> UploadAsync(Stream stream, string objectName, string contentType, long size)
        {
            var bucketExists = await _minio.BucketExistsAsync(
                new BucketExistsArgs().WithBucket(_config.BucketName));

            if (!bucketExists)
            {
                await _minio.MakeBucketAsync(
                    new MakeBucketArgs().WithBucket(_config.BucketName));
            }

            await _minio.PutObjectAsync(
                new PutObjectArgs()
                    .WithBucket(_config.BucketName)
                    .WithObject(objectName)
                    .WithStreamData(stream)
                    .WithObjectSize(size)
                    .WithContentType(contentType ?? "application/octet-stream")
            );

            return objectName;
        }

        public Task<bool> ExistsAsync(string objectName)
        {
            // Implementation could check if object exists
            throw new NotImplementedException();
        }

        public async Task<string> GetFileUrlAsync(string objectName, int expirySeconds = 86400)
        {
            return await _minio.PresignedGetObjectAsync(
                new PresignedGetObjectArgs()
                    .WithBucket(_config.BucketName)
                    .WithObject(objectName)
                    .WithExpiry(expirySeconds));
        }
    }

}
