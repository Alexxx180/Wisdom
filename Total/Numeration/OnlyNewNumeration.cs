namespace ControlMaterials.Total.Numeration
{
    public class OnlyNewNumeration<T> : ManualNumeration<T> where T : INumerable
    {
        public override void Add(T item)
        {
            Items.Additor.Increment(1);
        }
    }
}
