using ControlMaterials.Total;
using System.Collections.Generic;

namespace Wisdom.ViewModel.Collections.Features
{
    public class StateBlock<T, TParent> : PropertyChangedVM, IStateBlock<T, TParent> where T : IChangeable
    {
        private FeatureSetting _state;
        public List<State<T, TParent>> States { get; internal set; }

        private State<T, TParent> _current;
        public State<T, TParent> Current
        {
            get => _current;
            set
            {
                _current = value;
                _current.Setup();
                OnPropertyChanged();
            }
        }

        public StateBlock()
        {
            States = new List<State<T, TParent>>();
        }

        public StateBlock(List<State<T, TParent>> states, ref FeatureSetting state)
        {
            _state = state;
            States = states;
            state.Feature += Select;
            Select(state.Setting);
        }

        public void Unsubscribe()
        {
            _state.Feature -= Select;
        }

        public void Select(int selection)
        {
            Current = States[selection];
        }

        public void Add(T item, TParent parent) => Current.Add(item, parent);

        public void Remove(T item, TParent parent) => Current.Remove(item, parent);

        public void Recalculate(T item, TParent parent) => Current.Recalculate(item, parent);
        
        public string PropertyName => Current.PropertyName;
    }
}
