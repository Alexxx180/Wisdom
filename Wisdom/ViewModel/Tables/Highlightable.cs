using System.Drawing;
using ControlMaterials.Total;
using ControlMaterials.Total.Collections;
using ControlMaterials.Total.Count;
using ControlMaterials.Total.Count.Highlighting;

namespace Wisdom.ViewModel.Tables
{
    public abstract class Highlightable : Countable, IHighlighting
    {
        public static readonly Color[] Pallete;

        static Highlightable()
        {
            Pallete = new Color[]
            {
                Color.FromArgb(255, 152, 99),
                Color.Transparent,
                Color.FromArgb(155, 252, 199)
            };
        }

        public void SetColor(HighlightColor color)
        {
            Color = Pallete[(byte)color];
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

        private protected State<T>[] Highlighting<T>(Bridge<ISummator> bridge) where T : IHighlighting
        {
            return new State<T>[]
            {
                new HighlightOff<T>(this, nameof(Hours)),
                new HighlightOn<T>(bridge, this, nameof(Hours))
            };
        }
    }
}
