using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Wisdom.Tests
{
    public static class TotalTest
    {
        public static void TraceChildren(Grid grid)
        {
            foreach (UIElement element in grid.Children)
                Trace.WriteLine(element);
        }

        public static void TraceChildren(StackPanel panel)
        {
            foreach (UIElement element in panel.Children)
                Trace.WriteLine(element);
        }

        public static void TraceItems(Selector selector)
        {
            foreach (ContentControl item in selector.Items)
                Trace.WriteLine(item);
        }
        public static void TraceItems<T>(List<T> items)
        {
            foreach (T item in items)
                Trace.WriteLine(item);
        }
    }
}
