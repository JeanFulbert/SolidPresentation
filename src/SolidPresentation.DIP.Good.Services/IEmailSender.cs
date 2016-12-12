namespace SolidPresentation.DIP.Good.Services
{
    using SolidPresentation.DIP.Good.Domain.Models;

    public interface IEmailSender
    {
        void Send(Email email, string subject, string message);
    }
}
