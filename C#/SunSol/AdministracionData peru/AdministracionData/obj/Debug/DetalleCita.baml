   M S B A M L   `   `   `  ����  AdministracionData$    AdministracionData.DetalleCita   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   T PMahApps.Metro, Version=1.3.0.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f;Controls,http://metro.mahapps.com/winfx/xaml/controls  5   
   -   5          � Title$  Detalle Cita��5   	   $	��600��6   $	��600��6+    � WindowStartupLocation$ CenterScreen=�67   .��5      � .+�5   
   �� -   5         ��Name$ txtobservacion��5      $��	38,21,0,0q�6*   *  $MahApps.Metro.Controls.TextBoxHelper   UseFloatingWatermark .    	Watermark$ Observaciones��5	      {�. $�� ��5
      $��11(�6    $	��500��6.   $
��Left=�6:    �� MinLines$ 2��6z   $��87��6�   $	��Top=�6�   �� 5   
   -   5        $ txtVeces��5      $��
38,108,0,0q�6$   $��38��68    . $% Cantidad de intentos de llamada��5   
   {�. $�� ��5      $��11(�6#   $	��500��61   $
��Left=�6=   $	��Top=�6X   6p   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ 
dpFechaNac��5      $��
38,146,0,0q�6)   $��38��6=    . $ Fecha��5   
   {�.    Text$  ��5      $��11(�6#   $	��500��61   $
��Left=�6=   $	��Top=�6X      DisplayDateStart$ 
1930-01-01X�6p   *  $MahApps.Metro.Controls.NumericUpDown  5   
   -   5        	  Name$
	 hora��5   c   
   Minimum$
 0Q�6!      Maximum$ 23Q�6.      Interval$ 1Q�6=   $��38,184,419,0q�6M    . $
 Hora��5      $��35��6F   $	��Top=�6R   !  MahApps.Metro.Controls.Tile  5   
   -   5          Name$ 	tlGuardar��5      $��52��6,   $��
0,0,10,245q�68   $��58��6L   $��Bottom=�6W   $��Right=�6r    � ToolTip$ Guardar��6�    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 8Q�6#      Opacity$
 0.95Q�62      ShadowDepth$ 9Q�6A   .��5      �� $��imagenes/guardar.png��6   $��48��62   5        5   
   -   5        $		 min��5   e   $
 0Q�6!   $ 59Q�6.   $ 15Q�6=   $��150,184,307,0q�6N    . $	 Min��5!   
   $��35��61   $	��Top=�6=   �� 5"   
   -   5         ��Name$ txtTeleOperador��5"      $��
38,219,0,0q�6,   $��38��6@    . $ Teleoperador��5%   
   {�.  �� Text$  ��5&      $��11(�6#   $	��500��61   $
��Left=�6=   $	��Top=�6X   6p   &   System.Windows.Controls.DataGrid  5'   
   -	   5          Name$ dtgrdetalle��5'         AutoGenerateColumns .   �� AlternationCount$ 1��6^      CanUserReorderColumns .     CanUserResizeColumns .     CanUserAddRows .     CanUserResizeRows .     CanUserSortColumns .  $- 'Doble click para seleccionar un cliente��6�   $��Center=�6,  $��10,330,10,10q�6P     AreRowDetailsFrozen . $��10(�6�  ��6*   ��    Columns 5(      0  *System.Windows.Controls.DataGridTextColumn  5)      ,  &System.Windows.Controls.DataGridColumn   CanUserResize .      
IsReadOnly  . !   Header$! fecha��6u   1	  +System.Windows.Controls.DataGridBoundColumn" 	  Binding" 6%   �� *fecha+# �� Mode$# OneWay=�$   	CellStyle$ 5*      �� 5+      .�5,      �� % �� Property% � ��& �� Value$
& Left=�6U   5-      5/        50       .    . $! observación��6{   " 6%   �� *observacion+$# OneWay=�$ 51      �� 52      .�53      �� % � ��$
& Left=�6U   54      56        57       .    . $! veces��6u   " 6%   �� *veces+$# OneWay=�$ 58      �� 59      .�5:      �� % � ��$
& Left=�6U   5;      5=        5>       .    . $
! hora��6t   " 6%   �� *hora+$# OneWay=�$ 5?      �� 5@      .�5A      �� % � ��$
& Left=�6U   5B      5D        5E       .    . $! Teleoperador��6|   " 6%   �� *teleoperador+$# OneWay=�$ 5F      �� 5G      .�5H      �� % � ��$& Right=�6U   5I      5K      5O      5P      5Q      