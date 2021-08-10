using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace Wisdom.Customing
{
    public static class Converters
    {
        public static Label Lab(Grid grid, int no)
        {
            return grid.Children[no] as Label;
        }
        public static TextBlock Txt(Grid grid, int no)
        {
            return grid.Children[no] as TextBlock;
        }
        public static TextBox Box(Grid grid, int no)
        {
            return grid.Children[no] as TextBox;
        }
        public static ComboBox Cbx(Grid grid, int no)
        {
            return grid.Children[no] as ComboBox;
        }
        public static CheckBox Chx(Grid grid, int no)
        {
            return grid.Children[no] as CheckBox;
        }
        public static Int32 Ints(object o)
        {
            return Convert.ToInt32(o);
        }
        public static Int32 Itry(string value)
        {
            if (value == "")
                return 0;
            if (int.TryParse(value, out int result))
                return result;
            else
                return 0;
        }
        public static bool Bool(object o)
        {
            return Convert.ToBoolean(o);
        }
    }
}
