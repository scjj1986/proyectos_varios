   M S B A M L   `   `   `  ����  AdministracionData&     AdministracionData.telemarketing   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      T PMahApps.Metro, Version=1.3.0.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f;Controls,http://metro.mahapps.com/winfx/xaml/controls  5      9Custom,http://metro.mahapps.com/winfx/xaml/controls  5      -   5          N� Title$  telemarketing��5
      .��5      �� -   5         ��Name$
 data��5      $
��Auto=�6!   $
��Auto=�6F   .��5   
   � $��0,0,0,10q�6   $
��Auto=�6!   $
��Auto=�6S   .+�5      �� $��0��6   $��Retales��6$   $��0,0,0,4q�65   ��5      �� 5      .R�5      � $��Stretch=�6   $��Stretch=�6=   $��36��6Y   .+�5      �� $��Telemarketing��6$   
�������$
��Bold"�6O   $��16(�6a   $��5,0,0,0q�6o   $
��Left=�5      $��Center=�6#   5      5      5       �� 5"      -   5         ��Name$ BtnNvTelemarketing��5"         AccentedSquareButtonStyle#��[  62   $��	24,54,0,0q�6e   $
��Left=�6x   $��42��6�   $��32��6�   $	��Top=�6�    � ToolTip$ Nuevo cliente��6�   ��5#      �� 5$       �� ImageSource$ imagenes/nuevo.png��6!    j� Stretch$
 None=�6B   5&      �� 5'      -   5         ��Name$ 	txtCedula��5'      $��	71,54,0,0q�6)   $��38��6<   *  $MahApps.Metro.Controls.TextBoxHelper   UseFloatingWatermark .    	Watermark$ Documento de identidad��5*      {�. $�� ��5+      $��11(�6$   $	��266��62   $
��Left=�6>   $	��Top=�6Y   �� 5,      -   5        $ 	txtNombre��5,      $��
354,54,0,0q�6)   $��38��6=    . $ Nombre��5/      {�. $�� ��50      $��11(�6$   $	��266��62   $
��Left=�6>   $	��Top=�6Y   &   System.Windows.Controls.DataGrid  52      -   5        	  Name$	 dtgrdtelemarketing��52      
   AutoGenerateColumns
 .   �� AlternationCount$ 1��6h      CanUserReorderColumns .     CanUserResizeColumns .     CanUserAddRows .     CanUserResizeRows .     CanUserSortColumns .  $3 -Doble click para seleccionar un telemarketing��6  $   HorizontalScrollBarVisibility$ Disabled=�6<  $��Center=�6e  $��24,117,32,143q�6�  ��64   ��    Columns 53      0  *System.Windows.Controls.DataGridTextColumn  54      ,  &System.Windows.Controls.DataGridColumn   CanUserResize .     
IsReadOnly .    Header$ N° documento��6|   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6)   �� *
doc_iden+ �� Mode$ OneWay=�   	CellStyle 55      �� 56      .�57   "   ��  �� Property � �� �� Value$
 Left=�6Y   58      5:        5;       .   . $ nombre��6z    6)   �� *nombre+$ OneWay=� 5<      �� 5=      .�5>   "   ��  � ��$
 Left=�6Y   5?      5A        5B       .   . $ Apellido��6|    6)   �� *
apellido+$ OneWay=� 5C      �� 5D      .�5E   "   ��  � ��$
 Left=�6Y   5F      5H        5I       .   . $ 	teléfono��6|    6)   �� *
telefono+$ OneWay=� 5J      �� 5K      .�5L   "   ��  � ��$ Right=�6Y   5M      5O        5Q       .   . $ correo��6z    6)   �� *correo+$ OneWay=� 5R      �� 5S      .�5T   "   ��  � ��$
 Left=�6Y   5U      5W        5X       .   . $ código��6z    6)   �� *codigo+$ OneWay=� 5Y      �� 5Z      .�5[   "   ��  � ��$ Center=�6Y   5\      5^      5a      #  MahApps.Metro.Controls.Flyout  5b      -   5          Name$ flNuevo��5b   �      Header$ Nuevo Teleoperador��6      Position$
 Left=�6:   $��8,1,0,20q�6J   $
��Left=�6\   $	��750��6w      Theme$ Light=�6�   $	��Top=�6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   #��� ��6�   z�5c      V� 5d      .~�5e      �� �� 5f        �� AngleX$  -0.28Q�6(   �� 5g      T� 5h      ! T� X$! -1.495Q�6-   5i      .��5k      �� $
��auto��6   .��5l      � $
��auto��6   $��
98,0,-38,0q�6)   ��. $
��Auto=�6b   $
��Auto=�6�   .+�5m      �� -   5        $ txtCedul��5m   "   $��	10,37,0,0q�64   $��38��6G    . $ Documento de identidad��5o      {�. $�� ��5p   !   $��11(�6)   $	��500��67   $
��Left=�6C   $	��Top=�6^   ��.  6v   �� 5r      -	   5        $ 
txtNombreN��5r   "   $��	10,75,0,0q�66   $��38��6I    . $ Nombre��5u      {�. $�� ��5v   !   $��11(�6)   $	��500��67   $
��Left=�6C   $	��Top=�6^   6v   �� 5w      -
   5        $ txtApellido��5w   "   $��
10,113,0,0q�67   $��38��6K    . $ Apellido��5z      {�. $�� ��5{   !   $��11(�6)   $	��500��67   $
��Left=�6C   $	��Top=�6^   6v   !  MahApps.Metro.Controls.Tile  5~      -   5        "  Name$" 	tlGuardar��5~   (   $��52��6<   $��
0,334,99,0q�6H   $��58��6\   $	��Top=�6g   $��Right=�6   $ Guardar��6�   # J� Effect# 5      3  -System.Windows.Media.Effects.DropShadowEffect  5�   "   $   
BlurRadius$$ 8Q�63   %   Opacity$
% 0.95Q�6B   &   ShadowDepth$& 9Q�6Q   .��5�      �� $��imagenes/guardar.png��6$   $��48��6B   5�        5�      -   5        $" 
tlCancelar��5�   (   $��52��6=   $��0,334,162,0q�6I   $��58��6^   $��Right=�6i   $	��Top=�6�   # 5�        5�   "   $
% 0.95Q�63   $& 9Q�6B   $$ 8Q�6R   .��5�      �� $��imagenes/Cancel.png��6$   $��48��6A   5�      �� 5�      $��(*) Campos obligatorios��6    $
��Left=�6B   $��290,356,0,0q�6]   $	��Top=�6r   ���	#FFF30C0C6�   �� 5�      -   5        $ txtThabitacion��5�   "   $��
10,151,0,0q�6:   $��38��6N    . $+ %Teléfono habitación Ej: 212 1112211��5�      {�. $�� ��5�   #   $��11(�6+   $	��500��69   $
��Left=�6E   $	��Top=�6`   �� 5�      -   5        $ 	txtcorreo��5�   "   $��
10,189,0,0q�65   $��38��6I    . $ Correo electrónico��5�      {�. $�� ��5�   #   $��11(�6+   $	��500��69   $
��Left=�6E   $	��Top=�6`   6x   �� 5�      -   5        ' ��Name$' cmbtipo��5�   $   $��10,0,0,0q�65   $��38��6G    . $ Tipo de documento��5�      {�. ( �� Text$(  ��5�   !   $��11(�6)   $	��500��67   $
��Left=�6C   $	��Top=�6^   6v   �� 5�      -   5        $ 	txtcodigo��5�   "   $��
10,227,0,0q�65   $��38��6I    . $ Código��5�      {�. $�� ��5�   +   $��11(�63   $	��500��6A   $
��Left=�6M   $	��Top=�6h   6�   5�      5�      5�      5�      5�      5�      