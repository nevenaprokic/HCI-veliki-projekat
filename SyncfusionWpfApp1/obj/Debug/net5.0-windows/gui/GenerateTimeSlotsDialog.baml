   M S B A M L   `   `   `  ����L  HSyncfusionWpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:SyncfusionWpfApp1.guiSyncfusionWpfApp1.gui  5   	   3    -SyncfusionWpfApp1.gui.GenerateTimeSlotsDialog   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:SyncfusionWpfApp1.gui     5   	     � WindowStyle$
  None=�5   	    � 
ResizeMode$ NoResize=�6    � WindowStartupLocation$ CenterScreen=�5	   	    � AllowsTransparency$
 True��5
   	   
������  � Title$ GenerateTimeSlotsDialog��5   	   $	��300��6)   $	��500��66   .��5      �� $��2q�6   
���   � �� CornerRadius$ 20��5      ���#E8F0F2._�5   
   �  � RowDefinitions 5      �� 5      $��* �6    6-   �� 5      $��* �6    6-   �� 5      $��* �6    6-   �� 5      $��* �6    6-   �� 5      $
��0.7* �6    60   �� 5      $��* �6    6-   �� 5      $��2* �6    6.   �� 5      $
��0.1* �6    60    � ColumnDefinitions 5      �� 5      $��* �6#   6/   �� 5      $��* �6#   6/   �� 5      $��* �6#   6/   �� 5      $��* �6#   6/   �� 5      $��* �6#   6/   �� 5      $��* �6#   6/   �� 5       $��* �6#   6/   .+�5#      (� $��1��6   $��1��6#   $��5��63   $	��Top=�6G   .��5$      �� -   5         ��Name$ headline��5$      $
��Wrap=�6.   $&�� Automatsko generisanje rasporeda��6B   ���#00264d$
��Bold"�6   5%      (� 5'      $��3��6   $��1��6#   .��5(      �� $	��Od:��6   ���#00264d6>   5)      �� 5*      -   5        	 ��Name$	 
comboStart��5*      $��4��6+   $��1��68   ���#00264d
�������
 �� 
IsEditable$
 False��6q   (� 5,      $��3��6   $��3��6#   .��5-      �� $	��Do:��6   ���#00264d6=   5.      �� 5/      -   5        $	 comboEnd��5/      $��4��6)   $��3��66   ���#00264d
�������$
 False��6o   (� 51      $��3��6   $��5��6#   .��52      �� $��	Interval:��6   ���#00264d6C   53      (� 55      $��4��6   $��5��6#   .��56      �� -   5        $��intervalTextBox��56      ���#00264d���#00264d$��50��6\   6j   57      (� 59      $��5��6   $��4��6#   $��3��63   $	��Top=�6G   .��5:      �� -   5         ��Name$ intervalValidationLabel��5:      $�� ��69   ���#BB6464$��Italic$�6Y   5;      (� 5=      $��6��6   $��1��6#   $��5��63   .��5>      ��  �� Orientation$ 
Horizontal=�6   .+�5?      �� -   5         ��Name$	 Yes��5?   0   $��	Generiši��6   $��0, 0, 30, 5q�6=   $
��Left=�6R   ���#00264d$��5(�6�   
�������$	��Top=�6�   $��45��6�    � 	Resources 5A       �� 
TargetType �� Property �� Value��%^   '��       �� 5B      " ��6$   .�5C   "   ��  �@��CornerRadius$ 5��6A   5D      5E      5F      �� 5G      -   5        $ No��5G   0   $��Odustani��6   $
��Left=�6<   $��5(�6W   $	��Top=�6d   $��45��6|   ���#00264d
������� �� IsCancel$
 True��5H   .    5I      ��%^   '��       �� 5J      " ��6$   .�5K   "   ��  �@��CornerRadius$ 5��6A   5L      5M      5N      5O      5Q      5S      5T      5U      