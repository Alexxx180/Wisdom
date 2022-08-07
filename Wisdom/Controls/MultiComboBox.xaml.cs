using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Wisdom.Controls
{
    /// <summary>
    /// Логика взаимодействия для MultiComboBox.xaml
    /// </summary>
    public partial class MultiComboBox : UserControl
    {
        public MultiComboBox()
        {
            InitializeComponent();
            _nodeList = new ObservableCollection<Node>();

            Dictionary<string, object> items = new Dictionary<string, object>();

            items = new Dictionary<string, object>();
            items.Add("Chennai", "MAS");
            items.Add("Trichy", "TPJ");
            items.Add("Bangalore", "SBC");
            items.Add("Coimbatore", "CBE");

            ItemsSource = items;

            //SelectedItems = new Dictionary<string, object>();
            //SelectedItems.Add("Chennai", "MAS");
            //SelectedItems.Add("Trichy", "TPJ");
        }

        private ObservableCollection<Node> _nodeList;

        private void DisplayInControl()
        {
            _nodeList.Clear();
            if (ItemsSource.Count > 0)
                _nodeList.Add(new Node("All"));
            foreach (KeyValuePair<string, object> keyValue in ItemsSource)
            {
                Node node = new Node(keyValue.Key);
                _nodeList.Add(node);
            }
            MultiSelectCombo.ItemsSource = _nodeList;
        }

        private void SetSelectedItems()
        {
            if (SelectedItems == null)
                SelectedItems = new Dictionary<string, object>();
            SelectedItems.Clear();
            foreach (Node node in _nodeList)
            {
                if (node.IsSelected && node.Title != "All")
                {
                    if (ItemsSource.Count > 0)
                        SelectedItems.Add(node.Title, ItemsSource[node.Title]);
                }
            }
        }

        private void SetText()
        {
            if (SelectedItems is not null)
            {
                StringBuilder displayText = new StringBuilder();
                foreach (Node s in _nodeList)
                {
                    if (!s.IsSelected)
                        continue;

                    if (s.Title == "All")
                    {
                        displayText = new StringBuilder();
                        displayText.Append("All");
                        break;
                    }
                    else
                    {
                        displayText.Append(s.Title);
                        displayText.Append(',');
                    }
                }
                Text = displayText.ToString().TrimEnd(',');
            }
            // set DefaultText if nothing else selected
            if (string.IsNullOrEmpty(Text))
            {
                Text = DefaultText;
            }
        }

        private void SelectNodes()
        {
            foreach (KeyValuePair<string, object> keyValue in SelectedItems)
            {
                Node node = _nodeList.FirstOrDefault(i => i.Title == keyValue.Key);
                if (node != null)
                    node.IsSelected = true;
            }
        }

        private void OnSelect(object sender, RoutedEventArgs e)
        {
            CheckBox clickedBox = (CheckBox)sender;

            if (clickedBox.Content is "All")
            {
                if (clickedBox.IsChecked.Value)
                {
                    foreach (Node node in _nodeList)
                    {
                        node.IsSelected = true;
                    }
                }
                else
                {
                    foreach (Node node in _nodeList)
                    {
                        node.IsSelected = false;
                    }
                }
            }
            else
            {
                int _selectedCount = 0;
                foreach (Node s in _nodeList)
                {
                    if (s.IsSelected && s.Title != "All")
                        _selectedCount++;
                }
                if (_selectedCount == _nodeList.Count - 1)
                    _nodeList.FirstOrDefault(i => i.Title == "All").IsSelected = true;
                else
                    _nodeList.FirstOrDefault(i => i.Title == "All").IsSelected = false;
            }
            SetSelectedItems();
            SetText();
        }

        private static void OnItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MultiComboBox control = (MultiComboBox)d;
            control.DisplayInControl();
        }

        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register(nameof(ItemsSource),
                typeof(Dictionary<string, object>), typeof(MultiComboBox),
                new FrameworkPropertyMetadata(null, new PropertyChangedCallback
                    (OnItemsSourceChanged)));

        public static readonly DependencyProperty
            SelectedItemsProperty = DependencyProperty.Register
            (nameof(SelectedItems), typeof(Dictionary<string, object>),
            typeof(MultiComboBox), new FrameworkPropertyMetadata(null,
            new PropertyChangedCallback(OnSelectedItemsChanged)));

        private static void OnSelectedItemsChanged
        (DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MultiComboBox control = (MultiComboBox)d;
            control.SelectNodes();
            control.SetText();
        }

        public static readonly
            DependencyProperty TextProperty = DependencyProperty.Register(nameof(Text),
            typeof(string), typeof(MultiComboBox), new UIPropertyMetadata(string.Empty));

        public static readonly DependencyProperty DefaultTextProperty =
            DependencyProperty.Register(nameof(DefaultText), typeof(string),
            typeof(MultiComboBox), new UIPropertyMetadata(string.Empty));

        public Dictionary<string, object> ItemsSource
        {
            get
            {
                return (Dictionary<string, object>)
                    GetValue(ItemsSourceProperty);
            }
            set
            {
                SetValue(ItemsSourceProperty, value);
            }
        }

        public Dictionary<string, object> SelectedItems
        {
            get
            {
                return (Dictionary<string, object>)
                    GetValue(SelectedItemsProperty);
            }
            set
            {
                SetValue(SelectedItemsProperty, value);
            }
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public string DefaultText
        {
            get { return (string)GetValue(DefaultTextProperty); }
            set { SetValue(DefaultTextProperty, value); }
        }
    }
}
