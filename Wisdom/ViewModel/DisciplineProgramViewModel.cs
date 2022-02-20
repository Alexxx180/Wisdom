using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using Wisdom.Model;
using Wisdom.Model.Tools.DataBase;
using static Wisdom.Customing.Converters;
using System.Collections.ObjectModel;
using Wisdom.Controls;
using Wisdom.Controls.Tables.Competetions.General;
using Wisdom.Controls.Tables.Competetions.Professional.ProfessionalGroups;
using Wisdom.Controls.Tables.Sources.SourceTypes;
using Wisdom.Controls.Tables.ThemePlan;
using Wisdom.Controls.Tables.EducationLevels;
using static Wisdom.Writers.ResultRenderer;

namespace Wisdom.ViewModel
{
    internal class DisciplineProgramViewModel : INotifyPropertyChanged
    {
        private DisciplineProgram _document;
        internal DisciplineProgram Document
        {
            get => _document;
            set
            {
                _document = value;
                OnPropertyChanged();
            }
        }

        #region Connection Members
        private Sql _connector;
        internal Sql Connector
        {
            get => _connector;
            set
            {
                _connector = value;
                Data = new ProgramData(value);
                OnPropertyChanged();
            }
        }

        private ProgramData _data;
        internal ProgramData Data
        {
            get => _data;
            set
            {
                _data = value;
                SetLevels();
                SetMetaTypes();
                SetHourTypes();
                SetSourceTypes();
                SpecialityHead = _data.ListSpecialities();
                SpecialitySelect.Refresh(SpecialityHead.Value);
                Document = new DisciplineProgram();
                OnPropertyChanged();
            }
        }
        #endregion


        #region Types Members
        private List<string> _metaTypes;
        internal List<string> MetaTypes
        {
            get => _metaTypes;
            set
            {
                _metaTypes = value;
                OnPropertyChanged();
            }
        }

        private List<string> _hourTypes;
        internal List<string> HourTypes
        {
            get => _hourTypes;
            set
            {
                _hourTypes = value;
                OnPropertyChanged();
            }
        }

        private List<string> _sourceTypes;
        internal List<string> SourceTypes
        {
            get => _sourceTypes;
            set
            {
                _sourceTypes = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region SpecialitySelection Members
        private int _specialityNo;
        internal int SpecialityNo
        {
            get => _specialityNo;
            set
            {
                _specialityNo = value;
                OnPropertyChanged();
            }
        }

        private string _specialityFullName;
        internal string SpecialityFullName
        {
            get => _specialityFullName;
            set
            {
                _specialityFullName = value;
                OnPropertyChanged();
            }
        }

        private SpecialityBase _selectedSpeciality;
        internal SpecialityBase SelectedSpeciality
        {
            get => _selectedSpeciality;
            set
            {
                _selectedSpeciality = value;
                OnPropertyChanged();
            }
        }

        private Pair<List<uint>, List<string>> _specialityHead;
        internal Pair<List<uint>, List<string>> SpecialityHead
        {
            get => _specialityHead;
            set
            {
                _specialityHead = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<string> _specialitySelect;
        public ObservableCollection<string> SpecialitySelect
        {
            get => _specialitySelect;
            set
            {
                _specialitySelect = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region DisciplineSelection Members
        private string _disciplineFullName;
        internal string DisciplineFullName
        {
            get => _disciplineFullName;
            set
            {
                _disciplineFullName = value;
                OnPropertyChanged();
            }
        }

        private DisciplineBase _selectedDiscipline;
        internal DisciplineBase SelectedDiscipline
        {
            get => _selectedDiscipline;
            set
            {
                _selectedDiscipline = value;
                OnPropertyChanged();
            }
        }

        private Pair<List<uint>, List<string>> _disciplineHead;
        internal Pair<List<uint>, List<string>> DisciplineHead
        {
            get => _disciplineHead;
            set
            {
                _disciplineHead = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<string> _disciplinesSelect;
        public ObservableCollection<string> DisciplinesSelect
        {
            get => _disciplinesSelect;
            set
            {
                _disciplinesSelect = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Hours Members
        internal string MaxHours => EduHours + SelfHours;

        private string _selfHours;
        internal string SelfHours
        {
            get => _selfHours;
            set
            {
                _selfHours = value;
                OnPropertyChanged();
            }
        }

        private string _eduHours;
        internal string EduHours
        {
            get => _eduHours;
            set
            {
                _eduHours = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<HourElement> _hours;
        public ObservableCollection<HourElement> Hours
        {
            get => _hours;
            set
            {
                _hours = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Competetions Members
        private ObservableCollection<GeneralCompetetion> _generalCompetetions;
        public ObservableCollection<GeneralCompetetion> GeneralCompetetions
        {
            get => _generalCompetetions;
            set
            {
                _generalCompetetions = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<ProfessionalDivider> _professionalCompetetions;
        public ObservableCollection<ProfessionalDivider> ProfessionalCompetetions
        {
            get => _professionalCompetetions;
            set
            {
                _professionalCompetetions = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Sources Members
        private ObservableCollection<MetaElement> _metaData;
        public ObservableCollection<MetaElement> MetaData
        {
            get => _metaData;
            set
            {
                _metaData = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<SourceTypeElement> _sources;
        public ObservableCollection<SourceTypeElement> Sources
        {
            get => _sources;
            set
            {
                _sources = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region ThemePlan Members
        private ObservableCollection<PlanTopic> _themePlan;
        public ObservableCollection<PlanTopic> ThemePlan
        {
            get => _themePlan;
            set
            {
                _themePlan = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<EducationLevel> _levels;
        public ObservableCollection<EducationLevel> Levels
        {
            get => _levels;
            set
            {
                _levels = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public DisciplineProgramViewModel()
        {
            SpecialitySelect = new ObservableCollection<string>();
            DisciplinesSelect = new ObservableCollection<string>();
            Levels = new ObservableCollection<EducationLevel>();
            ThemePlan = new ObservableCollection<PlanTopic>();
            Sources = new ObservableCollection<SourceTypeElement>();
            MetaData = new ObservableCollection<MetaElement>();
            Hours = new ObservableCollection<HourElement>();
            Hours.Add(new HourElement());
            OnPropertyChanged(nameof(Hours));
            ProfessionalCompetetions = new ObservableCollection<ProfessionalDivider>();
            GeneralCompetetions = new ObservableCollection<GeneralCompetetion>();

            Connector = new MySQL();
        }

        #region DisciplineProgramFilling Logic
        internal void SetFromTemplate(DisciplineProgram program)
        {
            SetProfession(program);
            SetDiscipline(program);
        }

        internal void CreateTemplate()
        {
            DisciplineProgram program = new DisciplineProgram();
            program.DisciplineName = DisciplineFullName;
            program.ProfessionName = SpecialityFullName;

            program.MaxHours = MaxHours;
            program.SelfHours = SelfHours;
            program.EduHours = EduHours;

            program.MetaData.Refresh(MetaData);
            program.Hours.Refresh(Hours);

            program.GeneralCompetetions.Refresh(GeneralCompetetions);
            program.ProfessionalCompetetions.Refresh(ProfessionalCompetetions);

            program.Sources.Refresh(Sources);
            program.Plan.Refresh(ThemePlan);
            program.StudyLevels.Refresh(Levels);
            //WriteJson(FileName, program);
        }

        internal void SetUpDocumentBlank()
        {
            Document.DisciplineName = DisciplineFullName;
            Document.ProfessionName = SpecialityFullName;

            Document.MaxHours = MaxHours;
            Document.SelfHours = SelfHours;
            Document.EduHours = EduHours;

            Document.MetaData.Refresh(MetaData);
            Document.Hours.Refresh(Hours);

            Document.GeneralCompetetions.Refresh(GeneralCompetetions);
            Document.ProfessionalCompetetions.Refresh(ProfessionalCompetetions);

            Document.Sources.Refresh(Sources);
            Document.Plan.Refresh(ThemePlan);
            Document.StudyLevels.Refresh(Levels);
        }

        public void MakeDocument(string fileName)
        {
            SetUpDocumentBlank();
            CallWriter(fileName, Document);
        }
        #endregion

        internal void ResetCompetetions(ComboBox box)
        {
            int selected = box.SelectedIndex;
            if (selected < 0)
                return;

            string name = box.SelectedItem.ToString();
            SelectedSpeciality = Data.SpecialityData(SpecialityHead.Name[selected], name);
            DisciplineHead = Data.ListDisciplines(SpecialityHead.Name[SpecialityNo]);

            foreach (string discipline in DisciplineHead.Value)
                DisciplinesSelect.Add(discipline);

            Document.ProfessionName = SelectedSpeciality.Name;
            SetCompetetions();
        }

        internal void ResetDiscipline(ComboBox box)
        {
            int selected = box.SelectedIndex;
            if (SpecialityNo < 0 || selected < 0)
                return;
            string name = box.SelectedValue.ToString();

            SelectedDiscipline = Data.DisciplineData(DisciplineHead.Name[selected], name);

            int study = 0;
            int self = 0;
            
            for (byte i = 0; i < MetaData.Count; i++)
                MetaData[i].SetElement(SelectedDiscipline.MetaData[i]);

            for (byte i = 0; i < Hours.Count; i++)
            {
                Hours[i].SetElement(SelectedDiscipline.TotalHours[i]);
                if (SelectedDiscipline.TotalHours[i].Name == "Самостоятельная работа")
                {
                    self += SelectedDiscipline.TotalHours[i].Value;
                }
                else
                {
                    study += SelectedDiscipline.TotalHours[i].Value;
                }
            }

            EduHours = study.ToString();
            SelfHours = self.ToString();

            SetLevels();

            for (byte i = 0; i < SourceTypes.Count; i++)
                Sources[i].SetElement(SourceTypes, SelectedDiscipline.Sources[i]);

            SetCompetetions();

            for (byte i = 0; i < ThemePlan.Count; i++)
                ThemePlan[i].SetElement(SelectedDiscipline.Plan[i]);
        }       

        private void SetProfession(DisciplineProgram program)
        {
            SpecialityFullName = program.ProfessionName;
        }

        private void SetDiscipline(DisciplineProgram program)
        {
            DisciplineFullName = program.DisciplineName;

            int study = 0;
            int self = 0;

            for (byte i = 0; i < MetaData.Count; i++)
                MetaData[i].SetElement(program.MetaData[i]);

            for (byte i = 0; i < Hours.Count; i++)
            {
                Hours[i].SetElement(program.Hours[i]);
                if (program.Hours[i].Name == "Самостоятельная работа")
                {
                    self += SelectedDiscipline.TotalHours[i].Value;
                }
                else
                {
                    study += SelectedDiscipline.TotalHours[i].Value;
                }
            }

            EduHours = study.ToString();
            SelfHours = self.ToString();

            Sources.Clear();
            for (byte i = 0; i < program.Sources.Count; i++)
            {
                SourceTypeElement source = new SourceTypeElement();
                source.SetElement(SourceTypes, program.Sources[i]);
                Sources.Add(source);
            }

            SetCompetetions(program);

            SetLevels();

            ThemePlan.Clear();
            for (byte i = 0; i < program.Plan.Count; i++)
            {
                PlanTopic topic = new PlanTopic();
                topic.SetElement(program.Plan[i]);
                ThemePlan.Add(topic);
            }
        }

        private void SetLevels()
        {
            List<Pair<string, string>> levels = Data.LevelsData();
            Levels.Clear();
            for (byte i = 0; i < levels.Count; i++)
            {
                EducationLevel level = new EducationLevel();
                level.SetElement(levels[i]);
                Levels.Add(level);
            }
        }

        private void SetSourceTypes()
        {
            SourceTypes = Data.SourceTypesData();
        }

        private void SetMetaTypes()
        {
            MetaTypes = Data.MetaTypesData();
            MetaData.Clear();
            for (byte i = 0; i < MetaTypes.Count; i++)
            {
                MetaElement meta = new MetaElement();
                meta.SetType(MetaTypes[i]);
                MetaData.Add(meta);
            }
        }

        private void SetHourTypes()
        {
            HourTypes = Data.HourTypesData();
            Hours.Clear();
            for (byte i = 0; i < HourTypes.Count; i++)
            {
                HourElement hour = new HourElement();
                hour.SetType(HourTypes[i]);
                Hours.Add(hour);
            }
            //ResetTotalHourBinds();
        }

        private void SetGeneralCompetetions(byte auto)
        {
            SetGeneralCompetetions(SelectedSpeciality.GeneralCompetetions, auto);
        }

        private void SetGeneralCompetetions(List<HoursList<Pair<string, string>>> competetions, byte auto)
        {
            GeneralCompetetions.Clear();
            for (byte i = 0; i < HourTypes.Count; i++)
            {
                GeneralCompetetion competetion = new GeneralCompetetion();
                competetion.SetElement(competetions[i]);
                GeneralCompetetions.Add(competetion);
            }
        }

        private void SetProfessionalCompetetions(byte auto)
        {
            SetProfessionalCompetetions(SelectedSpeciality.ProfessionalCompetetions, auto);
        }

        private void SetProfessionalCompetetions(List<List<HoursList<Pair<string, string>>>> competetions, byte auto)
        {
            ProfessionalCompetetions.Clear();
            for (byte i = 0; i < HourTypes.Count; i++)
            {
                ProfessionalDivider division = new ProfessionalDivider();
                division.SetElement(competetions[i]);
                ProfessionalCompetetions.Add(division);
            }
        }

        private void SetCompetetions(DisciplineProgram program)
        {
            byte manual = Indexing.MANUAL.ToByte();
            SetGeneralCompetetions(program.GeneralCompetetions, manual);
            SetProfessionalCompetetions(program.ProfessionalCompetetions, manual);
        }

        private void SetCompetetions()
        {
            byte manual = Indexing.MANUAL.ToByte();
            SetGeneralCompetetions(manual);
            SetProfessionalCompetetions(manual);
        }

        //private void ResetTotalHourBinds()
        //{
        //    MultiBinding multiCount = TruncateMulti(Inputted, ContentProperty, new SumConverter());
        //    for (byte i = 0; i < TotalHoursCount.Children.Count; i++)
        //    {
        //        HourElement hour = TotalHoursCount.Children[i] as HourElement;
        //        Grid hourGrid = hour.Content as Grid;
        //        TextBox hourValue = Box(hourGrid, 1);
        //        Binding bindHours = FastBind(hourValue, "Text");k
        //        multiCount.Bindings.Add(bindHours);
        //    }
        //    _ = SetBind(Inputted, ContentProperty, multiCount);
        //}

        #warning Cool Features Here!!
        // TO DO

        // Solve for additors:
        // - ScrollViewer + StackPanel + Additor
        // -                | Stackpanel + Competetions

        // GENIUS IDEA
        // We have
        //
        // Dictionary<string, ushort>
        // Dictionary<string, List<ushort>>
        //
        // Use UsedValuesConverter to compare
        // work types with theme plan!

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
    }
}