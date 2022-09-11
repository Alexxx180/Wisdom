using System.Drawing;

namespace ControlMaterials.Total.Count.Highlighting
{
    public class HighlightOff
    {
        public IHighlighting Item { get; set; }

        public void Recalculate()
        {
            Item.SetColor(Color.Transparent);
        }
    }
}
