using ControlMaterials.Total;

namespace Wisdom.ViewModel.Collections.Features.Numeration
{
    public class AutoNumeration<T, TParent> : OnlyNewNumeration<T, TParent>
        where T : INumerable, IChangeable, ICloneable<T>
        where TParent : ICollectionContainer<T>, ICloneable<TParent>
    {
        private bool _isCalculating;

        public AutoNumeration()
        {
            _isCalculating = false;
        }

        public override void Remove(T item, TParent parent)
        {
            if (_isCalculating)
                return;

            _isCalculating = true;
            for (ushort i = item.No; i < parent.Items.Count; i++)
            {
                parent.Items[i].Number.Decrement(1);
            }
            parent.Items.Additor.Number.Decrement(1);
            _isCalculating = false;
        }
    }
}
