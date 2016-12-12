namespace SolidPresentation.DIP.Good.Utils
{
    using System.Net;
    using System.Net.Mail;
    using SolidPresentation.DIP.Good.Domain.Models;
    using SolidPresentation.DIP.Good.Services;

    public class EmailSender : IEmailSender
    {
        public void Send(Email email, string subject, string message)
        {
            var client = BuildSmtpClient();

            var mail = new MailMessage("solid.di.mtd@gmail.com", email)
            {
                Subject = subject,
                Body = message
            };

            client.Send(mail);
        }

        private static SmtpClient BuildSmtpClient()
        {
            var client = new SmtpClient
            {
                Host = "smtp.googlemail.com",
                Port = 587,
                UseDefaultCredentials = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                EnableSsl = true,
                Credentials = new NetworkCredential("solid.di.mtd@gmail.com", "DummyPassword")
            };
            return client;
        }
    }
}
