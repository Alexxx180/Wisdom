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
using Wisdom.ViewModel.Commands;

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

        private ObservableCollection<Task> _specialitySelect;
        public ObservableCollection<Task> SpecialitySelect
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

        private ObservableCollection<Task> _disciplinesSelect;
        public ObservableCollection<Task> DisciplinesSelect
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

                for (ushort i = 0; i < Hours.Count; i++)
                {
                    max += Hours[i].No;//Value; //.Total.ParseHours();
                }

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
        private ObservableCollection<HybridNode<Hour>> _hours;
        public ObservableCollection<HybridNode<Hour>> Hours
        {
            get => _hours;
            set
            {
                _hours = value;
                OnPropertyChanged();
            }
        }
        
        private ObservableCollection<Source> _sourceNodes;
        public ObservableCollection<Source> SourceNodes
        {
            get => _sourceNodes;
            set
            {
                _sourceNodes = value;
                OnPropertyChanged();
            }
        }
        
        private ObservableCollection<Competetion> _gCompetetions;
        public ObservableCollection<Competetion> GCompetetions
        {
            get => _gCompetetions;
            set
            {
                _gCompetetions = value;
                OnPropertyChanged();
            }
        }
        
        private ObservableCollection<IndexNode<Competetion>> _pCompetetions;
        public ObservableCollection<IndexNode<Competetion>> PCompetetions
        {
            get => _pCompetetions;
            set
            {
                _pCompetetions = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Level> _levels;
        public ObservableCollection<Level> Levels
        {
            get => _levels;
            set
            {
                _levels = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<NameNode<IndexedLabel>> _sources;
        public ObservableCollection<NameNode<IndexedLabel>> Sources
        {
            get => _sources;
            set
            {
                _sources = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<HoursNode<Theme>> _themePlan;
        public ObservableCollection<HoursNode<Theme>> ThemePlan
        {
            get => _themePlan;
            set
            {
                _themePlan = value;
                OnPropertyChanged();
            }
        }
        
        private ObservableCollection<Task> _metadata;
        public ObservableCollection<Task> Metadata
        {
            get => _metadata;
            set
            {
                _metadata = value;
                OnPropertyChanged();
            }
        }
        
        private ObservableCollection<Hour> _processSettings;
        public ObservableCollection<Hour> ProcessSettings
        {
            get => _processSettings;
            set
            {
                _processSettings = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public DisciplineProgramViewModel()
        {
            SpecialitySelect = new ObservableCollection<Task>();
            DisciplinesSelect = new ObservableCollection<Task>();
            
            Levels = new ObservableCollection<Level>();
            
            ThemePlan = new ObservableCollection<HoursNode<Theme>>();
            
            Sources = new ObservableCollection<NameNode<IndexedLabel>>();
            Metadata = new ObservableCollection<Task>();
            
            PCompetetions = new ObservableCollection<IndexNode<Competetion>>();
            GCompetetions = new ObservableCollection<Competetion>();
            
            SourceTypes = new ObservableCollection<string>();
            Document = new DisciplineProgram();

            AddHourCommand = new RelayCommand(argument =>
            {
                HybridNode<Hour> hour = argument as HybridNode<Hour>;
                Hours.Add(hour.Copy());
            });

            AddMetaCommand = new RelayCommand(argument =>
            {
                Task data = argument as Task;
                Metadata.Add(data.Copy());
                System.Diagnostics.Trace.WriteLine("РАБОТАААЙ!");
            });

            RemoveHourCommand = new RelayCommand(argument =>
            {
                Hours.Remove((HybridNode<Hour>)argument);
            });
            
            RemoveMetaCommand = new RelayCommand(argument =>
            {
                Metadata.Remove((Task)argument);
            });
            
            RemoveTopicCommand = new RelayCommand(argument =>
            {
                ThemePlan.Remove((HoursNode<Theme>)argument);
            });
            
            RemoveSourceCommand = new RelayCommand(argument =>
            {
                Sources.Remove((Source)argument);
            });
            
            RemoveGCompetetionCommand = new RelayCommand(argument =>
            {
                GCompetetions.Remove((Competetion)argument);
            });
            
            RemovePCompetetionCommand = new RelayCommand(argument =>
            {
                PCompetetions.Remove((IndexNode<Competetion>)argument);
            });

            //HourGroup
            Hours = new ObservableCollection<HybridNode<Hour>>();

            for (byte i = 0; i < 3; i++)
            {
                Hours.Add(new HybridNode<Hour>());
                Hours[i].Items.Add(new Hour("Hours", 40));
            }
            
            //AddGroup("Аудиторная нагрузка, часы");
            //AddGroup("Практическая подготовка, часы");
            OnPropertyChanged(nameof(Hours));

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

            SetDiscipline(program);
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
            document.Plan.Refresh(ThemePlan);
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
        private void SetDiscipline(
            List<Competetion> general,
            List<List<Competetion>> professional,
            List<Hour> classHours,
            List<Hour> selfHours,
            List<Task> metaData,
            List<Source> sources,
            List<HoursNode<Theme>> themePlan
            )
        {
            SetGeneralCompetetions(general);
            SetProfessionalCompetetions(professional);
            //SetHourGroups(classHours, selfHours);
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
            //SelectedDiscipline = Data.DisciplineData
            //    (DisciplineHead.Name[DisciplineNo], DisciplineFullName);

            //SetDiscipline(SelectedDiscipline);
            SetLevels();
        }

        private void SetHours(in int groupNo, List<HybridNode<Hour>> hours)
        {
            Hours.Clear();
            for (ushort i = 0; i < hours.Count; i++)
            {
                Hours.Add(hours[i]);
            }
        }

        private void SetMetaData(List<Task> data)
        {
            Metadata.Clear();
            for (ushort i = 0; i < data.Count; i++)
            {
                Metadata.Add(data[i]);
            }
        }

        private void SetSources(List<Source> sources)
        {
            Sources.Clear();
            for (ushort i = 0; i < sources.Count; i++)
            {
                Sources.Add(sources[i]);
            }
        }

        private void SetThemePlan(List<HoursNode<Theme>> plan)
        {
            ThemePlan.Clear();
            for (ushort i = 0; i < plan.Count; i++)
            {
                ThemePlan.Add(plan[i]);
            }
        }
        #endregion

        #region IndependentFromData Members
        private void SetLevels()
        {
            List<Task> levels = Data.LevelsData();
            Levels.Clear();
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
