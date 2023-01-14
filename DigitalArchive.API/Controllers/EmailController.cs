using DigitalArchive.Core.MailSender;
using Microsoft.AspNetCore.Mvc;

namespace DigitalArchive.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EmailController : BaseController
    {
        private readonly IMailSender _mailSender;

        public EmailController(IMailSender mailSender)
        {
            _mailSender = mailSender;
        }

        [HttpPost("SendEmail")]
        public IActionResult SendEmail(EmailTemp request)
        {
            _mailSender.SendEmail(request);
            return Ok();
        }
    }
}
