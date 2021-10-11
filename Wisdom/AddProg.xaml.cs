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
            DataContext = this;
        }

        private void ResetAllCompetetionFields(object sender, SelectionChangedEventArgs e)
        {
            GeneralCompetetions = ExtractCompetetions(TotalCompAddSpace, 1, 2);
            ProfessionalCompetetions = ExtractCompetetions2(ProfCompAddSpace, 1, 2);
        }

        private void ResetAllDisciplineFields(object sender, SelectionChangedEventArgs e)
        {
            //ComboBox combobox = sender as ComboBox;
            CollegeName = "";
            DisciplineRelation = "";
            WorkAround = "";
            DistanceEducation = "";

            DisciplineName = "";
            ProfessionName = "";
            MaxHours = "";
            SelfHours = "";
            EduHours = "";

            PracticePrepare = "";
            Lections = "";
            Practice = "";
            LabWorks = "";
            ControlWs = "";
            CourseWs = "";

            OrderDate.Text = "";
            OrderNo.Text = "";

            DeleteAllSources();
            Trace.WriteLine("GOT IT");
            Plan = GetAbsoleteList(DisciplinePlan, 2, 3, 2, 3, 4, 0, 2, 3);

            //Plan
            DropAllTopics();
            //Levels
            
            DropAllLevels();
        }

        private List<HoursList<String2>> ExtractCompetetions(StackPanel panel,
            byte idNo, byte nameNo)
        {
            List<HoursList<String2>> list = new List<HoursList<String2>>();
            int cnt = panel.Children.Count - 1;
            for (byte i = 0; i < cnt; i++)
            {
                Grid element = panel.Children[i] as Grid;
                Label competetionNo = element.Children[idNo] as Label;
                TextBox competetionName = element.Children[nameNo] as TextBox;
                HoursList<String2> competetion = new HoursList<String2>
                    (competetionNo.Content.ToString(), competetionName.Text);
                for (int ii = nameNo + 1; ii < element.Children.Count; ii += 2)
                {
                    Label skillsName = element.Children[ii] as Label;
                    TextBox skillsDescription = element.Children[ii + 1] as TextBox;
                    competetion.Values.Add(new String2(skillsName.Content.ToString(),
                        skillsDescription.Text));
                }
                list.Add(competetion);
            }
            return list;
        }

        private List<HoursList<String2>> ExtractCompetetions2(StackPanel panel,
            byte idNo, byte nameNo)
        {
            List<HoursList<String2>> list = new List<HoursList<String2>>();
            for (byte i = 0; i < panel.Children.Count - 1; i++)
            {
                Grid item = panel.Children[i] as Grid;
                StackPanel competetion = item.Children[2] as StackPanel;
                list.AddRange(ExtractCompetetions(competetion, idNo, nameNo));
            }
            return list;
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
        private String2 GetString2(Grid grid, byte nameNo, byte hoursNo)
        {
            string name = (grid.Children[nameNo] as TextBox).Text;
            string value = (grid.Children[hoursNo] as TextBox).Text;
            String2 string2 = new String2(name, value);
            return string2;
        }
        //2, 3
        //DisciplinePlan - Grid - StackPanel - Grid - StackPanel - Grid - StackPanel
        //Раздел 1. - Тема 1.1. - Содержание - 1.; 2. ...
        private List<String2> GetListFromElements2(StackPanel panel, byte nameNo, byte hoursNo)
        {
            List<String2> list = new List<String2>();
            int cnt = panel.Children.Count - 1;
            for (byte i = 0; i < cnt; i++)
            {
                Grid element = panel.Children[i] as Grid;
                list.Add(GetString2(element, nameNo, hoursNo));
            }
            return list;
        }
        //0
        //DisciplinePlan - Grid - StackPanel - Grid - StackPanel - Grid
        //Раздел 1. - Тема 1.1. - Содержание 
        private HashList<String2> GetHashs(Grid grid, byte captionNo, byte nameNo, byte hoursNo)
        {
            HashList<String2> source = null;
            Label caption = grid.Children[captionNo] as Label;
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
                int optimum = captionNo + 4;
                source = new HashList<String2>(caption.Content.ToString());
                StackPanel panel2 = grid.Children[optimum] as StackPanel;
                source.Values = GetListFromElements2(panel2, nameNo, hoursNo);
            }            
            return source;
        }

        //2, 3
        //DisciplinePlan - Grid - StackPanel - Grid
        //Раздел 1. - Тема 1.1.
        private LevelsList<HashList<String2>> GetHours(Grid grid, byte nameNo, byte hoursNo,
            byte levelNo, byte contentCaptionNo, byte contentNameNo, byte contentHoursNo)
        { //byte index3, 
            TextBox caption = grid.Children[nameNo] as TextBox;
            TextBox hours = grid.Children[hoursNo] as TextBox;
            ComboBox level = grid.Children[levelNo] as ComboBox;
            LevelsList<HashList<String2>> source = new LevelsList<HashList<String2>>(caption.Text, hours.Text, level.Text); // Exces
            int optimum = levelNo + 1;
            StackPanel panel2 = grid.Children[optimum] as StackPanel;
            int cnt = panel2.Children.Count - 1;
            for (byte i = 0; i < cnt; i++)
                source.Values.Add(GetHashs(panel2.Children[i] as Grid, contentCaptionNo, contentNameNo, contentHoursNo));
            return source;
        }
        //2, 3
        //DisciplinePlan - Grid
        //Раздел 1.
        private HoursList<LevelsList<HashList<String2>>> GetHours2(Grid grid, byte topicNameNo, byte topicHoursNo,
            byte themeNameNo, byte themeHoursNo, byte themeLevelNo, byte contentCaptionNo, byte contentNameNo, byte contentHoursNo)
        { //byte index3, 
            TextBox caption = grid.Children[topicNameNo] as TextBox;
            TextBox hours = grid.Children[topicHoursNo] as TextBox;
            HoursList<LevelsList<HashList<String2>>> source = new HoursList<LevelsList<HashList<String2>>>(caption.Text, hours.Text);
            int optimum = topicHoursNo + 1;
            StackPanel panel2 = grid.Children[optimum] as StackPanel;
            int cnt = panel2.Children.Count - 1;
            for (byte i = 0; i < cnt; i++)
                source.Values.Add(GetHours(panel2.Children[i] as Grid, themeNameNo, themeHoursNo,
                    themeLevelNo, contentCaptionNo, contentNameNo, contentHoursNo));
            return source;
        }

        //2, 3, | 2, 3, 4, | 0, | 2, 3

        //2, 3, 2, 3, 0, 2, 3
        //DisciplinePlan
        private List<HoursList<LevelsList<HashList<String2>>>> GetAbsoleteList(StackPanel panel, byte topicNameNo, byte topicHoursNo,
            byte themeNameNo, byte themeHoursNo, byte themeLevelNo, byte contentCaptionNo, byte contentNameNo, byte contentHoursNo)
        {
            List<HoursList<LevelsList<HashList<String2>>>> source = new List<HoursList<LevelsList<HashList<String2>>>>();
            int cnt = panel.Children.Count - 1;
            for (byte i = 0; i < cnt; i++)
            {
                Grid grid = panel.Children[i] as Grid;
                source.Add(GetHours2(grid, topicNameNo, topicHoursNo, themeNameNo, themeHoursNo,
                    themeLevelNo, contentCaptionNo, contentNameNo, contentHoursNo));
            }   
            return source;
        }
        private void ProfessionalCompettionSectionAdd_Click(object sender, RoutedEventArgs e)
        {
            Button add = sender as Button;
            Grid next = add.Parent as Grid;
            Border border = next.Children[1] as Border;
            Label title = border.Child as Label;
            StackPanel comps = next.Parent as StackPanel;
            Button deleteSection = new Button();
            Button addCompettion = new Button();
            string no = comps.Children.Count.ToString();
            comps.Children.Remove(next);
            comps.Children.Add(ProfessionSection("ПК ", no, out deleteSection, out addCompettion));
            comps.Children.Add(next);
            title.Content = "ПК " + comps.Children.Count.ToString() + ".";
            deleteSection.Click += DeleteProfessional;
            addCompettion.Click += AddProfessionalCompetetion;
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

            Order = new String2(OrderDate.Text, OrderNo.Text);
            GeneralCompetetions = ExtractCompetetions(TotalCompAddSpace, 1, 2);
            ProfessionalCompetetions = ExtractCompetetions2(ProfCompAddSpace, 1, 2);

            SourcesControl = GetHashListFromElements(EducationSources, 1, 2);

            Applyment = GetListFromElements(ApplyAddSpace, 2);

            Plan = GetAbsoleteList(DisciplinePlan, 2, 3, 2, 3, 4, 0, 2, 3);
            StudyLevels.Values = new List<string>();
            List<List<string>> levels = GetListFromElements3(Levels, 2, 4);
            for (byte i = 0; i < levels.Count; i++)
                StudyLevels.Add(levels[i][0], levels[i][1]);

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
            StylesX(GetStyle("Steps2"), Step1, Step2, Step3, Step4, Step5, Step6);
            Styles(GetStyle("Steps"), step);
            AnyHideX(Form1, Form2, Form3, Form4, Form5, Form6);
            AnyShow(form);
        }
        private void DeleteLevel(object sender, RoutedEventArgs e)
        {
            Button addLevel = sender as Button;
            DropLevel(addLevel.Parent as Grid);
        }
        private void DropAllLevels()
        {
            while (Levels.Children.Count > 1)
                DropLevel(Levels.Children[0] as Grid);
        }
        private void DropLevel(Grid level)
        {
            RemoveRun(level.Tag);
            AutoIndexing(RemoveGrid(level), 1, '.');
        }

        private void Levels_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox combobox = sender as ComboBox;
            BindingExpression binding = BindingOperations.GetBindingExpression(combobox, ComboBox.ItemsSourceProperty);
            binding.UpdateTarget();
        }
        private void DeleteContents(object sender, RoutedEventArgs e)
        {
            Grid grid = ((Button)sender).Tag as Grid;
            RemoveRun(grid.Tag);
            AutoIndexing(RemoveGrid(grid), 1, '.');
        }
        private void AddLevel(object sender, RoutedEventArgs e)
        {
            TextContent(sender as Button, null).Click += DeleteLevel;
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
        private void AddTotalCompetetion(object sender, RoutedEventArgs e)
        {
            TextContent4(sender as Button).Click += DeleteListItem;
        }
        private void AddProfessionalCompetetion(object sender, RoutedEventArgs e)
        {
            TextContent5(sender as Button).Click += DeleteProfessionalItem;
        }
        private void AddListItem2(object sender, RoutedEventArgs e)
        {
            TextContent3(sender as Button, null).Click += DeleteListItem2;
        }
        private void DeleteAllSources()
        {
            while (EducationSources.Children.Count > 1)
                DeleteSourceGroup(EducationSources.Children[0] as Grid);
        }
        private void DeleteSources(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Grid current = btn.Parent as Grid;
            DeleteSourceGroup(current);
        }
        private void DeleteSourceGroup(Grid sourceGroupGrid)
        {
            StackPanel panel = sourceGroupGrid.Parent as StackPanel;
            panel.Children.Remove(sourceGroupGrid);
            RemoveParagraph(sourceGroupGrid.Tag);
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
            string prefix = "ОК ";
            AutoIndexing2(panel, 1, "", prefix);
        }
        private void DeleteProfessionalItem(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Grid current = btn.Parent as Grid;
            StackPanel items = current.Parent as StackPanel;
            Grid section = items.Parent as Grid;

            Border border = section.Children[1] as Border;
            Label title = border.Child as Label;
            StackPanel panel = current.Parent as StackPanel;
            panel.Children.Remove(current);
            string prefix = title.Content.ToString();
            AutoIndexing(panel, 1, "", prefix);
        }

        private void DeleteProfessional(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Grid current = btn.Parent as Grid;
            //Border border = current.Children[1] as Border;
            //Label title = border.Child as Label;
            StackPanel panel = current.Parent as StackPanel;
            panel.Children.Remove(current);
            string prefix = "ПК ";
            AutoIndexingBorder(panel, 1, '.', prefix);
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
            Grid subContent = (sender as Button).Tag as Grid;
            Binding bind = (subContent.Children[3] as TextBox).Tag as Binding;

            StackPanel contentStack = subContent.Parent as StackPanel;
            Grid content = contentStack.Parent as Grid;
            StackPanel themeStack = content.Parent as StackPanel;
            Grid theme = themeStack.Parent as Grid;

            //Trace.WriteLine(refer.Name);
            //Trace.WriteLine(refer.Text);
            //Trace.WriteLine(refer.Background);
            //Trace.WriteLine(BindingOperations.GetMultiBindingExpression(refer, Control.BackgroundProperty));

            TextBox refer = theme.Children[3] as TextBox;
            MultiBinding old = BindingOperations.GetMultiBindingExpression(refer, BackgroundProperty).ParentMultiBinding;
            BindingOperations.ClearBinding(refer, BackgroundProperty);
            MultiBinding multi2 = new MultiBinding { Converter = new UsedValuesConverter() };

            foreach (Binding binding in old.Bindings)
            {
                if (!bind.Equals(binding))
                    multi2.Bindings.Add(binding);
            }

            _ = SetBind(refer, BackgroundProperty, multi2);

            RemoveTableRow(subContent.Tag); 
            AutoIndexing(RemoveGrid(subContent), 1, '.');
        }
        private void DeleteThemeClick(object sender, RoutedEventArgs e)
        {
            Grid current = (sender as Button).Parent as Grid;
            StackPanel themes = current.Parent as StackPanel;
            Grid topic = themes.Parent as Grid;
            TextBox refer = topic.Children[3] as TextBox;
            //Trace.WriteLine(refer.Name);
            //Trace.WriteLine(refer.Text);
            //Trace.WriteLine(refer.Background);
            //Trace.WriteLine(topic.Tag);
            MultiBinding multi = BindingOperations.GetMultiBindingExpression(refer, BackgroundProperty).ParentMultiBinding;
            BindingOperations.ClearBinding(refer, BackgroundProperty);
            MultiBinding multi2 = new MultiBinding { Converter = new SumConverter() };

            for (int i = 0; i < multi.Bindings.Count; i++)
            {
                if (i == themes.Children.IndexOf(current))
                    continue;
                multi2.Bindings.Add(multi.Bindings[i]);
            }
            _ = SetBind(refer, BackgroundProperty, multi2);

            DeleteSection(current);
            Grid section = themes.Parent as Grid;
            StackPanel sections = section.Parent as StackPanel;
            int optimization = sections.Children.IndexOf(section) + 1;
            AutoIndexing(themes, 1, '.', $"Тема {optimization}.");
        }
        private void DropAllTopics()
        {
            while (DisciplinePlan.Children.Count > 1)
            {
                Grid topic = DisciplinePlan.Children[0] as Grid;
                DropTopic(topic.Children[0] as Button, topic);
            }
        }
        private void DropTopic(Button deleteTopic, Grid topic)
        {
            StackPanel stack = deleteTopic.Tag as StackPanel;
            while (stack.Children.Count > 1)
                DeleteSection(stack.Children[0] as Grid);
            StackPanel sections = topic.Parent as StackPanel;

            Label refer = (topic.Children[3] as TextBox).Tag as Label;
            MultiBinding multi = BindingOperations.GetMultiBindingExpression(refer, ContentProperty).ParentMultiBinding;
            MultiBinding multi2 = new MultiBinding { Converter = new SumConverter() };

            for (int i = 0; i < multi.Bindings.Count; i++)
            {
                if (i == sections.Children.IndexOf(topic))
                    continue;
                multi2.Bindings.Add(multi.Bindings[i]);
            }

            DeleteSection(topic);
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
        private void DeleteTopicClick(object sender, RoutedEventArgs e)
        {
            Button deleteTopic = sender as Button;
            DropTopic(deleteTopic, deleteTopic.Parent as Grid);
        }

        private void AddTopic(object sender, RoutedEventArgs e)
        {
            Grid topic = (sender as Button).Parent as Grid;
            TextBox topicName = topic.Children[2] as TextBox;
            TextBox topicHours = topic.Children[3] as TextBox;
            NewTopic(AllSectionsContents, topic.Parent as StackPanel,
                out Button BTbutton, out Button Cadd, out Button NewTypeAdd,
                out Button deleteOmni, out Button addNew, out TextBox hours,
                topicName.Text, topicHours.Text, TotalHoursUsed, out ComboBox newThemeLevels, out ComboBox themeLevelsAdd);
            SetBind(newThemeLevels, ComboBox.ItemsSourceProperty, FastBind(Levels, "Children", new CompetetionsConverter()));
            newThemeLevels.SelectionChanged += Levels_SelectionChanged;
            SetBind(themeLevelsAdd, ComboBox.ItemsSourceProperty, FastBind(Levels, "Children", new CompetetionsConverter()));
            themeLevelsAdd.SelectionChanged += Levels_SelectionChanged;
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
            Label themeNo = current.Children[1] as Label;
            TextBox themeName = current.Children[2] as TextBox;
            TextBox themeHours = current.Children[3] as TextBox;
            ComboBox themeLevel = current.Children[4] as ComboBox;
            NewTheme(themeNo.Content.ToString(), themes, AllSectionsContents,
                out Button BTbutton, out Button Cadd, out Button NewTypeAdd, out ComboBox themeLevelsAdd,
                themeName.Text, themeHours.Text, themeLevel.Text);
            BTbutton.Click += DeleteThemeClick;
            Cadd.Click += AddContent;
            NewTypeAdd.Click += NewTypeContent;
            SetBind(themeLevelsAdd, ComboBox.ItemsSourceProperty, FastBind(Levels, "Children", new CompetetionsConverter()));
            themeLevelsAdd.SelectionChanged += Levels_SelectionChanged;
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
            AnyHideX(TotalCompetetions, ProfCompetetions);
            AnyShow(btn.Tag as Grid);
            EnableX(true, TotalComp, ProfComp);
            btn.IsEnabled = false;
        }
    }
}
