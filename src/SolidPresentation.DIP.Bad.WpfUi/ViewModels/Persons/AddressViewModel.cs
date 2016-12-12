namespace SolidPresentation.DIP.Bad.WpfUi.ViewModels.Persons
{
    using System;
    using MvvmValidation;
    using SolidPresentation.DIP.Bad.Business.Models;

    public class AddressViewModel : ViewModelWithValidationBase
    {
        public event Action ValueChanged;

        public AddressViewModel(Address address)
            : this()
        {
            this.StreetNumber = address.StreetNumber;
            this.StreetName = address.StreetName;
            this.PostalCode = address.PostalCode;
            this.City = address.City;
        }

        public AddressViewModel()
        {
            this.Validator.AddRequiredRule(() => this.StreetNumber, "Street number is required.");
            this.Validator.AddRequiredRule(() => this.StreetName, "Street name is required.");
            this.Validator.AddRequiredRule(() => this.PostalCode, "Postal code is required.");
            this.Validator.AddRequiredRule(() => this.City, "City is required.");

            this.Validator.AddRule(
                () => this.StreetNumber,
                () => RuleResult.Assert(this.StreetNumber.GetValueOrDefault(0) > 0, "Street number must be positive"));
        }

        private int? streetNumber;
        public int? StreetNumber
        {
            get { return this.streetNumber; }
            set
            {
                this.streetNumber = value;
                this.RaisePropertyChanged();
                this.Validator.Validate(() => this.StreetNumber);
            }
        }

        private string streetName;
        public string StreetName
        {
            get { return this.streetName; }
            set
            {
                this.streetName = value;
                this.RaisePropertyChanged();
                this.Validator.Validate(() => this.StreetName);
            }
        }
        
        private PostalCode postalCode;
        public PostalCode PostalCode
        {
            get { return this.postalCode; }
            set
            {
                this.postalCode = value;
                this.RaisePropertyChanged();
                this.Validator.Validate(() => this.PostalCode);
            }
        }
        
        private string city;
        public string City
        {
            get { return this.city; }
            set
            {
                this.city = value;
                this.RaisePropertyChanged();
                this.Validator.Validate(() => this.City);
            }
        }

        protected override void OnAfterValidationResultChanged()
        {
            base.OnAfterValidationResultChanged();
            this.ValueChanged?.Invoke();
        }

        public Address ToModel()
        {
            return
                new Address(
                    this.StreetNumber.Value,
                    this.StreetName,
                    new PostalCode(this.PostalCode),
                    this.City);
        }
    }
}