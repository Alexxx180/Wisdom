using Serilog;
using System.Windows;

namespace Wisdom
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static bool DebugMode { get; }

        static App()
        {
            DebugMode = true;
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            Log.Logger = new LoggerConfiguration().MinimumLevel.Debug()
                .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            Log.Information("Application started");
            Log.Debug("Collecting configuration info...");
        }
    }
}