   M S B A M L   `   `   `  ���� A  =Wisdom, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Wisdom.Binds.ConvertersWisdom.Binds.Converters  Y1clr-namespace:Wisdom.Controls.Tables.Hours.Groups#Wisdom.Controls.Tables.Hours.Groups  H    BWisdom.Controls.Forms.DocumentForms.AddDisciplineProgram.HoursPart   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     <
converters%clr-namespace:Wisdom.Binds.Converters     Chours1clr-namespace:Wisdom.Controls.Tables.Hours.Groups        
GlobalFont#��[    � DataContext  ��  �� RelativeSource �� *Self+ � 	Resources 1   +Wisdom.Binds.Converters.UsedValuesConverter  UsedValuesConverter,   &Wisdom.Binds.Converters.HoursConverter  HoursConverter��%   &	       &	          .��� -    �Name$ TreeContext��$��1��  ��  �� Path$ 	ViewModel� � ColumnDefinitions �� $��0.05* ��� $
��0.9* ��� $��0.05* � � RowDefinitions �� $��0.05* ��� $
��0.1* ��� $��0.05* ��� $��0.75* ��� $��0.05* �.+�� $��1��$��1��$
��Bold"� �� $��0.475* ��� $��0.05* ��� $��0.475* �.+��  �� �� .+�(� $��Bottom=�$
��Left=�.���� $ ��Специальность�� �� Padding$ 0q��� $��1�� �� 
IsEditable$
 True��$
��Bold"����� 	 �� ResourceKey$	 
NeutralPad������ $	 ItemsBox������ $ SpecialitySelect�
 �� SelectedIndex
 �� $ SpecialityNo� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� Text �� $ SpecialityFullName�$ TwoWay=�$ 	LostFocus=�� $��2�� �� �� .+�(� $��Bottom=�$
��Left=�.���� $��Дисциплина���� $��1��$��1��$
 True��$
��Bold"����� $	 
NeutralPad������ $	 ItemsBox������ $ DisciplinesSelect�
 �� $ DisciplineNo�$ TwoWay=�$ PropertyChanged=� �� $ DisciplineFullName�$ TwoWay=�$ PropertyChanged=�� $��3��$��1�� 	 Light#��[  �� �� $��35 �.+��� ���� $ 
HourGroups�� $��1��  Dark#��[  �� $��0.75* ��� $��0.25* �.+�(� $
��Left=�.���� $<��6 Максимальная нагрузка, часы: ���� $��1������ $	 Light��._�(� $��Right=�.���� ���� *
MaxHours+