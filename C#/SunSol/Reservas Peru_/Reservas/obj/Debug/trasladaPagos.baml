   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089M4clr-namespace:System.Globalization;assembly=mscorlibSystem.Globalization  5   	    Reservas   Reservas.trasladaPagos   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   T	 PMahApps.Metro, Version=1.3.0.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f;Controls,http://metro.mahapps.com/winfx/xaml/controls 	 5   	   =gl4clr-namespace:System.Globalization;assembly=mscorlib 	 5   	   -   5        ( 	 "MahApps.Metro.Controls.MetroWindow   Name$  frmTraspaso��5   	    � Title$ trasladaPagos��5   	   $	��320��6   $
��1117��6,    � WindowStartupLocation$ CenterScreen=�69   .��5	      �  J� RenderTransformOrigin$ 	0.5,0.721&�6   $��0,22,2,0q�6-   .+�5
   
   �� $��0��6   $��Retales��6    $��10,-15,10,10q�61   ��5      �� 5      .R�5      � $��Stretch=�6   $��Stretch=�69   $��27��6U   .+�5      �� $��Traslado de pagos��6    
�������$
��Bold"�6O   $��16(�6a   $��	5,0,0,-11q�6o   $
��Left=�5      $��Stretch=�6#   5      5      .��5      &   System.Windows.Controls.DataGrid  -   5          Name$ dtgPagos��5      $��
0,0,-2,134q�6)      CanUserReorderColumns .     CanUserResizeColumns .     CanUserResizeRows .     CanUserSortColumns .  	   SelectionMode$	 Single=�6�   
   MaxColumnWidth$	
 200Q�6�      AutoGenerateColumns .     CanUserAddRows .     CanUserDeleteRows .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   CanUserResize .     
IsReadOnly .    Header$ Concepto��6|   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6)   �� *
concepto+ �� Mode$ OneWay=�   	CellStyle 5      �� 5      .�5   "   ��  �� Property � �� �� Value$
 Left=�6Y   5      5         5!       .   . $ 	Monto bs.��6�    6)   �� *monto+$ OneWay=� �� StringFormat$ 
{0:#,#.00}�� �� InstalledUICulture �� ConverterCulture# Z  5"      �� 5#      .�5$   "   ��  � ��$ Right=�6Y   5%      5(        5)       .   . $ Puntos��6{    6)   �� *	puntosA+$ OneWay=� 5*      �� 5+      .�5,   "   ��  � ��$ Right=�6Y   5-      50        51       .   . $ transacción��6    6)   �� *transaccion+$ OneWay=� 52      �� 53      .�54   "   ��  � ��$
 Left=�6Y   55      58        59       .   . $ N° Documento��6}    6)   �� *	documento+$ OneWay=� 5:      �� 5;      .�5<   "   ��  � ��$ Right=�6Y   5=      5@        5B       .   . $ fecha��6�    6)   �� *fecha+$ OneWay=�$ {0:dd-MM-yyyy}�� 5C      �� 5D      .�5E   "   ��  � ��$ Center=�6Y   5F      5I        5J       .   . $
 tipo��6x    6)   �� *tipo+$ OneWay=� 5K      �� 5L      .�5M   "   ��  � ��$
 Left=�6Y   5N      5Q        5R       .   . $ Banco��6z    6)   �� *cuenta+$ OneWay=� 5S      �� 5T      .�5U   "   ��  � ��$
 Left=�6Y   5V      5Y        5Z       .   . $ hotel��6y    6)   �� *hotel+$ OneWay=� 5[      �� 5\      .�5]   "   ��  � ��$
 Left=�6Y   5^      5a        5b       .   . $ observación��6    6)   �� *observacion+$ OneWay=� 5c      �� 5d      .�5e   "   ��  � ��$
 Left=�6Y   5f      5i      5l      5m      �� 5n   
   -   5         ��Name$ 	txtmonto1��5n      $
��Left=�6%   $��23��6@   $��102,146,0,0q�6L    �� TextWrapping$
 Wrap=�6a   $	��Top=�6u   $	��120��6�   6�   �� 5o   
   $��
Monto Bs.:��6   $
��Left=�6%   $��
31,146,0,0q�6@   $	��Top=�6T   $
��Bold"�6l   �� 5p   
   $��Reserva Nº:��6   $
��Left=�6&   $��381,146,0,0q�6A   $	��Top=�6V   $
��Bold"�6n   �� 5q   
   -   5         ��Name$ lstReservas��5q      $
��Left=�6(   $��463,146,0,0q�6C   $	��Top=�6X   $	��354��6p   6|   �� 5r   
   -   5         ��Name$ btnTraspasoPago��5r      $�� ��6*   $��Right=�65   $��	0,0,73,46q�6Q   $��Bottom=�6d   $��32��6    � ToolTip$ Trasladar pago��6�   {�.  $ -0.734,0.04&�6�   ��5s      �� 5t       �� ImageSource$ icono/next.png��6     j� Stretch$  Uniform=�6:   5v      �� 5w   
   $��	Concepto:��6   $
��Left=�6$   $��
31,172,0,0q�6?   $	��Top=�6S   $
��Bold"�6k   $ 0.515,-0.077&�6}   �� 5x   
   -   5        $ 
lstCargos1��5x      $
��Left=�6'   $��102,172,0,0q�6B   $	��Top=�6W   $	��251��6o   �� 5y   
   -   5        $ txtobservacion��5y      $
��Left=�6*   $��49��6E   $��463,172,0,0q�6Q   $
 Wrap=�6f   $	��Top=�6z   $	��354��6�   �� 5z   
   $��Observación:��6   $
��Left=�6'   $��381,172,0,0q�6B   $	��Top=�6W   $
��Bold"�6o   5|      5}      