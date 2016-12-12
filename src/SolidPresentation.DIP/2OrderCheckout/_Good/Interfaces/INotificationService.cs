namespace SolidPresentation.DIP._Good.Interfaces
{
    using SolidPresentation.DIP.Model;

    public interface INotificationService
    {
        void NotifyCustomerOrderCreated(Cart cart);
    }
}