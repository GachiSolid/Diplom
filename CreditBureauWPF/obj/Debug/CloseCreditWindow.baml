   M S B A M L   `   `   `  ����J  FCreditBureauWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:CreditBureauWPFCreditBureauWPF  5   	   '    !CreditBureauWPF.CloseCreditWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   )localclr-namespace:CreditBureauWPF  5   	   -   5          � Title$  Погашение��5	   	    � SizeToContent$ WidthAndHeight=�6      MaterialDesignBody#���   5
   	   ���#2e3137$��Medium"�5   	   $��14(�5   	     Lato#��[ 5   	    � WindowStartupLocation$ CenterScreen=�6,   .��5      ��   MaterialDesignPaper#���  6    �� CornerRadius$ 15��6@   $��15q�6R   ._�5   
   �  � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    .+�5      �� $��10q�6   $��0��6$   $'��!Погашение кредита��61    �� TextAlignment$ Center=�6J   $��WrapWithOverflow=�6a   $��20(�6�   �� 5       �� Orientation$ 
Horizontal=�6   $��1��62   .+�5      �� -   5         ��Name$ zader��5      $��10q�6*   $
��Left=�66     MaterialDesignCheckBox#��[ 6Q   $��87��6�   .��6�   Задержки6�   �� 5      -   5         ��Name$ 	zaderlist��5   B   $��10q�66   $y�	Collapsed=�6U   )  #MaterialDesignThemes.Wpf.HintAssist	   Hint$+	 %Количество задержек��6l   $
��Left=�6�   
 �� Text
 6   �� *	ZaderList+.@�5      �� .��6#   1-25      �� 5       .��6#   3-55"      �� 5#      .��6#   >55%      5&      5'      �� 5(      -   5        $ sposob��5(   <   $��2��6/   $��10q�6L   $4	 .Способ погашения кредита��6X    & "MaterialDesignFloatingHintComboBox#��[ 6�   
 6   �� *Sposob+.@�5)      �� .��6#   +)Своевременная выплата5+      �� 5,      .��6#   64Досрочное погашение кредита5.      �� 5/      .��6#   1/Судебное разбирательство51      52      �� 53      $ 
Horizontal=�6   $��3��66   .+�54      �� -   5        $
 info��54      $��10q�6)   $
��Left=�65   #��[ 6P   .��6�   Доп. информация6�   �� 55      -   5         ��Name$ infoBox��55   3   " �� VerticalScrollBarVisibility$
 Auto=�6D   $y�	Collapsed=�6g   $��10q�6~   $	��100��6�   $	��250��6�    * &MaterialDesignOutlinedTextFieldTextBox#��[ 6�    �� AcceptsReturn .  �� TextWrapping$
 Wrap=�6�   $7	 1Дополнительная информация��6  ��6   �� *	InfoBox+6  56      �� 57      $��Center=�6   $��4��67   $ 
Horizontal=�6D   .+�58      �� -   5         ��Name$ okButton��58   A   $��15q�65   $
��Ок��6S   ��6   �� *	OkClick+6S   �� 59      $��15q�6    �� IsCancel . $��Отмена��65   5:      5;      5<      5=      