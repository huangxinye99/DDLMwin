   M S B A M L   `   `   `  ���� ?  ;DDLM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:DDLMDDLM      DDLM.DdlSettingWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     $localclr-namespace:DDLM     b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  -     � Title$  Deadline设置��$	��550��$	��500��$	��400�� � AllowsTransparency .  � WindowStyle$
 None=�   MaterialDesignBackground#���     MaterialDesignBody#���   � WindowStartupLocation$ CenterScreen=�.��� -    �Name$ 	Container��+  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth5=� � RowDefinitions �� $��* ��� $��10 ��� $
��0.5* ��� $��10 ��� $
��1.5* ��� $��10 ��� $
��1.5* ��� $��10 ��� $
��1.2* ��� $��10 ��� $
��0.5* ��� $��20 ��� $��2* ��� $��10 ��� $��* �.+��� -    ��Name$ DdlNameTextBox��  TextBox#��[   DdlName)  #MaterialDesignThemes.Wpf.HintAssist   Hint# �  $��0��$��30��$��	10,8,10,9q�$��Stretch=�$��Stretch=�(  "MaterialDesignThemes.Wpf.RatingBar  -   	  Name$	 DdlPriority��  Priority# �  $��Center=�$��Center=�$��2��
   Value$
 0��   
IsReadOnly .  � $��4�� �� �� $��20 �.+���   OverlineTextBlock#��[ $��1��$��Center=�$��Center=�  	StartTime#���  � $��0�� � ColumnDefinitions �� $��75 ��� �� .+��� -    ��Name$ ChineseCheckbox��$
��auto��$��0��$��
5, 0, 0, 0q�$��Center=�  MaterialDesignCheckBox#��[ .��农历� -   $ 	StartDate��$��
0, 0, 5, 0q�$��1�� �� �� �� .+��� -   $ 	StartYear�� % !MaterialDesignFloatingHintTextBox#��[ $��0��$��5q� 	 Year# � 	 .������  �� ElementName$ TrashBin�� �� Path$
 Text� �� Mode$ OneWayToSource=� �� UpdateSourceTrigger$ PropertyChanged=�.���� -   $ 
StartMonth��#��[ $��1��$��5q� 	
 Month# � 
 .������ $ TrashBin��$
 Text�$ OneWayToSource=�$ PropertyChanged=�.���� -	   $ StartDay��#��[ $��2��$��5q�  Day# �  .������ $ TrashBin��$
 Text�$ OneWayToSource=�$ PropertyChanged=�.��)  #MaterialDesignThemes.Wpf.TimePicker  -
     Name$ StartTimePicker��$��30��# �  $��Consolas)�   	Is24Hours .    WithSeconds . $��2��$��0, 0, 10, 5q�$��Bottom=�$��Stretch=�� $��6�� �� �� $��20 �.+��� #��[ $��1��$��Center=�  EndTime#���  7  1MaterialDesignThemes.Wpf.Transitions.Transitioner   �� SelectedIndex$ 0��$��0��.@�<  6MaterialDesignThemes.Wpf.Transitions.TransitionerSlide     TransitionOrigin$ 	0.25, 0.5&�   ForwardWipe 3  -MaterialDesignThemes.Wpf.Transitions.FadeWipe  .��� -   $ EndTimeGrid�� J� Opacity$ 1Q� �� $��75 ��� .+��� -    ��Name$ 
EndTimeBtn��$��0��  FlatLightBgButton#��[ $
��8, 0q�   MoveNextCommand#��Z $��12(� 
 EndBtn#���  � $��1�� �� �� .+�� -   $ EndDate��  EndDate
 � Tag# �  $��
0, 0, 5, 0q�$��0�� �� �� �� .+��� -   $ EndYear��  FloatingHintTextBox#��[ $��0��$��5q�# � 	 .������ $ TrashBin��$
 Text�$ OneWayToSource=�$ PropertyChanged=�.���� -   $ EndMonth��#��[ $��1��$��5q�# � 
 .������ $ TrashBin��$
 Text�$ OneWayToSource=�$ PropertyChanged=�.���� -   $ EndDay��#��[ $��2��$��5q�# �  .������ $ TrashBin��$
 Text�$ OneWayToSource=�$ PropertyChanged=�.��  -   $ EndTimePicker��$��30��# �  $��Consolas)� .  . $��1��$��0, 0, 10, 5q�$��Bottom=�$��Stretch=�  $ 	0.25, 0.5&�   BackwardWipe   .��� -   $ DurationGrid�� �� $��75 ��� .+��� -   $ DurationBtn��#��[ $��0��$
��8, 0q�$��12(�   MovePreviousCommand#��Z   DurationBtn#���  � $��1��$��
0, 0, 5, 0q� �� �� �� �� �� �� .+��� -   $ DurationYear��#��[ $��0��$��5q�# � 	 .������ $ TrashBin��$
 Text�$ OneWayToSource=�$ PropertyChanged=�.���� -   $ DurationMonth��#��[ $��1��$��5q�# � 
 .������ $ TrashBin��$
 Text�$ OneWayToSource=�$ PropertyChanged=�.���� -   $ DurationDay��#��[ $��2��$��5q�# �  .������ $ TrashBin��$
 Text�$ OneWayToSource=�$ PropertyChanged=�.���� -   $ DurationHour��#��[ $��3��$��5q�  Hour# �  .������ $ TrashBin��$
 Text�$ OneWayToSource=�$ PropertyChanged=�.���� -   $ DurationMinute��#��[ $��4��$��5q� 
 Minute# �  .������ $ TrashBin��$
 Text�$ OneWayToSource=�$ PropertyChanged=�.���� -   $ DurationSecond��#��[ $��5��$��5q� 
 Second# �  .������ $ TrashBin��$
 Text�$ OneWayToSource=�$ PropertyChanged=�.��� $��8�� �� $��75 ��� .+��� -   $ LoopCheckbox��$
��auto��$��0��$��
5, 0, 0, 0q�$��Center=�  CheckBox#��[   LoopCheckBox#���    LoopInterval# �  � $��1��$��
0, 0, 5, 0q�$��Center=�{��� $ 	IsChecked�$ LoopCheckbox�� �� �� �� �� �� �� .+��� -   $ LoopYear��#��[ $��0��$��5q�# � 	 .������ $ TrashBin��$
 Text�$ OneWayToSource=�$ PropertyChanged=�.���� -   $ 	LoopMonth��#��[ $��1��$��5q�# � 
 .������ $ TrashBin��$
 Text�$ OneWayToSource=�$ PropertyChanged=�.���� -   $ LoopDay��#��[ $��2��$��5q�# �  .������ $ TrashBin��$
 Text�$ OneWayToSource=�$ PropertyChanged=�.���� -   $ LoopHour��#��[ $��3��$��5q�# �  .������ $ TrashBin��$
 Text�$ OneWayToSource=�$ PropertyChanged=�.���� -   $ 
LoopMinute��#��[ $��4��$��5q�# �  .������ $ TrashBin��$
 Text�$ OneWayToSource=�$ PropertyChanged=�.���� -    $ 
LoopSecond��#��[ $��5��$��5q�# �  .������ $ TrashBin��$
 Text�$ OneWayToSource=�$ PropertyChanged=�.��� $��10��$��Bottom=� �� �� �� .+��� -!   $ NoticeCheckbox��$��0��$��Center=�#��[   TipCheckBox#���  �� -"   $ WindowCheckbox��$��1��$��Center=�#��[   WindowCheckBox#���  �� -#   $ SoundCheckbox��$��2��$��Center=�#��[   SoundCheckBox#���  � $��12��$
��0, 5q�$��Center=� �� $��20 ��� .+�� $��0�� �� $��75 ��� .+��� -$   $ RemindCheckbox��$
��auto��$��0��$��
5, 0, 0, 0q�$��Center=�#��[   RemindCheckBox#���    -%     Name$ RemindTimeGrid��$ 0��$��1��.@�  $ 	0.25, 0.5&�   .��� {��� $ 	IsChecked�$ RemindCheckbox�� �� $��75 ��� �� .+��� -&   $ RemindIntervalBtn��#��[ $��0��$
��8, 0q�$��12(�#��Z   IntervalBtn#���  � $��1��$��Bottom=�$��
0, 0, 5, 0q� �� �� �� .+��� -'   $ 
RemindYear��#��[ $��0��$��5q�# � 	 .������ $ TrashBin��$
 Text�$ OneWayToSource=�$ PropertyChanged=�.���� -(   $ RemindMonth��#��[ $��1��$��5q�# � 
 .������ $ TrashBin��$
 Text�$ OneWayToSource=�$ PropertyChanged=�.���� -)   $ 	RemindDay��#��[ $��2��$��5q�# �  .������ $ TrashBin��$
 Text�$ OneWayToSource=�$ PropertyChanged=�.��  $ 	0.25, 0.5&�   .��� {��� $ 	IsChecked�$ RemindCheckbox�� �� $��75 ��� �� .+��� -*   $ RemindWeekBtn��#��[ $��0��$
��8, 0q�$��12(�#��Z  
 DayBtn#���  � $��Center=�$��Center=� � Orientation$ 
Horizontal=�$��1��$��
0, 0, 5, 0q�.+��� -+   $ SundayCheckBox��-  'MaterialDesignThemes.Wpf.CheckBoxAssist    CheckBoxSize$  10Q�  SundayCheckBox#���  ���� $ MondayCheckBox��$ Style��� -,   $ MondayCheckBox��#��[ $  10Q�  MondayCheckBox#���  �� --   $ TuesdayCheckBox��$  10Q�   TuesdayCheckBox#���   ���� $ MondayCheckBox��$ Style��� -.   $ WednesdayCheckBox��$  10Q� ! WednesdayCheckBox#��� ! ���� $ MondayCheckBox��$ Style��� -/   $ ThursdayCheckBox��$  10Q� " ThursdayCheckBox#��� " ���� $ MondayCheckBox��$ Style��� -0   $ FridayCheckBox��$  10Q� # FridayCheckBox#��� # ���� $ MondayCheckBox��$ Style��� -1   $ SaturdayCheckBox��$  10Q� $ SaturdayCheckBox#��� $ ���� $ MondayCheckBox��$ Style�� $��1�� �� $��75 ��� �� .+�  -2   $ RemindTimePicker��$��30�� % 
RemindTime# � % $��Consolas)� . $��2��$��0, 0, 10, 5q�$��Bottom=�$��Stretch=�{��� $ RemindCheckbox��$ 	IsChecked�� $��14�� �� �� .+��� -3   $ NoBtn��$	��120��$��30��  & MaterialDesignOutlinedButton#��[& ! � ToolTip$! 取消��$��0��$��Stretch=�$��Stretch=� ' 	CancelBtn#��� ' �� -4   $ YesBtn��$	��120��$��30�� !( MaterialDesignFlatMidBgButton#��[( $! 确定��$��1��$��Stretch=�$��Stretch=�$ Depth2=� ) 
ComfirmBtn#��� ) '	  !MaterialDesignThemes.Wpf.Snackbar	  -5   " 	 Name$" Snackbar��$��15��# 	  MessageQueue# 4
  .MaterialDesignThemes.Wpf.MessageQueueExtension
  �� -6   $ TrashBin��{�.  $y�Hidden=�� -7   $ Messages��{�.  $y�Hidden=�.+��� -8   $ ��Name$$ EditSuccess�� * EditSuccess#��� * �� -9   $$ 	NullError�� + 	NullError#��� + �� -:   $$ NanError�� , NanError#��� , �� -;   $$ 
MinusError�� - 
MinusError#��� - �� -<   $$ TimespanError�� . TimespanError#��� . �� -=   $$ ZerotimeError�� / ZerotimeError#��� / �� ->   $$ StartDateError�� 0 StartDateError#��� 0 �� -?   $$ EndDateError�� 1 EndDateError#��� 1 �� -@   $$ StartEndTimeError�� 2 StartEndTimeError#��� 2 