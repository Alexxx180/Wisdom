using ControlMaterials.Total;

namespace ControlMaterials.Tables.Tasks
{
    public class Task : NameLabel
    {
        public Task() { }

        public Task(string name, string data)
        {
            Name = name;
            Data = data;
        }

        public override Task Copy()
        {
            return new Task
            {
                Name = Name,
                Data = Data
            };
        }

        private string _data;
        public string Data
        {
            get => _data;
            set
            {
                _data = value;
                OnPropertyChanged();
            }
        }
    }
}
