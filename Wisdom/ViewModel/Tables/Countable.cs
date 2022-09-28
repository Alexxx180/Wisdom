using ControlMaterials.Total;
using ControlMaterials.Total.Collections;
using ControlMaterials.Total.Count;

namespace Wisdom.ViewModel.Tables
{
    public abstract class Countable : Numerable, ICount
    {
        public void Append(ushort increment)
        {
            Hours += increment;
        }

        public void Reduce(ushort decrement)
        {
            Hours -= decrement;
        }

        public void SetTotal(ushort sum)
        {
            Hours = sum;
        }

        public ushort Sum => Hours;
        public abstract ushort Hours { get; set; }

        private protected State<T>[] SumCount<T>(Bridge<ISummator> bridge) where T : ICount
        {
            return new State<T>[]
            {
                new ManualCount<T>(bridge, this, nameof(Hours)),
                new AutoCount<T>(bridge, this, nameof(Hours))
            };
        }
    }
}
