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
using Wisdom.Controls.ThemePlan;
using Wisdom.Controls.Competetions;

namespace Wisdom
{
    /// <summary>
    /// Логика взаимодействия для AddProg.xaml
    /// </summary>
    public partial class AddProg : Window, INotifyPropertyChanged
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
                ListsRefresh(_DisciplinesSelect, value);
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
                ListsRefresh(_SpecialitySelect, value);
                OnPropertyChanged();
                SpSelect.Items.Refresh();
            }
        }

        public void ListsRefresh<T>(List<T> list, IEnumerable<T> value)
        {
            list.Clear();
            list.AddRange(value);
        }

        private string FileName => $@"{Program.Text}.docx";
        ProgramData Connection = new ProgramData();

        

        private void SetMetaTypes()
        {
            MetaTypes = Connection.MetaTypesData();
            MetaElement.DropMetaData(MetaData);
            MetaElement.AddElements(MetaTypes, MetaData);
        }

        private void SetHourTypes()
        {
            HourTypes = Connection.HourTypesData();
            HourElement.DropHourElements(TotalHoursCount);
            HourElement.AddElements(HourTypes, TotalHoursCount);
            ResetTotalHourBinds();
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

        public AddProg()
        {
            InitializeComponent();
            DataContext = this;
            SetMetaTypes();
            SetHourTypes();
            SpecialitySelect = Connection.ListSpecialities();
        }

        private void ResetAllCompetetionFields(object sender, SelectionChangedEventArgs e)
        {
            ComboBox box = sender as ComboBox;
            int selected = box.SelectedIndex;
            string name = box.SelectedItem.ToString();
            if (selected < 0)
                return;
            SelectedSpeciality = Connection.SpecialityData(SpecialityHead.keys[selected], name);
            DisciplinesSelect = Connection.ListDisciplines(SpecialityHead.keys[SpecNo]);

            ProfessionName = SelectedSpeciality.Name;
            GeneralCompetetion.DropGeneral(TotalCompAddSpace);
            GeneralCompetetion.AddElements(SelectedSpeciality.GeneralCompetetions, TotalCompAddSpace);
            ProfessionalDivider.DropProfessional(ProfCompAddSpace);
            ProfessionalDivider.AddElements(SelectedSpeciality.ProfessionalCompetetions, ProfCompAddSpace);
            
            OrderDate.Text = "";
            OrderNo.Text = "";
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

            //DropAllTopics();
            SelectedDiscipline = Connection.DisciplineData(DisciplineHead.keys[selected], name);

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
            GeneralCompetetion.DropGeneral(TotalCompAddSpace);
            GeneralCompetetion.AddElements(SelectedDiscipline.GeneralCompetetions, TotalCompAddSpace);
            ProfessionalDivider.DropProfessional(ProfCompAddSpace);
            ProfessionalDivider.AddElements(SelectedDiscipline.ProfessionalCompetetions, ProfCompAddSpace);
            

            PlanTopic.DropPlan(DisciplinePlan);
            PlanTopic.AddElements(SelectedDiscipline.Plan, DisciplinePlan);
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
            GeneralCompetetions = GeneralCompetetion.FullGeneral(TotalCompAddSpace); 
            List<List<HoursList<String2>>> fullProfessional = ProfessionalDivider.FullProfessional(ProfCompAddSpace);
            ProfessionalCompetetions = ProfessionalDivider.Zip(fullProfessional); 
            SourcesControl = GetSources(EducationSources, 1, 2);

            Applyment = GetSourceList(ApplyAddSpace, 2);

            Plan = PlanTopic.FullThemePlan(DisciplinePlan);

            StudyLevels.Values = new List<string>();
            List<List<string>> levels = GetListFromElements3(Levels, 2, 4);
            for (byte i = 0; i < levels.Count; i++)
                StudyLevels.Add(levels[i][0], levels[i][1]);

            CallWriter(FileName);
            //WriteDoc();
        }

        private void Hours(object sender, TextCompositionEventArgs e)
        {
            CheckForHours(sender, e);
        }
        private void PastingHours(object sender, DataObjectPastingEventArgs e)
        {
            CheckForPastingHours(sender, e);
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
