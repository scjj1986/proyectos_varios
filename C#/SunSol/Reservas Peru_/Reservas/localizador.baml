   M S B A M L   `   `   `  ����g  cMicrosoft.ReportViewer.WinForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91tSclr-namespace:Microsoft.Reporting.WinForms;assembly=Microsoft.ReportViewer.WinFormsMicrosoft.Reporting.WinForms  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089M4clr-namespace:System.Globalization;assembly=mscorlibSystem.Globalization 5       Reservas   Reservas.localizador   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5      R	 NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml  	   5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006  	   5      brvSclr-namespace:Microsoft.Reporting.WinForms;assembly=Microsoft.ReportViewer.WinForms  	   5   	   @d2http://schemas.microsoft.com/expression/blend/2008  	   5      Cgl4clr-namespace:System.Globalization;assembly=mscorlib  	   5      -   5          N� Title$  localizador��5
      $
��auto��6   $
��auto��6$   .��5      � .+�5   
   �� $��0��6   $��Retales��6    $��
10,0,10,10q�61   ��5      �� 5      .R�5      � $��Stretch=�6   $��Stretch=�69   $��27��6U   .+�5      �� $��Localizadores��6    
�������$
��Bold"�6K   $��16(�6]   $��5,0,0,0q�6k   $
��Left=�5      $��Center=�6/   5      5      .��5      �� $��	0,0,11,10q�6   .@�5      �� $��Localizadores��6   .��5      �� $
��Auto=�6#   $
��Auto=�6H   .��5      � ���	#FFE5E5E5.+�5      � $��0,0,0,-7q�6   #��� ��61   .+�5      �� $��Nº Reserva:��6$   $
��Left=�6:   $��39,0,0,0q�6U   $	��Top=�6g   $
��Bold"�6   �� 5       $��Cliente:��6$   $
��Left=�67   $��	39,26,0,0q�6R   $	��Top=�6e    J� RenderTransformOrigin$ 0.158,-0.192&�6}   $
��Bold"�6�   �� 5!      -   5         ��Name$ txtNroReserva1��5!   &   $
��Left=�6>   $��23��6Y   $��	115,1,0,0q�6e    �� TextWrapping$
 Wrap=�6x   $	��Top=�6�   $	��120��6�   6�   �� 5"      -   5        $ txtCliente1��5"   &   $
��Left=�6;   $��23��6V   $��
115,26,0,0q�6b   $
 Wrap=�6v   $	��Top=�6�   $	��120��6�   6�   &   System.Windows.Controls.DataGrid  5#      -   5          Name$ dtgReservas1��5#   '   $��39,57,48,266q�6=      AutoGenerateColumns .     Columns 5$   "   0  *System.Windows.Controls.DataGridTextColumn  5&   &   ,  &System.Windows.Controls.DataGridColumn   CanUserResize .     
IsReadOnly . 	   Header$	 N° Reserva��6�   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 69   �� *	idreserva+ �� Mode$ OneWay=�   	CellStyle 5'   *   �� 5(   .   .�5)   2   ��  �� Property � �� �� Value$ Center=�6i   5*   /   5-   '     5/   &    .   . $	 Fecha Inicio��6�   
 69   �� *fechaI+$ OneWay=� �� StringFormat$ {0:dd-MM-yyyy}�� 50   *   �� 51   .   .�52   2   ��  � ��$ Center=�6i   53   /   55   '     56   &    .   . $	 	Fecha Fin��6�   
 69   �� *fechaF+$ OneWay=�$ {0:dd-MM-yyyy}�� 57   *   �� 58   .   .�59   2   ��  � ��$ Center=�6i   5:   /   5=   '     5>   &    .   . $	 noches��6�   
 69   �� *diasReserva+$ OneWay=�$ {0:F0}�� 5?   *   �� 5@   .   .�5A   2   ��  � ��$ Right=�6i   5B   /   5D   '     5F   &    .   . $	 puntos��6�   
 69   �� *puntos+$ OneWay=�$ {0:F0}�� 5G   *   �� 5H   .   .�5I   2   ��  � ��$ Right=�6i   5J   /   5L   '     5M   &    .   . $	 todo incluido Bs.��6�   
 69   �� *	montoTI+ �� InstalledUICulture �� ConverterCulture# Z $ OneWay=�$ 
{0:#,#.00}�� 5N   *   �� 5O   .   .�5P   2   ��  � ��$ Right=�6i   5Q   /   5S   '     5T   &    .   . $	 puntos acelerados��6�   
 69   �� *	puntosA+$ OneWay=�$ {0:F0}�� 5U   *   �� 5V   .   .�5W   2   ��  � ��$ Right=�6i   5X   /   5Z   '     5[   &    .   . $	 Monto acelerados bs.��6�   
 69   �� *	montoPA+# Z $ OneWay=�$ 
{0:#,#.00}�� 5\   *   �� 5]   .   .�5^   2   ��  � ��$ Right=�6i   5_   /   5a   '     5b   &    .   . $	 Fecha��6�   
 69   �� *fechaReserva+$ OneWay=�$ {0:dd-MM-yyyy}�� 5c   *   �� 5d   .   .�5e   2   ��  � ��$ Center=�6i   5f   /   5h   '     5i   &    .   . $	 localizador��6�   
 69   �� *localizador+$ OneWay=� 5j   *   �� 5k   .   .�5l   2   ��  � ��$ Center=�6i   5m   /   5o   '     5p   &    .   . $	 	total bs.��6�   
 69   �� *total+# Z $ OneWay=�$ 
{0:#,#.00}�� 5q   *   �� 5r   .   .�5s   2   ��  � ��$ Center=�6i   5t   /   5v   '     5w   &    .   . $	 contrato��6�   
 69   �� *NroContrato+$ OneWay=� 5x   *   �� 5y   .   .�5z   2   ��  � ��$
 Left=�6i   5{   /   5~   '     5   &    .   . $	 Reservado por��6�   
 69   �� *
creado_por+$ OneWay=� 5�   *   �� 5�   .   .�5�   2   ��  � ��$ Center=�6i   5�   /   5�   '   5�      (  "System.Windows.Controls.DatePicker  5�      -   5          Name$ dpfecha1��5�   )   $
��Left=�6;   $��	337,0,0,0q�6V   $	��Top=�6i   6�   �� 5�      $��Fecha:��6$   $
��Left=�65   $��	257,0,0,0q�6P   $	��Top=�6c   $
��Bold"�6{   �� 5�      -   5        $ txtNroContrato1��5�   &   $
��Left=�6?   $��23��6Z   $��
337,26,0,0q�6f   $
 Wrap=�6z   $	��Top=�6�   $	��143��6�   6�   �� 5�      $��Nº Contrato:��6$   $
��Left=�6;   $��
257,26,0,0q�6V   $	��Top=�6j   $
��Bold"�6�     5�      -   5        $ 
dtgdetalle��5�   '   $��39,221,48,126q�6;    .     CanUserReorderColumns .     CanUserResizeColumns .     CanUserResizeRows .     CanUserSortColumns .     CanUserDeleteRows .     CanUserAddRows .   5�   "     5�   &    .   . $	 hotel��6�   
 69   �� *Descripcion+$ OneWay=� 5�   *   �� 5�   .   .�5�   2   ��  � ��$
 Left=�6i   5�   /   5�   '     5�   &    .   . $	 habitación��6�   
 69   �� *Expr1+$ OneWay=� 5�   *   �� 5�   .   .�5�   2   ��  � ��$
 Left=�6i   5�   /   5�   '     5�   &    .   . $	 Entrada��6�   
 69   �� *	entrada+$ OneWay=�$ {0:dd-MM-yyyy}�� 5�   *   �� 5�   .   .�5�   2   ��  � ��$ Center=�6i   5�   /   5�   '     5�   &    .   . $	 salida��6�   
 69   �� *salida+$ OneWay=�$ {0:dd-MM-yyyy}�� 5�   *   �� 5�   .   .�5�   2   ��  � ��$ Center=�6i   5�   /   5�   '     5�   &    .   .  $	 localizador��6�   
 6<   �� *localizador+$ TwoWay=� 5�   *   �� 5�   .   .�5�   2   ��  � ��$ Center=�6i   �� 5�   2    � ��$ 	ExtraBold"�6Y   5�   /   5�   '   5�      �� 5�      -   5         ��Name$ btnGuardalocalizador��5�   %   $�� ��6C   $��Right=�6N   $��	0,0,10,10q�6j   $��Bottom=�6}   $��32��6�    � ToolTip$ Guardar cambios��6�   {�.  ��5�   "   �� 5�   &    �� ImageSource$  Images/1353183085_save.png��61    j� Stretch$ Uniform=�6Z   5�      �� 5�      -	   5        $ btnConfirmacion��5�   %   $�� ��6>   $��Right=�6I   $��	0,0,48,10q�6e   $��32��6x   $ Guardar cambios��6�   {�.  $ 
0.438,0.44&�6�   $��25��6�   $��Bottom=�6�   ��5�   "   �� 5�   &   $/ )icono/icono-de-la-impresora-azul-3148.png��61   $ Uniform=�6i   5�      �� 5�      $!��Observación confirmación:��6$   $
��Left=�6H   $��
39,365,0,0q�6c   $	��Top=�6w   $
��Bold"�6�   �� 5�      -
   5        $ txtObservacion��5�   &   $
��Left=�6>   $��59��6Y   $��205,365,0,0q�6e   $
 Wrap=�6z   $	��Top=�6�   $	��230��6�   5�      5�      5�      5�      5�      5�      5�      5�      