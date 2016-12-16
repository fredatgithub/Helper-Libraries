using System;
using System.Globalization;
using System.Windows.Data;

namespace WinLab.Windows.Xaml.Converters
{
    public class BoolToVisibilityConverterEx : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Equals(value, parameter ?? When) ? Value: Otherwise;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public object When { get; set; }

        public object Value { get; set; }

        public object Otherwise { get; set; }
    }
}
