namespace SolidPresentation.DIP._Good
{
    using System;
    using SolidPresentation.DIP.Model;
    using SolidPresentation.DIP._Good.Interfaces;

    public class Order
    {
        private readonly Cart cart;
        private readonly PaymentDetails paymentDetails;
        private readonly IPaymentProcessor paymentProcessor;
        private readonly INotificationService notificationService;
        private readonly IReservationService reservationService;

        public Order(
            Cart cart,
            PaymentDetails paymentDetails,
            IPaymentProcessor paymentProcessor,
            IReservationService reservationService,
            INotificationService notificationService)
        {
            if (cart == null)
            {
                throw new ArgumentNullException(nameof(cart));
            }

            if (paymentDetails == null)
            {
                throw new ArgumentNullException(nameof(paymentDetails));
            }

            if (paymentProcessor == null)
            {
                throw new ArgumentNullException(nameof(paymentProcessor));
            }

            if (notificationService == null)
            {
                throw new ArgumentNullException(nameof(notificationService));
            }

            if (reservationService == null)
            {
                throw new ArgumentNullException(nameof(reservationService));
            }

            this.cart = cart;
            this.paymentDetails = paymentDetails;
            this.paymentProcessor = paymentProcessor;
            this.notificationService = notificationService;
            this.reservationService = reservationService;
        }

        public void Checkout()
        {
            this.paymentProcessor.ProcessCreditCard(this.paymentDetails, this.cart.TotalAmount);

            this.reservationService.ReserveInventory(this.cart.Items);

            this.notificationService.NotifyCustomerOrderCreated(this.cart);
        }
    }
}
