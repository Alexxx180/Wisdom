using System.Windows;
using Wisdom.Model;

namespace Wisdom
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AddProg prog = null;
        Sql MySql = new Sql();

        public MainWindow()
        {
            InitializeComponent();
            MySql.GetRecords();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            prog = new AddProg();
            prog.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (prog != null)
                prog.Close();
        }
    }
}
