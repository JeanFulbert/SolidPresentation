namespace SolidPresentation.LSP.Bad.Payment
{
    using SolidPresentation.LSP.WebServices;

    public class PayPalPayment : PaymentBase
    {
        public string AccountName { get; set; }
        public string Password { get; set; }

        public override string Refund(decimal amount, string transactionId)
        {
            var payPalWebService = new PayPalWebService();
            var token = payPalWebService.GetTransactionToken(AccountName, Password);
            var response = payPalWebService.MakeRefund(amount, transactionId, token);
            return response;
        }
    }
}
