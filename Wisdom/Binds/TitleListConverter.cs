using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Documents;

namespace Wisdom.Binds
{
    public class TitleListConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string result = "";
            for (int i = 0; i < values.Length - 1; i+=2)
            {
                result += values[i].ToString() + '\n';
                ListItem[] items = values[i + 1] as ListItem[];
                if (items != null)
                    foreach (ListItem item in items)
                        result += item.ToString() + '\n';
            }
            return result;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
