using Doar.Entity.Entities;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;

namespace Doar.Ui.Mvc.Controllers {
    public class ContatoController : Controller {
        public ActionResult Index() {
            return View();
        }

        public void SendMail(Email email) {
            var mail = new MailMessage();
            var smtp = new SmtpClient();
            mail.From = new MailAddress("doar@pjsoftware.com.br");
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("doar@pjsoftware.com.br", "luiz381");
            smtp.Host = "smtpi.kinghost.net";

            mail.To.Add(email.Destinatario);
            mail.IsBodyHtml = true;
            mail.Body = email.Nome + "<br>" +
                        email.Telefone + "<br>" +
                        email.Corpo;
            mail.Subject = email.Assunto;
            smtp.Send(mail);
        }
    }
}