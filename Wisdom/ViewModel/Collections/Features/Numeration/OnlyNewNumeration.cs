using ControlMaterials.Total;

namespace Wisdom.ViewModel.Collections.Features.Numeration
{
    public class OnlyNewNumeration<T, TParent> : ManualNumeration<T, TParent>
        where T : INumerable, IChangeable, ICloneable<T>
        where TParent : ICollectionContainer<T>, ICloneable<TParent>
    {
        public OnlyNewNumeration() { }

        #warning Begin with Number feature IS necessary!

        public override void Add(T item, TParent parent)
        {
            parent.Items.Additor.Number.Increment(1);
        }
    }
}
