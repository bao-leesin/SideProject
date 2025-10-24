namespace Infrastructure.Configuration
    {
    public class MinIOConfiguration
    {
        public string Endpoint { get; set; }
        public string AccessKey { get; set; }
        public string SecretKey { get; set; }
        public string BucketName { get; set; }
        public string Region { get; set; } = "us-east-1"; // Default region, can be overridden
        public bool WithSSL { get; set; } = true; // Default to using SSL
    }
}
