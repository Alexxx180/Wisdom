namespace Wisdom.Controls.Tables
{
    /// <summary>
    /// Components model raw data wrapper
    /// </summary>
    public interface IRawData<T>
    {
        public T Raw();
        public void SetElement(T data);
    }
}