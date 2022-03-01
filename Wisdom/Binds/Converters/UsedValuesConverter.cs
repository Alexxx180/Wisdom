using System;
using System.Windows.Media;
using System.Globalization;
using System.Windows.Data;
using static Wisdom.Customing.Converters;
using static Wisdom.Customing.Decorators;

namespace Wisdom.Binds.Converters
{
    public class UsedValuesConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            foreach (object value in values)
            {
                if (value == null)
                {
                    return new SolidColorBrush(Rgb(255, 252, 199));
                }
            }

            uint max = values[0].ConvertHours(), sum = 0;
            for (int i = 1; i < values.Length; i++)
            {
                sum += values[i].ConvertHours();
            }

            Color defaultColor = Rgb(255, 252, 199);
            Color[] colors = {
                Rgb(255, 152, 99),
                Rgb(155, 252, 199)
            };

            bool[] conditions = {
                sum > max, sum == max
            };

            return new SolidColorBrush(OmniTernar(defaultColor, conditions, colors));
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}