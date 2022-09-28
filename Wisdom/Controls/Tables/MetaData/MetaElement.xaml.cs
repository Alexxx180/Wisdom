using ControlMaterials.Tables;
using Wisdom.Controls.Templates;

namespace Wisdom.Controls.Tables.MetaData
{
    /// <summary>
    /// Record component containing discipline meta data
    /// </summary>
    public partial class MetaElement //: OldItem<Task>, IWrapFields
    {
        #region IWrapFields Members
        private bool _isWrap;
        public bool IsWrap
        {
            get => _isWrap;
            set
            {
                _isWrap = value;
                //OnPropertyChanged();
            }
        }

        public void WrapFields()
        {
            IsWrap = !IsWrap;
        }
        #endregion

        public MetaElement()
        {
            InitializeComponent();
        }
    }
}
