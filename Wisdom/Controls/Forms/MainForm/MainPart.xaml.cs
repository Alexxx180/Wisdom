using System.Windows;
using System.Windows.Controls;
using System.IO;
using Wisdom.Model.Documents;
using Wisdom.Controls.Forms.MainForm.UserTemplates;

namespace Wisdom.Controls.Forms.MainForm
{
    /// <summary>
    /// Part responsible for add/load program calls
    /// </summary>
    public partial class MainPart : UserControl
    {
        public MainPart()
        {
            InitializeComponent();
            LoadTemplates();
        }

        public static void CreateDisciplineProgram()
        {
            AddProg Discipline = new AddProg();
            Discipline.Show();
        }

        public static void CreateDisciplineProgram(DisciplineProgram program)
        {
            AddProg Discipline = new AddProg(program);
            Discipline.Show();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            CreateDisciplineProgram();
        }

        private void RefreshTemplates(object sender, RoutedEventArgs e)
        {
            LoadTemplates();
        }

        public void LoadTemplates()
        {
            Templates.Children.Clear();
            try
            {
                //string executingDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName; | executingDirectory + 
                string templatesDirectory = @"D:\Aleksandr\Windows-7\Учёба, ПТК НовГУ\4 курс\ДИПЛОМ\Шаблоны JSON";
                foreach (string file in Directory.GetFiles(templatesDirectory))
                {
                    TemplateControl template = new TemplateControl(file);
                    _ = Templates.Children.Add(template);
                }
            }
            catch (IOException exception)
            {
                LoadMessage(exception.Message);
            }
        }

        private static void LoadMessage(string exception)
        {
            string noLoad = "Не удалось загрузить шаблоны.";
            string message = "\nФайлы повреждены или находятся вне досягаемости программы.\n";
            string advice = "Полное сообщение:\n";
            _ = MessageBox.Show(noLoad + message + advice + exception);
        }
    }
}