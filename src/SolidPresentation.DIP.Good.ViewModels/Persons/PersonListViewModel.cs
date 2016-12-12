namespace SolidPresentation.DIP.Good.ViewModels.Persons
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;
    using SolidPresentation.DIP.Good.Services;
    using SolidPresentation.DIP.Good.Services.Repositories;
    using SolidPresentation.DIP.Good.ViewModels.Commands;

    public class PersonListViewModel : ViewModelBase
    {
        private readonly IPersonRepository personRepository;
        private readonly IEditPersonService editPersonService;
        private readonly IMessageBoxService messageBoxService;
        private readonly PersonEmailService personEmailService;

        public PersonListViewModel(
            IPersonRepository personRepository,
            IEditPersonService editPersonService,
            IMessageBoxService messageBoxService,
            PersonEmailService personEmailService)
        {
            if (personRepository == null)
            {
                throw new ArgumentNullException(nameof(personRepository));
            }

            if (editPersonService == null)
            {
                throw new ArgumentNullException(nameof(editPersonService));
            }

            if (messageBoxService == null)
            {
                throw new ArgumentNullException(nameof(messageBoxService));
            }

            if (personEmailService == null)
            {
                throw new ArgumentNullException(nameof(personEmailService));
            }

            this.personRepository = personRepository;
            this.editPersonService = editPersonService;
            this.messageBoxService = messageBoxService;
            this.personEmailService = personEmailService;

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
            var result = this.editPersonService.Create();
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
            var canDeletePersons =
                this.messageBoxService.ShowQuestion(
                    $"Are you sure to delete these {this.SelectedPersons.Count} person(s)?");

            if (!canDeletePersons)
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

                this.personEmailService.SendAccountCreated(selectedPersonViewModel.Person.Email);
            }

            this.SelectedPersons = new List<PersonViewModel>();
        }
    }
}
