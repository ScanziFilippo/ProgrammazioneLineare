   M S B A M L   `   `   `  ���� E  AFluentWPF, Version=0.10.2.0, Culture=neutral, PublicKeyToken=nullP6clr-namespace:SourceChord.FluentWPF;assembly=FluentWPFSourceChord.FluentWPF  P LProgrammazioneLineare, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:ProgrammazioneLineareProgrammazioneLineare I EBlurryControls, Version=1.0.0.1, Culture=neutral, PublicKeyToken=null[>clr-namespace:BlurryControls.Internals;assembly=BlurryControlsBlurryControls.Internals Y=clr-namespace:BlurryControls.Controls;assembly=BlurryControlsBlurryControls.Controls U QSystem.Runtime, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a7,clr-namespace:System;assembly=System.RuntimeSystem &    ProgrammazioneLineare.MainWindow   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     Efw6clr-namespace:SourceChord.FluentWPF;assembly=FluentWPF     7control#clr-namespace:ProgrammazioneLineare     T	internals>clr-namespace:BlurryControls.Internals;assembly=BlurryControls     Rcontrols=clr-namespace:BlurryControls.Controls;assembly=BlurryControls     ?System,clr-namespace:System;assembly=System.Runtime     -   *  $BlurryControls.Controls.BlurryWindow   Name$  Finestra�� � Icon$] Wpack://application:,,,/BlurryControls;component/Resources/Icons/256/BlurryWpfWindow.png��$	��800��$	��600��$��1q� � WindowStartupLocation$ CenterScreen=� � Title$ Programmazione Lineare��   Strength$ 0Q� � WindowStyle$
 None=�   
Background$ Black��.��� *   $SourceChord.FluentWPF.PointerTracker   Enabled$
 True�����	#01FFFFFF$��3q� � ColumnDefinitions �� $��1* �	 � RowDefinitions	 �� $	��100 ��� $��1* �.+��� $��0��$��0��$��Center=�$��Bottom=�.+��� 
�������$��16(�.��Formula obiettivo:�� -   
 ��Name$
 Formula��.��	20x+12.5y�� 
�������$��16(�.��
Vincoli:�� $��0��$��1��.+�� $��Center=�.+�&   System.Windows.Controls.DataGrid  -     Name$ Tabella��$	��250��   AutoGenerateColumns$
 True��   
IsReadOnly$ False����Z� ����  �� Color$ Transparent�� �� Opacity$	 0.5Q��� -    ��Name$ Rette�� J� IsHitTestVisible$ False�� �� Padding$ 	500 0 0 0q�$��Center=�$��Esempio���� -    ��Name$
 Tipo��$��5q� �� Text$ TextBox��$	��120��
�������.@��� $��
Massimizza�� �� 
IsSelected$
 True���� $��	Minimizza���� -   $��5q�$	��120��
�������$��GRAFICO���� -   $	��120��
�������$��CALCOLA��