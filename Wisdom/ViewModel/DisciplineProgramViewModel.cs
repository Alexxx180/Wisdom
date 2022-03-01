using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Wisdom.Model;
using Wisdom.Model.Tools.DataBase;
using Wisdom.Controls;
using Wisdom.Controls.Tables.Competetions.General;
using Wisdom.Controls.Tables.Competetions.Professional.ProfessionalGroups;
using Wisdom.Controls.Tables.Sources.SourceTypes;
using Wisdom.Controls.Tables.ThemePlan;
using Wisdom.Controls.Tables.EducationLevels;
using Wisdom.Controls.Tables.MetaData;
using static Wisdom.Writers.ResultRenderer;
using static Wisdom.Customing.Converters;

namespace Wisdom.ViewModel
{
    internal class DisciplineProgramViewModel : INotifyPropertyChanged
    {
        private DisciplineProgram _document;
        public DisciplineProgram Document
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

        private ObservableCollection<string> _sourceTypes;
        public ObservableCollection<string> SourceTypes
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
        public int SpecialityNo
        {
            get => _specialityNo;
            set
            {
                _specialityNo = value;
                DisciplineNo = -1;
                OnPropertyChanged();
                if (value >= 0 && value < SpecialityHead.Name.Count)
                    ResetCompetetions();
            }
        }

        private string _specialityFullName;
        public string SpecialityFullName
        {
            get => _specialityFullName;
            set
            {
                _specialityFullName = value;
                OnPropertyChanged();
            }
        }

        private SpecialityBase _selectedSpeciality;
        public SpecialityBase SelectedSpeciality
        {
            get => _selectedSpeciality;
            set
            {
                _selectedSpeciality = value;
                OnPropertyChanged();
            }
        }

        private Pair<List<uint>, List<string>> _specialityHead;
        public Pair<List<uint>, List<string>> SpecialityHead
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
        private int _disciplineNo;
        public int DisciplineNo
        {
            get => _disciplineNo;
            set
            {
                _disciplineNo = value;
                OnPropertyChanged();
                if (SpecialityNo >= 0 && value >= 0 &&
                    value < DisciplineHead.Name.Count)
                    ResetDiscipline();
            }
        }

        private string _disciplineFullName;
        public string DisciplineFullName
        {
            get => _disciplineFullName;
            set
            {
                _disciplineFullName = value;
                OnPropertyChanged();
            }
        }

        private DisciplineBase _selectedDiscipline;
        public DisciplineBase SelectedDiscipline
        {
            get => _selectedDiscipline;
            set
            {
                _selectedDiscipline = value;
                OnPropertyChanged();
            }
        }

        private Pair<List<uint>, List<string>> _disciplineHead;
        public Pair<List<uint>, List<string>> DisciplineHead
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
        public string MaxHours {
            get
            {
                int max = EduHours.ParseHours()
                    + SelfHours.ParseHours();
                return max.ToString();
            }
        }

        private string _selfHours;
        public string SelfHours
        {
            get => _selfHours;
            set
            {
                _selfHours = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(MaxHours));
            }
        }

        private string _eduHours;
        public string EduHours
        {
            get => _eduHours;
            set
            {
                _eduHours = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(MaxHours));
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
                OnPropertyChanged(nameof(MaxHours));
            }
        }

        public void RefreshHours()
        {
            OnPropertyChanged(nameof(Hours));
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

        #region MVVM Tests
        public void TestCompetetions()
        {
            System.Diagnostics.Trace.WriteLine(SpecialityFullName);
            TestGeneral();
            TestProfessional();
        }

        public void TestGeneral()
        {
            System.Diagnostics.Trace.WriteLine(GeneralCompetetions.Count);
            foreach (GeneralCompetetion competetions in GeneralCompetetions)
            {
                System.Diagnostics.Trace.WriteLine(competetions.Raw().Name);
                System.Diagnostics.Trace.WriteLine(competetions.Raw().Hours);
                foreach (Pair<string, string> pair in competetions.Raw().Values)
                {
                    System.Diagnostics.Trace.WriteLine(pair.Name);
                    System.Diagnostics.Trace.WriteLine(pair.Value);
                }
            }
        }

        public void TestProfessional()
        {
            System.Diagnostics.Trace.WriteLine(ProfessionalCompetetions.Count);
            foreach (ProfessionalDivider competetions in ProfessionalCompetetions)
            {
                foreach (HoursList<Pair<string, string>> pro in competetions.Raw())
                {
                    System.Diagnostics.Trace.WriteLine(pro.Name);
                    System.Diagnostics.Trace.WriteLine(pro.Hours);
                    foreach (Pair<string, string> pair in pro.Values)
                    {
                        System.Diagnostics.Trace.WriteLine(pair.Name);
                        System.Diagnostics.Trace.WriteLine(pair.Value);
                    }
                }
            }
        }

        public void TestDiscipline()
        {
            System.Diagnostics.Trace.WriteLine(DisciplineFullName);
            TestHours();
            TestMetaData();
            TestSources();
            TestThemePlan();
        }

        public void TestHours()
        {
            System.Diagnostics.Trace.WriteLine(Hours.Count);
            foreach (HourElement hour in Hours)
            {
                System.Diagnostics.Trace.WriteLine(hour.Raw().Name);
                System.Diagnostics.Trace.WriteLine(hour.Raw().Value);
            }
        }

        public void TestMetaData()
        {
            System.Diagnostics.Trace.WriteLine(MetaData.Count);
            foreach (MetaElement meta in MetaData)
            {
                System.Diagnostics.Trace.WriteLine(meta.Raw().Name);
                System.Diagnostics.Trace.WriteLine(meta.Raw().Value);
            }
        }

        public void TestSources()
        {
            System.Diagnostics.Trace.WriteLine(Sources.Count);
            foreach (SourceTypeElement sourceType in Sources)
            {
                System.Diagnostics.Trace.WriteLine(sourceType.Raw().Name);
                foreach (string source in sourceType.Raw().Value)
                {
                    System.Diagnostics.Trace.WriteLine(source);
                }
            }
        }

        public void TestThemePlan()
        {
            System.Diagnostics.Trace.WriteLine(ThemePlan.Count);
            foreach (PlanTopic topic in ThemePlan)
            {
                System.Diagnostics.Trace.WriteLine(topic.Raw().Name);
                foreach (LevelsList<HashList<Pair<string, string>>> theme in topic.Raw().Values)
                {
                    System.Diagnostics.Trace.WriteLine(theme.Name);
                    System.Diagnostics.Trace.WriteLine(theme.Hours);
                    System.Diagnostics.Trace.WriteLine(theme.Competetions);
                    System.Diagnostics.Trace.WriteLine(theme.Level);
                    foreach (HashList<Pair<string, string>> work in theme.Values)
                    {
                        System.Diagnostics.Trace.WriteLine(work.Name);
                        foreach (Pair<string, string> task in work.Values)
                        {
                            System.Diagnostics.Trace.WriteLine(task.Name);
                            System.Diagnostics.Trace.WriteLine(task.Value);
                        }
                    }
                }
            }
        }
        #endregion

        #region SpecialityAutoSet Logic
        private void SetProfession(DisciplineProgram program)
        {
            SpecialityFullName = program.ProfessionName;
        }

        internal void ResetCompetetions()
        {
            SelectedSpeciality = Data.SpecialityData(SpecialityHead.Name[SpecialityNo], SpecialityFullName);
            DisciplineHead = Data.ListDisciplines(SpecialityHead.Name[SpecialityNo]);
            DisciplinesSelect.Refresh(DisciplineHead.Value);

            SetGeneralCompetetions(SelectedSpeciality.GeneralCompetetions);
            SetProfessionalCompetetions(SelectedSpeciality.ProfessionalCompetetions);

            OnPropertyChanged(nameof(GeneralCompetetions));
            OnPropertyChanged(nameof(ProfessionalCompetetions));
        }

        private void SetGeneralCompetetions(List<HoursList<Pair<string, string>>> competetions)
        {
            GeneralCompetetions.Clear();
            for (byte i = 0; i < competetions.Count; i++)
            {
                GeneralCompetetion competetion = new GeneralCompetetion();
                competetion.SetElement(competetions[i]);
                GeneralCompetetions.Add(competetion);
            }
        }

        private void SetProfessionalCompetetions(List<List<HoursList<Pair<string, string>>>> competetions)
        {
            ProfessionalCompetetions.Clear();
            for (byte i = 0; i < competetions.Count; i++)
            {
                ProfessionalDivider division = new ProfessionalDivider();
                division.SetElement(competetions[i]);
                ProfessionalCompetetions.Add(division);
            }
        }
        #endregion

        #region DisciplineAutoSet Logic
        

        internal void ResetDiscipline()
        {
            SelectedDiscipline = Data.DisciplineData(DisciplineHead.Name[DisciplineNo], DisciplineFullName);

            SetGeneralCompetetions(SelectedDiscipline.GeneralCompetetions);
            SetProfessionalCompetetions(SelectedDiscipline.ProfessionalCompetetions);

            int study = 0;
            int self = 0;

            int count = Math.Min(MetaData.Count, SelectedDiscipline.MetaData.Count);
            for (ushort i = 0; i < count; i++)
                MetaData[i].SetElement(SelectedDiscipline.MetaData[i]);

            count = Math.Min(Hours.Count, SelectedDiscipline.TotalHours.Count);
            for (ushort i = 0; i < count; i++)
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

            //

            EduHours = study.ToString();
            SelfHours = self.ToString();

            Sources.Clear();
            for (ushort i = 0; i < SelectedDiscipline.Sources.Count; i++)
            {
                SourceTypeElement source = new SourceTypeElement
                {
                    Groups = Sources
                };
                source.SetElement(SourceTypes, SelectedDiscipline.Sources[i]);
                Sources.Add(source);
            }

            SetLevels();
            SetThemePlan();
        }       

        private void SetThemePlan()
        {
            ThemePlan.Clear();
            for (ushort i = 0; i < SelectedDiscipline.Plan.Count; i++)
            {
                PlanTopic topic = new PlanTopic
                {
                    No = (i + 1).ToUInt()
                };
                topic.SetElement(SelectedDiscipline.Plan[i]);
                ThemePlan.Add(topic);
            }
            OnPropertyChanged(nameof(ThemePlan));
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
                SourceTypeElement source = new SourceTypeElement
                {
                    Groups = Sources
                };
                source.SetElement(SourceTypes, program.Sources[i]);
                Sources.Add(source);
            }

            SetGeneralCompetetions(program.GeneralCompetetions);
            SetProfessionalCompetetions(program.ProfessionalCompetetions);

            SetLevels();

            ThemePlan.Clear();
            for (byte i = 0; i < program.Plan.Count; i++)
            {
                PlanTopic topic = new PlanTopic();
                topic.SetElement(program.Plan[i]);
                ThemePlan.Add(topic);
            }

            //OnPropertyChanged(nameof(ThemePlan));
        }

        private void SetSourceTypes()
        {
            SourceTypes = new ObservableCollection<string>(Data.SourceTypesData());
            foreach (string type in SourceTypes)
            {
                System.Diagnostics.Trace.WriteLine("Unbeliavable: " + type);
            }
        }

        private void SetLevels()
        {
            List<Pair<string, string>> levels = Data.LevelsData();
            Levels.Clear();
            for (byte i = 0; i < levels.Count; i++)
            {
                EducationLevel level = new EducationLevel
                {
                    LevelNo = (i + 1).ToString()
                };
                level.SetElement(levels[i]);
                Levels.Add(level);
            }
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
                HourElement hour = new HourElement
                {
                    ViewModel = this
                };
                hour.SetType(HourTypes[i]);
                Hours.Add(hour);
            }
            //ResetTotalHourBinds();
        }
        #endregion

#warning HOURS HIGHLIGHTING NEED TO BE REPAIRED
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