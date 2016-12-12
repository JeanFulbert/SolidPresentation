namespace SolidPresentation.DIP.Bad.WpfUi.ViewModels
{
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Linq;
    using MvvmValidation;

    public abstract class ViewModelWithValidationBase : ViewModelBase, INotifyDataErrorInfo
    {
        protected ValidationHelper Validator { get; private set; }

        protected ViewModelWithValidationBase()
        {
            this.Validator = new ValidationHelper();
            this.Validator.ResultChanged += this.OnValidatorResultChanged;
        }

        public bool IsValid => this.Validator.GetResult().IsValid;
        public bool HasErrors => !this.IsValid;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            if (propertyName == null)
            {
                return Enumerable.Empty<string>();
            }

            var validationResult = Validator.GetResult(propertyName);

            // Return all the errors as a single string because most UI implementations display only first error
            return
                string.IsNullOrEmpty(propertyName) || validationResult.IsValid
                ? Enumerable.Empty<string>()
                : new[] { validationResult.ToString() };
        }

        public virtual void LoadAsync()
        {
            this.Validator.ValidateAll();
        }

        protected virtual void OnAfterValidationResultChanged()
        {
        }

        public override void Cleanup()
        {
            if (this.Validator != null)
            {
                this.Validator.ResultChanged -= this.OnValidatorResultChanged;
            }

            base.Cleanup();
        }

        private void OnValidatorResultChanged(object sender, ValidationResultChangedEventArgs e)
        {
            this.OnErrorsChanged(e.Target as string);

            this.RaisePropertyChanged(() => this.HasErrors);
            this.RaisePropertyChanged(() => this.IsValid);

            this.OnAfterValidationResultChanged();
        }

        private void OnErrorsChanged(string propertyName)
        {
            this.ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

    }
}
