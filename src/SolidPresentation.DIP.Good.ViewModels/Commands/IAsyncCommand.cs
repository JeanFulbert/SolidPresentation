namespace SolidPresentation.DIP.Good.ViewModels.Commands
{
    using System.Threading.Tasks;

    public interface IAsyncCommand : ICommandWithRaiseCanExecuteChanged
    {
        Task ExecuteAsync(object parameter);
    }
}
