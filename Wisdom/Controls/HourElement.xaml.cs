using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using static System.Convert;
using Wisdom.Model;
using static Wisdom.Model.ProgramContent;
using static Wisdom.Writers.Content;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Wisdom.Controls
{
    /// <summary>
    /// Логика взаимодействия для HourElement.xaml
    /// </summary>
    
    public sealed partial class HourElement : UserControl, INotifyPropertyChanged
    {
        public string _type = "";
        public string WorkType
        {
            get { return _type; }
            set
            {
                _type = value;
                OnPropertyChanged();
            }
        }

        public string _value = "";
        public string HourValue
        {
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

        public HourElement()
        {
            InitializeComponent();
        }

        public static void AddElements(List<String2> metaTypes, StackPanel stack)
        {
            for (byte i = 0; i < metaTypes.Count; i++)
            {
                HourElement metaElement = SetElement(metaTypes[i].Value);
                _ = stack.Children.Add(metaElement);
            }
        }

        public static void DropHourElements(StackPanel panel)
        {
            panel.Children.Clear();
        }

        private static HourElement SetElement(string name)
        {
            HourElement hourElement = new HourElement();
            hourElement.WorkType = name;
            return hourElement;
        }

        public static void FillElements(StackPanel stack)
        {
            for (byte i = 0; i < stack.Children.Count; i++)
            {
                HourElement hour = stack.Children[i] as HourElement;
                FillElement(hour);
            }
        }

        private static void FillElement(HourElement hour)
        {
            hour.HourValue = TryGetHours(hour.WorkType).ToString();
        }

        public static void FillElements(StackPanel stack, Dictionary<string, ushort> values)
        {
            for (byte i = 0; i < stack.Children.Count; i++)
            {
                HourElement hour = stack.Children[i] as HourElement;
                FillElement(hour, values);
            }
        }

        private static void FillElement(HourElement hour, Dictionary<string, ushort> values)
        {
            if (values.TryGetValue(hour.WorkType, out ushort value))
                hour.HourValue = value.ToString();
        }

        public static List<string> GetValues(StackPanel stack)
        {
            List<string> values = new List<string>();
            for (byte i = 0; i < stack.Children.Count; i++)
            {
                HourElement hour = stack.Children[i] as HourElement;
                values.Add(hour.HourValue);
            }
            return values;
        }

        public static Dictionary<string, ushort> GetFullData(StackPanel stack)
        {
            Dictionary<string, ushort> values = new Dictionary<string, ushort>();
            for (byte i = 0; i < stack.Children.Count; i++)
            {
                HourElement hour = stack.Children[i] as HourElement;
                values.Add(hour.WorkType, ToUInt16(hour.HourValue));
            }
            return values;
        }

        private void Hours(object sender, TextCompositionEventArgs e)
        {
            CheckForHours(sender, e);
        }
        private void PastingHours(object sender, DataObjectPastingEventArgs e)
        {
            CheckForPastingHours(sender, e);
        }
    }
}