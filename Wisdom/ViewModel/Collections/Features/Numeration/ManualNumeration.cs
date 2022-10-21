using ControlMaterials.Total;
using ControlMaterials.Total.Collections;

namespace Wisdom.ViewModel.Collections.Features.Numeration
{
    public class ManualNumeration<T> : State<T> where T : INumerable, IChangeable
    {
        public ManualNumeration(IOptionableCollection<T> items) :
            base(nameof(Indexer.No), items) { }

        public override void Add(T item) { }

        public override void Remove(T item) { }

        public override void Recalculate() { }

        public override void Setup() { }
    }
}
