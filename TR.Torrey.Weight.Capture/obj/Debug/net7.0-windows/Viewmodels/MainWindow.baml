   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	   S OTR.Torrey.Weight.Capture, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:TR.Torrey.Weight.Capture.Viewmodels#TR.Torrey.Weight.Capture.Viewmodels 5   	   4   .TR.Torrey.Weight.Capture.Viewmodels.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=5.0.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   3System&clr-namespace:System;assembly=mscorlib  5   	   =local1clr-namespace:TR.Torrey.Weight.Capture.Viewmodels  5   	     � WindowStartupLocation$  CenterScreen=�5
   	      StyleWindow#��[  5   	    � WindowState$ 	Maximized=�5   	   .��5      )  #MaterialDesignThemes.Wpf.DialogHost  -   5          Name$ 	dgContent��5   8      CloseOnClickAway$
 True��6    .��5   
   �  � ColumnDefinitions 5      �� 5      $
��auto �6#   �� 5      $��* �6#   .+�5      � $��0��6   $
��Left=�6#    � RowDefinitions 5      �� 5      $
��auto �6$   �� 5      $��* �6$   .+�5      � $��0��6   $	��150��6$   $��Bottom=�64   .+�5      ��   iconViva#��[ 6   $��Uniform=�6?   $	��150��6Q   5       � 5!      $��1��6   ���#009c36 5"      �� 5#      $
��auto �6(   �� 5$      $
��auto �6(   �� 5%      $��* �6(   .+�5(      � -   5         �Name$ Scales��5(   (   $��0��6    � Cursor$
 Hand��6U   $��0,20,0,5q�6c    5)      �� 5*      $
��auto �6/   �� 5+      $��* �6/   .+�5.      �� $��0��6      iconWeighings#��[ 60     	ImageItem#��[ 6X   �� 5/      $��1��6$   $��	Básculas��64     TextBlockItem#��[ 6D   50      � 51      -   5        $ 
ScalesList��51   (   $��1��6   $
 Hand��6a   $	��0,5q�6o    52      �� 53      $
��auto �6/   �� 54      $��* �6/   .+�57      �� $��0��6    #��[ 60   #��[ 6X   �� 58      $��1��6$   $��Básculas en linea��64   #��[ 6M   59      � 5:      $��2��6   $��Bottom=�6(   .+�5;      �� -   5         ��Name$ SoftwareVersion��5;   $   $��Básculas en linea��6=   #��[ 6V   5<      5=      5>      � 5@      $��1��6    5B      �� 5C      $��60 �6$   �� 5D      $��* �6$   .+�5G      � $��1��6   .+�5H      �� -   5        	 ��Name$	 ContentMenu��5H   %   5I      5K      5M      
   DialogContent
 5P   
   � 5Q      
������� 5R      �� 5S      $
��auto �6$   �� 5T      $
��auto �6$   .+�5W      � -   5        $ dgError��5W   $   $��0��6   $��20q�65    5X      �� 5Y      $��* �6(   �� 5Z      $��* �6(   .+�5]      �� -   5        $ msgError��5]   -   $��0��6    $��Error��6?     TextBlockTitle#��[ 6L   ���#4141416t   �� 5_      -   5         ��Name$ bdrBtnCloseMessage��5_   *   $��1��6     BorderButton#��[ 6F   ���#414141���#414141$	��150��6�   $��0,10,0,0q�6�   ._�5`      �� -	   5         ��Name$ btnCloseMessage��5`   !   $��50��5a   !   
������ ���#333333$��0q�5d   !    � ToolTip$ Download file��5e   !    " MaterialDesignRaisedDarkButton#��[ 5g   !   {�5f   !   �� *DataContext.ControlsEnabled+ �� RelativeSource �� *FindAncestor+ �� AncestorType
 Window.��5i      ��  �� Orientation$ 
Horizontal=�6)   .+�5j   "   �� -
   5        $ txtbtnCloseMessage��5j   ,   6J   5k      5l      5m      5n      5p      5s      5t      