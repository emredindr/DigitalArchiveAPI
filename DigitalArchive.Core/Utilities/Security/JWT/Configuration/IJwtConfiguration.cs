namespace DigitalArchive.Core.Utilities.Security.JWT.Configuration
{
    public interface IJwtConfiguration
    {
        public string Audience { get; }
        public string Issuer { get; }
        public int AccessTokenExpiration { get; }
        public string SecurityKey { get; }
    }
}
