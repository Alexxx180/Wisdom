using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Data;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Wisdom.Binds;
using Wisdom.Model;
using Wisdom.Model.DataBase;
using Wisdom.Controls;
using Wisdom.Controls.ThemePlan;
using Wisdom.Controls.Competetions;
using Wisdom.Controls.Sources;
using Wisdom.Controls.EducationLevels;
using Wisdom.Controls.Applyment;
using static Wisdom.Customing.Decorators;
using static Wisdom.Writers.ResultRenderer;
using static Wisdom.Binds.EasyBindings;
using static Wisdom.Writers.Content;
using static Wisdom.Customing.Converters;
using static Wisdom.Customing.ResourceHelper;
using static Wisdom.Model.ProgramContent;

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

        private string FileName => Program.Text;
        ProgramData Connection = new ProgramData();

        private void SetLevels()
        {
            List<String2> levels = Connection.LevelsData();
            EducationLevel.DropLevels(Levels);
            EducationLevel.AddElements(levels, Levels);
        }

        private void SetSourceTypes()
        {
            SourceTypes = Connection.SourceTypesData();
            SetSourceTypeKeys();
        }

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

        private void SetGeneralCompetetions(byte auto)
        {
            GeneralIndexer.Selected = auto;
            GeneralCompetetion.DropGeneral(TotalCompAddSpace);
            GeneralCompetetion.AddElements(SelectedSpeciality.GeneralCompetetions, TotalCompAddSpace, auto);
            GeneralCompetetion.SetAutoOptions(TotalCompAddSpace, auto);
        }

        private void SetProfessionalCompetetions(byte auto)
        {
            ProfessionalIndexer.Selected = auto;
            ProfessionalDivider.DropProfessional(ProfCompAddSpace);
            ProfessionalDivider.AddElements(SelectedSpeciality.ProfessionalCompetetions, ProfCompAddSpace, auto);
            ProfessionalDivider.SetAutoOptions(ProfCompAddSpace, auto);
        }

        private void SetGeneralCompetetions(List<HoursList<String2>> competetions, byte auto)
        {
            GeneralIndexer.Selected = auto;
            GeneralCompetetion.DropGeneral(TotalCompAddSpace);
            GeneralCompetetion.AddElements(competetions, TotalCompAddSpace, auto);
            GeneralCompetetion.SetAutoOptions(TotalCompAddSpace, auto);
        }

        private void SetProfessionalCompetetions(List<List<HoursList<String2>>> competetions, byte auto)
        {
            ProfessionalIndexer.Selected = auto;
            ProfessionalDivider.DropProfessional(ProfCompAddSpace);
            ProfessionalDivider.AddElements(competetions, ProfCompAddSpace, auto);
            ProfessionalDivider.SetAutoOptions(ProfCompAddSpace, auto);
        }

        private void SetCompetetions(DisciplineProgram program)
        {
            byte manual = Bits(Indexing.MANUAL);
            SetGeneralCompetetions(program.GeneralCompetetions, manual);
            SetProfessionalCompetetions(program.ProfessionalCompetetions, manual);
        }

        private void SetCompetetions()
        {
            byte manual = Bits(Indexing.MANUAL);
            SetGeneralCompetetions(manual);
            SetProfessionalCompetetions(manual);
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
            _ = SetBind(Inputted, ContentProperty, multiCount);
        }

        public AddProg()
        {
            InitializeComponent();
            DataContext = this;
            SetLevels();
            SetMetaTypes();
            SetHourTypes();
            SetSourceTypes();
            SpecialitySelect = Connection.ListSpecialities();
        }

        public AddProg(DisciplineProgram program) : this()
        {
            SetProfession(program);
            SetDiscipline(program);
        }

        private void MakeUserTemplate(object sender, RoutedEventArgs e)
        {
            DisciplineProgram program = new DisciplineProgram();
            program.DisciplineName = DpSelect.Text;
            program.ProfessionName = SpSelect.Text;

            program.MaxHours = Max.Content.ToString();
            program.SelfHours = Self.Text;
            program.EduHours = Usual.Text;

            program.MetaData.Clear();
            Dictionary<string, string> factMetaData = MetaElement.GetFullData(MetaData);
            program.AddMetaData(factMetaData);

            program.Hours.Clear();
            Dictionary<string, ushort> factHours = HourElement.GetFullData(TotalHoursCount);
            program.AddHours(factHours);

            program.GeneralCompetetions = GeneralCompetetion.FullGeneral(TotalCompAddSpace);
            program.ProfessionalCompetetions = ProfessionalDivider.FullProfessional(ProfCompAddSpace);
            program.Sources = SourceTypeElement.GetValues(EducationSources);

            program.Applyment = ApplyElement.GetValues(ApplyAddSpace);
            program.Plan = PlanTopic.FullThemePlan(DisciplinePlan);
            program.StudyLevels = EducationLevel.GetValues(Levels);
            WriteJson(FileName, program);
        }

        private void SetProfession(DisciplineProgram program)
        {
            ProfessionName = program.ProfessionName;
        }

        private void SetDiscipline(DisciplineProgram program)
        {
            DisciplineName = program.DisciplineName;

            MetaElement.FillElements(MetaData, program.MetaData);

            int study = program.GetStudyHours();
            int self = program.TryGetHours("Самостоятельная работа");
            Usual.Text = study.ToString();
            Self.Text = self.ToString();

            HourElement.FillElements(TotalHoursCount, program.Hours);

            List<string> sourceTypes = new List<string>();
            for (byte i = 0; i < SourceTypes.Count; i++)
                sourceTypes.Add(SourceTypes[i].Value);
            SourceTypeElement.DropSourceGroups(EducationSources);
            SourceTypeElement.AddElements(program.Sources, sourceTypes, EducationSources);

            SetCompetetions(program);

            PlanTopic.DropPlan(DisciplinePlan);
            PlanTopic.AddElements(program.Plan, DisciplinePlan);
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
            SetCompetetions();
        }

        private void ResetAllDisciplineFields(object sender, SelectionChangedEventArgs e)
        {
            ComboBox box = sender as ComboBox;
            int selected = box.SelectedIndex;
            if (SpecNo < 0 || selected < 0)
                return;
            string name = box.SelectedValue.ToString();
            
            SelectedDiscipline = Connection.DisciplineData(DisciplineHead.keys[selected], name);
            DisciplineName = SelectedDiscipline.Name;
            MetaElement.FillElements(MetaData, SelectedDiscipline.MetaData);

            int study = GetStudyHours();
            int self = TryGetHours("Самостоятельная работа");
            Usual.Text = study.ToString();
            Self.Text = self.ToString();

            HourElement.FillElements(TotalHoursCount);

            SetLevels();
            List<string> sourceTypes = new List<string>();
            for (byte i = 0; i < SourceTypes.Count; i++)
                sourceTypes.Add(SourceTypes[i].Value);
            SourceTypeElement.DropSourceGroups(EducationSources);
            SourceTypeElement.AddElements(SelectedDiscipline.Sources, sourceTypes, EducationSources);

            SetCompetetions();

            PlanTopic.DropPlan(DisciplinePlan);
            PlanTopic.AddElements(SelectedDiscipline.Plan, DisciplinePlan);
        }

        private void SetUpDocumentBlank()
        {
            DisciplineName = DpSelect.Text;
            ProfessionName = SpSelect.Text;

            MaxHours = Max.Content.ToString();
            SelfHours = Self.Text;
            EduHours = Usual.Text;

            MetaDataCollection.Clear();
            List<string> factMetaData = MetaElement.GetValues(MetaData);
            MetaDataCollection.AddRange(factMetaData);

            HoursCollection.Clear();
            List<string> factHours = HourElement.GetValues(TotalHoursCount);
            HoursCollection.AddRange(factHours);

            GeneralCompetetions = GeneralCompetetion.FullGeneral(TotalCompAddSpace);
            List<List<HoursList<String2>>> fullProfessional = ProfessionalDivider.FullProfessional(ProfCompAddSpace);
            ProfessionalCompetetions = ProfessionalDivider.Zip(fullProfessional);
            SourcesControl = SourceTypeElement.GetValues(EducationSources);

            Applyment = ApplyElement.GetValues(ApplyAddSpace);
            Plan = PlanTopic.FullThemePlan(DisciplinePlan);
            StudyLevels = EducationLevel.GetValues(Levels);
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            SetUpDocumentBlank();
            CallWriter(FileName);
        }

        private void Hours(object sender, TextCompositionEventArgs e)
        {
            CheckForHours(sender, e);
        }
        private void PastingHours(object sender, DataObjectPastingEventArgs e)
        {
            CheckForPastingHours(sender, e);
        }

        private void Naming(object sender, TextCompositionEventArgs e)
        {
            CheckForNaming(sender, e);
        }
        private void PastingNaming(object sender, DataObjectPastingEventArgs e)
        {
            CheckForPastingNaming(sender, e);
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
