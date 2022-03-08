using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using Wisdom.Controls.Tables;
using Wisdom.Customing;
using Wisdom.Model;

namespace Wisdom.Controls.Forms.DocumentForms
{
    /// <summary>
    /// Custom selector for some setting
    /// </summary>
    public partial class SetterSelector : UserControl, INotifyPropertyChanged, IRawData<Pair<string, int>>
    {
        public static readonly DependencyProperty
            HeaderProperty = DependencyProperty.Register(
                nameof(Header), typeof(string), typeof(SetterSelector));

        public static readonly DependencyProperty
            ExpressionProperty = DependencyProperty.Register(
                nameof(Expression), typeof(string), typeof(SetterSelector));

        public static readonly DependencyProperty
            SelectedProperty = DependencyProperty.Register(
                nameof(Selected), typeof(int), typeof(SetterSelector));

        #region IRawData Members
        public Pair<string, int> Raw()
        {
            return new Pair<string, int>
            {
                Name = Expression,
                Value = Selected
            };
        }

        public void SetElement(Pair<string, int> settings)
        {
            Expression = settings.Name;
            Selected = settings.Value;
        }
        #endregion

        #region RecordsPanel Members
        public string Header
        {
            get => GetValue(HeaderProperty).ToString();
            set => SetValue(HeaderProperty, value);
        }

        public string Expression
        {
            get => GetValue(ExpressionProperty).ToString();
            set => SetValue(ExpressionProperty, value);
        }

        public int Selected
        {
            get => GetValue(SelectedProperty).ToInt();
            set => SetValue(SelectedProperty, value);
        }
        #endregion

        public SetterSelector()
        {
            InitializeComponent();
        }

    #region INotifyPropertyChanged Members
    public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises this object's PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The property that has a new value.</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChangedEventArgs e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }
        #endregion
    }
}