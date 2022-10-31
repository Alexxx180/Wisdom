namespace Wisdom.ViewModel.Collections.Features.Numeration
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
    }
}
