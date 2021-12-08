using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static Wisdom.Customing.Converters;
using static Wisdom.Writers.Content;

namespace Wisdom.Controls.ThemePlan
{
    /// <summary>
    /// Логика взаимодействия для PlanWorkAdditor.xaml
    /// </summary>
    public partial class PlanWorkAdditor : UserControl
    {
        public PlanWorkAdditor()
        {
            InitializeComponent();
        }

        private static PlanWorkAdditor SetElement()
        {
            PlanWorkAdditor task = new PlanWorkAdditor();
            return task;
        }

        public static void AddElement(StackPanel stack)
        {
            PlanWorkAdditor element = SetElement();
            _ = stack.Children.Add(element);
        }

        private void AddWork(object sender, RoutedEventArgs e)
        {
            Button addButton = sender as Button;
            Grid workGrid = Parent(addButton);
            ComboBox workName = Cbx(workGrid, 1);
            CheckBox workFew = Chx(workGrid, 2);
            PlanWorkAdditor workAdd = workGrid.Parent as PlanWorkAdditor;
            StackPanel workPanel = Parent(workAdd);
            workPanel.Children.Remove(workAdd);
            if (workFew.IsChecked.Value)
                PlanWork.AddElement(workName.Text, workPanel);
            else
                PlanWorkTask.AddElement(workName.Text, workPanel);
            workPanel.Children.Add(workAdd);
        }

        private void Hours(object sender, TextCompositionEventArgs e)
        {
            CheckForHours(sender, e);
        }
        private void PastingHours(object sender, DataObjectPastingEventArgs e)
        {
            CheckForPastingHours(sender, e);
        }
    }
}
