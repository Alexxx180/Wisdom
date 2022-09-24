using ControlMaterials.Total;
using ControlMaterials.Total.Collections;
using ControlMaterials.Total.Collections.Nodes;
using ControlMaterials.Total.Count;
using ControlMaterials.Total.Count.Highlighting;
using ControlMaterials.Total.Numeration;
using System.Drawing;

namespace ControlMaterials.Tables.ThemePlan
{
    public class HoursNode<T> : HybridNode<T>, ISum, ICount, IHighlighting where T : INumerable, ISum, ICloneable<T>
    {
        static HoursNode()
        {
            Pallete = new Color[]
            {
                Color.FromArgb(255, 152, 99),
                Color.Transparent,
                Color.FromArgb(155, 252, 199)
            };
        }

        public HoursNode(T additor)
        {
            Bridge<ISummator> bridge = new Bridge<ISummator>();
            SetItems(additor, Numeration(),
                SumCount(bridge), Highlighting(bridge));
        }

        private protected HoursNode(OptionableCollection<T> items) : base(items) { }


        private protected State<T>[] SumCount(Bridge<ISummator> bridge)
        {
            return new State<T>[]
            {
                new ManualCount<T>(bridge, nameof(Hours)),
                new AutoCount<T>(bridge, this, nameof(Hours))
            };
        }

        private protected State<T>[] Highlighting(Bridge<ISummator> bridge)
        {
            return new State<T>[]
            {
                new HighlightOff<T>(this, nameof(Hours)),
                new HighlightOn<T>(bridge, this, nameof(Hours))
            };
        }


        public override HoursNode<T> Copy()
        {
            return new HoursNode<T>(_items)
            {
                No = No,
                Name = Name,
                Hours = Hours
            };
        }

        public void SetColor(HighlightColor color)
        {
            Color = Pallete[(byte)color];
        }

        public void Append(ushort increment)
        {
            Hours += increment;
        }

        public void Reduce(ushort decrement)
        {
            Hours -= decrement;
        }

        public void SetTotal(ushort sum)
        {
            Hours = sum;
        }

        public ushort Sum => Hours;

        private ushort _hours;
        public ushort Hours
        {
            get => _hours;
            set
            {
                _hours = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Sum));
            }
        }

        public static readonly Color[] Pallete;

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
