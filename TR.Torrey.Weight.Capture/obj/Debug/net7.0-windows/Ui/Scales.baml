   M S B A M L   `   `   `  ����S  OTR.Torrey.Weight.Capture, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:TR.Torrey.Weight.Capture.UiTR.Torrey.Weight.Capture.Ui  5      (    "TR.Torrey.Weight.Capture.Ui.Scales   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [MaterialDesignThemes.Wpf, Version=5.0.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      5local)clr-namespace:TR.Torrey.Weight.Capture.Ui  5         StyleUC#��[  5	      .��5      � $��10q�6     � RowDefinitions  5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      $
��auto �6#   �� 5      $��* �6#   �� 5      $
��auto �6#   .+�5      � $��0��6   .+�5      ��   
ItemsFound#��[ 68   ��6   �� *ScalesFound+68   5      �� 5      $��1��6     BorderTextBoxGray#��[ 6%   ._�5      �� 
������ $��0q�5      $��16(�5       $��Center=�5!      $
��5,10q�5"      ���#FFFFFF$	��300��5$      .  (MaterialDesignThemes.Wpf.ColorZoneAssist   Mode$ Light=�5%      .  (MaterialDesignThemes.Wpf.TextFieldAssist   DecorationVisibility$ Visible=�5&       0 ,MaterialDesignDataGridTextColumnEditingStyle#��[ 5(      )  #MaterialDesignThemes.Wpf.HintAssist   Hint 5'      �� *
TxtSeach+��5)      �� *
FilterText+ �� UpdateSourceTrigger$ PropertyChanged=�5*      �� 5,      $��2��6     BorderTextBoxBlack#��[ 6%   $
��10,0q�6Q   ._�5-      �� $	��200��5.      $��40��5/      
������ $��0q�51       " MaterialDesignRaisedDarkButton#��[ 54       � ToolTip 52      �� *TxtNew+{�53      �� *DataContext.ControlsEnabled+ �� RelativeSource �� *FindAncestor+ �� AncestorType
 Window��55      �� *
NewCommand+��56      ��  �� 	 �� Mode$
	 Self=�.��57      ��   TextBlockButton#��[ 68   ��6    �� *TxtNew+68   58      59      5;      &   System.Windows.Controls.DataGrid  5=   
   $��1��6   
   AutoGenerateColumns$
 False��6       CanUserAddRows$ False��6<      CanUserDeleteRows$ False��6S   $��10,50,10,10q�6�   
������ 
������ $��1q�6�     MaterialDesignDataGrid#��[ 6�   ��6m   �� *Scales+ � 	Resources 5?      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value)  #System.Windows.Controls.DataGridRow��%C  '        '  �     �� 5A      "  6   .�5B      ��  � �� �#009c3663   �� 5C       � ��
 �����63   �� 5D       � ��$
 Bold"�63   �� 5E       � ��$ 10q�60   5F      �� 5H      "  6   .�5I      ��  � �� �#41414164   �� 5J       � ��$ 1q�68   5K      5L         Columns 5N      0  *System.Windows.Controls.DataGridTextColumn  5O      -   5        	hName��,  &System.Windows.Controls.DataGridColumn   
IsReadOnly$
 True��5O   s      
Foreground �#414141   Width5	  /System.Windows.Controls.DataGridLengthConverter$ *	 6�   1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding 64   �� *vName+$ PropertyChanged=�6�     5P      -   5        hIp��$
 True��5P   o    �#414141$ *	 6�    62   �� *vIp+$ PropertyChanged=�6�     5Q      -   5        
hMinWeight��$
 True��5Q   }    �#414141$ *	 6�    69   �� *
fMinWeight+$ PropertyChanged=�6�     5R      -   5        hLastUpdate��$
 True��5R   �    �#414141$ *	 6�    6:   �� *dtLastUpdate+$ PropertyChanged=�6�   4  .System.Windows.Controls.DataGridTemplateColumn  5T      -   5        hActions��   CellTemplate 5U      �� 5V      .R�5X      �  5Y   "   �� 5Z   &   $
��auto �67   �� 5[   &   $
��auto �67   .+�5^   "   �� $��0��6)   ._�5_   &   �� 
������ $��0q�5a   -   #��[ 5b   -    5c   -   �� *	TxtEdit+��5d   -   �� *DataContext.EditCommand+ ��  UserControl��5e   -   �� .��5f   *   '  !MaterialDesignThemes.Wpf.PackIcon     Kind$
 Edit=�6B   $��50��6N   $��50(�6Y   ���#4141416g   5g   '   5i   #   �� 5k   "   $��1��6)   ._�5l   &   �� 
������ $��0q�5n   -   #��[ 5o   -    5p   -   �� *	TxtDelete+��5q   -   �� *DataContext.DeleteCommand+ ��  UserControl��5r   -   �� .��5s   *     $ Delete=�6B   $��50��6P   $��50(�6[   ���#E306136i   5t   '   5u   #   5w      5z      5|      5      5�      5�      