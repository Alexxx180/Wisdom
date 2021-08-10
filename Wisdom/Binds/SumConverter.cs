using System;
using System.Globalization;
using System.Windows.Data;
using static Wisdom.Customing.Converters;

namespace Wisdom.Binds
{
    public class SumConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            int sum = 0;
            foreach (string value in values)
                sum += Itry(value);
            return sum.ToString();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
