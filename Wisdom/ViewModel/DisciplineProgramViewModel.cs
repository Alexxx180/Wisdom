using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ControlMaterials;
using ControlMaterials.Documents;
using ControlMaterials.Tables;
using ControlMaterials.Tables.ThemePlan;
using Wisdom.Model.Tools.DataBase;
using Wisdom.Controls.Tables.Hours;
using Wisdom.Controls.Tables.Hours.Groups;
using Wisdom.Controls.Tables.Competetions.General;
using Wisdom.Controls.Tables.Competetions.Professional.ProfessionalGroups;
using Wisdom.Controls.Tables.Sources.SourceTypes;
using Wisdom.Controls.Tables.ThemePlan;
using Wisdom.Controls.Tables.EducationLevels;
using Wisdom.Controls.Tables.MetaData;
using Wisdom.Customing;
using static Wisdom.Writers.ResultRenderer;
using Wisdom.Model;
using System.Windows.Input;

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
                SetLevels();
                SourceTypes.Refresh(Data.SourceTypesData());
                SpecialityHead = _data.ListSpecialities();
                SpecialitySelect.Refresh(SpecialityHead.Value);
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
                int max = 0;

                for (ushort i = 0; i < HourGroups.Count; i++)
                {
                    max += HourGroups[i].Value; //.Total.ParseHours();
                }

                return max.ToString();
            }
        }

        private ObservableCollection<TaskHours> _hourGroups;
        public ObservableCollection<TaskHours> HourGroups
        {
            get => _hourGroups;
            set
            {
                _hourGroups = value;
                OnPropertyChanged();
            }
        }

        private void AddGroup(string description)
        {
            //HourGroup group = new HourGroup
            //{
            //    Type = description
            //};
            //HourGroups.Add(group);
        }

        public void RefreshHours()
        {
            OnPropertyChanged(nameof(MaxHours));
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

        public void AddMetaData(Task data)
        {
            MetaElement element = new MetaElement
            {
                ViewModel = this
            };
            element.SetElement(data);
            MetaData.Add(element);
            OnPropertyChanged(nameof(MetaData));
        }

        public void DropMetaData(MetaElement meta)
        {
            _ = MetaData.Remove(meta);
            OnPropertyChanged(nameof(MetaData));
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

        public ICommand RemoveCommand { get; }

        public DisciplineProgramViewModel()
        {
            SpecialitySelect = new ObservableCollection<string>();
            DisciplinesSelect = new ObservableCollection<string>();
            Levels = new ObservableCollection<EducationLevel>();
            ThemePlan = new ObservableCollection<PlanTopic>();
            Sources = new ObservableCollection<SourceTypeElement>();
            MetaData = new ObservableCollection<MetaElement>();
            ProfessionalCompetetions = new ObservableCollection<ProfessionalDivider>();
            GeneralCompetetions = new ObservableCollection<GeneralCompetetion>();
            SourceTypes = new ObservableCollection<string>();
            Document = new DisciplineProgram();
            //HourGroup
            HourGroups = new ObservableCollection<TaskHours>();

            HourGroups.Add(new TaskHours("Hours", 40));
            HourGroups.Add(new TaskHours("Hours", 40));
            HourGroups.Add(new TaskHours("Hours", 40));

            AddGroup("Аудиторная нагрузка, часы");
            AddGroup("Практическая подготовка, часы");
            OnPropertyChanged(nameof(HourGroups));

            SpecialityFullName = "";
            DisciplineFullName = "";
        }

        public DisciplineProgramViewModel(GlobalViewModel viewModel) : this()
        {
            Connector = viewModel.Connector;
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
            //document.ClassHours.Refresh(HourGroups[0].Raw());
            //document.SelfHours.Refresh(HourGroups[1].Raw());

            document.MetaData.Refresh(MetaData);
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

        public DisciplineProgram MakeDocument()
        {
            SetUpDocumentBlank(Document);
            return Document;
        }
        #endregion

        #region SpecialityAutoSet Logic
        internal void ResetCompetetions()
        {
            SelectedSpeciality = Data.SpecialityData(SpecialityHead.Name[SpecialityNo], SpecialityFullName);
            DisciplineHead = Data.ListDisciplines(SpecialityHead.Name[SpecialityNo]);
            DisciplinesSelect.Refresh(DisciplineHead.Value);

            SetGeneralCompetetions(SelectedSpeciality.GeneralCompetetions);
            SetProfessionalCompetetions(SelectedSpeciality.ProfessionalCompetetions);
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
            OnPropertyChanged(nameof(GeneralCompetetions));
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
            OnPropertyChanged(nameof(ProfessionalCompetetions));
        }
        #endregion

        #region DisciplineAutoSet Logic
        private void SetDiscipline(
            List<Competetion> general,
            List<List<Competetion>> professional,
            List<Hour> classHours,
            List<Hour> selfHours,
            List<Task> metaData,
            List<Source> sources,
            List<Topic> themePlan
            )
        {
            SetGeneralCompetetions(general);
            SetProfessionalCompetetions(professional);
            SetHourGroups(classHours, selfHours);
            SetMetaData(metaData);
            SetSources(sources);
            SetThemePlan(themePlan);
        }

        private void SetDiscipline(DisciplineBase program)
        {
            SetDiscipline(
                program.GeneralCompetetions,
                program.ProfessionalCompetetions,
                program.ClassHours,
                program.SelfHours,
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
            SetLevels();
        }

        private void SetHours(in int groupNo, List<Hour> hours)
        {
            //HourGroups[groupNo].Hours.Clear();
            //for (ushort i = 0; i < hours.Count; i++)
            //{
            //    Hour hour = hours[i];

            //    HourElement element = new HourElement();
            //    element.Group = HourGroups[groupNo];
            //    element.SetElement(hour);

            //    HourGroups[groupNo].AddHour(element);
            //}
        }

        private void SetHourGroups(
            List<Hour> classHours,
            List<Hour> selfHours
            )
        {
            SetHours(0, classHours);
            SetHours(1, selfHours);

            OnPropertyChanged(nameof(HourGroups));
            OnPropertyChanged(nameof(MaxHours));
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

        private void SetSources(List<Source> sources)
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

        #region IndependentFromData Members
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
        #endregion

        // TO DO

        // For future development...
        // Let's say we have
        //
        // Total hours count - Dictionary<string, ushort>
        // Work hours count - Dictionary<string, List<ushort>>
        //
        // If there is a way to bind it together,
        // we can use UsedValuesConverter to 
        // compare hours total with theme plan!

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