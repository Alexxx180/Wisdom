using System.ComponentModel;

namespace ControlMaterials.Total
{
    public interface IChangeable
    {
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
