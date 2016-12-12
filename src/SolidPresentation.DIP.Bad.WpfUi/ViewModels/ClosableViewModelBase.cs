namespace SolidPresentation.DIP.Bad.WpfUi.ViewModels
{
    using System;

    public abstract class ClosableViewModelBase : ViewModelWithValidationBase
    {
        public event Action RequestClose;

        protected void OnRequestClose()
        {
            this.RequestClose?.Invoke();
        }
    }
}
