using System.Windows;
using System.IO;
using Wisdom.Model.Documents;
using System.ComponentModel;

namespace Wisdom.Controls.Forms.MainForm.UserTemplates
{
    /// <summary>
    /// Discipline program template
    /// </summary>
    public partial class DisciplineProgramTemplate : TemplateControl, INotifyPropertyChanged
    {
        public DisciplineProgramTemplate()
        {
            InitializeComponent();
        }

        public void CreateProgram(DisciplineProgram program)
        {
            AddProg Discipline = new AddProg(program);
            Discipline.Show();
        }

        private void CreateFromTemplate
            (object sender, RoutedEventArgs e)
        {
            if (!File.Exists(FullName))
            {
                MainForm.ReloadTemplates();
                return;
            }

            DisciplineProgram
                    program = LoadFromTemplate
                    <DisciplineProgram>();

            if (program == null)
            {
                MainForm.ReloadTemplates();
                return;
            }
            CreateProgram(program);
        }
    }
}