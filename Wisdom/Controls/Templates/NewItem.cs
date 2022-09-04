using System.Windows;
using System.Windows.Input;

namespace Wisdom.Controls.Templates
{
    public partial class NewItem<T> : Item<T>
    {
        public static readonly DependencyProperty
            AddProperty = DependencyProperty.Register(nameof(Add),
                typeof(ICommand), typeof(NewItem<T>));

        public ICommand Add
        {
            get => GetValue(AddProperty) as ICommand;
            set => SetValue(AddProperty, value);
        }
    }
}