using ControlMaterials.Total;
using ControlMaterials.Total.Collections;

namespace Wisdom.ViewModel.Collections.Features.Numeration
{
    public class OnlyNewNumeration<T> : ManualNumeration<T> where T : INumerable, IChangeable
    {
        public OnlyNewNumeration(IOptionableCollection<T> items) : base(items) { }

        #warning Begin with Number feature IS necessary!

        public override void Add(T item)
        {
            Items.Additor.Number.Increment(1);
        }
    }
}
