using System.Windows.Controls;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using static Wisdom.Customing.Converters;
using static Wisdom.Customing.BlockTemplates;
using static Wisdom.Customing.ResourceHelper;
using static Wisdom.Customing.Decorators;
using static Wisdom.Binds.EasyBindings;
using Wisdom.Binds;
using System.IO;
using System.Text;
using System.Xml;
using System.Windows.Markup;
using System;
using System.Media;
using System.Windows.Media;

namespace Wisdom.Writers
{
    public static class Content
    {
        public static Button TextContent(Button btn, Button delete)
        {
            Grid next = btn.Parent as Grid;
            StackPanel levels = next.Parent as StackPanel;
            Grid grid = GridItem3();
            Paragraph p = next.Tag as Paragraph;
            delete = new Button { Style = GetStyle("DeleteButton"), Tag = grid };
            Label no = new Label { Style = GetStyle("No1"), Content = levels.Children.Count + "." };
            TextBox name = new TextBox { Text = ((TextBox)next.Children[2]).Text, Style = GetStyle("RegularBox") };
            TextBox hours = new TextBox { Text = ((TextBox)next.Children[3]).Text, Style = GetStyle("HoursBox") };
            Run run2 = new Run();
            _ = SetBind(run2, Run.TextProperty, Multi(new LevelsConverter(), FastBind(no, "Content"), FastBind(name, "Text"), FastBind(hours, "Text")));
            p.Inlines.Add(run2);
            GridAddX(grid, delete, no, name, hours);
            SetPropX(Grid.ColumnProperty, new object[] { 1, 2, 3 }, new Control[] { no, name, hours });
            grid.Tag = run2;
            levels.Children.Remove(next);
            levels.Children.Add(grid);
            int id = levels.Children.Count + 1;
            ((Label)next.Children[1]).Content = $"{id}.";
            levels.Children.Add(next);
            return delete;
        }
        public static Button TableContent(Button btn, Button delete)
        {
            Grid grid = btn.Parent as Grid;
            Label lab = new Label { Content = Lab(grid, 1).Content, Style = GetStyle("No2") };
            TextBox txt1 = new TextBox { Text = Box(grid, 2).Text, Style = GetStyle("RegularBox") };
            TextBox txt2 = new TextBox { Text = Box(grid, 3).Text, Style = GetStyle("HoursBox") };

            TableCell no = new TableCell { Style = GetStyle("RegularCells"), Blocks = { Text(lab) } };
            TableCell name = new TableCell { Style = GetStyle("RegularCells"), Blocks = { Text(txt1) } };
            TableCell hours = new TableCell { Style = GetStyle("RegularCells"), Blocks = { Text(txt2) } };
            TableRow row = new TableRow { Cells = { no, name, hours } };

            TableRowGroup grp = ((StackPanel)grid.Parent).Tag as TableRowGroup;
            Grid grid2 = GridItem();

            delete = new Button { Style = GetStyle("DeleteButton"), Tag = grid2 };

            grid2.Tag = row;
            GridAddX(grid2, delete, lab, txt1, txt2);
            SetPropX(Grid.ColumnProperty, new object[] { 1, 2, 3 }, new Control[] { lab, txt1, txt2 });
            StackPanel panel = grid.Parent as StackPanel;
            panel.Children.Remove(grid);
            panel.Children.Add(grid2);
            int id = panel.Children.Count + 1;
            ((Label)grid.Children[1]).Content = $"{id}.";
            panel.Children.Add(grid);
            grp.Rows.Add(row);
            return delete;
        }
        private static void TableSingleContent(Grid grid, StackPanel panel, ComboBox cbx, out TextBox hoursBox, out Button delete)
        {
            Label lab = new Label { Content = cbx.Text, Style = GetStyle("No2") };
            Grid grid2 = GridItem2();
            delete = new Button { Style = GetStyle("DeleteButton"), Tag = grid2 };
            TextBox txt1 = new TextBox { Style = GetStyle("RegularBox"), Text = "«»" };
            hoursBox = new TextBox { Style = GetStyle("HoursBox") };
            MultiBinding multi = Multi(new SectionsConverter(), FastBind(lab, "Content"), FastBind(txt1, "Text"));
            Binding bind3 = FastBind(hoursBox, "Text");
            GridAddX(grid2, delete, lab, txt1, hoursBox);
            TableCell name = new TableCell { Style = GetStyle("RegularCells"), Blocks = { Text(multi) } };
            TableCell hours = new TableCell
            {
                Style = GetStyle("RegularCells"),
                Blocks = { new Paragraph() { Style = GetStyle("RegularParagraph"),
                    Inlines = { SetBind(new Run(), Run.TextProperty, bind3) as Run }, TextAlignment = TextAlignment.Center } }
            };
            lab.SetValue(Grid.ColumnProperty, 1);
            txt1.SetValue(Grid.ColumnProperty, 2);
            hoursBox.SetValue(Grid.ColumnProperty, 3);

            TableRow row = new TableRow { Cells = { name, hours } };
            grid2.Tag = row;

            panel.Children.Remove(grid);
            panel.Children.Add(grid2);
            panel.Children.Add(grid);
            TableRowGroup grp = ((StackPanel)grid.Parent).Tag as TableRowGroup;
            grp.Rows.Add(row);
        }
        private static void TableGroupContent(Grid grid, ref StackPanel panel, ComboBox cbx, out TextBox hours, out Button delete, ref Button add)
        {
            Label no = new Label { Content = "№", Style = GetStyle("ListCaptions") };
            Label descp = new Label { Content = "Описание", Style = GetStyle("ListCaptions") };
            Label lab = new Label { Content = cbx.Text, Style = GetStyle("RegularSections") };
            Grid grid2 = GridItem();
            Grid sgrid = GridItem();
            AddRows(sgrid, 3);
            delete = new Button { Style = GetStyle("DeleteButton"), Tag = sgrid };
            GridAddX(sgrid, lab, delete, no, descp);
            SetPropX(Grid.ColumnProperty, new object[] { 1, 1, 2 }, new Control[] { lab, no, descp });
            SetPropX(Grid.RowProperty, 1, new Control[] { descp, no });
            SetPropX(Grid.ColumnSpanProperty, 2, new Control[] { descp, lab });

            Run run = new Run(cbx.Text);
            Paragraph p = new Paragraph { Style = GetStyle("RegularParagraph"), Inlines = { run } };
            Table table = new Table { Style = GetStyle("RegularTable") };
            AddTCols(table, 0.048, 0.8, 0.152);

            TableCell cell = new TableCell { Style = GetStyle("RegularCells"), Blocks = { p, table }, ColumnSpan = 2 };
            TableRow tableRow = new TableRow();
            TableRowGroup grp2 = new TableRowGroup { Rows = { tableRow } };
            table.RowGroups.Add(grp2);

            TableRowGroup grp = panel.Tag as TableRowGroup;
            TableRow row = new TableRow { Cells = { cell } };
            grp.Rows.Add(row);
            grid2.Tag = tableRow;

            sgrid.Tag = row;
            StackPanel stackPanel = new StackPanel { Tag = grp2 };
            Label autoNo = new Label { Content = "1", Style = GetStyle("No2") };
            TextBox name = new TextBox { Style = GetStyle("RegularBox") };
            hours = new TextBox { Style = GetStyle("HoursBox") };

            MultiBinding multi = Multi(new SectionsConverter(), FastBind(lab, "Content"), FastBind(name, "Text"));
            Binding bind3 = FastBind(hours, "Text");
            SetBind(new Run(), Run.TextProperty, multi);
            SetBind(new Run(), Run.TextProperty, bind3);
            add = new Button { Style = GetStyle("AddButton"), Tag = grid2 };
            GridAddX(grid2, add, autoNo, name, hours);
            SetPropX(Grid.ColumnProperty, new object[] { 1, 2, 3 }, new Control[] { autoNo, name, hours });
            
            stackPanel.Children.Add(grid2);

            sgrid.Children.Add(stackPanel);
            stackPanel.SetValue(Grid.RowProperty, 2);
            stackPanel.SetValue(Grid.ColumnSpanProperty, 4);
            panel.Children.Remove(grid);
            panel.Children.Add(sgrid);
            panel.Children.Add(grid);
        }

        public static void AutoDetectContentType(Button btn, out TextBox hours, out Button delete, ref Button add)
        {
            Grid grid = btn.Parent as Grid;
            StackPanel panel = grid.Parent as StackPanel;
            ComboBox cbx = Cbx(grid, 1);
            CheckBox chx = Chx(grid, 2);
            if (chx.IsChecked.Value)
                TableGroupContent(grid, ref panel, cbx, out hours, out delete, ref add);
            else
                TableSingleContent(grid, panel, cbx, out hours, out delete);
        }
        public static void RemoveRun(object value)
        {
            Run run = value as Run;
            Paragraph prg = run.Parent as Paragraph;
            prg.Inlines.Remove(run);
        }
        public static void RemoveTableRow(object value)
        {
            TableRow row = value as TableRow;
            TableRowGroup rgr = row.Parent as TableRowGroup;
            rgr.Rows.Remove(row);
        }
        public static StackPanel RemoveGrid(FrameworkElement element)
        {
            StackPanel grandGrid = element.Parent as StackPanel;
            grandGrid.Children.Remove(element);
            return grandGrid;
        }
        public static void AutoIndexing(StackPanel grandGrid, int pos, char mark, string prefix)
        {
            for (int no = 0; no < grandGrid.Children.Count; no++)
                ((grandGrid.Children[no] as Grid).Children[pos] as Label).Content = $"{prefix}{no + 1}{mark}";
        }
        public static void AutoIndexing(StackPanel grandGrid, int pos, char mark)
        {
            for (int no = 0; no < grandGrid.Children.Count; no++)
                ((grandGrid.Children[no] as Grid).Children[pos] as Label).Content = $"{no + 1}{mark}";
        }
        public static void AutoIndexing(StackPanel grandGrid, int pos)
        {
            for (int no = 0; no < grandGrid.Children.Count; no++)
                ((grandGrid.Children[no] as Grid).Children[pos] as Label).Content = $"{no + 1}";
        }
        public static Section BoXaml(RichTextBox box)
        {
            StringReader stringReader = new StringReader(XamlText(box));
            XmlReader xmlReader = XmlReader.Create(stringReader);
            return XamlReader.Load(xmlReader) as Section;
        }
        private static string XamlText(RichTextBox box)
        {
            TextRange range = new TextRange(box.Document.ContentStart, box.Document.ContentEnd);
            MemoryStream stream = new MemoryStream();
            range.Save(stream, DataFormats.Xaml);
            return Encoding.UTF8.GetString(stream.ToArray());
        }
        public static void ListResetMethod(Button btn)
        {
            RichTextBox txt = btn.Tag as RichTextBox;
            List list = new List(new ListItem());
            txt.Document.Blocks.Clear();
            txt.Document.Blocks.Add(list);
        }
        public static void NumbersBox(Button btn, int defaultValue)
        {
            StackPanel stp = btn.Parent as StackPanel;
            TextBox box = stp.Tag as TextBox;
            int p = Ints(btn.Tag.ToString());
            if (box.Text == "")
            {
                box.Text = defaultValue.ToString();
                return;
            }
            int i = Ints(box.Text) + p;
            box.Text = i > 0 ? (i < 999 ? i.ToString() : defaultValue.ToString()) : "999";
        }
        public static void DeleteSection(Grid parent)
        {
            TableRow row = parent.Tag as TableRow;
            TableRowGroup grp = row.Parent as TableRowGroup;
            grp.Rows.Remove(row);
            //throw new Exception("SUCCESS");
            StackPanel panel = parent.Parent as StackPanel;
            panel.Children.Remove(parent);
        }
        /*
         <Grid>
        (TableRow)
            <Grid Tag="{x:Reference Name=Topic1}">
        
                (TableRow)
                    <Grid Tag="{x:Reference Name=ThemeContents}">
                        
                        <StackPanel Tag="{x:Reference Name=EduContents}">
                    
                    <Grid>

                        
                    </Grid>
                


        </Grid>

        <TableRow x:Name="Topic1">
            <TableCell BorderBrush="Black" BorderThickness="0.5">
                <Paragraph FontFamily="Times New Roman" FontSize="14pt" TextAlignment="Center">
                    <Run FontWeight="Bold">
                        <Run.Resources>
                            <bind:SectionsConverter x:Key="SectionsConverter" />
                        </Run.Resources>
                        <Run.Text>
                            <MultiBinding Converter="{StaticResource SectionsConverter}">
                                <Binding Path="Content" ElementName="SectionNo" />
                                <Binding Path="Text" ElementName="SectionName" />
                            </MultiBinding>
                        </Run.Text>
                    </Run>
                </Paragraph>
            </TableCell>
            <TableCell BorderBrush="Black" BorderThickness="0.5">
            </TableCell>
            <TableCell BorderBrush="Black" BorderThickness="0.5">
                <Paragraph FontFamily="Times New Roman" FontSize="14pt" TextAlignment="Center">
                    <Run FontWeight="Bold" Text="{Binding ElementName=SectionHours, Path=Text}">
                    </Run>
                </Paragraph>
            </TableCell>
            <TableCell BorderBrush="Black" BorderThickness="0.5">
            </TableCell>
        </TableRow>
        <TableRow x:Name="Theme1">
            <TableCell BorderBrush="Black" BorderThickness="0.5">
                <Paragraph FontFamily="Times New Roman" FontSize="14pt" TextAlignment="Center">
                    <Run FontWeight="Bold">
                        <Run.Resources>
                            <bind:SectionsConverter x:Key="SectionsConverter" />
                        </Run.Resources>
                        <Run.Text>
                            <MultiBinding Converter="{StaticResource SectionsConverter}">
                                <Binding Path="Content" ElementName="ThemeNo" />
                                <Binding Path="Text" ElementName="ThemeName" />
                            </MultiBinding>
                        </Run.Text>
                    </Run>
                </Paragraph>
            </TableCell>
            <TableCell BorderBrush="Black" BorderThickness="0.5" ColumnSpan="2">
                <Table BorderBrush="Black" BorderThickness="0.5" CellSpacing="0" Margin="0" Padding="0">
                    <Table.Columns>
                        <TableColumn Width="0.848*"></TableColumn>
                        <TableColumn Width="0.152*"></TableColumn>
                    </Table.Columns>
                    <TableRowGroup x:Name="ThemeContents">
                        <TableRow>
                            <TableCell BorderBrush="Black" BorderThickness="0.5">
                                <Paragraph FontSize="14pt" FontFamily="Times New Roman">
                                    <Run Text="Содержание учебного материала"></Run>
                                </Paragraph>
                            </TableCell>
                            <TableCell BorderBrush="Black" BorderThickness="0.5">
                                                                    
                            </TableCell>
                        </TableRow>
                        <TableRow>
                            <TableCell BorderBrush="Black" BorderThickness="0.5"  ColumnSpan="2">
                                <Table BorderBrush="Black" BorderThickness="0.5" CellSpacing="0" Margin="0" Padding="0">
                                    <Table.Columns>
                                        <TableColumn Width="0.048*"></TableColumn>
                                        <TableColumn Width="0.8*"></TableColumn>
                                        <TableColumn Width="0.152*"></TableColumn>
                                    </Table.Columns>
                                    <TableRowGroup x:Name="EduContents"></TableRowGroup>
                                </Table>
                            </TableCell>
                        </TableRow>
                    </TableRowGroup>
                </Table>
            </TableCell>
            <TableCell BorderBrush="Black" BorderThickness="0.5">
                <Paragraph FontFamily="Times New Roman" FontSize="14pt" TextAlignment="Center">
                    <Run FontWeight="Bold" Text="{Binding ElementName=ThemeLevel, Path=Text}">
                    </Run>
                </Paragraph>
            </TableCell>
        </TableRow>
         */
        public static void NewTopic(out Button BTbutton, out Button Cadd, out Button NewTypeAdd)
        {
            Grid mainGrid = GridItem();
            AddRows(mainGrid, 2);
            BTbutton = new Button { Style = GetStyle("DeleteButton") };
            Label themeNo = new Label { Content = "Тема 1.1.", Style = GetStyle("CaptionSections") };
            TextBox themeName = new TextBox { Text = "", Style = GetStyle("SubCaptionBox") };
            TextBox themeLevel = new TextBox { Text = "2", Style = GetStyle("HoursBox") };
            StackPanel themes = new StackPanel { Background = new SolidColorBrush(Color.FromRgb(238, 235, 182)) }; //"#FFEEEBB6"
            GridAddX(mainGrid, BTbutton, themeNo, themeName, themeLevel, themes);
            SetPropX(Grid.ColumnProperty, new object[] { 1, 2, 3 }, new Control[] { themeNo, themeName, themeLevel });
            SetPropX(new DependencyProperty[] { Grid.RowProperty, Grid.ColumnProperty, Grid.ColumnSpanProperty },
                new object[] { 1, 0, 5 }, themes);

            Grid content = GridItem();
            AddRows(mainGrid, 3);
            Label title = new Label { Content = "Содержание учебного материала", Style = GetStyle("RegularSections") };
            Label listCaption1 = new Label { Content = "№", Style = GetStyle("ListCaptions") };
            Label listCaption2 = new Label { Content = "Описание", Style = GetStyle("ListCaptions") };
            Label listCaption3 = new Label { Content = "Часы", Style = GetStyle("ListCaptions") };
            StackPanel themeContent = new StackPanel();
            GridAddX(content, title, listCaption1, listCaption2, listCaption3, themeContent);
            SetPropX(Grid.ColumnProperty, new object[] { 1, 2, 3 }, new Control[] { listCaption1, listCaption2, listCaption3 });
            SetPropX(Grid.RowProperty, 1, new Control[] { listCaption1, listCaption2, listCaption3 });
            SetPropX(new DependencyProperty[] { Grid.RowProperty, Grid.ColumnProperty, Grid.ColumnSpanProperty },
                new object[] { 1, 0, 5 }, themeContent);
            themes.Children.Add(content);

            Grid levelContent = GridItem();
            Cadd = new Button { Style = GetStyle("AddButton") };
            Label levelNo = new Label { Style = GetStyle("No2") };
            TextBox levelName = new TextBox { Style = GetStyle("RegularBox") };
            TextBox levelHours = new TextBox { Style = GetStyle("HoursBox") };
            GridAddX(levelContent, Cadd, levelNo, levelName, levelHours);
            SetPropX(Grid.ColumnProperty, new object[] { 1, 2, 3 }, new Control[] { levelNo, levelName, levelHours });
            themeContent.Children.Add(levelContent);

            Grid newTypeContent = GridItem();
            NewTypeAdd = new Button { Style = GetStyle("AddButton") };
            ComboBox NewType = new ComboBox { Style = GetStyle("SubCaptionBox"), ItemContainerStyle = GetStyle("ItemsBox") };
            AddItems(NewType, "Практические занятия", "Контрольная работа", "Самостоятельная работа");
            CheckBox MultiValue = new CheckBox { Content = " >1", Style = GetStyle("RegularCheckBox") };
            GridAddX(newTypeContent, NewTypeAdd, NewType, MultiValue);
            SetPropX(Grid.RowProperty, 3, new Control[] { NewTypeAdd, NewType, MultiValue });
            SetPropX(Grid.ColumnProperty, new object[] { 1, 3 }, new Control[] { NewType, MultiValue });
            SetProp(NewType, Grid.ColumnSpanProperty, 2);
            themes.Children.Add(newTypeContent);
        }

    }
}
