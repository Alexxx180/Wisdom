﻿using System;
using System.Windows.Media;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Wisdom.Controls;
using Wisdom.Controls.Tables;

namespace Wisdom.Customing
{
    public static class Converters
    {
        public static bool ToBool(this object value)
        {
            return Convert.ToBoolean(value);
        }

        public static byte ToByte(this object value)
        {
            return Convert.ToByte(value);
        }

        public static int ToInt(this object value)
        {
            return Convert.ToInt32(value);
        }

        public static ushort ToUShort(this object value)
        {
            return Convert.ToUInt16(value);
        }

        public static uint ToUInt(this object value)
        {
            return Convert.ToUInt32(value);
        }

        public static ulong ToULong(this object value)
        {
            return Convert.ToUInt64(value);
        }

        public static Indexing ToMode(this object value)
        {
            return (Indexing)value;
        }

        public static ushort ConvertHours(this object hours)
        {
            return ParseHours(hours.ToString());
        }

        public static ushort ParseHours(this string hours)
        {
            return ushort.TryParse(hours, out ushort result) ? result : 0.ToUShort();
        }

        public static void Refresh<T>(this List<T> list, IEnumerable<T> value)
        {
            list.Clear();
            list.AddRange(value);
        }

        public static void Refresh<T>(this Collection<T> list, IEnumerable<T> value)
        {
            list.Clear();
            foreach (T item in value)
                list.Add(item);
        }

        public static void Refresh<T>(this List<T> list, IEnumerable<IRawData<T>> value)
        {
            list.Clear();
            foreach (IRawData<T> item in value)
                list.Add(item.Raw());
        }

        public static void Refresh<T>(this Collection<T> list, IEnumerable<IRawData<T>> value)
        {
            list.Clear();
            foreach (IRawData<T> item in value)
                list.Add(item.Raw());
        }

        public static List<T> GetRaw<T>(this Collection<IRawData<T>> list)
        {
            List<T> elements = new List<T>();
            for (byte i = 0; i < list.Count; i++)
            {
                elements.Add(list[i].Raw());
            }
            return elements;
        }

        public static Color Rgb(byte red, byte green, byte blue)
        {
            return Color.FromRgb(red, green, blue);
        }

        public static ushort GetStudyHours(this Dictionary<string, ushort> hours)
        {
            ushort total = 0;
            foreach (KeyValuePair<string, ushort> pair in hours)
                total += TryGetHours(hours, pair.Key);
            return total;
        }

        public static ushort TryGetHours(this Dictionary<string, ushort> hours, string name)
        {
            if (hours.TryGetValue(name, out ushort max))
                return max;
            return 0;
        }
    }
}
