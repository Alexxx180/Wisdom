using Microsoft.Win32;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using ControlMaterials;
using Wisdom.Customing;
using static Wisdom.Writers.AutoGenerating.Processors;
using static Wisdom.Writers.AutoGenerating.Documents.DisciplineProgram;
using System;

namespace Wisdom.Controls.Forms.DocumentForms.AddDisciplineProgram
{
    /// <summary>
    /// User settings applying to discipline program
    /// </summary>
    public partial class SettingsPart : UserControl, INotifyPropertyChanged
    {
        #region Settings Members
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
                OnPropertyChanged();
                IsChanged = true;
            }
        }
        #endregion

        private void SetUpSetter
            (string header, string cipher, int selection)
        {
            SetterSelector setter = new SetterSelector();
            setter.Header = header;
            setter.SetElement
                (new Pair<string, int>(cipher, selection));
            setter.OnChanged += new EventHandler(OnChanged);
            Setters.Add(setter);
        }

        public void LoadSetters(Dictionary<string, int> options)
        {
            for (byte i = 0; i < Expressions.Length; i++)
            {
                Pair<string, string> expression = Expressions[i];
                string cipher = expression.Value;
                int selection = options.ContainsKey(cipher) ?
                    options[cipher] : 0;

                SetterSelector setter = Setters[i];
                setter.SetElement
                    (new Pair<string, int>(cipher, selection));
            }
        }

        public void ZeroStart()
        {
            for (byte i = 0; i < Expressions.Length; i++)
            {
                Pair<string, string> expression = Expressions[i];
                SetUpSetter(expression.Name, expression.Value, 0);
            }
        }

        static SettingsPart()
        {
            _documentFilter = "Документ Microsoft Word (*.docx)|*.docx";
        }

        public SettingsPart()
        {
            InitializeComponent();
            Setters = new ObservableCollection<SetterSelector>();
            ZeroStart();
        }

        public Dictionary<string, int> SerializeOptions()
        {
            return Setters.ToDictionary();
        }

        public void LoadPreferences(Settings presets)
        {
            FullPath = presets.TemplatePath;
            LoadSetters(presets.Options);
        }

        private void SetFilePath(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = CallManager(_documentFilter, FullPath);

            if (dialog.ShowDialog().Value)
            {
                FullPath = dialog.FileName;
            }
        }

        private void OnChanged(object sender, EventArgs e)
        {
            IsChanged = true;
            //Top article :
            //https://stackoverflow.com/questions/7880850/how-do-i-make-an-event-in-the-usercontrol-and-have-it-handled-in-the-main-form
        }

        public bool WasChanged()
        {
            bool memory = IsChanged;
            IsChanged = false;
            return memory;
        }

        public bool IsChanged { get; set; }

        private static readonly string _documentFilter;

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