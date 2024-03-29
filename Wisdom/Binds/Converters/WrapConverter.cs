﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using static Wisdom.Customing.Converters;

namespace Wisdom.Binds.Converters
{
    public class WrapConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isWrap = value.ToBool();
            return isWrap ?
                TextWrapping.Wrap :
                TextWrapping.NoWrap;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}