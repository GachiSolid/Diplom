   M S B A M L   `   `   `  ����J  FCreditBureauWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:CreditBureauWPFCreditBureauWPF  5   	   "    CreditBureauWPF.CreateWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   )localclr-namespace:CreditBureauWPF  5   	   -   5          � Title$  Добавление��5	   	    � SizeToContent$ WidthAndHeight=�6    � WindowStartupLocation$ CenterScreen=�6;      MaterialDesignBody#���   5
      $��Regular"�5      $��16(�5      &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignPaper#���  5        Lato#���  5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5!   
   ��  �� Orientation$ 
Horizontal=�6   $��10q�6.   $��0��6:   $��Center=�6G   $��2��6d   .+�5"      �� -   5         ��Name$
 have��5"   �   $7��1Человек есть в базе данных?��6     MaterialDesignCheckBox#��[ 6o   5#      �� 5$      -   5        	 ��Name$	 exist��5$   �   $y�	Collapsed=�6   
 �� SelectedValuePath$
 Id��6�    �� DisplayMemberPath$ Id��6�   $��10q�6�   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Код субъекта��6�    �� 
IsEditable .  �� Text 6Y   �� *IdText+��6q   �� *IdSub+��5%      �� 5&      .R�5'      $� 5(      5*      5+      �� 5,   
   -   5         ��Name$ Familiya��5,   n   $��0��6Q   $��1��6a   $��15q�6�   $ Фамилия��6�    % !MaterialDesignFloatingHintTextBox#��[ 6�   ��6   �� *
Familiya+ �� UpdateSourceTrigger$ PropertyChanged=�6  �� 5-   
   -   5        $
 Name��5-   �   $��0��6d   $��2��6t   $��15q�6�   $ Имя��6�   #��[ 6�   ��6   �� *Name+$ PropertyChanged=�6�   �� 5.   
   -   5        $ 	Otchestvo��5.   �   $��0��6i   $��3��6y   $��15q�6�   $ Отчество��6�   #��[ 6�   ��6   �� *	Otchestvo+$ PropertyChanged=�6
  �� 5/   
   -   5        $	 Gender��5/   P   $��0��6`   $��50��6p   $��40��6{   $
��Left=�6�   $��4��6�   $��15q�6�   $ Пол��6�    & "MaterialDesignFloatingHintComboBox#��[ 6�    6   �� *Gender+$ PropertyChanged=�.@�50      �� .��6   М52      �� 53      .��6   Ж55      56      �� 57   
   -   5        $ Passport��57   �    �� 	MaxLength$ 11��6r   $��0��6�   $��5��6�   $��15q�6�   $ Номер СНИЛС��6�   #��[ 6   ��6   �� *Snils+$ PropertyChanged=� �� StringFormat$ {0: ###-###-###-##}��6;  �� 58   
   -	   5        $
 Bank��58   E   $��1��6(   $��1��68   $��15q�6S   $ Банк��6_   #��[ 6�   ��6   �� *Bank+6�   �� 59   
   -
   5        $	 Sum��59   �   $��1��6c   $��2��6s   $��15q�6�   $ Сумма кредита��6�   #��[ 6�   ��6   �� *Sum+$ PropertyChanged=�6  �� 5:   
   $��Bottom=�6   $��15q�60   $ 
Horizontal=�6<   $��1��6U   $��3��6e   .+�5;      �� -   5        $ Procent��5;   o   $��Bottom=�6F   $ 2��6a   $ Процент��6�   ��6   �� *	Percent+6�   �� 5<      $��5,0,0,0q�6   $��Center=�6%   $��Center=�6B   $��%��6]   5=      (  "System.Windows.Controls.DatePicker  5>   
   -   5          Name$ 
datePicker��5>   3   $��15q�6G   $��1��6S   $��4��6c   $
��Left=�6p   $	��120��6�   $ Дата выдачи��6�    ( $MaterialDesignFloatingHintDatePicker#��[ 6�      SelectedDate 6   �� *Date+6�   �� 5?   
   $��15q�6   $ 
Horizontal=�6!   $��1��6:   $��5��6J   .+�5@      �� -   5        $ 
MounthText��5@   [   $��Bottom=�62   $ 2��6M   $ Срок��6o   ��6   �� *
MounthText+6�   �� 5A      -   5        $	 	MounthBox��5A   2   {�.  $��50��6W   $��30��6b   $��10,0,0,0q�6n   $��Bottom=�6�   $��Bottom=�6�     MaterialDesignComboBox#��[ 6�    6   �� *	MounthBox+.@�5B      �� .��6   	Мес.6%   �� 5C      .��6   Лет6$   5D      5E      �� 5F   
   -   5         ��Name$ 
createWarn��5F   )   $��6��6=   $��15(�6J   
���  ��$��Center=�6z   $��2��6�   ��6   �� *Warn+��6X   Z� 6�   �� 5G   
   $ 
Horizontal=�6   $��Center=�6/   $��7��6L   $��2��6Y   .+�5H      �� -   5         ��Name$ createOk��5H   <   $��15q�60   $��Ввод��6N   ��6   �� *Create+6N   �� 5I      -   5        $ createCancel��5I   !   $��15q�6    �� IsCancel . $��Отмена��6G   5J      5K      5L      