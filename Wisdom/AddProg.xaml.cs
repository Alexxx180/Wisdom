using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Text.RegularExpressions;
using static Wisdom.Customing.Decorators;
using static Wisdom.Writers.ResultRenderer;
using static Wisdom.Binds.EasyBindings;
using static Wisdom.Writers.Content;
using static Wisdom.Customing.Converters;
using static Wisdom.Customing.ResourceHelper;
using System.Windows.Data;
using Wisdom.Binds;
using static Wisdom.Model.ProgramContent;
using System.Collections.Generic;
using Wisdom.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using static Wisdom.AutoGenerating.AutoWriter;
using Wisdom.Model.DataBase;
using static Wisdom.Tests.TotalTest;
using System.Diagnostics;
using System;
using Wisdom.Controls;

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

        private int SpecNo => SpSelect.SelectedIndex;

        private List<ComboBoxItem> _DisciplinesSelect = new List<ComboBoxItem>();

        public List<ComboBoxItem> DisciplinesSelect
        {
            get => _DisciplinesSelect;
            set
            {
                _DisciplinesSelect.Clear();
                _DisciplinesSelect.AddRange(value);
                OnPropertyChanged();
                DpSelect.Items.Refresh();
            }
        }

        private List<ComboBoxItem> _SpecialitySelect = new List<ComboBoxItem>();

        public List<ComboBoxItem> SpecialitySelect
        {
            get => _SpecialitySelect;
            set
            {
                _SpecialitySelect.Clear();
                _SpecialitySelect.AddRange(value);
                OnPropertyChanged();
                SpSelect.Items.Refresh();
            }
        }

        private List<uint> specialityIDs = new List<uint>();

        private void SetSpecialitySelect()
        {
            specialityIDs.Clear();
            List<object[]> specialities = MySql.SpecialitiesList();
            List<ComboBoxItem> reload = new List<ComboBoxItem>();
            for (byte i = 0; i < specialities.Count; i++)
            {
                specialityIDs.Add(UInts(specialities[i][0]));
                reload.Add(new ComboBoxItem {
                    Content = specialities[i][1] +
                    " " + specialities[i][2]
                });
            }
                
            SpecialitySelect = reload;

            //List <ComboBoxItem> reload = new List<ComboBoxItem>();
            //for (byte i = 0; i < Specialities.Length; i++)
            //    reload.Add(new ComboBoxItem { Content = Specialities[i].Name });
            //SpecialitySelect = reload;
        }

        private List<uint> disciplineIDs = new List<uint>();

        private void SetDisciplineSelect()
        {
            disciplineIDs.Clear();
            List<object[]> disciplines = MySql.DisciplinesList(specialityIDs[SpecNo]);
            List<ComboBoxItem> reload = new List<ComboBoxItem>();
            for (byte i = 0; i < disciplines.Count; i++)
            {
                disciplineIDs.Add(UInts(disciplines[i][0]));
                reload.Add(new ComboBoxItem
                {
                    Content = disciplines[i][1] +
                    " " + disciplines[i][2]
                });
            }

            DisciplinesSelect = reload;

            //List<ComboBoxItem> reload = new List<ComboBoxItem>();
            //for (byte i = 0; i < Disciplines[SpecNo].Count; i++)
            //    reload.Add(new ComboBoxItem { Content = Disciplines[SpecNo][i].Name });
            //DisciplinesSelect = reload;
        }

        private string FileName => $@"{Program.Text}.docx";
        MySQL MySql = new MySQL();

        private void SetMetaTypes()
        {
            MetaTypes = new List<String2>();
            List<object[]> types = MySql.MetaTypes();
            for(byte i = 0; i < types.Count; i++)
                MetaTypes.Add(new String2(
                    types[i][0].ToString(),
                    types[i][1].ToString()));
            MetaData.Children.Clear();
            MetaElement.AddElements(MetaTypes, MetaData);
        }

        private void ResetTotalHourBinds()
        {
            MultiBinding multiCount = TruncateMulti(Inputted, ContentProperty, new SumConverter());
            for (byte i = 0; i < TotalHoursCount.Children.Count; i++)
            {
                HourElement hour = TotalHoursCount.Children[i] as HourElement;
                Grid hourGrid = hour.Content as Grid;
                TextBox hourValue = Box(hourGrid, 1);
                Binding bindHours = FastBind(hourValue, "Text");
                multiCount.Bindings.Add(bindHours);
            }
            SetBind(Inputted, ContentProperty, multiCount);
        }

        private void SetHourTypes()
        {
            HourTypes = new List<String2>();
            List<object[]> types = MySql.WorkTypes();
            for (byte i = 0; i < types.Count; i++)
                HourTypes.Add(new String2(
                    types[i][0].ToString(),
                    types[i][1].ToString()));
            TotalHoursCount.Children.Clear();
            HourElement.AddElements(HourTypes, TotalHoursCount);
            ResetTotalHourBinds();
        }

        public AddProg()
        {
            InitializeComponent();
            DataContext = this;
            SetMetaTypes();
            SetHourTypes();
            SetSpecialitySelect();
        }
        private void DropAllProfessional()
        {
            while (ProfCompAddSpace.Children.Count > 1)
                DropProfessionalTopic(ProfCompAddSpace.Children[0] as Grid);
        }
        private void DropAllGeneral()
        {
            while (TotalCompAddSpace.Children.Count > 1)
                DropGeneral(TotalCompAddSpace.Children[0] as Grid);
        }
        private void DeleteGeneralCompetetion(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            DropGeneral(btn.Parent as Grid);
        }
        private void DropGeneral(Grid generalCompetetion)
        {
            StackPanel panel = generalCompetetion.Parent as StackPanel;
            panel.Children.Remove(generalCompetetion);
            string prefix = "ОК ";
            AutoIndexing2(panel, 1, "", prefix);
        }
        private void AddTotalCompetetion(object sender, RoutedEventArgs e)
        {
            GeneralCompetetion(sender as Button).Click += DeleteGeneralCompetetion;
        }
        private void DeleteProfessional(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            DropProfessionalTopic(btn.Parent as Grid);
        }
        private void DeleteProfessionalItem(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            DropProfessional(btn.Parent as Grid);
        }
        private void DropProfessional(Grid profCompetetion)
        {
            StackPanel items = profCompetetion.Parent as StackPanel;
            Grid section = items.Parent as Grid;

            Border border = section.Children[1] as Border;
            Label title = border.Child as Label;
            StackPanel panel = profCompetetion.Parent as StackPanel;
            panel.Children.Remove(profCompetetion);
            string prefix = title.Content.ToString();
            AutoIndexing(panel, 1, "", prefix);
        }
        private void DropProfessionalTopic(Grid profCompetetionTopic)
        {
            StackPanel panel = profCompetetionTopic.Parent as StackPanel;
            panel.Children.Remove(profCompetetionTopic);
            string prefix = "ПК ";
            AutoIndexingBorder(panel, 1, '.', prefix);
        }
        private void AddProfessionalCompetetion(object sender, RoutedEventArgs e)
        {
            ProfessionalCompetetion(sender as Button).Click += DeleteProfessionalItem;
        }
        private void ProfessionalCompettionSectionAdd_Click(object sender, RoutedEventArgs e)
        {
            Button add = sender as Button;
            ProfessionalSectionAdd(add);
        }
        private void ProfessionalSectionAdd(Button add)
        {
            Grid next = Parent(add);
            Border border = Border(next, 1);
            Label title = Child(border);
            StackPanel comps = Parent(next);
            Button deleteSection = new Button();
            Button addCompettion = new Button();
            string no = comps.Children.Count.ToString();
            Grid competetion = ProfessionSection("ПК ", no, out deleteSection, out addCompettion);
            Restack(comps, next, competetion);
            title.Content = "ПК " + comps.Children.Count.ToString() + ".";
            deleteSection.Click += DeleteProfessional;
            addCompettion.Click += AddProfessionalCompetetion;
        }

        public void SetProfessionalCompetetions()
        {
            DropAllProfessional();
            Grid next = GridChild(ProfCompAddSpace, 0);
            Button add = Btn(next, 0);

            List<List<HoursList<String2>>> profCompetetions = SelectedSpeciality.ProfessionalCompetetions;
            for (byte i = 0; i < profCompetetions.Count; i++)
            {
                ProfessionalSectionAdd(add);
                Grid subNext = GridChild(ProfCompAddSpace, i);
                StackPanel profComps = Panel(subNext, 2);
                Grid subSubNext = GridChild(profComps, 0);

                Button subAdd = Btn(subSubNext, 0);
                TextBox name = Box(subSubNext, 2);

                List<HoursList<String2>> profCompetetionSection = profCompetetions[i];
                for (byte ii = 0; ii < profCompetetionSection.Count; ii++)
                {
                    HoursList<String2> profCompetetion = profCompetetionSection[ii];
                    Button delete = ProfessionalCompetetion(subAdd);
                    Grid current = Parent(delete);
                    TextBox experience = Box(current, 4);
                    TextBox skills = Box(current, 6);
                    TextBox knowledge = Box(current, 8);
                    delete.Click += DeleteProfessionalItem;
                    name.Text = profCompetetion.Hours;
                    experience.Text = profCompetetion.Values[0].Value;
                    skills.Text = profCompetetion.Values[1].Value;
                    knowledge.Text = profCompetetion.Values[2].Value;
                }
            }
        }
        public void SetGeneralCompetetions()
        {
            DropAllGeneral();
            Grid next = GridChild(TotalCompAddSpace, 0);
            Button add = Btn(next, 0);

            TextBox name = Box(next, 2);
            List<HoursList<String2>> totalCompetetions = SelectedSpeciality.GeneralCompetetions;
            for (byte i = 0; i < totalCompetetions.Count; i++)
            {
                HoursList<String2> totalCompetetion = totalCompetetions[i];
                Button delete = GeneralCompetetion(add);
                Grid current = Parent(delete);
                TextBox skills = Box(current, 4);
                TextBox knowledge = Box(current, 6);
                name.Text = totalCompetetion.Hours;
                delete.Click += DeleteGeneralCompetetion;
                skills.Text = totalCompetetion.Values[0].Value;
                knowledge.Text = totalCompetetion.Values[1].Value;
            }
        }

        private void ResetAllCompetetionFields(object sender, SelectionChangedEventArgs e)
        {
            ComboBox box = sender as ComboBox;
            int selected = box.SelectedIndex;
            string name = box.SelectedItem.ToString();
            if (selected < 0)
                return;
            SelectedSpeciality = MySql.GetSpeciality(specialityIDs[selected], name);
            SetDisciplineSelect();
            ProfessionName = SelectedSpeciality.Name;
            SetGeneralCompetetions();
            SetProfessionalCompetetions();
            OrderDate.Text = "";
            OrderNo.Text = "";
        }

        private void SetPlan()
        {
            Grid nextTopic = GridChild(DisciplinePlan, 0);
            List<HoursList<LevelsList<HashList<String2>>>> planTopic = SelectedDiscipline.Plan;
            TestData(planTopic);
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
            TextBox nextThemeCompetetions = Box(nextTheme, 4);
            ComboBox nextThemeLevel = Cbx(nextTheme, 5);

            for (byte ii = 0; ii < topicTheme.Values.Count; ii++)
            {
                nextThemeName.Text = topicTheme.Values[ii].Name;
                nextThemeHours.Text = topicTheme.Values[ii].Hours;
                nextThemeLevel.Text = topicTheme.Values[ii].Level;
                nextThemeCompetetions.Text = topicTheme.Values[ii].Competetions;
                ThemeAdd(nextTheme);

                Grid theme = GridChild(nextThemeGroup, ii);
                StackPanel nextTasksGroup = Panel(theme, 6);
                LevelsList<HashList<String2>> themeContent = topicTheme.Values[ii];
                SetThemeContent(themeContent, nextTasksGroup);
            }
        }

        //Content
        private void SetThemeContent(LevelsList<HashList<String2>> themeContent,
            StackPanel nextTasksGroup)
        {
            Grid nextTasks = GridChild(nextTasksGroup, 1);
            Button nextTasksAdd = Btn(nextTasks, 0);
            ComboBox nextTasksType = Cbx(nextTasks, 1);
            CheckBox nextTasksMultiplier = Chx(nextTasks, 2);

            for (byte iii = 0; iii < themeContent.Values.Count; iii++)
            {
                HashList<String2> contentTasks = themeContent.Values[iii];
                if (contentTasks.Name == "Содержание")
                {
                    SetMaterial(contentTasks, nextTasksGroup);
                    continue;
                }

                bool isLastTask = contentTasks.Values.Count <= 1;
                nextTasksType.SelectedIndex = WorkTypes[contentTasks.Name];
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
                TableContent(nextContentAdd, out TextBox hours).Click += AnyDeleteAuto;
                hours.PreviewTextInput += Hours;
                DataObject.AddPastingHandler(hours, PastingHours);
            }
        }

        //Content single task
        private void SetTask(HashList<String2> contentTasks, Button deleteAddedTasks)
        {
            Grid nextTask = Parent(deleteAddedTasks);
            TextBox nextTaskName = Box(nextTask, 2);
            TextBox nextTaskHours = Box(nextTask, 3);
            nextTaskName.Text = contentTasks.Values[0].Name;
            nextTaskHours.Text = contentTasks.Values[0].Value;
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
                TableContent(nextTaskAdd, out TextBox hours).Click += AnyDeleteAuto;
                hours.PreviewTextInput += Hours;
                DataObject.AddPastingHandler(hours, PastingHours);
            }
        }

        private void SetSources()
        {
            DeleteAllSources();
            Grid next = GridChild(EducationSources, 0);
            Button add = Btn(next, 0);
            ComboBox box = Cbx(next, 1);
            for (byte i = 0; i < SelectedDiscipline.Sources.Count; i++)
            {
                box.SelectedIndex = Ints(SelectedDiscipline.Sources[i].Name);
                ParagraphText(add, out Button delete2, out Button add2);
                add2.Click += AddSource;
                delete2.Click += DeleteSources;

                Grid subNext = GridChild(EducationSources, i);
                StackPanel profComps = Panel(subNext, 2);
                Grid subSubNext = GridChild(profComps, 0);

                Button subAdd = Btn(subSubNext, 0);
                TextBox name = Box(subSubNext, 2);

                HashList<string> disciplineSources = SelectedDiscipline.Sources[i];
                for (byte ii = 0; ii < disciplineSources.Values.Count; ii++)
                {
                    name.Text = disciplineSources.Values[ii];
                    Source(subAdd).Click += DeleteSource;
                }
            }
        }

        private void ResetAllDisciplineFields(object sender, SelectionChangedEventArgs e)
        {
            ComboBox box = sender as ComboBox;
            int selected = box.SelectedIndex;
            if (SpecNo < 0 || selected < 0)
                return;
            string name = box.SelectedValue.ToString();

            DropAllTopics();
            SelectedDiscipline = MySql.GetDiscipline(disciplineIDs[selected], name);

            for (byte i = 0; i < MetaData.Children.Count; i++)
            {
                MetaElement meta = MetaData.Children[i] as MetaElement;
                Grid metaGrid = meta.Content as Grid;
                TextBlock metaName = Txt(metaGrid, 0);
                TextBox metaValue = Box(metaGrid, 1);
                if (SelectedDiscipline.MetaData.TryGetValue(metaName.Text, out string value))
                    metaValue.Text = value;
                else
                    metaValue.Text = "";
                MetaDataCollection[i] = metaValue.Text;
            }

            DisciplineName = SelectedDiscipline.Name;

            int study = GetStudyHours();
            int self = 0;
            if (SelectedDiscipline.TotalHours.TryGetValue("Самостоятельная работа", out ushort max))
                self = max;
            MaxHours = (study + self).ToString();
            Self.Text = self.ToString();
            Usual.Text = study.ToString();

            for (byte i = 0; i < TotalHoursCount.Children.Count; i++)
            {
                HourElement hour = TotalHoursCount.Children[i] as HourElement;
                Grid hourGrid = hour.Content as Grid;
                TextBlock hourName = Txt(hourGrid, 0);
                TextBox hourValue = Box(hourGrid, 1);
                hourValue.Text = TryGetHours(hourName.Text).ToString();
                HoursCollection[i] = hourValue.Text;
            }
            
            SetSources();
            SetPlan();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            DirectorName = Director.Text;
            SubDirectorName = SubDirector.Text;
            SubManagerName = SubManager.Text;

            CollegeName = College.Text;

            DisciplineName = DpSelect.Text;
            ProfessionName = SpSelect.Text;
            MaxHours = Max.Content.ToString();
            SelfHours = Self.Text;
            EduHours = Usual.Text;

            Order = new String2(OrderDate.Text, OrderNo.Text);
            GeneralCompetetions = ExtractCompetetions(TotalCompAddSpace, 1, 2);
            ProfessionalCompetetions = ExtractCompetetions2(ProfCompAddSpace, 1, 2);

            SourcesControl = GetSources(EducationSources, 1, 2);

            Applyment = GetSourceList(ApplyAddSpace, 2);

            //Topics| Themes      | Content
            //2, 3, | 2, 3, 4, 5, | 0, | 2, 3
            Plan = GetAbsoleteList(DisciplinePlan, 2, 3, 2, 3, 4, 5, 0, 2, 3);
            StudyLevels.Values = new List<string>();
            List<List<string>> levels = GetListFromElements3(Levels, 2, 4);
            for (byte i = 0; i < levels.Count; i++)
                StudyLevels.Add(levels[i][0], levels[i][1]);

            CallWriter(FileName);
            //WriteDoc();
        }

        private static readonly Regex _hours = new Regex("^([1-9]|[1-9]\\d\\d?)$");//v\\d
        private void Hours(object sender, TextCompositionEventArgs e)
        {
            TextBox box = e.OriginalSource as TextBox;
            string full = box.Text.Insert(box.CaretIndex, e.Text);
            e.Handled = !_hours.IsMatch(full);
        }
        private static string GetProposedText(TextBox textBox, string newText)
        {
            var text = textBox.Text;

            if (textBox.SelectionStart != -1)
            {
                text = text.Remove(textBox.SelectionStart, textBox.SelectionLength);
            }

            text = text.Insert(textBox.CaretIndex, newText);

            return text;
        }
        private void PastingHours(object sender, DataObjectPastingEventArgs e)
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
            StylesX(GetStyle("Steps2"), Step1, Step2, Step3, Step4, Step5, Step6);
            Styles(GetStyle("Steps"), step);
            AnyHideX(Form1, Form2, Form3, Form4, Form5, Form6);
            AnyShow(form);
        }
        private void DeleteLevel(object sender, RoutedEventArgs e)
        {
            Button addLevel = sender as Button;
            Grid level = Parent(addLevel);
            DropLevel(level);
        }
        private void DropLevel(Grid level)
        {
            RemoveRun(level.Tag);
            AutoIndexing(RemoveGrid(level), 1, '.');
        }

        private void Levels_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox combobox = sender as ComboBox;
            BindingExpression binding = GetBindExpress(combobox, ComboBox.ItemsSourceProperty);
            binding.UpdateTarget();
        }
        private void DeleteContents(object sender, RoutedEventArgs e)
        {
            Button dropTask = sender as Button;
            Grid grid = dropTask.Tag as Grid;
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
            Button addNext = sender as Button;
            TableContent(addNext, out TextBox hours).Click += AnyDeleteAuto;
            hours.PreviewTextInput += Hours;
            DataObject.AddPastingHandler(hours, PastingHours);
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
            {
                Grid source = GridChild(EducationSources, 0);
                DeleteSourceGroup(source);
            }
        }
        private void DeleteSources(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Grid current = Parent(btn);
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
            Grid current = Parent(btn);
            StackPanel panel = Parent(current);
            panel.Children.Remove(current);
            RemoveRunLB(current.Tag);
            AutoIndexing(panel, 1, '.');
        }
        private void DeleteListItem2(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Grid current = Parent(btn);
            StackPanel panel = Parent(current);
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
            DataObject.AddPastingHandler(hours, PastingHours);
            delete.Click += AnyDelete;
            if (add != null)
                add.Click += AddContent;
            return delete;
        }
        private void AnyDelete(object sender, RoutedEventArgs e)
        {
            Button dropContent = sender as Button;
            Grid content = dropContent.Tag as Grid;
            RemoveTableRow(content.Tag);

            TextBox box = content.Children[3] as TextBox;
            if (box != null && box.Tag != null)
            {
                Binding bind = box.Tag as Binding;

                StackPanel contentGroup = Parent(content);
                Grid theme = Parent(contentGroup);
                StackPanel themeStack = Parent(theme);
                Grid topic = Parent(themeStack);
                TextBox referHours = Box(topic, 3);

                MultiBinding reCalculation = DeleteBindFromMulti(referHours,
                    BackgroundProperty, new UsedValuesConverter(), bind);

                _ = SetBind(referHours, BackgroundProperty, reCalculation);
            }

            _ = RemoveGrid(content);
        }


        private void AnyDeleteAuto(object sender, RoutedEventArgs e)
        {
            Button deleteButton = sender as Button;
            Grid subContent = deleteButton.Tag as Grid;
            TextBox hours = Box(subContent, 3);
            Binding bind = hours.Tag as Binding;

            StackPanel contentStack = Parent(subContent);
            Grid content = Parent(contentStack);
            StackPanel themeStack = Parent(content);
            Grid theme = Parent(themeStack);

            TextBox refer = Box(theme, 3);
            MultiBinding reCalculation = DeleteBindFromMulti(refer, 
                BackgroundProperty, new UsedValuesConverter(), bind);

            _ = SetBind(refer, BackgroundProperty, reCalculation);

            RemoveTableRow(subContent.Tag);
            AutoIndexing(RemoveGrid(subContent), 1, '.');
        }
        private void DeleteThemeClick(object sender, RoutedEventArgs e)
        {
            Button delete = sender as Button;
            Grid current = Parent(delete);
            StackPanel themes = Parent(current);
            Grid topic = Parent(themes);
            TextBox refer = Box(topic, 3);

            MultiBinding reCalculation = DeleteElemFromMulti(refer,
                BackgroundProperty, new SumConverter(), current, themes);

            _ = SetBind(refer, BackgroundProperty, reCalculation);

            DeleteSection(current);
            Grid section = Parent(themes);
            StackPanel sections = Parent(section);
            int optimization = sections.Children.IndexOf(section) + 1;
            AutoIndexing(themes, 1, '.', $"Тема {optimization}.");
        }
        private void DropAllTopics()
        {
            while (DisciplinePlan.Children.Count > 1)
            {
                Grid topic = GridChild(DisciplinePlan, 0);
                Button dropButton = Btn(topic, 0);
                DropTopic(dropButton, topic);
            }
        }
        private void DropTopic(Button deleteTopic, Grid topic)
        {
            StackPanel stack = deleteTopic.Tag as StackPanel;
            while (stack.Children.Count > 1)
            {
                Grid theme = GridChild(stack, 0);
                DeleteSection(theme);
            }    
            StackPanel sections = Parent(topic);
            TextBox hours = Box(topic, 3);
            
            Label refer = hours.Tag as Label;

            MultiBinding reCalculation = DeleteElemFromMulti(refer,
                ContentProperty, new SumConverter(), topic, sections);

            //MultiBinding multi = GetMulti(refer, ContentProperty);
            //MultiBinding multi2 = new MultiBinding { Converter = new SumConverter() };

            //for (int i = 0; i < multi.Bindings.Count; i++)
            //{
            //    if (i == sections.Children.IndexOf(topic))
            //        continue;
            //    multi2.Bindings.Add(multi.Bindings[i]);
            //}

            _ = SetBind(refer, ContentProperty, reCalculation);

            DeleteSection(topic);
            AutoIndexing(sections, 1, '.', "Раздел ");
            for (int i = 0; i < sections.Children.Count - 1; i++)
            {
                int optimization = i + 1;
                Grid section = GridChild(sections, i);
                StackPanel themes = Panel(section, 4);
                AutoIndexing(themes, 1, '.', $"Тема {optimization}.");
            }
            //reCalculation
            
        }
        private void DeleteTopicClick(object sender, RoutedEventArgs e)
        {
            Button deleteTopic = sender as Button;
            Grid topic = Parent(deleteTopic);
            DropTopic(deleteTopic, topic);
        }

        private void AddTopic(object sender, RoutedEventArgs e)
        {
            Button addTopic = sender as Button;
            Grid nextTopic = Parent(addTopic);
            TopicAdd(nextTopic);
        }
        private void TopicAdd(Grid topic)
        {
            TextBox topicName = Box(topic, 2);
            TextBox topicHours = Box(topic, 3);
            StackPanel topicStack = Parent(topic);

            NewTopic(AllSectionsContents, topicStack, out Button BTbutton,
                out Button Cadd, out Button NewTypeAdd, out Button deleteOmni,
                out Button addNew, out TextBox nextThemehours,
                topicName.Text, topicHours.Text, TotalHoursUsed,
                out ComboBox newThemeLevels, out ComboBox themeLevelsAdd,
                out TextBox themeHours, out TextBox contentHours,
                out TextBox hours);

            //Theme
            _ = SetBind(newThemeLevels, ComboBox.ItemsSourceProperty,
                FastBind(Levels, "Children", new CompetetionsConverter()));
            newThemeLevels.SelectionChanged += Levels_SelectionChanged;

            //Content
            _ = SetBind(themeLevelsAdd, ComboBox.ItemsSourceProperty,
                FastBind(Levels, "Children", new CompetetionsConverter()));
            themeLevelsAdd.SelectionChanged += Levels_SelectionChanged;

            Cadd.Click += AddContent;
            NewTypeAdd.Click += NewTypeContent;

            BTbutton.Click += DeleteThemeClick;
            addNew.Click += AddTheme;

            deleteOmni.Click += DeleteTopicClick;

            hours.PreviewTextInput += Hours;
            DataObject.AddPastingHandler(hours, PastingHours);
            themeHours.PreviewTextInput += Hours;
            DataObject.AddPastingHandler(themeHours, PastingHours);
            nextThemehours.PreviewTextInput += Hours;
            DataObject.AddPastingHandler(nextThemehours, PastingHours);
            contentHours.PreviewTextInput += Hours;
            DataObject.AddPastingHandler(contentHours, PastingHours);
        }
        private void TopicAdd2(Grid topic)
        {
            TextBox topicName = Box(topic, 2);
            TextBox topicHours = Box(topic, 3);
            StackPanel topicStack = Parent(topic);

            NewTopic(AllSectionsContents, topicStack,
                out Button deleteOmni, out Button addNew, out TextBox themeHours,
                 TotalHoursUsed, out ComboBox themeLevelsAdd, topicName.Text,
                 topicHours.Text, out TextBox hours);

            //Content
            _ = SetBind(themeLevelsAdd, ComboBox.ItemsSourceProperty, 
                FastBind(Levels, "Children", new CompetetionsConverter()));
            themeLevelsAdd.SelectionChanged += Levels_SelectionChanged;

            addNew.Click += AddTheme;

            deleteOmni.Click += DeleteTopicClick;

            hours.PreviewTextInput += Hours;
            DataObject.AddPastingHandler(hours, PastingHours);
            themeHours.PreviewTextInput += Hours;
            DataObject.AddPastingHandler(themeHours, PastingHours);
        }
        private void AddTheme(object sender, RoutedEventArgs e)
        {
            Button addTheme = sender as Button;
            Grid theme = Parent(addTheme);
            ThemeAdd(theme);
        }

        private void ThemeAdd(Grid current)
        {
            StackPanel themes = Parent(current);
            themes.Children.Remove(current);
            Label themeNo = Lab(current, 1);
            TextBox themeName = Box(current, 2);
            TextBox themeHours = Box(current, 3);
            TextBox themeCompetetions = Box(current, 4);
            ComboBox themeLevel = Cbx(current, 5);
            NewTheme(themeNo.Content.ToString(), themeCompetetions.Text,
                themes, AllSectionsContents,
                out Button deleteTheme, out Button addContent,
                out Button addNextTask, out ComboBox themeLevels,
                themeName.Text, themeHours.Text, themeLevel.Text,
                out TextBox hours, out TextBox contentHours);
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
            hours.PreviewTextInput += Hours;
            DataObject.AddPastingHandler(hours, PastingHours);
            contentHours.PreviewTextInput += Hours;
            DataObject.AddPastingHandler(contentHours, PastingHours);
        }

        private void SwitchPlan(object sender, RoutedEventArgs e)
        {
            SwitchSections(sender, new Button[] { ThemePlanSwitch,
                LearnLevelsSwitch }, ThemePlan, LearnLevels);
        }
        private void SwitchCompetetions(object sender, RoutedEventArgs e)
        {
            SwitchSections(sender, new Button[] { TotalHourSwitch, TotalComp,
                ProfComp }, TotalHoursCountPanel, ProfCompetetions, TotalCompetetions);
        }

        private void SwitchSections(object sender,
            Button[] switchs, params Grid[] toHide)
        {
            Button mainSwitch = sender as Button;
            AnyHideX(toHide);
            AnyShow(mainSwitch.Tag as Grid);
            EnableX(true, switchs);
            mainSwitch.IsEnabled = false;
        }
    }
}
