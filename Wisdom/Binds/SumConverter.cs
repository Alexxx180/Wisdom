using System;
using System.Globalization;
using System.Windows.Data;

namespace Wisdom.Binds
{
    public class SumConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            int sum = 0;
            //foreach (int value in values)
             //   sum += value;
            return sum.ToString();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
