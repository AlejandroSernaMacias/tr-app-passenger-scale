   M S B A M L   `   `   `  ���� S  OTR.Torrey.Weight.Capture, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:TR.Torrey.Weight.Capture.UiTR.Torrey.Weight.Capture.Ui  -    'TR.Torrey.Weight.Capture.Ui.ScaleDetail   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     _ [MaterialDesignThemes.Wpf, Version=5.0.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5local)clr-namespace:TR.Torrey.Weight.Capture.Ui     StyleUC#��[  .���   � RowDefinitions  �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto �.+�� $��0��$
��0,10q�.+���   BorderTextBoxGray#��[ ._��� -   $	��200��
������ $��0q�$��18(�$	��300��$��Center=�$��5q�$
��10,0q����#FFFFFF % !MaterialDesignFloatingHintTextBox#��[ ���� *Name+)  #MaterialDesignThemes.Wpf.HintAssist   Hint �� *	TxtName+� $��1��.+��� #��[ ._��� -   $	��200��
������ $��0q�$��18(�$	��300��$��Center=�$��5q�$
��10,0q����#FFFFFF#��[ ���� *Ip+ �� *TxtIp+� $��2��$
��0,10q�.+��� #��[ ._��� -   $	��200��
������ $��0q�$��18(�$	��300��$��Center=�$��5q�$
��10,0q����#FFFFFF#��[ ���� *	MinWeight+ �� *TxtMinWeight+� $��3��$
��0,10q�.+���   BorderTextBoxRed#��[ ._��� -    ��Name$ btnSave��$��40��
������ $��0q� " MaterialDesignRaisedDarkButton#��[ {��� *DataContext.ControlsEnabled+ �� RelativeSource �� *FindAncestor+ �� AncestorType
 Window � ToolTip �� *	TxtSave+���� *SaveCommand+.����   TextBlockButton#��[ ���� *	TxtSave+