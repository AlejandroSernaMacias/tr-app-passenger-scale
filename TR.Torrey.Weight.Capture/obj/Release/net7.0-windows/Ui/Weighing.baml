   M S B A M L   `   `   `  ���� S  OTR.Torrey.Weight.Capture, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:TR.Torrey.Weight.Capture.UiTR.Torrey.Weight.Capture.Ui  *    $TR.Torrey.Weight.Capture.Ui.Weighing   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     _ [MaterialDesignThemes.Wpf, Version=5.0.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  :d2http://schemas.microsoft.com/expression/blend/2008  5local)clr-namespace:TR.Torrey.Weight.Capture.Ui     StyleUC#��[  .���   � RowDefinitions  �� $
��auto ��� $
��auto ��� $
��auto �.+�� $��0�� � ColumnDefinitions �� $��* ��� $��* ��� $��* �.+�� $��0��.+���   
ItemsFound#��[ ���� *Title+� $��1��.+���   ItemsFoundActive#��[ ���� *TotalSamples+� $��2��.+���   ItemsFoundPending#��[ ���� *TotalWeight+� $��1�� �� $
��auto ��� $��* ��� $
��auto �.+�� $��0��.+��� #��[ ���� *ScalesFound+� $��1��.+��� #��[ ���� *Weight+�� $��2��  BorderTextBoxBlack#��[ $
��10,0q�._��� $��40��
������ $��0q� " MaterialDesignRaisedDarkButton#��[ {��� *DataContext.ControlsEnabled+ �� RelativeSource �� *FindAncestor+ �� AncestorType
 Window � ToolTip �� *	TxtReport+���� *ReportCommand+.����   TextBlockButton#��[ ���� *	TxtReport+� $��2��$
��Left=�$��0,50,0,0q�.+�&   System.Windows.Controls.DataGrid  -     Name$ dgScales��  DataGridDetail#��[  �� SelectedItem �� *SelectedScale+ �� Mode$ TwoWay=����� *Scales+   Columns 0  *System.Windows.Controls.DataGridTextColumn  -   HeaderScaleName��  DataGridHeader,  &System.Windows.Controls.DataGridColumn	   HeaderStyle#	 [ 1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 �� *vName+  -   HeaderIp��#	 [ 
 �� *vIp+  -   HeaderMinWeight��#	 [ 
 �� *
fMinWeight+  -   HeaderSamples��#	 [ 
 �� *
iSamples+  -   HeaderWeight��#	 [ 
 �� *	fWeight+  -   HeaderTotal��#	 [ 
 �� *fTotal+