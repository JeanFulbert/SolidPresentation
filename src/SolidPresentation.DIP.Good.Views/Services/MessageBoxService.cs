namespace SolidPresentation.DIP.Good.Views.Services
{
    using System.Windows;
    using SolidPresentation.DIP.Good.Services;

    public class MessageBoxService : IMessageBoxService
    {
        public bool ShowQuestion(string message)
        {
            var result = MessageBox.Show(message, "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
            return result == MessageBoxResult.Yes;
        }
    }
}
