namespace SolidPresentation.LSP.WebServices
{
    public class PayPalWebService
    {
        public string GetTransactionToken(string username, string password)
        {
            return "Hello from PayPal";
        }

        public string MakeRefund(decimal amount, string transactionId, string token)
        {
            return "Auth";
        }
    }
}
