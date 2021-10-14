using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using static Wisdom.Customing.ResourceHelper;
using static Wisdom.Customing.Converters;

namespace Wisdom.Customing
{
    public static class BlockTemplates
    {
        public static Grid GridItem()
        {
            Grid grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.05, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.15, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.7, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.1, GridUnitType.Star) });
            return grid;
        }
        public static Grid GridItem2()
        {
            Grid grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.05, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.35, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.5, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.1, GridUnitType.Star) });
            return grid;
        }
        public static Grid GridItem3()
        {
            Grid grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.05, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.15, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.3, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.5, GridUnitType.Star) });
            return grid;
        }
        public static Grid GridItem4()
        {
            Grid grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.05, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.15, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.6, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.1, GridUnitType.Star) });
            return grid;
        }
        public static Grid GridItem5()
        {
            Grid grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.05, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.125, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.075, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.65, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.1, GridUnitType.Star) });
            return grid;
        }
        public static Grid GridItem6()
        {
            Grid grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.05, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.95, GridUnitType.Star) });
            return grid;
        }

        public static void AddItems(ComboBox box, params string[] names)
        {
            foreach (string name in names) box.Items.Add(new ComboBoxItem { Content = name });
        }
        public static void AddRows(Grid grid)
        {
            grid.RowDefinitions.Add(new RowDefinition());
        }
        public static void AddRows(Grid grid, int repeat)
        {
            for (int i = 0; i < repeat; i++) AddRows(grid);
        }
        public static void AddCols(Grid grid, double width)
        {
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(width, GridUnitType.Star) });
        }
        public static void AddCols(Grid grid, params double[] width)
        {
            foreach (double w in width) AddCols(grid, w);
        }
        public static void AddTCols(Table grid, double width)
        {
            grid.Columns.Add(new TableColumn { Width = new GridLength(width, GridUnitType.Star) });
        }
        public static void AddTCols(Table grid, params double[] width)
        {
            foreach (double w in width) AddTCols(grid, w);
        }
        public static void AddRCells(TableRow row, TableCell cell)
        {
            row.Cells.Add(cell);
        }
        public static void AddRCells(TableRow row, params TableCell[] cells)
        {
            foreach (TableCell cell in cells) AddRCells(row, cell);
        }
        public static void MenuItemTemplating(MenuItem item, RichTextBox box)
        {
            DependencyProperty[] dps = new DependencyProperty[] { TextElement.FontWeightProperty, TextElement.FontStyleProperty, TextBlock.TextDecorationsProperty };
            int p = Ints(item.Tag);
            object[] obs = { item.FontWeight, item.FontStyle, TextDecorations.Underline };
            object[] cls = { FontWeights.Normal, FontStyles.Normal, null };
            box.Selection.ApplyPropertyValue(dps[p], box.Selection.GetPropertyValue(dps[p]).Equals(obs[p]) ? cls[p] : obs[p]);
        }
        public static Label ListNo(string content) => new Label { Style = GetStyle("No1"), Content = content };
        public static Label ListNo2(string content) => new Label { Style = GetStyle("No2"), Content = content };
        public static Label Caption(string content) => new Label { Style = GetStyle("ListCaptions"), Content = content };
        public static TextBox UsualBox(string text) => new TextBox { Style = GetStyle("RegularBox"), Text = text };
        public static TextBox HoursBox(string text) => new TextBox { Style = GetStyle("HoursBox"), Text = text };
        public static Button DropButton(Grid grid) => new Button { Style = GetStyle("DeleteButton"), Tag = grid };

        public static Paragraph FromTag(Grid grid) => grid.Tag as Paragraph;
    }
}
