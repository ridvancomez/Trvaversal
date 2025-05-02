using DataTransferObjectLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace Trvaversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(MailRequestDTO mailRequest)
        {
            MimeMessage mimeMessage = new();
            
            MailboxAddress mailboxAddressFrom = new("Admin", "ridvancomeztest@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new("User", mailRequest.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);

            mimeMessage.Subject = mailRequest.Subject;

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = mailRequest.Body;
            MimeEntity body = bodyBuilder.ToMessageBody();

            mimeMessage.Body = body;

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("ridvancomeztest@gmail.com", "eqdbcgkyqxonkeaq");//eqdb cgky qxon keaq
            client.Send(mimeMessage);
            client.Disconnect(true);
            return View();
        }
    }
}
