   M S B A M L   `   `   `  ����L  HSyncfusionWpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:SyncfusionWpfApp1.guiSyncfusionWpfApp1.gui  5   	   /    )SyncfusionWpfApp1.gui.TicketDetailsDialog   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:SyncfusionWpfApp1.gui     5   	     � WindowStyle$
  None=�5   	    � 
ResizeMode$ NoResize=�6    � WindowStartupLocation$ CenterScreen=�5	   	    � AllowsTransparency$
 True��5
   	   
������  � Title$ Detaljan prikaz karte��5   	   $	��400��6'   $	��600��64   .��5      �  � RowDefinitions 5   
   �� 5      $
��0.3* �6   �� 5      $��1* �6   �� 5      $
��0.7* �6   �� 5      $
��0.5* �6   �� 5      $
��0.5* �6   �� 5      $
��0.3* �6   �� 5      $
��0.5* �6   �� 5      $
��0.5* �6   �� 5      $
��0.5* �6   �� 5      $
��0.5* �6   �� 5      $
��0.5* �6   �� 5      $
��0.5* �6   �� 5      $
��0.5* �6   �� 5      $
��0.5* �6   �� 5      $
��0.3* �6    � ColumnDefinitions 5   
   �� 5       $
��0.5* �6   �� 5!      $
��3.5* �6   �� 5"      $��1* �6   �� 5#      $
��3.5* �6   �� 5$      $
��0.5* �6   .+�5'   
   �� $��0��6   $��0��6   $��5��6.   $��15��6B   
�������$��2q�6g    �� CornerRadius$ 15��6{   ���#00264d6�   � 5)   
   $��1��6   $��1��6   $��4��6,    5*      �� 5+      $
��0.5* �6#   �� 5,      $
��0.1* �6#   �� 5-      $
��0.5* �6#   �� 5.      $��2* �6#    50      �� 51      .+�53      (� $��0��6   $��0��6#   $��3��63   .��54      �� $��Detaljni prikaz karte��6   $
��Wrap=�69   ���#204060$��Italic$�6b   $
��Left=�6u   6�   55      56      � 58   
   $��2��6   $��10��6   $��1��6.   $��3��6>    59      �� 5:      $
��0.2* �6+   �� 5;      $
��0.3* �6+   �� 5<      $
��0.4* �6+   �� 5=      $
��0.4* �6+   �� 5>      $
��0.3* �6+   �� 5?      $
��0.3* �6+   �� 5@      $
��0.6* �6+   �� 5A      $
��0.4* �6+    5C      �� 5D      $
��0.1* �6(   �� 5E      $
��0.3* �6(   �� 5F      $
��0.2* �6(   �� 5G      $
��0.5* �6(   �� 5H      $
��0.4* �6(   �� 5I      $
��0.5* �6(   �� 5J      $
��0.4* �6(   �� 5K      $
��0.4* �6(   �� 5L      $
��0.4* �6(   �� 5M      $
��0.4* �6(   �� 5N      $
��0.3* �6(   �� 5O      $
��0.1* �6(   .+�5R      �� 
�������$ 15��60   $��0��6B   $��10��6O   $��0��6a   $��8��6q   ���#204060$	��1.5q�6�   6�   �� 5S      ���#E8F0F2$ 	15,15,0,0��62   $��0��6K   $��2��6X   $��0��6i   $��8��6y   ���#204060$��1.5, 1.5,1.5,0q�6�   6�   �� 5U      -   5         ��Name$ AppIcon��5U      $��1��6-   $��1��6:   $��Center=�6J   6i   �� 5V      -   5        $ 	startIcon��5V      $��3��6/   $��1��6<   $��Right=�6L   �� 5W      -   5        $ endIcon��5W      $��3��6-   $��5��6:   $��Right=�6J   �� 5X      -   5        $ 
ClockIcon1��5X      $��5��60   $��1��6=   $��Right=�6M   �� 5Y      -   5        $ 
ClockIcon2��5Y      $��5��60   $��5��6=   $��Right=�6M   �� 5Z      -   5        $ 
cardArrow1��5Z      $��3��60   $��4��6=   $��Center=�6M   �� 5[      -   5        $ 
cardArrow2��5[      $��5��60   $��4��6=   $��Center=�6M   (� 5]      $��1��6   $��2��6+   $��3��6;   $
��Left=�6O   .��5^      �� $��Vozna karta��6    $��Italic$�66   $
��Bold"�6I   
����  �$��17(�6q   6�   5_      �� 5b      $��3��6   $��2��6*   $��2��6:   
�������$��0,0,0,1q�6c   6   �� 5c      $��3��6   $��2��6)   $��2��69   $��2��6M   $
��Left=�6^   .��5d      �� $��14(�6$   $��WrapWithOverflow=�62   
����  ���6h   �� *	From.Name+5e      �� 5g      $��3��6   $��6��6*   $��2��6:   
�������$��0,0,0,1q�6c   6   �� 5h      $��3��6   $��6��6)   $��2��69   $��2��6M   $
��Left=�6^   
����  �$��11(�6�   $��Stretch=�6�   .��5i      �� $��14(�6$   $��WrapWithOverflow=�62   
����  ���6h   �� *	To.Name+5j      (� 5l      $��5��6   $��2��6+   $��2��6;   $
��Left=�6O   .��5m      �� 
����  �$��7(�6.   
�������$��0,0,0,1q�6r   ��6;   �� *DepartureTime+6�   5n      (� 5o      $��5��6   $��6��6+   $��2��6;   $
��Left=�6O   .��5p      �� 
����  �$��7(�6.   
�������$��0,0,0,1q�6p   ��6;   �� *ArrivalTime+6�   5q      (� 5t      -   5        	 (�Name$	 returnTicketLabel��5t      $��6��69   $��1��6F   $
��Left=�6W   $��2��6r   $y�Hidden=�6�   .��5u      �� 
����  �$��10(�66   $��Povrtna karta: da��6D   6c   5v      (� 5w      -	   5        $	 returnTicketExpireLabel��5w      $��6��6@   $��4��6M   $��2��6]   $
��Left=�6r   $y�Hidden=�6�   .��5x      �� 
����  �$��10(�66   $��Povrtna karta važi do��6D   6g   5y      (� 5z      -
   5        $	 returnTicketExpireDate��5z      $��6��6>   $��6��6K   $
��Left=�6[   $y�Hidden=�6v   .��5{      �� 
����  �$��10(�66   ��6D   �� *
ExpireDate+6f   5|      (� 5~      -   5        $	 indirectRideLabel��5~      $��6��69   $��4��6F   $
��Left=�6W   $��2��6r   $y�Hidden=�6�   .��5      �� 
����  �$��10(�66   $��Presedanje: da��6D   6`   5�      (� 5�      $��7��6   $��1��6+   $
��Left=�6<   .��5�      �� 
����  �$��10(�66   $
��Voz:��6D   6V   5�      (� 5�      $��7��6   $��2��6+   $
��Left=�6<   .��5�      �� 
����  �$��10(�6.   ��6<   �� *
Train.Name+6^   5�      (� 5�      $��8��6   $��1��6+   $
��Left=�6<   .��5�      �� 
����  �$��10(�66   $��Razred:��6D   6Y   5�      (� 5�      $��8��6   $��2��6+   $
��Left=�6<   .��5�      �� 
����  �$��10(�66   ��6D   �� *ClassNumber+6g   5�      (� 5�      $��7��6   $��4��6+   $
��Left=�6<   .��5�      �� 
����  �$��10(�66   $��Vagon:��6D   6X   5�      (� 5�      $��7��6   $��5��6+   $
��Left=�6<   .��5�      �� 
����  �$��10(�6.   ��6<   �� *Seat.Wagon.OrderdNumber+6k   5�      (� 5�      $��8��6   $��4��6+   $
��Left=�6<   .��5�      �� 
����  �$��10(�66   $��Sediste:��6D   6Z   5�      (� 5�      $��8��6   $��5��6+   $
��Left=�6<   .��5�      �� 
����  �$��10(�66   ��6D   �� *Seat.SeatNumber+6k   5�      �� 5�      ���#E8F0F2���#204060$��1.5,0,1.5,1.5q�6H   $ 	0,0,15,15��6h   $��9��6�   $��0��6�   $��8��6�   6�   �� 5�      $ 10��6   
�������$��7��6C   $��6��6P   (� 5�      $��7��6   $��6��6+   .��5�      �� $
��Bold"�6=   $��10(�6O   
����  ���6    �� *
PriceStr+6u   5�      5�      � 5�   
   $��1��6   $��12��6   $��3��6-    5�      �� 5�      $
��0.5* �6#   �� 5�      $
��0.5* �6#   �� 5�      $
��0.1* �6#   �� 5�      $
��0.5* �6#   �� 5�      $
��0.1* �6#   �� 5�      $
��0.5* �6#   �� 5�      $
��0.5* �6#    5�      �� 5�      .+�5�      �� -   5        
 ��Name$
 Exit1��5�      $��1��6$   $��Izađi��64   ���#BB6464
�������$
��Bold"�6l   $y�Hidden=�6�    � 	Resources 5�       �� 
TargetType �� Property �� Value��%^   '��       �� 5�      " ��6   .�5�      ��  �@��CornerRadius$ 5��69   5�      5�      5�      �� 5�      -   5        $
 Exit2��5�      $��3��6$   $��Izađi��64   ���#BB6464
�������$
��Bold"�6l    5�      ��%^   '��       �� 5�      " ��6   .�5�      ��  �@��CornerRadius$ 5��69   5�      5�      5�      �� 5�      -   5        $
 reservationCancelBtn��5�      $��3��63   $��Otkaži��6C   ���#FFA881
�������$
��Bold"�6|   $y�Hidden=�6�    5�      ��%^   '��       �� 5�      " ��6   .�5�      ��  �@��CornerRadius$ 5��69   5�      5�      5�      �� 5�      -   5        $
 	boughtBtn��5�      $��5��6(   $
��Kupi��68   ���#86b069
�������$
��Bold"�6o   $y�Hidden=�6�    5�      ��%^   '��       �� 5�      " ��6   .�5�      ��  �@��CornerRadius$ 5��69   5�      5�      5�      5�      5�      5�      