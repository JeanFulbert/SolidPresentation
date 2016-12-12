namespace SolidPresentation.DIP.Good.Views
{
    using System.Windows;
    using SolidPresentation.DIP.Good.ViewModels.Persons;

    public partial class AddressControl
    {
        public AddressControl()
        {
            InitializeComponent();
        }
        
        public AddressViewModel Address
        {
            get { return (AddressViewModel)GetValue(AddressProperty); }
            set { SetValue(AddressProperty, value); }
        }

        public static readonly DependencyProperty AddressProperty =
            DependencyProperty.Register("Address", typeof(AddressViewModel), typeof(AddressControl), new PropertyMetadata(null));
    }
}
