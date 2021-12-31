﻿using System;
using System.IO;
using System.Windows;
using Wisdom.Model;
using Wisdom.Controls.UserTemplates;

namespace Wisdom
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static AddProg Discipline { get; set; }

        public static void CreateDisciplineProgram()
        {
            if (Discipline != null)
                return;
            Discipline = new AddProg();
            Discipline.Show();
        }

        public static void CreateDisciplineProgram(DisciplineProgram program)
        {
            if (Discipline != null)
                return;
            Discipline = new AddProg(program);
            Discipline.Show();
        }

        public MainWindow()
        {
            InitializeComponent();
            Discipline = null;
            LoadTemplates();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            CreateDisciplineProgram();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Discipline != null)
                Discipline.Close();
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
                string executingDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
                string templatesDirectory = @"\Resources\Templates";
                System.Diagnostics.Trace.WriteLine(Directory.GetFiles(executingDirectory).Length);
                foreach (string file in Directory.GetFiles(executingDirectory + templatesDirectory))
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
