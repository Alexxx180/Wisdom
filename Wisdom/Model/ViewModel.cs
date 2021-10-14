using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
//using static Wisdom.Writers.Content;
using static Wisdom.Customing.Converters;
using static Wisdom.Customing.BlockTemplates;
using static Wisdom.Customing.ResourceHelper;
using static Wisdom.Customing.Decorators;
using static Wisdom.Writers.Content;
using System.Windows;

namespace Wisdom.Model
{
    class ViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises this object's PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The property that has a new value.</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            //PropertyChangedEventHandler handler = PropertyChanged;
            //if (handler != null)
            //{
            //    PropertyChangedEventArgs e = new PropertyChangedEventArgs(propertyName);
            //    handler(this, e);
            //}
        }
        #endregion

        private List<string> _levels;
        public List<string> Levels
        {
            get { return _levels; }
            set { _levels = value; }
        }
        private static void AddLevel(object sender, RoutedEventArgs e)
        {
            //ThemeLevel.GetBindingExpression(ComboBox.ItemsSourceProperty).UpdateTarget();
            //OnPropertyChanged(nameof(ThemeLevel.ItemsSource));
        }
        private static Grid NextLevel()
        {
            Grid grid = GridItem3();
            //                    <Button Click = "AddLevel" Style="{StaticResource ResourceKey=AddButton}"></Button>
            Button delete = new Button { Style = GetStyle("AddButton") };
            delete.Click += AddLevel;
            Label no = new Label { Style = GetStyle("No1"), Content = "1." };
            TextBox name = new TextBox { Text = "", Style = GetStyle("RegularBox") };
            TextBox hours = new TextBox { Text = "", Style = GetStyle("RegularBox") };
            GridAddX2(grid, 0, delete, no, name, hours);
            
            return grid;
        }
        private UIElementCollection _levelsSource = new UIElementCollection(new StackPanel(), new StackPanel())
        {
            NextLevel()
        };
        public UIElementCollection LevelsSource
        {
            get { return _levelsSource; }
            set
            {
                _levelsSource = value;
                Levels = LevelsReset(_levelsSource);
                OnPropertyChanged("Levels"); // уведомление View о том, что изменилась
            }
        }
        private List<string> LevelsReset(UIElementCollection grids)
        {
            List<string> items = new List<string>();
            for (byte i = 0; i < grids.Count - 1; i++)
            {
                Grid grid = grids[i] as Grid;
                Label lab = grid.Children[1] as Label;
                string text = lab.Content.ToString();
                items.Add(text);
            }
            return items;
        }

        //<Grid x:Name="NextLevel" Tag="{x:Reference LevelsText}">
        //                    <Grid.ColumnDefinitions>
        //                        <ColumnDefinition Width = "0.05*" />
        //                        < ColumnDefinition Width="0.15*" />
        //                        <ColumnDefinition Width = "0.3*" />
        //                        < ColumnDefinition Width="0.5*" />
        //                    </Grid.ColumnDefinitions>

        //                    <Button Click = "AddLevel" Style="{StaticResource ResourceKey=AddButton}"></Button>
        //                    <Label Grid.Column="1" Content= "4." Style= "{StaticResource No1}" ></ Label >
        //                    < TextBox Grid.Column= "2" Text= "" Style= "{StaticResource RegularBox}" ></ TextBox >
        //                    < TextBox Grid.Column= "3" Text= "" Style= "{StaticResource RegularBox}" ></ TextBox >
        //                </ Grid >
    }
}
