namespace SolidPresentation.SRP.Example2.Better
{
    using System;

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Address Address { get; set; }
        public ContactInfo Contact { get; set; }
    }

    public class Address
    {
        public int? StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
    }

    public class ContactInfo
    {
        public string Email { get; set; }
        public string MobilePhoneNumber { get; set; }
        public string HomePhoneNumber { get; set; }
    }
}