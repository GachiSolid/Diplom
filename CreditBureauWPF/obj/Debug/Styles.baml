   M S B A M L   `   `   `  ����J  FCreditBureauWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:CreditBureauWPFCreditBureauWPF  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   Lato  �� 
TargetType �� Property �� Value  ScrollThumbs �� 
TargetType �Name ��Name �� CornerRadius �� Triggers P� Property	 P� Value
 �� 
TargetName � RowDefinitions ]�Name ]� Thumb n�Name ]� IncreaseRepeatButton ��Name J� Opacity ]� DecreaseRepeatButton P� 
SourceName  ButtonSelectBrush  	DarkBrush �� Angle�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      'localclr-namespace:CreditBureauWPF  5      %�	  &	        '�� B     &	 �     '�� �    *�5      .*pack://application;,,,/Fonts/#Lato Regular)�6J   �� 5      "  ��6   .�5   
   ��  � ��$ 15q�6#   5	      �� 5      "  n�6!   .�5   
   ��  � �� 5      �� 5      " n�6"   .R�5      � $
 Grid��6   .+�5      �� $��Stretch=�6$   $��Stretch=�6B   $
��Auto��6^   $
��Auto��6k   
������ 6y   �� 5      $ 
Rectangle1��6!   $ 10��65   $��Stretch=�6G   $��Stretch=�6e   $
��Auto��6�   $
��Auto��6�   #��z��6�   5       5      P� 5       �@�Tag$	 
Horizontal��61   . �5      �� $
 
Rectangle1��6%    � ��$
 Auto��6N   �� 5      $
 
Rectangle1��6%    � ��$ 7��6O   5      5      5      5      �� 5      "  ��6'   .�5   
   ��  �@��IsFlicksEnabled .  63   �� 5    
    � ��
 �����6'   �� 5!   
    � ��
 �����6'   �� 5"   
    � ��$ 10��6"   �� 5#   
    � �� 5$      �� 5%      " ��6"   .R�5&      � $ GridRoot��6   $��19��6-   #��z��68    5'      �� 5(      $��0.00001* �6,   .+�5+      ]� $ 
PART_Track��6    $��0��64   ��. |�.   5,      n� 5-   "   $ Thumb��6(   #��z��67   #���  6a    5/      �� 50   "   $ PageUp��6/   $��ScrollBar.PageDownCommand��6?   $ 0Q�6c   |�.  6o    52      �� 53   "   $ PageDown��6/   $��ScrollBar.PageUpCommand��6A   $ 0Q�6c   |�.  6o   55      56       58      P� 59      $ Thumb��6"    �@J�IsMouseOver	 . . �5:      �� # �  6%   $
 Thumb��6Q    � ��6d   5;      P� 5<      $ Thumb��6"    �@n�
IsDragging	 . . �5=      �� # �  6%   $
 Thumb��6I    � ��6\   5>      P� 5@       � {�	 .  . �5A      �� $
 Thumb��6%    � y�$ 	Collapsed=�6N   5B      P� 5C       �@��Orientation$	 
Horizontal=�69   . �5D      �� $
 GridRoot��6%    �@�LayoutTransform 5E   "   �� 5F   &   $	 -90Q�66   5H      �� 5I      $
 
PART_Track��6%    �@�LayoutTransform 5J   "   �� 5K   &   $	 -90Q�66   5M      �� 5N       � ��$
 Auto��66   �� 5O       � ��$ 12��67   �� 5P      $
 Thumb��6%    �@�Tag$ 
Horizontal��6G   �� 5Q      $
 PageDown��6%    � ��$ ScrollBar.PageLeftCommand��6N   �� 5R      $
 PageUp��6%    � ��$  ScrollBar.PageRightCommand��6L   5S      5U      5W      5X      5Z      