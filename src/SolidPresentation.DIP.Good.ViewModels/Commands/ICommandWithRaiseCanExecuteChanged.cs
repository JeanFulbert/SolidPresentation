
namespace SolidPresentation.DIP.Good.ViewModels.Commands
{
    using System.Windows.Input;

    public interface ICommandWithRaiseCanExecuteChanged : ICommand
    {
        void RaiseCanExecuteChanged();
    }
}
