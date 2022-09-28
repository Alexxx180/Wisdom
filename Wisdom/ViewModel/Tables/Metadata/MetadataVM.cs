using ControlMaterials.Tables.Tasks;
using ControlMaterials.Total;

namespace Wisdom.ViewModel.Tables.Metadata
{
    public class MetadataVM : PropertyChangedVM, ICloneable<MetadataVM>
    {
        private Task _metadata;

        public MetadataVM(Task metadata)
        {
            _metadata = metadata;
        }

        public string Name
        {
            get => _metadata.Name;
            set
            {
                _metadata.Name = value;
                OnPropertyChanged();
            }
        }

        public string Data
        {
            get => _metadata.Data;
            set
            {
                _metadata.Data = value;
                OnPropertyChanged();
            }
        }

        public MetadataVM Copy() => new MetadataVM(_metadata.Copy());
    }
}
