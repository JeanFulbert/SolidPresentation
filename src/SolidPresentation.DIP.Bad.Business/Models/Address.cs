namespace SolidPresentation.DIP.Bad.Business.Models
{
    using System;

    public class Address : ValueObject<Address>
    {
        public Address(int streetNumber, string streetName, PostalCode postalCode, string city)
        {
            if (streetNumber <= 0)
            {
                throw new ArgumentException("The street number must be strictly positive.");
            }

            if (streetName == null)
            {
                throw new ArgumentNullException(nameof(streetName));
            }

            if (postalCode == null)
            {
                throw new ArgumentNullException(nameof(postalCode));
            }

            if (city == null)
            {
                throw new ArgumentNullException(nameof(city));
            }

            this.StreetNumber = streetNumber;
            this.StreetName = streetName;
            this.PostalCode = postalCode;
            this.City = city;
        }

        public int StreetNumber { get; }
        public string StreetName { get; }
        public PostalCode PostalCode { get; }
        public string City { get; }

        protected override bool EqualsCore(Address other)
        {
            return
                this.StreetNumber == other.StreetNumber &&
                this.StreetName == other.StreetName &&
                this.PostalCode == other.PostalCode &&
                this.City == other.City;
        }

        protected override int GetHashCodeCore()
        {
            return
                GetHashCodeCombiner.GetCombinedHashCode(
                    this.StreetNumber,
                    this.StreetName,
                    this.PostalCode,
                    this.City);
        }
    }
}