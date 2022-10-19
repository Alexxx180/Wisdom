using ControlMaterials.Total.Numeration;

namespace Wisdom.ViewModel.Collections.Features.Numeration
{
    public class OnlyNewNumeration<T> : ManualNumeration<T> where T : INumerable
    {
        #warning Begin with Number feature IS necessary!

        public override void Add(T item)
        {
            Items.Additor.Increment(1);
        }
    }
}
