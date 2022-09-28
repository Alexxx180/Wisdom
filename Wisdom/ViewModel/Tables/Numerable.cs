using ControlMaterials.Total.Collections;
using ControlMaterials.Total.Numeration;

namespace Wisdom.ViewModel.Tables
{
    public abstract class Numerable : PropertyChangedVM, INumerable
    {
        public abstract ushort No { get; set; }

        public void SetNumber(ushort no)
        {
            No = no;
        }

        public void Increment(ushort no)
        {
            No += no;
        }

        public void Decrement(ushort no)
        {
            No -= no;
        }

        public static State<T>[] Numeration<T>() where T : INumerable
        {
            return new State<T>[]
            {
                new ManualNumeration<T>(),
                new OnlyNewNumeration<T>(),
                new AutoNumeration<T>()
            };
        }
    }
}
