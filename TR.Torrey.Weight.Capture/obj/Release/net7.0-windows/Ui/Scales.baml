   M S B A M L   `   `   `  ���� S  OTR.Torrey.Weight.Capture, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:TR.Torrey.Weight.Capture.UiTR.Torrey.Weight.Capture.Ui  (    "TR.Torrey.Weight.Capture.Ui.Scales   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     _ [MaterialDesignThemes.Wpf, Version=5.0.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5local)clr-namespace:TR.Torrey.Weight.Capture.Ui     StyleUC#��[  .���   � RowDefinitions  �� $
��auto ��� $
��auto �.+�� $��0�� � ColumnDefinitions �� $
��auto ��� $��* ��� $
��auto �.+�� $��0��.+���   
ItemsFound#��[ ���� *ScalesFound+�� $��1��  BorderTextBoxGray#��[ ._��� 
������ $��0q�$��16(�$��Center=�$
��5,10q����#FFFFFF$	��300��.  (MaterialDesignThemes.Wpf.ColorZoneAssist   Mode$ Light=�.  (MaterialDesignThemes.Wpf.TextFieldAssist   DecorationVisibility$ Visible=� 0 ,MaterialDesignDataGridTextColumnEditingStyle#��[ )  #MaterialDesignThemes.Wpf.HintAssist   Hint �� *
TxtSeach+���� *
FilterText+ �� UpdateSourceTrigger$ PropertyChanged=��� $��2��  BorderTextBoxBlack#��[ $
��10,0q�._��� -   $	��200��$��40��
������ $��0q� " MaterialDesignRaisedDarkButton#��[  � ToolTip �� *TxtNew+{��� *DataContext.ControlsEnabled+ �� RelativeSource �� *FindAncestor+ �� AncestorType
 Window.����   TextBlockButton#��[ ���� *TxtNew+� $��1��$
��Left=�$��0,50,0,0q�.+�&   System.Windows.Controls.DataGrid  -   	  Name$	 dgScales��  DataGridDetail#��[ 
 �� SelectedItem
 �� *SelectedScale+ �� Mode$ TwoWay=����� *Scales+   Columns 4  .System.Windows.Controls.DataGridTemplateColumn  -   HeaderScaleName��  DataGridHeader,  &System.Windows.Controls.DataGridColumn   HeaderStyle# [    CellTemplate �� .R��� #��[ $	��250��._��� -   
������ $��0q�$��16(�$��Center=�$��5q�$
��10,0q����#FFFFFF %	 !MaterialDesignFloatingHintTextBox#��[	  �� *	TxtName+���� *vName+$ PropertyChanged=�0  *System.Windows.Controls.DataGridTextColumn  -   HeaderIp��# [ 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *vIp+  -   HeaderMinWeight��# [  �� .R��� #��[ $	��250��._��� -   
������ $��0q�$��16(�$��Center=�$��5q�$
��10,0q����#FFFFFF#��[	  �� *TxtMinWeight+���� *
fMinWeight+$ PropertyChanged=�  -   HeaderActions��# [  �� .R��  �� $��* ��� $��* �.+��� $��0��._��� -	   
������ $��0q�#��[  �� *	TxtSend+���� .��'	  !MaterialDesignThemes.Wpf.PackIcon	   	  Kind$
 Edit=�$��50��$��50(�
����  ��� $��1��._��� -
   
������ $��0q�#��[  �� *	TxtSend+���� .��	  $ Delete=�$��50��$��50(�
���  ��