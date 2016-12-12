namespace SolidPresentation.DIP.Good.Views
{
    using System;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using SolidPresentation.DIP.Good.ViewModels.Persons;

    public partial class PersonListWindow
    {
        private readonly PersonListViewModel viewModel;

        public PersonListWindow(PersonListViewModel viewModel)
        {
            if (viewModel == null)
            {
                throw new ArgumentNullException(nameof(viewModel));
            }

            this.viewModel = viewModel;
            this.InitializeComponent();
            this.DataContext = viewModel;

            this.Loaded += this.OnLoaded;
            this.Unloaded += this.OnUnloaded;
            this.PersonListBox.SelectionChanged += this.OnSelectedPersonsChanged;
        }

        private void OnSelectedPersonsChanged(object sender, SelectionChangedEventArgs e)
        {
            this.viewModel.SelectedPersons =
                this.PersonListBox.SelectedItems
                    .Cast<PersonViewModel>()
                    .ToList();
        }

        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            await this.viewModel.LoadAsync();
        }

        private void OnUnloaded(object sender, RoutedEventArgs e)
        {
            this.Loaded -= this.OnLoaded;
            this.Unloaded -= this.OnUnloaded;
        }
    }
}
