namespace DigitalArchive.Core.MailSender;

public interface IMailSender
{
    void SendEmail(EmailTemp request);
}
