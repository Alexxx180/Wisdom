using ControlMaterials.Tables;
using ControlMaterials.Total;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Wisdom.Controls.Tables.Sources;
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
