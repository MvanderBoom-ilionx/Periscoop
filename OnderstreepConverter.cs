using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.TextFormatting;

namespace WpfFormulierDemo
{
    public class OnderstreepConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? TextDecorations.Underline : null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
