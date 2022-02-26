using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using static Wisdom.Controls.EditHelper;

namespace Wisdom.Controls
{
    public partial class EditEvents
    {
        private static readonly Regex _hours = new Regex("^([1-9]|[1-9]\\d\\d?)$");

        private void Hours(object sender, TextCompositionEventArgs e)
        {
            CheckForText(e, _hours);
        }

        private void PastingHours(object sender, DataObjectPastingEventArgs e)
        {
            CheckForPastingText(sender, e, _hours);
        }

        private static readonly Regex _naming = new Regex(@"^[A-Za-zА-Яа-я0-9\s-_]*$");

        private void Naming(object sender, TextCompositionEventArgs e)
        {
            CheckForText(e, _naming);
        }

        private void PastingNaming(object sender, DataObjectPastingEventArgs e)
        {
            CheckForPastingText(sender, e, _naming);
        }

        private string _memoryNo;
        private static readonly Regex _no = new Regex(@"\d+");

        private void ForgetNo(object sender, RoutedEventArgs e)
        {
            _memoryNo = MemoryNoGotFocus(sender);
        }

        private void MemoryNo(object sender, RoutedEventArgs e)
        {
            MemoryNoLostFocus(sender, _memoryNo, _no);
        }
    }
}