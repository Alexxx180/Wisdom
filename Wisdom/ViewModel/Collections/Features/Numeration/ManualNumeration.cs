using ControlMaterials.Total;

namespace Wisdom.ViewModel.Collections.Features.Numeration
{
    public class ManualNumeration<T, TParent> : State<T, TParent> where T : INumerable, IChangeable
    {
        public ManualNumeration() : base(nameof(INo.No)) { }

        public override void Add(T item, TParent parent) { }

        public override void Remove(T item, TParent parent) { }

        public override void Recalculate(T item, TParent parent) { }

        public override void Setup() { }
    }
}
