namespace SolidPresentation.DIP.Bad.WpfUi.Utils
{
    using System.Net;
    using System.Net.Mail;
    using SolidPresentation.DIP.Bad.Business.Models;

    public class EmailSender
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
