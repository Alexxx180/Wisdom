using System;
using System.Windows.Media;
using System.Windows.Controls;
using System.Collections.Generic;

namespace Wisdom.Customing
{
    public static class Converters
    {
        public static Label Lab(Grid grid, int no) => grid.Children[no] as Label;

        public static TextBlock Txt(Grid grid, int no) => grid.Children[no] as TextBlock;

        public static TextBox Box(Grid grid, int no) => grid.Children[no] as TextBox;

        public static ComboBox Cbx(Grid grid, int no) => grid.Children[no] as ComboBox;

        public static CheckBox Chx(Grid grid, int no) => grid.Children[no] as CheckBox;

        public static Button Btn(Grid grid, int no) => grid.Children[no] as Button;

        public static Border Border(Grid grid, int no) => grid.Children[no] as Border;

        public static StackPanel Panel(Grid grid, int no) => grid.Children[no] as StackPanel;

        public static Grid GridChild(StackPanel stack, int no) => stack.Children[no] as Grid;

        public static Grid Parent(StackPanel stack) => stack.Parent as Grid;

        public static Grid Parent(Button button) => button.Parent as Grid;

        public static StackPanel Parent(Grid stack) => stack.Parent as StackPanel;

        public static Label Child(Border border) => border.Child as Label;

        public static int Itry(string value)
        {
            if (value == "")
                return 0;
            if (int.TryParse(value, out int result))
                return result;
            return 0;
        }
        public static bool Bool(object o) => Convert.ToBoolean(o);
        public static byte Bits(object o) => Convert.ToByte(o);
        public static int Ints(object o) => Convert.ToInt32(o);
    }
}
