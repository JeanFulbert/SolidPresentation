namespace SolidPresentation.DIP.Good.Views.Converters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;
    using SolidPresentation.DIP.Good.Domain.Models;

    public class PostalCodeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (string)(value as PostalCode);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return
                PostalCode.IsValid((string)value)
                    ? new PostalCode((string)value)
                    : null;
        }
    }
}
