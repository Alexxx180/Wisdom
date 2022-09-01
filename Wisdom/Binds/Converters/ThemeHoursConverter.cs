using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Data;
using Wisdom.Controls.Tables;
using Wisdom.Customing;
using ControlMaterials.Tables.ThemePlan;

namespace Wisdom.Binds.Converters
{
    public class ThemeHoursConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return 0;

            ObservableCollection<IRawData<Work>> works = value as ObservableCollection<IRawData<Work>>;

            uint sum = 0;
            for (ushort i = 0; i < works.Count; i++)
            {
                //List<Task> work = works[i].Raw().Tasks;
                //for (ushort ii = 0; ii < work.Count; ii++)
                //{
                //    Task task = work[ii];
                //    sum += task.Hours.ParseHours();
                //}
            }
            return sum.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}