namespace SolidPresentation.DIP.Good.Domain.Models
{
    using System;

    public sealed class Person : Entity
    {
        public const long JustCreatedId = long.MinValue;

        public Person(long id, string firstName, string lastName, DateTime birthDate, Email email, Address address)
        {
            if (firstName == null)
            {
                throw new ArgumentNullException(nameof(firstName));
            }

            if (lastName == null)
            {
                throw new ArgumentNullException(nameof(lastName));
            }

            if (email == null)
            {
                throw new ArgumentNullException(nameof(email));
            }

            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.BirthDate = birthDate;
            this.Email = email;
            this.Address = address;
        }

        public string FirstName { get; }
        public string LastName { get; }
        public DateTime BirthDate { get; }
        public Email Email { get; }
        public Address Address { get; }
    }
}
