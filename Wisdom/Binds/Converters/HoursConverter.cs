using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Data;
using Wisdom.Controls.Tables.Hours;
using Wisdom.Model;

namespace Wisdom.Binds.Converters
{
    public class HoursConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ObservableCollection<HourElement> hours = value as ObservableCollection<HourElement>;

            uint sum = 0;
            for (ushort i = 0; i < hours.Count; i++)
            {
                Pair<string, ushort> hour = hours[i].Raw();
                sum += hour.Value;
            }
            return sum.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}