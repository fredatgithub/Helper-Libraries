using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WinLab.Windows.Xaml.Converters
{
    public class NullOrEmptyStringToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Converts the specified value to visibility property. 
        /// If the passed value is null or empty, will return <code>Visibility.Collapsed</code>.
        /// In other case, <code>Visibility.Visible</code>.
        /// </summary>
        /// <param name="value">The passed value.</param>
        /// <param name="targetType">Type of the target.</param>
        /// <param name="parameter">The parameter.</param>
        /// <param name="culture">The culture.</param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null || string.IsNullOrEmpty(value.ToString().Trim()) ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}