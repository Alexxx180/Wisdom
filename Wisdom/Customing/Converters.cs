using System;
using Wisdom.Controls;

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
            return ushort.TryParse(hours, out ushort result) ? 
                result : 0.ToUShort();
        }

        /// <summary>
        /// Format number to fit general prefix number.
        /// </summary>
        /// <param name="value">String value.</param>
        /// <returns>General competetion prefix no.</returns>
        public static string ToGeneralNo(this uint value)
        {
            return string.Format("{0:00}", value);
        }
    }
}