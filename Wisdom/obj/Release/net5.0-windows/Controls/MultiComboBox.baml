   M S B A M L   `   `   `  ���� A  =Wisdom, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Wisdom.ControlsWisdom.Controls  #    Wisdom.Controls.MultiComboBox   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     /localclr-namespace:Wisdom.Controls     .���� -     ��Name$  MultiSelectCombo�� J� SnapsToDevicePixels$
 True�� � OverridesDefaultStyle$
 True��$
��Auto=�$
��Auto=�$
��True��$ �� IsSynchronizedWithCurrentItem$
 TrueY����� .R��� ���� *Title+ d� 	IsChecked ��  �� Path$ 
IsSelected� �� Mode$ TwoWay=�
 � Tag �� *FindAncestor+ �� AncestorType" ������ 	 �� 
TargetType"	 ��.R�� .+�d� 
 d�Name$
 ToggleButton��$��2��$|�false�� �� 	ClickMode$ Press=�$
��Left=� �� $ IsDropDownOpen�$ TwoWay=� �� RelativeSource �� *TemplatedParent+���� .R��  � ColumnDefinitions �� $��* ��� $��18 �.+���  ��Name$ Border��$��2�� �� CornerRadius$ 2��
�������
���   �$��1,1,1,1q��� $ 
BorderComp��$��0��$ 2��$��1q�
�������
���   �$��0,0,0,0q�._��� 
������� �� Padding$ 3q����� $
 Text� ��  �� Mode$ FindAncestor=�" >�F�  F�Name$ Arrow��$��1��
���   �$��Center=�$��Center=�"����        � 	=  	= � z     	� $��Popup��$��Bottom=� � AllowsTransparency$
 True�� �� IsDropDownOpen#��z $��Slide=�$|�False��.��� $��DropDown��$
 True�� � ActualWidth#��z  �� MaxDropDownHeight#��z .+��� $ DropDownBorder��$��1q�
�������
���   ��� $��4,6,4,6q�$
 True�� � DataContext �� .����  K� IsItemsHost$
 True��-  'System.Windows.Input.KeyboardNavigation   DirectionalNavigation$ 	Contained=� �� Triggers P�  P� Property �@��HasItems P� Value$ false��. ���  �� 
TargetName$ DropDownBorder�� �� Property � �� �� Value$ 95��P�   P� 
SourceName$  Popup�� �@�AllowsTransparency$
 true��. ��� $ DropDownBorder�� �@��CornerRadius$ 4���� $ DropDownBorder�� � ��$ 0,2,0,0q�