namespace SolidPresentation.DIP.Good.ViewModels.Persons
{
    using System;
    using SolidPresentation.DIP.Good.Domain.Models;

    public class PersonViewModel : ViewModelBase
    {
        public PersonViewModel(Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullException(nameof(person));
            }

            this.Person = person;
        }

        public Person Person { get; }

        public string Description =>
            $"{this.Person.FirstName} {this.Person.LastName} (birth date: {this.Person.BirthDate.ToShortDateString()})";
    }
}