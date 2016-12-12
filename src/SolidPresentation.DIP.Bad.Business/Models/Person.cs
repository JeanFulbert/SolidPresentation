namespace SolidPresentation.DIP.Bad.Business.Models
{
    using System;
    using SolidPresentation.DIP.Bad.Business.DbModel;

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

            this.DbModel = DbPerson.FromPerson(this);
        }

        public string FirstName { get; }
        public string LastName { get; }
        public DateTime BirthDate { get; }
        public Email Email { get; }
        public Address Address { get; }

        internal DbPerson DbModel { get; }
    }
}
