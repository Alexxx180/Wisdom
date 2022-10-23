using ControlMaterials.Total;
using ControlMaterials.Total.Collections;
using System.Collections.Generic;
using static Wisdom.ViewModel.DisciplineProgramViewModel;

namespace Wisdom.ViewModel.Collections.Features
{
    public class StateBlock<T> : PropertyChangedVM where T : IChangeable
    {
        public List<State<T>> States { get; }

        private State<T> _current;
        public State<T> Current
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
            States = new List<State<T>>();
        }

        public StateBlock(List<State<T>> states, ref FeatureSetting state)
        {
            States = states;
            state.Feature += Select;
            Select(state.Setting);
        }

        public void Select(int selection)
        {
            Current = States[selection];
        }

        public void Add(T item)
        {
            Current.Add(item);
        }

        public void Remove(T item)
        {
            Current.Remove(item);
        }

        public void Recalculate()
        {
            Current.Recalculate();
        }

        public string PropertyName => Current.PropertyName;
    }
}
