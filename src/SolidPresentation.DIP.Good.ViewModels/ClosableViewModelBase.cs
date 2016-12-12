namespace SolidPresentation.DIP.Good.ViewModels
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
