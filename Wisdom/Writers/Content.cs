using System.Windows.Controls;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.IO;
using System.Text;
using System.Xml;
using System.Windows.Markup;
using static Wisdom.Customing.BlockTemplates;
using static Wisdom.Customing.Decorators;
using static Wisdom.Binds.EasyBindings;

namespace Wisdom.Writers
{
    public static class Content
    {
        public static void ParagraphText(Button addNext,
            out Button delete, out Button add)
        {
            Grid next = addNext.Parent as Grid;
            StackPanel levels = next.Parent as StackPanel;
            ComboBox type = next.Children[1] as ComboBox;
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
            Paragraph prg = run.Parent as Paragraph;
            _ = prg.Inlines.Remove(run);
        }
        public static void RemoveRunLB(object value)
        {
            Run run = value as Run;
            Paragraph prg = run.Parent as Paragraph;
            LineBreak lbreak = run.Tag as LineBreak;
            _ = prg.Inlines.Remove(run);
            _ = prg.Inlines.Remove(lbreak);
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
            TextBlock taskNo = topic.Children[position] as TextBlock;
            taskNo.Text = $"{prefix}{no + 1}{mark}";
        }
    }
}
