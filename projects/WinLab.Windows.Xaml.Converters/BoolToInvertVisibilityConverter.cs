using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WinLab.Windows.Xaml.Converters
{
    public class BoolToInvertVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value is bool && (bool)value) ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var visiblityValue = (Visibility)value;
            return visiblityValue != Visibility.Visible;
        }
    }
}
