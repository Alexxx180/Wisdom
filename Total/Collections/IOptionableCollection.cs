using System.Collections.Generic;

namespace ControlMaterials.Total.Collections
{
    public interface IOptionableCollection<T> : IList<T>, ICollection<T>
    {
        public T Additor { get; }
        public void SetTotal(uint total);
    }
}
