   M S B A M L   `   `   `  ����L  HSyncfusionWpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:SyncfusionWpfApp1.guiSyncfusionWpfApp1.gui  5   	   d `Microsoft.Maps.MapControl.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35tRclr-namespace:Microsoft.Maps.MapControl.WPF;assembly=Microsoft.Maps.MapControl.WPFMicrosoft.Maps.MapControl.WPF 5   	   ?$clr-namespace:SyncfusionWpfApp1.helpSyncfusionWpfApp1.help  5      &     SyncfusionWpfApp1.gui.AddNewLine   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:SyncfusionWpfApp1.gui     5   	   `mRclr-namespace:Microsoft.Maps.MapControl.WPF;assembly=Microsoft.Maps.MapControl.WPF     5   	   2l$clr-namespace:SyncfusionWpfApp1.help     5        � WindowStyle$
  None=�5
       � 
ResizeMode$ NoResize=�6    � Title$! Dodavanje nove medjustanice��5   	   $	��500��6-   $	��700��6:    � WindowStartupLocation$ CenterScreen=�5   	    � AllowsTransparency$
 True��5   	   
������  J� InputBindings 5      �� 5   
   
 �� Key$ F1��6    �� Command$
 Help��6    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5        	   Command$	 ApplicationCommands.Help��5      5      
 � 	Resources
 5   
    �� 
TargetType   tt_style �� Property �� Value��%�  &	        �� 5      " _�6   .�5      ��  �@_�	Placement$ Right=�6.   �� 5       � ��$ 30��6+   �� 5       � ��$
 Auto��6*   �� 5       � ��$ 20,0,0,0q�6+   �� 5       � �� �#E8F0F26/   �� 5        � �� �#00264d60   �� 5!       � �� �#00264d6/   �� 5"       � ��$$ Fonts/Roboto-Light.ttf #Roboto)�6/   �� 5#       � ��$ 16(�6-   �� 5$       �@_�PlacementRectangle$ 60,0,0,0�67   �� 5%       �@_�HorizontalOffset$ 15��65   �� 5&       �@_�VerticalOffset$ 6��63   �� 5'       �@_�HasDropShadow$
 True��62   �� 5(       � ��$ Center=�6?   5+      5,      .��5.   
   �  � ColumnDefinitions 5/      �� 50      $
��0.1* �6#   �� 51      $��* �6#   �� 52      $��5* �6#   �� 53      $	��15* �6#   �� 54      $��* �6#   �� 55      $
��0.1* �6#    � RowDefinitions 57      �� 58      $
��0.1* �6    �� 59      $
��0.6* �6    �� 5:      $��8* �6    �� 5;      $
��0.5* �6    �� 5<      $
��0.1* �6    .+�5?      �� $��0��6   $��0��6"   $��6��62   $��5��6F   ���#E8F0F2$��1q�6l    �� CornerRadius$ 15��6�   ���#00264d6�   (� 5A      $��1��6   $��2��6#   $��4��63   $
��Left=�6G   .��5B      �� $��Medium"�6   $
��Left=�60   $��Center=�6K   $��Italic$�6f   ���#00264dDefinisanje nove Međustanice6�   5C      �� 5E   
   -   5         ��Name$ 
helpButton��5E   .   $��1��6   $��4��6   )   #SyncfusionWpfApp1.help.HelpProvider   HelpKey$ EditAndAddTrainLine��6B   $��Right=�6o   $��35��6�   $��35��6�   $
��Help��5F      
������ .��5G      �� 
������ .+�5H      �� -   5         ��Name$ helpIcon��5H      $��/images/help_icon.png��6.   $��30��6N   $��30��6Y   6g   5I       � ToolTip 5J      _� 5K      $*��$Pomoć za korišćenje stranice (F1)��6   #��[  6J   5M      �� 5N   
   -   5        $ videoButton��5N   .   $��1��6   $��3��6   $��Right=�6C   $��Center=�6_   $��35��6z   $��35��6�   
������ .��5O      �� 
������ .+�5P      �� $��/images/play_icon.png��6   $��30��68   $��30��6C   6Q   5Q       5R      _� 5S      $*��$Demo pomoć za korišćenje stranice��6   #��[  6F   5U      � 5V   
   -   5         �Name$ 
LayoutRoot��5V      
�������$��3��67   $��2��6G   .+�5W      '  !Microsoft.Maps.MapControl.WPF.Map  -   5          Name$ MainMap��5W      +  %Microsoft.Maps.MapControl.WPF.MapCore   CredentialsProviderT  NMicrosoft.Maps.MapControl.WPF.Design.ApplicationIdCredentialsProviderConverter$F @AusVMyYktKC6acBY2olTotz0tcbvBRx6Oal5XaWYcP-lXLpvW2Ejy162U2hIubv6 6*      Mode;  5Microsoft.Maps.MapControl.WPF.Design.MapModeConverter$
 Road 6�      	ZoomLevel$ 7Q�6�      Center<  6Microsoft.Maps.MapControl.WPF.Design.LocationConverter$ 44.2108 , 20.9224 6�    J� 	AllowDrop$
 True��6�   5Y      5Z      � 5[      -   5        $��
LoadingBar��5[   7   $��3��6   $��2��6*    � IsIndeterminate$
 True��6I   $��25��6`   $	��250��6l   $��Center=�6x   $��Center=�6�   $y�	Collapsed=�6�   � 5\      $��2��6   $��2��6     5]      �� 5^      $
��1.2* �6'   �� 5_      $��3* �6'   �� 5`      $
��1.2* �6'    5b      �� 5c      $
��1.2* �6$   �� 5d      $��2* �6$   �� 5e      $��* �6$   �� 5f      $��* �6$   �� 5g      $��* �6$   �� 5h      $��* �6$   �� 5i      $��2* �6$   .+�5l      �� $��0��6   $��0��6%   $��3��65   ���#00264d$��Bottom=�6_   $
��Left=�6z   .��5m      �� $-��'Prevucite pin na željeno mesto na mapi��6    $
��Wrap=�6N   ���#00264d$��15(�6x   $��Italic$�6�   6�   5n      �� 5o      $��2��6   $��0��6%   $��2��65   ���#00264d$��Bottom=�6_   $
��Left=�6z   .��5p      �� $&�� Izaberite stanicu koja prethodi:��6    $
��Wrap=�6H   ���#00264d$��15(�6r   $��Italic$�6�   6�   5q      �� 5s      -   5        $��
comboLines��5s   �   $��3��6   $��0��6(   $��2��68   ���#00264d$
��Left=�6b   $��30��6}   $	��120��6�   $��15(�6�    5t      _� 5u      $ ��Vozna linija koja prethodi��5v   1   #��[  5w   1   5y      (� 5|      $��6��6   $��0��6'   $��3��67   .��5}      ��  �� Orientation$ 
Horizontal=�6!   .+�5~      �� -	   5        $	 Yes��5~   D   $��Sačuvaj��6   $��
0, 0, 2, 3q�6Q   $
��Left=�6e   ���#00264d���#00264d$��5(�5   3   
�������$	��Top=�6S   $��25��6k   
 5�      ��%^   '��       �� 5�   "   " ��6(   .�5�   &   ��  �@��CornerRadius$ 1��6E   5�   #   5�       5�      _� 5�   "   $ ��Čuvanje nove vozne linije��5�   !   #��[  5�   !   5�      �� 5�      -
   5        $ No��5�   4   $��Odustani��6!   ���#00264d$��
0, 0, 2, 0q�6m   $
��Left=�6�   $��5(�6�   $	��Top=�6�   $��25��6�   ���#00264d
������� �� IsCancel$
 True��5�      
 5�      ��%^   '��       �� 5�   "   " ��6(   .�5�   &   ��  �@��CornerRadius$ 1��6E   5�   #   5�       5�      _� 5�   "   $0��*Odustajanje od dodavanja nove vozne linije��5�   !   #��[  5�   !   5�      5�      5�      �� 5�      -   5        $
 img1��5�      $��1��6&   $��50��66   $��1��6B   $��/images/pinRed.png��6O   6�   5�      5�      5�      