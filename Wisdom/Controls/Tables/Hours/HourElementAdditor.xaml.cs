using ControlMaterials.Tables;
using Wisdom.Controls.Templates;

namespace Wisdom.Controls.Tables.Hours
{
    /// <summary>
    /// Логика взаимодействия для HourElementAdditor.xaml
    /// </summary>
    public partial class HourElementAdditor : NewItem<Hour>
    {
        public HourElementAdditor()
        {
            InitializeComponent();
            Data = new Hour();
        }
    }
}