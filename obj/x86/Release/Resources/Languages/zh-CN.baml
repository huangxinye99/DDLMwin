   M S B A M L   `   `   `  ���� O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  ? ;DDLM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:DDLMDDLM \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   languageName  DdlPageBtnText  SettingPageBtnText  InfoPageBtnText  AddBtnToolTip  ReloadBtnToolTip  
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
MinusError H TimespanError I ZerotimeError J StartDateError K EndDateError L StartEndTimeError�� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     .sys&clr-namespace:System;assembly=mscorlib  localclr-namespace:DDLM  %I  &	        &	      &	 $     &	 4     &	 D     &	 _     &	 o     &	      &	 �     &		 �     &	
 �     &	 �     &	 �     &	 �     &	 �     &	     &	     &	 %    &	 ;    &	 K    &	 a    &	 y    &	 �    &	 �    &	 �    &	 �    &	 �    &	     &	 	    &	     &	 �    &	 �    &	  �    &	! �    &	"     &	# '    &	$ 4    &	% A    &	& N    &	' [    &	( h    &	) u    &	* �    &	+ �    &	, �    &	- �    &	. �    &	/ �    &	0 �    &	1 	    &	2 	    &	3 /	    &	4 ?	    &	5 O	    &	6 e	    &	7 {	    &	8 �	    &	9 �	    &	: �	    &	; �	    &	< �	    &	= �	    &	> �	    &	? �	    &	@ �	    &	A 
    &	B 
    &	C ,
    &	D B
    &	E X
    &	F n
    &	G �
    &	H �
    &	I �
    &	J �
    &	K �
    &	L     ��简体中文����DDLs����
设置����
关于����添加新Deadline����
刷新����
设置����
浮窗����
删除����
语言����开机启动����
主题����
亮色����
暗色����
主色����
副色����
声音����闹铃路径����
音量����使用说明����添加Deadline����a]在窗口左侧选择DDLs页面，点击右下角的添加按钮，进行Deadline的编辑。����编辑Deadline������在编辑页面，设置Deadline的名称、星级、开始时间、结束时间、循环间隔、通知方式和提醒时间。
勾选农历选择框来设置开始时间和结束时间为农历。此时双击月份输入框，可以切换到闰月。
点击结束时间左侧的按钮来选择输入具体的结束时间或是Deadline的持续时间。
勾选循环选择框来开启循环功能，Deadline结束后重新开始，持续时间为循环间隔。
勾选通知方式来选择Deadline结束时的通知方式。现有提醒、弹窗和声音三种通知方式。
勾选提醒选择框来开启提醒功能。点击选择框下方的按钮来选择隔一段时间或星期进行提醒。����操作Deadline������在DDLs页面显示所有的Deadlines，显示其名字、起止时间、星级、剩余时间和进度条。
Deadline未结束时，进度条为主色；结束后，进度条为副色。
单击Deadline显示三个按钮，从左到右依次为编辑、浮窗和删除。����浮窗Deadline������点击浮窗按钮后，一个Deadline浮窗会出现在主显示器左上角，显示Deadline的名字、剩余时间和进度。
拖动浮窗设置其位置，右击进入其设置页面，滚轮调整其大小，左键双击关闭浮窗。����软件设置����nj在窗口左侧选择设置进入设置页面。
可以设置开机启动、主题颜色和通知音效。����关于软件����Deadlines Matter����开发：黄鑫烨����2.基于SQLite-NET和MaterialDesignInXAMLToolkit����
时间����年����月����日����时����分����秒����Deadline名称����
星级����开始时间����结束时间����
时间����
间隔����
循环����循环间隔����
通知����
弹窗����
音效����
提醒����提醒日期����提醒时间����
间隔����
星期����一����二����三����四����五����六����日����
取消����
确认����添加成功����编辑成功����删除成功����不能为空����只能输入数字����不能为负数����允许的时间范围：����时间不能为零����开始日期错误����结束日期错误����($开始时间不能晚于结束时间��