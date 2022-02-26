using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using Wisdom.Controls.Tables;

namespace Wisdom.Binds.Converters
{
    public class IndexableCollectionConverter<T> : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ObservableCollection<T> original = value as ObservableCollection<T>;
            IEnumerable<IOptionableIndexing> casted = original.Cast<IOptionableIndexing>();
            return new ObservableCollection<IOptionableIndexing>(casted);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ObservableCollection<IOptionableIndexing> original = value as ObservableCollection<IOptionableIndexing>;
            IEnumerable<T> casted = original.Cast<T>();
            return new ObservableCollection<T>(casted);
        }
    }
}