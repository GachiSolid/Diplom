   M S B A M L   `   `   `  ����J  FCreditBureauWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:CreditBureauWPFCreditBureauWPF  5   	   !    CreditBureauWPF.AdminWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   )localclr-namespace:CreditBureauWPF  5   	     � Title$  Пользователи��5	   	    � SizeToContent$ WidthAndHeight=�6    � WindowStartupLocation$ CenterScreen=�6>      MaterialDesignBody#���   5
   	     MaterialDesignPaper#���  5      $��Medium"�5   	   $��14(�5   	     Lato#��[ 5   	   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   (  "MaterialDesignThemes.Wpf.ColorZone     Mode$ 
PrimaryMid=�6#   $��16q�65   .��5      ]� .+�5      ��  �� Orientation$ 
Horizontal=�6   +  %MaterialDesignThemes.Wpf.RippleAssist   
IsCentered . $	��350��6d   .+�5        $ Standard=�6/   $��8 4 8 4q�6?      CornerRadius$ 2��6Q    K� ZIndex$ 1��6b   $��16 0 0 0q�6s   +  %MaterialDesignThemes.Wpf.ShadowAssist	   ShadowDepth$	 Depth1=�6�   .��5      � 
 � ColumnDefinitions
 5      �� 5   "   $
��Auto �63   �� 5   "   $��* �63   �� 5   "   $
��Auto �63   .+�5      ��   MaterialDesignToolButton#���  6%   .��5    "   '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=null]]   Kind$ Magnify=�6:    J� Opacity$	 .56Q�6I   5!      �� 5"      -   5         ��Name$ 
searchText��5"   +  $��1��6g   $��8 0 0 0q�6w   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Поиск��6�   .  (MaterialDesignThemes.Wpf.TextFieldAssist   DecorationVisibility$ Hidden=�6�   $��0q�6�   $	��200��6   $��Center=�6  ��6&   �� *
FilterText+ �� UpdateSourceTrigger$ PropertyChanged=�6+  �� 5#      #���  6?   $��2��6r   ��6%   �� *Clear+.��5$   "     $ Close=�6:   $	 .56Q�6G   5%      5&      5'      �� 5(      -   5         ��Name$
 exit��5(   �    & "MaterialDesignToolForegroundButton#���  68   $��8 0 0 0q�6u   $ 0��6�   ��6   �� *LogOut+.��5)        $ Logout=�62   $��20��6@   $��20��6K   5*      5+      5,      5-      &   System.Windows.Controls.DataGrid  5.   
   -   5          Name$ userGrid��5.   1      AutoGenerateColumns .  $��1��6_      CanUserDeleteRows .     CanUserAddRows .  ��6   �� *Items+   Columns 5/      0	  *System.Windows.Controls.DataGridTextColumn	  50      ,
  &System.Windows.Controls.DataGridColumn 
  Width5  /System.Windows.Controls.DataGridLengthConverter$ 90 6%    
  
IsReadOnly . -   5        	Login�� 
  Header$ 
Логин��50   Q   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6`   �� *Login+	  51      $	 100 6%   $ Пароль��61    6A   �� *
Password+	  52      $
 Auto 6%   $! Имя сотрудника��62    6J   �� *Name+4  .System.Windows.Controls.DataGridCheckBoxColumn  53      $
 Auto 6)   $  Администратор��66    6M   �� *	IsAdmin+	  54      $
 Auto 6%   $3 -Последний вход в систему��62    .  6f   �� *
LastOnline+ �� StringFormat$ {0:dd.MM.yy HH:mm:ss}��56      �� 57   
   $��Center=�6   $��2��63   $ 
Horizontal=�6@   .+�58      �� -   5        $ createButton��58   >   $	�� 15q�60   $��Создать��6T   ��6   �� *Create+6T   �� 59      -   5        $ updateButton��59   =   $��15q�60   $��Обновить��6S   ��6   �� *Update+6S   �� 5:      -   5        $ deleteButton��5:   �   $��15q�6u   $��Удалить��6�   ��6   �� *Delete+��60   ��  �� ElementName$ userGrid�� �� Path$ SelectedItem�6�   5;      5<      5=      