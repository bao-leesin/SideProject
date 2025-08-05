using System;

namespace Service.DTOs
{
    public class PartnerDto : BaseDto
    {
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Response { get; set; }
        public PartnerAuthConfigDto? AuthConfig { get; set; }
        public PartnerApiConfigDto? ApiConfig { get; set; }
        public PartnerFieldMappingDto? FieldMappings { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastSyncDate { get; set; }
        public string? SyncStatus { get; set; }
    }
    public class PartnerAuthConfigDto : BaseDto
    {
        public string? AuthType { get; set; }
        public string? AuthApiLink { get; set; }
        public string? AuthMethod { get; set; }
        public string? AuthHeaders { get; set; }
        public string? AuthParams { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? ApiKey { get; set; }
        public string? ClientId { get; set; }
        public string? ClientSecret { get; set; }
        public string? TokenResponsePath { get; set; }
        public string? TokenExpiryPath { get; set; }
        public string? RefreshTokenPath { get; set; }
        public string? TokenPrefix { get; set; }
        public int? PartnerId { get; set; }
        public PartnerDto? Partner { get; set; }
    }
    public class PartnerApiConfigDto : BaseDto
    {
        public string? ApiLink { get; set; }
        public string? ApiMethod { get; set; }
        public string? ApiHeaders { get; set; }
        public string? ApiParams { get; set; }
        public bool? RequireAuth { get; set; }
        public string? AuthHeaderName { get; set; }
        public int? PartnerId { get; set; }
        public PartnerDto? Partner { get; set; }
    }
    public class PartnerFieldMappingDto : BaseDto
    {
        public int? ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public string? ProductPreview { get; set; }
        public string? ProductType { get; set; }
        public string? ProductDuration { get; set; }
        public string? ProductPrice { get; set; }
        public string? ProductPublishedDate { get; set; }
        public int? PartnerId { get; set; }
        public PartnerDto? Partner { get; set; }
    }
} 