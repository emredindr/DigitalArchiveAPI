

using Microsoft.Extensions.Configuration;

namespace DigitalArchive.Core.Utilities.Security.JWT.Configuration
{
    public class JwtConfiguration : IJwtConfiguration
    {
        private readonly IConfiguration _configuration;
        public JwtConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Audience => _configuration.GetSection("TokenOptions:Audience").Value;

        public string Issuer => _configuration.GetSection("TokenOptions:Issuer").Value;

       

        public string SecurityKey => _configuration.GetSection("TokenOptions:SecurityKey").Value;

        public int AccessTokenExpiration
        {
            get
            {
                var asd = _configuration.GetSection("TokenOptions:AccessTokenExpiration").Value;
                return Convert.ToInt32(asd);
            }
        }
    }
}
