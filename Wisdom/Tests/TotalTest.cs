using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Wisdom.Model;
using Wisdom.Model.ThemePlan;

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

        public static void TraceItems(ComboBox selector)
        {
            foreach (ComboBoxItem item in selector.Items)
                Trace.WriteLine(item);
        }
        public static void TraceItems<T>(List<T> items)
        {
            foreach (T item in items)
                Trace.WriteLine(item);
        }

        public static void Dump(List<object[]> records)
        {
            for (int i = 0; i < records.Count; i++)
                for (int ii = 0; ii < records[i].Length; ii++)
                    Trace.WriteLine(records[i][ii]);
        }

        public static void TestData(List<Topic> plan)
        {
            foreach (Topic l1 in plan)
            {
                Trace.WriteLine("Раздел ...");
                Trace.WriteLine("Название: " + l1.Name);
                Trace.WriteLine("Часы: " + l1.Hours);
                foreach (Theme l2 in l1.Themes)
                {
                    Trace.WriteLine("Тема ...");
                    Trace.WriteLine("Название: " + l2.Name);
                    Trace.WriteLine("Часы: " + l2.Hours);
                    Trace.WriteLine("Уровень освоения: " + l2.Level);
                    foreach (Work l3 in l2.Works)
                    {
                        Trace.WriteLine("Элемент темы ...");
                        Trace.WriteLine("Название: " + l3.Type);
                        foreach (Task l4 in l3.Tasks)
                        {
                            Trace.WriteLine("Элемент работы ...");
                            Trace.WriteLine("Название: " + l4.Name);
                            Trace.WriteLine("Часы: " + l4.Hours);
                        }
                    }
                }
            }
        }

        public static void TestCompetetion(List<HoursList<Task>> competetion, string prefix)
        {
            foreach (HoursList<Task> l1 in competetion)
            {
                Trace.WriteLine("Компетенция ...");
                Trace.WriteLine("Номер: " + prefix + l1.Name);
                Trace.WriteLine("Название: " + l1.Hours);
                foreach (Task l2 in l1.Values)
                {
                    Trace.WriteLine("Тема ...");
                    Trace.WriteLine("Название: " + l2.Name);
                    Trace.WriteLine("Значение: " + l2.Hours);
                }
            }
        }

        public static void TestCompetetion2(List<List<HoursList<Task>>> competetion, string prefix)
        {
            foreach (List<HoursList<Task>> l1 in competetion)
            {
                TestCompetetion(l1, prefix);
            }
        }
    }
}
