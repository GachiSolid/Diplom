   M S B A M L   `   `   `  ����J  FCreditBureauWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:CreditBureauWPFCreditBureauWPF  5   	   "    CreditBureauWPF.Registration   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   )localclr-namespace:CreditBureauWPF  5   	   -   5          � Title$  Регистрация��5	   	   $	��200��6    � SizeToContent$ Height=�6)    � WindowStartupLocation$ CenterScreen=�6@      MaterialDesignBody#���   5
      $��Regular"�5      $��16(�5      &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignPaper#���  5        Lato#���  5       � 
ResizeMode$ NoResize=�6*   .��5      �� .+�5   
   �� #��[ 6   $��15q�67    �� TextAlignment$ Center=�6C   $��WrapWithOverflow=�6Z   $��20(�6z   Регистрация6�   �� 5   
   �� 5   
   $��0,2,0,10q�6   �� 5   
   $��5,0,5,15q�6)   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Роль��6;   $��40��6a    & "MaterialDesignFloatingHintComboBox#��[ 6m    �� Text 6   �� *Role+.@�5      �� .��6   Администратор5      �� 5      .��6   Пользователь5      5      �� 5   
   -   5        $��5,0,5,15q�5   (   $ Имя��6:   ��6   �� *Name+6_   �� 5   
   -   5        	 ��Name$	 RegLogin��5   ;   $��5,0,5,15q�6)   $ 
Логин��6M   ��6   �� *Login+6M   G� 5   
   -   5        
 G�Name$

 Pass��5      $��5,0,5,15q�6$   $ Пароль��66   G� 5    
   -   5        $
 PassConfirm��5       $��5,0,5,0q�6,   $% Повторите пароль��6=   �� 5!   
   -   5         ��Name$ 	warnlabel��5!      $��13(�6<   
���  ��$��Center=�6\   ��6#   �� *Warn+��6y   Z� �� 5"   
   $��15q�6   $��85��6   $��Center=�6)   $��Ввод��6F   ��6U   �� *Create+�� 5#   
   $��15q�6   $��85��6    �� IsCancel . $��Center=�68   $��Отмена��6U   5$      5%      