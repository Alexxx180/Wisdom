using ControlMaterials.Total.Collections;
using ControlMaterials.Total.Numeration;
using Wisdom.ViewModel.Collections.Features.Count;

namespace Wisdom.ViewModel.Tables
{
    public class Numerable : PropertyChangedVM
    {
        private readonly INo _item;

        public Numerable(INo item)
        {
            _item = item;
        }

        public void SetNumber(ushort no)
        {
            _item.No = no;
        }

        public void Increment(ushort no)
        {
            _item.No += no;
        }

        public void Decrement(ushort no)
        {
            _item.No -= no;
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
