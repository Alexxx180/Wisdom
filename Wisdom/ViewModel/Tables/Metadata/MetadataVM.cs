using ControlMaterials.Tables.Tasks;
using ControlMaterials.Total;

namespace Wisdom.ViewModel.Tables.MetaData
{
    public class MetadataVM : PropertyChangedVM, ICloneable<MetadataVM>
    {
        private Metadata _metadata;

        public MetadataVM(Metadata metadata)
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

        public MetadataVM Copy() => new MetadataVM(_metadata);
    }
}
