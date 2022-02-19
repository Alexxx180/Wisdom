using System.Windows;
using System.Windows.Input;
using static Wisdom.Controls.EditHelper;

namespace Wisdom.Controls
{
    public partial class EditEvents
    {
        private void Hours(object sender, TextCompositionEventArgs e)
        {
            CheckForHours(sender, e);
        }

        private void PastingHours(object sender, DataObjectPastingEventArgs e)
        {
            CheckForPastingHours(sender, e);
        }

        private void Naming(object sender, TextCompositionEventArgs e)
        {
            CheckForNaming(sender, e);
        }

        private void PastingNaming(object sender, DataObjectPastingEventArgs e)
        {
            CheckForPastingNaming(sender, e);
        }

        private void ForgetNo(object sender, RoutedEventArgs e)
        {
            MemoryNoGotFocus(sender, e);
        }

        private void MemoryNo(object sender, RoutedEventArgs e)
        {
            MemoryNoLostFocus(sender, e);
        }
    }
}