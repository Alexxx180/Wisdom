using ControlMaterials.Total;
using ControlMaterials.Total.Collections;
using System.Collections.Generic;
using Wisdom.ViewModel.Collections.Features.Count;
using Wisdom.ViewModel.Collections.Features.Numeration;

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
            System.Diagnostics.Trace.WriteLine(no);
            _item.No += no;
        }

        public void Decrement(ushort no)
        {
            _item.No -= no;
        }

        public static List<State<T>> Collection<T>(IOptionableCollection<T> items) where T : INumerable, IChangeable
        {
            return new List<State<T>>
            {
                new ManualNumeration<T>(items),
                new OnlyNewNumeration<T>(items),
                new AutoNumeration<T>(items)
            };
        }
    }
}
