namespace SolidPresentation.DIP._Good.Services
{
    using SolidPresentation.DIP.Model;
    using SolidPresentation.DIP._Good.Interfaces;

    public class DoNotNotifyService : INotificationService
    {
        public void NotifyCustomerOrderCreated(Cart cart)
        {
        }
    }
}
