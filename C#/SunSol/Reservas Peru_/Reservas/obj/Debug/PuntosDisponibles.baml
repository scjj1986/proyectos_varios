   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089M4clr-namespace:System.Globalization;assembly=mscorlibSystem.Globalization  5       Reservas    Reservas.PuntosDisponibles   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      NGlobalization4clr-namespace:System.Globalization;assembly=mscorlib     5      -   5          N� Title$  PuntosDisponibles��5      $
��auto��6   $
��auto��6*   .��5
      � $
��auto��6   $
��auto��6   .+�5   
   �� $��0��6   $��Retales��6    $��0q�61   ��5      �� 5      .R�5      � $��Stretch=�6   $��Stretch=�69   $��27��6U   .+�5      �� $��Puntos disponibles��6    
�������$
��Bold"�6P   $��14(�6b   $��5,0,0,0q�6p   $
��Left=�5      $��Center=�6#   5      5      .��5      �� -   5         ��Name$ tbprincipal��5      $��	0,95,0,33q�6.   .@�5      �� -   5         ��Name$ tbContratos��5      $��	Contratos��6/   $
��Left=�6B   $	��127��6]   .��5      � ���	#FFE5E5E5$��0,0,0,4q�62   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ dtgrdContratos��5   #      AutoGenerateColumns .   �� AlternationCount$ 1��6q      CanUserReorderColumns .     CanUserResizeColumns .     CanUserAddRows .  	   CanUserResizeRows	 .  
   CanUserSortColumns
 .   � ToolTip$. (Doble click para seleccionar un contrato��6@  $   HorizontalScrollBarVisibility$ Disabled=�6s  $��Center=�6�  #��� ��6�  $��0,0,0,13q�6  ��6=   ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5   "   ,  &System.Windows.Controls.DataGridColumn   CanUserResize .     
IsReadOnly .    Header$ N° Contrato��6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *NroContrato+ �� Mode$ OneWay=�   	CellStyle 5    &   �� 5!   *   .�5"   .   ��  �� Property � �� �� Value$ Center=�6e   5#   +   5&   #     5(   "    .   . $ tipo contrato��6�    65   �� *DescripcionTipoContrato+$ OneWay=� 5)   &   �� 5*   *   .�5+   .   ��  � ��$
 Left=�6e   5,   +   5.   #     5/   "    .   . $ puntos��6�    65   �� *puntos+$ OneWay=� 50   &   �� 51   *   .�52   .   ��  � ��$ Center=�6e   53   +   56   #     57   "    .   . $ valor��6�    65   �� *ValorPuntos+ �� InstalledUICulture �� ConverterCulture# Z $ OneWay=� �� StringFormat$ 
{0:#,#.00}�� 58   &   �� 59   *   .�5:   .   ��  � ��$ Right=�6e   5;   +   5=   #     5?   "    .   . $ Monto��6�    65   �� *MontoContrato+# Z $ OneWay=�$ 
{0:#,#.00}�� 5@   &   �� 5A   *   .�5B   .   ��  � ��$ Right=�6e   5C   +   5E   #     5F   "    .   . $ FECHA��6�    65   �� *FechaCreacion+$ OneWay=�$ {0:dd-MM-yyyy}�� 5G   &   �� 5H   *   .�5I   .   ��  � ��$ Center=�6e   5J   +   5L   #     5M   "    .   . $ primer año��6�    65   �� *PrimerAnioUso+$ OneWay=� 5N   &   �� 5O   *   .�5P   .   ��  � ��$ Center=�6e   5Q   +   5S   #     5T   "    .   . $ CLiente��6�    65   �� *
cedula_rif+$ OneWay=� 5U   &   �� 5V   *   .�5W   .   ��  � ��$ Center=�6e   5X   +   5Z   #   5]      5^      5_      �� 5`      -   5        $ tbPuntosAnnio��5`      $��Puntos por año��61   .��5a      � ���	#FFE5E5E5$��0,0,0,28q�62   .+�5b        -   5        $ dtgrdPuntosPorAnio��5b   #    .  $��Stretch=�6[   $��Center=�6~    .  #��� ��6�    .  	 .  
 .  $��0,0,0,39q�6_  $ �� IsSynchronizedWithCurrentItem$ FalseY�6q   5c        5e   "    .   . $ N° Contrato��6�    65   �� *NroContrato+$ OneWay=� 5f   &   �� 5g   *   .�5h   .   ��  � ��$ Center=�6e   5i   +   5l   #     5n   "    .   . $
 Año��6�    65   �� *Anio+$ OneWay=� 5o   &   �� 5p   *   .�5q   .   ��  � ��$ Center=�6e   5r   +   5t   #     5u   "    .   . $ Puntos disponibles��6�    65   �� *PuntosNoConsumidos+$ TwoWay=�$ {0:F0}�� 5v   &   �� 5w   *   .�5x   .   ��  � ��$ Center=�6e   5y   +   5|   #     5}   "    .   .  $ Puntos Consumidos��6�    65   �� *PuntosConsumidos+$ OneWay=�$ {0:F0}�� 5~   &   �� 5   *   .�5�   .   ��  � ��$ center=�6e   5�   +   5�   #     5�   "    .   . $ Puntos por año��6�    65   �� *PuntosPorAnio+$ OneWay=�$ {0:F0}�� 5�   &   �� 5�   *   .�5�   .   ��  � ��$ center=�6e   5�   +   5�   #   5�      �� 5�      -   5         ��Name$ btnActualizar��5�   !   $��
Actualizar��68   $��Right=�6M   $��0,0,10,9q�6i   $��Bottom=�6{   $��75��6�   {�.  $��10(�6�   6�   5�      5�      5�      5�      �� 5�   
   -   5         ��Name$ 	lblcedula��5�      $��Cédula:��6$   $��6,74,0,0q�66   $	��Top=�6H   $
��Bold"�6`   $
��Left=�6r   $��68��6�    J� OpacityMask 5�      �� 5�       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5�      �  � Color$ Black��6#     � Offset$  0Q�61   � 5�      $ 	#FF6E2626��6#   $  1Q�65   5�      5�      �� 5�   
   -	   5        ! ��Name$! 	txtcedula��5�      $
��Left=�6%   $��23��6@   $��	83,75,0,0q�6L   " �� TextWrapping$
" Wrap=�6_   $	��Top=�6s   $	��120��6�   $��10(�6�   6�   �� 5�   
   -
   5        $ 
lblcliente��5�      $��Cliente��6$   $
��Left=�66   $��	39,43,0,0q�6Q   $	��Top=�6d   $��
ExtraBlack"�6|   $��14(�6�   �� 5�   
   -   5        $ lblcedula_Copy��5�      $��Nombre:��6)   $
��Left=�6;   $��
208,75,0,0q�6V   $	��Top=�6j   $
��Bold"�6�   }�.  5�      �� 5�      $ 0.5,1&�6&   $ 0.5,0&�67   .��5�      � $ Black��6#   $  0Q�61   � 5�      $ 	#FF6E2626��6#   $  1Q�65   5�      5�      �� 5�   
   -   5        $! 	txtnombre��5�      $
��Left=�6%   $��23��6@   $��
269,75,0,0q�6L   $
" Wrap=�6`   $�� ��6t   $	��Top=�6|   $	��273��6�   $��10(�6�   �� 5�   
   -   5        $ lblcedula_Copy1��5�      $��Nº Contrato:��6*   $
��Left=�6A   $��	5,104,0,0q�6\   $	��Top=�6o   $
��Bold"�6�   }�.  5�      �� 5�      $ 0.5,1&�6&   $ 0.5,0&�67   .��5�      � $ Black��6#   $  0Q�61   � 5�      $ 	#FF6E2626��6#   $  1Q�65   5�      5�      �� 5�   
   -   5        $! txtcontrato��5�      $
��Left=�6'   $��23��6B   $��
83,106,0,0q�6N   $
" Wrap=�6b   $�� ��6v   $	��Top=�6~   $	��120��6�   $��10(�6�   6�   �� 5�   
   -   5        $ 
btnGuardar��5�      $�� ��6%   $��Right=�60   $��	0,0,10,10q�6L   $��Bottom=�6_   $��32��6z   $ Guardar reserva��6�   {�.  ��5�      �� 5�      # �� ImageSource$ # Images/1353183085_save.png��6   $ j� Stretch$$ Uniform=�6F   5�      �� 5�   
   -   5        $ 	lbltitulo��5�      $�� ��6#   
�������$
��Bold"�6B   $��18(�6T   $��
347,2,21,0q�6b   $��Center=�6v   $��34��6�   $	��Top=�6�   5�      5�      