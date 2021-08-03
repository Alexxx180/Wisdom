using System;
using System.Windows;
using System.Windows.Controls;
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
        public static void GridAddX(Grid grid, params UIElement[] elements)
        {
            foreach (UIElement element in elements) grid.Children.Add(element);
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
        public static void SetPropX(DependencyProperty property, object value, Control[] cntrl)
        {
            for (int i = 0; i < cntrl.Length; i++) SetProp(cntrl[i], property, value);
        }
        public static bool NAN(FrameworkElement element)
        {
            return element == null;
        }
        public static bool NA(object o)
        {
            return o == null;
        }
    }
}
