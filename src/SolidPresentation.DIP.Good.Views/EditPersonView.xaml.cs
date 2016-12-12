namespace SolidPresentation.DIP.Good.Views
{
    using System.Windows;
    using SolidPresentation.DIP.Good.ViewModels.Persons;

    public partial class EditPersonView
    {
        private readonly EditPersonViewModel viewModel;

        public EditPersonView(EditPersonViewModel viewModel)
        {
            this.viewModel = viewModel;
            this.viewModel.RequestClose += this.OnRequestClose;

            InitializeComponent();
            this.DataContext = this.viewModel;

            this.Loaded += this.OnLoaded;
            this.Unloaded += this.OnUnloaded;
        }

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
