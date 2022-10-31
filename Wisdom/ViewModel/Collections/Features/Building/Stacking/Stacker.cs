using ControlMaterials.Total;

namespace Wisdom.ViewModel.Collections.Features.Building.Stacking
{
    public abstract class Stacker<T, TParent> where T : IChangeable
    {
        private protected abstract void Reset();

        public abstract StateGroup<T, TParent> Stack();
    }
}
