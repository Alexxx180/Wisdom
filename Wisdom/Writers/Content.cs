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
        public static Button TextContent2(Button btn, Button delete)
        {
            Grid next = btn.Parent as Grid;
            StackPanel levels = next.Parent as StackPanel;
            Grid grid = GridItem3();
            Paragraph p = (levels.Parent as Grid).Tag as Paragraph;

            delete = new Button { Style = GetStyle("DeleteButton"), Tag = grid };
            Label no = new Label { Style = GetStyle("No1"), Content = levels.Children.Count + "." };
            TextBox name = new TextBox { Text = ((TextBox)next.Children[2]).Text, Style = GetStyle("RegularBox") };
            Run run2 = new Run();
            _ = SetBind(run2, Run.TextProperty, Multi(new SectionsConverter(), FastBind(no, "Content"), FastBind(name, "Text")));
            LineBreak lb = new LineBreak();
            p.Inlines.Add(lb);
            run2.Tag = lb;
            p.Inlines.Add(run2);
            GridAddX(grid, delete, no, name);
            grid.Tag = run2;
            SetPropX(Grid.ColumnProperty, new object[] { 1, 2 }, new Control[] { no, name });
            SetProp(name, Grid.ColumnSpanProperty, 3);

            levels.Children.Remove(next);
            levels.Children.Add(grid);
            int id = levels.Children.Count + 1;
            (next.Children[1] as Label).Content = $"{id}.";
            levels.Children.Add(next);
            return delete;
        }
        public static Button TextContent3(Button btn, Button delete)
        {
            Grid next = btn.Parent as Grid;
            StackPanel levels = next.Parent as StackPanel;
            Grid grid = GridItem3();
            List p = (levels.Parent as Grid).Tag as List;

            delete = new Button { Style = GetStyle("DeleteButton"), Tag = grid };
            Label no = new Label { Style = GetStyle("No1"), Content = levels.Children.Count + "." };
            TextBox name = new TextBox { Text = ((TextBox)next.Children[2]).Text, Style = GetStyle("RegularBox") };

            ListItem litems = new ListItem();
            Run run2 = new Run();
            _ = SetBind(run2, Run.TextProperty, FastBind(name, "Text"));
            ListItem litem = new ListItem();
            
            litems.Blocks.Add(new Paragraph(run2) { Style = GetStyle("RegularParagraph") });
            p.ListItems.Add(litems);

            if (levels.Tag != null)
            {
                List p2 = levels.Tag as List;
                Run run = new Run();
                _ = SetBind(run, Run.TextProperty, FastBind(name, "Text"));
                litem.Blocks.Add(new Paragraph(run) { Style = GetStyle("RegularParagraph") });
                p2.ListItems.Add(litem);
            }

            GridAddX(grid, delete, no, name);
            litems.Tag = litem;
            grid.Tag = litems;
            SetPropX(Grid.ColumnProperty, new object[] { 1, 2 }, new Control[] { no, name });
            SetProp(name, Grid.ColumnSpanProperty, 3);

            levels.Children.Remove(next);
            _ = levels.Children.Add(grid);
            int id = levels.Children.Count + 1;
            (next.Children[1] as Label).Content = $"{id}.";
            _ = levels.Children.Add(next);
            return delete;
        }
        public static void ParagraphText(Button btn, out Button delete, out Button add)
        {
            Grid next = btn.Parent as Grid;
            StackPanel levels = next.Parent as StackPanel;
            string title = (next.Children[1] as ComboBox).Text;
            Paragraph p = TextB(title + ":");
            Section sources = next.Tag as Section;

            sources.Blocks.Add(p);

            Grid grid = GridItem();
            AddRows(grid, 2);
            delete = new Button { Style = GetStyle("DeleteButton"), Tag = grid };
            Label no = new Label { Style = GetStyle("ListCaptions"), Content = title };

            StackPanel stack = new StackPanel();
            
            Grid subGrid = GridItem();
            add = new Button { Style = GetStyle("AddButton"), Tag = grid };
            Label no1 = new Label { Style = GetStyle("No1"), Content = "1." };
            TextBox level = new TextBox { Style = GetStyle("RegularBox"), Text = "" };
            stack.Children.Add(subGrid);

            GridAddX(subGrid, add, no1, level);
            GridAddX(grid, delete, no, stack);
            SetPropX(Grid.ColumnProperty, new object[] { 1, 1, 2 }, new Control[] { no, no1, level });
            SetProp(no, Grid.ColumnSpanProperty, 3);
            SetProp(level, Grid.ColumnSpanProperty, 2);
            SetProp(stack, Grid.ColumnSpanProperty, 4);
            SetProp(stack, Grid.RowProperty, 1);
            grid.Tag = p;

            levels.Children.Remove(next);
            _ = levels.Children.Add(grid);
            _ = levels.Children.Add(next);
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
            _ = panel.Children.Add(grid);
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
            _ = panel.Children.Add(grid2);
            _ = panel.Children.Add(grid);
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
        public static void RemoveParagraph(object value)
        {
            Paragraph prg = value as Paragraph;
            Section sct = prg.Parent as Section;
            _ = sct.Blocks.Remove(prg);
        }
        public static void RemoveRun(object value)
        {
            Run run = value as Run;
            Paragraph prg = run.Parent as Paragraph;
            _ = prg.Inlines.Remove(run);
        }
        public static void RemoveRunLB(object value)
        {
            Run run = value as Run;
            Paragraph prg = run.Parent as Paragraph;
            _ = prg.Inlines.Remove(run);
            _ = prg.Inlines.Remove(run.Tag as LineBreak);
        }
        public static void RemoveListItem(object value)
        {
            ListItem item = value as ListItem;
            List list = item.Parent as List;
            _ = list.ListItems.Remove(item);
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
        /*public static void AutoIndexingI1(StackPanel grandGrid, int pos, char mark, string prefix)
        {
            for (int no = 0; no < grandGrid.Children.Count; no++)
                ((grandGrid.Children[no] as Grid).Children[pos] as Label).Content = $"{prefix}{no + 1}{mark}";
        }*/
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
        public static void NewTopic(TableRowGroup mainBinding, StackPanel master, out Button BTbutton, out Button Cadd, out Button NewTypeAdd, out Button deleteOmni, out Button addNew, out TextBox newHours, string name, string hours)
        {
            int cnt = master.Children.Count;
            //Topic
            Grid omniGrid = GridItem();
            AddRows(omniGrid, 2);
            deleteOmni = new Button { Style = GetStyle("DeleteButton") };
            Label topicNo = new Label { Content = $"Раздел {cnt}.", Style = GetStyle("CaptionSections") };
            TextBox topicName = new TextBox { FontWeight = FontWeights.Bold, Text=name, Style = GetStyle("RegularBox") };
            TextBox topicHours = new TextBox { FontWeight = FontWeights.Bold, Text=hours, Style = GetStyle("HoursBox") };
            StackPanel Themes = new StackPanel { Background = new SolidColorBrush(Color.FromRgb(238, 235, 182)) };
            GridAddX(omniGrid, deleteOmni, topicNo, topicName, topicHours, Themes);
            SetPropX(Grid.ColumnProperty, new object[] { 1, 2, 3 }, new Control[] { topicNo, topicName, topicHours });
            SetPropX(new DependencyProperty[] { Grid.RowProperty, Grid.ColumnProperty, Grid.ColumnSpanProperty },
                new object[] { 1, 0, 5 }, Themes);
            Grid addTopic = master.Children[cnt - 1] as Grid;
            (addTopic.Children[1] as Label).Content = $"Раздел {cnt+1}.";
            master.Children.Remove(addTopic);
            master.Children.Add(omniGrid);
            master.Children.Add(addTopic);

            MultiBinding multi = Multi(new SectionsConverter(), FastBind(topicNo, "Content"), FastBind(topicName, "Text"));
            Binding bindHours = FastBind(topicHours, "Text");
            TableRow newTopicRow = new TableRow();
            TableCell topicNameCell = new TableCell { Style = GetStyle("RegularCells"), Blocks = { TextCB(multi) } };
            TableCell emptyCell = new TableCell { Style = GetStyle("RegularCells") };
            TableCell topicHoursCell = new TableCell { Style = GetStyle("RegularCells"), Blocks = { TextCB(bindHours) } };
            TableCell emptyCell2 = new TableCell { Style = GetStyle("RegularCells") };
            AddRCells(newTopicRow, topicNameCell, emptyCell, topicHoursCell, emptyCell2);
            omniGrid.Tag = newTopicRow;
            mainBinding.Rows.Add(newTopicRow);
            deleteOmni.Tag = Themes;
            NewTheme(cnt, Themes, mainBinding, out BTbutton, out Cadd, out NewTypeAdd);

            Grid AddThemeGrid = GridItem();
            addNew = new Button { Style = GetStyle("AddButton") };
            Label newTitle = new Label { Content = $"Тема {cnt}.2.", Style = GetStyle("CaptionSections") };
            TextBox newName = new TextBox { Style = GetStyle("RegularBox") };
            newHours = new TextBox { Style = GetStyle("HoursBox") };
            GridAddX(AddThemeGrid, addNew, newTitle, newName, newHours);
            SetPropX(Grid.ColumnProperty, new object[] { 1, 2, 3 }, new Control[] { newTitle, newName, newHours });
            Themes.Children.Add(AddThemeGrid);
        }

        public static void NewTheme(int cnt, StackPanel Themes, TableRowGroup mainBinding, out Button BTbutton, out Button Cadd, out Button NewTypeAdd)
        {
            NewTheme($"Тема {cnt}.1.", Themes, mainBinding, out BTbutton, out Cadd, out NewTypeAdd, "", "");
        }

        public static void NewTheme(string themeTitle, StackPanel Themes, TableRowGroup mainBinding, out Button BTbutton, out Button Cadd, out Button NewTypeAdd, string themeNameVal, string themeLevelVal)
        {
            //Theme
            Grid mainGrid = GridItem();
            AddRows(mainGrid, 2);
            BTbutton = new Button { Style = GetStyle("DeleteButton") };
            Label themeNo = new Label { Content = themeTitle, Style = GetStyle("CaptionSections") };
            TextBox themeName = new TextBox { Text = themeNameVal, Style = GetStyle("SubCaptionBox") };
            TextBox themeLevel = new TextBox { Text = themeLevelVal, Style = GetStyle("HoursBox") };
            StackPanel themes = new StackPanel { Background = new SolidColorBrush(Color.FromRgb(238, 235, 182)) }; //"#FFEEEBB6"
            GridAddX(mainGrid, BTbutton, themeNo, themeName, themeLevel, themes);
            SetPropX(Grid.ColumnProperty, new object[] { 1, 2, 3 }, new Control[] { themeNo, themeName, themeLevel });
            SetPropX(new DependencyProperty[] { Grid.RowProperty, Grid.ColumnProperty, Grid.ColumnSpanProperty },
                new object[] { 1, 0, 5 }, themes);
            Themes.Children.Add(mainGrid);

            //ThemeContent
            Grid content = GridItem();
            AddRows(content, 3);
            Label title = new Label { Content = "Содержание учебного материала", Style = GetStyle("RegularSections") };
            Label listCaption1 = new Label { Content = "№", Style = GetStyle("ListCaptions") };
            Label listCaption2 = new Label { Content = "Описание", Style = GetStyle("ListCaptions") };
            Label listCaption3 = new Label { Content = "Часы", Style = GetStyle("ListCaptions") };
            StackPanel themeContent = new StackPanel();
            GridAddX(content, title, listCaption1, listCaption2, listCaption3, themeContent);
            SetPropX(Grid.ColumnProperty, new object[] { 1, 1, 2, 3 }, new Control[] { title, listCaption1, listCaption2, listCaption3 });
            SetPropX(Grid.RowProperty, 1, new Control[] { listCaption1, listCaption2, listCaption3 });
            SetProp(title, Grid.ColumnSpanProperty, 3);
            SetPropX(new DependencyProperty[] { Grid.RowProperty, Grid.ColumnProperty, Grid.ColumnSpanProperty },
                new object[] { 2, 0, 5 }, themeContent);
            themes.Children.Add(content);

            Grid levelContent = GridItem();
            Cadd = new Button { Style = GetStyle("AddButton") };
            Label levelNo = new Label { Style = GetStyle("No2"), Content = "1" };
            TextBox levelName = new TextBox { Style = GetStyle("RegularBox") };
            TextBox levelHours = new TextBox { Style = GetStyle("HoursBox") };
            GridAddX(levelContent, Cadd, levelNo, levelName, levelHours);
            SetPropX(Grid.ColumnProperty, new object[] { 1, 2, 3 }, new Control[] { levelNo, levelName, levelHours });
            themeContent.Children.Add(levelContent);

            MultiBinding multi2 = Multi(new SectionsConverter(), FastBind(themeNo, "Content"), FastBind(themeName, "Text"));
            Binding bindLevel = FastBind(themeLevel, "Text");
            TableRow newTheme = new TableRow();
            TableCell themeNameCell = new TableCell { Style = GetStyle("RegularCells"), Blocks = { TextCB(multi2) } };
            TableCell contentsCell = new TableCell { Style = GetStyle("RegularCells"), ColumnSpan = 2 };
            TableCell themeLevelCell = new TableCell { Style = GetStyle("RegularCells"), Blocks = { TextCenter(bindLevel) } };
            TableCell emptyCell3 = new TableCell { Style = GetStyle("RegularCells") };
            AddRCells(newTheme, themeNameCell, contentsCell, themeLevelCell);
            mainGrid.Tag = newTheme;
            mainBinding.Rows.Add(newTheme);

            Table educationCont = new Table { Style = GetStyle("RegularTable") };
            AddTCols(educationCont, 0.848, 0.152);
            TableRowGroup pureContent = new TableRowGroup();
            TableRow eduNameRow = new TableRow();
            TableCell eduName = new TableCell { Style = GetStyle("RegularCells"), Blocks = { Text("Содержание учебного материала") } };
            TableCell emptyCell4 = new TableCell { Style = GetStyle("RegularCells") };
            AddRCells(eduNameRow, eduName, emptyCell4);
            pureContent.Rows.Add(eduNameRow);
            educationCont.RowGroups.Add(pureContent);

            TableRow simpleRow = new TableRow();
            TableCell cellTable2 = new TableCell { Style = GetStyle("RegularCells"), ColumnSpan = 2 };
            AddRCells(simpleRow, cellTable2);
            Table educationCont2 = new Table { Style = GetStyle("RegularTable") };
            AddTCols(educationCont2, 0.048, 0.8, 0.152);
            cellTable2.Blocks.Add(educationCont2);
            TableRowGroup pureContent2 = new TableRowGroup();
            pureContent.Rows.Add(simpleRow);
            educationCont2.RowGroups.Add(pureContent2);

            themeContent.Tag = pureContent2;
            themes.Tag = pureContent;
            contentsCell.Blocks.Add(educationCont);

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
