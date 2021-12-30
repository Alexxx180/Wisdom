﻿using static System.Convert;
using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Wisdom.Controls.Competetions
{
    /// <summary>
    /// Логика взаимодействия для ProfessionalAutoIndexer.xaml
    /// </summary>
    public partial class ProfessionalAutoIndexer : UserControl, INotifyPropertyChanged
    {
        public StackPanel ToIndex => Tag as StackPanel;
        private int _selected = 0;
        public int Selected
        {
            get => _selected;
            set
            {
                _selected = value;
                OnPropertyChanged();
            }
        }

        public ProfessionalAutoIndexer()
        {
            InitializeComponent();
        }

        private void AutoIndexing(object sender, SelectionChangedEventArgs e)
        {
            ComboBox box = sender as ComboBox;
            byte selection = ToByte(box.SelectedIndex);
            if (ToIndex != null)
                SetAuto(selection);
        }

        private void SetAuto(byte selection)
        {
            ProfessionalDivider.SetAutoOptions(ToIndex, selection);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
