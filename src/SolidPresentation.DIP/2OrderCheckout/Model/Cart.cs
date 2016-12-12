namespace SolidPresentation.DIP.Model
{
    using System.Collections.Generic;
    using SolidPresentation.DIP.Common;

    public class Cart
    {
        public string CustomerEmail { get; set; }

        public IReadOnlyCollection<OrderLine> Items { get; set; }

        public decimal TotalAmount { get; set; }
    }
}