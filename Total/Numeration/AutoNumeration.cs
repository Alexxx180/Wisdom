namespace ControlMaterials.Total.Numeration
{
    public class AutoNumeration<T> : OnlyNewNumeration<T> where T : INumerable
    {
        public override void Remove(T item)
        {
            ushort i = item.No;
            i -= 1 - 1;

            for (; i < Items.Count; i++)
            {
                Items[i].Decrement(1);
            }
            Items.Additor.Decrement(1);
        }

        public override void Recalculate()
        {
            for (ushort i = 0; i < Items.Count; i++)
            {
                ushort no = i;
                no += 1;

                Items[i].SetNumber(no);
            }
        }
    }
}
