   M S B A M L   `   `   `  ����   Reservas    Reservas.nuevareserva   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008       N� Title$  Nueva reserva��$
��1164��$	��590��.���� $��0��$��Retales��$��0q����� .R�� $��Stretch=�$��Stretch=�.+���  ��Name$ 	lbltitulo��$��Nueva reserva��
�������$
��Bold"�$��16(�$	��5,0q�$
��Left=�$��Center=���  �� Orientation$ 
Horizontal=�$��Right=�.��� $��0,0,0,0q�.+��� -   $ 	lblcedula��$��Cédula/Rif:��$
��Left=�$��	36,46,0,0q�$	��Top=�$
��Bold"� J� OpacityMask ��  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ Black�� � Offset$ 0Q�� $ 	#FF6E2626��$ 1Q��� -    ��Name$ 	txtcedula��$
��Left=�$��23��$��
145,46,0,0q�	 �� TextWrapping$
	 Wrap=�$�� ��$	��Top=�$	��120���� -   $ 	lblNombre��$��Nombres /Razón:��$
��Left=�$��	37,72,0,0q�$	��Top=�$
��Bold"��� -   $ lblValorNombre��$�� ��$
��Left=�$��
145,72,0,0q�$	��Top=�
 J� RenderTransformOrigin$
 0.342,0.077&�$	��273���� -   $ lblDireccion��$��Dirección:��$
��Left=�$��	36,96,0,0q�$	��Top=�$
��Bold"�$��70���� -   $ lblValorDireccion��$�� ��$
��Left=�$��
112,96,0,0q�$	��Top=�$	��306��$��Stretch=��� -   $ lblTelefonos��$��Teléfonos:��$
��Left=�$��
37,121,0,0q�$	��Top=�$
 -0.711,0.231&�$��70��$
��Bold"��� -   $ lblValorTelefonos��$�� ��$
��Left=�$��163,121,0,0q�$	��Top=�$
 
-2.9,0.423&��� -	   $ lblEmail��$��Email:��$
��Left=�$��
38,147,0,0q�$	��Top=�$
 0.105,0.115&�$
��Bold"��� -
   $ lblValorEmail��$�� ��$
��Left=�$��163,147,0,0q�$	��Top=��� -   $ lblTotalPuntos��$��Total Puntos:��$
��Left=�$��
38,170,0,0q�$	��Top=�$
 	0.5,0.077&�$
��Bold"��� -   $ lblValorTotalPuntos��$�� ��$
��Left=�$��163,170,0,0q�$	��Top=��� -   $ lblPuntosConsumidos��$��Puntos Consumidos:��$
��Left=�$��
37,196,0,0q�$	��Top=�$	��128��$
��Bold"��� -   $ lblValorPuntosConsumidos��$�� ��$
��Left=�$��163,196,0,0q�$	��Top=�$
 	0.4,1.038&��� -   $ lblPuntosDisponibles��$��Puntos Disponibles:��$
��Left=�$��
37,222,0,0q�$	��Top=�$
��Bold"��� -   $ lblValorPuntosDisponibles��$�� ��$
��Left=�$��163,222,0,0q�$	��Top=�$
 -0.526,0.077&��� -   $ 
lblcliente��$��Cliente��$
��Left=�$��	77,15,0,0q�$	��Top=�$��
ExtraBlack"�$��14(��� -   $ lblcliente_Copy1��$��Reserva��$
��Left=�$��
77,242,0,0q�$	��Top=�$��
ExtraBlack"�$��14(�����  �� 
TargetType" �� �� BasedOn �� " ��.���  �� Property � ��   LabelTextBrush �� Value# �   (  "System.Windows.Controls.DatePicker  -     Name$ dpFechaI��$
��Left=�$��175,261,0,0q�$	��Top=�{�.    -   $ dpFechaF��$
��Left=�$��175,287,0,0q�$	��Top=�{�.  �� -   $ 	lblFechaI��$��Fecha inicio:��$
��Left=�$��
38,261,0,0q�$	��Top=�$
��Bold"�$��85���� -   $ 	lblFechaf��$��
Fecha fin:��$
��Left=�$��
38,290,0,0q�$	��Top=�$
��Bold"�$��85���� -   $ lblHotel��$��Hotel:��$
��Left=�$��
39,316,0,0q�$	��Top=�$
��Bold"�$��85���� -    ��Name$ lstHotel��$
��Left=�$��175,313,0,0q�$	��Top=�$	��168��{�.  �� -   $ lblHabitacion��$��Habitación:��$
��Left=�$��
39,344,0,0q�$	��Top=�$
��Bold"�$��85���� -   $ lstHabitacion��$
��Left=�$��175,341,0,0q�$	��Top=�$	��168��{�.  �� -   $ lblHabitacion_Copy��$��
Capacidad:��$
��Left=�$��
39,367,0,0q�$	��Top=�$
��Bold"�$��85���� -   $ lblValorCapacidad��$�� ��$
��Left=�$��178,367,0,0q�$	��Top=��� -   $ lblHabitacion_Copy1��$��	Personas:��$
��Left=�$��
39,393,0,0q�$	��Top=�$
��Bold"�$��70���� -   $ 
lstPersona��$
��Left=�$��175,393,0,0q�$	��Top=�$	��168��{�.  .@���  �� ContentStringFormat$  ��$��INFANTE(0 A 6 AÑOS)���� $  ��$��NIÑO(7 A 12 AÑOS)���� $  ��$��ADULTO���� -    ��Name$ tbContenedor��$
��Left=�$	��269��$��423,253,0,0q�$	��Top=�$	��485��.@��� -     ��Name$ 	tbPersona��$��Personas��.��� ���	#FFE5E5E5 � ColumnDefinitions �� $	��23* ��� $	��98* ��� $	��51* ��� $	��66* ��� $
��237* �.+�&   System.Windows.Controls.DataGrid  -!     Name$ 
dtgPersona��$
��Left=�$	��Top=�$	��210��$	��475��$��5�� J� IsHitTestVisible .     
IsReadOnly . �� -"   $ tbPuntos��$��Puntos��.��� ���	#FFE5E5E5.+�  -#   $ dtgPunto��$
��Left=�$	��Top=�$	��210��$	��475�� . $ �� IsSynchronizedWithCurrentItem$ FalseY��� -$   $ tbTodoIncluido��$��Todo incluido��{�.  .��� ���	#FFE5E5E5.+�  -%   $ dtgTodoIncluido��$
��Left=�$	��Top=�$	��210��$	��475�� . �� -&    ��Name$ 
btnAgregar��$��Agregar��$
��Left=�$��268,435,0,0q�$	��Top=�$��75��{�.  �� -'   $ lblcliente_Copy2��$��Resumen��$
��Left=�$��913,233,0,0q�$	��Top=�$��
ExtraBlack"�$��14(����� " �� �� " ��.���  � ��# �   �� -(   $ lblFechaI_Copy��$��Total puntos reserva:��$
��Left=�$��913,253,0,0q�$	��Top=�$
��Bold"�$	��142���� -)   $ lblFechaI_Copy1��$��Habitaciones actual:��$
��Left=�$��913,331,0,0q�$	��Top=�$
��Bold"�$	��142���� -*   $ lblValorPuntosReserva��$�� ��$
��Left=�$��1084,253,0,0q�$	��Top=�$
 	0.4,1.038&��� -+   $ btnAgregarHabitacion��$�� ��$
��Left=�$��
71,467,0,0q�$	��Top=�$��32�� � ToolTip$ Agregar otra habitación��{�.  ����  �� ImageSource$ Images/add.png�� j� Stretch$ Uniform=��� $�� ��$
��Left=�$��1099,497,0,0q�$	��Top=�$��32��$ Agregar otra habitación��{�.  ���� $  Images/1353183085_save.png��$ Uniform=��� -,   $ btnQuitarHabitacion��$�� ��$
��Left=�$��
34,467,0,0q�$	��Top=�$��32��$ Quitar habitación��{�.  ���� $ Images/list_remove.png��$ Uniform=��� --   $ lblHabitacionA��$��Habitación��$
��Left=�$��
34,435,0,0q�$	��Top=�$
��Bold"�$��83���� -.   $ 	lblHotelA��$��Hotel��$
��Left=�$��140,435,0,0q�$	��Top=�$
��Bold"�$��48��}�. �� -/   $ btnQuitarHotel��$�� ��$
��Left=�$��133,467,0,0q�$	��Top=�$��32��$ Agregar otra habitación��{�.  ���� $ Images/list_remove.png��$ Uniform=��� -0   $ btnAgregarHotel��$�� ��$
��Left=�$��170,467,0,0q�$	��Top=�$��32��$ Agregar otra habitación��{�.  ���� $ Images/add.png��$ Uniform=��� -1   $" lblValorCantidadHabitaciones��$�� ��$
��Left=�$��1084,331,0,0q�$	��Top=�$
 	0.4,1.038&��� $
��Left=�$��26��$��913,466,0,0q�$
	 Wrap=�$	��Top=�$	��189���� -2   $ lblobservaciones��$��Observaciones:��$
��Left=�$��913,435,0,0q�$	��Top=�$
��Bold"�$	��142��}�. �� -3   $ 
lbltotalbs��$��Total todo incluido Bs.:��$
��Left=�$��913,357,0,0q�$	��Top=�$
��Bold"�$	��142��}�. �� -4   $ lblPuntosAcelerados��$��Puntos acelerados:��$
��Left=�$��913,383,0,0q�$	��Top=�$
��Bold"�$	��111��}�. �� -5   $ lblValorTotalTodoIncluido��$�� ��$
��Left=�$��1084,357,0,0q�$	��Top=�$
 	0.4,1.038&��� -6   $ tbContenedor_Copy��$
��Left=�$	��213��$��
423,-2,0,0q�$	��Top=�$	��708��.@��� -7   $ tbContratos��$��	Contratos��.��� ���	#FFE5E5E5$��	0,0,0,-30q� �� $
��151* ��� $
��443* �.+�  -8   $ dtgrdContratos��$
��Left=�   AutoGenerateColumns .   �� AlternationCount$ 1��$	��Top=�$	��184��$	��698��   CanUserReorderColumns .      CanUserResizeColumns  .  !   CanUserAddRows! .  "   CanUserResizeRows" .  #   CanUserSortColumns# .  $. (Doble click para seleccionar un contrato��$$   HorizontalScrollBarVisibility$$ Disabled=�$��Center=�#��� ��$��2������ %   Columns% 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn&   CanUserResize& .  '   
IsReadOnly' . (   Header$( N° Contrato��1  +System.Windows.Controls.DataGridBoundColumn)   Binding) �� * �� Mode$* OneWay=�+ �� Path$+ NroContrato�,   	CellStyle, �� .���  � ��$ Center=�  & .  ' . $( tipo contrato��) �� $* OneWay=�$+ DescripcionTipoContrato�, �� .���  � ��$
 Left=�  & .  ' . $( puntos��) �� $* OneWay=�$+ puntos�, �� .���  � ��$ Center=�  & .  ' . $( valor��) �� $* OneWay=�$+ ValorPuntos�- �� StringFormat$- {0:F2}��, �� .���  � ��$ Right=�  & .  ' . $( Monto��) �� $* OneWay=�$+ MontoContrato�$- {0:F2}��, �� .���  � ��$ Right=�  & .  ' . $( FECHA��) �� $* OneWay=�$+ FechaProcesable�$- {0:dd-MM-yyyy}��, �� .���  � ��$ Center=�  & .  ' . $( primer año��) �� $* OneWay=�$+ PrimerAnioUso�, �� .���  � ��$ Center=��� -9   $ tbPuntosAnnio��$��Puntos por año��.��� ���	#FFE5E5E5.+�  -:   $ dtgrdPuntosPorAnio��$
��Left=�$	��Top=�$	��154��$	��698�� .  $��Stretch=�$��Center=� .  #��� ��%   & .  ' . $( N° Contrato��) �� $* OneWay=�$+ NroContrato�, �� .���  � ��$ Center=�  & .  ' . $
( Año��) �� $* OneWay=�$
+ Anio�, �� .���  � ��$ Center=�  & .  ' . $( Puntos no consumidos��) �� $* OneWay=�$+ PuntosNoConsumidos�$- {0:F0}��, �� .���  � ��$ Center=�  & .  ' . $( Puntos Consumidos��) �� $* OneWay=�$+ PuntosConsumidos�$- {0:F0}��, �� .���  � ��$ center=��� -;   $ btnCancelar��$�� ��$
��Left=�$��1062,497,0,0q�$	��Top=�$��32��$ Agregar otra habitación������ $ Images/boton-rojo.png��$ Uniform=��� -<   $ 	lbltitulo��$�� ��
�������$
��Bold"�$��18(�$��456,-41,0,543q�$
��Left=�$��Center=��� -=   $ lblFechaI_Copy2��$��Hoteles reserva:��$
��Left=�$��913,279,0,0q�$	��Top=�$
��Bold"�$	��111���� ->   $ lblValorHotelesreserva��$�� ��$
��Left=�$��1084,279,0,0q�$	��Top=�$
 	0.4,1.038&��� -?   $ lblFechaI_Copy3��$��Habitaciones reserva:��$
��Left=�$��913,305,0,0q�$	��Top=�$
��Bold"�$	��142���� -@   $ lblValortotalhabitaciones��$�� ��$
��Left=�$��1084,305,0,0q�$	��Top=�$
 	0.4,1.038&��� -A   $ lblValorPuntosacelerados��$�� ��$
��Left=�$��1084,383,0,0q�$	��Top=�$
 	0.4,1.038&��� -B   $ lblPuntosAcelerados_Copy��$"��Total puntos acelerados Bs.:��$
��Left=�$��913,409,0,0q�$	��Top=�$
��Bold"�$	��167��}�. �� -C   $ lblValorTotalacelerado��$�� ��$
��Left=�$��1084,409,0,0q�$	��Top=�$
 	0.4,1.038&�