   M S B A M L   `   `   `  ���� ?  ;DDLM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:DDLMDDLM      DDLM.SingleDdl   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     $localclr-namespace:DDLM     b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  -      MaterialDesignBody#���   $
��auto��$
��auto��$��Stretch=�.��� -     �Name$  	Container��$
��auto�� J� Opacity$ 0Q�z�T�  T� X$
 -150Q�.+�� -   $  DdlBackground��$	 0.5Q� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     Color$ Black��   ShadowDepth$ 1Q�   	Direction$	 270Q�   Opacity$ 0Q�.+�� $��Stretch=�$��Stretch=�  MaterialDesignBackground#���  .+��� -    ��Name$ ProgressRect��$��Stretch=�$
��Left=�  PrimaryHueLightBrush#���  $	 0.5Q�z��� 	 �� ScaleX$	 0Q�� $��10, 10, 0, 10q�$
��Left=�$��Center=�
 � RowDefinitions
 �� $��16 ��� $��28 ��� $��* �.+��� -    ��Name$ ddlTime��$��
0, 0, 0, 5q�  CaptionTextBlock#��[ $��Center=�$��0��时间�� -   $ ddlNameTextBlock��  Headline5TextBlock#��[ $��Center=�$��1��	DDL名称(  "MaterialDesignThemes.Wpf.RatingBar  -     Name$ ddlPriority��$��
0, 5, 0, 0q�$��Center=�   Value$ 3��   
IsReadOnly . $��2���� -   $ leftTimeTextBlock��  Headline2TextBlock#���  $��Right=�$��Center=�
01:01:01� -	   $  BtnPanel��$y�Hidden=�$ 0Q�.+��� $	 0.5Q�  MaterialDesignBodyLight#���  � $	��200�� � ColumnDefinitions �� �� �� .+��� -
    ��Name$ SettingDdlBtn�� / +MaterialDesignFloatingActionMiniLightButton#��[ $ 0Q�  
SettingDdl � ToolTip# �  $��0��z�T�  T� Y$ 25Q�.��'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Settings=�$��24��$��24���� -   $ 
FlowDdlBtn�� .	 *MaterialDesignFloatingActionMiniDarkButton#��[	 $ 0Q� 
 FlowWindowDdl# � 
 $��1��z�T� $ 25Q�.��  $ WindowMaximize=�$��24��$��24���� -   $ DeleteDdlBtn�� 0 ,MaterialDesignFloatingActionMiniAccentButton#��[ $ 0Q�  	DeleteDdl# �  $��2��z�T� $ 25Q�.��  $ Delete=�$��24��$��24��