namespace SolidPresentation.DIP.Bad.WpfUi.Commands
{
    using System.Windows.Input;

    public interface ICommandWithRaiseCanExecuteChanged : ICommand
    {
        void RaiseCanExecuteChanged();
    }
}
