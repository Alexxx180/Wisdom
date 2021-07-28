using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.Xml;
using System.Windows.Markup;
using System.IO;
using System.Text.RegularExpressions;
//using Xceed.Words.NET;
//using Xceed.Document.NET;

//using Microsoft.Office.Interop.Word;

namespace Wisdom
{
    /// <summary>
    /// Логика взаимодействия для AddProg.xaml
    /// </summary>
    public partial class AddProg : System.Windows.Window
    {
        private static readonly Regex numbers = new Regex("^[\\d]");
        public AddProg()
        {
            InitializeComponent();
            //NLab = Paragraph;
            //NLab.Inlines.Clear();
            //NLab.Inlines.Add(new TextRange(NText.Document.ContentStart, NText.Document.ContentEnd).Text);
            
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            string fileName = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\Wisdom\test.rtf";
            //using (FileStream fs = new FileStream(@"D:\Александр\Windows 7\misc\Надгробные плиты\C#\Wisdom\test.rtf", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            //{
            //    TextRange textRange = new TextRange(Struct.ContentStart, Struct.ContentEnd);
            //    textRange.Save(fs, DataFormats.Rtf);
            //}

            //Microsoft.Office.Interop.Word.Document doc = new Microsoft.Office.Interop.Word.Document();
            //doc.WordOpenXML.
            //Microsoft.Office.Interop.Word.Section section = (Microsoft.Office.Interop.Word.Section)textRange;
            //doc.Sections.Add(section);
            //doc.Sections.Add(Sheet2);
            //doc.Sections.Add(Sheet3);
            //doc.Sections.Add(Sheet4);
            //doc.Sections.Add(Sheet5);
            //doc.Sections.Add(Sheet6);
            //doc.Sections.Add(Sheet7);
            //doc.SaveAs2(@"D:\Александр\Windows 7\misc\Надгробные плиты\C#\Wisdom\test.docx");
            //Xceed.Words.NET.DocX doc = Xceed.Words.NET.DocX.Create(@"D:\Александр\Windows 7\misc\Надгробные плиты\C#\Wisdom\test.docx");
            //Xceed.Document.NET.Document doc = null;
            //doc.InsertDocument(doc);
            //Xceed.Document.NET.Section section = null;
            //section.InsertSection();
            //section.Xml
            //doc.Xml.Add(Struct);
            //doc.SaveAs(@"D:\Александр\Windows 7\misc\Надгробные плиты\C#\Wisdom\test.docx");
            //Xceed.Document.NET.Section

            //MemoryStream stream = new MemoryStream();
            //DocX document = DocX.Create(stream);
            //Xceed.Document.NET.Paragraph p = document.InsertParagraph();
            //p.Append("Hello World");

            //document.Save();

            //System.IO.
            //return File(stream, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "DOCHK.docx");
            //using FileStream fs = File.Open(@"D:\Александр\Windows 7\misc\Надгробные плиты\C#\Wisdom\test.doc", FileMode.Create);


            //Method 1
            //IDocumentPaginatorSource source = Struct;
            //TextRange content = new TextRange(Struct.ContentStart, Struct.ContentEnd);

            //if (content.CanSave(DataFormats.Rtf))
            //{
            //    using FileStream fs = File.Open(fileName, FileMode.Create);
            //    content.Save(fs, DataFormats.Rtf, true);
            //}

            //Method 2
            //using FileStream fs = File.Open(@"D:,ent, fs);
            //    MessageBox.Show("Файл сохранен");

            //Method 3
            //using (FileStream fs = File.Create(fileName))
            //{
            //    using (BinaryWriter binWriter = new BinaryWriter(fs))
            //    {
            //        //binWriter.Write(true);
            //        binWriter.Write(XamlWriter.Save(Struct));
            //    }
            //}
            //Method 4
            //try
            //{
            //    IDocumentPaginatorSource source = Struct;
            //    Stream file = File.Create(fileName);
            //    TextWriter writer = new StreamWriter(file);
            //    XmlTextWriter xmlWriter = new XmlTextWriter(writer);

            //    XamlDesignerSerializationManager xamlManager = new XamlDesignerSerializationManager(xmlWriter);
            //    XamlWriter.Save(source, xamlManager);
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            //                      BreakPageBefore="True"
            /*string searchPattern = @"}{\qj"; //
            //bool firstPage = true; // No pagebreak on the first page
            List<long> linesReadList = new List<long>(10);
            // open the file for writing
            using (MemoryStream stream = new MemoryStream())
            {
                // create a textrange and save it to the memory stream;
                TextRange content = new TextRange(Struct.ContentStart, Struct.ContentEnd);
                //if (content.CanSave(DataFormats.Rtf))
                content.Save(stream, DataFormats.Rtf, true);
                StreamReader memoryReader = new StreamReader(stream);
                stream.Seek(0, SeekOrigin.Begin);
                StreamWriter writer = new StreamWriter(fileName);
                string line;
               // string lines = "";
                // Read and display lines from the file until the end of
                // the file is reached.
                //throw new Exception(memoryReader.ReadLine());
                while ((line = memoryReader.ReadLine()) != null)
                {
                    if (line.Contains(searchPattern))
                    {
                        // if not on the first page write a pagebreak
                        //if (!firstPage)
                        writer.WriteLine("\\page");
                        //throw new Exception("-YEAH-");
                        //lines += "\n\\page\n";
                        //firstPage = false;
                    }
                    //throw new Exception("-SUCCESS-");
                    writer.WriteLine(line);
                   // lines += line;
                }
                writer.Close();
                memoryReader.Close();
            }*/
        }

        private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //if (NA(NText1) || NA(NText2) || NA(Cell0))
            RichTextBox box = sender as RichTextBox;
            if (NAN(box) || NA(box.Tag))
                return;
            if (box.Tag.GetType() == typeof(TableCell))
            {
                TableCell cl = box.Tag as TableCell;
                cl.Blocks.Clear();
                System.Windows.Documents.Section sec = BoxXaml(box);
                while (sec.Blocks.Count > 0)
                    cl.Blocks.Add(sec.Blocks.FirstBlock);
            }
            else if (box.Tag.GetType() == typeof(System.Windows.Documents.List))
            {
                System.Windows.Documents.List cl = box.Tag as System.Windows.Documents.List;
                cl.ListItems.Clear();
                System.Windows.Documents.List lst = box.Document.Blocks.FirstBlock as System.Windows.Documents.List;
                foreach (ListItem item in lst.ListItems)
                    if (item.ToString() != "")
                        cl.ListItems.Add(item);
            }
        }
        private System.Windows.Documents.Section BoxXaml(RichTextBox box)
        {
            TextRange range = new TextRange(box.Document.ContentStart, box.Document.ContentEnd);
            MemoryStream stream = new MemoryStream();
            range.Save(stream, DataFormats.Xaml);
            string xamlText = Encoding.UTF8.GetString(stream.ToArray());

            StringReader stringReader = new StringReader(xamlText);
            XmlReader xmlReader = XmlReader.Create(stringReader);
            return XamlReader.Load(xmlReader) as System.Windows.Documents.Section;
        }
        
        private bool NAN(UIElement element)
        {
            return element == null;
        }
        private bool NAN(FrameworkElement element)
        {
            return element == null;
        }
        private bool NA(System.Windows.Documents.Run run)
        {
            return run == null;
        }
        private bool NA(object o)
        {
            return o == null;
        }
        private bool NA(System.Windows.Documents.Paragraph run)
        {
            return run == null;
        }
        private bool NA(TableCell run)
        {
            return run == null;
        }
        private String getSelectedValue(ComboBox cbx) { return ((ComboBoxItem)cbx.SelectedItem).Content.ToString(); }
        private BitmapImage Bmper(String path) { return new BitmapImage(new Uri(path, UriKind.RelativeOrAbsolute)); }
        private void DpSelect_SelectionChanged(object sender, SelectionChangedEventArgs e) { DpRep.Text = getSelectedValue(DpSelect); }
        private void SpSelect_SelectionChanged(object sender, SelectionChangedEventArgs e) { SpRep.Text = getSelectedValue(SpSelect); }
        private void BSbSelect_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                Symbol.Source = SmbSelect.Source = Bmper(openFileDialog.FileName);
        }
        private void ToCase(object sender, RoutedEventArgs e)
        {
            if (NText.Selection.Text.ToString() == NText.Selection.Text.ToUpper().ToString())
                NText.Selection.Text = NText.Selection.Text.ToLower();
            else
                NText.Selection.Text = NText.Selection.Text.ToUpper();
        }
        private void CustomingText(object sender, RoutedEventArgs e)
        {
            MenuItem item = sender as MenuItem;
            DependencyProperty[] dps = new DependencyProperty[] { TextElement.FontWeightProperty, TextElement.FontStyleProperty, TextBlock.TextDecorationsProperty };
            int p = Ints(item.Tag);
            object[] obs = { item.FontWeight, item.FontStyle, TextDecorations.Underline };
            object[] cls = { FontWeights.Normal, FontStyles.Normal, null };
            NText.Selection.ApplyPropertyValue(dps[p], NText.Selection.GetPropertyValue(dps[p]).Equals(obs[p]) ? cls[p] : obs[p]);
        }
        private Int32 Ints(object o)
        {
            return Convert.ToInt32(o);
        }
        private bool Bool(object o)
        {
            return Convert.ToBoolean(o);
        }
        private void Numbers(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !numbers.IsMatch(e.Text);
        }
        private void Hours(object sender, TextChangedEventArgs e)
        {
            TextBox box = sender as TextBox;
            string s = box.Text;
            if ((s != "") && (s.Substring(0, 1) == "0"))
                box.Text = s.Substring(1);
            if (int.TryParse(Usual.Text, out int actual) && int.TryParse(Self.Text, out int self))
                Max.Content = ""+(actual + self);
        }
        private void Counting(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            StackPanel stp = btn.Parent as StackPanel;
            TextBox box = stp.Tag as TextBox;
            int p = Ints(btn.Tag.ToString());
            if (box.Text == "")
            {
                box.Text = "1";
                return;
            }
            int i = Ints(box.Text) + p;
            box.Text = i>0 ? (i < 999 ? i.ToString() : "1") : "999";
        }
        private void ResetLists(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            RichTextBox txt = btn.Tag as RichTextBox;
            System.Windows.Documents.List list = new System.Windows.Documents.List(new ListItem());
            txt.Document.Blocks.Clear();
            txt.Document.Blocks.Add(list);
        }
        private void GridHide(Grid grid)
        {
            grid.Visibility = Visibility.Hidden;
            grid.IsEnabled = false;
        }
        private void GridShow(Grid grid)
        {
            grid.Visibility = Visibility.Visible;
            grid.IsEnabled = true;
        }
        private void GridHideX(params Grid[] grids)
        {
            foreach (Grid grid in grids) GridHide(grid);
        }
        private void Stepping(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Grid grid = btn.Tag as Grid;
            GridHideX(Form1, Form2);
            GridShow(grid);
        }
        private void DeleteLevel(object sender, RoutedEventArgs e)
        {
            Grid grid = ((Button)sender).Tag as Grid;
            Run run = grid.Tag as Run;
            LevelsText.Inlines.Remove(run);
            Levels.Children.Remove(grid);
            grid = null;
            for (int no=0;no<Levels.Children.Count;no++)
                ((Label)((Grid)Levels.Children[no]).Children[1]).Content = (no+1) + ".";
        }
        private void AddLevel(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Grid grid = new Grid();
            ColumnDefinition col = new ColumnDefinition();
            col.Width = new GridLength(0.05, GridUnitType.Star);
            grid.ColumnDefinitions.Add(col);
            ColumnDefinition col2 = new ColumnDefinition();
            col2.Width = new GridLength(0.15, GridUnitType.Star);
            grid.ColumnDefinitions.Add(col2);
            ColumnDefinition col3 = new ColumnDefinition();
            col3.Width = new GridLength(0.3, GridUnitType.Star);
            grid.ColumnDefinitions.Add(col3);
            ColumnDefinition col4 = new ColumnDefinition();
            col4.Width = new GridLength(0.5, GridUnitType.Star);
            grid.ColumnDefinitions.Add(col4);
            string[] txts = new string[] { ((TextBox)NextLevel.Children[2]).Text, ((TextBox)NextLevel.Children[3]).Text };
            Button btn2 = new Button
            {
                Background = new SolidColorBrush(Color.FromArgb(255, 255, 42, 42)),
                Foreground = new SolidColorBrush(Colors.White),
                BorderBrush = new SolidColorBrush(Colors.Black),
                FontFamily = new FontFamily("Gill Sans MT"),
                FontSize = 26,
                Content = "X",
                Tag = grid
            };
            btn2.Click += DeleteLevel;
            Label lab1 = new Label
            {
                Content = Levels.Children.Count + ".",
                FontSize = 26,
                HorizontalContentAlignment = HorizontalAlignment.Right
            };
            TextBox txt1 = new TextBox
            {
                Text = txts[0],
                FontSize = 26
            };
            TextBox txt2 = new TextBox
            {
                Text = txts[1],
                FontSize = 26
            };
            Binding bind1 = new Binding
            {
                Source = lab1,
                Path = new PropertyPath("Content")
            };
            Binding bind2 = new Binding
            {
                Source = txt1,
                Path = new PropertyPath("Text")
            };
            Binding bind3 = new Binding
            {
                Source = txt2,
                Path = new PropertyPath("Text")
            };
            MultiBinding multi = new MultiBinding();
            multi.Bindings.Add(bind1);
            multi.Bindings.Add(bind2);
            multi.Bindings.Add(bind3);
            multi.Converter = new LevelsConverter();
            Run run2 = new Run();
            BindingOperations.SetBinding(run2, Run.TextProperty, multi);
            LevelsText.Inlines.Add(run2);
            grid.Children.Add(btn2);
            grid.Children.Add(lab1);
            grid.Children.Add(txt1);
            grid.Children.Add(txt2);
            lab1.SetValue(Grid.ColumnProperty, 1);
            txt1.SetValue(Grid.ColumnProperty, 2);
            txt2.SetValue(Grid.ColumnProperty, 3);
            grid.Tag = run2;
            Levels.Children.Remove(NextLevel);
            Levels.Children.Add(grid);
            ((Label)NextLevel.Children[1]).Content = (Levels.Children.Count + 1) + ".";
            Levels.Children.Add(NextLevel);
            auto++;
        }
        private int auto = 4;
    }
}
