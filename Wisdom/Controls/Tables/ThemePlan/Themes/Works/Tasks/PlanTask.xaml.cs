using ControlMaterials.Tables;
using Wisdom.Controls.Templates;

namespace Wisdom.Controls.Tables.ThemePlan.Themes.Works.Tasks
{
    /// <summary>
    /// Task of theme's work
    /// </summary>
    public partial class PlanTask //: OldItem<Topic>, IWrapFields
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

        public PlanTask()
        {
            InitializeComponent();
            IsWrap = false;
        }
    }
}
