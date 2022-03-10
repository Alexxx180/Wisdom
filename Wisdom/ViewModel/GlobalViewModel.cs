using Wisdom.Model.Tools.DataBase;

namespace Wisdom.ViewModel
{
    public class GlobalViewModel
    {
        public GlobalViewModel()
        {
            Connector = new MySQL();
        }

        internal readonly Sql Connector;
    }
}