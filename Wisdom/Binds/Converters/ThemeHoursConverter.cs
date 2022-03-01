using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Data;
using Wisdom.Controls.Tables;
using Wisdom.Customing;
using Wisdom.Model;

namespace Wisdom.Binds.Converters
{
    public class ThemeHoursConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return 0;
            ObservableCollection<IRawData<HashList<Pair<string, string>>>>
                works = value as ObservableCollection<IRawData<HashList<Pair<string, string>>>>;

            uint sum = 0;
            for (ushort i = 0; i < works.Count; i++)
            {
                List<Pair<string, string>> work = works[i].Raw().Values;
                for (ushort ii = 0; ii < work.Count; ii++)
                {
                    Pair<string, string> task = work[ii];
                    sum += task.Value.ParseHours();
                }
            }
            return sum.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}