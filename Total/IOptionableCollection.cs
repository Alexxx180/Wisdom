using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMaterials.Total
{
    public interface IOptionableCollection<T> : IList<T>, ICollection<T>
    {
        public T Additor { get; }
        public void SetTotal(uint total);
    }
}
