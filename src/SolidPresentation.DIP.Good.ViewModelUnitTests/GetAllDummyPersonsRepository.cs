namespace SolidPresentation.DIP.Good.ViewModelUnitTests
{
    using System.Collections.Generic;
    using SolidPresentation.DIP.Good.Domain.Models;
    using SolidPresentation.DIP.Good.Services.Repositories;

    internal class GetAllDummyPersonsRepository : IPersonRepository
    {
        public IReadOnlyCollection<Person> GetAll() =>
            PersonsFactory.All;

        public void Save(Person person)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(IReadOnlyCollection<Person> personsToRemove)
        {
            throw new System.NotImplementedException();
        }
    }
}
