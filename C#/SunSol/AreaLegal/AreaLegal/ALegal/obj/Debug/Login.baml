   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089M4clr-namespace:System.Globalization;assembly=mscorlibSystem.Globalization  5   
    AL   ALegal.Login   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Cgl4clr-namespace:System.Globalization;assembly=mscorlib     5   
   U QMahApps.Metro, Version=1.5.0.23, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f;Controls,http://metro.mahapps.com/winfx/xaml/controls  5   	   :d2http://schemas.microsoft.com/expression/blend/2008  5   	   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  6F     � Title$  SISTEMA ÁREA LEGAL��5   	   $	��350��6$   $	��525��61    � WindowStartupLocation$ CenterScreen=�6=    � Icon$ imagenes/sunsol isla.png��6b    � 
ResizeMode$ NoResize=�6�   .��5      � .+�5	   
   �� $��
203,53,0,0q�6   $��icono/photo.jpg��6%   $��92��6>   $	��Top=�6J   $
��Left=�6b   $	��126��6}    J� RenderTransformOrigin$ 0.5,0.5&�6�   z�5
      V� 5      .~�5      �� �� 5      �� 5       �� Angle$ -0.814Q�6&   T� 5      5      5      �� 5   
   $��0��6   $��Retales��6    $��10q�61   ��5      �� 5      .R�5      � $��Stretch=�6   $��Stretch=�69   $��27��6U   .+�5      �� $��Inicio de Sesión��6    
�������$
��Bold"�6N   $��16(�6`   $��5,0,0,0q�6n   $
��Left=�5      $��Center=�6/   5      5      .��5      � $��Stretch=�6   $��Center=�61   $	��164��6L   $��	0,54,0,15q�6Y    � RowDefinitions 5      �� 5       $��40 �6$   �� 5!      $��* �6$   .+�5#      ��  �� Orientation$ Vertical=�6   $��Stretch=�64   $��10,29,10,38q�6R   $��2��6g   .+�5$      �� -   5         ��Name$ 
txtUsuario��5$      $��	19,10,0,0q�62   $��38��6E   *  $MahApps.Metro.Controls.TextBoxHelper	   ClearTextButton	 . 
   UseFloatingWatermark
 .    	Watermark$ Usuario��5'      {�. $�� ��5(      $��11(�6&   G� 5)      -   5         G�Name$ txtClave��5)   "   $��	19,10,0,0q�64   $ Contraseña��5*      
 . 	 .  G� Password$  ��5.      $��11(�6    � ForceCursor . $��38��6:      ButtonCommand 5-      �� *TextBoxButtonCmd+ �� Mode$ OneWay=�5.   :   5/      50      52      �� 53   
   -   5         ��Name$ 
btnaceptar��53   0    � Cursor$
 Hand��6    �� 	IsDefault . $��Aceptar��6D   $
��Left=�6V   $��418,261,0,0q�6q   $	��Top=�6�   $��75��6�   6�   �� 55   
   $��1q�6   $��
0,-10,0,10q�6&   ._�56      �� -   5         ��Name$ imagen1��56      $
��Left=�6%   $��33��6@   $	��Top=�6L   $��37��6d   $��imagenes/admin.png��6o   $ 0.843,0.048&�6�   $��436,166,0,0q�6�   57      �� 58   
   -   5        $ imagen2��58      $
��Left=�6!   $��35��6<   $��439,206,0,0q�6H   $	��Top=�6]   $��32��6u   $��imagenes/clave.png��6�   59      5:      