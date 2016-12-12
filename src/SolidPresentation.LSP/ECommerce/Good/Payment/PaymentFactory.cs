namespace SolidPresentation.LSP.Good.Payment
{
    using System;

    public class PaymentFactory
    {
        public static PaymentBase GetPaymentService(PaymentServiceType serviceType)
        {
            switch (serviceType)
            {
                case PaymentServiceType.PayPal:
                    return new PayPalPayment("Andras", "Passw0rd");
                case PaymentServiceType.WorldPay:
                    return new WorldPayPayment("Andras", "Passw0rd", "ABC");
                default:
                    throw new NotImplementedException("No such service.");
            }
        }
    }
}
