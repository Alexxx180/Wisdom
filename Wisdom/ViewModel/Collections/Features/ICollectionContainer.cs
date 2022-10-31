using ControlMaterials.Total;
using Wisdom.ViewModel.Tables;

namespace Wisdom.ViewModel.Collections.Features
{
    public interface ICollectionContainer<T> : IParent<T> where T : IChangeable, ICloneable<T>
    {
        public AutoList<T> Items { get; }
    }
}
