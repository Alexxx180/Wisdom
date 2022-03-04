using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Wisdom.Model;
using Wisdom.Model.ThemePlan;
using Wisdom.Model.Tools.DataBase;
using Wisdom.Controls;
using Wisdom.Controls.Tables.Competetions.General;
using Wisdom.Controls.Tables.Competetions.Professional.ProfessionalGroups;
using Wisdom.Controls.Tables.Sources.SourceTypes;
using Wisdom.Controls.Tables.ThemePlan;
using Wisdom.Controls.Tables.EducationLevels;
using Wisdom.Controls.Tables.MetaData;
using Wisdom.Customing;
using static Wisdom.Writers.ResultRenderer;

namespace Wisdom.ViewModel
{
    public class DisciplineProgramViewModel : INotifyPropertyChanged
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
                DocumentTypes.WorkTypes.Refresh(Data.WorkTypesData());
                SetHourTypes();
                SetMetaTypes();
                SetLevels();
                SourceTypes.Refresh(Data.SourceTypesData());
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
                OnPropertyChanged();
                DisciplineNo = -1;
                if (value >= 0 &&
                    value < SpecialityHead.Name.Count)
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
                if (value >= 0 && SpecialityNo >= 0 &&
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
            SourceTypes = new ObservableCollection<string>();
            Connector = new MySQL();
        }

        #region DisciplineProgramFilling Logic
        internal void SetFromTemplate(DisciplineProgram program)
        {
            SpecialityFullName = program.ProfessionName;
            DisciplineFullName = program.Name;

            SetDiscipline(program);
        }

        internal void SetUpDocumentBlank(in DisciplineProgram document)
        {
            document.Name = DisciplineFullName;
            document.ProfessionName = SpecialityFullName;

            document.MaxHours = MaxHours;
            document.SelfHours = SelfHours;
            document.EduHours = EduHours;

            document.MetaData.Refresh(MetaData);
            document.Hours.Refresh(Hours);
            document.GeneralCompetetions.Refresh(GeneralCompetetions);
            document.ProfessionalCompetetions.Refresh(ProfessionalCompetetions);
            document.Sources.Refresh(Sources);
            document.Plan.Refresh(ThemePlan);
            document.StudyLevels.Refresh(Levels);
        }

        internal void CreateTemplate(string fileName)
        {
            DisciplineProgram program = new DisciplineProgram();
            SetUpDocumentBlank(program);
            WriteTemplate(program, fileName);
        }

        public void MakeDocument(string fileName)
        {
            SetUpDocumentBlank(Document);
            WriteDocument(Document, fileName);
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
                System.Diagnostics.Trace.WriteLine(competetions.Raw().PrefixNo);
                System.Diagnostics.Trace.WriteLine(competetions.Raw().Name);
                foreach (Task pair in competetions.Raw().Abilities)
                {
                    System.Diagnostics.Trace.WriteLine(pair.Name);
                    System.Diagnostics.Trace.WriteLine(pair.Hours);
                }
            }
        }

        public void TestProfessional()
        {
            System.Diagnostics.Trace.WriteLine(ProfessionalCompetetions.Count);
            foreach (ProfessionalDivider competetions in ProfessionalCompetetions)
            {
                foreach (Competetion pro in competetions.Raw())
                {
                    System.Diagnostics.Trace.WriteLine(pro.PrefixNo);
                    System.Diagnostics.Trace.WriteLine(pro.Name);
                    foreach (Task pair in pro.Abilities)
                    {
                        System.Diagnostics.Trace.WriteLine(pair.Name);
                        System.Diagnostics.Trace.WriteLine(pair.Hours);
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
                System.Diagnostics.Trace.WriteLine(meta.Raw().Hours);
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
                foreach (Theme theme in topic.Raw().Themes)
                {
                    System.Diagnostics.Trace.WriteLine(theme.Name);
                    System.Diagnostics.Trace.WriteLine(theme.Hours);
                    System.Diagnostics.Trace.WriteLine(theme.Competetions);
                    System.Diagnostics.Trace.WriteLine(theme.Level);
                    foreach (Work work in theme.Works)
                    {
                        System.Diagnostics.Trace.WriteLine(work.Type);
                        foreach (Task task in work.Tasks)
                        {
                            System.Diagnostics.Trace.WriteLine(task.Name);
                            System.Diagnostics.Trace.WriteLine(task.Hours);
                        }
                    }
                }
            }
        }
        #endregion

        #region SpecialityAutoSet Logic
        internal void ResetCompetetions()
        {
            SelectedSpeciality = Data.SpecialityData(SpecialityHead.Name[SpecialityNo], SpecialityFullName);
            DisciplineHead = Data.ListDisciplines(SpecialityHead.Name[SpecialityNo]);
            DisciplinesSelect.Refresh(DisciplineHead.Value);

            SetGeneralCompetetions(SelectedSpeciality.GeneralCompetetions);

            //GeneralCompetetions.SetDataElements(SelectedSpeciality.GeneralCompetetions);
            SetProfessionalCompetetions(SelectedSpeciality.ProfessionalCompetetions);

            OnPropertyChanged(nameof(GeneralCompetetions));
            OnPropertyChanged(nameof(ProfessionalCompetetions));
        }

        private void SetGeneralCompetetions(List<Competetion> competetions)
        {
            GeneralCompetetions.Clear();
            for (byte i = 0; i < competetions.Count; i++)
            {
                GeneralCompetetion competetion = new GeneralCompetetion();
                competetion.SetElement(competetions[i]);
                GeneralCompetetions.Add(competetion);
            }
        }

        private void SetProfessionalCompetetions(List<List<Competetion>> competetions)
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
        private void SetDiscipline(
            List<Competetion> general,
            List<List<Competetion>> professional,
            List<Pair<string, ushort>> hours,
            List<Task> metaData,
            List<Pair<string, List<string>>> sources,
            List<Topic> themePlan
            )
        {
            SetGeneralCompetetions(general);
            SetProfessionalCompetetions(professional);
            SetHours(hours);
            SetMetaData(metaData);
            SetSources(sources);
            SetLevels();
            SetThemePlan(themePlan);
        }

        private void SetDiscipline(DisciplineBase program)
        {
            SetDiscipline(
                program.GeneralCompetetions,
                program.ProfessionalCompetetions,
                program.TotalHours,
                program.MetaData,
                program.Sources,
                program.Plan
                );
        }

        internal void ResetDiscipline()
        {
            SelectedDiscipline = Data.DisciplineData
                (DisciplineHead.Name[DisciplineNo], DisciplineFullName);

            SetDiscipline(SelectedDiscipline);
        }

        private void SetHours(List<Pair<string, ushort>> hours)
        {
            int study = 0;
            int self = 0;

            Hours.Clear();
            for (ushort i = 0; i < hours.Count; i++)
            {
                Pair<string, ushort> hour = hours[i];
                HourElement element = new HourElement
                {
                    ViewModel = this
                };
                element.SetElement(hour);
                Hours.Add(element);

                if (hour.Name == "Самостоятельная работа")
                {
                    self += hour.Value;
                }
                else
                {
                    study += hour.Value;
                }
            }

            EduHours = study.ToString();
            SelfHours = self.ToString();
        }

        private void SetMetaData(List<Task> metaData)
        {
            MetaData.Clear();
            for (ushort i = 0; i < metaData.Count; i++)
            {
                MetaElement meta = new MetaElement();
                meta.SetElement(metaData[i]);
                MetaData.Add(meta);
            }
        }

        private void SetSources(List<Pair<string, List<string>>> sources)
        {
            Sources.Clear();
            for (ushort i = 0; i < sources.Count; i++)
            {
                SourceTypeElement source = new SourceTypeElement
                {
                    Groups = Sources
                };
                source.SetElement(SourceTypes, sources[i]);
                Sources.Add(source);
            }
        }

        private void SetThemePlan(List<Topic> plan)
        {
            ThemePlan.Clear();
            for (ushort i = 0; i < plan.Count; i++)
            {
                PlanTopic topic = new PlanTopic
                {
                    No = (i + 1).ToUInt()
                };
                topic.SetElement(plan[i]);
                ThemePlan.Add(topic);
            }
            OnPropertyChanged(nameof(ThemePlan));
        }
        #endregion

        #region SetTypes Members
        private void SetLevels()
        {
            List<Task> levels = Data.LevelsData();
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
            Hours.Clear();
            for (byte i = 0; i < DocumentTypes.WorkTypes.Count; i++)
            {
                HourElement hour = new HourElement
                {
                    ViewModel = this
                };
                hour.SetType(DocumentTypes.WorkTypes[i]);
                Hours.Add(hour);
            }
        }
        #endregion

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