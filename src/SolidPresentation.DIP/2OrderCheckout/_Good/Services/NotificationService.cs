namespace SolidPresentation.DIP._Good.Services
{
    using System;
    using System.Net.Mail;
    using SolidPresentation.DIP.Common;
    using SolidPresentation.DIP.Model;
    using SolidPresentation.DIP._Good.Interfaces;

    public class NotificationService : INotificationService
    {
        public void NotifyCustomerOrderCreated(Cart cart)
        {
            var customerEmail = cart.CustomerEmail;
            if (string.IsNullOrEmpty(customerEmail))
            {
                return;
            }

            using (var message = new MailMessage("orders@somewhere.com", customerEmail))
            using (var client = new SmtpClient("localhost"))
            {
                message.Subject = "Your order placed on " + DateTime.Now;
                message.Body = "Your order details: \n" + cart;

                try
                {
                    client.Send(message);
                }
                catch (Exception ex)
                {
                    Logger.Error("Problem sending notification email", ex);
                    throw;
                }
            }
        }
    }
}