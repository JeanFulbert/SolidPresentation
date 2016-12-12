namespace SolidPresentation.LSP.Bad.Payment
{
    using SolidPresentation.LSP.WebServices;

    public class WorldPayPayment : PaymentBase
    {
        public string AccountName { get; set; }
        public string Password { get; set; }
        public string ProductId { get; set; }

        public override string Refund(decimal amount, string transactionId)
        {
            var worldPayWebService = new WorldPayWebService();
            var response = worldPayWebService.MakeRefund(amount, transactionId, AccountName, Password, ProductId);
            return response;
        }
    }
}