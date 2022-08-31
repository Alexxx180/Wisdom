using System.ComponentModel;
using System.Runtime.CompilerServices;
using ControlMaterials.Total;

namespace ControlMaterials.Tables.ThemePlan
{
    public struct Task : NameLabel
    {
        public Task(string name, string data)
        {
            Name = name;
            Data = data;
        }

        private string _data;
        public string Data
        {
            get => _data;
            set
            {
                _data = value;
                OnPropertyChanged();
            }
        }
    }
}