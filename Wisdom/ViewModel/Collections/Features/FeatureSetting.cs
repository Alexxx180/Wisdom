using static Wisdom.ViewModel.DisciplineProgramViewModel;

namespace Wisdom.ViewModel.Collections.Features
{
    public class FeatureSetting : PropertyChangedVM
    {
        private int _setting;
        public int Setting
        {
            get => _setting;
            set
            {
                _setting = value;
                OnPropertyChanged();
                Feature?.Invoke(value);
            }
        }

        public void Select(int selection)
        {
            Setting = selection;
        }

        public event OnSelect Feature;
    }
}
