using ControlMaterials.Total;

namespace Wisdom.ViewModel.Collections.Features.Building
{
    public class StateBuilder<T, TParent> where T : IChangeable
    {
        private StateBlock<T, TParent> _stateBlock;

        public StateBuilder()
        {
            Reset();
        }

        public virtual StateBuilder<T, TParent> Reset()
        {
            _stateBlock = new StateBlock<T, TParent>();
            return this;
        }

        private protected void AddState(State<T, TParent> state)
        {
            _stateBlock.States.Add(state);
        }

        public StateBuilder<T, TParent> Select(int selection)
        {
            _stateBlock.Select(selection);
            return this;
        }

        public StateBlock<T, TParent> Result()
        {
            StateBlock<T, TParent> block = _stateBlock;
            Reset();
            return block;
        }
    }
}
