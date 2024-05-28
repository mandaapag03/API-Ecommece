using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using EmailAPI.Model;
using VerifyNullablesObjects;

namespace EmailAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class EmailController : ControllerBase
  {
    [HttpPost("SendEmail")]
    public ActionResult SendEmail(Email emailData)
    {
      var fromEmail = Environment.GetEnvironmentVariable("ADM__EMAIL");
      var password = Environment.GetEnvironmentVariable("EMAIL__PASSWORD");

      NullOrEmptyVariable<string>.ThrowIfNull(fromEmail, "Admin Email not found, verify your .env file definine it.");
      NullOrEmptyVariable<string>.ThrowIfNull(password, "Password of admin email not found, verify your .env file definine it.");

      var message = new MailMessage()
      {
        From = new MailAddress(fromEmail),
        Subject = emailData.Subject,
        IsBodyHtml = true,
        Body = $"""
                <html>
                    <body>{emailData.Body}</body>
                </html>
                """
      };
      foreach (var toEmail in emailData.ToEmails.Split(";"))
      {
        message.To.Add(new MailAddress(toEmail));
      }

      var smtp = new SmtpClient("smtp.medicinadamulher.com.br")
      {
        Port = 587,
        Credentials = new NetworkCredential(fromEmail, password),
        EnableSsl = true,
      };

      Utils.DisableCertificateValidation();
      smtp.Send(message);

      return Ok("Email Sent!");
    }
  }
}
