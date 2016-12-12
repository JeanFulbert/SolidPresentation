namespace SolidPresentation.DIP.Good.PersistLiteDb.DbModel
{
    using SolidPresentation.DIP.Good.Domain.Models;

    public class DbAddress
    {
        public int StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }

        public static DbAddress FromAddress(Address address)
        {
            return
                new DbAddress
                {
                    StreetNumber = address.StreetNumber,
                    StreetName = address.StreetName,
                    PostalCode = address.PostalCode,
                    City = address.City
                };
        }

        public Address ToModel()
        {
            return 
                new Address(
                    this.StreetNumber,
                    this.StreetName,
                    new PostalCode(this.PostalCode),
                    this.City);
        }
    }
}