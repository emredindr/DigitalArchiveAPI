using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalArchive.Core.MailSender
{
    public interface IMailSender
    {
        void SendEmail(EmailTemp request);
    }
}
