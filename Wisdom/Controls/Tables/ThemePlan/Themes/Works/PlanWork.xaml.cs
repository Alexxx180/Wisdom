using System.Windows;
using Wisdom.Controls.Templates;
using ControlMaterials.Tables.ThemePlan;
using System.Windows.Input;

namespace Wisdom.Controls.Tables.ThemePlan.Themes.Works
{
    /// <summary>
    /// Work with tasks group of theme
    /// </summary>
    public partial class PlanWork : OldItem<Work>, IExtendableItems
    {
        #region Dependency Properties
        public static readonly DependencyProperty
            RemoveTaskProperty = DependencyProperty.Register(nameof(RemoveTask),
                typeof(ICommand), typeof(PlanWork));

        public ICommand RemoveTask
        {
            get => GetValue(RemoveTaskProperty) as ICommand;
            set => SetValue(RemoveTaskProperty, value);
        }

        public static readonly DependencyProperty
            AddTaskProperty = DependencyProperty.Register(nameof(AddTask),
                typeof(ICommand), typeof(PlanWork));

        public ICommand AddTask
        {
            get => GetValue(AddTaskProperty) as ICommand;
            set => SetValue(AddTaskProperty, value);
        }
        #endregion

        #region IExtendableItems Members
        private bool _extended;
        public bool Extended
        {
            get => _extended;
            set
            {
                _extended = value;
                OnPropertyChanged();
            }
        }

        public void ExtendItems()
        {
            Extended = !Extended;
        }
        #endregion

        public PlanWork()
        {
            InitializeComponent();
            Extended = true;
        }
    }
}
