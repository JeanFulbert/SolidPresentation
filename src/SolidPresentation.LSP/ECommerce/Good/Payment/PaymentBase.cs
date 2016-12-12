namespace SolidPresentation.LSP.Good.Payment
{
    public abstract class PaymentBase
    {
        public abstract bool Refund(decimal amount, string transactionId);
    }
}
