   M S B A M L   `   `   `  ����   Reservas    Reservas.menu   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     T PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f;Controls,http://metro.mahapps.com/winfx/xaml/controls  -   (  "MahApps.Metro.Controls.MetroWindow   Name$  VtnPrincipal�� � Title$< 6Módulo de Reservaciones para contratos SUNSOL HOTELES��$	��750��$
��1212��    IsMaxRestoreButtonEnabled .   � WindowStartupLocation$ CenterScreen=� � Icon$ icono/LogoSS.ico��*   #WindowButtonCommandsOverlayBehavior$ Never=�   ShowCloseButton .     IsCloseButtonEnabled .     IsWindowDraggable .  	   WindowTransitionsEnabled	 .  .��� .+��� $��1q�   AccentColorBrush#���   �� $��0��$��Retales��$��0q����� .R�� $��Stretch=�$��Stretch=�.+��� $��Menú principal��
�������$
��Bold"�$��16(�$	��5,0q�$
��Left=�$��Center=��� 
 �� Orientation$
 
Horizontal=�$��Right=�.+���  ��Name$ btnSalir��-   $��30��$��30��$��0q�  MetroCircleButtonStyle#���  ����  �� ImageSource$ Images/quit.png�� j� Stretch$ Uniform=�.���� $��20��$��20������  �� Path$ 
Foreground� �� RelativeSource �� *FindAncestor+ �� AncestorType" �� J� OpacityMask !� $
 Fill=�.��� $��Stretch=�$��Center=�$	��164��$��0,166,0,298q� � RowDefinitions �� $��40 ��� $��* �.+��� $��icono/man_icon.png��$��918,-190,221,180q��� -   $ btnNuevaReserva��$��40��$��40��$��13,-190,1139,190q�#���   � ToolTip$ Nueva reserva������ $ icono/other.png��$ Uniform=�.���� $��20��$��20������ *
Foreground+ �� *FindAncestor+" �� !� $
 Fill=��� -   $ btnModificarReserva��$��40��$��40��$��58,-190,1094,190q�#���  $ Modificar reserva������ $! icono/editnote_edi_9512.png��$ Uniform=�.���� $��20��$��20������ *
Foreground+ �� *FindAncestor+" �� !� $
 Fill=��� -   $ btnTemporada��$��40��$��40��$��103,-190,1049,190q�#���  $ 	Temporada������ $ icono/CALENDARIO AZUL.png��$ Uniform=�.���� $��20��$��20������ *
Foreground+ �� *FindAncestor+" �� !� $
 Fill=��� -   $ btnReportes��$��40��$��40��$��148,-190,1004,190q�#���  $ Reportes������ $/ )icono/icono-de-la-impresora-azul-3148.png��$ Uniform=�.���� $��20��$��20������ *
Foreground+ �� *FindAncestor+" �� !� $
 Fill=��� -    ��Name$ lblUser��$�� ��$��971,-190,4,200q�$
��Bold"��� -   $ lblFecha��$�� ��$��971,-170,-1,180q�$��Light"��� -	   $ 
btnLimpiar��$��40��$��40��$��193,-190,959,190q�#���  $ Cerrar ventanas������ $ Images/undo.png��$ Uniform=�.���� $��20��$��20������ *
Foreground+ �� *FindAncestor+" �� !� $
 Fill=� � -
     �Name$ frmContenido��$��
20,85,20,5q�$
��Auto=���.   � NavigationUIVisibility$ Hidden=�$	��590��