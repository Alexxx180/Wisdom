using ControlMaterials.Total;
using ControlMaterials.Total.Collections;
using ControlMaterials.Total.Numeration;

namespace Wisdom.ViewModel.Collections.Features.Numeration
{
    public class ManualNumeration<T> : State<T> where T : INumerable
    {
        public ManualNumeration() : base(nameof(Indexer.No)) { }

        public override void Add(T item) { }

        public override void Remove(T item) { }

        public override void Recalculate() { }

        public override void Setup() { }
    }
}
