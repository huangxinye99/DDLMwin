   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5      ? ;DDLM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:DDLMDDLM 5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   languageName  DdlPageBtnText  SettingPageBtnText  InfoPageBtnText  AddBtnToolTip  ReloadBtnToolTip  
SettingDdl  FlowWindowDdl  	DeleteDdl 	 LangText 
 AutoStartText  	ThemeText  	LightText  DarkText  PrimaryColorText  SecondaryColorText  	SoundText  AlarmPathText  AlarmVolumeText  Help 
 AddDdl  AddDdlContent  EditDdl  EditDdlContent  OperateDdls  OperateDdlsContent  FlowDdl  FlowDdlContent  SoftwareSetting  SoftwareSettingContent 	 About  SoftwareName   	Developer ! SoftwareBase " Time # Year 	$ Month % Day & Hour 
' Minute 
( Second ) DdlName * Priority + 	StartTime , EndTime 
- EndBtn . DurationBtn / LoopCheckBox 0 LoopInterval 1 TipCheckBox 2 WindowCheckBox 3 SoundCheckBox 4 RemindCheckBox 5 
RemindDate 6 
RemindTime 7 IntervalBtn 
8 DayBtn 9 MondayCheckBox : TuesdayCheckBox ; WednesdayCheckBox < ThursdayCheckBox = FridayCheckBox > SaturdayCheckBox ? SundayCheckBox @ 	CancelBtn A 
ComfirmBtn B 
AddSuccess C EditSuccess D DeleteSuccess E 	NullError F NanError G 
MinusError H TimespanError I ZerotimeError J StartDateError K EndDateError L StartEndTimeError�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      .sys&clr-namespace:System;assembly=mscorlib  5      localclr-namespace:DDLM  5      %�  &	        &	 $     &	 @     &	 ^     &	 |     &	 �     &	 �     &	 �     &	 �     &		     &	
 ;    &	 _    &	 }    &	 �    &	 �    &	 �    &	 �    &	     &	 7    &	 U    &	 y    &	 �    &	     &	 :    &	     &	 :    &	 g    &	 �    &	 �    &	 �    &	 G	    &	 k	    &	  �	    &	! �	    &	" 
    &	# !
    &	$ <
    &	% W
    &	& r
    &	' �
    &	( �
    &	) �
    &	* �
    &	+     &	, +    &	- O    &	. m    &	/ �    &	0 �    &	1 �    &	2 �    &	3 	    &	4 '    &	5 E    &	6 i    &	7 �    &	8 �    &	9 �    &	: �    &	; �    &	<     &	= 5    &	> P    &	? k    &	@ �    &	A �    &	B �    &	C �    &	D 
    &	E .    &	F R    &	G |    &	H �    &	I �    &	J �    &	K '    &	L Q    ��5      简体中文��6,   ��5	      DDLs��6.   ��5
      
设置��60   ��5      
关于��6-   ��5      添加新Deadline��64   ��5      
刷新��6.   ��5      
设置��6(   ��5      
浮窗��6+   ��5      
删除��6'   ��5      
语言��6&   ��5      开机启动��6-   ��5      
主题��6'   ��5      
亮色��6'   ��5      
暗色��6&   ��5      
主色��6.   ��5      
副色��60   ��5      
声音��6'   ��5      闹铃路径��6-   ��5       
音量��6-   ��5$      使用说明��6$   ��5%      添加Deadline��6,   ��5&      a]在窗口左侧选择DDLs页面，点击右下角的添加按钮，进行Deadline的编辑。��6P   ��5'      编辑Deadline��6-   ��5(      ��在编辑页面，设置Deadline的名称、星级、开始时间、结束时间、循环间隔、通知方式和提醒时间。
勾选农历选择框来设置开始时间和结束时间为农历。此时双击月份输入框，可以切换到闰月。
点击结束时间左侧的按钮来选择输入具体的结束时间或是Deadline的持续时间。
勾选循环选择框来开启循环功能，Deadline结束后重新开始，持续时间为循环间隔。
勾选通知方式来选择Deadline结束时的通知方式。现有提醒、弹窗和声音三种通知方式。
勾选提醒选择框来开启提醒功能。点击选择框下方的按钮来选择隔一段时间或星期进行提醒。��5-   ,   ��5.      操作Deadline��61   ��5/      ��在DDLs页面显示所有的Deadlines，显示其名字、起止时间、星级、剩余时间和进度条。
Deadline未结束时，进度条为主色；结束后，进度条为副色。
单击Deadline显示三个按钮，从左到右依次为编辑、浮窗和删除。��51   $   ��52      浮窗Deadline��6-   ��53      ��点击浮窗按钮后，一个Deadline浮窗会出现在主显示器左上角，显示Deadline的名字、剩余时间和进度。
拖动浮窗设置其位置，右击进入其设置页面，滚轮调整其大小，左键双击关闭浮窗。��54   (   ��55      软件设置��6/   ��56      nj在窗口左侧选择设置进入设置页面。
可以设置开机启动、主题颜色和通知音效。��57      ��59      关于软件��6%   ��5:      Deadlines Matter��68   ��5;      开发：黄鑫烨��6+   ��5<      2.基于SQLite-NET和MaterialDesignInXAMLToolkit��6P   ��5@      
时间��6"   ��5A      年��6!   ��5B      月��6"   ��5C      日��6    ��5D      时��6!   ��5E      分��6#   ��5F      秒��6#   ��5H      Deadline名称��6-   ��5I      
星级��6&   ��5K      开始时间��6)   ��5L      结束时间��6'   ��5M      
时间��6$   ��5N      
间隔��6)   ��5P      
循环��6*   ��5Q      循环间隔��6,   ��5S      
通知��6)   ��5T      
弹窗��6,   ��5U      
音效��6+   ��5W      
提醒��6,   ��5X      提醒日期��6*   ��5Y      提醒时间��6*   ��5Z      
间隔��6)   ��5[      
星期��6$   ��5\      一��6+   ��5]      二��6,   ��5^      三��6.   ��5_      四��6-   ��5`      五��6+   ��5a      六��6-   ��5b      日��6+   ��5d      
取消��6'   ��5e      
确认��6(   ��5h      添加成功��6*   ��5i      编辑成功��6+   ��5j      删除成功��6-   ��5l      不能为空��6)   ��5m      只能输入数字��6*   ��5n      不能为负数��6+   ��5o      允许的时间范围：��61   ��5p      时间不能为零��6/   ��5q      开始日期错误��60   ��5r      结束日期错误��6.   ��5s      ($开始时间不能晚于结束时间��69   5u      