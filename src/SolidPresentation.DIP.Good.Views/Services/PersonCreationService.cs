namespace SolidPresentation.DIP.Good.Views.Services
{
    using SolidPresentation.DIP.Good.Domain.Models;
    using SolidPresentation.DIP.Good.Services;
    using SolidPresentation.DIP.Good.ViewModels.Persons;

    public class PersonCreationService : IPersonCreationService
    {
        public CancellableResult<Person> Create()
        {
            var viewModel = new EditPersonViewModel();
            var view = new EditPersonView(viewModel);

            view.ShowDialog();

            return viewModel.Result;
        }
    }
}
