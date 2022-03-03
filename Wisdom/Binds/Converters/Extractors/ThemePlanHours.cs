using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Data;
using Wisdom.Controls.Tables.ThemePlan;
using Wisdom.Customing;

namespace Wisdom.Binds.Converters.Extractors
{
    public class ThemePlanHours : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ObservableCollection<PlanTopic> plan = value as ObservableCollection<PlanTopic>;
            uint sum = 0;
            for (ushort i = 0; i < plan.Count; i++)
            {
                sum += plan[i].TopicHours.ParseHours();
            }
            return sum;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
