   M S B A M L   `   `   `  ���� O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  ? ;DDLM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:DDLMDDLM \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   DdlPageBtnText  SettingPageBtnText  InfoPageBtnText  AddBtnToolTip  ReloadBtnToolTip  
SettingDdl  FlowWindowDdl  	DeleteDdl  LangText 	 AutoStartText 
 	ThemeText  	LightText  DarkText  PrimaryColorText  SecondaryColorText  	SoundText  AlarmPathText  AlarmVolumeText  Help 
 AddDdl  AddDdlContent  EditDdl  EditDdlContent  OperateDdls  OperateDdlsContent  FlowDdl  FlowDdlContent  SoftwareSetting  SoftwareSettingContent 	 About  SoftwareName  	Developer   SoftwareBase ! Year 	" Month # Day $ Hour 
% Minute 
& Second ' DdlName ( Priority ) 	StartTime * EndTime 
+ EndBtn , DurationBtn - LoopCheckBox . LoopInterval / TipCheckBox 0 WindowCheckBox 1 SoundCheckBox 2 RemindCheckBox 3 
RemindDate 4 
RemindTime 5 IntervalBtn 
6 DayBtn 7 SundayCheckBox 8 MondayCheckBox 9 TuesdayCheckBox : WednesdayCheckBox ; ThursdayCheckBox < FridayCheckBox = SaturdayCheckBox > 	CancelBtn ? 
ComfirmBtn @ 
AddSuccess A EditSuccess B DeleteSuccess C 	NullError D NanError E 
MinusError F TimespanError G ZerotimeError H StartDateError I EndDateError J StartEndTimeError�� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     .sys&clr-namespace:System;assembly=mscorlib  localclr-namespace:DDLM  %�  &	        &	      &	       &	 .     &	 H     &	 Y     &	 j     &	 x     &	 �     &		 �     &	
 �     &	 �     &	 �     &	 �     &	 �     &	     &	     &	 *    &	 :    &	 H    &	 `    &	 �    &	 �    &	 �    &	 �    &	 .    &	 G    &	 �    &	 �    &	 P    &	 _    &	 y    &	  �    &	! �    &	" �    &	# �    &	$ �    &	% 	    &	& 	    &	' &	    &	( =	    &	) O	    &	* c	    &	+ u	    &	, �	    &	- �	    &	. �	    &	/ �	    &	0 �	    &	1 �	    &	2 �	    &	3 �	    &	4 
    &	5 "
    &	6 0
    &	7 =
    &	8 K
    &	9 Y
    &	: g
    &	; u
    &	< �
    &	= �
    &	> �
    &	? �
    &	@ �
    &	A �
    &	B �
    &	C     &	D     &	E 9    &	F S    &	G s    &	H �    &	I �    &	J �    ��DDLs����Settings����Info����add new deadline����Refresh����Setting����Flow����
Delete����Language����Run on system start����	Theme����	Light����Dark����Primary����	Secondary����	Sound����
Alarm path����
Volume����Help����Add a deadline����lhOn the left side of button panel, click DDLs Button. Click the Add Button, and start edit your deadline.����Edit a deadline������On the edit window, set the name, importance, time, loop, notification method, and reminder of the deadline.
Click the button to the left of the end time to select the specific end time or the duration of deadline.
Check the loop checkbox to enable the Loop function. After the deadline ends, it will start again and the duration will be the cycle interval.
Check Notification checkboxes to select the notification modes at the end of Deadline. There are three kinds of notice available: tip, pop-up window and sound.
Check the remind checkbox to enable the Remind function. Click the button at the bottom of the checkbox to select remind interval or remind days of a week.����Operate deadlines������Displays all the slots on the DDLS page, showing their names, times, importance, remaining times, and progress bars. When the Deadline does not end, the colro of progress bar is the dominant color; When finished, it becomes the secondary color. Clicking Deadline displays three buttons, which are Edit button, flow Window button, and Delete button from left to right.����Flow a deadline������Click the flow window button, and a deadline flow window appears in the upper left corner of the main display, showing its name, the remaining time and the progress. Drag the flow window to move it; Right-click to enter its setting window; Scroll to adjust its size; Double left-click to close the flow window.����Software Setting������Click Settings button on the left side of the main window to go to the Settings page of the software. You can set boot start, theme color and notification sound.����	About����Deadlines Matter����Handsone Huang����73Based on SQLite-NET AND MaterialDesignInXAMLToolkit����Year����	Month����Day����Hour����
Minute����
Second����Deadline name����Priority����
Start time����End Time����End����Span����Loop����Loop interval����Tip����Pop-up window����	Sound����
Remind����Remind date����Remind time����Span����Day����Sun.����Mon.����Tue.����Wed.����Thu.����Fri.����Sat.����
Cancel����Confirm����Add Success.����Edit Success.����Delete Success.���� can't be null.����is not a number.���� can't be minus.���� avaliable time span: ���� time can't be zero. ����Wrong start date.����Wrong end date.����-)Start time must be earlier than end time.��