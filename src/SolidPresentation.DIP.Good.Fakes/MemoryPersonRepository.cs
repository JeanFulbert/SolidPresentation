namespace SolidPresentation.DIP.Good.Fakes
{
    using System.Collections.Generic;
    using SolidPresentation.DIP.Good.Domain.Models;
    using SolidPresentation.DIP.Good.Services.Repositories;

    public class MemoryPersonRepository : IPersonRepository
    {
        private readonly List<Person> personns = new List<Person>();

        public IReadOnlyCollection<Person> GetAll()
        {
            return this.personns;
        }

        public void Save(Person person)
        {
            if (this.personns.Contains(person))
            {
                this.personns.Remove(person);
            }

            this.personns.Add(person);
        }

        public void Remove(IReadOnlyCollection<Person> personsToRemove)
        {
            foreach (var person in personsToRemove)
            {
                if (this.personns.Contains(person))
                {
                    this.personns.Remove(person);
                }
            }
        }
    }
}