namespace SolidPresentation.LSP.Good.Payment
{
    using SolidPresentation.LSP.WebServices;

    public class WorldPayPayment : PaymentBase
    {
        private readonly string accountName;
        private readonly string password;
        private readonly string productId;

        public WorldPayPayment(string accountId, string password, string productId)
        {
            this.accountName = accountId;
            this.password = password;
            this.productId = productId;
        }

        public override bool Refund(decimal amount, string transactionId)
        {
            var worldPayWebService = new WorldPayWebService();
            var response = worldPayWebService.MakeRefund(amount, transactionId, this.accountName, this.password, this.productId);

            var succeeded = response.Contains("Success");
            return succeeded;
        }
    }
}
