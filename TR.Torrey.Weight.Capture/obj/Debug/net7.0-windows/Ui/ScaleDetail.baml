   M S B A M L   `   `   `  ����S  OTR.Torrey.Weight.Capture, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:TR.Torrey.Weight.Capture.UiTR.Torrey.Weight.Capture.Ui  5      -    'TR.Torrey.Weight.Capture.Ui.ScaleDetail   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [MaterialDesignThemes.Wpf, Version=5.0.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      5local)clr-namespace:TR.Torrey.Weight.Capture.Ui  5         	FormPopup#��[  5	      .��5      � $��10q�6     � RowDefinitions  5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   .+�5      �� $��X��6     MaterialDesignFlatButton#��[ 6G   $��30��6y   $��30��6�   $��0q�6�   ��6!   �� *ClosePopupCommand+6�   5      �� 5   
   $��1��6   $
��0,10q�6!     TextBlockTitle#��[ 6L   ��6/   �� *TxtNewScale+6L   � 5   
   $��2��6   $
��0,10q�6   .+�5      ��   BorderTextBoxGray#��[ 6   ._�5       �� -   5        $	��200��5!      
������ $��0q�5#      $��18(�5$      $	��300��5%      $��Center=�5&      $��5q�5'      $
��10,0q�5(      ���#FFFFFF % !MaterialDesignFloatingHintTextBox#��[ 5*      ��5+      �� *Name+)  #MaterialDesignThemes.Wpf.HintAssist   Hint 5,      �� *	TxtName+5-      5.      5/      � 50   
   $��3��6   .+�51      �� #��[ 6   ._�52      �� -   5        $	��200��53      
������ $��0q�55      $��18(�56      $	��300��57      $��Center=�58      $��5q�59      $
��10,0q�5:      ���#FFFFFF#��[ 5<      ��5=      �� *Ip+ 5>      �� *TxtIp+5?      5@      5B      � 5C   
   $��4��6   $
��0,10q�6   .+�5D      �� #��[ 6   ._�5E      �� -   5        $	��200��5F      
������ $��0q�5H      $��18(�5I      $	��300��5J      $��Center=�5K      $��5q�5L      $
��10,0q�5M      ���#FFFFFF#��[ 5O      ��5P      �� *	MinWeight+ 5Q      �� *TxtMinWeight+5R      5S      5U      � 5W   
   $��5��6   $
��0,10q�6   .+�5X      �� #��[ 6   ._�5Y      �� -   5        $	��200��5Z      
������ $��0q�5\      $��18(�5]      $	��300��5^      $��Center=�5_      $��5q�5`      $
��10,0q�5a      ���#FFFFFF#��[ 5c      ��5d      �� *	MinTime+ 5e      �� *
TxtMinTime+5f      5g      5i      � 5k   
   $��6��6   $
��0,10q�6   .+�5l      ��   TextBlockButton#��[ 6X   ���#E30613��6   �� *	TxtStatus+ �� UpdateSourceTrigger$ PropertyChanged=�6�   5m      � 5o   
   $��7��6   $
��0,10q�6   .+�5p      ��   BorderTextBoxRed#��[ 6   ._�5q      �� -   5         ��Name$ btnSave��5q      $��40��5r      
������ $��0q�5t       " MaterialDesignRaisedDarkButton#��[ 5v      {�5u      �� *DataContext.ControlsEnabled+ �� RelativeSource �� *FindAncestor+ �� AncestorType
 Window � ToolTip 5w      �� *	TxtSave+��5x      �� *SaveCommand+.��5y      �� #��[ 69   ��6    �� *	TxtSave+69   5z      5{      5}      5      5�      