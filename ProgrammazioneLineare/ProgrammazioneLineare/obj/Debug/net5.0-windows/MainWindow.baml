   M S B A M L   `   `   `  ����E  AFluentWPF, Version=0.10.2.0, Culture=neutral, PublicKeyToken=nullP6clr-namespace:SourceChord.FluentWPF;assembly=FluentWPFSourceChord.FluentWPF  5      P LProgrammazioneLineare, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:ProgrammazioneLineareProgrammazioneLineare 5      I EBlurryControls, Version=1.0.0.1, Culture=neutral, PublicKeyToken=null[>clr-namespace:BlurryControls.Internals;assembly=BlurryControlsBlurryControls.Internals 5      Y=clr-namespace:BlurryControls.Controls;assembly=BlurryControlsBlurryControls.Controls 5	      U QSystem.Runtime, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a7,clr-namespace:System;assembly=System.RuntimeSystem 5
      &    ProgrammazioneLineare.MainWindow   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      Efw6clr-namespace:SourceChord.FluentWPF;assembly=FluentWPF     5      7control#clr-namespace:ProgrammazioneLineare     5      T	internals>clr-namespace:BlurryControls.Internals;assembly=BlurryControls     5      Rcontrols=clr-namespace:BlurryControls.Controls;assembly=BlurryControls     5	      ?System,clr-namespace:System;assembly=System.Runtime     5
      -   5        *  $BlurryControls.Controls.BlurryWindow   Name$  Finestra��5
   T    � Icon$] Wpack://application:,,,/BlurryControls;component/Resources/Icons/256/BlurryWpfWindow.png��5      $	��800��5      $	��600��6$   $��1q�61    � WindowStartupLocation$ CenterScreen=�5       � Title$ Programmazione Lineare��5         Strength$ 0Q�67    � WindowStyle$
 None=�6D      
Background$ Black��6W   .��5      � *   $SourceChord.FluentWPF.PointerTracker   Enabled$
 True��6   ���	#01FFFFFF$��3q�6C    � ColumnDefinitions 5    
   �� 5!      $��1* �6   	 � RowDefinitions	 5#   
   �� 5$      $	��100 �6   �� 5%      $��1* �6   .+�5'   
   �� $��0��6   $��0��6%   $��Center=�62   $��Bottom=�6O   .+�5(      �� 
�������$��16(�6'   .��65   Formula obiettivo:6I   �� 5)      -   5        
 ��Name$
 Formula��5)      .��6'   	20x+12.5y62   �� 5*      
�������$��16(�6'   .��65   
Vincoli:6?   5+      �� 5,   
   $��0��6   $��1��6%   .+�5-      � $��Center=�6   .+�50      &   System.Windows.Controls.DataGrid  -   5          Name$ Tabella��50      $	��250��6,      AutoGenerateColumns$
 True��68      
IsReadOnly$ False��6S   ��6f   Z� ��51      �� 52       �� Color$ Transparent��6*    �� Opacity$	 0.5Q�6>   5;      �� 5<      -   5         ��Name$ Rette��5<   5    J� IsHitTestVisible$ False��6    �� Padding$ 	500 0 0 0q�6D   $��Center=�6X   $��Esempio��6u   5=      �� 5>      -   5         ��Name$
 Tipo��5>      $��5q�6%    �� Text$ TextBox��60   $	��120��6?   
�������.@�5?      �� $��
Massimizza��6    �� 
IsSelected$
 True��64   �� 5@      $��	Minimizza��6   5A      �� 5B      -   5        $��5q�5B      $	��120��6    
�������$��GRAFICO��6V   �� 5C      -   5        $	��120��5C      
�������$��CALCOLA��64   6F   5D      5E      5F      