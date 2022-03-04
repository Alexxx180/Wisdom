namespace Wisdom.Controls.Tables
{
    public interface IRawData<T>
    {
        public T Raw();
        public void SetElement(T data);
    }
}