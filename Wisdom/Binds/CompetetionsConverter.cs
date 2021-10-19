﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace Wisdom.Binds
{
    class CompetetionsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            List<string> items = new List<string>();
            UIElementCollection grids = value as UIElementCollection;
            for (byte i = 1; i < grids.Count; i++)
            {
                items.Add(i.ToString());
            }
            return items;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
