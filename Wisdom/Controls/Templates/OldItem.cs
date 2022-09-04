using System.Windows;
using System.Windows.Input;

namespace Wisdom.Controls.Templates
{
    public partial class OldItem<T> : Item<T>
    {
        public static readonly DependencyProperty
            RemoveProperty = DependencyProperty.Register(nameof(Remove),
                typeof(ICommand), typeof(OldItem<T>));

        public ICommand Remove
        {
            get => GetValue(RemoveProperty) as ICommand;
            set => SetValue(RemoveProperty, value);
        }
    }
}