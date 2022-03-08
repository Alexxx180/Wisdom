using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Wisdom.Controls.Forms.MainForm;
using static Wisdom.Writers.AutoGenerating.Processors;

namespace Wisdom
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MainPart.Settings = ReadJson<Preferences>(ConfigDirectory + "Preferences.json");
        }
    }
}
