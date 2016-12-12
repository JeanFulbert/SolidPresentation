namespace SolidPresentation.DIP.Good.PersistLiteDb.DbModel
{
    using System;
    using SolidPresentation.DIP.Good.Domain.Models;

    public class DbPerson
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public DbAddress Address { get; set; }

        public Person ToPerson()
        {
            return
                new Person(
                    this.Id,
                    this.FirstName, 
                    this.LastName, 
                    this.BirthDate, 
                    new Email(this.Email),
                    this.Address.ToModel());
        }

        public static DbPerson FromPerson(Person person)
        {
            return
                new DbPerson
                {
                    Id = person.Id,
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    BirthDate = person.BirthDate,
                    Email = person.Email,
                    Address = DbAddress.FromAddress(person.Address)
                };
        }
    }
}
