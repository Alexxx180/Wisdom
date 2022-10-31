using ControlMaterials.Total;
using Wisdom.ViewModel.Collections.Features.Numeration;

namespace Wisdom.ViewModel.Collections.Features.Building.Stacking
{
    public class Numerator<T, TParent> : Stacker<T, TParent>
        where T : IChangeable, INumerable, ICloneable<T>
        where TParent : ICollectionContainer<T>, ICloneable<TParent>
    {
        private Stacker<T, TParent> _counter;
        private NumerationBuilder<T, TParent> _numeration;

        public Numerator(Stacker<T, TParent> counter)
        {
            Sync(counter);
            Reset();
        }

        public void Sync(Stacker<T, TParent> counter)
        {
            _counter = counter;
        }

        private protected override void Reset()
        {
            _numeration = new NumerationBuilder<T, TParent>();
        }

        public override StateGroup<T, TParent> Stack()
        {
            StateGroup<T, TParent> group = _counter.Stack();
            group.Features.Add(_numeration.Manual().OnlyNew().Auto().Select(0).Result());
            return group;
        }
    }
}
