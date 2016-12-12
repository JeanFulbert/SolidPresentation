namespace SolidPresentation.DIP.Bad.WpfUi.Utils
{
    using SolidPresentation.DIP.Bad.Business.Models;

    public class PersonEmailService
    {
        private readonly EmailSender emailSender;

        public PersonEmailService()
        {
            this.emailSender = new EmailSender();
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
