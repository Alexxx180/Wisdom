using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Data;
using System.Windows.Media;
using System.Globalization;
using static Wisdom.Customing.Converters;

namespace Wisdom.Binds
{
    public class CompareConverter : IValueConverter, INotifyPropertyChanged
    {
        private string _compareTo = null;
        public Binding CompareTo
        {
            set { throw new Exception((value as Binding).Source.ToString()); _compareTo = value.ToString() ?? ""; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return new SolidColorBrush(Color.FromRgb(255, 252, 199));
            int sum = Itry(value.ToString());
            return new SolidColorBrush((Itry(_compareTo) > sum) ? Color.FromRgb(255, 152, 99) : Color.FromRgb(255, 252, 199));
        }

        public object ConvertBack(object value, Type targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
