using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace creativo_API.Services
{
    using System;
    using System.Net;
    using System.Net.Mail;

    public class MailService
    {
        internal static void SendEmail(string toEmail, string subject, string body, string attachmentPath)
        {
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("clubcreativo95@gmail.com", "rhslulyagacuxvbe"),
                EnableSsl = true,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress("clubcreativo95@gmail.com"),
                Subject = subject,
                Body = body,
                IsBodyHtml = true,
            };

            mailMessage.To.Add(toEmail);

            // Adjuntar archivo
            if (!string.IsNullOrEmpty(attachmentPath))
            {
                Attachment attachment = new Attachment(attachmentPath);
                mailMessage.Attachments.Add(attachment);
            }

            try
            {
                smtpClient.Send(mailMessage);
                Console.WriteLine("Correo enviado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al enviar el correo: {ex.Message}");
            }
        }
    }
}