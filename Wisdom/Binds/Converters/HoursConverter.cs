using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Data;
using Wisdom.Controls.Tables.Hours;
using Wisdom.Model.Tables;

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
                Hour hour = hours[i].Raw();
                sum += hour.Count;
            }
            return sum.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}