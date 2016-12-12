namespace SolidPresentation.DIP.Common
{
    using System;

    public class PaymentGateway : IDisposable
    {
        public void Dispose()
        {
        }

        public string Credentials { get; set; }
        public string CardNumber { get; set; }
        public int ExpiresMonth { get; set; }
        public int ExpiresYear { get; set; }
        public string NameOnCard { get; set; }
        public decimal AmountToCharge { get; set; }

        public void Charge()
        {
        }
    }
}