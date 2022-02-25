using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using Wisdom.Controls.Tables;
using Wisdom.Controls.Tables.Competetions.General;

namespace Wisdom.Binds.Converters
{
    public class IndexableCollectionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ObservableCollection<GeneralCompetetion> original = value as ObservableCollection<GeneralCompetetion>;
            IEnumerable<IOptionableIndexing> casted = original.Cast<IOptionableIndexing>();
            return new ObservableCollection<IOptionableIndexing>(casted);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ObservableCollection<IOptionableIndexing> original = value as ObservableCollection<IOptionableIndexing>;
            IEnumerable<GeneralCompetetion> casted = original.Cast<GeneralCompetetion>();
            return new ObservableCollection<GeneralCompetetion>(casted);
        }
    }
}