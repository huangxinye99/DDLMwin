   M S B A M L   `   `   `  ���� ?  ;DDLM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:DDLMDDLM      DDLM.SettingPage   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  localclr-namespace:DDLM    N� Title$  SettingPage�� � 	Resources    DDLM.WidthConverter   WidthConverter��%   &	          .��� .+��� $��Hidden=�$��Stretch=�.���� -    ��Name$ 	Container��$��10q� J� Opacity$ 0Q�.+���  �� Orientation$ 
Horizontal=�$ 0Q�z�T�  T� Y$	 100Q�.+��� $��0��  Subtitle2TextBlock#��[   MaterialDesignBody#���    LangText#���  $
��Left=�$��Center=�$��10, 10, 0, 0q��� $��1��$
��Left=�$��Center=�$��20, 10, 0, 0q�$��80��.+��� -    ��Name$ LanguageComboBox��#���  .@��� $��Consolas)�
 � Tag$ zh-CN��.��简体中文�� $��Consolas)�$ en-US��.��	English�� -    ��Name$ AutoStartCheckBox��  CheckBox#��[ #���  $��Center=�$
��Left=�	 d� 	IsChecked$	 FalseY�  AutoStartText#���  $��10, 20, 10, 0q�$ 0Q�z�T� $	 100Q��� $��30��� $��0, 20, 0, 0q�
 � RowDefinitions
 �� �� .+��� #��[ #���  $��Center=�$��0��  	ThemeText#���  $ 0Q�z�T� $	 100Q�� $��1�� � ColumnDefinitions �� $
��auto ��� .+�� $��0��$��5q�
 �� �� �� .+��� -   $ DarkCheckBox��#��[ #���  $��Center=�$
��Left=�$��5, 0, 0, 20q�$��0��$ 0Q����� ����  �� 
TargetType" �� �� Triggers ��  �� Binding ��  �� ElementName$ DarkCheckBox�� �� Path$ 	IsChecked� �� Value	 false.a���  �� Property � ��  	LightText �� Value# �  ��  �� $ DarkCheckBox��$ 	IsChecked� true.a���  � ��  DarkText# �  z�T� $	 100Q�� $��1��$��0, 0, 0, 20q�$ 0Q� �� $	��100 ��� z�T� $	 100Q�.+��� -    ��Name$ PrimaryColorTextBlock��$
��Wrap=�#��[ #���  $��Center=�$
��Left=�$��7, 0, 0, 20q�$��0�� 	 PrimaryColorText#��� 	 � -    �Name$ PrimaryColorBtnPanel��$
��Left=�$��1������ $ 	Container��$ ActualWidth� �� 	Converter# [   �� ConverterParameter$	 120��� $��2��$ 0Q� �� $	��100 ��� ���� $ 	Container��$ Width�z�T� $	 100Q�.+��� $
��Wrap=�#��[ #���  $��Center=�$
��Left=�$��
7, 0, 0, 0q�$��0�� 
 SecondaryColorText#��� 
 � -   $ SecondaryColorBtnPanel��$��1������ $ PrimaryColorBtnPanel��$ Width��� $��30��� 
 �� �� �� .+��� #��[ #���  $��0, 0, 0, 20q�$��Center=�$��0��  	SoundText#���  $ 0Q�z�T� $	 100Q�� $��1��$��7, 0, 7, 20q�$��Center=�$ 0Q� �� �� $��60 �z�T� $	 100Q�.+��� -    ��Name$ AlarmPathTextBox��  AlarmPathText)  #MaterialDesignThemes.Wpf.HintAssist   Hint# �    FloatingHintTextBox#��[ #���  $��Center=�$��0���� -	    ��Name$ AlarmPathLocateBtn�� * &MaterialDesignFloatingActionMiniButton#��[ $��1��.��'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Location=�$��24��$��24��� $��2��$ 0Q�
 �� �� z�T� $	 100Q�.+��� -
    ��Name$ AlarmVolumeSlider�� � Minimum$ 0Q� � Maximum$	 100Q� � Value$ 49Q�  �� IsSnapToTickEnabled  . $��0��$
��7, 0q�$��Center=��� -   ! ��Name$! alarmVolumeLabel��$��0, 10, 0, 0q�#���  $��Center=�$��1��  AlarmVolumeText# �  ���� $ Value�$ AlarmVolumeSlider��