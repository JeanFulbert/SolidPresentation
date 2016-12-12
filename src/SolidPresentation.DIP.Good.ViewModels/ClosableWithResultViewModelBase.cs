namespace SolidPresentation.DIP.Good.ViewModels
{
    using System.Threading;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using SolidPresentation.DIP.Good.Services;

    public abstract class ClosableWithResultViewModelBase<T> : ClosableViewModelBase
    {
        private readonly SynchronizationContext currentContext;

        protected ClosableWithResultViewModelBase()
        {
            this.currentContext = SynchronizationContext.Current;

            this.ValidateCommand = new RelayCommand(this.Validate, this.CanValidate);
            this.CancelCommand = new RelayCommand(this.Cancel);
        }

        public CancellableResult<T> Result { get; private set; }

        public ICommand ValidateCommand { get; }

        public ICommand CancelCommand { get; }

        protected abstract T GetResult();

        protected virtual bool CanValidate()
        {
            return !this.HasErrors;
        }

        private void Validate()
        {
            if (this.HasErrors)
            {
                return;
            }

            var result = this.GetResult();
            this.Result = CancellableResult<T>.Success(result);
            this.OnRequestClose();
        }

        private void Cancel()
        {
            this.Result = CancellableResult<T>.Cancel();
            this.OnRequestClose();
        }

        protected override void OnAfterValidationResultChanged()
        {
            this.currentContext.Post(o =>
                ((RelayCommand)this.ValidateCommand).RaiseCanExecuteChanged()
                , null);
        }
    }
}
