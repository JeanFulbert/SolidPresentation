namespace SolidPresentation.LSP.Good.Payment
{
    using SolidPresentation.LSP.WebServices;

    public class PayPalPayment : PaymentBase
    {
        private readonly string accountName;
        private readonly string password;

        public PayPalPayment(string accountName, string password)
        {
            this.accountName = accountName;
            this.password = password;
        }

        public override bool Refund(decimal amount, string transactionId)
        {
            var payPalWebService = new PayPalWebService();
            var token = payPalWebService.GetTransactionToken(this.accountName, this.password);
            var response = payPalWebService.MakeRefund(amount, transactionId, token);

            var succeeded = response.Contains("Auth");
            return succeeded;
        }
    }
}
