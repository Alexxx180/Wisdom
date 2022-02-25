using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using Wisdom.Controls.Tables;

namespace Wisdom.Binds.Converters
{
    public class ObjectTypeConverter<T> : TypeConverter
    {
        public override bool
            CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(T);
        }

        public override object
            ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            return value as ObservableCollection<IAutoIndexing>;
        }

        public override bool
            CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(T);
        }

        public override object ConvertTo(ITypeDescriptorContext context,
            CultureInfo culture, object value, Type destinationType)
        {
            if (value == null)
                return null;
            else
                return (T)value;
        }
    }
}