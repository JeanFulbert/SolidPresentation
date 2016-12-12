namespace SolidPresentation.DIP._Bad
{
    using System;
    using System.Net.Mail;
    using SolidPresentation.DIP.Common;
    using SolidPresentation.DIP.Exceptions;
    using SolidPresentation.DIP.Model;

    public class Order
    {
        public void Checkout(Cart cart, PaymentDetails paymentDetails, bool notifyCustomer)
        {
            this.ChargeCard(paymentDetails, cart);

            this.ReserveInventory(cart);

            if (notifyCustomer)
            {
                this.NotifyCustomer(cart);
            }
        }

        private void ChargeCard(PaymentDetails paymentDetails, Cart cart)
        {
            using (var paymentGateway = new PaymentGateway())
            {
                try
                {
                    paymentGateway.Credentials = "account credentials";
                    paymentGateway.CardNumber = paymentDetails.CardNumber;
                    paymentGateway.ExpiresMonth = paymentDetails.ExpiresMonth;
                    paymentGateway.ExpiresYear = paymentDetails.ExpiresYear;
                    paymentGateway.NameOnCard = paymentDetails.CardholderName;
                    paymentGateway.AmountToCharge = cart.TotalAmount;

                    paymentGateway.Charge();
                }
                catch (AvsMismatchException ex)
                {
                    throw new OrderException("The card gateway rejected the card based on the address provided.", ex);
                }
                catch (Exception ex)
                {
                    throw new OrderException("Problem charging payment gateway", ex);
                }
            }
        }

        private void ReserveInventory(Cart cart)
        {
            foreach (var item in cart.Items)
            {
                try
                {
                    var inventorySystem = new InventorySystem();
                    inventorySystem.Reserve(item.Sku, item.Quantity);
                }
                catch (InsufficientInventoryException ex)
                {
                    throw new OrderException("Insufficient inventory for item " + item.Sku, ex);
                }
                catch (Exception ex)
                {
                    throw new OrderException("Problem reserving inventory", ex);
                }
            }
        }

        private void NotifyCustomer(Cart cart)
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