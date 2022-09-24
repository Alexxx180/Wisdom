namespace ControlMaterials.Total
{
    public class Bridge<T>
    {
        public void SetReference(T reference)
        {
            Reference = reference;
        }

        public T Reference;
    }
}
