using Microsoft.Extensions.Configuration;

namespace DigitalArchive.Core.MailSender.Configuration
{
    public class MailConfiguration : IMailConfiguration
    {
        private readonly IConfiguration _configuration;
        public MailConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Host => _configuration.GetSection("MailConfig:Host").Value;
        public string UserName => _configuration.GetSection("MailConfig:UserName").Value;
        public string Password => _configuration.GetSection("MailConfig:Password").Value;
    }
}
