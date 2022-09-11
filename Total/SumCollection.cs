using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ControlMaterials.Total
{
    public class SumCollection<T> : OptionableCollection<T>, IOptionableCollection<T> where T : ISum
    {
        public override void SetTotal(uint total)
        {
            Sum = total;
        }

        private uint _sum;
        public uint Sum
        { 
            get => _sum;
            set
            {
                _sum = value;
                OnPropertyChanged();
            }
        }
    }
}
