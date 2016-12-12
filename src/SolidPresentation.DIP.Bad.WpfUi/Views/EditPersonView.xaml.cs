namespace SolidPresentation.DIP.Bad.WpfUi.Views
{
    using System.Windows;
    using SolidPresentation.DIP.Bad.Business.Models;
    using SolidPresentation.DIP.Bad.WpfUi.Utils;
    using SolidPresentation.DIP.Bad.WpfUi.ViewModels.Persons;

    public partial class EditPersonView
    {
        private readonly EditPersonViewModel viewModel;

        public EditPersonView()
        {
            this.viewModel = new EditPersonViewModel();
            this.viewModel.RequestClose += this.OnRequestClose;

            InitializeComponent();
            this.DataContext = this.viewModel;

            this.Loaded += this.OnLoaded;
            this.Unloaded += this.OnUnloaded;
        }

        internal ClosableWindowResult<Person> WindowResult => this.viewModel.Result;

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            this.viewModel.LoadAsync();
        }

        private void OnUnloaded(object sender, RoutedEventArgs e)
        {
            this.viewModel.RequestClose -= this.OnRequestClose;
            this.Unloaded -= this.OnUnloaded;
        }

        private void OnRequestClose()
        {
            this.Close();
        }
    }
}
