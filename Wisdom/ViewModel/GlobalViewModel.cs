using Wisdom.Model;
using Wisdom.Model.Tools.DataBase;
using static Wisdom.Writers.AutoGenerating.Processors;

namespace Wisdom.ViewModel
{
    public class GlobalViewModel
    {
        public GlobalViewModel()
        {
            Connector = new MySQL();
        }

        #region Connection Members
        private bool FileConnection()
        {
            Pair<string, string> initials = LoadRuntime("Data.json");

            bool connectionSuccessful = !(initials is null) &&
                Connector.TestConnection(initials.Name, initials.Value);

            return connectionSuccessful;
        }

        private void ResetConfiguration()
        {
            Pair<string, string> config = LoadRuntime("Config.json");
            Connector.SetConfiguration(config.Name, config.Value);
        }

        internal void NewConfiguration(string host, string dbName)
        {
            SaveRuntime("Config.json",
                new Pair<string, string>
                (host, dbName));
            ResetConfiguration();
        }

        private void LoginMemory(string login, string pass)
        {
            SaveRuntime("Data.json",
                new Pair<string, string>
                (login, pass));
        }

        internal void Connect()
        {
            if (FileConnection())
                return;

            bool userAgreement, connectionSuccessful = false;
            EntryWindow entry;

            do
            {
                entry = new EntryWindow();
                userAgreement = entry.ShowDialog().Value;

                if (entry.NewConfig)
                {
                    NewConfiguration(entry.Login, entry.Pass);
                    entry = new EntryWindow();
                    continue;
                }

                if (!userAgreement)
                {
                    IndependentMode = true;
                    break;
                }

                connectionSuccessful =
                    Connector.TestConnection
                    (entry.Login, entry.Pass);

                if (!connectionSuccessful)
                {
                    entry = new EntryWindow();
                }
            }
            while (!connectionSuccessful);

            if (entry.MemberMe)
            {
                LoginMemory(entry.Login, entry.Pass);
            }
        }
        #endregion

        public bool IndependentMode { get; set; }

        internal readonly Sql Connector;
    }
}