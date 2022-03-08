using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using Wisdom.Model;
using Wisdom.Customing;
using static Wisdom.Writers.AutoGenerating.Processors;
using static Wisdom.Writers.AutoGenerating.Documents.DisciplineProgram;
using System.Windows;
using Microsoft.Win32;

namespace Wisdom.Controls.Forms.DocumentForms.AddDisciplineProgram
{
    /// <summary>
    /// User settings applying to discipline program
    /// </summary>
    public partial class SettingsPart : UserControl, INotifyPropertyChanged
    {
        public static readonly string ProgramPreferences = "DisciplineProgram.json";
        public static Settings DisciplineProgramProcessing { get; set; }

        private ObservableCollection<SetterSelector> _setters;
        public ObservableCollection<SetterSelector> Setters
        {
            get => _setters;
            set
            {
                _setters = value;
                OnPropertyChanged();
            }
        }

        private string _fullPath;
        public string FullPath
        {
            get => _fullPath;
            set
            {
                _fullPath = value;
                DisciplineProgramProcessing.TemplatePath = value;
                OnPropertyChanged();
            }
        }

        private void SetUpSetter
            (string header, string cipher, int selection)
        {
            SetterSelector setter = new SetterSelector();
            setter.Header = header;
            setter.SetElement
                (new Pair<string, int>(cipher, selection));
            Setters.Add(setter);
        }

        public void ZeroStart()
        {
            for (byte i = 0; i < Expressions.Length; i++)
            {
                Pair<string, string> expression = Expressions[i];
                System.Diagnostics.Trace.WriteLine(expression.Name + " " + expression.Value);
                SetUpSetter(expression.Name, expression.Value, 0);
            }
        }

        public SettingsPart()
        {
            InitializeComponent();
            Setters = new ObservableCollection<SetterSelector>();
            LoadPreferences();
        }

        public void SerializeOptions()
        {
            DisciplineProgramProcessing.Options = Setters.ToDictionary();
        }

        private void LoadPreferences()
        {
            DisciplineProgramProcessing = ReadJson<Settings>
                (SettingsDirectory + ProgramPreferences);

            if (DisciplineProgramProcessing == null)
            {
                ZeroStart();
                DisciplineProgramProcessing = new Settings();
                return;
            }

            FullPath = DisciplineProgramProcessing.TemplatePath;
            for (byte i = 0; i < Expressions.Length; i++)
            {
                Dictionary<string, int>
                    options = DisciplineProgramProcessing.Options;

                Pair<string, string> expression = Expressions[i];
                string cipher = expression.Value;
                int selection = options.ContainsKey(cipher) ?
                    options[cipher] : 0;

                SetUpSetter(expression.Name, cipher, selection);
            }
        }

        private void SetFilePath(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = CallManager(_documentFilter, FullPath);

            if (dialog.ShowDialog().Value)
            {
                FullPath = dialog.FileName;
            }
        }

        private static readonly string _documentFilter =
            "Документ Microsoft Word (*.docx)|*.docx";

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