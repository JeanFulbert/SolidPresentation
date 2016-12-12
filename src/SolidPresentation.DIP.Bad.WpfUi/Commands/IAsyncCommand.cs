namespace SolidPresentation.DIP.Bad.WpfUi.Commands
{
    using System.Threading.Tasks;

    public interface IAsyncCommand : ICommandWithRaiseCanExecuteChanged
    {
        Task ExecuteAsync(object parameter);
    }
}
