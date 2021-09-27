using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Text.RegularExpressions;
using static Wisdom.Customing.BlockTemplates;
using static Wisdom.Customing.Decorators;
using static Wisdom.Writers.ResultRenderer;
using static Wisdom.Binds.EasyBindings;
using static Wisdom.Writers.Content;
using static Wisdom.Customing.Converters;
using System;
using static Wisdom.Customing.ResourceHelper;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Data;
using Wisdom.Binds;
using Microsoft.Win32;
using static Wisdom.Model.ProgramContent;

namespace Wisdom
{
    /// <summary>
    /// Логика взаимодействия для AddProg.xaml
    /// </summary>
    public partial class AddProg : Window
    {
        private static readonly Regex numbers = new Regex("^[\\d]");
        private string FileName => $@"{Program.Text}.docx";
        public AddProg()
        {
            InitializeComponent();
        }
        //public static string MaxHours = "58";
        //public static string EduHours = "48";
        //public static string SelfHours = "10";

        ////Form 2
        //public static string Lections = "18";
        //public static string Practices = "25";
        //public static string ControlWs = "10";
        //public static string CourseWs = "0";
        private void Create_Click(object sender, RoutedEventArgs e)
        {
            DisciplineName = DpSelect.Text;
            ProfessionName = SpSelect.Text;
            MaxHours = Max.Content.ToString();
            SelfHours = Self.Text;
            EduHours = Usual.Text;

            Lections = Lectures.Text;
            Practice = Practices.Text;
            LabWorks = Labs.Text;
            ControlWs = Controls.Text;
            CourseWs = Course.Text;
            //Usual.Text
            //SaveFileDialog dialog = new SaveFileDialog
            //{
            //    FileName = FileName,
            //    Filter =
            //    "Документ Microsoft Word (*.docx)|*.docx|" +
            //    "Документ Word 97-2003 (*.doc)|*.doc|" +
            //    "Текст в формате RTF (*.rtf)|*.rtf"
            //};
            //if (dialog.ShowDialog().Value) dialog.FileName
            WriteDoc(Struct, FileName);
        }

        private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            RichTextBox box = sender as RichTextBox;
            if (NAN(box) || NA(box.Tag))
                return;
            //RichText(box);
        }
        private void BSbSelect_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                Symbol.Source = SmbSelect.Source = Bmper(openFileDialog.FileName);
        }
        private void ToCase(object sender, RoutedEventArgs e)
        {
            NText.Selection.Text = NText.Selection.Text.ToString() == NText.Selection.Text.ToUpper().ToString()
                ? NText.Selection.Text.ToLower()
                : NText.Selection.Text.ToUpper();
        }
        private void CustomingText(object sender, RoutedEventArgs e)
        {
            MenuItemTemplating(sender as MenuItem, NText);
        }
        private void Numbers(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !numbers.IsMatch(e.Text);
        }
        private void Hours(object sender, TextChangedEventArgs e)
        {
            TextBox box = sender as TextBox;
            RejectCondition(box, (box.Text != "") && box.Text.Substring(0, 1) == "0");
        }
        private void RejectCondition(TextBox box, bool cond)
        {
            if (cond)
                box.Text = box.Text[1..];
        }
        private void Counting(object sender, RoutedEventArgs e)
        {
            NumbersBox(sender as Button, 1);
        }
        private void ResetLists(object sender, RoutedEventArgs e)
        {
            ListResetMethod(sender as Button);
        }
        
        private void Stepping(object sender, RoutedEventArgs e)
        {
            Button step = sender as Button;
            Grid form = step.Tag as Grid;
            StylesX(GetStyle("Steps2"), Step1, Step2, Step3, Step4, Step5);
            Styles(GetStyle("Steps"), step);
            AnyHideX(Form1, Form2, Form3, Form4, Form5);
            AnyShow(form);
        }
        private void DeleteLevel(object sender, RoutedEventArgs e)
        {
            Grid grid = (sender as Button).Parent as Grid;
            RemoveRun(grid.Tag);
            AutoIndexing(RemoveGrid(grid), 1, '.');
        }
        private void DeleteContents(object sender, RoutedEventArgs e)
        {
            Grid grid = ((Button)sender).Tag as Grid;
            RemoveRun(grid.Tag);
            AutoIndexing(RemoveGrid(grid), 1, '.');
        }
        private void AddLevel(object sender, RoutedEventArgs e)
        {
            TextContent(sender as Button, null).Click += DeleteContents;
        }
        private void AddContent(object sender, RoutedEventArgs e)
        {
            TableContent(sender as Button, null).Click += AnyDeleteAuto;
        }
        private void AddSources(object sender, RoutedEventArgs e)
        {
            ParagraphText(sender as Button, out Button delete, out Button add);
            add.Click += AddSource;
            delete.Click += DeleteSources;
        }
        private void AddSource(object sender, RoutedEventArgs e)
        {
            TextContent2(sender as Button, null).Click += DeleteSource;
        }
        private void AddListItem(object sender, RoutedEventArgs e)
        {
            TextContent3(sender as Button, null).Click += DeleteListItem;
        }
        private void AddListItem2(object sender, RoutedEventArgs e)
        {
            TextContent3(sender as Button, null).Click += DeleteListItem2;
        }
        private void DeleteSources(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Grid current = btn.Parent as Grid;
            StackPanel panel = current.Parent as StackPanel;
            panel.Children.Remove(current);
            RemoveParagraph(current.Tag);
        }
        private void DeleteSource(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Grid current = btn.Parent as Grid;
            StackPanel panel = current.Parent as StackPanel;
            panel.Children.Remove(current);
            RemoveRunLB(current.Tag);
            AutoIndexing(panel, 1, '.');
        }
        private void DeleteListItem(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Grid current = btn.Parent as Grid;
            StackPanel panel = current.Parent as StackPanel;
            panel.Children.Remove(current);
            RemoveListItem((current.Tag as ListItem).Tag);
            RemoveListItem(current.Tag);
            AutoIndexing(panel, 1, '.');
        }
        private void DeleteListItem2(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Grid current = btn.Parent as Grid;
            StackPanel panel = current.Parent as StackPanel;
            panel.Children.Remove(current);
            RemoveListItem(current.Tag);
            AutoIndexing(panel, 1, '.');
        }
        private void NewTypeContent(object sender, RoutedEventArgs e)
        {
            Button add = null, delete = null;
            TextBox hours = null;
            AutoDetectContentType(sender as Button, out hours, out delete, ref add);
            hours.TextChanged += Hours;
            hours.PreviewTextInput += Numbers;
            delete.Click += AnyDelete;
            if (add != null)
                add.Click += AddContent;
        }
        private void AnyDelete(object sender, RoutedEventArgs e)
        {
            Grid grid = (sender as Button).Tag as Grid;
            RemoveTableRow(grid.Tag);

            TextBox box = grid.Children[3] as TextBox;
            if (box != null && box.Tag != null)
            {
                Binding bind = box.Tag as Binding;
                TextBox refer = ((((grid.Parent as StackPanel).Parent as Grid).Parent as StackPanel).Parent as Grid).Children[3] as TextBox; ;
                MultiBinding old = BindingOperations.GetMultiBindingExpression(refer, BackgroundProperty).ParentMultiBinding;
                BindingOperations.ClearBinding(refer, BackgroundProperty);
                MultiBinding multi2 = new MultiBinding { Converter = new UsedValuesConverter() };

                foreach (Binding binding in old.Bindings)
                {
                    if (!bind.Equals(binding))
                        multi2.Bindings.Add(binding);
                }

                _ = SetBind(refer, BackgroundProperty, multi2);
            }

            _ = RemoveGrid(grid);
        }
        private void AnyDeleteAuto(object sender, RoutedEventArgs e)
        {
            Grid grid = (sender as Button).Tag as Grid;

            Binding bind = (grid.Children[3] as TextBox).Tag as Binding;
            TextBox refer = ((((((grid.Parent as StackPanel).Parent as Grid).Parent as StackPanel).Parent as Grid).Parent as StackPanel).Parent as Grid).Children[3] as TextBox; ;
            //throw new Exception(refer.Name);
            MultiBinding old = BindingOperations.GetMultiBindingExpression(refer, BackgroundProperty).ParentMultiBinding;
            BindingOperations.ClearBinding(refer, BackgroundProperty);
            MultiBinding multi2 = new MultiBinding { Converter = new UsedValuesConverter() };

            foreach (Binding binding in old.Bindings)
            {
                if (!bind.Equals(binding))
                    multi2.Bindings.Add(binding);
            }

            _ = SetBind(refer, BackgroundProperty, multi2);

            RemoveTableRow(grid.Tag); 
            AutoIndexing(RemoveGrid(grid), 1, '.');
        }
        private void DeleteThemeClick(object sender, RoutedEventArgs e)
        {
            Grid current = (sender as Button).Parent as Grid;
            StackPanel themes = current.Parent as StackPanel;
            DeleteSection(current);
            Grid section = themes.Parent as Grid;
            StackPanel sections = section.Parent as StackPanel;
            int optimization = sections.Children.IndexOf(section) + 1;
            AutoIndexing(themes, 1, '.', $"Тема {optimization}.");
        }
        private void DeleteTopicClick(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            StackPanel stack = btn.Tag as StackPanel;
            while(stack.Children.Count > 1)
                DeleteSection(stack.Children[0] as Grid);
            Grid current = btn.Parent as Grid;
            StackPanel sections = current.Parent as StackPanel;

            Label refer = (current.Children[3] as TextBox).Tag as Label;
            MultiBinding multi = BindingOperations.GetMultiBindingExpression(refer, ContentProperty).ParentMultiBinding;
            MultiBinding multi2 = new MultiBinding { Converter = new SumConverter() };

            for (int i = 0; i < multi.Bindings.Count; i++)
            {
                if (i == sections.Children.IndexOf(current))
                    continue;
                multi2.Bindings.Add(multi.Bindings[i]);
            }

            DeleteSection(current);
            AutoIndexing(sections, 1, '.', "Раздел ");
            for (int i = 0; i < sections.Children.Count - 1; i++)
            {
                Grid section = sections.Children[i] as Grid;
                StackPanel themes = section.Children[4] as StackPanel;
                int optimization = i + 1;
                AutoIndexing(themes, 1, '.', $"Тема {optimization}.");
            }
            
            _ = SetBind(refer, ContentProperty, multi2);
        }

        private void AddTopic(object sender, RoutedEventArgs e)
        {
            Grid topic = (sender as Button).Parent as Grid;
            NewTopic(AllSectionsContents, topic.Parent as StackPanel,
                out Button BTbutton, out Button Cadd, out Button NewTypeAdd,
                out Button deleteOmni, out Button addNew, out TextBox hours,
                (topic.Children[2] as TextBox).Text,
                (topic.Children[3] as TextBox).Text, TotalHoursUsed);
            BTbutton.Click += DeleteThemeClick;
            Cadd.Click += AddContent;
            NewTypeAdd.Click += NewTypeContent;
            deleteOmni.Click += DeleteTopicClick;
            addNew.Click += AddTheme;
            hours.TextChanged += Hours;
            hours.PreviewTextInput += Numbers;
        }
        private void AddTheme(object sender, RoutedEventArgs e)
        {
            Grid current = (sender as Button).Parent as Grid;
            StackPanel themes = current.Parent as StackPanel;
            themes.Children.Remove(current);
            NewTheme((current.Children[1] as Label).Content.ToString(), themes,
                AllSectionsContents, out Button BTbutton, out Button Cadd,
                out Button NewTypeAdd, (current.Children[2] as TextBox).Text,
                (current.Children[3] as TextBox).Text);
            BTbutton.Click += DeleteThemeClick;
            Cadd.Click += AddContent;
            NewTypeAdd.Click += NewTypeContent;
            themes.Children.Add(current);
            Grid section = themes.Parent as Grid;
            StackPanel sections = section.Parent as StackPanel;
            int optimization = sections.Children.IndexOf(section) + 1;
            AutoIndexing(themes, 1, '.', $"Тема {optimization}.");
        }
        
        private void SwitchSections(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            AnyHideX(AbilitiesAdd, KnowledgeAdd, TotalAdd);
            AnyShow(btn.Tag as Grid);
            EnableX(true, AbAdd, KnAdd, TtAdd);
            btn.IsEnabled = false;
        }
    }
}
