using System;
using System.Windows.Media;
using System.Globalization;
using System.Windows.Data;
using static Wisdom.Customing.Converters;
using static Wisdom.Customing.Decorators;

namespace Wisdom.Binds
{
    class UsedValuesConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            foreach (object value in values)
                if (value == null)
                    return new SolidColorBrush(Color.FromRgb(255, 252, 199));
            int max = Itry(values[0].ToString()), sum = 0;
            for (int i = 1; i < values.Length; i++)
                sum += Itry(values[i].ToString());
            object[] colors = { Color.FromRgb(255, 152, 99), Color.FromRgb(155, 252, 199) };
            Color defaultColor = Color.FromRgb(255, 252, 199);
            bool[] conditions = { sum > max, sum == max };
            return new SolidColorBrush((Color)OmniTernar(defaultColor, conditions, colors));
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
