namespace SolidPresentation.DIP.Good.Views.Converters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;
    using SolidPresentation.DIP.Good.Domain.Models;

    public class EmailConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (string)(value as Email);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return
                Email.IsValid((string)value)
                    ? new Email((string)value)
                    : null;
        }
    }
}
