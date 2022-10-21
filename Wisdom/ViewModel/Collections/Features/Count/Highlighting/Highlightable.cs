using System.Collections.Generic;
using System.Drawing;
using ControlMaterials.Total;
using ControlMaterials.Total.Collections;

namespace Wisdom.ViewModel.Collections.Features.Count.Highlighting
{
    public class Highlightable : PropertyChangedVM
    {
        private readonly Bridge<ISummator> _bridge;
        private readonly IHighlighting _item;
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

        public Highlightable(IHighlighting item,
            Bridge<ISummator> bridge)
        {
            _item = item;
            _bridge = bridge;
        }

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

        internal List<State<T>> Collection<T>(IOptionableCollection<T> items) where T : IChangeable
        {
            return new List<State<T>>()
            {
                new HighlightOff<T>(_item, items),
                new HighlightOn<T>(_bridge, _item, items)
            };
        }
    }
}
