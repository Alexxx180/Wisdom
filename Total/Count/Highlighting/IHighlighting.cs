using System.Drawing;

namespace ControlMaterials.Total.Count.Highlighting
{
    public interface IHighlighting : ICount
    {
        public void SetColor(Color highlight);

        public Color Conformity { get; }
        public Color Violation { get; }

        public void SetColorHighlight()
        {

        }
    }
}
