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
using System.ComponentModel;
using System.Runtime.CompilerServices;
using static Wisdom.Tests.TotalTest;

namespace Wisdom
{
    /// <summary>
    /// Логика взаимодействия для AddProg.xaml
    /// </summary>
    public partial class AddProg : Window
    {
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises this object's PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The property that has a new value.</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChangedEventArgs e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }
        #endregion


        private List<ComboBoxItem> _DisciplinesSelect = new List<ComboBoxItem>();

        public List<ComboBoxItem> DisciplinesSelect
        {
            get => _DisciplinesSelect;
            set
            {
                _DisciplinesSelect.Clear();
                _DisciplinesSelect.AddRange(value);
                TraceItems(_DisciplinesSelect);
                OnPropertyChanged();
                TraceItems(DpSelect);
                DpSelect.Items.Refresh();
            }
        }

        private int SpecNo => SpSelect.SelectedIndex;

        private void SetDisciplineSelect()
        {
            List<ComboBoxItem> reload = new List<ComboBoxItem>();
            for (byte i = 0; i < Disciplines[SpecNo].Count; i++)
                reload.Add(new ComboBoxItem { Content = Disciplines[SpecNo][i].Name });
            DisciplinesSelect = reload;
        }

        private string FileName => $@"{Program.Text}.docx";
        public AddProg()
        {
            InitializeComponent();
            DataContext = this;
            Form2.BindInclude(Max, Self);
        }
        
        private void ResetAllCompetetionFields(object sender, SelectionChangedEventArgs e)
        {
            ComboBox box = sender as ComboBox;
            SetDisciplineSelect();
            ProfessionName = Specialities[box.SelectedIndex].Name;
            Form2.SetGeneralCompetetions(box.SelectedIndex);
            Form2.SetProfessionalCompetetions(box.SelectedIndex);
            OrderDate.Text = "";
            OrderNo.Text = "";
        }

        private void SetPlan(int no)
        {
            Grid nextTopic = GridChild(DisciplinePlan, 0);
            List<HoursList<LevelsList<HashList<String2>>>> planTopic = Disciplines[SpecNo][no].Plan;
            SetTopics(planTopic, nextTopic);
        }

        //Topics
        private void SetTopics(List<HoursList<LevelsList<HashList<String2>>>> planTopic,
            Grid nextTopic)
        {
            TextBox topicName = Box(nextTopic, 2);
            TextBox topicHours = Box(nextTopic, 3);

            for (byte i = 0; i < planTopic.Count; i++)
            {
                topicName.Text = planTopic[i].Name;
                topicHours.Text = planTopic[i].Hours;
                TopicAdd2(nextTopic);

                Grid topic = GridChild(DisciplinePlan, i);
                StackPanel nextThemeGroup = Panel(topic, 4);

                //TraceChildren(topic);
                //Trace.WriteLine("Topic: " + i);
                HoursList<LevelsList<HashList<String2>>> topicTheme = planTopic[i];
                SetTheme(topicTheme, nextThemeGroup);
            }
        }
        //Themes
        private void SetTheme(HoursList<LevelsList<HashList<String2>>> topicTheme, StackPanel nextThemeGroup)
        {
            Grid nextTheme = GridChild(nextThemeGroup, 0);
            TextBox nextThemeName = Box(nextTheme, 2);
            TextBox nextThemeHours = Box(nextTheme, 3);
            ComboBox nextThemeLevel = Cbx(nextTheme, 5);

            for (byte ii = 0; ii < topicTheme.Values.Count; ii++)
            {
                nextThemeName.Text = topicTheme.Values[ii].Name;
                nextThemeHours.Text = topicTheme.Values[ii].Hours;
                nextThemeLevel.Text = topicTheme.Values[ii].Level;
                ThemeAdd(nextTheme);

                Grid theme = GridChild(nextThemeGroup, ii);
                StackPanel nextTasksGroup = Panel(theme, 6);

                //TraceChildren(theme);
                //Trace.WriteLine("Theme: " + ii);
                LevelsList<HashList<String2>> themeContent = topicTheme.Values[ii];
                SetThemeContent(themeContent, nextTasksGroup);
            }
        }

        //Content
        private void SetThemeContent(LevelsList<HashList<String2>> themeContent,
            StackPanel nextTasksGroup)
        {
            TraceChildren(nextTasksGroup);
            Grid nextTasks = GridChild(nextTasksGroup, 1);
            Button nextTasksAdd = Btn(nextTasks, 0);
            ComboBox nextTasksType = Cbx(nextTasks, 1);
            CheckBox nextTasksMultiplier = Chx(nextTasks, 2);

            for (byte iii = 0; iii < themeContent.Values.Count; iii++)
            {
                Trace.WriteLine("Content info/tasks: " + iii);
                HashList<String2> contentTasks = themeContent.Values[iii];
                if (themeContent.Values[iii].Name == "255")
                {
                    SetMaterial(contentTasks, nextTasksGroup);
                    return;
                }

                bool isLastTask = themeContent.Values[iii].Values.Count <= 1;
                nextTasksType.SelectedIndex = Ints(themeContent.Values[iii].Name);
                nextTasksMultiplier.IsChecked = !isLastTask;
                Button deleteAddedTasks = NewTypeContentTasks(nextTasksAdd);
                
                if (isLastTask)
                    SetTask(contentTasks, deleteAddedTasks);
                else
                    SetTasksGroup(contentTasks, deleteAddedTasks);
            }
        }

        //Content material
        private void SetMaterial(HashList<String2> contentTasks, StackPanel nextTasksGroup)
        {
            Grid content = GridChild(nextTasksGroup, 0);
            StackPanel contentStack = Panel(content, 4);

            Grid nextContent = GridChild(contentStack, 0);
            Button nextContentAdd = Btn(nextContent, 0);
            TextBox nextContentName = Box(nextContent, 2);
            TextBox nextContentHours = Box(nextContent, 3);

            for (byte iv = 0; iv < contentTasks.Values.Count; iv++)
            {
                nextContentName.Text = contentTasks.Values[iv].Name;
                nextContentHours.Text = contentTasks.Values[iv].Value;
                TableContent(nextContentAdd).Click += AnyDeleteAuto;
            }
            //TraceChildren(contentStack);
            //Trace.WriteLine("Content group");
        }

        //Content single task
        private void SetTask(HashList<String2> contentTasks, Button deleteAddedTasks)
        {
            Grid nextTask = Parent(deleteAddedTasks);
            TextBox nextTaskName = Box(nextTask, 2);
            TextBox nextTaskHours = Box(nextTask, 3);
            nextTaskName.Text = contentTasks.Values[0].Name;
            nextTaskHours.Text = contentTasks.Values[0].Value;
            //TraceChildren(nextTask);
            //Trace.WriteLine("Task");
        }

        //Content tasks group
        private void SetTasksGroup(HashList<String2> contentTasks, Button deleteAddedTasks)
        {
            Grid task = Parent(deleteAddedTasks);
            StackPanel taskStack = Panel(task, 4);

            Grid nextTask = GridChild(taskStack, 0);
            Button nextTaskAdd = Btn(nextTask, 0);
            TextBox nextTaskName = Box(nextTask, 2);
            TextBox nextTaskHours = Box(nextTask, 3);

            for (byte iv = 0; iv < contentTasks.Values.Count; iv++)
            {
                nextTaskName.Text = contentTasks.Values[iv].Name;
                nextTaskHours.Text = contentTasks.Values[iv].Value;
                TableContent(nextTaskAdd).Click += AnyDeleteAuto;
            }
            //TraceChildren(taskStack);
            //Trace.WriteLine("Task group");
        }

        private void SetSources(int no)
        {
            DeleteAllSources();
            Grid next = EducationSources.Children[0] as Grid;
            Button add = next.Children[0] as Button;
            ComboBox box = next.Children[1] as ComboBox;

            for (byte i = 0; i < Disciplines[SpecNo][no].Sources.Count; i++)
            {
                box.SelectedIndex = Ints(Disciplines[SpecNo][no].Sources[i].Name);
                ParagraphText(add, out Button delete2, out Button add2);
                add2.Click += AddSource;
                delete2.Click += DeleteSources;

                Grid subNext = EducationSources.Children[i] as Grid;
                StackPanel profComps = subNext.Children[2] as StackPanel;
                Grid subSubNext = profComps.Children[0] as Grid;

                Button subAdd = subSubNext.Children[0] as Button;
                TextBox name = subSubNext.Children[2] as TextBox;

                for (byte ii = 0; ii < Disciplines[SpecNo][no].Sources[i].Values.Count; ii++)
                {
                    name.Text = Disciplines[SpecNo][no].Sources[i].Values[ii];
                    Source(subAdd).Click += DeleteSource;
                }
            }
        }

        private void ResetAllDisciplineFields(object sender, SelectionChangedEventArgs e)
        {
            ComboBox box = sender as ComboBox;
            
            if (SpecNo < 0 || box.SelectedIndex < 0)
                return;
            DropAllTopics();
            //Disciplines
            //CollegeName = "";
            DisciplineBase discipline = Disciplines[SpecNo][box.SelectedIndex];
            DisciplineRelation1.Text = discipline.Relation;
            WorkAround1.Text = discipline.PracticePrepare;
            DisctanceEdu.Text = discipline.DistanceEducation;

            DisciplineName = discipline.Name;

            MaxHours = discipline.Hours.MaxHours;
            Self.Text = discipline.Hours.SelfHours;
            Usual.Text = discipline.Hours.EduHours;

            Form2.Prepare.Text = discipline.Hours.PracticePrepare;
            Form2.Lectures.Text = discipline.Hours.Lections;
            Form2.Practices.Text = discipline.Hours.Practice;
            Form2.Labs.Text = discipline.Hours.LabWorks;
            Form2.Controls.Text = discipline.Hours.ControlWs;
            Form2.Course.Text = discipline.Hours.CourseWs;

            SetSources(box.SelectedIndex);
            SetPlan(box.SelectedIndex);
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
        private List<HashList<string>> GetSources(StackPanel list, byte index, byte index2)
        {
            List<HashList<string>> sources = new List<HashList<string>>();
            int cnt = list.Children.Count - 1;
            for (byte i = 0; i < cnt; i++)
            {
                Grid source = GridChild(list, i);
                sources.Add(GetSource(source, index, index2));
            }
            return sources;
        }

        private HashList<string> GetSource(Grid grid, byte index, byte index2)
        {
            Label caption = Lab(grid, index);
            HashList<string> source = new HashList<string>(caption.Content.ToString());
            int optimum = index + 1;
            StackPanel sourceValues = Panel(grid, optimum);
            source.Values = GetSourceList(sourceValues, index2);
            return source;
        }
        private List<string> GetSourceList(StackPanel sourceValues, byte index)
        {
            List<string> list = new List<string>();
            int cnt = sourceValues.Children.Count - 1;
            for (byte i = 0; i < cnt; i++)
            {
                Grid element = GridChild(sourceValues, i);
                TextBox box = Box(element, index);
                list.Add(box.Text);
            }
            return list;
        }

        private String2 GetString2(Grid grid, byte nameNo, byte hoursNo)
        {
            TextBox nameBox = Box(grid, nameNo);
            TextBox hoursBox = Box(grid, hoursNo);
            string name = nameBox.Text;
            string value = hoursBox.Text;
            String2 string2 = new String2(name, value);
            return string2;
        }
        //2, 3
        //DisciplinePlan - Grid - StackPanel - Grid - StackPanel - Grid - StackPanel
        //Раздел 1. - Тема 1.1. - Содержание - 1.; 2. ...
        private List<String2> GetTasks(StackPanel panel, byte nameNo, byte hoursNo)
        {
            List<String2> list = new List<String2>();
            int cnt = panel.Children.Count - 1;
            for (byte i = 0; i < cnt; i++)
            {
                Grid element = GridChild(panel, i);
                list.Add(GetString2(element, nameNo, hoursNo));
            }
            return list;
        }
        //DisciplinePlan - Grid - StackPanel - Grid - StackPanel - Grid
        //Раздел 1. - Тема 1.1. - Практические работы/Контрольные работы...
        private HashList<String2> GetTaskGroup(Grid grid, byte captionNo, byte nameNo, byte hoursNo)
        {
            HashList<String2> source;
            Label caption = Lab(grid, captionNo);
            if (caption == null)
            {
                caption = Lab(grid, 1);
                source = new HashList<String2>(caption.Content.ToString());
                TextBox name = Box(grid, 2);
                TextBox hours = Box(grid, 3);
                String2 str2 = new String2(name.Text, hours.Text);
                source.Values = new List<String2>();
                source.Values.Add(str2);
            }
            else
            {
                source = new HashList<String2>(caption.Content.ToString());
                StackPanel panel2 = Panel(grid, 4);
                source.Values = GetTasks(panel2, nameNo, hoursNo);
            }
            return source;
        }
        //0
        //DisciplinePlan - Grid - StackPanel - Grid - StackPanel - Grid
        //Раздел 1. - Тема 1.1. - Содержание 
        private HashList<String2> GetMaterial(Grid grid, byte captionNo, byte nameNo, byte hoursNo)
        {
            HashList<String2> source;
            Label caption = Lab(grid, captionNo);
            source = new HashList<String2>(caption.Content.ToString());
            StackPanel panel2 = Panel(grid, 4);
            source.Values = GetTasks(panel2, nameNo, hoursNo);
            return source;
        }

        //2, 3
        //DisciplinePlan - Grid - StackPanel - Grid
        //Раздел 1. - Тема 1.1.
        private LevelsList<HashList<String2>> GetHours(Grid grid, byte nameNo, byte hoursNo,
            byte levelNo, byte contentCaptionNo, byte contentNameNo, byte contentHoursNo)
        { //byte index3, 
            TextBox caption = Box(grid, nameNo);
            TextBox hours = Box(grid, hoursNo);
            ComboBox level = Cbx(grid, levelNo);
            LevelsList<HashList<String2>> source = new LevelsList<HashList<String2>>(caption.Text, hours.Text, level.Text); // Exces
            int optimum = levelNo + 1;
            StackPanel panel2 = grid.Children[optimum] as StackPanel;
            int cnt = panel2.Children.Count - 1;
            Trace.WriteLine(contentCaptionNo);
            TraceChildren(grid);
            Grid content = GridChild(panel2, 0);
            Trace.WriteLine(0);
            TraceChildren(content);
            source.Values.Add(GetMaterial(content, contentCaptionNo, contentNameNo, contentHoursNo));
            for (byte i = 1; i < cnt; i++)
            {
                Grid tasks = GridChild(panel2, i);
                Trace.WriteLine(i);
                TraceChildren(tasks);
                source.Values.Add(GetTaskGroup(tasks, 3, contentNameNo, contentHoursNo));
            }
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

            PracticePrepare = Form2.Prepare.Text;
            Lections = Form2.Lectures.Text;
            Practice = Form2.Practices.Text;
            LabWorks = Form2.Labs.Text;
            ControlWs = Form2.Controls.Text;
            CourseWs = Form2.Course.Text;

            Order = new String2(OrderDate.Text, OrderNo.Text);
            GeneralCompetetions = ExtractCompetetions(Form2.TotalCompAddSpace, 1, 2);
            ProfessionalCompetetions = ExtractCompetetions2(Form2.ProfCompAddSpace, 1, 2);

            SourcesControl = GetSources(EducationSources, 1, 2);

            Applyment = GetSourceList(ApplyAddSpace, 2);

            Plan = GetAbsoleteList(DisciplinePlan, 2, 3, 2, 3, 5, 0, 2, 3);
            StudyLevels.Values = new List<string>();
            List<List<string>> levels = GetListFromElements3(Levels, 2, 4);
            for (byte i = 0; i < levels.Count; i++)
                StudyLevels.Add(levels[i][0], levels[i][1]);

            //CallWriter(FileName);
            WriteDoc();
        }

        private static readonly Regex _hours = new Regex("^([1-9]|[1-9]\\d\\d?)$");//v\\d
        private void Hours(object sender, TextCompositionEventArgs e)
        {
            TextBox box = e.OriginalSource as TextBox;
            string full = box.Text.Insert(box.CaretIndex, e.Text);
            e.Handled = !_hours.IsMatch(full);
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
            FrameworkElement form = step.Tag as FrameworkElement;
            Trace.WriteLine(step.Tag);
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
            StudyLevel(sender as Button).Click += DeleteLevel;
        }
        private void AddSource(object sender, RoutedEventArgs e)
        {
            Source(sender as Button).Click += DeleteSource;
        }
        
        private void AddContent(object sender, RoutedEventArgs e)
        {
            TableContent(sender as Button).Click += AnyDeleteAuto;
        }
        private void AddSources(object sender, RoutedEventArgs e)
        {
            ParagraphText(sender as Button, out Button delete, out Button add);
            add.Click += AddSource;
            delete.Click += DeleteSources;
        }
        
        private void AddMarkControls(object sender, RoutedEventArgs e)
        {
            //TextContent3(sender as Button).Click += DeleteListItem2;
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
            NewTypeContentTasks(sender as Button);
        }
        private Button NewTypeContentTasks(Button newContent)
        {
            Button add = null, delete = null;
            TextBox hours = null;
            AutoDetectContentType(newContent, out hours, out delete, ref add);
            hours.PreviewTextInput += Hours;
            delete.Click += AnyDelete;
            if (add != null)
                add.Click += AddContent;
            return delete;
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
            Button addTopic = sender as Button;
            TopicAdd(addTopic.Parent as Grid);
        }
        private void TopicAdd(Grid topic)
        {
            TextBox topicName = topic.Children[2] as TextBox;
            TextBox topicHours = topic.Children[3] as TextBox;

            NewTopic(AllSectionsContents, topic.Parent as StackPanel,
                out Button BTbutton, out Button Cadd, out Button NewTypeAdd,
                out Button deleteOmni, out Button addNew, out TextBox hours,
                topicName.Text, topicHours.Text, TotalHoursUsed, out ComboBox newThemeLevels, out ComboBox themeLevelsAdd);

            //Theme
            _ = SetBind(newThemeLevels, ComboBox.ItemsSourceProperty, FastBind(Levels, "Children", new CompetetionsConverter()));
            newThemeLevels.SelectionChanged += Levels_SelectionChanged;

            //Content
            _ = SetBind(themeLevelsAdd, ComboBox.ItemsSourceProperty, FastBind(Levels, "Children", new CompetetionsConverter()));
            themeLevelsAdd.SelectionChanged += Levels_SelectionChanged;

            Cadd.Click += AddContent;
            NewTypeAdd.Click += NewTypeContent;

            BTbutton.Click += DeleteThemeClick;
            addNew.Click += AddTheme;

            deleteOmni.Click += DeleteTopicClick;
            
            hours.PreviewTextInput += Hours;
        }
        private void TopicAdd2(Grid topic)
        {
            TextBox topicName = topic.Children[2] as TextBox;
            TextBox topicHours = topic.Children[3] as TextBox;

            NewTopic(AllSectionsContents, topic.Parent as StackPanel,
                out Button deleteOmni, out Button addNew, out TextBox hours,
                 TotalHoursUsed, out ComboBox themeLevelsAdd, topicName.Text, topicHours.Text);

            //Content
            _ = SetBind(themeLevelsAdd, ComboBox.ItemsSourceProperty, FastBind(Levels, "Children", new CompetetionsConverter()));
            themeLevelsAdd.SelectionChanged += Levels_SelectionChanged;

            addNew.Click += AddTheme;

            deleteOmni.Click += DeleteTopicClick;

            hours.PreviewTextInput += Hours;
        }
        private void AddTheme(object sender, RoutedEventArgs e)
        {
            Button addTheme = sender as Button;
            Grid theme = addTheme.Parent as Grid;
            ThemeAdd(theme);
        }

        private void ThemeAdd(Grid current)
        {
            StackPanel themes = Parent(current);
            themes.Children.Remove(current);
            Label themeNo = Lab(current, 1);
            TextBox themeName = Box(current, 2);
            TextBox themeHours = Box(current, 3);
            ComboBox themeLevel = Cbx(current, 5);
            NewTheme(themeNo.Content.ToString(), themes, AllSectionsContents,
                out Button deleteTheme, out Button addContent,
                out Button addNextTask, out ComboBox themeLevels,
                themeName.Text, themeHours.Text, themeLevel.Text);
            deleteTheme.Click += DeleteThemeClick;
            addContent.Click += AddContent;
            addNextTask.Click += NewTypeContent;
            Binding bindLevels = FastBind(Levels, "Children", new CompetetionsConverter());
            _ = SetBind(themeLevels, ItemsControl.ItemsSourceProperty, bindLevels);
            themeLevels.SelectionChanged += Levels_SelectionChanged;
            themes.Children.Add(current);
            Grid section = Parent(themes);
            StackPanel sections = Parent(section);
            int optimization = sections.Children.IndexOf(section) + 1;
            AutoIndexing(themes, 1, '.', $"Тема {optimization}.");
        }

        private void SwitchSections(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            AnyHideX(ThemePlan, LearnLevels);
            AnyShow(btn.Tag as Grid);
            EnableX(true, ThemePlanSwitch, LearnLevelsSwitch);
            btn.IsEnabled = false;
        }
    }
}
