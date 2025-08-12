using Minio;
using Serilog.Sinks.Elasticsearch;
using Serilog;
using Infrastructure.Configuration;

namespace WebAPI.DependencyInjection
{
    public static class DIConfig
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            // ===== Existing Elasticsearch config =====
            var elasticConfiguration = new ElasticSearchConfiguration();
            configuration.GetSection(nameof(ElasticSearchConfiguration)).Bind(elasticConfiguration);
            if (elasticConfiguration.Uri != null)
            {
                services.AddSingleton(elasticConfiguration);

                Log.Logger = new LoggerConfiguration()
                    .Enrich.FromLogContext()
                    .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(elasticConfiguration.Uri))
                    {
                        AutoRegisterTemplate = true,
                        IndexFormat = "logstash-{0:yyyy.MM.dd}"
                    })
                    .CreateLogger();
            }

            // ===== MinIO config =====
            var minioSettings = new MinIOConfiguration();
            configuration.GetSection(nameof(MinIOConfiguration)).Bind(minioSettings);

            services.AddSingleton(minioSettings);

            services.AddSingleton<IMinioClient>(sp =>
            {
                return new MinioClient()
                    .WithEndpoint(minioSettings.Endpoint)
                    .WithCredentials(minioSettings.AccessKey, minioSettings.SecretKey)
                    .WithSSL(minioSettings.WithSSL)
                    .Build();
            });

            // ===== RabbitMq config =====
            var rabbitSettings = new RabbitMqConfiguration();
            configuration.GetSection(nameof(RabbitMqConfiguration)).Bind(rabbitSettings);
            services.AddSingleton(rabbitSettings);
        }

    }
}
