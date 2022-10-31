using System.Windows.Media;
using ControlMaterials.Total;

namespace Wisdom.ViewModel.Collections.Features.Count.Highlighting
{
    public class Highlightable : PropertyChangedVM, IChangeable
    {
        public static readonly Color[] Pallete;

        static Highlightable()
        {
            Pallete = new Color[]
            {
                Color.FromRgb(255, 152, 99),
                Colors.Transparent,
                Color.FromRgb(155, 252, 199)
            };
        }

        public Highlightable() { }
        
        public void SetColor(HighlightColor highlight)
        {
            Color = Pallete[(byte)highlight];
        }

        private Color _color;
        public Color Color
        {
            get => _color;
            set
            {
                _color = value;
                OnPropertyChanged();
            }
        }
    }
}
