   M S B A M L   `   `   `  ����L  HSyncfusionWpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:SyncfusionWpfApp1.guiSyncfusionWpfApp1.gui  5      d `Microsoft.Maps.MapControl.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35tRclr-namespace:Microsoft.Maps.MapControl.WPF;assembly=Microsoft.Maps.MapControl.WPFMicrosoft.Maps.MapControl.WPF 5      ?$clr-namespace:SyncfusionWpfApp1.helpSyncfusionWpfApp1.help  5      +    %SyncfusionWpfApp1.gui.AddNewTrainLine   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:SyncfusionWpfApp1.gui     5      `mRclr-namespace:Microsoft.Maps.MapControl.WPF;assembly=Microsoft.Maps.MapControl.WPF     5      2l$clr-namespace:SyncfusionWpfApp1.help     5        N� Title$  AddNewTrainLine��5       � 	Resources 5       �� 
TargetType   tt_style �� Property �� Value��%�  &	        �� 5   
   " _�6   .�5      ��  �@_�	Placement$ Right=�6*   �� 5       � ��$ 30��6'   �� 5       � ��$
 Auto��6&   �� 5       � ��$ 20,0,0,0q�6'   �� 5       � �� �#E8F0F26+   �� 5       � �� �#00264d6,   �� 5       � �� �#00264d6+   �� 5       � ��$$ Fonts/Roboto-Light.ttf #Roboto)�6+   �� 5       � ��$ 16(�6)   �� 5       �@_�PlacementRectangle$ 60,0,0,0�63   �� 5       �@_�HorizontalOffset$ 15��61   �� 5       �@_�VerticalOffset$ 6��6/   �� 5       �@_�HasDropShadow$
 True��6.   �� 5       � ��$ Center=�6;   5       5!      .��5#      �  � ColumnDefinitions 5$   
   �� 5%      $��2* �6   �� 5&      $��* �6   �� 5'      $��4* �6   �� 5(      $	��15* �6   �� 5)      $��* �6   �� 5*      $��2* �6    � RowDefinitions 5,   
   �� 5-      $��* �6   �� 5.      $
��0.6* �6   �� 5/      $��8* �6   �� 50      $
��0.5* �6   �� 51      $��* �6   .+�54   
   �� $��1��6   $��1��6   $��4��6.   $��3��6B   ���#E8F0F2$��1q�6h    �� CornerRadius$ 15��6|   ���#00264d6�   (� 56   
   $��1��6   $��2��6   $��4��6/   $
��Left=�6C   .��57      �� $��Medium"�6   $
��Left=�6,   $��Center=�6G   $��Italic$�6b   ���#00264dDefinisanje nove vozne linije6�   58      �� 5:   
   -   5         ��Name$ 
helpButton��5:   .   $��1��6   $��4��6   )   #SyncfusionWpfApp1.help.HelpProvider	   HelpKey$	 AddNewTrainLine��6B   $��Right=�6k   $��35��6�   $��35��6�   $
��Help��5;      
������ .��5<      �� 
������ .+�5=      �� -   5        
 ��Name$
 helpIcon��5=      $��/images/help_icon.png��6*   $��30��6J   $��30��6U   6c   5>       � ToolTip 5?      _� 5@      $*��$Pomoć za korišćenje stranice (F1)��6   #��[  6F   5B      �� 5C   
   -   5        $ videoButton��5C   .   $��1��6   $��3��6   $��Right=�6C   $��Center=�6_   $��35��6z   $��35��6�   
������ .��5D      �� 
������ .+�5E      �� $��/images/play_icon.png��6   $��30��68   $��30��6C   6Q   5F       5G      _� 5H      $*��$Demo pomoć za korišćenje stranice��6   #��[  6F   5J      � 5K   
   -   5         �Name$ 
LayoutRoot��5K      
�������$��3��67   $��2��6G   .+�5L      '  !Microsoft.Maps.MapControl.WPF.Map  -   5          Name$ MainMap��5L      +  %Microsoft.Maps.MapControl.WPF.MapCore   CredentialsProviderT  NMicrosoft.Maps.MapControl.WPF.Design.ApplicationIdCredentialsProviderConverter$F @AusVMyYktKC6acBY2olTotz0tcbvBRx6Oal5XaWYcP-lXLpvW2Ejy162U2hIubv6 6&      Mode;  5Microsoft.Maps.MapControl.WPF.Design.MapModeConverter$
 Road 6}      	ZoomLevel$ 7Q�6�      Center<  6Microsoft.Maps.MapControl.WPF.Design.LocationConverter$ 44.2108 , 20.9224 6�    J� 	AllowDrop$
 True��6�   5N      5O      � 5P   
   -   5        $��
LoadingBar��5P   3   $��3��6   $��2��6&    � IsIndeterminate$
 True��6E   $��25��6\   $	��250��6h   $��Center=�6t   $��Center=�6�   $y�	Collapsed=�6�   � 5Q   
   $��2��6   $��2��6    5R      �� 5S      $
��1.2* �6#   �� 5T      $��3* �6#   �� 5U      $
��1.2* �6#    5W      �� 5X      $
��1.2* �6    �� 5Y      $��2* �6    �� 5Z      $��* �6    �� 5[      $��* �6    �� 5\      $��* �6    �� 5]      $��* �6    �� 5^      $��2* �6    .+�5a      �� $��0��6   $��0��6!   $��3��61   ���#00264d$��Bottom=�6[   $
��Left=�6v   .��5b      �� $-��'Prevucite pin na željeno mesto na mapi��6   $
��Wrap=�6J   ���#00264d$��15(�6t   $��Italic$�6�   6�   5c      (� 5e      $��1��6   $��3��6&   $��Right=�63   $��Center=�6O   .��5f      �� -   5        $��Nacrtaj rutu��5f      $��90��60   $��29��6>   
����������#00264d 5g      ��%^   '��       �� 5h      " ��6    .�5i      ��  �@��CornerRadius$ 5��6=   5j      5k       5l      _� 5m      $'��!Iscrtavanje izabrane rute na mapi��5n   !   #��[  5o   !   5q      5r      (� 5s      $��1��6   $��4��6&   $��Right=�63   $��Center=�6O   .��5t      �� -   5        $��	Dodaj voz��5t      $��90��6-   $��29��6;   
����������#00264d 5u      ��%^   '��       �� 5v      " ��6    .�5w      ��  �@��CornerRadius$ 5��6=   5x      5y       5z      _� 5{      $1��+Dodavanje vozova koji saobraćaju na liniji��5|   !   #��[  5}   !   5      5�      (� 5�      $��1��6   $��5��6&   $��Right=�63   $��Center=�6O   .��5�      �� -	   5        $��Dodaj raspored��5�      $��90��6Q   $��29��6_   
����������#00264d 5�      ��%^   '��       �� 5�      " ��6    .�5�      ��  �@��CornerRadius$ 5��6=   5�      5�       5�      _� 5�      $!��Dodavanje rasporeda vožnje��5�   !   #��[  5�   !   5�      5�      (� 5�      $��6��6   $��0��6#   $��3��63   .��5�      ��  �� Orientation$ 
Horizontal=�6   .+�5�      �� -
   5        $	 Yes��5�   D   $��Sačuvaj��6   $��
0, 0, 2, 3q�6Q   $
��Left=�6e   ���#00264d���#00264d$��5(�5�   3   
�������$	��Top=�6S   $��25��6k    5�      ��%^   '��       �� 5�      " ��6$   .�5�   "   ��  �@��CornerRadius$ 1��6A   5�      5�       5�      _� 5�      $ ��Čuvanje nove vozne linije��5�   !   #��[  5�   !   5�      �� 5�      -   5        $ No��5�   0   $��Odustani��6   ���#00264d$��
0, 0, 2, 0q�6i   $
��Left=�6}   $��5(�6�   $	��Top=�6�   $��25��6�   ���#00264d
������� �� IsCancel$
 True��5�       5�      ��%^   '��       �� 5�      " ��6$   .�5�   "   ��  �@��CornerRadius$ 1��6A   5�      5�       5�      _� 5�      $0��*Odustajanje od dodavanja nove vozne linije��5�   !   #��[  5�   !   5�      5�      5�      �� 5�      -   5        $

 img1��5�      $��1��6"   $��50��62   $��1��6>   $��/images/pinRed.png��6K   6�   5�      5�      5�      