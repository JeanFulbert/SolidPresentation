namespace SolidPresentation.LSP.Better
{
    using SolidPresentation.LSP.Better.Payment;

    public class RefundService
    {
        public bool Refund(PaymentServiceType paymentServiceType, decimal amount, string transactionId)
        {
            var refundSuccess = false;
            var payment = PaymentFactory.GetPaymentService(paymentServiceType);

            var serviceResponse = payment.Refund(amount, transactionId);

            if (serviceResponse.Contains("Auth") || serviceResponse.Contains("Success"))
            {
                refundSuccess = true;
            }

            return refundSuccess;
        }
    }
}
