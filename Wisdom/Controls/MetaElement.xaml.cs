using System.Windows.Controls;
using Wisdom.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Wisdom.Controls
{
    /// <summary>
    /// Логика взаимодействия для MetaElement.xaml
    /// </summary>
    public partial class MetaElement : UserControl, INotifyPropertyChanged
    {
        public string _name = "";
        public string MetaName {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string _value = "";
        public string MetaValue {
            get { return _value; }
            set
            {
                _value = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public MetaElement()
        {
            InitializeComponent();
        }

        public static void AddElements(List<String2> metaTypes, StackPanel stack)
        {
            for (byte i = 0; i < metaTypes.Count; i++)
            {
                MetaElement metaElement = SetElement(metaTypes[i].Value);
                _ = stack.Children.Add(metaElement);
            }
        }

        public static void DropMetaData(StackPanel panel)
        {
            panel.Children.Clear();
        }

        private static MetaElement SetElement(string name)
        {
            MetaElement metaElement = new MetaElement();
            metaElement.MetaName = name;
            return metaElement;
        }

        public static void FillElements(StackPanel stack, Dictionary<string, string> values)
        {
            for (byte i = 0; i < stack.Children.Count; i++)
            {
                MetaElement meta = stack.Children[i] as MetaElement;
                FillElement(meta, values);
            }
        }

        private static void FillElement(MetaElement meta, Dictionary<string, string> values)
        {
            if (values.TryGetValue(meta.MetaName, out string value))
                meta.MetaValue = value;
        }

        public static List<string> GetValues(StackPanel stack)
        {
            List<string> values = new List<string>();
            for (byte i = 0; i < stack.Children.Count; i++)
            {
                MetaElement meta = stack.Children[i] as MetaElement;
                values.Add(meta.MetaValue);
            }
            return values;
        }
    }
}