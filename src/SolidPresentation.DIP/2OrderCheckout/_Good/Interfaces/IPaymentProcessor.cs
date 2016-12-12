namespace SolidPresentation.DIP._Good.Interfaces
{
    using SolidPresentation.DIP.Model;

    public interface IPaymentProcessor
    {
        void ProcessCreditCard(PaymentDetails paymentDetails, decimal amount);
    }
}
