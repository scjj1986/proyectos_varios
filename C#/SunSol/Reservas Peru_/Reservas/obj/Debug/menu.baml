   M S B A M L   `   `   `  ����  Reservas    Reservas.menu   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   T PMahApps.Metro, Version=1.3.0.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f;Controls,http://metro.mahapps.com/winfx/xaml/controls  5   	   -   5        (  "MahApps.Metro.Controls.MetroWindow   Name$  VtnPrincipal��5       � Title$= 7Módulo de Reservaciones para contratos SUNSOL VACATION��5   	   $
��auto��6H   $
��auto��6V       IsMaxRestoreButtonEnabled .   � WindowStartupLocation$ CenterScreen=�6�    � Icon$ icono/logo vacation.png��6�   *   #WindowButtonCommandsOverlayBehavior$ Never=�6�      ShowCloseButton .     IsCloseButtonEnabled .     WindowTransitionsEnabled .  	 � WindowState$	 	Maximized=�6�  $��Disabled=�6�  
   ShowMaxRestoreButton
 .  .��5      � $��0,0,-2,1q�6   .+�5	   
   �� $��0��6   $��Retales��6    $��0q�61   $
��auto��6<   ��5
      �� 5      .R�5      � $��Stretch=�6   $��Stretch=�69   .+�5      �� $��Menú principal��6    
�������$
��Bold"�6L   $��16(�6^   $	��5,0q�6l   $
��Left=�5       $��Center=�6;   �� 5       �� Orientation$ 
Horizontal=�6%   $��Right=�6>   .+�5      ��  ��Name$ 	btnCerrar��6%   -   5        $��30��5   8   $��30��6C   $��0q�6O      MetroCircleButtonStyle#���   6Z    � ToolTip$ Cerrar sesión��6�   ��5   "   �� 5   &    �� ImageSource$% Images/imgModalUserLoginOut.png��61    j� Stretch$ Uniform=�6_   .��5   "   �� $��20��6,   $��20��67   ��5   ,   ��  �� Path$ 
Foreground� �� RelativeSource �� *FindAncestor+ �� AncestorType" �� J� OpacityMask 5   &   !� 5   *   $
 Fill=�66   5   #   5      �� 5      $ btnSalir��6%   -   5        $��30��5   7   $��30��6B   $��0q�6N   #���   6Y   $ Salir del sistema��6�   ��5   "   �� 5   &   $ Images/quit.png��61   $ Uniform=�6O   .��5    "   �� $��20��6,   $��20��67   ��5!   ,   �� $ 
Foreground� �� *FindAncestor+" �� 5"   &   !� 5#   *   $
 Fill=�66   5%   #   5&      5'      5*      5,      .��5.      �� $U��OTodos los derechos reservados SUNSOL VACATION powered by SOLUCIONES DE SISTEMAS��6   $��181,0,177,-10q�6n   $��9(�6�   $��Italic$�6�   $
��Bold"�6�   $	��392��6�   $��23��6�   $��Center=�6�   $��Bottom=�6�   $��Center=�6  5/       � 50   
   -   5          �Name$ frmContenido��50      $��10,97,10,29q�6&   $
��Auto=�6;   ��.   � NavigationUIVisibility$ Hidden=�6�   $
��auto��6�   �� 52   
   -   5        $ btnModificarReserva��52      $��	54,47,0,0q�6.   #���   6A   $ Modificar Reserva��6r   $
��Left=�6�   $��40��6�   $��40��6�   $	��Top=�6�   ��53      �� 54      $! icono/editnote_edi_9512.png��6   $ Uniform=�6G   .��56      �� $��20��6   $��20��6#   ��57      �� *
Foreground+ �� *FindAncestor+" �� 58      !� 59      $
 Fill=�6"   5;      5<      �� 5>   
   -   5        $ btnReportes��5>      $��40��6&   $��
184,47,0,0q�62   #���   6F   $ Reportes��6w   $	��Top=�6�   $
��Left=�6�   $��40��6�   ��5?      �� 5@      $/ )icono/icono-de-la-impresora-azul-3148.png��6   $ Uniform=�6U   .��5B      �� $��20��6   $��20��6#   ��5C      �� *
Foreground+ �� *FindAncestor+" �� 5D      !� 5E      $
 Fill=�6"   5G      5H      �� 5J   
   -   5        $ 
btnLimpiar��5J      $��
319,47,0,0q�6%   #���   69   $ Cerrar ventanas��6j   $��40��6�   $	��Top=�6�   $
��Left=�6�   $��40��6�   ��5K      �� 5L      $ Images/undo.png��6   $ Uniform=�6;   .��5N      �� $��20��6   $��20��6#   ��5O      �� *
Foreground+ �� *FindAncestor+" �� 5P      !� 5Q      $
 Fill=�6"   5S      5T      �� 5U   
   -   5        $ btnConfiguracion��5U      $��
274,47,0,0q�6+   #���   6?   $ Configuración��6p   $
��Left=�6�   $��40��6�   $��40��6�   $	��Top=�6�   ��5V      �� 5W      $ icono/herramientas.png��6   $ Uniform=�6B   .��5Y      �� $��20��6   $��20��6#   ��5Z      �� *
Foreground+ �� *FindAncestor+" �� 5[      !� 5\      $
 Fill=�6"   5^      5_      �� 5`   
   -	   5        $ btnNuevaReserva��5`      #���   6*   $ Nueva reserva��6y   $��	10,47,0,0q�6�   $��40��6�   $	��Top=�6�   $
��Left=�6�   $��40��6�   ��5a      �� 5b      $ icono/other.png��6   $ Uniform=�6;   .��5d      �� $��20��6   $��20��6#   ��5e      �� *
Foreground+ �� *FindAncestor+" �� 5f      !� 5g      $
 Fill=�6"   5i      5j      �� 5k   
   $��icono/man_icon.png��6   $��
0,47,220,0q�6,   $��50��6@   $	��Top=�6L   $��Right=�6d   $��50��6�   �� 5l   
   -
   5         ��Name$ lblUser��5l      $��hh��6!   $��0,70,28,409q�6.   $
��Bold"�6C   $��Right=�6U   $	��187��6q   �� 5m   
   -   5        $ lblFecha��5m      $��hh��6"   $��0,47,18,435q�6/   $��Light"�6D   $��Right=�6W   $	��197��6s   �� 5n   
   -   5        $ btnPagos��5n      $��	94,47,0,0q�6#   #���   66   $ Pagos reserva��6g   $
��Left=�6�   $��40��6�   $��40��6�   $	��Top=�6�   ��5o      �� 5p      $ icono/pagos (1).png��6   $ Uniform=�6?   .��5r      �� $��20��6   $��20��6#   ��5s      �� *
Foreground+ �� *FindAncestor+" �� 5t      !� 5u      $
 Fill=�6"   5w      5x      �� 5y   
   -   5        $ btnLocalizador��5y      $��
139,47,0,0q�6)   #���   6=   $ Localizador��6n   $
��Left=�6�   $��40��6�   $��40��6�   $	��Top=�6�   ��5z      �� 5{      $ icono/localizador.png��6   $ Uniform=�6A   5}      �� 5~   
   -   5        $ btnPuntosDisponibles��5~      $��
229,47,0,0q�6/   #���   6C   $! Puntos disponibles contrato��6t   $
��Left=�6�   $��40��6�   $��40��6�   $	��Top=�6�   ��5      �� 5�      $ icono/disponible.png��6   $ Uniform=�6@   .��5�      �� $��20��6   $��20��6#   ��5�      �� *
Foreground+ �� *FindAncestor+" �� 5�      !� 5�      $
 Fill=�6"   5�      5�      5�      5�      