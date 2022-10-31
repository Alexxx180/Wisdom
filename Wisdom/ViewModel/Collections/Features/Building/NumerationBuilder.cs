using ControlMaterials.Total;
using Wisdom.ViewModel.Collections.Features.Numeration;

namespace Wisdom.ViewModel.Collections.Features.Building
{
    public class NumerationBuilder<T, TParent> : StateBuilder<T, TParent>
        where T : IChangeable, INumerable, ICloneable<T>
        where TParent : ICollectionContainer<T>, ICloneable<TParent>
    {
        public NumerationBuilder<T, TParent> Manual()
        {
            AddState(new ManualNumeration<T, TParent>());
            return this;
        }

        public NumerationBuilder<T, TParent> OnlyNew()
        {
            AddState(new OnlyNewNumeration<T, TParent>());
            return this;
        }

        public NumerationBuilder<T, TParent> Auto()
        {
            AddState(new AutoNumeration<T, TParent>());
            return this;
        }
    }
}
