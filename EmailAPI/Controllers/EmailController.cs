using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;

namespace EmailAPI.Controllers
{

    public class EmailModel
    {
        public string FromEmail { get; set; } = "amandapagani@bol.com.br";
        public string ToEmails { get; set; } = "paganiamanda791@gmail.com";
        public string Subject { get; set; } = "Teste";
        public string Body { get; set; } = "Teste";
    }

    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        [HttpPost("SendEmail")]
        public ActionResult SendEmail(EmailModel emailData)
        {
            var message = new MailMessage()
            {
                From = new MailAddress(emailData.FromEmail),
                Subject = emailData.Subject,
                IsBodyHtml = true,
                Body = $"""
                <html>
                    <body>
                        <h3>{emailData.Body}</h3>
                    </body>
                </html>
                """
            };
            foreach (var toEmail in emailData.ToEmails.Split(";"))
            {
                message.To.Add(new MailAddress(toEmail));
            }

            var smtp = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(emailData.FromEmail, "mg7112003"),
                EnableSsl = true,
            };

            smtp.Send(message);

            return Ok("Email Sent!");
        }
    }
    // [Route("api/[controller]")]
    // [ApiController]
    // public class EmailController : ControllerBase
    // {
    //     [HttpPost]
    //     public IActionResult EnviarEmail([FromBody] Email email)
    //     {
    //         string remetente = "contato.amandapagani791@gmail.com"; // Insira aqui o e-mail do remetente
    //         string senha = "MainSennaRell2022@@"; // Insira aqui a senha do e-mail do remetente

    //         using (var message = new MailMessage(remetente, email.Destinatario))
    //         {
    //             message.Subject = email.Assunto;
    //             message.Body = email.Corpo;
    //             message.IsBodyHtml = true;

    //             using (var client = new SmtpClient("smtp.gmail.com")) // Configure o SMTP conforme o provedor do e-mail
    //             {
    //                 client.Port = 587;
    //                 client.Credentials = new NetworkCredential(remetente, senha, "smtp.gmail.com");
    //                 client.EnableSsl = true;
    //                 client.UseDefaultCredentials = false;

    //                 client.Send(message);
    //             }

    //             return Ok("E-mail enviado com sucesso!");
    //         }
    //     }
    // }
}
