namespace SolidPresentation.ISP.Other
{
    using System.Collections.Generic;

    public class PersonEntityContext
    {
        private List<Person> persons = new List<Person>
        {
            new Person("Jean-Pierre"),
            new Person("Jean-Jacques"),
            new Person("Jean-Eudes")
        };
        public IReadOnlyCollection<Person> GetAll()
        {
            return persons;
        }

        public void Save(Person person)
        {
            this.persons.Add(person);
        }
    }
}