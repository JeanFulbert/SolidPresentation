namespace SolidPresentation.DIP.Good.Fakes
{
    using SolidPresentation.DIP.Good.Domain.Models;
    using SolidPresentation.DIP.Good.Services;

    public class FakeEmailSender : IEmailSender
    {
        public void Send(Email email, string subject, string merssage)
        {
        }
    }
}
