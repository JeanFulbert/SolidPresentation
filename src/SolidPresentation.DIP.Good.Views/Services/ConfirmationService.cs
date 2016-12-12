namespace SolidPresentation.DIP.Good.Views.Services
{
    using System.Windows;
    using SolidPresentation.DIP.Good.Services;

    public class ConfirmationService : IConfirmationService
    {
        public bool ConfirmPersonDeletion(int nbPersonToDelete)
        {
            var message = $"Are you sure to delete these {nbPersonToDelete} person(s)?";
            return this.ShowQuestion(message);
        }

        private bool ShowQuestion(string message)
        {
            var result = MessageBox.Show(message, "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
            return result == MessageBoxResult.Yes;
        }
    }
}
