using System.Windows.Controls;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using static Wisdom.Customing.Converters;
using static Wisdom.Customing.BlockTemplates;
using static Wisdom.Customing.ResourceHelper;
using static Wisdom.Customing.Decorators;
using static Wisdom.Binds.EasyBindings;
using static Wisdom.Writers.Preview;
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

        public static Button Source(Button addNext)
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
            SetColSpan(name, 3);
            grid.Tag = source;

            int count = Restack(levels, next, grid);
            nextNo.Content = $"{count}.";
            return delete;
        }
        public static Button TextContent3(Button btn)
        {
            Grid next = Parent(btn);
            StackPanel levels = Parent(next);
            Grid captionGrid = Parent(levels);

            List controlList = ListFromTag(captionGrid);
            
            Label nextNo = Lab(next, 1);
            TextBox nextName = Box(next, 2);

            Grid grid = GridItem3();
            Button delete = DropButton(grid);
            Label no = ListNo(levels.Children.Count + ".");
            TextBox name = UsualBox(nextName.Text);

            ListItem litems = new ListItem();
            Run run2 = new Run();
            _ = SetBind(run2, Run.TextProperty, FastBind(name, "Text"));
            
            litems.Blocks.Add(new Paragraph(run2) { Style = GetStyle("RegularParagraph") });
            controlList.ListItems.Add(litems);

            ListItem litem = new ListItem();
            if (levels.Tag != null)
            {
                List p2 = levels.Tag as List;
                Run run = new Run();
                _ = SetBind(run, Run.TextProperty, FastBind(name, "Text"));
                litem.Blocks.Add(new Paragraph(run) { Style = GetStyle("RegularParagraph") });
                p2.ListItems.Add(litem);
            }

            litems.Tag = litem;
            grid.Tag = litems;

            GridAddX2(grid, 0, delete, no, name);
            SetColSpan(name, 3);

            int count = Restack(levels, next, grid);
            nextNo.Content = $"{count}.";
            return delete;
        }

        public static Button GeneralCompetetion(Button addNext)
        {
            Grid next = Parent(addNext);
            StackPanel levels = Parent(next);

            Label nextNo = Lab(next, 1);

            FrameworkElement[][] elements = new FrameworkElement[][] {
                new FrameworkElement[] { ListNo("Умения:"), UsualBox("") },
                new FrameworkElement[] { ListNo("Знания:"), UsualBox("") }
            };
            Grid grid = Competetions(GridItem5(3), levels, next, out Button delete, 1, "ОК", elements);

            int count = Restack(levels, next, grid);
            nextNo.Content = $"ОК {count / 10}{count % 10}";
            return delete;
        }

        public static Button TextContent5(Button add)
        {
            Grid next = Parent(add);
            StackPanel levels = Parent(next);
            Grid current = Parent(levels);
            Border border = Border(current, 1);
            Label title = Child(border);

            FrameworkElement[][] elements = new FrameworkElement[][] {
                new FrameworkElement[] { ListNo("Практический опыт:"), UsualBox("") },
                new FrameworkElement[] { ListNo("Умения:"), UsualBox("") },
                new FrameworkElement[] { ListNo("Знания:"), UsualBox("") }
            };
            string prefix = title.Content.ToString();
            Grid grid = Competetions2(GridItem5(4), levels, next, out Button delete, 1, prefix, elements);

            Label nextNo = Lab(next, 1);
            int count = Restack(levels, next, grid);
            nextNo.Content = $"{prefix}{count}";
            return delete;
        }

        public static Button NewProfessionalSection(Button add)
        {
            Grid next = Parent(add);
            StackPanel levels = Parent(next);

            FrameworkElement[][] elements = new FrameworkElement[][] {
                new FrameworkElement[] { ListNo("Практический опыт:"), UsualBox("") },
                new FrameworkElement[] { ListNo("Умения:"), UsualBox("") },
                new FrameworkElement[] { ListNo("Знания:"), UsualBox("") }
            };
            Grid grid = Competetions(GridItem5(4), levels, next, out Button delete, 1, "ПК", elements);

            Label nextNo = Lab(next, 1);
            int count = Restack(levels, next, grid);
            nextNo.Content = $"ПК {count}";
            return delete;
        }
        public static Grid ProfessionSection(string prefix,
            string no, out Button delete, out Button addComp)
        {
            Grid grid = GridItem6(2);
            delete = DropButton();
            Border border = SolidBorder(3, 198, 255);
            Label no1 = Caption($"{prefix}{no}.");
            border.Child = no1;
            StackPanel competetions = new StackPanel() {
                Children = { CompetetionAddGrid($"{prefix} {no}.", out addComp) }
            };
            GridAddX2(grid, 0, delete, border);
            GridAdd(grid, competetions);
            SetSpans(competetions, 1, 2);
            return grid;
        }
        public static Grid CompetetionAddGrid(string prefix, out Button add)
        {
            Grid subGrid = GridItem5();
            add = AddButton();
            Label no1 = ListNo($"{prefix}1");
            TextBox level = UsualBox("");
            GridAddX2(subGrid, 0, add, no1, level);
            SetColSpan(level, 3);
            return subGrid;
        }
        private static Grid Competetions(Grid grid, StackPanel levels, Grid next,
            out Button delete, int startRow, string prefix, FrameworkElement[][] elements)
        {
            int count = levels.Children.Count;

            TextBox competetionName = Box(next, 2);
            delete = DropButton(grid);
            Label no = ListNo($"{prefix} {count / 10}{count % 10}");
            TextBox name = UsualBox(competetionName.Text);

            GridAddX2(grid, 0, delete, no, name);
            SetColSpan(name, 3);
            
            for (int i = 0; i < elements.Length; i++)
                GridAddX3(grid, i + startRow, 1, 2, elements[i]);
            return grid;
        }
        private static Grid Competetions2(Grid grid, StackPanel levels, Grid next,
            out Button delete, int startRow, string prefix, FrameworkElement[][] elements)
        {
            TextBox competetionName = Box(next, 2);
            delete = DropButton(grid);
            Label no = ListNo($"{prefix}{levels.Children.Count}");
            TextBox name = UsualBox(competetionName.Text);

            GridAddX2(grid, 0, delete, no, name);
            SetProp(name, Grid.ColumnSpanProperty, 3);

            for (int i = 0; i < elements.Length; i++)
                GridAddX3(grid, i + startRow, 1, 2, elements[i]);
            return grid;
        }
        

        public static void ParagraphText(Button addNext,
            out Button delete, out Button add)
        {
            Grid next = Parent(addNext);
            StackPanel levels = Parent(next);
            ComboBox type = Cbx(next, 1);
            string title = type.Text;
            Paragraph p = TextB(title + ":");
            Section sources = SectionFromTag(next);

            sources.Blocks.Add(p);

            Grid grid = GridItem();
            AddRows(grid, 2);
            delete = DropButton(grid);
            Label no = Caption(title);

            StackPanel stack = new StackPanel();
            
            Grid subGrid = GridItem();
            add = AddButton(grid);
            Label no1 = ListNo("1.");
            TextBox level = UsualBox("");
            stack.Children.Add(subGrid);

            GridAddX2(subGrid, 0, add, no1, level);
            GridAddX2(grid, 0, delete, no);
            GridAdd(grid, stack);

            SetColSpanX(2, level, no, stack);
            SetRow(stack, 1);
            grid.Tag = p;

            _ = Restack(levels, next, grid);
        }
        private static DependencyObject ReferNewBind(MultiBinding calculation,
            TextBox newHours, Label refer, DependencyProperty property)
        {
            Binding bindHours = FastBind(newHours, "Text");
            newHours.Tag = bindHours;
            calculation.Bindings.Add(bindHours);
            return SetBind(refer, property, calculation);
        }
        private static DependencyObject ReferNewBind(
            MultiBinding calculation, TextBox newHours, TextBox refer)
        {
            Binding bindHours = FastBind(newHours, "Text");
            newHours.Tag = bindHours;
            calculation.Bindings.Add(bindHours);
            return SetBind(refer, Control.BackgroundProperty, calculation);
        }

        public static Button TableContent(Button addNext)
        {
            Grid next = Parent(addNext);
            StackPanel tasks = Parent(next);

            Label nextNo = Lab(next, 1);
            TextBox nextName = Box(next, 2);
            TextBox nextHours = Box(next, 3);

            Grid newTask = GridItem();
            Button delete = DropButton(newTask);
            Label newNo = ListNo2(nextNo.Content.ToString());
            TextBox newName = UsualBox(nextName.Text);
            TextBox newHours = HoursBox(nextHours.Text);
            GridAddX2(newTask, 0, delete, newNo, newName, newHours);

            TableCell no = UsualTableCell(Text(newNo));
            TableCell name = UsualTableCell(Text(newName));
            TableCell hours = UsualTableCell(Text(newHours));
            TableRow row = new TableRow { Cells = { no, name, hours } };
            TableRowGroup docRowGroup = RowGroupFromTag(tasks);
            docRowGroup.Rows.Add(row);

            newTask.Tag = row;

            int count = Restack(tasks, next, newTask);
            nextNo.Content = $"{count}.";

            Grid content = Parent(tasks);
            StackPanel themeStack = Parent(content);
            Grid theme = Parent(themeStack);

            TextBox referHours = Box(theme, 3);

            MultiBinding reCalculation = ResetMulti(referHours,
                Control.BackgroundProperty, new UsedValuesConverter());

            _ = ReferNewBind(reCalculation, newHours, referHours);
            return delete;
        }
        private static void TableSingleContent(Grid nextSection, StackPanel sections,
            ComboBox cbx, out TextBox hoursBox, out Button delete)
        {
            Label type = ListNo2(cbx.Text);
            Grid newSection = GridItem2();
            delete = DropButton(newSection);
            TextBox nameBox = UsualBox("«»");
            hoursBox = HoursBox("");
            GridAddX(newSection, delete, type, nameBox, hoursBox);

            Binding bindType = FastBind(type, "Content");
            Binding bindName = FastBind(nameBox, "Text");
            MultiBinding sectionName = Multi(new SectionsConverter(), bindType, bindName);
            Binding bindHours = FastBind(hoursBox, "Text");
            
            TableCell name = UsualTableCell(Text(sectionName));
            TableCell hours = UsualTableCell(TextCenter(bindHours));
            SetColX2(1, type, nameBox, hoursBox);

            TableRow row = new TableRow { Cells = { name, hours } };
            newSection.Tag = row;
            Restack(sections, nextSection, newSection);

            Grid content = Parent(sections);
            TextBox referHours = Box(content, 3);

            MultiBinding reCalculation = ResetMulti(referHours,
                Control.BackgroundProperty, new UsedValuesConverter());

            _ = ReferNewBind(reCalculation, hoursBox, referHours);

            TableRowGroup grp = RowGroupFromTag(sections);
            grp.Rows.Add(row);
        }
        private static void TableGroupContent(Grid nextTaskGroup, ref StackPanel panel,
            ComboBox cbx, out TextBox hours, out Button delete, ref Button add)
        {
            Label taskNo = Caption("№");
            Label taskDescription = Caption("Описание");
            Label taskType = Section(cbx.Text);
            Grid task = GridItem();
            Grid taskGroup = GridItem();
            AddRows(taskGroup, 3);
            delete = DropButton(taskGroup);
            GridAddX2(taskGroup, 0, delete, taskNo, taskDescription);
            GridAdd(taskGroup, taskType);
            SetCol(taskType, 1);
            //SetColX(new int[] { 1, 1, 2 }, taskType, taskNo, taskDescription);
            SetRowX(1, taskDescription, taskNo);
            SetColSpanX(2, taskDescription, taskType);

            Paragraph type = Text(cbx.Text);
            Table docTasks = UsualTable();
            AddTCols(docTasks, 0.048, 0.8, 0.152);
            TableRow docTask = new TableRow();
            TableRowGroup docTaskGroup = new TableRowGroup { Rows = { docTask } };
            docTasks.RowGroups.Add(docTaskGroup);
            task.Tag = docTask;

            TableRowGroup docContentGroup = RowGroupFromTag(panel);
            TableCell docContentCell = Span2TableCell(type, docTasks);
            TableRow docContentRow = new TableRow { Cells = { docContentCell } };
            docContentGroup.Rows.Add(docContentRow);
            taskGroup.Tag = docContentRow;

            StackPanel stackPanel = new StackPanel { Tag = docTaskGroup };
            Label no = ListNo2("1");
            TextBox name = UsualBox("");
            hours = HoursBox("");

            Binding bindDescription = FastBind(taskDescription, "Content");
            Binding bindName = FastBind(name, "Text");

            MultiBinding fullDescribe = Multi(new SectionsConverter(), bindDescription, bindName);
            Binding bindHours = FastBind(hours, "Text");
            SetBind(new Run(), Run.TextProperty, fullDescribe);
            SetBind(new Run(), Run.TextProperty, bindHours);
            add = AddButton(task);
            GridAddX2(task, 0, add, no, name, hours);
            
            stackPanel.Children.Add(task);
            taskGroup.Children.Add(stackPanel);
            SetRow(stackPanel, 2);
            SetColSpan(stackPanel, 4);
            Restack(panel, nextTaskGroup, taskGroup);
        }

        public static void AutoDetectContentType(Button btn, out TextBox hours,
            out Button delete, ref Button add)
        {
            Grid grid = Parent(btn);
            StackPanel panel = Parent(grid);
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
                Label nolab = Child(border);
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

        public static void NewTopic(TableRowGroup mainBinding, StackPanel master,
            out Button BTbutton, out Button Cadd, out Button NewTypeAdd,
            out Button deleteOmni, out Button addNew, out TextBox newHours,
            string name, string hours, Label hoursToBind,
            out ComboBox newThemeLevels, out ComboBox themeLevelAdd)
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

        //Topic
        private static StackPanel TopicBase(TableRowGroup mainBinding, StackPanel master, 
            out Button deleteTopic, string name, string hours, Label hoursToBind, int cnt)
        {
            Grid topic = GridItem4(2);
            deleteTopic = DropButton();
            Label topicNo = Caption($"Раздел {cnt}.");
            TextBox topicName = UsualBox(name);
            TextBox topicHours = HoursBox(hours);
            SetPropX(TextElement.FontWeightProperty, FontWeights.Bold, topicName, topicHours);

            Binding bindColor = FastBind(topicHours, "Text");
            MultiBinding colorFromText = Multi(new UsedValuesConverter(), bindColor);
            _ = SetBind(topicHours, Control.BackgroundProperty, colorFromText);

            StackPanel Themes = new StackPanel { Background = new SolidColorBrush(Color.FromRgb(238, 235, 182)) };
            GridAddX2(topic, 0, deleteTopic, topicNo, topicName, topicHours);
            GridAdd(topic, Themes);
            SetRow(Themes, 1);
            SetColSpan(Themes, 5);
            Grid addTopic = master.Children[cnt - 1] as Grid;
            Label addTopicNo = Lab(addTopic, 1);
            addTopicNo.Content = $"Раздел {cnt + 1}.";
            Restack(master, addTopic, topic);

            topicHours.Tag = hoursToBind;
            MultiBinding reCalculation = ResetMulti(hoursToBind,
                ContentControl.ContentProperty, new SumConverter());

            _ = ReferNewBind(reCalculation, topicHours, hoursToBind, ContentControl.ContentProperty);
            
            //Doc topic
            Binding bindNo = FastBind(topicNo, "Content");
            Binding bindName = FastBind(topicName, "Text");
            MultiBinding multi = Multi(new SectionsConverter(), bindNo, bindName);
            Binding bindHours = FastBind(topicHours, "Text");

            TableRow docTopic = new TableRow();
            TableCell docTopicName = UsualTableCell(TextCB(multi));
            TableCell docEmptyDescription = UsualTableCell();
            TableCell docTopicHours = UsualTableCell(TextCB(bindHours));
            TableCell docEmptyLevel = UsualTableCell();
            AddRCells(docTopic, docTopicName, docEmptyDescription, docTopicHours, docEmptyLevel);

            topic.Tag = docTopic;
            mainBinding.Rows.Add(docTopic);
            deleteTopic.Tag = Themes;
            return Themes;
        }

        private static Grid NewThemeGrid(out Button addTheme, out TextBox hours,
            out ComboBox level, int cnt, string start)
        {
            Grid theme = GridItem4();
            addTheme = AddButton();
            Label title = Caption($"Тема {cnt}.{start}.");
            TextBox name = UsualBox("");
            hours = HoursBox("");
            level = HoursCombo("", true);
            GridAddX2(theme, 0, addTheme, title, name, hours, level);
            return theme;
        }

        public static void NewTheme(int cnt, StackPanel Themes, TableRowGroup themePlan,
            out Button BTbutton, out Button Cadd, out Button NewTypeAdd, out ComboBox newThemeLevels)
        {
            NewTheme($"Тема {cnt}.1.", Themes, themePlan, out BTbutton, out Cadd, out NewTypeAdd, out newThemeLevels, "", "", "");
        }

        public static void NewTheme(string no, StackPanel themes, TableRowGroup themePlan,
            out Button dropTheme, out Button Cadd, out Button addNextTask, out ComboBox newLevels,
            string name, string hours, string level)
        {
            //Theme
            Grid theme = GridItem4(2);
            dropTheme = DropButton();
            Label themeNo = Caption(no);
            TextBox themeName = SubCaptionBox(name);
            TextBox themeHours = HoursBox(hours);

            Binding bindThemeHours = FastBind(themeHours, "Text");
            MultiBinding colorFromText = Multi(new UsedValuesConverter(), bindThemeHours);
            _ = SetBind(themeHours, Control.BackgroundProperty, colorFromText);

            newLevels = HoursCombo(level, true);
            StackPanel contentGroup = new StackPanel { Background = Yellow };
            GridAddX2(theme, 0, dropTheme, themeNo, themeName, themeHours, newLevels);
            GridAdd(theme, contentGroup);
            SetRow(contentGroup, 1);
            SetColSpan(contentGroup, 5);

            themes.Children.Add(theme);

            Grid topic = Parent(themes);
            TextBox referHours = Box(topic, 3);

            MultiBinding reCalculation = ResetMulti(referHours,
                Control.BackgroundProperty, new UsedValuesConverter());
            _ = ReferNewBind(reCalculation, themeHours, referHours);

            //Theme Content
            Grid content = NewThemeContent(out Cadd, out StackPanel themeContent);
            contentGroup.Children.Add(content);

            Grid nextTask = NextThemeTask(out addNextTask);
            contentGroup.Children.Add(nextTask);

            //Doc theme
            TableRow docTheme = ThemePreviewRow(themeNo, themeName, themeHours, out TableCell contentsCell);
            themePlan.Rows.Add(docTheme);
            theme.Tag = docTheme;

            //Doc theme content
            Table docContent = ContentPreviewTable(out TableRowGroup docContentGroup);
            TableRow docTasks = TasksPreviewRow(out TableCell docTask);
            TableRowGroup taskGroup = TaskPreviewGroup(docTask);
            docContentGroup.Rows.Add(docTasks);
            contentsCell.Blocks.Add(docContent);

            //Doc theme refer
            themeContent.Tag = taskGroup;
            contentGroup.Tag = docContentGroup;
            
        }
        private static Grid NewThemeContent(out Button addContent, out StackPanel themeContent)
        {
            Grid content = GridItem(3);
            Label title = Section("Содержание учебного материала");
            Label listCaption1 = Caption("№");
            Label listCaption2 = Caption("Описание");
            Label listCaption3 = Caption("Часы");
            themeContent = new StackPanel();

            GridAdd(content, title);
            SetCol(title, 1);
            SetColSpan(title, 3);
            GridAddX3(content, 1, 1, 1, listCaption1, listCaption2, listCaption3);
            GridAdd(content, themeContent);
            SetRow(themeContent, 2);
            SetColSpan(themeContent, 5);

            Grid levelContent = NextContentLevel(out addContent);
            _ = themeContent.Children.Add(levelContent);
            return content;
        }
        private static Grid NextContentLevel(out Button addContent)
        {
            Grid levelContent = GridItem();
            addContent = AddButton();
            Label levelNo = ListNo2("1");
            TextBox levelName = UsualBox("");
            TextBox levelHours = HoursBox("");
            GridAddX2(levelContent, 0, addContent, levelNo, levelName, levelHours);
            return levelContent;
        }
        private static Grid NextThemeTask(out Button addNextTask)
        {
            Grid nextTask = GridItem();
            addNextTask = AddButton();
            ComboBox type = TasksCombo();
            AddItems(type,
                "Практические занятия",
                "Контрольная работа",
                "Самостоятельная работа"
                );
            CheckBox isGroup = UsualCheckBox(" >1");
            GridAdd(nextTask, addNextTask);
            SetRow(addNextTask, 3);
            GridAddX3(nextTask, 3, 1, 2, type, isGroup);
            return nextTask;
        }
    }
}
