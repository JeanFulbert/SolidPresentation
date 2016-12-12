namespace SolidPresentation.DIP.Bad.WpfUi
{
    using System.Windows;
    using SolidPresentation.DIP.Bad.WpfUi.Views;

    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var listPersonsView = new PersonListWindow();
            listPersonsView.Show();
        }
    }
}
