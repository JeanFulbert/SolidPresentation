namespace SolidPresentation.DIP.Good.ViewModels.Persons
{
    using System;
    using MvvmValidation;
    using SolidPresentation.DIP.Good.Domain.Models;

    public class EditPersonViewModel : ClosableWithResultViewModelBase<Person>
    {
        private long id = Person.JustCreatedId;

        public EditPersonViewModel()
        {
            this.Address.ValueChanged += this.OnAddressValueChanged;

            this.Validator.AddRequiredRule(() => this.FirstName, "First name is mandatory.");
            this.Validator.AddRequiredRule(() => this.LastName, "Last name is mandatory.");
            this.Validator.AddRequiredRule(() => this.BirthDate, "Birth date is mandatory.");
            this.Validator.AddRequiredRule(() => this.Email, "Email is mandatory.");
            this.Validator.AddRule(
                () => this.Address,
                () => RuleResult.Assert(
                    this.Address != null && this.Address.IsValid,
                    "Address is mandatory."));
        }

        private string firstName;
        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                this.firstName = value;
                this.RaisePropertyChanged();
                this.Validator.Validate(() => this.FirstName);
            }
        }

        private string lastName;
        public string LastName
        {
            get { return this.lastName; }
            set
            {
                this.lastName = value;
                this.RaisePropertyChanged();
                this.Validator.Validate(() => this.LastName);
            }
        }

        private DateTime? birthDate;
        public DateTime? BirthDate
        {
            get { return this.birthDate; }
            set
            {
                this.birthDate = value;
                this.RaisePropertyChanged();
                this.Validator.Validate(() => this.BirthDate);
            }
        }

        private Email email;
        public Email Email
        {
            get { return this.email; }
            set
            {
                this.email = value;
                this.RaisePropertyChanged();
                this.Validator.Validate(() => this.Email);
            }
        }

        private AddressViewModel address = new AddressViewModel();
        public AddressViewModel Address
        {
            get { return this.address; }
            set
            {
                this.address = value;
                this.RaisePropertyChanged();
                this.Validator.Validate(() => this.Address);
            }
        }

        public void LoadFrom(Person person)
        {
            this.id = person.Id;
            this.FirstName = person.FirstName;
            this.LastName = person.LastName;
            this.BirthDate = person.BirthDate;
            this.Email = person.Email;
            this.Address = new AddressViewModel(person.Address);
        }

        public override void LoadAsync()
        {
            this.Address.LoadAsync();
            base.LoadAsync();
        }

        protected override Person GetResult()
        {
            return
                new Person(
                    this.id,
                    this.FirstName,
                    this.LastName,
                    this.BirthDate.Value,
                    this.Email,
                    this.Address.ToModel());
        }

        private void OnAddressValueChanged()
        {
            this.Validator.Validate(() => this.Address);
        }
    }
}
