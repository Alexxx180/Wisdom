using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using static Wisdom.Customing.ResourceHelper;
using static Wisdom.Writers.Content;

namespace Wisdom.Binds
{
    public static class EasyBindings
    {
        public static Binding FastBind(object source, string path)
        {
            return new Binding
            {
                Source = source,
                Path = new PropertyPath(path)
            };
        }

        public static DependencyObject SetBind(DependencyObject @object, DependencyProperty property, BindingBase @base)
        {
            BindingOperations.SetBinding(@object, property, @base);
            return @object;
        }
        public static MultiBinding Multi(IMultiValueConverter converter, params Binding[] bindings)
        {
            MultiBinding multi = new MultiBinding { Converter = converter };
            foreach (Binding bind in bindings)
                multi.Bindings.Add(bind);
            return multi;
        }
        public static MultiBinding Multi(params Binding[] bindings)
        {
            MultiBinding multi = new MultiBinding();
            foreach (Binding bind in bindings)
                multi.Bindings.Add(bind);
            return multi;
        }
        public static Paragraph Text(Binding binding)
        {
            return new Paragraph()
            {
                Style = GetStyle("RegularParagraph"),
                Inlines = { SetBind(new Run(), Run.TextProperty, binding) as Run }
            };
        }
        public static Paragraph Text(MultiBinding binding)
        {
            return new Paragraph()
            {
                Style = GetStyle("RegularParagraph"),
                Inlines = { SetBind(new Run(), Run.TextProperty, binding) as Run }
            };
        }
        public static Paragraph Text(TextBox box)
        {
            return Text(FastBind(box, "Text"));
        }
        public static Paragraph Text(Label lab)
        {
            return Text(FastBind(lab, "Content"));
        }
        public static void RichText(RichTextBox box)
        {
            if (box.Tag.GetType() == typeof(TableCell))
            {
                TableCell cl = box.Tag as TableCell;
                cl.Blocks.Clear();
                Section sec = BoXaml(box);
                while (sec.Blocks.Count > 0)
                    cl.Blocks.Add(sec.Blocks.FirstBlock);
            }
            else if (box.Tag.GetType() == typeof(List))
            {
                List cl = box.Tag as List;
                cl.ListItems.Clear();
                List lst = box.Document.Blocks.FirstBlock as List;
                foreach (ListItem item in lst.ListItems)
                    if (item.ToString() != "")
                        cl.ListItems.Add(item);
            }
        }
    }
}
