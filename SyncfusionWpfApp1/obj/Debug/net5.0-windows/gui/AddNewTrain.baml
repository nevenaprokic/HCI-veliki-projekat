   M S B A M L   `   `   `  ����L  HSyncfusionWpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:SyncfusionWpfApp1.guiSyncfusionWpfApp1.gui  5   	   ?$clr-namespace:SyncfusionWpfApp1.helpSyncfusionWpfApp1.help  5   
   '    !SyncfusionWpfApp1.gui.AddNewTrain   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:SyncfusionWpfApp1.gui     5   	   2l$clr-namespace:SyncfusionWpfApp1.help     5   
     � WindowStyle$
  None=�5	   
    � 
ResizeMode$ NoResize=�6    � Title$ Izmena vozne linije��5
   	   $	��500��6%   $	��500��62    � WindowStartupLocation$ CenterScreen=�5   	    � AllowsTransparency$
 True��5   	   
������  J� InputBindings 5      �� 5   
   
 �� Key$ F1��6    �� Command$
 Help��6    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5        	   Command$	 ApplicationCommands.Help��5      5      
 � 	Resources
 5       �� 
TargetType   tt_style �� Property �� Value��%�  &	        �� 5   
   " _�6   .�5      ��  �@_�	Placement$ Right=�6*   �� 5       � ��$ 30��6'   �� 5       � ��$
 Auto��6&   �� 5       � ��$ 20,0,0,0q�6'   �� 5       � �� �#E8F0F26+   �� 5       � �� �#00264d6,   �� 5       � �� �#00264d6+   �� 5        � ��$$ Fonts/Roboto-Light.ttf #Roboto)�6+   �� 5!       � ��$ 16(�6)   �� 5"       �@_�PlacementRectangle$ 60,0,0,0�63   �� 5#       �@_�HorizontalOffset$ 15��61   �� 5$       �@_�VerticalOffset$ 6��6/   �� 5%       �@_�HasDropShadow$
 True��6.   �� 5&       � ��$ Center=�6;   5)      5*      .��5+      �� $��2q�6   ���#00264d �� CornerRadius$ 20��5,      ���#E8F0F2._�5-   
   �  � RowDefinitions 5.      �� 5/      $
��0.6* �6    60   �� 50      $
��0.4* �6    60   �� 51      $
��0.4* �6    60   �� 52      $
��0.2* �6    60   �� 53      $��* �6    6-   �� 54      $��* �6    6-   �� 55      $
��0.4* �6    60   �� 56      $��* �6    6-   �� 57      $
��0.4* �6    60    � ColumnDefinitions 5:      �� 5;      $
��0.5* �6#   62   �� 5<      $��* �6#   6/   �� 5=      $��* �6#   6/   �� 5>      $
��0.6* �6#   62   �� 5?      $
��0.5* �6#   62   .+�5B      (� $��1��6   $��0��6&   $��2��63   .��5C      �� -   5         ��Name$ 
txtMessage��5C      $��18(�5D      $
��Wrap=�6   $��Center=�5E      $��Center=�6.    �� TextAlignment$ Center=�5F      $��Vozovi vozne linije��6(   $
��Bold"�6C   $��Italic$�6U   5G      �� 5H      -   5         ��Name$ 
helpButton��5H   2   $��0��6   $��4��6"   )   #SyncfusionWpfApp1.help.HelpProvider   HelpKey$ AddNewTrain��6F   $��Right=�6k   $��35��6�   $��35��6�   $
��Help��5I      
������ .��5J      �� 
������ .+�5K      �� -   5         ��Name$ helpIcon��5K      $��/images/help_icon.png��6.   $��30��6N   $��30��6Y   6g   5L       � ToolTip 5M      _� 5N      $%��Pomoć za korišćenje stranice��6   #��[  6E   5P      �� 5Q      -   5        $ videoButton��5Q   2   $��0��6   $��4��6"   $
��Left=�6G   $��Center=�6b   $��35��6}   $��35��6�   
������ .��5R      �� 
������ .+�5S      �� $��/images/play_icon.png��6   $��30��6<   $��30��6G   6U   5T       5U      _� 5V      $%��Pomoć za korišćenje stranice��6   #��[  6E   5X      (� 5Z      $��1��6   $��2��6&   $��2��63   $
��Left=�6G   .��5[      �� -   5         ��Name$ lblTrainLine��5[      $��29(�5\      $��Center=�5]      $��Center=�6.   $��Izaberite nove vozove: ��5^      5_      &   System.Windows.Controls.DataGrid  5a      -   5        $��dataGridTrain��5a         AutoGenerateColumns$ False��5b      $��4��5c      $��1��5d      $��2��5e      $��3��5f      $��14(�5g         
IsReadOnly$
 True��5i      ��5h      �� *RowsNewTrain+   	CellStyle 5m      �� 5n      *  $System.Windows.Controls.DataGridCell"  6   .�5o      ��  � �� �#00264d67   �� 5p       � ��$	 0.6q�6<   �� 5q       � ��$ Stretch=�6@   �� 5r       � ��$ Center=�6G   5t         Columns 5x      0  *System.Windows.Controls.DataGridTextColumn  5y      ,  &System.Windows.Controls.DataGridColumn   Header$ Ime voza��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6U   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *Name+6U   4	  .System.Windows.Controls.DataGridTemplateColumn	  5z      $ Dodaj��6-   $
 0.6* 6=    	  CellTemplate 5{      �� 5|      .R�5}   "   �� $ addRowButton��6)   -   5        $��30��5}   ?   
�������.��5~   &   �� .+�5   *   �� $ addIconTable��60   $��/images/add1.png��6F   $��20��6a   $��20��6l   6z   5�   '   5�   #   5�      5�      
 5�      =
  7System.Windows.Controls.Primitives.DataGridColumnHeader��%�   '
        �� 5�      " 
 6   .�5�      ��  � ��$ Stretch=�6@   �� 5�       � ��$ 30��63   �� 5�       � ��$ DemiBold"�68   �� 5�       � ��$ Center=�6G   5�      5�      5�      �� 5�      -	   5        $ delete��5�      $��2��6%   $��3��6:   $	��110��6J   $��7��6Y   $��Center=�6f   $��Center=�6�   ���#00264d��5�      �� 5�      $��Center=�6!   $��Center=�5�        �� Orientation$  
Horizontal=�62   
������ $��29��5�   .   .+�5�      �� $��/images/give_up.png��6    �� 5�      $��Odustani��6    $	��Top=�63   $��Center=�5�      ���#00264d
�������$��15(�6Y   5�      
 5�      ��%^   '��       �� 5�      " ��6   .�5�      ��  �@��CornerRadius$ 5��69   5�      5�      5�      �� 5�      -
   5        $��2��5�   *   $	��110��6:   $��7��6I   $��Center=�6V   $��Center=�6q   ���#00264d
�������$��15(�6�   ��5�      �� 5�      $��Center=�6!   $��Center=�5�      $  
Horizontal=�62   
������ $��29��5�   .   .+�5�      �� $��/images/save.png��6    �� 5�      $��Sačuvaj��6    $	��Top=�62   $��Center=�5�      ���#00264d
�������$��15(�6Y   5�      
 5�      ��%^   '��       �� 5�      " ��6   .�5�      ��  �@��CornerRadius$ 5��69   5�      5�      5�      5�      5�      5�      