   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089M4clr-namespace:System.Globalization;assembly=mscorlibSystem.Globalization  5   
    AL   ALegal.Principal   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Cgl4clr-namespace:System.Globalization;assembly=mscorlib     5   
   U QMahApps.Metro, Version=1.5.0.23, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f;Controls,http://metro.mahapps.com/winfx/xaml/controls  5   	   :d2http://schemas.microsoft.com/expression/blend/2008  5   	   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  6F   -   5          � Title$  SISTEMA ÁREA LEGAL��5	      $
��auto��6   $
��auto��6+   (  "MahApps.Metro.Controls.MetroWindow    IsMaxRestoreButtonEnabled .   � WindowStartupLocation$ CenterScreen=�6Z    � Icon$ imagenes/sunsol isla.png��6    � WindowState$ 	Maximized=�6�    � 
ResizeMode$ CanResizeWithGrip=�6�   .��5      � $��0,0,-2,1q�6   .+�5   
   �� $��0��6   $��Retales��6    $��0q�61   $
��auto��6<   ��5      �� 5      .R�5      � $��Stretch=�6   $��Stretch=�69   .+�5      �� $��Menú Principal��6    
�������$
��Bold"�6L   $��16(�6^   $	��5,0q�6l   $
��Left=�5       $��Center=�6;   �� 5       �� Orientation$ 
Horizontal=�6%   $��Right=�6>   .+�5      ��  ��Name$ 	btnCerrar��6%   -   5        $��30��5   8   $��30��6C   $��0q�6O      MetroCircleButtonStyle#���   6Z    � ToolTip$ Cerrar sesión��6�   ��5   "   �� 5   &   	 �� ImageSource$%	 Images/imgModalUserLoginOut.png��61   
 j� Stretch$
 Uniform=�6_   .��5   "   �� $��20��6,   $��20��67   ��5   ,   ��  �� Path$ 
Foreground� �� RelativeSource �� *FindAncestor+ �� AncestorType" �� J� OpacityMask 5   &   !� 5   *   $

 Fill=�66   5   #   5       �� 5!      $ btnSalir��6%   -   5        $��30��5!   7   $��30��6B   $��0q�6N   #���   6Y   $ Salir del sistema��6�   ��5"   "   �� 5#   &   $	 Images/quit.png��61   $
 Uniform=�6O   .��5%   "   �� $��20��6,   $��20��67   ��5&   ,   �� $ 
Foreground� �� *FindAncestor+" �� 5'   &   !� 5(   *   $

 Fill=�66   5*   #   5+      5-      5.      50      .��52      �� $2��,Todos los derechos reservados Sistema Sunsol��6   $��268,0,279,-10q�6K   $��9(�6b   $��Italic$�6o   $
��Bold"�6�   $	��203��6�   $��Center=�6�   $��Center=�6�   $��23��6�   $��Bottom=�6�   53       � 54   
   -   5          �Name$ frmContenido��54      $��5,108,15,18q�6&   $
��Auto=�6;   ��.   � NavigationUIVisibility$ Hidden=�6�   $
��auto��6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   z�55      V� 56      .~�57      �� �� 58      �� 59       �� Angle$ -0.079Q�6&   T� 5:      5;      5=      �� 5?   
   -   5        $ 	tlEmpresa��5?      #���   6%   $ Empresas��6V   $��	10,47,0,0q�6i   $��60��6|   $	��Top=�6�   $
��Left=�6�   $��60��6�   ��5@      �� 5A      $	 imagenes/empresa.png��6   $
 Uniform=�6@   .��5C      �� $��50��6   $��50��6#   ��5D      �� *
Foreground+ �� *FindAncestor+" �� 5E      !� 5F      $

 Fill=�6"   5H      5I      �� 5K   
   -   5        $ tlPerm��5K      #���   6"   $ Permisologías��6S   $��	70,47,0,0q�6k   $��60��6~   $	��Top=�6�   $
��Left=�6�   $��60��6�   ��5L      �� 5M      $	 imagenes/Keys.png��6   $
 Uniform=�6=   .��5O      �� $��50��6   $��50��6#   ��5P      �� *
Foreground+ �� *FindAncestor+" �� 5Q      !� 5R      $

 Fill=�6"   5T      5U      �� 5W   
   -   5        $ 	tlUsuario��5W      #���   6=   $ Usuarios��6n   $��
0,47,313,0q�6�   $��60��6�   $	��Top=�6�   $��Right=�6�   $��60��6�   ��5X      �� 5Y      $	 imagenes/users.png��6   $
 Uniform=�6>   .��5[      �� $��50��6   $��50��6#   ��5\      �� *
Foreground+ �� *FindAncestor+" �� 5]      !� 5^      $

 Fill=�6"   5`      5a      �� 5b   
   $��icono/man_icon.png��6   $��
0,47,231,0q�6,   $��60��6@   $	��Top=�6L   $��Right=�6d   $��65��6�   �� 5d   
   -   5         ��Name$ 	lblPerfil��5d      $��hh��6#   $��0,83,8,0q�60   $
��Bold"�6B   $��22��6T   $��10(�6`   $	��Top=�6o   $��Right=�6�   $	��200��6�   �� 5e   
   -	   5        $ lblUser��5e      $��hh��6!   $��0,65,8,0q�6.   $
��Bold"�6@   $��25��6R   $��10(�6^   $	��Top=�6m   $��Right=�6�   $	��200��6�   �� 5f   
   -
   5        $ lblFecha��5f      $��hh��6"   $��
0,47,8,197q�6/   $��Light"�6C   $��10(�6V   $��Right=�6d   $	��200��6�   5h      5i      