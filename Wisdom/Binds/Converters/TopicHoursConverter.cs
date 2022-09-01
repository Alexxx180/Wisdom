using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Data;
using Wisdom.Controls.Tables.ThemePlan.Themes;
using Wisdom.Customing;

namespace Wisdom.Binds.Converters
{
    public class TopicHoursConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return 0;

            ObservableCollection<PlanTheme> themes = value as ObservableCollection<PlanTheme>;

            uint sum = 0;
            for (ushort i = 0; i < themes.Count; i++)
            {
                //string hours = themes[i].Raw().Hours;
                //sum += hours.ParseHours();
            }
            return sum.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
