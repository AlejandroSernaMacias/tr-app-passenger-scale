   M S B A M L   `   `   `  ���� O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  S OTR.Torrey.Weight.Capture, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:TR.Torrey.Weight.Capture.Viewmodels#TR.Torrey.Weight.Capture.Viewmodels 4   .TR.Torrey.Weight.Capture.Viewmodels.MainWindow   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     _ [MaterialDesignThemes.Wpf, Version=5.0.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  3System&clr-namespace:System;assembly=mscorlib  =local1clr-namespace:TR.Torrey.Weight.Capture.Viewmodels    � WindowStartupLocation$  CenterScreen=�   StyleWindow#��[   � WindowState$ 	Maximized=�.��)  #MaterialDesignThemes.Wpf.DialogHost  -     Name$ 	dgContent��   CloseOnClickAway$
 True��.���  � ColumnDefinitions �� $
��auto ��� $��* �.+�� $��0��$
��Left=� � RowDefinitions �� $
��auto ��� $��* �.+�� $��0��$	��150��$��Bottom=�.+���   iconViva#��[ $��Uniform=�$	��150��� $��1�����#009c36 �� $
��auto ��� $
��auto ��� $��* �.+�� -    �Name$ Scales��$��0�� � Cursor$
 Hand��$��0,20,0,5q� �� $
��auto ��� $��* �.+��� $��0��  iconWeighings#��[   	ImageItem#��[ �� $��1��$��	Básculas��  TextBlockItem#��[ � -   $ 
ScalesList��$��1��$
 Hand��$	��0,5q� �� $
��auto ��� $��* �.+��� $��0��#��[ #��[ �� $��1��$��Básculas en linea��#��[ � $��2��$��Bottom=�.+��� -    ��Name$ SoftwareVersion��$��Básculas en linea��#��[ � $��1�� �� $��60 ��� $��* �.+�� $��1��.+��� -   	 ��Name$	 MainScrollViewer��1  +MaterialDesignThemes.Wpf.ScrollViewerAssist
   IsAutoHideEnabled$

 True��$
��Auto=�$
��Left=�$
��Auto=�$
��auto��$
��auto��.���� -    ��Name$ ContentMenu�� � DataContext �� *SelectedItem+���� *	Content+ �� FallbackValue Z�  �� UpdateSourceTrigger$ PropertyChanged=�   DialogContent � 
������� �� $
��auto ��� $
��auto �.+�� -   $ dgError��$��0��$��20q� �� $��* ��� $��* �.+��� -   $ msgError��$��0��$��Error��  TextBlockTitle#��[ ���#414141�� -	    ��Name$ bdrBtnCloseMessage��$��1��  BorderButton#��[ ���#414141���#414141$	��150��$��0,10,0,0q�._��� -
    ��Name$ btnCloseMessage��$��50��
������ ���#333333$��0q� � ToolTip$ Download file�� " MaterialDesignRaisedDarkButton#��[ {��� *DataContext.ControlsEnabled+ �� RelativeSource �� *FindAncestor+ �� AncestorType
 Window.����  �� Orientation$ 
Horizontal=�.+��� -   $ txtbtnCloseMessage��