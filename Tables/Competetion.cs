using ControlMaterials.Tables.ThemePlan;
using ControlMaterials.Total;

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
