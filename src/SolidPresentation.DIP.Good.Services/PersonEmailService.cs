namespace SolidPresentation.DIP.Good.Services
{
    using System;
    using SolidPresentation.DIP.Good.Domain.Models;

    public class PersonEmailService
    {
        private readonly IEmailSender emailSender;

        public PersonEmailService(IEmailSender emailSender)
        {
            if (emailSender == null)
            {
                throw new ArgumentNullException(nameof(emailSender));
            }

            this.emailSender = emailSender;
        }

        public void SendAccountCreated(Email email)
        {
            this.emailSender.Send(
                email,
                "Account created",
                "Hello,\n\n" +
                "your account has been created.\n\n" +
                "Sincerely");
        }

        public void SendAccountDeleted(Email email)
        {
            this.emailSender.Send(
                email,
                "Account created",
                "Hello,\n\n" +
                "your account has been deleted.\n\n" +
                "Sincerely");
        }
    }
}
