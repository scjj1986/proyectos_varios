   M S B A M L   `   `   `  ����  AdministracionData    AdministracionData.Login   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   T PMahApps.Metro, Version=1.3.0.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f;Controls,http://metro.mahapps.com/winfx/xaml/controls  5   	   :d2http://schemas.microsoft.com/expression/blend/2008  5   	   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  6F   -   5          � Title$(  "Sistema de Administración de data��5   	   $	��328��63   $	��450��6@   (  "MahApps.Metro.Controls.MetroWindow    IsMaxRestoreButtonEnabled .   � WindowStartupLocation$ CenterScreen=�6n    � Icon$  imagenes/logo vacation.ico��6�   .��5      � .+�5   
   �� $��
146,45,0,0q�6   $��imagenes/photo.jpg��6%   $	��118��6A   $	��Top=�6N   $
��Left=�6f   $	��146��6�   �� 5	   
   $��0��6   $��Retales��6    $��10q�61   ��5
      �� 5      .R�5      � $��Stretch=�6   $��Stretch=�69   $��27��6U   .+�5      �� $��Acceso��6    
�������$
��Bold"�6D   $��16(�6V   $��5,0,0,0q�6d   $
��Left=�5      $��Center=�6/   5      5      .��5      � $��Stretch=�6   $��Center=�61   $	��164��6L   $��	0,54,0,15q�6Y    � RowDefinitions 5      �� 5      $��40 �6$   �� 5      $��* �6$   .+�5      ��  �� Orientation$ Vertical=�6   $��Stretch=�64   $��10,29,10,38q�6R   $��2��6g   .+�5      �� -   5         ��Name$ 
txtUsuario��5      $��0, 10, 0, 0q�62   $��38��6G   *  $MahApps.Metro.Controls.TextBoxHelper   ClearTextButton .    UseFloatingWatermark . 	   	Watermark$	 Usuario��5      {�. $�� ��5      $��11(�6&   64   G� 5       -   5        
 G�Name$
 txtClave��5    "   $��0, 10, 0, 0q�64   $	 Password��5!       .  .  G� Password$  ��5%      $��11(�6    � ForceCursor . $��38��6:      ButtonCommand 5$      �� *TextBoxButtonCmd+ �� Mode$ OneWay=�5%   F   5&      5(      5*      �� 5+   
   -   5         ��Name$ 
btnaceptar��5+      $��Aceptar��6%   $
��Left=�67   $��338,246,0,0q�6R   $	��Top=�6g   $��75��6   6�   �� 5,   
   $��30,246,195,34q�6   �� 5-      -   5        .�5-   0   ¿Olvidó password?6C   5.      �� 5/   
   $��1q�6      AccentColorBrush#���   6%   50      51      