namespace SolidPresentation.DIP.Bad.WpfUi.ViewModels.Persons
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows;
    using LiteDB;
    using SolidPresentation.DIP.Bad.Business;
    using SolidPresentation.DIP.Bad.WpfUi.Commands;
    using SolidPresentation.DIP.Bad.WpfUi.Utils;
    using SolidPresentation.DIP.Bad.WpfUi.Views;

    public class PersonListViewModel : ViewModelBase
    {
        private readonly LiteDbPersonRepository personRepository;
        private readonly PersonEmailService personEmailService;

        public PersonListViewModel()
        {
            this.personRepository = new LiteDbPersonRepository(new LiteDatabase("local.db"));
            this.personEmailService = new PersonEmailService();

            this.AddNewPersonCommand = new AsyncCommand(this.AddNewPersonAsync);
            this.DeletePersonsCommand = new AsyncCommand(this.DeletePersonsAsync, () => this.SelectedPersons?.Any() ?? false);
        }

        private readonly ObservableCollection<PersonViewModel> persons = new ObservableCollection<PersonViewModel>();
        public IReadOnlyCollection<PersonViewModel> Persons => this.persons;

        private IReadOnlyCollection<PersonViewModel> selectedPersons = new List<PersonViewModel>();
        public IReadOnlyCollection<PersonViewModel> SelectedPersons
        {
            get { return this.selectedPersons; }
            set
            {
                this.selectedPersons = value ?? new List<PersonViewModel>();
                this.RaisePropertyChanged();
                this.DeletePersonsCommand.RaiseCanExecuteChanged();
            }
        }

        public IAsyncCommand AddNewPersonCommand { get; }

        public IAsyncCommand DeletePersonsCommand { get; }

        public async Task LoadAsync()
        {
            var personsFromRepo = await Task.Run(() => this.personRepository.GetAll());
            foreach (var person in personsFromRepo)
            {
                this.persons.Add(new PersonViewModel(person));
            }
        }

        private async Task AddNewPersonAsync()
        {
            var editPersonView = new EditPersonView();
            editPersonView.ShowDialog();

            var result = editPersonView.WindowResult;
            if (result.IsCancelled)
            {
                return;
            }

            await Task.Run(() => this.personRepository.Save(result.Object));
            this.persons.Add(new PersonViewModel(result.Object));

            this.personEmailService.SendAccountCreated(result.Object.Email);
        }

        private async Task DeletePersonsAsync()
        {
            var result = MessageBox.Show(
                $"Are you sure to delete these {this.SelectedPersons.Count} person(s)?",
                "",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.No)
            {
                return;
            }

            var personsToRemove =
                this.SelectedPersons
                    .Select(vm => vm.Person)
                    .ToList();

            await Task.Run(() => this.personRepository.Remove(personsToRemove));

            foreach (var selectedPersonViewModel in this.SelectedPersons)
            {
                this.persons.Remove(selectedPersonViewModel);

                this.personEmailService.SendAccountDeleted(selectedPersonViewModel.Person.Email);
            }

            this.SelectedPersons = new List<PersonViewModel>();
        }
    }
}
