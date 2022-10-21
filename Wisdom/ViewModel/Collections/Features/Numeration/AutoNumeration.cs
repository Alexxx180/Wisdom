using ControlMaterials.Total;
using ControlMaterials.Total.Collections;

namespace Wisdom.ViewModel.Collections.Features.Numeration
{
    public class AutoNumeration<T> : OnlyNewNumeration<T> where T : INumerable, IChangeable
    {
        private bool _isCalculating;

        public AutoNumeration(IOptionableCollection<T> items) :
            base(items)
        {
            _isCalculating = false;
        }

        public override void Remove(T item)
        {
            if (_isCalculating)
                return;

            _isCalculating = true;
            for (ushort i = item.No; i < Items.Count; i++)
            {
                Items[i].Number.Decrement(1);
            }
            Items.Additor.Number.Decrement(1);
            _isCalculating = false;
        }

        public override void Recalculate()
        {
            if (_isCalculating)
                return;

            _isCalculating = true;
            for (ushort i = 0; i < Items.Count; i++)
            {
                ushort no = i;
                Items[i].Number.SetNumber(no);
            }
            _isCalculating = false;
        }

        public override void Setup()
        {
            Recalculate();
        }
    }
}
