using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using ControlMaterials.Tables.ThemePlan;

namespace ControlMaterials.Tables
{
    public class Competetion : HybridNode<Task>
    {
        public Competetion() : base() { }
        
        private string _prefix;
        public string Prefix
        {
            get => _prefix;
            set
            {
                _prefix = value;
                OnPropertyChanged();
            }
        }
    }
}
