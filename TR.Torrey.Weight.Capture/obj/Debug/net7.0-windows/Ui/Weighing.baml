   M S B A M L   `   `   `  ����S  OTR.Torrey.Weight.Capture, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:TR.Torrey.Weight.Capture.UiTR.Torrey.Weight.Capture.Ui  5      *    $TR.Torrey.Weight.Capture.Ui.Weighing   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      _ [MaterialDesignThemes.Wpf, Version=5.0.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      5local)clr-namespace:TR.Torrey.Weight.Capture.Ui  5         StyleUC#��[  5	      .��5      � $��10q�6     � RowDefinitions  5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��* �6#   �� 5      $��* �6#   .+�5      � $��0��6   .+�5      ��   
ItemsFound#��[ 62   ��6   �� *Title+62   5      � 5      $��1��6   .+�5      ��   ItemsFoundActive#��[ 69   ��6   �� *TotalSamples+69   5      � 5      $��2��6   .+�5       ��   ItemsFoundPending#��[ 68   ��6   �� *TotalWeight+68   5!      5#      � 5$   
   $��1��6    5%      �� 5&      $
��auto �6#   �� 5'      $��* �6#   �� 5(      $
��auto �6#   .+�5+      � $��0��6   .+�5,      �� #��[ 68   ��6   �� *ScalesFound+68   5-      � 5.      $��1��6   .+�5/      �� #��[ 63   ��6   �� *Weight+63   50      �� 52      $��2��6     BorderTextBoxBlack#��[ 6%   $
��10,0q�6Q   ._�53      �� $��40��54      
������ $��0q�56       " MaterialDesignRaisedDarkButton#��[ 58      {�57      �� *DataContext.ControlsEnabled+ �� RelativeSource �� *FindAncestor+ �� AncestorType
 Window � ToolTip 59      �� *	TxtReport+��5:      �� *ReportCommand+.��5;      ��   TextBlockButton#��[ 6;   ��6    �� *	TxtReport+6;   5<      5=      5?      &   System.Windows.Controls.DataGrid  5A   
   $��2��6      AutoGenerateColumns$ False��6       CanUserAddRows$ False��6<      CanUserDeleteRows$ False��6S   $��10,50,10,10q�6�   
������ 
������ $��1q�6�     MaterialDesignDataGrid#��[ 6�   ��6m   �� *Scales+ � 	Resources 5C      =  7System.Windows.Controls.Primitives.DataGridColumnHeader	 �� 
TargetType
 �� Property �� Value)  #System.Windows.Controls.DataGridRow��%C  '        '  �     �� 5E      "	  6   .�5F      �� 
 � �� �#009c3663   �� 5G      
 � ��
 �����63   �� 5H      
 � ��$
 Bold"�63   �� 5I      
 � ��$ 10q�60   5J      �� 5L      "	  6   .�5M      �� 
 � �� �#41414164   �� 5N      
 � ��$ 1q�68   5O      5P         Columns 5R      0  *System.Windows.Controls.DataGridTextColumn  5S      -   5        HeaderScaleName��,  &System.Windows.Controls.DataGridColumn   
IsReadOnly$
 True��5S   �      
Foreground �#414141   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6A   �� *vName+ �� UpdateSourceTrigger$ PropertyChanged=�6�     5T      -   5        HeaderIp��$
 True��5T   ~    �#414141$ * 6�    6A   �� *vIp+$ PropertyChanged=�6�     5U      -   5        HeaderMinWeight��$
 True��5U   �    �#414141$ * 6�    6A   �� *
fMinWeight+$ PropertyChanged=�6�     5V      -   5        HeaderMinTime��$
 True��5V   �    �#414141$ * 6�    6A   �� *
iMinTime+$ PropertyChanged=�6�     5W      -   5        HeaderScaleStatus��$
 True��5W   �   $ * 6�    6A   �� *vStatusScale+$ PropertyChanged=� 6�   �� *vStatusColor+6�     5X      -   5        HeaderSamples��$
 True��5X   �    �#414141   
FontWeight$
 Bold"�6�   $ * 6�    6A   �� *
iSamples+$ PropertyChanged=�6�     5Y      -   5        HeaderWeight��$
 True��5Y   �    �#414141$
 Bold"�6�   $ * 6�    6A   �� *	fWeight+$ PropertyChanged=�6�     5Z      -   5        HeaderTotal��$
 True��5Z   �    �#414141$ * 6�    6A   �� *fTotal+$ PropertyChanged=�6�   5\      5^      5_      