   M S B A M L   `   `   `  ����?  ;DDLM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:DDLMDDLM  5          DDLM.InfoPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $localclr-namespace:DDLM     5        N� Title$  InfoPage��5	       � 	Resources 5         DDLM.WidthConverter   WidthConverter��%   &	          5   
   6   5      .��5      � -   5         �Name$ 	Container��5   	   .+�5   
   �� $��Hidden=�5      $��Stretch=�5      .��5      �� -   5         ��Name$ sp��5      $��20, 20q�5      ��5      ��  �� ElementName$ 	Container�� �� Path$ ActualWidth� �� 	Converter# [   �� ConverterParameter$ 40��.+�5      �� -   5         ��Name$ TitleTb��5        Headline4TextBlock#��[ 5         MaterialDesignToolForeground#���  5        Help#���  5      	 J� Opacity$	 0Q�5      
 J� RenderTransformOrigin$
 0.5, 0.5&�5      z�5      T� 5        T� Y$	 100Q�6-   5"      �� 5$      -   5        $ 
SubTitleTb��5%        Headline5TextBlock#��[ 5&       
 AddDdl#���  5(      $��0, 10, 0, 0q�5)      $	 0Q�5*      ��5'      �� $ TitleTb��$ 
Foreground�
 5+      �� $ TitleTb��$ RenderTransformOrigin�z�5,      T� 5-      $	 100Q�6-   5/      �� 50        Body1TextBlock#��[ 51        AddDdlContent#���  53      $	 0Q�54      ��52      �� $ TitleTb��$ 
Foreground�
 55      �� $ TitleTb��$ RenderTransformOrigin�z�56      T� 57      $	 100Q�6-   59      �� 5;      #��[ 5<        EditDdl#���  5>      $	 0Q�5@      ��5=      �� $ TitleTb��$ 
Foreground���5?      �� $ 
SubTitleTb��$ Margin�
 5A      �� $ TitleTb��$ RenderTransformOrigin�z�5B      T� 5C      $	 100Q�6-   5E      �� 5F      #��[ 5G       	 EditDdlContent#��� 	 5I      $	 0Q�5J      ��5H      �� $ TitleTb��$ 
Foreground�
 5K      �� $ TitleTb��$ RenderTransformOrigin�z�5L      T� 5M      $	 100Q�6-   5O      �� 5Q      #��[ 5R       
 OperateDdls#��� 
 5T      $	 0Q�5V      ��5S      �� $ TitleTb��$ 
Foreground���5U      �� $ 
SubTitleTb��$ Margin�
 5W      �� $ TitleTb��$ RenderTransformOrigin�z�5X      T� 5Y      $	 100Q�6-   5[      �� 5\      #��[ 5]        OperateDdlsContent#���  5_      $	 0Q�5`      ��5^      �� $ TitleTb��$ 
Foreground�
 5a      �� $ TitleTb��$ RenderTransformOrigin�z�5b      T� 5c      $	 100Q�6-   5e      �� 5g      #��[ 5h        FlowDdl#��[ 5j      $	 0Q�5l      ��5i      �� $ TitleTb��$ 
Foreground���5k      �� $ 
SubTitleTb��$ Margin�
 5m      �� $ TitleTb��$ RenderTransformOrigin�z�5n      T� 5o      $	 100Q�6-   5q      �� 5r      $
��Wrap=�5s      #��[ 5t        FlowDdlContent#��[ 5v      $	 0Q�5w      ��5u      �� $ TitleTb��$ 
Foreground�
 5x      �� $ TitleTb��$ RenderTransformOrigin�z�5y      T� 5z      $	 100Q�6-   5|      �� 5~      #��[ 5        SoftwareSetting#��[ 5�      $	 0Q�5�      ��5�      �� $ TitleTb��$ 
Foreground���5�      �� $ 
SubTitleTb��$ Margin�
 5�      �� $ TitleTb��$ RenderTransformOrigin�z�5�      T� 5�      $	 100Q�6-   5�      �� 5�      $
��Wrap=�5�      #��[ 5�        SoftwareSettingContent#��[ 5�      $	 0Q�5�      ��5�      �� $ TitleTb��$ 
Foreground�
 5�      �� $ TitleTb��$ RenderTransformOrigin�z�5�      T� 5�      $	 100Q�6-   5�      �� 5�      #��[ 5�      #���  5�       	 About#���  5�      $��0, 30, 0, 0q�5�      $	 0Q�5�      $
 0.5, 0.5&�5�      z�5�      T� 5�      $	 100Q�6-   5�      �� 5�       $  MaterialDesignHeadline5TextBlock#��[ 5�        SoftwareName#��[ 5�      $	 0Q�5�      ��5�      �� $ TitleTb��$ 
Foreground���5�      �� $ 
SubTitleTb��$ Margin�
 5�      �� $ TitleTb��$ RenderTransformOrigin�z�5�      T� 5�      $	 100Q�6-   5�      �� 5�      #��[ 5�        	Developer#��[ 5�      $	 0Q�5�      ��5�      �� $ TitleTb��$ 
Foreground�
 5�      �� $ TitleTb��$ RenderTransformOrigin�z�5�      T� 5�      $	 100Q�6-   5�      �� 5�      #��[ 5�        SoftwareBase#��[ 5�      $	 0Q�5�      ��5�      �� $ TitleTb��$ 
Foreground�
 5�      �� $ TitleTb��$ RenderTransformOrigin�z�5�      T� 5�      $	 100Q�6-   5�      5�      5�      5�      5�      