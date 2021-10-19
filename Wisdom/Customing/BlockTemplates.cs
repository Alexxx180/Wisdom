using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using static Wisdom.Customing.ResourceHelper;
using static Wisdom.Customing.Converters;
using static Wisdom.Customing.Decorators;
using System.Windows.Media;

namespace Wisdom.Customing
{
    public static class BlockTemplates
    {
        public static Grid GridItem(int rows = 0)
        {
            Grid grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.05, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.15, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.7, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.1, GridUnitType.Star) });
            AddRows(grid, rows);
            return grid;
        }
        public static Grid GridItem2(int rows = 0)
        {
            Grid grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.05, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.35, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.5, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.1, GridUnitType.Star) });
            AddRows(grid, rows);
            return grid;
        }
        public static Grid GridItem3(int rows = 0)
        {
            Grid grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.05, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.15, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.3, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.5, GridUnitType.Star) });
            AddRows(grid, rows);
            return grid;
        }
        public static Grid GridItem4(int rows = 0)
        {
            Grid grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.05, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.15, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.6, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.1, GridUnitType.Star) });
            AddRows(grid, rows);
            return grid;
        }
        public static Grid GridItem5(int rows = 0)
        {
            Grid grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.05, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.125, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.075, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.65, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.1, GridUnitType.Star) });
            AddRows(grid, rows);
            return grid;
        }
        public static Grid GridItem6(int rows = 0)
        {
            Grid grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.05, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.95, GridUnitType.Star) });
            AddRows(grid, rows);
            return grid;
        }
        public static Grid GridItem7(int rows = 0)
        {
            Grid grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.05, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.15, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.475, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.085, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.19, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.05, GridUnitType.Star) });
            AddRows(grid, rows);
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
        public static void SetRow(FrameworkElement element, int value)
        {
            SetProp(element, Grid.RowProperty, value);
        }
        public static void SetRowX(int value, params Control[] elements)
        {
            SetPropX(Grid.RowProperty, value, elements);
        }
        public static void SetCol(FrameworkElement element, int value)
        {
            SetProp(element, Grid.ColumnProperty, value);
        }
        public static void SetColX(int[] value, params Control[] elements)
        {
            SetPropX(Grid.ColumnProperty, value, elements);
        }
        public static void SetColX2(int startColumn, params Control[] elements)
        {
            for (byte i = 0; i < elements.Length; i++)
            {
                int column = startColumn + i;
                SetProp(elements[i], Grid.RowProperty, column);
            }
        }
        public static void SetColSpanX(int startValue, params FrameworkElement[] elements)
        {
            for (byte i = 0; i < elements.Length; i++)
            {
                int value = startValue + i;
                SetProp(elements[i], Grid.ColumnSpanProperty, value);
            }
        }
        public static void SetColSpanX(int value, params Control[] elements)
        {
            SetPropX(Grid.ColumnSpanProperty, value, elements);
        }
        public static void SetRowSpan(FrameworkElement element, int value)
        {
            SetProp(element, Grid.RowSpanProperty, value);
        }
        public static void SetColSpan(FrameworkElement element, int value)
        {
            SetProp(element, Grid.ColumnSpanProperty, value);
        }
        public static void SetSpans(FrameworkElement element, int row, int column)
        {
            SetRowSpan(element, row);
            SetColSpan(element, column);
        }
        public static void MenuItemTemplating(MenuItem item, RichTextBox box)
        {
            DependencyProperty[] dps = new DependencyProperty[] { TextElement.FontWeightProperty, TextElement.FontStyleProperty, TextBlock.TextDecorationsProperty };
            int p = Ints(item.Tag);
            object[] obs = { item.FontWeight, item.FontStyle, TextDecorations.Underline };
            object[] cls = { FontWeights.Normal, FontStyles.Normal, null };
            box.Selection.ApplyPropertyValue(dps[p], box.Selection.GetPropertyValue(dps[p]).Equals(obs[p]) ? cls[p] : obs[p]);
        }

        public static Grid NextCompetetion(string prefix, out Button add)
        {
            Grid subGrid = GridItem5();
            add = AddButton();
            Label no = ListNo($"{prefix}1");
            TextBox level = UsualBox("");
            GridAddX2(subGrid, 0, add, no, level);
            SetColSpan(level, 3);
            return subGrid;
        }

        public static Label ListNo(string content) => new Label { Style = GetStyle("No1"), Content = content };
        public static Label ListNo2(string content) => new Label { Style = GetStyle("No2"), Content = content };
        public static Label Caption(string content) => new Label { Style = GetStyle("ListCaptions"), Content = content };
        public static Label Section(string content) => new Label { Style = GetStyle("RegularSections"), Content = content };

        public static TextBox SubCaptionBox(string text) => new TextBox { Style = GetStyle("SubCaptionBox"), Text = text };
        public static TextBox UsualBox(string text) => new TextBox { Style = GetStyle("RegularBox"), Text = text };
        public static TextBox HoursBox(string text) => new TextBox { Style = GetStyle("HoursBox"), Text = text };

        public static CheckBox UsualCheckBox(string content) => new CheckBox { Style = GetStyle("RegularCheckBox"), Content = content };

        public static ComboBox HoursCombo(string text, bool edit) => new ComboBox { Style = GetStyle("HoursBox"), Text = text, IsEditable = edit };
        public static ComboBox TasksCombo() => new ComboBox { Style = GetStyle("SubCaptionBox"), ItemContainerStyle = GetStyle("ItemsBox") };

        public static Button DropButton() => new Button { Style = GetStyle("DeleteButton") };
        public static Button DropButton(Grid grid) => new Button { Style = GetStyle("DeleteButton"), Tag = grid };
        public static Button AddButton() => new Button { Style = GetStyle("AddButton") };
        public static Button AddButton(Grid grid) => new Button { Style = GetStyle("AddButton"), Tag = grid };

        public static Border SolidBorder(SolidColorBrush backColor) => new Border { Background = backColor };

        public static Paragraph FromTag(Grid grid) => grid.Tag as Paragraph;
        public static List ListFromTag(Grid grid) => grid.Tag as List;
        public static TableRowGroup RowGroupFromTag(StackPanel stack) => stack.Tag as TableRowGroup;
        public static Section SectionFromTag(Grid grid) => grid.Tag as Section;

        public static Table UsualTable() => new Table { Style = GetStyle("RegularTable") };
        public static TableCell UsualTableCell() => new TableCell { Style = GetStyle("RegularCells") };
        public static TableCell UsualTableCell(Paragraph paragraph) => new TableCell { Style = GetStyle("RegularCells"), Blocks = { paragraph } };
        public static TableCell Span2TableCell() => new TableCell { Style = GetStyle("RegularCells"), ColumnSpan = 2 };
        public static TableCell Span2TableCell(params Block[] blocks)
        {
            TableCell cell = new TableCell { Style = GetStyle("RegularCells"), ColumnSpan = 2 };
            cell.Blocks.AddRange(blocks);
            return cell;
        }
        public static SolidColorBrush Yellow = new SolidColorBrush(Color.FromRgb(238, 235, 182));
        public static SolidColorBrush Blue = new SolidColorBrush(Color.FromRgb(3, 198, 255));

    }
}
