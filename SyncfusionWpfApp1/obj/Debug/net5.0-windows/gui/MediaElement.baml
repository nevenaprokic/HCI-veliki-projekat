   M S B A M L   `   `   `  ����L  HSyncfusionWpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:SyncfusionWpfApp1.guiSyncfusionWpfApp1.gui  5   	   (    "SyncfusionWpfApp1.gui.MediaElement   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:SyncfusionWpfApp1.gui     5   	     � Title$  MediaElement��5   	   $
��1200��6   $	��700��6+    � WindowStartupLocation$ CenterScreen=�5	   	    � Icon$ 
../App.ico��5
   	    � 	Resources 5       �� 
TargetType   tt_style �� Property �� Value��%�  &	        �� 5   
   " _�6   .�5      ��  �@_�	Placement$ Right=�6*   �� 5       � ��$ 30��6'   �� 5       � ��$
 Auto��6&   �� 5       � ��$ 20,0,0,0q�6'   �� 5       � �� �#E8F0F26+   �� 5       � �� �#00264d6,   �� 5       � �� �#00264d6+   �� 5       � ��$$ Fonts/Roboto-Light.ttf #Roboto)�6+   �� 5       � ��$ 16(�6)   �� 5       �@_�PlacementRectangle$ 60,0,0,0�63   �� 5       �@_�HorizontalOffset$ 15��61   �� 5       �@_�VerticalOffset$ 6��6/   �� 5       �@_�HasDropShadow$
 True��6.   �� 5       � ��$ Center=�6;   5      5      .��5       � $��10q�6    � RowDefinitions 5!   
   �� 5"      $��* �6   �� 5#      $
��Auto �6   .+�5&   
   (� .��5'      r� -   5         r�Name$ mePlayer��5'      	 r� Stretch$	 UniformToFill=�6-   5(      (� 5*   
   .��5+      �� -   5        
 ��Name$
 labela��5+      $��Italic$�6$   .��67   1/Pritisnite dugme Play da biste pokrenuli video!6h   5,      �� 5-   
   $��1��6   .+�5.      �� -   5        $��	lblStatus��5.      $��Ne pušta se...��6%   $��Center=�6>   $��5q�6b   � 5/      $��Center=�6   .+�51      �� -   5         ��Name$ btnPlay��51      $��35��6*   $��35��65   
������ .��52      �� 
������ .+�53      �� $��/images/play_icon.png��6    $��30��6@   $��30��6K   6Y   54       � ToolTip 55      _� 56      $��Pokreni video��6"   #��[  6:   58      �� 5:      -   5        $ btnPause��5:      $��35��6+   $��35��66   
������ .��5;      �� 
������ .+�5<      �� $��/images/pause_icon.png��6    $��30��6A   $��30��6L   6Z   5=       5>      _� 5?      $��Puziraj��6"   #��[  64   5A      �� 5C      -   5        $ btnStop��5C      $��35��6*   $��35��65   
������ .��5D      �� 
������ .+�5E      �� $��/images/stop_icon.png��6    $��30��6@   $��30��6K   6Y   5F       5G      _� 5H      $��Vrati na početak��6"   #��[  6=   5J      5L      5M      5N      5O      