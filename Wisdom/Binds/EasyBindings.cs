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
        public static Binding FastBind(object source, string path, IValueConverter converter)
        {
            return new Binding
            {
                Source = source,
                Path = new PropertyPath(path),
                Converter = converter
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
        public static DependencyObject SetRunMultiBind(Run run, IMultiValueConverter converter, params Binding[] bindings)
        {
            return SetBind(run, Run.TextProperty, Multi(converter, bindings));
        }

        public static Paragraph Text(Binding binding)
        {
            return new Paragraph()
            {
                Style = GetStyle("RegularParagraph"),
                Inlines = { SetBind(new Run(), Run.TextProperty, binding) as Run }
            };
        }
        public static Paragraph Text(string text)
        {
            return new Paragraph()
            {
                Style = GetStyle("RegularParagraph"),
                Inlines = { new Run(text) }
            };
        }
        public static Paragraph TextB(string text)
        {
            return new Paragraph()
            {
                Style = GetStyle("RegularParagraph"),
                Inlines = { new Run(text) { FontWeight = FontWeights.Bold } }
            };
        }
        public static Paragraph TextCB(Binding binding)
        {
            return new Paragraph()
            {
                TextAlignment = TextAlignment.Center,
                Style = GetStyle("RegularParagraph"),
                Inlines = { SetBind(new Run() { FontWeight = FontWeights.Bold }, Run.TextProperty, binding) as Run }
            };
        }
        public static Paragraph TextCenter(Binding binding)
        {
            return new Paragraph()
            {
                TextAlignment = TextAlignment.Center,
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
        public static Paragraph TextCB(MultiBinding binding)
        {
            return new Paragraph()
            {
                TextAlignment = TextAlignment.Center,
                Style = GetStyle("RegularParagraph"),
                Inlines = { SetBind(new Run() { FontWeight = FontWeights.Bold }, Run.TextProperty, binding) as Run }
            };
        }
        public static Paragraph TextCenter(MultiBinding binding)
        {
            return new Paragraph()
            {
                TextAlignment = TextAlignment.Center,
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
    }
}
