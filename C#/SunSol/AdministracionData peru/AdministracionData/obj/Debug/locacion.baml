   M S B A M L   `   `   `  ����  AdministracionData!    AdministracionData.locacion   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      T PMahApps.Metro, Version=1.3.0.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f9Custom,http://metro.mahapps.com/winfx/xaml/controls  5      ;Controls,http://metro.mahapps.com/winfx/xaml/controls  5      -   5          N� Title$  locacion��5
      $
��auto��6   .��5      �� -   5         ��Name$
 data��5      $
��Auto=�6!   $
��Auto=�6F   .��5   
   � $��0,0,0,10q�6   $
��Auto=�6!   $
��Auto=�6S    � RowDefinitions 5      �� 5      $
��393* �6    �� 5      $	��61* �6    �� 5      $��0* �6    �� 5      $��0* �6    .+�5      �� $��0��6   $��Retales��6$   $��0,0,0,2q�65   $��2��6F   ��5      �� 5      .R�5      � $��Stretch=�6   $��Stretch=�6=   $��36��6Y   .+�5      �� $��
Locaciones��6$   
�������$
��Bold"�6L   $��16(�6^   $��5,0,0,0q�6l   $
��Left=�5      $��Center=�6#   5      5      5#      �� 5%      -   5         ��Name$ BtnNvLocacion��5%         AccentedSquareButtonStyle#��[  6-   $��	24,54,0,0q�6`   $
��Left=�6s   $��42��6�   $��32��6�   $	��Top=�6�    � ToolTip$ Nueva locación��6�   ��5&      �� 5'       �� ImageSource$ imagenes/nuevo.png��6!    j� Stretch$
 None=�6B   5)      &   System.Windows.Controls.DataGrid  5+      -   5          Name$ dtgrdlocaciones��5+         AutoGenerateColumns .  	 �� AlternationCount$	 1��6e   
   CanUserReorderColumns
 .     CanUserResizeColumns .     CanUserAddRows .     CanUserResizeRows .     CanUserSortColumns .  $0 *Doble click para seleccionar una locación��6  $   HorizontalScrollBarVisibility$ Disabled=�65  $��Center=�6^  $��24,91,32,54q�6�     AreRowDetailsFrozen . $��2��6�  ��61   ��    Columns 5,      0  *System.Windows.Controls.DataGridTextColumn  5-      ,  &System.Windows.Controls.DataGridColumn   CanUserResize .     
IsReadOnly .    Header$ código��6z   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6)   �� *codigo+ �� Mode$ OneWay=�   	CellStyle 5.      �� 5/      .�50   "   ��  �� Property � �� �� Value$
 Left=�6Y   51      53        54       .   . $ descripción��6    6)   �� *descripcion+$ OneWay=� 55      �� 56      .�57   "   ��  � ��$
 Left=�6Y   58      5:        5<       .   . $ 
dirección��6}    6)   �� *	direccion+$ OneWay=� 5=      �� 5>      .�5?   "   ��  � ��$
 Left=�6Y   5@      5B      5E      #  MahApps.Metro.Controls.Flyout  5F      -   5          Name$ flNuevo��5F   �      Header$ Nueva locación��6   $
��auto��66      Position$
 Left=�6D   $��	8,1,-98,6q�6T   $
��Left=�6g   $	��580��6�      Theme$ Light=�6�   $	��Top=�6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   #��� ��6�   z�5G      V� 5H      .~�5I      �� �� 5J       �� AngleX$ -0.28Q�6(   �� 5K      T� 5L        T� X$  -1.495Q�6-   5M      .��5P      � $
��auto��6   $
��Auto=�6&   $
��Auto=�6X   $
��auto��6�   .+�5Q      �� -   5        ! ��Name$! 	txtCodigo��5Q      $��	36,38,0,0q�61   $��38��6D   *  $MahApps.Metro.Controls.TextBoxHelper"   UseFloatingWatermark" . #   	Watermark$# Código de locación��5S      {�. $�� ��5T   !   $��11(�6)   $	��500��67   $
��Left=�6C   $	��Top=�6^   ��.  6�   �� 5U      -   5        $! txtDescripcion��5U      $��	36,81,0,0q�66   $��38��6I   " . $# Descripción��5W      {�. $�� ��5X   !   $��11(�6)   $	��500��67   $
��Left=�6C   $	��Top=�6^   ��.  6�   �� 5Y      -   5        $! txtDireccion��5Y      $��
36,124,0,0q�64   $��38��6H   " . $# 
Dirección��5[      {�. $�� ��5\   !   $��11(�6)   $	��500��67   $
��Left=�6C   $	��Top=�6^   ��.  6�   !  MahApps.Metro.Controls.Tile  5]      -	   5        $  Name$$ 	tlGuardar��5]   $   $��52��68   $��541,200,0,0q�6D   $��58��6Y   $	��Top=�6d   $ Guardar��6|   $
��Left=�6�   % J� Effect% 5^      3  -System.Windows.Media.Effects.DropShadowEffect  5_      &   
BlurRadius$& 8Q�6/   '   Opacity$
' 0.95Q�6>   (   ShadowDepth$( 8Q�6M   .��5a      �� $��imagenes/guardar.png��6    $��48��6>   5b        5c      -
   5        $$ 
tlCancelar��5c   $   $��52��69   $��478,200,0,0q�6E   $��58��6Z   $	��Top=�6e   $
��Left=�6}   % 5d        5e      $
' 0.95Q�6/   $( 8Q�6>   $& 8Q�6N   .��5g      �� $��imagenes/Cancel.png��6    $��48��6=   5h      �� 5i      $��(*) Campos obligatorios��6   $
��Left=�6>   $��264,222,0,0q�6Y   $	��Top=�6n   ���	#FFF30C0C6�   �� 5j      $	��(*)��6   $
��Left=�6*   $��
614,38,0,0q�6E   $	��Top=�6Y   ���	#FFF30C0C6q   �� 5k      $	��(*)��6   $
��Left=�6*   $��
614,81,0,0q�6E   $	��Top=�6Y   ���	#FFF30C0C6q   �� 5l      $	��(*)��6   $
��Left=�6*   $��614,124,0,0q�6E   $	��Top=�6Z   ���	#FFF30C0C6r   5n      5p      5r      5s      5t      