   M S B A M L   `   `   `  ����J  FCreditBureauWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:CreditBureauWPFCreditBureauWPF  5   	        CreditBureauWPF.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   )localclr-namespace:CreditBureauWPF  5   	     � Title$  
Логин��5	   	    � WindowStartupLocation$ CenterScreen=�6      MaterialDesignBody#���   5
      $��Regular"�5      $��16(�5      &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5         TextRenderingMode$
 Auto=�5        Lato#���  5       � 
ResizeMode$ CanMinimize=�6*   $	��450��6C   $	��350��6P    � Triggers 5      :� 5   
    :� RoutedEvent$ Loaded��6   [�5   
   �� 5      .��5      ��  g� DesiredFrameRate$ 60X�6!   .��5      ��  �� 
TargetName$ gradient��6)   	 �� TargetProperty$'	 !Background.GradientStops[0].Color�6J   	
 �� To$
 #2c3e50X�5   "    g� AutoReverse .  g� Duration$ 0:0:3D�6B    g� RepeatBehavior$ Forever��6S    g� DecelerationRatio$ 1Q�5   "   5      5      5      .��5      �� -   5         ��Name$ gradient��5      ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5       �  � Color$ #bdc3c7��6    � Offset$ 0Q�6/   � 5!      $ #2c3e50��6   $ 1Q�6/   5"      ._�5$   
   �  � RowDefinitions 5%      �� 5&      $	��120 �6    �� 5'      .+�5)      �� $	��100��6   $	��100��6"    * &MaterialDesignFloatingActionDarkButton#��[ 6.   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth5=�6o   .��5*      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=null]]   Kind$ CreditCardSettings=�6*   $��50��6D   $��50��6P   5+      �� 5,      $	��Top=�6    �� RadiusX$ 10��60    �� RadiusY$ 10��6=   
�������$��1��6W   $	��230��6d   $��15q�6q   �� 5-      $	��Top=�6   $	��320��61   $	��220��6>   $��1��6K   
�������$��
16,20,20,0q�6k   .+�5.      �� $��10q�6   $��Center=�6(      MaterialDesignTitleTextBlock#��[ 6E   $ ��Вход в систему��6{   �� 5/      $��5q�6    �� Orientation$ 
Horizontal=�6(   .+�50        $��5q�62   ���#707070$ Account=�6R   $��Center=�6a   �� 51      -   5         ��Name$ Login��51   O   $��20(�65   $	��270��6C   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Логин��6^   .  (MaterialDesignThemes.Wpf.TextFieldAssist   TextBoxViewMargin$ 1 0 1 0q�6�      FloatingScale$
 0.50Q�6�    % !MaterialDesignFloatingHintTextBox#��[ 6�   ��6   �� *Login+.��6*  52      53      �� 54      $��5q�6!   $ 
Horizontal=�6,   .+�55        $��5q�62   ���#707070$	 Key=�6R   $��Center=�6]   G� 56      -   5         G�Name$
 Pass��56   "   $	��320��60   $ Пароль��6<   $
 0.50Q�6e    ) %MaterialDesignFloatingHintPasswordBox#��[ 6�   $��20(�6�   57      �� 58      -   5         ��Name$
 warn��58   C   $��13(�65   
���  ��$��Center=�6d   ��6   �� *Warn+��6�   Z� �� 59      -   5          ��Name$  Enter��59   3   $��Center=�6B   $��
Войти��6_   ��6   �� *Check+6_   5:      5;      5<      5=      