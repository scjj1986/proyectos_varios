   M S B A M L   `   `   `  ����  AdministracionData$    AdministracionData.confirmador   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      T PMahApps.Metro, Version=1.3.0.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f;Controls,http://metro.mahapps.com/winfx/xaml/controls  5      9Custom,http://metro.mahapps.com/winfx/xaml/controls  5      -   5          N� Title$  Confirmador��5
      .��5      �� -   5         ��Name$
 data��5      $
��Auto=�6!   $
��Auto=�6F   .��5   
   � $��0,0,0,10q�6   $
��Auto=�6!   $
��Auto=�6S   .+�5      �� $��0��6   $��Retales��6$   $��0,0,0,4q�65   ��5      �� 5      .R�5      � $��Stretch=�6   $��Stretch=�6=   $��36��6Y   .+�5      �� $��Confirmador��6$   
�������$
��Bold"�6M   $��16(�6_   $��5,0,0,0q�6m   $
��Left=�5      $��Center=�6#   5      5      5!      �� 5#      -   5         ��Name$ BtnNvTelemarketing��5#         AccentedSquareButtonStyle#��[  62   $��	24,54,0,0q�6e   $
��Left=�6x   $��42��6�   $��32��6�   $	��Top=�6�    � ToolTip$ Nuevo cliente��6�   ��5$      �� 5%       �� ImageSource$ imagenes/nuevo.png��6!    j� Stretch$
 None=�6B   5'      �� 5(      -   5         ��Name$ 	txtCedula��5(      $��	71,54,0,0q�6)   $��38��6<   *  $MahApps.Metro.Controls.TextBoxHelper   UseFloatingWatermark .    	Watermark$ Documento de identidad��5+      {�. $�� ��5,      $��11(�6$   $	��266��62   $
��Left=�6>   $	��Top=�6Y   �� 5-      -   5        $ 	txtNombre��5-      $��
354,54,0,0q�6)   $��38��6=    . $ Nombre��50      {�. $�� ��51      $��11(�6$   $	��266��62   $
��Left=�6>   $	��Top=�6Y   &   System.Windows.Controls.DataGrid  53      -   5        	  Name$	 dtgrdconfirmador��53      
   AutoGenerateColumns
 .   �� AlternationCount$ 1��6f      CanUserReorderColumns .     CanUserResizeColumns .     CanUserAddRows .     CanUserResizeRows .     CanUserSortColumns .  $3 -Doble click para seleccionar un telemarketing��6  $   HorizontalScrollBarVisibility$ Disabled=�6:  $��Center=�6c  $��24,117,32,143q�6�  ��62   ��    Columns 54      0  *System.Windows.Controls.DataGridTextColumn  55      ,  &System.Windows.Controls.DataGridColumn   CanUserResize .     
IsReadOnly .    Header$ N° documento��6|   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6)   �� *
doc_iden+ �� Mode$ OneWay=�   	CellStyle 56      �� 57      .�58   "   ��  �� Property � �� �� Value$
 Left=�6Y   59      5;        5<       .   . $ nombre��6z    6)   �� *nombre+$ OneWay=� 5=      �� 5>      .�5?   "   ��  � ��$
 Left=�6Y   5@      5B        5C       .   . $ Apellido��6|    6)   �� *
apellido+$ OneWay=� 5D      �� 5E      .�5F   "   ��  � ��$
 Left=�6Y   5G      5I        5J       .   . $ 	teléfono��6|    6)   �� *
telefono+$ OneWay=� 5K      �� 5L      .�5M   "   ��  � ��$ Right=�6Y   5N      5P        5R       .   . $ correo��6z    6)   �� *correo+$ OneWay=� 5S      �� 5T      .�5U   "   ��  � ��$
 Left=�6Y   5V      5X      5\      #  MahApps.Metro.Controls.Flyout  5]      -   5          Name$ flNuevo��5]   �      Header$ Nuevo confirmador��6      Position$
 Left=�69   $��8,1,0,20q�6I   $
��Left=�6[   $	��750��6v      Theme$ Light=�6�   $	��Top=�6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   #��� ��6�   z�5^      V� 5_      .~�5`      �� �� 5a        �� AngleX$  -0.28Q�6(   �� 5b      T� 5c      ! T� X$! -1.495Q�6-   5d      .��5f      �� $
��auto��6   .��5g      � $
��auto��6   $��
98,0,-38,0q�6)   ��. $
��Auto=�6b   $
��Auto=�6�   .+�5h      �� -   5        $ txtCedul��5h   "   $��	10,37,0,0q�64   $��38��6G    . $ Documento de identidad��5j      {�. $�� ��5k   !   $��11(�6)   $	��500��67   $
��Left=�6C   $	��Top=�6^   ��.  6v   �� 5m      -	   5        $ 
txtNombreN��5m   "   $��	10,75,0,0q�66   $��38��6I    . $ Nombre��5p      {�. $�� ��5q   !   $��11(�6)   $	��500��67   $
��Left=�6C   $	��Top=�6^   6v   �� 5r      -
   5        $ txtApellido��5r   "   $��
10,113,0,0q�67   $��38��6K    . $ Apellido��5u      {�. $�� ��5v   !   $��11(�6)   $	��500��67   $
��Left=�6C   $	��Top=�6^   6v   !  MahApps.Metro.Controls.Tile  5y      -   5        "  Name$" 	tlGuardar��5y   (   $��52��6<   $��
0,334,99,0q�6H   $��58��6\   $	��Top=�6g   $��Right=�6   $ Guardar��6�   # J� Effect# 5z      3  -System.Windows.Media.Effects.DropShadowEffect  5{   "   $   
BlurRadius$$ 8Q�63   %   Opacity$
% 0.95Q�6B   &   ShadowDepth$& 9Q�6Q   .��5}      �� $��imagenes/guardar.png��6$   $��48��6B   5~        5      -   5        $" 
tlCancelar��5   (   $��52��6=   $��0,334,162,0q�6I   $��58��6^   $��Right=�6i   $	��Top=�6�   # 5�        5�   "   $
% 0.95Q�63   $& 9Q�6B   $$ 8Q�6R   .��5�      �� $��imagenes/Cancel.png��6$   $��48��6A   5�      �� 5�      $��(*) Campos obligatorios��6    $
��Left=�6B   $��290,356,0,0q�6]   $	��Top=�6r   ���	#FFF30C0C6�   �� 5�      -   5        $ txtThabitacion��5�   "   $��
10,151,0,0q�6:   $��38��6N    . $+ %Teléfono habitación Ej: 212 1112211��5�      {�. $�� ��5�   #   $��11(�6+   $	��500��69   $
��Left=�6E   $	��Top=�6`   �� 5�      -   5        $ 	txtcorreo��5�   "   $��
10,189,0,0q�65   $��38��6I    . $ Correo electrónico��5�      {�. $�� ��5�   #   $��11(�6+   $	��500��69   $
��Left=�6E   $	��Top=�6`   6x   �� 5�      -   5        ' ��Name$' cmbtipo��5�   $   $��10,0,0,0q�65   $��38��6G    . $ Tipo de documento��5�      {�. ( �� Text$(  ��5�   !   $��11(�6)   $	��500��67   $
��Left=�6C   $	��Top=�6^   6v   �� 5�      -   5        $ 	txtcodigo��5�   "   $��
10,227,0,0q�65   $��38��6I   $y�Hidden=�6U    . $ Código��5�      {�. $�� ��5�   +   $��11(�63   $	��500��6A   $
��Left=�6M   $	��Top=�6h   6�   5�      5�      5�      5�      5�      5�      