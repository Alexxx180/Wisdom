using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using Wisdom.Model;
using static Wisdom.Customing.Converters;
using static Wisdom.Tests.TotalTest;

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
            //List<object[]> disciplines = MySql.DisciplinesList();

            //Trace.WriteLine(UInts(disciplines[0][0]));
            //Trace.WriteLine(disciplines[0].Length);
            //Trace.WriteLine(disciplines[0][1] + " " + disciplines[0][2]);

            //DisciplineBase discipline = MySql.GetDiscipline(UInts(disciplines[0][0]),
            //    disciplines[0][1] + " " + disciplines[0][2]);
            //TestData(discipline.Plan);

            //List<object[]> specialities = MySql.SpecialitiesList();
            //SpecialityBase speciality = MySql.GetSpeciality(UInts(specialities[0][0]),
            //    specialities[0][1] + " " + specialities[0][2]);
            //TestCompetetion(speciality.GeneralCompetetions, "ОК ");
            //TestCompetetion2(speciality.ProfessionalCompetetions, "ПК ");
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
