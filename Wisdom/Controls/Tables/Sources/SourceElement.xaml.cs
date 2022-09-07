using ControlMaterials.Total;
using Wisdom.Controls.Templates;

namespace Wisdom.Controls.Tables.Sources
{
    /// <summary>
    /// Record component containing educational source
    /// </summary>
    public partial class SourceElement : OldItem<IndexedLabel>, IWrapFields
    {
        #region IWrapFields Members
        private bool _isWrap;
        public bool IsWrap
        {
            get => _isWrap;
            set
            {
                _isWrap = value;
                OnPropertyChanged();
            }
        }

        public void WrapFields()
        {
            IsWrap = !IsWrap;
        }
        #endregion

        public SourceElement()
        {
            InitializeComponent();
        }
    }
}
