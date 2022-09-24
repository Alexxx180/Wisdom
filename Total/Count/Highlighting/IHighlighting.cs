namespace ControlMaterials.Total.Count.Highlighting
{
    public interface IHighlighting : ICount
    {
        public void SetColor(HighlightColor highlight);
    }
}
