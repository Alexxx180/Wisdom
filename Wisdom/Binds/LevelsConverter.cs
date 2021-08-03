using System;
using System.Globalization;
using System.Windows.Data;

namespace Wisdom.Binds
{
    public class LevelsConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return values[0].ToString() + " - " + values[1].ToString() + " (" + values[2].ToString() + ")\n";
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
