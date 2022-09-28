//using CompetetionModel = ControlMaterials.Tables.Competetion;
using Wisdom.Controls.Templates;

namespace Wisdom.Controls.Tables.Competetions
{
    /// <summary>
    /// General competetion related to speciality-discipline
    /// </summary>
    public partial class Competetion //: OldItem<CompetetionModel>, IExtendableItems, IWrapFields
    {
        #region IExtendableItems Members
        private bool _extended;
        public bool Extended
        {
            get => _extended;
            set
            {
                _extended = value;
                //OnPropertyChanged();
            }
        }

        public void ExtendItems()
        {
            Extended = !Extended;
        }
        #endregion

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

        public Competetion()
        {
            InitializeComponent();
            Extended = true;
            IsWrap = false;
        }
    }
}
