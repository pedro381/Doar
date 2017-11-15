using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

namespace Doar.Seguranca.Configuration
{
    public class EmailService
    {
        private static string nomeRemetente = "Nome";
        private static string emailRemetente = "@gmail.com";
        private static string senha = "";
        private static string SMTP = "smtp.gmail.com";

        private static MailMessage ObterConfiguracaoEmail()
        {
            MailMessage objEmail = new MailMessage();
            objEmail.From = new MailAddress(nomeRemetente + "<" + emailRemetente + ">");
            objEmail.Priority = MailPriority.Normal;
            objEmail.IsBodyHtml = true;
            objEmail.SubjectEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
            objEmail.BodyEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");

            return objEmail;
        }

        private static void EnviarMensagem(MailMessage myMail)
        {
            SmtpClient objSmtp = new SmtpClient();
            objSmtp.Credentials = new NetworkCredential(emailRemetente, senha);
            objSmtp.Host = SMTP;
            objSmtp.Port = 587;
            objSmtp.EnableSsl = true;
            objSmtp.Send(myMail);
        }

        public static void EnviarEmail(string assunto, string mensagem, string destinatarios)
        {
            EnviarEmail(assunto, mensagem, new List<string> { destinatarios }, null, null, null);
        }

        public static void EnviarEmail(string assunto, string mensagem, List<string> destinatarios, List<string> anexos)
        {
            EnviarEmail(assunto, mensagem, destinatarios, null, null, anexos);
        }

        public static void EnviarEmail(string assunto, string mensagem, List<string> destinatarios, List<string> destinatariosCC, List<string> destinatariosCCO, List<string> anexos)
        {
            var myMail = ObterConfiguracaoEmail();
            destinatarios?.ForEach(x => { myMail.To.Add(x); });
            destinatariosCC?.ForEach(x => { myMail.CC.Add(x); });
            destinatariosCCO?.ForEach(x => { myMail.Bcc.Add(x); });
            anexos?.ForEach(x => { myMail.Attachments.Add(new Attachment(x)); });
            myMail.Subject = assunto;
            myMail.Body = mensagem;
            EnviarMensagem(myMail);
        }
    }
}
