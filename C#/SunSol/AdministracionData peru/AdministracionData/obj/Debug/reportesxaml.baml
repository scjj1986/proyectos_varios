   M S B A M L   `   `   `  ����|  xSystem.Windows.Controls.DataVisualization.Toolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35�{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit2System.Windows.Controls.DataVisualization.Charting  5       AdministracionData%   AdministracionData.reportesxaml   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      T PMahApps.Metro, Version=1.3.0.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f;Controls,http://metro.mahapps.com/winfx/xaml/controls  5      �chartingToolkit{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit  5      9Custom,http://metro.mahapps.com/winfx/xaml/controls  5      -   5          N� Title$  reportesxaml��5
      $
��auto��6   $
��auto��6$   .��5      � $��0,0,0,10q�6   $
��Auto=�6   $
��Auto=�6O   .+�5   
   �� $��0��6   $��Retales��6    $��0,0,0,10q�61   ��5      �� 5      .R�5      � $��Stretch=�6   $��Stretch=�69   $��36��6U   .+�5      �� $��Reportes��6    
�������$
��Bold"�6F   $��16(�6X   $��5,0,0,0q�6f   $
��Left=�5      $��Center=�6#   5      5      5      �� 5   
   $��0,51,0,0q�6   .@�5      �� $
��Data��6   .��5      � .+�5       �� -   5         ��Name$ 	cmbStatus��5       $��30��62   *  $MahApps.Metro.Controls.TextBoxHelper   UseFloatingWatermark .    	Watermark$ Estatus��5#      {�.  �� Text$  ��5$   #   $��8(�6+   $	��165��68   $
��Left=�6D   $	��Top=�6_   $��
404,10,0,0q�6w   6�   �� 5%      -   5        $ cmbStatusPrincipal��5%      $��	10,10,0,0q�6;   $��30��6N    . $ Estatus principal��5(      {�. $  ��5)   #   $��8(�6+   $	��141��68   $
��Left=�6D   $	��Top=�6_   6w   &   System.Windows.Controls.DataGrid  5,      -   5          Name$ dtgrdclientes��5,         AutoGenerateColumns .   �� AlternationCount$ 1��6k      CanUserReorderColumns .  	   CanUserResizeColumns	 .  
   CanUserAddRows
 .     CanUserResizeRows .     CanUserSortColumns .   � ToolTip$- 'Doble click para seleccionar un cliente��6  $   HorizontalScrollBarVisibility$ Disabled=�69  $��Center=�6b     AreRowDetailsFrozen . $��10,53,10,88q�6�  $��2��6�  ��67   ��    Columns 5-      0  *System.Windows.Controls.DataGridTextColumn  5.      ,  &System.Windows.Controls.DataGridColumn   CanUserResize .     
IsReadOnly .    Header$ N° documento��6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *documento_identidad+ �� Mode$ OneWay=�   	CellStyle 5/   "   �� 50   &   .�51   *   ��  �� Property � �� �� Value$
 Left=�6a   52   '   54        55       .   . $ nombre��6�    61   �� *nombre+$ OneWay=� 56   "   �� 57   &   .�58   *   ��  � ��$
 Left=�6a   59   '   5;        5<       .   . $ Apellido��6�    61   �� *
apellido+$ OneWay=� 5=   "   �� 5>   &   .�5?   *   ��  � ��$
 Left=�6a   5@   '   5B        5C       .   . $ 
dirección��6�    61   �� *	direccion+$ OneWay=� 5D   "   �� 5E   &   .�5F   *   ��  � ��$
 Left=�6a   5G   '   5I        5J       .   . $ Telf. habitación��6�    61   �� *t_habitacion+$ OneWay=� 5K   "   �� 5L   &   .�5M   *   ��  � ��$ Right=�6a   5N   '   5P        5Q       .   . $ Telf. celular��6�    61   �� *	t_celular+$ OneWay=� 5R   "   �� 5S   &   .�5T   *   ��  � ��$ Right=�6a   5U   '   5W        5X       .   . $ Telf. oficina��6�    61   �� *	t_oficina+$ OneWay=� 5Y   "   �� 5Z   &   .�5[   *   ��  � ��$ Right=�6a   5\   '   5^        5_       .   . $ correo��6�    61   �� *correo+$ OneWay=� 5`   "   �� 5a   &   .�5b   *   ��  � ��$
 Left=�6a   5c   '   5e        5f       .   . $ 	locación��6�    61   �� *C_Locacion.codigo+$ OneWay=� 5g   "   �� 5h   &   .�5i   *   ��  � ��$ Center=�6a   5j   '   5l        5m       .   . $ 
profesión��6�    61   �� *	profesion+$ OneWay=� 5n   "   �� 5o   &   .�5p   *   ��  � ��$
 Left=�6a   5q   '   5s        5t       .   . $
 edad��6�    61   �� *edad+$ OneWay=� 5u   "   �� 5v   &   .�5w   *   ��  � ��$ Center=�6a   5x   '   5z        5{       .   . $ 
edo. civil��6�    61   �� *	edo_civil+$ OneWay=� 5|   "   �� 5}   &   .�5~   *   ��  � ��$
 Left=�6a   5   '   5�        5�       .   . $ 
f. ingreso��6�    61   �� *f_nacimiento+$ OneWay=� �� StringFormat$ {0:dd-MM-yyyy}�� 5�   "   �� 5�   &   .�5�   *   ��  � ��$ Center=�6a   5�   '   5�        5�       .   . $ Status��6�    61   �� *C_Status.descripcion+$ OneWay=� 5�   "   �� 5�   &   .�5�   *   ��  � ��$
 Left=�6a   5�   '   5�      5�      �� 5�      -   5         ��Name$ btnImprimirRClientes��5�      $��Imprimir��6;   $��	0,0,10,10q�6N   $��25��6a   $��Bottom=�6m   $��Right=�6�   $��75��6�   $��1��6�   6�   (  "System.Windows.Controls.DatePicker  5�      -   5          Name$ dpFechaDesdeD��5�   !   $
��Left=�68   $	��Top=�6S   $��30��6k   $	��137��6w   {�.  . $ Fecha ingreso desde��5�         Text$  ��5�      $��8(�6   $��
593,10,0,0q�6+   6?     5�      -   5        $ dpFechaHastaD��5�   !   $
��Left=�68   $	��Top=�6S   $��30��6k   $	��137��6w   {�.  . $ Fecha ingreso hasta��5�      $  ��5�      $��8(�6   $��
750,10,0,0q�6+   6?   �� 5�      -   5        $ cmbLocacion��5�      $��
172,10,0,0q�64   $��30��6H    . $ Locación / Campaña��5�      {�. $  ��5�   '   $��8(�6/   $	��213��6<   $
��Left=�6H   $	��Top=�6c   $��2��6{   5�      5�      �� 5�      $��Asignaciones��6   .��5�      � .+�5�        -	   5        $ dtgrdclientesAsig��5�       .  $ 1��6o    .  	 .  
 .   .   .  $- 'Doble click para seleccionar un cliente��6  $ Disabled=�6=  $��Center=�6f   . $��10,62,31,64q�6�  ��6;   ��  5�        5�       .   . $ N° documento��6�    61   �� *documento_identidad+$ OneWay=� 5�   "   �� 5�   &   .�5�   *   ��  � ��$
 Left=�6a   5�   '   5�        5�       .   . $ nombre��6�    61   �� *nombre+$ OneWay=� 5�   "   �� 5�   &   .�5�   *   ��  � ��$
 Left=�6a   5�   '   5�        5�       .   . $ Apellido��6�    61   �� *
apellido+$ OneWay=� 5�   "   �� 5�   &   .�5�   *   ��  � ��$
 Left=�6a   5�   '   5�        5�       .   . $ 
dirección��6�    61   �� *	direccion+$ OneWay=� 5�   "   �� 5�   &   .�5�   *   ��  � ��$
 Left=�6a   5�   '   5�        5�       .   . $ Telf. habitación��6�    61   �� *t_habitacion+$ OneWay=� 5�   "   �� 5�   &   .�5�   *   ��  � ��$ Right=�6a   5�   '   5�        5�       .   . $ Telf. celular��6�    61   �� *	t_celular+$ OneWay=� 5�   "   �� 5�   &   .�5�   *   ��  � ��$ Right=�6a   5�   '   5�        5�       .   . $ Telf. oficina��6�    61   �� *	t_oficina+$ OneWay=� 5�   "   �� 5�   &   .�5�   *   ��  � ��$ Right=�6a   5�   '   5�        5�       .   . $ correo��6�    61   �� *correo+$ OneWay=� 5�   "   �� 5�   &   .�5�   *   ��  � ��$
 Left=�6a   5�   '   5�        5�       .   . $ 	locación��6�    61   �� *C_Locacion.codigo+$ OneWay=� 5�   "   �� 5�   &   .�5�   *   ��  � ��$ Center=�6a   5�   '   5�        5�       .   . $ 
profesión��6�    61   �� *	profesion+$ OneWay=� 5�   "   �� 5�   &   .�5�   *   ��  � ��$
 Left=�6a   5�   '   5�        5�       .   . $
 edad��6�    61   �� *edad+$ OneWay=� 5�   "   �� 5�   &   .�5�   *   ��  � ��$ Center=�6a   5�   '   5�        5�       .   . $ 
edo. civil��6�    61   �� *	edo_civil+$ OneWay=� 5�   "   �� 5�   &   .�5�   *   ��  � ��$
 Left=�6a   5�   '   5�        5�       .   . $ 
F. ingreso��6�    61   �� *f_nacimiento+$ OneWay=�$ {0:dd-MM-yyyy}�� 5�   "   �� 5   &   .�5  *   ��  � ��$ Center=�6a   5  '   5       5      .   . $ Status��6�    61   �� *C_Status.descripcion+$ OneWay=� 5  "   �� 5  &   .�5	  *   ��  � ��$
 Left=�6a   5
  '   5     5     �� 5     -
   5        $ btnImprimirRAsig��5     $��Imprimir��67   $��	0,0,10,10q�6J   $��25��6]   $��Bottom=�6i   $��Right=�6�   $��75��6�   $��1��6�   6�   �� 5     -   5        $ cmbTelemarketing��5     $��	10,10,0,0q�69   $��38��6L    . $ Teleoperador��5     {�. $  ��5  '   $��11(�6/   $	��389��6=   $
��Left=�6I   $	��Top=�6d     5     -   5        $ dpFechaDesde��5  !   $
��Left=�67   $	��Top=�6R   $��38��6j   $	��137��6v   {�.  . $ Fecha desde��5     $  ��5     $��11(�6   $��
430,10,0,0q�6,   6@     5     -   5        $ dpFechaHasta��5  !   $
��Left=�67   $	��Top=�6R   $��38��6j   $	��127��6v   {�.  . $ Fecha hasta��5     $  ��5     $��11(�6   $��
605,10,0,0q�6,   6@   5     5      �� 5!     $��	Historial��6   $
��Left=�6)   $��39��6D   $	��Top=�6P   $	��115��6h   $��	0,0,-10,0q�6t   .��5"     � .+�5#     �� -   5         ��Name$ 	txtCedula��5#     $��	10,10,0,0q�61   $��38��6D    . $ Documento de identidad��5&     {�. $�� ��5'     $��11(�6$   $	��266��62   $
��Left=�6>   $	��Top=�6Y   6q   �� 5(     -   5        $ txtTelefono��5(     $��
301,10,0,0q�63   $��38��6G    . $ 
Teléfonos��5+     {�. $�� ��5,     $��11(�6$   $	��266��62   $
��Left=�6>   $	��Top=�6Y   6q     5.     -   5        $ dtgrdclientesHis��5.      .  $ 1��6n    .  	 .  
 .   .   .  $- 'Doble click para seleccionar un cliente��6
  $ Disabled=�6<  $��Center=�6e  $��
10,53,10,0q�6�   . $��10(�6�  ��6:   ��  5/       50      .   . $ N° documento��6�    61   �� *documento_identidad+$ OneWay=� 51  "   �� 52  &   .�53  *   ��  � ��$
 Left=�6a   54  '   56       57      .   . $ nombre��6�    61   �� *nombre+$ OneWay=� 58  "   �� 59  &   .�5:  *   ��  � ��$
 Left=�6a   5;  '   5=       5>      .   . $ Apellido��6�    61   �� *
apellido+$ OneWay=� 5?  "   �� 5@  &   .�5A  *   ��  � ��$
 Left=�6a   5B  '   5D       5E      .   . $ 
dirección��6�    61   �� *	direccion+$ OneWay=� 5F  "   �� 5G  &   .�5H  *   ��  � ��$
 Left=�6a   5I  '   5K       5L      .   . $ Telf. habitación��6�    61   �� *t_habitacion+$ OneWay=� 5M  "   �� 5N  &   .�5O  *   ��  � ��$ Right=�6a   5P  '   5R       5S      .   . $ Telf. celular��6�    61   �� *	t_celular+$ OneWay=� 5T  "   �� 5U  &   .�5V  *   ��  � ��$ Right=�6a   5W  '   5Y       5Z      .   . $ Telf. oficina��6�    61   �� *	t_oficina+$ OneWay=� 5[  "   �� 5\  &   .�5]  *   ��  � ��$ Right=�6a   5^  '   5`       5a      .   . $ correo��6�    61   �� *correo+$ OneWay=� 5b  "   �� 5c  &   .�5d  *   ��  � ��$
 Left=�6a   5e  '   5g       5h      .   . $ 	locación��6�    61   �� *C_Locacion.codigo+$ OneWay=� 5i  "   �� 5j  &   .�5k  *   ��  � ��$ Center=�6a   5l  '   5n       5o      .   . $ 
profesión��6�    61   �� *	profesion+$ OneWay=� 5p  "   �� 5q  &   .�5r  *   ��  � ��$
 Left=�6a   5s  '   5u       5v      .   . $
 edad��6�    61   �� *edad+$ OneWay=� 5w  "   �� 5x  &   .�5y  *   ��  � ��$ Center=�6a   5z  '   5|       5}      .   . $ 
edo. civil��6�    61   �� *	edo_civil+$ OneWay=� 5~  "   �� 5  &   .�5�  *   ��  � ��$
 Left=�6a   5�  '   5�       5�      .   . $ 
f. ingreso��6�    61   �� *f_nacimiento+$ OneWay=�$ {0:dd-MM-yyyy}�� 5�  "   �� 5�  &   .�5�  *   ��  � ��$ Center=�6a   5�  '   5�     5�     5�     5�     5�     5�     5�     