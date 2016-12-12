namespace SolidPresentation.LSP.Bad.Payment
{
    public abstract class PaymentBase
    {
        public abstract string Refund(decimal amount, string transactionId);
    }
}
