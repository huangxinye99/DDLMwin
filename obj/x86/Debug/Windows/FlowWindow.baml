   M S B A M L   `   `   `  ����?  ;DDLM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:DDLMDDLM  5   	       DDLM.FlowWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   localclr-namespace:DDLM  5   	   -   5          �Name$  DdlFlowWindow��5	   	    � SizeToContent$ WidthAndHeight=�5
   	    � Title$ DdlFlowWindow��5   	    � AllowsTransparency . 
������  � WindowStyle$
 None=�5   	    � WindowStartupLocation$ Manual=�5   	    � 
ResizeMode$ NoResize=�5   	    � Topmost .  � ShowInTaskbar .  .��5      � -   5        	 �Name$	 	Container��5   	   .+�5   
   �� -   5        
 ��Name$
 Bg��5      $��Stretch=�5      $��Stretch=�5      
������� J� Opacity$	 0.5Q�5      z�5       �� 5!       �� ScaleX$ 0Q�6!   5#      �� 5%   
   -   5        $
 ProgressRect��5&      $��Stretch=�5'      $
��Left=�5(         PrimaryHueDarkBrush#���   5)      $	 0.5Q�5*      z�5+      �� 5,      $ 0Q�6!   5.      �� 50   
    �� Orientation$ 
Horizontal=�51      .+�52      �� -   5         ��Name$ DdlNameTextBlock��53      $��Center=�54      $
��Left=�55      56      �� 58      -   5        $ NullTextBlock��59        BaseTextBlock#��[ 5:      ��5;      ��  �� Path$ FontSize� �� ElementName$ DdlNameTextBlock���� 5=      -   5        $ LeftTimeTextBlock��5>      #��[ 5?      $��Center=�5@      $��Right=�5A      5B      5C      5D      5E      