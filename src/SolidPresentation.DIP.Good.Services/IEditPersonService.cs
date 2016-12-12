namespace SolidPresentation.DIP.Good.Services
{
    using SolidPresentation.DIP.Good.Domain.Models;

    public interface IEditPersonService
    {
        CancellableResult<Person> Create();
    }
}
