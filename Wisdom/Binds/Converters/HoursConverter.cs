using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Data;
using Wisdom.Controls;
using Wisdom.Customing;
using Wisdom.Model;

namespace Wisdom.Binds.Converters
{
    public class HoursConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ObservableCollection<HourElement> hours = value as ObservableCollection<HourElement>;
            List<Pair<string, ushort>> hoursData = hours.GetRaw();

            uint sum = 0;
            for (ushort i = 0; i < hoursData.Count; i++)
            {
                sum += hoursData[i].Value;
            }
            return sum.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}