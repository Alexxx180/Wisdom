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
using System.Diagnostics;
using static Wisdom.Customing.ResourceHelper;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Data;
using Wisdom.Binds;
using Microsoft.Win32;
using static Wisdom.Model.ProgramContent;
using System.Collections.Generic;
using Wisdom.Model;

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
        

        private List<string> GetListFromElements(StackPanel panel, byte index)
        {
            List<string> list = new List<string>();
            int cnt = panel.Children.Count - 1;
            for (byte i = 0; i < cnt; i++)
            {
                Grid element = panel.Children[i] as Grid;
                TextBox box = element.Children[index] as TextBox;
                list.Add(box.Text);
            }
            return list;
        }
        private List<List<string>> GetListFromElements3(StackPanel panel, byte rangeStart, byte rangeEnd)
        {
            List<List<string>> list = new List<List<string>>();
            int cnt = panel.Children.Count - 1;
            for (byte i = 0; i < cnt; i++)
            {
                list.Add(new List<string>());
                Grid element = panel.Children[i] as Grid;
                for (byte ii = rangeStart; ii < rangeEnd; ii++)
                {
                    TextBox box = element.Children[ii] as TextBox;
                    list[i].Add(box.Text);
                }
            }
            return list;
        }
        private List<HashList<string>> GetHashListFromElements(StackPanel panel, byte index, byte index2)
        {
            List<HashList<string>> sources = new List<HashList<string>>();
            int cnt = panel.Children.Count - 1;
            for (byte i = 0; i < cnt; i++)
                sources.Add(GetHashs(panel.Children[i] as Grid, index, index2));
            return sources;
        }

        private HashList<string> GetHashs(Grid grid, byte index, byte index2)
        {
            Label caption = grid.Children[index] as Label; //1
            HashList<string> source = new HashList<string>(caption.Content.ToString());
            int optimum = index + 1;
            StackPanel panel2 = grid.Children[optimum] as StackPanel;
            source.Values = GetListFromElements(panel2, index2);
            return source;
        }
        private String2 GetString2(Grid grid, byte no1, byte no2)
        {
            string name = (grid.Children[no1] as TextBox).Text;
            string value = (grid.Children[no2] as TextBox).Text;
            String2 string2 = new String2(name, value);
            return string2;
        }
        //2, 3
        //DisciplinePlan - Grid - StackPanel - Grid - StackPanel - Grid - StackPanel
        //Раздел 1. - Тема 1.1. - Содержание - 1.; 2. ...
        private List<String2> GetListFromElements2(StackPanel panel, byte no1, byte no2)
        {
            List<String2> list = new List<String2>();
            int cnt = panel.Children.Count - 1;
            for (byte i = 0; i < cnt; i++)
            {
                Grid element = panel.Children[i] as Grid;
                list.Add(GetString2(element, no1, no2));
            }
            return list;
        }
        //0
        //DisciplinePlan - Grid - StackPanel - Grid - StackPanel - Grid
        //Раздел 1. - Тема 1.1. - Содержание 
        private HashList<String2> GetHashs(Grid grid, byte index, byte index2, byte index3)
        {
            HashList<String2> source = null;
            Label caption = grid.Children[index] as Label;
            if (caption == null)
            {
                caption = grid.Children[1] as Label;
                source = new HashList<String2>(caption.Content.ToString());
                String2 str2 = new String2((grid.Children[2] as TextBox).Text, (grid.Children[3] as TextBox).Text);
                source.Values = new List<String2>();
                source.Values.Add(str2);
            }
            else
            {
                int optimum = index + 4;
                source = new HashList<String2>(caption.Content.ToString());
                StackPanel panel2 = grid.Children[optimum] as StackPanel;
                source.Values = GetListFromElements2(panel2, index2, index3);
            }            
            return source;
        }


        //2, 3
        //DisciplinePlan - Grid - StackPanel - Grid
        //Раздел 1. - Тема 1.1.
        private LevelsList<HashList<String2>> GetHours(Grid grid,
            byte index, byte index2, byte index4, byte index5, byte index6)
        { //byte index3, 
            TextBox caption = grid.Children[index] as TextBox;
            TextBox hours = grid.Children[index2] as TextBox;
            LevelsList<HashList<String2>> source = new LevelsList<HashList<String2>>(caption.Text, hours.Text, ""); // Exces
            int optimum = index2 + 1;
            StackPanel panel2 = grid.Children[optimum] as StackPanel;
            int cnt = panel2.Children.Count - 1;
            for (byte i = 0; i < cnt; i++)
                source.Values.Add(GetHashs(panel2.Children[i] as Grid, index4, index5, index6));
            return source;
        }
        //2, 3
        //DisciplinePlan - Grid
        //Раздел 1.
        private HoursList<LevelsList<HashList<String2>>> GetHours2(Grid grid,
            byte index, byte index2, byte index4, byte index5, byte index6, byte index7, byte index8)
        { //byte index3, 
            TextBox caption = grid.Children[index] as TextBox;
            TextBox hours = grid.Children[index2] as TextBox;
            HoursList<LevelsList<HashList<String2>>> source = new HoursList<LevelsList<HashList<String2>>>(caption.Text, hours.Text);
            int optimum = index2 + 1;
            StackPanel panel2 = grid.Children[optimum] as StackPanel;
            int cnt = panel2.Children.Count - 1;
            for (byte i = 0; i < cnt; i++)
                source.Values.Add(GetHours(panel2.Children[i] as Grid, index4, index5, index6, index7, index8));
            return source;
        }

        //2, 3, 2, 3, 0, 2, 3
        //DisciplinePlan
        private List<HoursList<LevelsList<HashList<String2>>>> GetAbsoleteList(StackPanel panel,
            byte index, byte index2, byte index4, byte index5, byte index6, byte index7, byte index8)
        {
            List<HoursList<LevelsList<HashList<String2>>>> source = new List<HoursList<LevelsList<HashList<String2>>>>();
            int cnt = panel.Children.Count - 1;
            for (byte i = 0; i < cnt; i++)
            {
                Grid grid = panel.Children[i] as Grid;
                source.Add(GetHours2(grid, index, index2, index4, index5, index6, index7, index8));
            }   
            return source;
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            CollegeName = College.Text;
            DisciplineRelation = DisciplineRelation1.Text;
            WorkAround = WorkAround1.Text;
            DistanceEducation = DisctanceEdu.Text;

            DisciplineName = DpSelect.Text;
            ProfessionName = SpSelect.Text;
            MaxHours = Max.Content.ToString();
            SelfHours = Self.Text;
            EduHours = Usual.Text;

            PracticePrepare = Prepare.Text;
            Lections = Lectures.Text;
            Practice = Practices.Text;
            LabWorks = Labs.Text;
            ControlWs = Controls.Text;
            CourseWs = Course.Text;

            ShallCan = GetListFromElements(SkillsAddSpace, 2);
            ShallKnow = GetListFromElements(KnowledgeAddSpace, 2);
            TotalCompetetion = GetListFromElements(TotalAddSpace, 2);

            EducationControl = GetListFromElements(EducationAddSpace, 2);
            MarkControl = GetListFromElements(MarkControlAddSpace, 2);
            SourcesControl = GetHashListFromElements(EducationSources, 1, 2);

            Applyment = GetListFromElements(ApplyAddSpace, 2);

            Plan = GetAbsoleteList(DisciplinePlan, 2, 3, 2, 3, 0, 2, 3);
            StudyLevels.Values = new List<string>();
            List<List<string>> levels = GetListFromElements3(Levels, 2, 4);
            for (byte i = 0; i < levels.Count; i++)
                StudyLevels.Add(levels[i][0], levels[i][1]);

            //Сложная система вложенностей:
            //Разделы -> Темы -> Типы работ
            //List< HoursList< HoursList< HashList<String2> > > > Plan = List< HoursList< HoursList< HashList<String2> > > >();


            //Usual.Text
            //SaveFileDialog dialog = new SaveFileDialog
            //{
            //    FileName = FileName,
            //    Filter =
            //    "Документ Microsoft Word (*.docx)|*.docx|" +
            //    "Документ Word 97-2003 (*.doc)|*.doc|" +
            //    "Текст в формате RTF (*.rtf)|*.rtf"
            //};
            //if (dialog.ShowDialog().Value)
            //    WriteDoc(dialog.FileName); 
            WriteDoc();
        }

        private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            RichTextBox box = sender as RichTextBox;
            if (NAN(box) || NA(box.Tag))
                return;
            //RichText(box);
        }
        /*private void BSbSelect_Click(object sender, RoutedEventArgs e)
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
        }*/
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
            StylesX(GetStyle("Steps2"), Step1, Step2, Step3, Step4, Step5, Step6);
            Styles(GetStyle("Steps"), step);
            AnyHideX(Form1, Form2, Form3, Form4, Form5, Form6);
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
            //Error
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
