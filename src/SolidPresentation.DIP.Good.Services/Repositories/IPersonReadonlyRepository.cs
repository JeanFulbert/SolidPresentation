namespace SolidPresentation.DIP.Good.Services.Repositories
{
    using System.Collections.Generic;
    using SolidPresentation.DIP.Good.Domain.Models;

    public interface IPersonReadonlyRepository
    {
        IReadOnlyCollection<Person> GetAll();
    }
}
