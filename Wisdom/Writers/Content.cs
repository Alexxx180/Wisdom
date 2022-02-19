using System.Windows.Controls;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using static Wisdom.Customing.Converters;
using static Wisdom.Customing.BlockTemplates;
using static Wisdom.Customing.Decorators;
using static Wisdom.Binds.EasyBindings;
using static Wisdom.Writers.Preview;
using Wisdom.Binds;
using System.IO;
using System.Text;
using System.Xml;
using System.Windows.Markup;
using System.Windows.Input;
using System.Text.RegularExpressions;

namespace Wisdom.Writers
{
    public static class Content
    {
        

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
            newHours.Tag = refer; //bindHours
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
        public static void RemoveParagraph(object value)
        {
            Paragraph prg = value as Paragraph;
            Section sct = prg.Parent as Section;
            _ = sct.Blocks.Remove(prg);
        }
        public static void RemoveRun(object value)
        {
            Run run = value as Run;
            Paragraph prg = Parent(run);
            _ = prg.Inlines.Remove(run);
        }
        public static void RemoveRunLB(object value)
        {
            Run run = value as Run;
            Paragraph prg = Parent(run);
            LineBreak lbreak = run.Tag as LineBreak;
            _ = prg.Inlines.Remove(run);
            _ = prg.Inlines.Remove(lbreak);
        }
        public static void RemoveListItem(object value)
        {
            ListItem item = value as ListItem;
            List list = Parent(item);
            _ = list.ListItems.Remove(item);
        }
        public static void RemoveTableRow(object value)
        {
            TableRow row = value as TableRow;
            TableRowGroup rgr = Parent(row);
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
                Grid section = GridChild(grandGrid, no);
                Border border = Border(section, pos);
                Label nolab = Child(border);
                nolab.Content = $"{prefix}{no + 1}{mark}";
                StackPanel panel = Panel(section, pos + 1);
                AutoIndexing(panel, 1, "", $"{prefix} {no + 1}.");
            }
        }
        public static void AutoIndexing(StackPanel grandGrid, int pos, string mark, string prefix)
        {
            for (int no = 0; no < grandGrid.Children.Count; no++)
            {
                int calc = no + 1;
                Grid section = GridChild(grandGrid, no);
                Label themeNo = Lab(section, pos);
                themeNo.Content = $"{prefix}{calc}{mark}";
            }
        }
        public static void AutoIndexing2(StackPanel grandGrid, int pos, string mark, string prefix)
        {
            for (int no = 0; no < grandGrid.Children.Count; no++)
            {
                int calc = no + 1;
                Grid section = GridChild(grandGrid, no);
                Label nolab = Lab(section, pos);
                nolab.Content = $"{prefix}{calc / 10}{calc % 10}{mark}";
            }
        }
        public static void AutoIndexing(StackPanel grandGrid, int pos, char mark, string prefix)
        {
            for (int no = 0; no < grandGrid.Children.Count; no++)
            {
                Grid section = GridChild(grandGrid, no);
                Label nolab = Lab(section, pos);
                nolab.Content = $"{prefix}{no + 1}{mark}";
            }
        }
        public static void AutoIndexing(StackPanel grandGrid, int pos, char mark)
        {
            for (int no = 0; no < grandGrid.Children.Count; no++)
            {
                Grid content = GridChild(grandGrid, no);
                Label taskNo = Lab(content, pos);
                taskNo.Content = $"{no + 1}{mark}";
            }
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
        
        public static void DeleteSection(Grid parent)
        {
            TableRow row = parent.Tag as TableRow;
            TableRowGroup grp = row.Parent as TableRowGroup;
            grp.Rows.Remove(row);
            StackPanel panel = parent.Parent as StackPanel;
            panel.Children.Remove(parent);
        }


        public static void AutoIndexing(StackPanel grandGrid, int pos, string prefix, char mark)
        {
            for (int no = 0; no < grandGrid.Children.Count; no++)
            {
                Index(grandGrid, no, pos, prefix, mark);
            }
        }

        public static void Index(StackPanel grandGrid, int no, int position, string prefix, char mark)
        {
            UserControl task = grandGrid.Children[no] as UserControl;
            Grid topic = task.Content as Grid;
            TextBlock taskNo = Txt(topic, position);
            taskNo.Text = $"{prefix}{no + 1}{mark}";
        }

        private static string GetProposedText(TextBox textBox, string newText)
        {
            var text = textBox.Text;
            if (textBox.SelectionStart != -1)
                text = text.Remove(textBox.SelectionStart, textBox.SelectionLength);
            text = text.Insert(textBox.CaretIndex, newText);
            return text;
        }

        public static string RememberNo(out string memory, string no)
        {
            memory = no;
            return "";
        }

        private static readonly Regex _hours = new Regex("^([1-9]|[1-9]\\d\\d?)$");
        public static void CheckForHours(object sender, TextCompositionEventArgs e)
        {
            TextBox box = e.OriginalSource as TextBox;
            string full = box.Text.Insert(box.CaretIndex, e.Text);
            e.Handled = !_hours.IsMatch(full);
        }
        public static void CheckForPastingHours(object sender, DataObjectPastingEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                string pastedText = e.DataObject.GetData(typeof(string)) as string;
                string proposedText = GetProposedText(textBox, pastedText);

                if (!_hours.IsMatch(proposedText))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }

        private static readonly Regex _naming = new Regex(@"^[A-Za-zА-Яа-я0-9\s-_]*$");
        public static void CheckForNaming(object sender, TextCompositionEventArgs e)
        {
            TextBox box = e.OriginalSource as TextBox;
            string full = box.Text.Insert(box.CaretIndex, e.Text);
            e.Handled = !_naming.IsMatch(full);
        }
        public static void CheckForPastingNaming(object sender, DataObjectPastingEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                string pastedText = e.DataObject.GetData(typeof(string)) as string;
                string proposedText = GetProposedText(textBox, pastedText);

                if (!_naming.IsMatch(proposedText))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }
    }
}
