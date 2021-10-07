using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Wisdom.Customing
{
    public static class Decorators
    {
        private static Uri Ura(in string path)
        {
            return new Uri(path, UriKind.RelativeOrAbsolute);
        }
        public static BitmapImage Bmper(in string path)
        {
            return new BitmapImage(Ura(path));
        }
        public static void AnyHide(FrameworkElement element)
        {
            element.Visibility = Visibility.Hidden;
            element.IsEnabled = false;
        }
        public static void AnyShow(FrameworkElement element)
        {
            element.Visibility = Visibility.Visible;
            element.IsEnabled = true;
        }
        public static void GridHide(Grid grid)
        {
            grid.Visibility = Visibility.Hidden;
            grid.IsEnabled = false;
        }
        public static void GridShow(Grid grid)
        {
            grid.Visibility = Visibility.Visible;
            grid.IsEnabled = true;
        }
        public static void GridHideX(params Grid[] grids)
        {
            foreach (Grid grid in grids) GridHide(grid);
        }
        public static void AnyHideX(params FrameworkElement[] elements)
        {
            foreach (FrameworkElement element in elements) AnyHide(element);
        }
        public static void EnableX(bool value, params FrameworkElement[] elements)
        {
            for (byte i = 0; i < elements.Length; i++)
                elements[i].IsEnabled = value;
        }
        public static void GridAddX(Grid grid, params UIElement[] elements)
        {
            foreach (UIElement element in elements) grid.Children.Add(element);
        }
        public static void GridAddX2(Grid grid, byte startno, params FrameworkElement[] elements)
        {
            List<object> slots = new List<object>();
            foreach (FrameworkElement element in elements)
            {
                grid.Children.Add(element);
                slots.Add(startno);
                startno++;
            }
            SetPropX(Grid.ColumnProperty, slots.ToArray(), elements);
        }
        public static void SetProp(UIElement cntrl, DependencyProperty property, object value)
        {
            cntrl.SetValue(property, value);
        }
        public static void SetPropX(DependencyProperty[] property, object[] value, UIElement cntrl)
        {
            for (int i = 0; i < property.Length; i++) SetProp(cntrl, property[i], value[i]);
        }
        public static void SetPropX(DependencyProperty property, object[] value, Control[] cntrl)
        {
            for (int i=0;i<cntrl.Length;i++) SetProp(cntrl[i], property, value[i]);
        }
        public static void SetPropX(DependencyProperty property, object[] value, UIElement[] cntrl)
        {
            for (int i = 0; i < cntrl.Length; i++) SetProp(cntrl[i], property, value[i]);
        }
        public static void SetPropX(DependencyProperty property, object value, Control[] cntrl)
        {
            for (int i = 0; i < cntrl.Length; i++) SetProp(cntrl[i], property, value);
        }
        public static void StylesX(Style style, params FrameworkElement[] elements)
        {
            foreach (FrameworkElement element in elements) Styles(style, element);
        }
        public static void ColorBack(Color color, Control element)
        {
            element.Background = new SolidColorBrush(color);
        }
        public static void Styles(Style style, FrameworkElement element)
        {
            element.Style = style;
        }
        public static bool NAN(FrameworkElement element)
        {
            return element == null;
        }
        public static bool NA(object o)
        {
            return o == null;
        }
        public static object OmniTernar(object fallBackValue, bool[] conditions, object[] values)
        {
            for (int i = 0; i < conditions.Length; i++)
                if (conditions[i])
                    return values[i];
            return fallBackValue;
        }
    }
}
