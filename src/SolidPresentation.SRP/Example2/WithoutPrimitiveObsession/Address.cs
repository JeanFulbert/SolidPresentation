namespace SolidPresentation.SRP.Example2.BetterWithoutPrimitiveObsession
{
    using System;

    public class Address
    {
        public StreetNumber StreetNumber { get; }
        public string StreetName { get; }
        public PostalCode PostalCode { get; }
        public string City { get; }

        public Address(StreetNumber streetNumber, string streetName, PostalCode postalCode, string city)
        {
            if (city == null)
                throw new ArgumentNullException (nameof(city));
            if (postalCode == null)
                throw new ArgumentNullException (nameof(postalCode));
            if (streetName == null)
                throw new ArgumentNullException (nameof(streetName));

            this.StreetNumber = streetNumber;
            this.StreetName = streetName;
            this.PostalCode = postalCode;
            this.City = city;
        }
    }
}