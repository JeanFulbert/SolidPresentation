namespace SolidPresentation.LSP.Bad
{
    using SolidPresentation.LSP.Bad.Payment;

    public class RefundService
    {
        public bool Refund(PaymentServiceType paymentServiceType, decimal amount, string transactionId)
        {
            var refundSuccess = false;
            var payment = PaymentFactory.GetPaymentService(paymentServiceType);
            if (payment is PayPalPayment)
            {
                ((PayPalPayment)payment).AccountName = "Andras";
                ((PayPalPayment)payment).Password = "Passw0rd";
            }
            else if (payment is WorldPayPayment)
            {
                ((WorldPayPayment)payment).AccountName = "Andras";
                ((WorldPayPayment)payment).Password = "Passw0rd";
                ((WorldPayPayment)payment).ProductId = "ABC";
            }

            string serviceResponse = payment.Refund(amount, transactionId);

            if (serviceResponse.Contains("Auth") || serviceResponse.Contains("Success"))
            {
                refundSuccess = true;
            }

            return refundSuccess;
        }
    }
}
