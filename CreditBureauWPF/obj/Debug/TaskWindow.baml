   M S B A M L   `   `   `  ����J  FCreditBureauWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:CreditBureauWPFCreditBureauWPF  5   	        CreditBureauWPF.TaskWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   )localclr-namespace:CreditBureauWPF  5   	     � Title$  Заемщики��5	   	    � SizeToContent$ WidthAndHeight=�6    � WindowStartupLocation$ CenterScreen=�6:      MaterialDesignBody#���   5
   	     MaterialDesignPaper#���  5      $��Medium"�5   	   $��14(�5   	     Lato#��[ 5   	   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   (  "MaterialDesignThemes.Wpf.ColorZone     Mode$ 
PrimaryMid=�6#   $��16q�65   .��5      ]� .+�5      ��  �� Orientation$ 
Horizontal=�6   +  %MaterialDesignThemes.Wpf.RippleAssist   
IsCentered . $	��385��6d   .+�5        $ Standard=�6/   $��8 4 8 4q�6?      CornerRadius$ 2��6Q    K� ZIndex$ 1��6b   $��16 0 0 0q�6s   +  %MaterialDesignThemes.Wpf.ShadowAssist	   ShadowDepth$	 Depth1=�6�   .��5      � 
 � ColumnDefinitions
 5      �� 5   "   $
��Auto �63   �� 5   "   $��* �63   �� 5   "   $
��Auto �63   .+�5      ��   MaterialDesignToolButton#���  6%   .��5    "   '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=null]]   Kind$ Magnify=�6:    J� Opacity$	 .56Q�6I   5!      �� 5"      -   5         ��Name$ 
searchText��5"   +  $��1��6g   $��8 0 0 0q�6w   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Поиск��6�   .  (MaterialDesignThemes.Wpf.TextFieldAssist   DecorationVisibility$ Hidden=�6�   $��0q�6�   $	��200��6   $��Center=�6  ��6&   �� *
FilterText+ �� UpdateSourceTrigger$ PropertyChanged=�6+  �� 5#      #���  6?   $��2��6r   ��6%   �� *Clear+.��5$   "     $ Close=�6:   $	 .56Q�6G   5%      5&      5'      �� 5(      -   5         ��Name$ 
openButton��5(   �    & "MaterialDesignToolForegroundButton#���  6}   $��8 0 0 0q�6�   $ 0��6�   ��6   �� *Open+��66   ��  �� ElementName$ 
peopleGrid�� �� Path$ SelectedItem�.��5)        $��20��62   $��20��6=   $ BookOpen=�6I   5*      �� 5+      -   5        $
 exit��5+   �   #���  68   $��8 0 0 0q�6u   $ 0��6�   ��6   �� *LogOut+.��5,        $��20��62   $��20��6=   $ Logout=�6I   5-      5.      5/      50      &   System.Windows.Controls.DataGrid  51   
   -   5          Name$ 
peopleGrid��51   >   $��1��61      AutoGenerateColumns .     CanUserDeleteRows .     CanUserAddRows .  ��6   �� *Items+   Columns 52      0	  *System.Windows.Controls.DataGridTextColumn	  53      ,
  &System.Windows.Controls.DataGridColumn 
  Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6%   -   5        ID�� 
  Header$ Код субъекта��53   >    
  
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6f   �� *Id+	  54      $
 Auto 6%   $ Фамилия��62    6C   �� *
Familiya+	  55      $
 Auto 6%   $ Имя��62    6?   �� *Name+	  56      $
 Auto 6%   $ Отчество��62    6D   �� *	Otchestvo+	  57      $
 Auto 6%   $ 
СНИЛС��62    6A   �� *Snils+	  58      $
 Auto 6%   $ Пол��62    .  6Q   �� *Gender+	  59      $
 Auto 6%   $# Дата обновления��62    .  6]   �� *Date+ �� StringFormat$ {0:dd.MM.yy}��	  5:      $
 Auto 6%   $ Сотрудник��62    .  6W   �� *User+$ PropertyChanged=�5<      �� 5=   
   $��Center=�6   $��2��63   $ 
Horizontal=�6@   $��2��6Y   .+�5>      �� -   5        $ createButton��5>   !   $��15q�6   $��Создать��67   ��6I   �� *Create+�� 5?      -   5        $ updateButton��5?   !   $��15q�6   $��Обновить��67   ��6J   �� *Update+�� 5@      -   5        $ deleteButton��5@   !   $��15q�6   $��Удалить��67   ��6J   �� *Delete+��6e   �� $ 
peopleGrid��$ SelectedItem�5A      5B      5C      