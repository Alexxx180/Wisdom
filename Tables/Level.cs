using ControlMaterials.Total;

namespace ControlMaterials.Tables
{
    public class Level : Indexer
    {
        public Level()
        {
            Description = new Task("", "");
        }

        public override Level Copy()
        {
            return new Level
            {
                No = No,
                Description = Description
            };
        }

        private Task _description;
        public Task Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }
    }
}
