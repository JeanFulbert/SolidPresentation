namespace SolidPresentation.DIP.Model
{
    public class PaymentDetails
    {
        public string CardNumber { get; set; }
        public int ExpiresMonth { get; set; }
        public int ExpiresYear { get; set; }
        public string CardholderName { get; set; }
    }
}