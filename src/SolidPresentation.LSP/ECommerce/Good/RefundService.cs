namespace SolidPresentation.LSP.Good
{
    using SolidPresentation.LSP.Good.Payment;

    public class RefundService
    {
        public bool Refund(PaymentServiceType paymentServiceType, decimal amount, string transactionId)
        {
            var payment = PaymentFactory.GetPaymentService(paymentServiceType);
            var refundSuccess = payment.Refund(amount, transactionId);
            return refundSuccess;
        }
    }
}
