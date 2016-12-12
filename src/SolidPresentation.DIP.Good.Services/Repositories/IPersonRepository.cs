namespace SolidPresentation.DIP.Good.Services.Repositories
{
    using System.Collections.Generic;
    using SolidPresentation.DIP.Good.Domain.Models;

    public interface IPersonRepository : IPersonReadonlyRepository
    {
        void Save(Person person);

        void Remove(IReadOnlyCollection<Person> personsToRemove);
    }
}
