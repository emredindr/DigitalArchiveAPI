namespace DigitalArchive.Core.MailSender.Configuration
{
    public interface IMailConfiguration
    {
        public string Host { get; }
        public string UserName { get; }
        public string Password { get; }
    }
}
