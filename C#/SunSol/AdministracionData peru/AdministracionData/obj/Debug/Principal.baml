   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089M4clr-namespace:System.Globalization;assembly=mscorlibSystem.Globalization  5       AdministracionData"   AdministracionData.Principal   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Cgl4clr-namespace:System.Globalization;assembly=mscorlib     5      T PMahApps.Metro, Version=1.3.0.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f;Controls,http://metro.mahapps.com/winfx/xaml/controls  5   	   :d2http://schemas.microsoft.com/expression/blend/2008  5   	   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  6F   -   5          � Title$(  "Sistema de Administración de data��5   	   $��784.5��63   $��1310.5��6B   (  "MahApps.Metro.Controls.MetroWindow    IsMaxRestoreButtonEnabled .   � WindowStartupLocation$ CenterScreen=�6s    � Icon$  imagenes/logo vacation.ico��6�    � WindowState$ 	Maximized=�6�   .��5	      � .+�5   
    � -   5          �Name$ frmContenido��5      $��61,10,10,29q�6&   $
��Auto=�6;   ��.   � NavigationUIVisibility$ Hidden=�6�   $
��auto��6�   �� 5   
   -   5         ��Name$ BtnMenu��5         AccentedSquareButtonStyle#��[  6#   $��	10,10,0,0q�6V   $
��Left=�6i   $��42��6�   $��32��6�   $	��Top=�6�    � ToolTip$ Nuevo cliente��6�   ��5      �� 5      	 �� ImageSource$	 imagenes/Menu.png��6   5      �� 5   
   $��1q�6     AccentColorBrush#���  6%   #  MahApps.Metro.Controls.Flyout  5   
   -   5        
  Name$
 flmenu��5      $	��Top=�6+   $��
10,26,0,29q�6C      Position$
 Left=�6W   $
��Left=�6g   $	��351��6�   .��5      � $	��Top=�6   $
��auto��6+   $
��auto��69   .+�5      �� -   5         ��Name$ lblFecha��5      $
��fgfg��6*   $��84,390,10,0q�69   $
��Bold"�6N   $��Right=�6`   $��32��6�   $	��Top=�6�   !  MahApps.Metro.Controls.Tile  5      -   5          Name$ 	tlUsuario��5   w   $��	38,38,0,0q�6       Title$ Usuarios��63   $
��Left=�6D   $	��Top=�6_   $��80��6�   $��82��6�   $��10(�6�      TitleFontSize$ 12Q�6�    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         ShadowDepth$ 9Q�6+      
BlurRadius$ 8Q�6;      Opacity$
 0.95Q�6J   .��5      �� $��imagenes/Users-WF.png��6   5        5      -   5        $ tlprospecto��5       $��
125,38,0,0q�65   $ 	Prospecto��6I   $	��Top=�6[   $
��Left=�6s   $��80��6�   $��82��6�   $��10(�6�   $ 12Q�6�    5        5       $ 9Q�6+   $ 8Q�6;   $
 0.95Q�6J   .��5"      �� $��imagenes/Cliente.png��6   5#        5$      -   5        $ 
tlAfiliado��5$       $��
212,38,0,0q�64   $ Afiliado��6H   $	��Top=�6Y   $
��Left=�6q   $��80��6�   $��82��6�   $ 12Q�6�    5%        5&      $ 9Q�6+   $ 8Q�6;   $
 0.95Q�6J   .��5(      �� $��imagenes/prospecto.png��6   5)        5*      -	   5        $ tlTelemarketing��5*       $��212,123,0,0q�69   $ Teleoperador��6N   $��82��6c   $	��Top=�6n   $
��Left=�6�   $(��"80                                ��6�   $ 10Q�6�    5+        5,      $ 9Q�6+   $ 8Q�6;   $
 0.95Q�6J   .��5.      �� $��imagenes/Tele.png��6   5/        50      -
   5        $ tlAsignacion��50       $��125,207,0,0q�66   $ Asignación��6K   $
��Left=�6^   $	��Top=�6y   $��80��6�   $	��169��6�   $ 12Q�6�    51        52      $ 9Q�6+   $ 8Q�6;   $
 0.95Q�6J   .��54      �� $��imagenes/cita.png��6   55        56      -   5        $ tlConfiguracion��56       $��212,292,0,0q�69   $ Configuración��6N   $
��Left=�6d   $	��Top=�6   $��80��6�   $��82��6�   $ 10Q�6�    57        58      $ 9Q�6+   $ 8Q�6;   $
 0.95Q�6J   .��5:      �� $ ��imagenes/configuracion.png��6   5;        5<      -   5        $ 
tlReportes��5<       $��
38,293,0,0q�64   $ Reportes��6H   $
��Left=�6Y   $	��Top=�6t   $��80��6�   $	��169��6�   $ 12Q�6�    5=        5>      $ 9Q�6+   $ 8Q�6;   $
 0.95Q�6J   .��5@      �� $��imagenes/reporte.png��6   5A        5B      -   5        $ 
tlLocacion��5B       $��
38,208,0,0q�64   $ 	Locación��6H   $	��Top=�6Y   $
��Left=�6q   $��80��6�   $��82��6�   $ 11Q�6�    5C        5D      $ 9Q�6+   $ 8Q�6;   $
 0.95Q�6J   .��5F      �� $��imagenes/locacion.png��6   5G        5I      -   5        $ tlpendiente��5I       $��	15,44,0,0q�65   $ 
Pendientes��6H   $	��Top=�6[   $
��Left=�6s   $��80��6�   $��82��6�   $y�Hidden=�6�   $ 11Q�6�    5J        5K      $ 9Q�6+   $ 8Q�6;   $
 0.95Q�6J   .��5M      �� $��imagenes/pendientes.png��6   5N      �� 5O      -   5        $ 	lblPerfil��5O      $
��fgfg��6+   $��	84,0,10,0q�6:   $
��Bold"�6M   $��Right=�6_   $��29��6�   $	��Top=�6�     5P      -   5        $ cerrarSesion��5P       $��38,1,0,0q�66   $
��Left=�6I   $	��Top=�6d   $��28��6|   $��41��6�   $ 12Q�6�    5Q        5R      $ 9Q�6+   $ 8Q�6;   $
 0.95Q�6J   .��5T      �� $��imagenes/quit.png��6   5U        5V      -   5        $ tlconfirmador��5V       $��
38,123,0,0q�67   $ Confirmador��6K   $	��Top=�6_   $
��Left=�6w   $��80��6�   $��82��6�   $��9(�6�   $ 10Q�6�    5W        5X      $ 9Q�6+   $ 8Q�6;   $
 0.95Q�6J   .��5Z      �� $��imagenes/supervisor.png��6   5[        5\      -   5        $ 
tlpromotor��5\       $��125,123,0,0q�64   $ Promotor��6I   $	��Top=�6Z   $
��Left=�6r   $��80��6�   $��82��6�   $��10(�6�   $ 12Q�6�    5]        5^      $ 9Q�6+   $ 8Q�6;   $
 0.95Q�6J   .��5`      �� $��imagenes/promotor.png��6   5a      5d      5f      �� 5g   
   $U��OTodos los derechos reservados SUNSOL VACATION powered by SOLUCIONES DE SISTEMAS��6   $��438,0,472,1q�6j   $��9(�6   $��Italic$�6�   $
��Bold"�6�   $	��392��6�   $��23��6�   $��Center=�6�   $��Bottom=�6�   $��Center=�6  5j      5k      