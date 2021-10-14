﻿using System.Windows.Controls;
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
using System.Diagnostics;

namespace Wisdom.Writers
{
    public static class Content
    {
        private static int Restack(StackPanel stack, Grid toMove, Grid toAdd)
        {
            stack.Children.Remove(toMove);
            stack.Children.Add(toAdd);
            stack.Children.Add(toMove);
            return stack.Children.Count;
        }

        public static Button StudyLevel(Button addNext)
        {
            Grid next = Parent(addNext);
            StackPanel levels = Parent(next);

            Label nextNo = Lab(next, 1);
            TextBox nextName = Box(next, 2);
            TextBox nextHours = Box(next, 3);

            Grid grid = GridItem3();
            Button delete = DropButton(grid);
            Label no = ListNo(levels.Children.Count + ".");
            TextBox name = UsualBox(nextName.Text);
            TextBox hours = UsualBox(nextHours.Text);

            Paragraph studyLevels = FromTag(next);
            Run newStudyLevel = new Run();
            studyLevels.Inlines.Add(newStudyLevel);

            Binding bindNo = FastBind(no, "Content");
            Binding bindName = FastBind(name, "Text");
            Binding bindHours = FastBind(hours, "Text");
            _ = SetRunMultiBind(newStudyLevel, new LevelsConverter(),
                bindNo, bindName, bindHours);

            GridAddX2(grid, 0, delete, no, name, hours);
            grid.Tag = newStudyLevel;

            int count = Restack(levels, next, grid);
            nextNo.Content = $"{count}.";
            return delete;
        }

        public static Button TextContent2(Button addNext)
        {
            Grid next = Parent(addNext);
            StackPanel levels = Parent(next);
            Grid captionGrid = Parent(levels);

            Label nextNo = Lab(next, 1);
            TextBox nextName = Box(next, 2);

            Grid grid = GridItem3();
            Button delete = DropButton(grid);
            Label no = ListNo(levels.Children.Count + ".");
            TextBox name = UsualBox(nextName.Text);

            Paragraph sources = FromTag(captionGrid);
            Run source = new Run();
            LineBreak lineBreak = new LineBreak();
            sources.Inlines.Add(lineBreak);
            source.Tag = lineBreak;
            sources.Inlines.Add(source);

            Binding bindNo = FastBind(no, "Content");
            Binding bindName = FastBind(name, "Text");
            _ = SetRunMultiBind(source, new SectionsConverter(),
                bindNo, bindName);
            
            GridAddX2(grid, 0, delete, no, name);
            SetProp(name, Grid.ColumnSpanProperty, 3);
            grid.Tag = source;

            int count = Restack(levels, next, grid);
            nextNo.Content = $"{count}.";
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

        public static Button TextContent4(Button add)
        {
            Grid next = add.Parent as Grid;
            StackPanel levels = next.Parent as StackPanel;
            FrameworkElement[][] elements = new FrameworkElement[][] {
                new FrameworkElement[] { ListNo("Умения:"), UsualBox("") },
                new FrameworkElement[] { ListNo("Знания:"), UsualBox("") }
            };
            Grid grid = Competetions(GridItem5(), levels, next, out Button delete, 3, 1, "ОК", elements);

            levels.Children.Remove(next);
            _ = levels.Children.Add(grid);
            int id = levels.Children.Count + 1;
            (next.Children[1] as Label).Content = $"ОК {id / 10}{id % 10}";
            _ = levels.Children.Add(next);
            return delete;
        }

        public static Button TextContent5(Button add)
        {
            Grid next = add.Parent as Grid;
            StackPanel levels = next.Parent as StackPanel;
            Grid current = levels.Parent as Grid;
            Border border = current.Children[1] as Border;
            Label title = border.Child as Label;
            FrameworkElement[][] elements = new FrameworkElement[][] {
                new FrameworkElement[] { ListNo("Практический опыт:"), UsualBox("") },
                new FrameworkElement[] { ListNo("Умения:"), UsualBox("") },
                new FrameworkElement[] { ListNo("Знания:"), UsualBox("") }
            };
            string prefix = title.Content.ToString();
            Grid grid = Competetions2(GridItem5(), levels, next, out Button delete, 4, 1, prefix, elements);

            levels.Children.Remove(next);
            _ = levels.Children.Add(grid);
            int id = levels.Children.Count + 1;
            (next.Children[1] as Label).Content = $"{prefix}{id}";
            _ = levels.Children.Add(next);
            return delete;
        }
        public static Button NewProfessionalSection(Button add)
        {

            Grid next = add.Parent as Grid;
            StackPanel levels = next.Parent as StackPanel;
            FrameworkElement[][] elements = new FrameworkElement[][] {
                new FrameworkElement[] { ListNo("Практический опыт:"), UsualBox("") },
                new FrameworkElement[] { ListNo("Умения:"), UsualBox("") },
                new FrameworkElement[] { ListNo("Знания:"), UsualBox("") }
            };
            Grid grid = Competetions(GridItem5(), levels, next, out Button delete, 4, 1, "ПК", elements);

            levels.Children.Remove(next);
            _ = levels.Children.Add(grid);
            int id = levels.Children.Count + 1;
            (next.Children[1] as Label).Content = $"ПК {id}";
            _ = levels.Children.Add(next);
            return delete;
        }
        public static Grid ProfessionSection(string prefix, string no, out Button delete, out Button addComp)
        {
            Grid grid = GridItem6();
            AddRows(grid, 2);
            delete = new Button { Style = GetStyle("DeleteButton") };
            Border border = new Border { Background = new SolidColorBrush(Color.FromRgb(3, 198, 255)) };
            Label no1 = Caption($"{prefix}{no}.");
            border.Child = no1;
            StackPanel competetions = new StackPanel();
            competetions.Children.Add(CompetetionAddGrid($"{prefix} {no}.", out addComp));
            GridAddX2(grid, 0, delete, border);
            GridAdd(grid, competetions);
            SetProp(border, Grid.ColumnProperty, 2);
            SetProp(competetions, Grid.RowProperty, 1);
            SetProp(competetions, Grid.ColumnSpanProperty, 2);
            return grid;
        }
        public static Grid CompetetionAddGrid(string prefix, out Button add)
        {
            Grid subGrid = GridItem5();
            add = new Button { Style = GetStyle("AddButton") };
            Label no1 = ListNo($"{prefix}1");
            TextBox level = UsualBox("");
            GridAddX2(subGrid, 0, add, no1, level);
            SetProp(level, Grid.ColumnSpanProperty, 3);
            return subGrid;
        }
        private static Grid Competetions(Grid grid, StackPanel levels, Grid next, out Button delete, int rows, int startRow, string prefix, FrameworkElement[][] elements)
        {
            AddRows(grid, rows);
            TextBox competetionName = next.Children[2] as TextBox;
            delete = new Button { Style = GetStyle("DeleteButton"), Tag = grid };
            Label no = ListNo($"{prefix} {levels.Children.Count / 10}{levels.Children.Count % 10}");
            TextBox name = UsualBox(competetionName.Text);

            GridAddX2(grid, 0, delete, no, name);
            SetProp(name, Grid.ColumnSpanProperty, 3);
            
            for (int i = 0; i < elements.Length; i++)
                GridAddX3(grid, i + startRow, 1, 2, elements[i]);
            return grid;
        }
        private static Grid Competetions2(Grid grid, StackPanel levels, Grid next, out Button delete, int rows, int startRow, string prefix, FrameworkElement[][] elements)
        {
            AddRows(grid, rows);
            TextBox competetionName = next.Children[2] as TextBox;
            delete = DropButton(grid);
            Label no = ListNo($"{prefix}{levels.Children.Count}");
            TextBox name = UsualBox(competetionName.Text);

            GridAddX2(grid, 0, delete, no, name);
            SetProp(name, Grid.ColumnSpanProperty, 3);

            for (int i = 0; i < elements.Length; i++)
                GridAddX3(grid, i + startRow, 1, 2, elements[i]);
            return grid;
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
            Label lab = ListNo2(Lab(grid, 1).Content.ToString());
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

            Grid content = panel.Parent as Grid;
            StackPanel themeStack = content.Parent as StackPanel;
            Grid theme = themeStack.Parent as Grid;

            TextBox refer = theme.Children[3] as TextBox;

            MultiBinding multi = BindingOperations.GetMultiBindingExpression(refer, Control.BackgroundProperty).ParentMultiBinding;
            BindingOperations.ClearBinding(refer, Control.BackgroundProperty);
            MultiBinding multi2 = new MultiBinding { Converter = new UsedValuesConverter() };

            foreach (Binding binding in multi.Bindings)
                multi2.Bindings.Add(binding);

            Binding newBind = FastBind(txt2, "Text");
            txt2.Tag = newBind;
            multi2.Bindings.Add(newBind);
            _ = SetBind(refer, Control.BackgroundProperty, multi2);


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

            Grid content = panel.Parent as Grid;

            TextBox refer = content.Children[3] as TextBox;

            MultiBinding old = BindingOperations.GetMultiBindingExpression(refer, Control.BackgroundProperty).ParentMultiBinding;
            BindingOperations.ClearBinding(refer, Control.BackgroundProperty);
            MultiBinding multi2 = new MultiBinding { Converter = new UsedValuesConverter() };

            foreach (Binding binding in old.Bindings)
                multi2.Bindings.Add(binding);

            Binding newBind = FastBind(hoursBox, "Text");
            hoursBox.Tag = newBind;
            multi2.Bindings.Add(newBind);
            _ = SetBind(refer, Control.BackgroundProperty, multi2);

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
        public static void AutoIndexingBorder(StackPanel grandGrid, int pos, char mark, string prefix)
        {
            for (int no = 0; no < grandGrid.Children.Count; no++)
            {
                Grid section = grandGrid.Children[no] as Grid;
                Border border = section.Children[pos] as Border;
                Label nolab = border.Child as Label;
                nolab.Content = $"{prefix}{no + 1}{mark}";
                StackPanel panel = section.Children[pos + 1] as StackPanel;
                AutoIndexing(panel, 1, "", $"{prefix} {no + 1}.");
            }
        }
        public static void AutoIndexing(StackPanel grandGrid, int pos, string mark, string prefix)
        {
            for (int no = 0; no < grandGrid.Children.Count; no++)
            {
                Grid section = grandGrid.Children[no] as Grid;
                Label nolab = section.Children[pos] as Label; //Label nolab = section.Children[pos] as Label;
                nolab.Content = $"{prefix}{no + 1}{mark}";
            }
        }
        public static void AutoIndexing2(StackPanel grandGrid, int pos, string mark, string prefix)
        {
            for (int no = 0; no < grandGrid.Children.Count; no++)
            {
                Grid section = grandGrid.Children[no] as Grid;
                Label nolab = section.Children[pos] as Label;
                int calc = no + 1;
                nolab.Content = $"{prefix}{calc / 10}{calc % 10}{mark}";
            }
        }
        public static void AutoIndexing(StackPanel grandGrid, int pos, char mark, string prefix)
        {
            for (int no = 0; no < grandGrid.Children.Count; no++)
            {
                Grid section = grandGrid.Children[no] as Grid;
                Label nolab = section.Children[pos] as Label; //Label nolab = section.Children[pos] as Label;
                nolab.Content = $"{prefix}{no + 1}{mark}";
            }
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
            StackPanel panel = parent.Parent as StackPanel;
            panel.Children.Remove(parent);
        }

        public static void NewTopic(TableRowGroup mainBinding, StackPanel master, out Button BTbutton, out Button Cadd, out Button NewTypeAdd,
            out Button deleteOmni, out Button addNew, out TextBox newHours, string name, string hours, Label hoursToBind, out ComboBox newThemeLevels,
            out ComboBox themeLevelAdd)
        {
            int cnt = master.Children.Count;
            StackPanel Themes = TopicBase(mainBinding, master, 
            out deleteOmni, name, hours, hoursToBind, cnt);

            NewTheme(cnt, Themes, mainBinding, out BTbutton, out Cadd, out NewTypeAdd, out newThemeLevels);

            Grid newThemeGrid = NewThemeGrid(out addNew, out newHours, out themeLevelAdd, cnt, "2");
            Themes.Children.Add(newThemeGrid);
        }

        public static void NewTopic(TableRowGroup mainBinding, StackPanel master,
            out Button deleteOmni, out Button addNew, out TextBox newHours,
            Label hoursToBind,  out ComboBox themeLevelAdd, string name, string hours)
        {
            int cnt = master.Children.Count;
            StackPanel Themes = TopicBase(mainBinding, master,
            out deleteOmni, name, hours, hoursToBind, cnt);

            Grid newThemeGrid = NewThemeGrid(out addNew, out newHours, out themeLevelAdd, cnt, "1");
            Themes.Children.Add(newThemeGrid);
        }

        private static StackPanel TopicBase(TableRowGroup mainBinding, StackPanel master, 
            out Button deleteOmni, string name, string hours, Label hoursToBind, int cnt)
        {
            
            //Topic
            Grid omniGrid = GridItem4();
            AddRows(omniGrid, 2);
            deleteOmni = new Button { Style = GetStyle("DeleteButton") };
            Label topicNo = new Label { Content = $"Раздел {cnt}.", Style = GetStyle("CaptionSections") };
            TextBox topicName = new TextBox { FontWeight = FontWeights.Bold, Text = name, Style = GetStyle("RegularBox") };
            TextBox topicHours = new TextBox { FontWeight = FontWeights.Bold, Text = hours, Style = GetStyle("HoursBox") };
            MultiBinding colorFromText = Multi(new UsedValuesConverter(), FastBind(topicHours, "Text"));
            _ = SetBind(topicHours, Control.BackgroundProperty, colorFromText);
            StackPanel Themes = new StackPanel { Background = new SolidColorBrush(Color.FromRgb(238, 235, 182)) };
            GridAddX(omniGrid, deleteOmni, topicNo, topicName, topicHours, Themes);
            SetPropX(Grid.ColumnProperty, new object[] { 1, 2, 3 }, new Control[] { topicNo, topicName, topicHours });
            SetPropX(new DependencyProperty[] { Grid.RowProperty, Grid.ColumnProperty, Grid.ColumnSpanProperty },
                new object[] { 1, 0, 5 }, Themes);
            Grid addTopic = master.Children[cnt - 1] as Grid;
            (addTopic.Children[1] as Label).Content = $"Раздел {cnt + 1}.";
            master.Children.Remove(addTopic);
            master.Children.Add(omniGrid);
            master.Children.Add(addTopic);

            topicHours.Tag = hoursToBind;
            MultiBinding oldBind = BindingOperations.GetMultiBindingExpression(hoursToBind, ContentControl.ContentProperty).ParentMultiBinding;
            BindingOperations.ClearBinding(hoursToBind, ContentControl.ContentProperty);
            MultiBinding newBind = new MultiBinding { Converter = new SumConverter() };

            for (int i = 0; i < oldBind.Bindings.Count; i++)
                newBind.Bindings.Add(oldBind.Bindings[i]);
            newBind.Bindings.Add(FastBind(topicHours, "Text"));
            _ = SetBind(hoursToBind, ContentControl.ContentProperty, newBind);

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
            return Themes;
        }

        private static Grid NewThemeGrid(out Button addNew, out TextBox newHours, out ComboBox themeLevelAdd, int cnt, string start)
        {
            Grid AddThemeGrid = GridItem4();
            addNew = new Button { Style = GetStyle("AddButton") };
            Label newTitle = new Label { Content = $"Тема {cnt}.{start}.", Style = GetStyle("CaptionSections") };
            TextBox newName = new TextBox { Style = GetStyle("RegularBox") };
            newHours = new TextBox { Style = GetStyle("HoursBox") };
            themeLevelAdd = new ComboBox { Text = "", Style = GetStyle("HoursBox"), IsEditable = true };
            GridAddX(AddThemeGrid, addNew, newTitle, newName, newHours, themeLevelAdd);
            SetPropX(Grid.ColumnProperty, new object[] { 1, 2, 3, 4 }, new Control[] { newTitle, newName, newHours, themeLevelAdd });
            return AddThemeGrid;
        }

        public static void NewTheme(int cnt, StackPanel Themes, TableRowGroup mainBinding, out Button BTbutton, out Button Cadd, out Button NewTypeAdd, out ComboBox newThemeLevels)
        {
            NewTheme($"Тема {cnt}.1.", Themes, mainBinding, out BTbutton, out Cadd, out NewTypeAdd, out newThemeLevels, "", "", "");
        }

        public static void NewTheme(string themeTitle, StackPanel Themes, TableRowGroup mainBinding,
            out Button BTbutton, out Button Cadd, out Button NewTypeAdd, out ComboBox newLevels,
            string themeNameVal, string themeHoursVal, string themeLevelVal)
        {
            //Theme
            Grid mainGrid = GridItem4();
            AddRows(mainGrid, 2);
            BTbutton = new Button { Style = GetStyle("DeleteButton") };
            Label themeNo = new Label { Content = themeTitle, Style = GetStyle("CaptionSections") };
            TextBox themeName = new TextBox { Text = themeNameVal, Style = GetStyle("SubCaptionBox") };
            TextBox themeHours = new TextBox { Text = themeHoursVal, Style = GetStyle("HoursBox") };
            MultiBinding colorFromText = Multi(new UsedValuesConverter(), FastBind(themeHours, "Text"));
            _ = SetBind(themeHours, Control.BackgroundProperty, colorFromText);
            newLevels = new ComboBox { Text = themeLevelVal, Style = GetStyle("HoursBox"), IsEditable = true };
            StackPanel themes = new StackPanel { Background = new SolidColorBrush(Color.FromRgb(238, 235, 182)) }; //"#FFEEEBB6"
            GridAddX(mainGrid, BTbutton, themeNo, themeName, themeHours, newLevels, themes);
            SetPropX(Grid.ColumnProperty, new object[] { 1, 2, 3, 4 }, new Control[] { themeNo, themeName, themeHours, newLevels });
            SetPropX(new DependencyProperty[] { Grid.RowProperty, Grid.ColumnProperty, Grid.ColumnSpanProperty },
                new object[] { 1, 0, 5 }, themes);
            Themes.Children.Add(mainGrid);

            Grid topic = Themes.Parent as Grid;

            TextBox refer = topic.Children[3] as TextBox;

            MultiBinding oldHoursMark = BindingOperations.GetMultiBindingExpression(refer, Control.BackgroundProperty).ParentMultiBinding;
            BindingOperations.ClearBinding(refer, Control.BackgroundProperty);
            MultiBinding newHoursMark = new MultiBinding { Converter = new UsedValuesConverter() };

            foreach (Binding binding in oldHoursMark.Bindings)
                newHoursMark.Bindings.Add(binding);

            Binding newBind = FastBind(themeHours, "Text");
            themeHours.Tag = newBind;
            newHoursMark.Bindings.Add(newBind);
            _ = SetBind(refer, Control.BackgroundProperty, newHoursMark);

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

            //Table Contents
            MultiBinding multi2 = Multi(new SectionsConverter(), FastBind(themeNo, "Content"), FastBind(themeName, "Text"));
            Binding bindLevel = FastBind(themeHours, "Text");
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
