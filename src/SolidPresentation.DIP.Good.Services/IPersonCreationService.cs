namespace SolidPresentation.DIP.Good.Services
{
    using SolidPresentation.DIP.Good.Domain.Models;

    public interface IPersonCreationService
    {
        CancellableResult<Person> Create();
    }
}
