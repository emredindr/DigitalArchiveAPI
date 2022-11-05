using DigitalArchive.Core.MailSender.Configuration;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;

namespace DigitalArchive.Core.MailSender
{
    public class MailSender : IMailSender
    {
        private readonly IMailConfiguration _mailConfiguration;
        public MailSender(IMailConfiguration mailConfiguration)
        {
            _mailConfiguration = mailConfiguration;
        }

        //Geliştirilecek
        //Dosya opisiyonu koyulacak,
        //To, BCC, CC Eklemeleri çoğul bi şekilde yapılacak
        //From alanı değiştirilebilir olacak
        //Try catch yapılıp hata veya başarılı gönderimler kayıt altına alınacak
        public void SendEmail(EmailTemp request)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_mailConfiguration.UserName));
            email.To.Add(MailboxAddress.Parse(request.To));
            email.Subject = request.Subject;
            email.Body = new TextPart(TextFormat.Html) { Text = request.Body };
            //email.Attachments.

            var smtp = new SmtpClient();
            smtp.Connect(_mailConfiguration.Host, 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailConfiguration.UserName, _mailConfiguration.Password);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
