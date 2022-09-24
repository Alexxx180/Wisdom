namespace ControlMaterials.Total.Numeration
{
    public class AutoNumeration<T> : OnlyNewNumeration<T> where T : INumerable
    {
        private bool _isCalculating;

        public AutoNumeration()
        {
            _isCalculating = false;
        }

        public override void Remove(T item)
        {
            if (_isCalculating)
                return;

            _isCalculating = true;
            for (ushort i = item.No; i < Items.Count; i++)
            {
                Items[i].Decrement(1);
            }
            Items.Additor.Decrement(1);
            _isCalculating = false;
        }

        public override void Recalculate()
        {
            if (_isCalculating)
                return;

            _isCalculating = true;
            for (ushort i = 0; i < Items.Count; i++)
            {
                ushort no = i;
                Items[i].SetNumber(no);
            }
            _isCalculating = false;
        }

        public override void Setup()
        {
            Recalculate();
        }
    }
}
