using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using static Wisdom.Customing.BlockTemplates;
using static Wisdom.Customing.Decorators;
using static Wisdom.Writers.ResultRenderer;
using static Wisdom.Binds.EasyBindings;
using static Wisdom.Writers.Content;
using System;

namespace Wisdom
{
    /// <summary>
    /// Логика взаимодействия для AddProg.xaml
    /// </summary>
    public partial class AddProg : Window
    {
        private static readonly Regex numbers = new Regex("^[\\d]");
        private string FileName => $@"D:\Александр\Windows 7\misc\Надгробные плиты\C#\Wisdom\{Program.Text}.rtf";
        public AddProg()
        {
            InitializeComponent();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            WriteDoc(Struct, FileName);
        }

        private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            RichTextBox box = sender as RichTextBox;
            if (NAN(box) || NA(box.Tag))
                return;
            RichText(box);
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
            if ((box.Text != "") && (box.Text.Substring(0, 1) == "0"))
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
            Grid grid = (sender as Button).Tag as Grid;
            GridHideX(Form1, Form2, Form3);
            GridShow(grid);
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
        private void NewTypeContent(object sender, RoutedEventArgs e)
        {
            Button add = null, delete = null;
            TextBox hours = null;
            AutoDetectContentType(sender as Button, out hours, out delete, ref add);
            hours.TextChanged += Hours;
            hours.PreviewTextInput += Numbers;
            delete.Click += AnyDelete;
            if (add != null) add.Click += AddContent;
        }
        private void AnyDelete(object sender, RoutedEventArgs e)
        {
            Grid grid = ((Button)sender).Tag as Grid;
            RemoveTableRow(grid.Tag);
            _ = RemoveGrid(grid);
        }
        private void AnyDeleteAuto(object sender, RoutedEventArgs e)
        {
            Grid grid = ((Button)sender).Tag as Grid;
            RemoveTableRow(grid.Tag);
            AutoIndexing(RemoveGrid(grid), 1, '.');
        }
        private void DeleteThemeClick(object sender, RoutedEventArgs e)
        {
            DeleteSection((sender as Button).Parent as Grid);
        }
        private void DeleteTopicClick(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            StackPanel stack = btn.Tag as StackPanel;
            while(stack.Children.Count > 1)
                DeleteSection(stack.Children[0] as Grid);
            Grid current = btn.Parent as Grid;
            StackPanel sections = current.Parent as StackPanel;
            DeleteSection(current);
            AutoIndexing(sections, 1, '.', "Раздел ");
        }

        private void AddTopic(object sender, RoutedEventArgs e)
        {
            NewTopic(out Button BTbutton, out Button Cadd, out Button NewTypeAdd);
            BTbutton.Click += DeleteTopicClick;
            Cadd.Click += AddContent;
            NewTypeAdd.Click += NewTypeContent;
        }
    }
}
