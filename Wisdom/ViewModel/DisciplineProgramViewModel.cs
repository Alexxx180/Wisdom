using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ControlMaterials;
using ControlMaterials.Documents;
using ControlMaterials.Total;
using ControlMaterials.Tables;
using ControlMaterials.Tables.ThemePlan;
using Wisdom.Model.Tools.DataBase;
using Wisdom.Controls.Tables.Competetions.Professional.ProfessionalGroups;
using Wisdom.Customing;
using static Wisdom.Writers.ResultRenderer;
using Wisdom.Model;
using System.Windows.Input;
using Wisdom.ViewModel.Commands;
using ControlMaterials.Total.Collections.Nodes;
using ControlMaterials.Total.Collections;
using ControlMaterials.Total.Numeration;
using Wisdom.ViewModel.Tables.ThemePlan;
using Wisdom.ViewModel.Tables.Competetions;
using ControlMaterials.Tables.Tasks;

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
                //SpecialityHead = _data.ListSpecialities();
                //SpecialitySelect.Refresh(SpecialityHead.Value);
                OnPropertyChanged();
            }
        }
        #endregion

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
                //if (value >= 0 &&
                //    value < SpecialityHead.Name.Count)
                //    ResetCompetetions();
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

        private ObservableCollection<Metadata> _specialitySelect;
        public ObservableCollection<Metadata> SpecialitySelect
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
                //if (value >= 0 && SpecialityNo >= 0 &&
                //    value < DisciplineHead.Name.Count)
                //    ResetDiscipline();
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

        private ObservableCollection<Metadata> _disciplinesSelect;
        public ObservableCollection<Metadata> DisciplinesSelect
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

                //Value; //.Total.ParseHours();
                //for (ushort i = 0; i < Hours.Count; i++)
                //{
                //    max += Hours[i].No;
                //}

                return max.ToString();
            }
        }

        public void RefreshHours()
        {
            OnPropertyChanged(nameof(MaxHours));
        }
        #endregion

        public ICommand AddHourCommand { get; }
        public ICommand AddMetaCommand { get; }
        public ICommand AddTopicCommand { get; }
        public ICommand AddLevelCommand { get; }
        public ICommand AddSourceCommand { get; }
        public ICommand AddGCompetetionCommand { get; }
        public ICommand AddPCompetetionCommand { get; }

        public ICommand RemoveHourCommand { get; }
        public ICommand RemoveMetaCommand { get; }
        public ICommand RemoveTopicCommand { get; }
        public ICommand RemoveLevelCommand { get; }
        public ICommand RemoveSourceCommand { get; }
        public ICommand RemoveGCompetetionCommand { get; }
        public ICommand RemovePCompetetionCommand { get; }

        #region Data template members
        //private HoursNode<HoursNode<Topic>> _hours;
        //public HoursNode<HoursNode<Topic>> Hours
        //{
        //    get => _hours;
        //    set
        //    {
        //        _hours = value;
        //        OnPropertyChanged();
        //    }
        //}
        
        //private ObservableCollection<NameLabel> _sourceNodes;
        //public ObservableCollection<Source> SourceNodes
        //{
        //    get => _sourceNodes;
        //    set
        //    {
        //        _sourceNodes = value;
        //        OnPropertyChanged();
        //    }
        //}
        
        //private OptionableCollection<Competetion> _gCompetetions;
        //public OptionableCollection<Competetion> GCompetetions
        //{
        //    get => _gCompetetions;
        //    set
        //    {
        //        _gCompetetions = value;
        //        OnPropertyChanged();
        //    }
        //}
        
        //private ObservableCollection<IndexNode<Competetion>> _pCompetetions;
        //public ObservableCollection<IndexNode<Competetion>> PCompetetions
        //{
        //    get => _pCompetetions;
        //    set
        //    {
        //        _pCompetetions = value;
        //        OnPropertyChanged();
        //    }
        //}

        private LevelsVM _levels;
        public LevelsVM Levels
        {
            get => _levels;
            set
            {
                _levels = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<HybridNode<IndexedLabel>> _sources;
        public ObservableCollection<HybridNode<IndexedLabel>> Sources
        {
            get => _sources;
            set
            {
                _sources = value;
                OnPropertyChanged();
            }
        }

        private ThemePlanVM _themePlan;
        public ThemePlanVM ThemePlan
        {
            get => _themePlan;
            set
            {
                _themePlan = value;
                OnPropertyChanged();
            }
        }
        
        private ObservableCollection<Metadata> _metadata;
        public ObservableCollection<Metadata> Metadata
        {
            get => _metadata;
            set
            {
                _metadata = value;
                OnPropertyChanged();
            }
        }
        
        //private ObservableCollection<Hour> _processSettings;
        //public ObservableCollection<Hour> ProcessSettings
        //{
        //    get => _processSettings;
        //    set
        //    {
        //        _processSettings = value;
        //        OnPropertyChanged();
        //    }
        //}
        #endregion

        public DisciplineProgramViewModel()
        {
            SpecialitySelect = new ObservableCollection<Metadata>();
            DisciplinesSelect = new ObservableCollection<Metadata>();
            
            //Levels = new LevelsVM();
            
            ThemePlan = new ThemePlanVM(new Plan());
            
            Sources = new ObservableCollection<HybridNode<IndexedLabel>>();
            Metadata = new ObservableCollection<Metadata>();


            //PCompetetions = new ObservableCollection<IndexNode<Competetion>>();
            //GCompetetions = new OptionableCollection<Competetion>(new Competetion(), 
            //    new State<Competetion>[][] { IndexNode<Competetion>.Numeration() });
            
            SourceTypes = new ObservableCollection<string>();
            Document = new DisciplineProgram();

            //AddHourCommand = new RelayCommand(argument => Hours.Add());
            AddMetaCommand = new RelayCommand(argument => Metadata.Add((argument as Metadata).Copy()));
            //AddLevelCommand = new RelayCommand(argument => Levels.Add());

            //RemoveHourCommand = new RelayCommand(argument => Hours.Remove(argument as HoursNode<Topic>));
            RemoveMetaCommand = new RelayCommand(argument => Metadata.Remove(argument as Metadata));
            //RemoveLevelCommand = new RelayCommand(argument => Levels.Remove(argument as Level));
            //RemoveTopicCommand = new RelayCommand(argument => ThemePlan.Remove(argument as Topic));
            RemoveSourceCommand = new RelayCommand(argument => Sources.Remove(argument as HybridNode<IndexedLabel>));
            
            //RemoveGCompetetionCommand = new RelayCommand(argument => GCompetetions.Remove(argument as Competetion));
            //RemovePCompetetionCommand = new RelayCommand(argument => PCompetetions.Remove(argument as IndexNode<Competetion>));

            //HourGroup
            //Hours = new HoursNode<HoursNode<Topic>>
            //    (new HoursNode<Topic>(new Topic()));

            //for (byte i = 0; i < 3; i++)
            //{
            //    Hours.Add(new HoursNode<Topic>(new Topic()));
            //    Hours[i].Add(new Topic("Hours", 40));
            //}
            
            //AddGroup("Аудиторная нагрузка, часы");
            //AddGroup("Практическая подготовка, часы");
            //OnPropertyChanged(nameof(Hours));

            //SpecialityFullName = "";
            //DisciplineFullName = "";
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

            //SetDiscipline(program);
        }

        internal void SetUpDocumentBlank(in DisciplineProgram document)
        {
            document.Name = DisciplineFullName;
            document.ProfessionName = SpecialityFullName;

            document.MaxHours = MaxHours;
            //document.ClassHours.Refresh(HourGroups[0].Raw());
            //document.SelfHours.Refresh(HourGroups[1].Raw());

            //document.MetaData.Refresh(MetaData);
            //document.GeneralCompetetions.Refresh(GeneralCompetetions);
            //document.ProfessionalCompetetions.Refresh(ProfessionalCompetetions);
            //document.Sources.Refresh(Sources);
            //document.Plan.Refresh(ThemePlan);
            //document.StudyLevels.Refresh(Levels);
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
            //SelectedSpeciality = Data.SpecialityData(SpecialityHead.Name[SpecialityNo], SpecialityFullName);
            //DisciplineHead = Data.ListDisciplines(SpecialityHead.Name[SpecialityNo]);
            //DisciplinesSelect.Refresh(DisciplineHead.Value);

            //SetGeneralCompetetions(SelectedSpeciality.GeneralCompetetions);
            //SetProfessionalCompetetions(SelectedSpeciality.ProfessionalCompetetions);
        }

        private void SetGeneralCompetetions(List<Competetion> competetions)
        {
            //GeneralCompetetions.Clear();
            for (byte i = 0; i < competetions.Count; i++)
            {
                Competetion competetion = new Competetion();
                //competetion.SetElement(competetions[i]);
                //GeneralCompetetions.Add(competetion);
            }
            //OnPropertyChanged(nameof(GeneralCompetetions));
        }

        private void SetProfessionalCompetetions(List<List<Competetion>> competetions)
        {
            //ProfessionalCompetetions.Clear();
            for (byte i = 0; i < competetions.Count; i++)
            {
                ProfessionalDivider division = new ProfessionalDivider();
                //division.SetElement(competetions[i]);
                //ProfessionalCompetetions.Add(division);
            }
            //OnPropertyChanged(nameof(ProfessionalCompetetions));
        }
        #endregion

        #region DisciplineAutoSet Logic
        //private void SetDiscipline(
        //    List<Competetion> general,
        //    List<List<Competetion>> professional,
        //    List<Hour> classHours,
        //    List<Hour> selfHours,
        //    List<Metadata> metaData,
        //    List<HybridNode<IndexedLabel>> sources,
        //    List<Topic> themePlan
        //    )
        //{
        //    SetGeneralCompetetions(general);
        //    SetProfessionalCompetetions(professional);
        //    //SetHourGroups(classHours, selfHours);
        //    SetMetaData(metaData);
        //    SetSources(sources);
        //    SetThemePlan(themePlan);
        //}

        //private void SetDiscipline(DisciplineBase program)
        //{
        //    SetDiscipline(
        //        program.GeneralCompetetions,
        //        program.ProfessionalCompetetions,
        //        program.ClassHours,
        //        program.SelfHours,
        //        program.MetaData,
        //        program.Sources,
        //        program.Plan
        //        );
        //}

        internal void ResetDiscipline()
        {
            //SelectedDiscipline = Data.DisciplineData
            //    (DisciplineHead.Name[DisciplineNo], DisciplineFullName);

            //SetDiscipline(SelectedDiscipline);
            SetLevels();
        }

        //private void SetHours(in int groupNo, HoursNode<HoursNode<Topic>> hours)
        //{
        //    Hours.Clear();
        //    for (ushort i = 0; i < hours.Count; i++)
        //    {
        //        Hours.Add(hours[i]);
        //    }
        //}

        private void SetMetaData(List<Metadata> data)
        {
            Metadata.Clear();
            for (ushort i = 0; i < data.Count; i++)
            {
                Metadata.Add(data[i]);
            }
        }

        private void SetSources(List<HybridNode<IndexedLabel>> sources)
        {
            Sources.Clear();
            for (ushort i = 0; i < sources.Count; i++)
            {
                Sources.Add(sources[i]);
            }
        }

        //private void SetThemePlan(List<Topic> plan)
        //{
        //    ThemePlan.Clear();
        //    for (ushort i = 0; i < plan.Count; i++)
        //    {
        //        ThemePlan.Add(plan[i]);
        //    }
        //}
        #endregion

        #region IndependentFromData Members
        private void SetLevels()
        {
            //List<Metadata> levels = Data.LevelsData();
            //Levels.Clear();
            //for (ushort i = 0; i < levels.Count; i++)
            //{
            //    Levels.Add(levels[i]);
            //}
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
