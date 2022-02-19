using Wisdom.Model.Tools.DataBase;

namespace Wisdom.ViewModel
{
    public class GlobalViewModel
    {
        public GlobalViewModel()
        {
            _connector = new MySQL();
        }

        private readonly Sql _connector;
    }
}
