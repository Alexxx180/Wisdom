using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Text.RegularExpressions;
using static Wisdom.Customing.BlockTemplates;
using static Wisdom.Customing.Decorators;
using static Wisdom.Writers.ResultRenderer;
using static Wisdom.Binds.EasyBindings;
using static Wisdom.Writers.Content;
using static Wisdom.Customing.Converters;
using System.Diagnostics;
using static Wisdom.Customing.ResourceHelper;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Data;
using Wisdom.Binds;
using Microsoft.Win32;
using static Wisdom.Model.ProgramContent;
using System.Collections.Generic;
using Wisdom.Model;
using static Wisdom.Competetions;

namespace Wisdom
{
    /// <summary>
    /// Логика взаимодействия для Competetions.xaml
    /// </summary>
    public partial class Competetions : UserControl
    {
        public Competetions()
        {
            InitializeComponent();
            DataContext = this;
        }
        //List RSkills, List RS
        //GeneralCompGroup.Tag = RSkills;
        //    TotalCompAddSpace.Tag = RS;
        //    ProfStack.Tag = RS;
        public void References()
        {
            
        }

        public void BindInclude(Label Max, TextBox Self)
        {
            Binding maxHours = FastBind(Max, "Content");
            Binding selfHours = FastBind(Self, "Text");
            SetBind(Available, ContentControl.ContentProperty, maxHours);
            SetBind(SelfWork, ContentControl.ContentProperty, selfHours);
        }
        private void DropAllProfessional()
        {
            while (ProfCompAddSpace.Children.Count > 1)
                DropProfessionalTopic(ProfCompAddSpace.Children[0] as Grid);
        }
        private void DropAllGeneral()
        {
            while (TotalCompAddSpace.Children.Count > 1)
                DropGeneral(TotalCompAddSpace.Children[0] as Grid);
        }
        public void SetProfessionalCompetetions(int no)
        {
            DropAllProfessional();
            Grid next = ProfCompAddSpace.Children[0] as Grid;
            Button add = next.Children[0] as Button;

            for (byte i = 0; i < SelectedSpeciality.ProfessionalCompetetions.Count; i++)
            {
                ProfessionalSectionAdd(add);
                Grid subNext = ProfCompAddSpace.Children[i] as Grid;
                StackPanel profComps = subNext.Children[2] as StackPanel;
                Grid subSubNext = profComps.Children[0] as Grid;

                Button subAdd = subSubNext.Children[0] as Button;
                TextBox name = subSubNext.Children[2] as TextBox;

                for (byte ii = 0; ii < SelectedSpeciality.ProfessionalCompetetions[i].Count; ii++)
                {
                    name.Text = SelectedSpeciality.ProfessionalCompetetions[i][ii].Hours;
                    Button delete = ProfessionalCompetetion(subAdd) as Button;
                    delete.Click += DeleteProfessionalItem;
                    Grid current = delete.Parent as Grid;
                    TextBox experience = current.Children[4] as TextBox;
                    TextBox skills = current.Children[6] as TextBox;
                    TextBox knowledge = current.Children[8] as TextBox;
                    experience.Text = SelectedSpeciality.ProfessionalCompetetions[i][ii].Values[0].Value;
                    skills.Text = SelectedSpeciality.ProfessionalCompetetions[i][ii].Values[1].Value;
                    knowledge.Text = SelectedSpeciality.ProfessionalCompetetions[i][ii].Values[2].Value;
                }
            }
        }
        public void SetGeneralCompetetions(int no)
        {
            DropAllGeneral();
            Grid next = TotalCompAddSpace.Children[0] as Grid;
            Button add = next.Children[0] as Button;

            TextBox name = next.Children[2] as TextBox;
            for (byte i = 0; i < SelectedSpeciality.GeneralCompetetions.Count; i++)
            {
                name.Text = SelectedSpeciality.GeneralCompetetions[i].Hours;
                Button delete = GeneralCompetetion(add);
                delete.Click += DeleteGeneralCompetetion;
                Grid current = delete.Parent as Grid;
                TextBox skills = current.Children[4] as TextBox;
                TextBox knowledge = current.Children[6] as TextBox;
                skills.Text = SelectedSpeciality.GeneralCompetetions[i].Values[0].Value;
                knowledge.Text = SelectedSpeciality.GeneralCompetetions[i].Values[1].Value;
            }
        }

        private static readonly Regex _hours = new Regex("^([1-9]|[1-9]\\d\\d?)$");//v\\d
        private void Hours(object sender, TextCompositionEventArgs e)
        {
            TextBox box = e.OriginalSource as TextBox;
            string full = box.Text.Insert(box.CaretIndex, e.Text);
            e.Handled = !_hours.IsMatch(full);
        }

        private void SwitchSections(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            AnyHideX(TotalCompetetions, ProfCompetetions);
            AnyShow(btn.Tag as Grid);
            EnableX(true, TotalComp, ProfComp);
            btn.IsEnabled = false;
        }
        private void DeleteGeneralCompetetion(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            DropGeneral(btn.Parent as Grid);
        }
        private void DropGeneral(Grid generalCompetetion)
        {
            StackPanel panel = generalCompetetion.Parent as StackPanel;
            panel.Children.Remove(generalCompetetion);
            string prefix = "ОК ";
            AutoIndexing2(panel, 1, "", prefix);
        }
        private void AddTotalCompetetion(object sender, RoutedEventArgs e)
        {
            GeneralCompetetion(sender as Button).Click += DeleteGeneralCompetetion;
        }
        private void DeleteProfessional(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            DropProfessionalTopic(btn.Parent as Grid);
        }
        private void DeleteProfessionalItem(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            DropProfessional(btn.Parent as Grid);
        }
        private void DropProfessional(Grid profCompetetion)
        {
            StackPanel items = profCompetetion.Parent as StackPanel;
            Grid section = items.Parent as Grid;

            Border border = section.Children[1] as Border;
            Label title = border.Child as Label;
            StackPanel panel = profCompetetion.Parent as StackPanel;
            panel.Children.Remove(profCompetetion);
            string prefix = title.Content.ToString();
            AutoIndexing(panel, 1, "", prefix);
        }
        private void DropProfessionalTopic(Grid profCompetetionTopic)
        {
            StackPanel panel = profCompetetionTopic.Parent as StackPanel;
            panel.Children.Remove(profCompetetionTopic);
            string prefix = "ПК ";
            AutoIndexingBorder(panel, 1, '.', prefix);
        }
        private void AddProfessionalCompetetion(object sender, RoutedEventArgs e)
        {
            ProfessionalCompetetion(sender as Button).Click += DeleteProfessionalItem;
        }
        private void ProfessionalCompettionSectionAdd_Click(object sender, RoutedEventArgs e)
        {
            Button add = sender as Button;
            ProfessionalSectionAdd(add);
        }
        private void ProfessionalSectionAdd(Button add)
        {
            Grid next = add.Parent as Grid;
            Border border = next.Children[1] as Border;
            Label title = border.Child as Label;
            StackPanel comps = next.Parent as StackPanel;
            Button deleteSection = new Button();
            Button addCompettion = new Button();
            string no = comps.Children.Count.ToString();
            Grid competetion = ProfessionSection("ПК ", no, out deleteSection, out addCompettion);
            Restack(comps, next, competetion);
            title.Content = "ПК " + comps.Children.Count.ToString() + ".";
            deleteSection.Click += DeleteProfessional;
            addCompettion.Click += AddProfessionalCompetetion;
        }

    }
}
