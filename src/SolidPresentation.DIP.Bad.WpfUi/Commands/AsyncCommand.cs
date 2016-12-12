namespace SolidPresentation.DIP.Bad.WpfUi.Commands
{
    using System;
    using System.Threading.Tasks;

    public class AsyncCommand : AsyncCommandBase
    {
        private readonly Func<Task> getCommand;
        private readonly Func<bool> canExecute;

        public AsyncCommand(Func<Task> getCommand, Func<bool> canExecute = null)
        {
            if (getCommand == null)
            {
                throw new ArgumentNullException(nameof(getCommand));
            }

            this.getCommand = getCommand;
            this.canExecute = canExecute;
        }

        public override bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute();
        }

        public override Task ExecuteAsync(object parameter)
        {
            return this.getCommand();
        }
    }
}
