using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Wisdom.Model;
using static Wisdom.Customing.Decorators;
using static Wisdom.Writers.ResultRenderer;
using static Wisdom.Writers.Content;
using static Wisdom.Customing.ResourceHelper;
using Wisdom.ViewModel;

namespace Wisdom
{
    /// <summary>
    /// Add new programm instance window
    /// </summary>
    public partial class AddProg : Window, INotifyPropertyChanged
    {
        private DisciplineProgramViewModel _viewModel;
        internal DisciplineProgramViewModel ViewModel
        {
            get => _viewModel;
            set
            {
                _viewModel = value;
                OnPropertyChanged();
            }
        }

        private string FileName => Program.Text;

        public AddProg()
        {
            InitializeComponent();
            DataContext = this;
        }

        public AddProg(DisciplineProgram program) : this()
        {
            
        }

        private void MakeUserTemplate(object sender, RoutedEventArgs e)
        {
            
        }      

        

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.SetUpDocumentBlank();
            CallWriter(FileName);
        }


        private void Stepping(object sender, RoutedEventArgs e)
        {
            Button step = sender as Button;
            FrameworkElement form = step.Tag as FrameworkElement;
            //StylesX(GetStyle("Steps2"), Step1, Step2, Step3, Step4);
            //Styles(GetStyle("Steps"), step);
            //AnyHideX(Form1, Form2, Form3, Form4);
            AnyShow(form);
        }

        private void SwitchPlan(object sender, RoutedEventArgs e)
        {
            //SwitchSections(sender, new Button[] { ThemePlanSwitch,
            //    LearnLevelsSwitch }, ThemePlan, LearnLevels);
        }
        private void SwitchCompetetions(object sender, RoutedEventArgs e)
        {
            //SwitchSections(sender, new Button[] { TotalComp,
            //    ProfComp }, TotalHoursCountPanel, ProfCompetetions, TotalCompetetions);
        }

        private void SwitchSections(object sender,
            Button[] switchs, params Grid[] toHide)
        {
            Button mainSwitch = sender as Button;
            AnyHideX(toHide);
            AnyShow(mainSwitch.Tag as Grid);
            EnableX(true, switchs);
            mainSwitch.IsEnabled = false;
        }

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises this object's PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The property that has a new value.</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChangedEventArgs e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }
        #endregion
    }
}
