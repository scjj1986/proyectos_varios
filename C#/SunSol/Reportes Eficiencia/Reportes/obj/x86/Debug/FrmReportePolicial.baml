   M S B A M L   `   `   `  ����g  cMicrosoft.ReportViewer.WinForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3atSclr-namespace:Microsoft.Reporting.WinForms;assembly=Microsoft.ReportViewer.WinFormsMicrosoft.Reporting.WinForms  5   	    Reportes   Reportes.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   brvSclr-namespace:Microsoft.Reporting.WinForms;assembly=Microsoft.ReportViewer.WinForms     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   �   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6    � Title$-  'Correos Huespedes - Sunsol Hoteles S.A.��6	    � Icon$8 2/Reportes;component/Images/LOGO_SUNSOL_HOTELES.ico��69   
������� J� 	AllowDrop .  {�. $	��746��6Z  $
��1335��6g   � WindowStartupLocation$ CenterScreen=�6t  ��6s   Z� .��5      ]� $��Stretch=�6   $��Stretch=�6,   .+�5   
   � $��10,10,10,10q�6   $��
Right,Left=�6$   $	��Top=�6@   $��Stretch=�6X   .+�5      � -   5        $��grid1��5   G   $��Stretch=�6   $��20,146,15,0q�62   $	��Top=�6T   .+�5	      7  1System.Windows.Forms.Integration.WindowsFormsHost  -   5        $��windowsFormsHost1��5	   X   $��Stretch=�6#   $��18,25,24,-465q�6A   $��Stretch=�6q      Child. 5
      /   )Microsoft.Reporting.WinForms.ReportViewer  [ WSystem.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"  System.Windows.Forms.Control   Margin+  %System.Windows.Forms.PaddingConverter$ 	10,0,12,0 6&   -   5        RwReporteCorreo��5
   9   5      5      � 5      $��Center=�6   $	��Top=�61   $
��1268��6I   $	��165��6V   $��18,0,7,0q�6c   .+�5      (  "System.Windows.Controls.DatePicker  -   5        $��
dtp_fecha1��5   X   $��25��6   $
��Left=�6)   $��
461,47,0,0q�6D   $	��Top=�6j   $	��148��6�     5      -   5        $��
dtp_fecha2��5   X   $��25��6   $
��Left=�6)   $��
632,47,0,0q�6D   $	��Top=�6j   $	��148��6�   �� 5      -   5        $��btn_GenerarReporte��5   T   $��45��6   $
��Left=�6%   $��
599,88,0,0q�6@   $	��Top=�6n   $��46��6�   {�.  �� 	IsDefault .   �� IsCancel .   �� 	ClickMode$ Press=�6�   |�.  ��6�   Z� ��5      �� 5      	 �� ImageSource$2	 ,/Reportes;component/Images/File%20Search.png��6%   
 j� Stretch$

 None=�6`    j� TileMode$
 None=�6o   5      �� 5      -   5        $��label1��5   j   $��Fecha Inicio��6   $��28��6/   $
��Left=�6;   $��
494,19,0,0q�6V   $	��Top=�6x   ���	#FF22439B$��14(�6�   �� 5      -   5        $��label2��5   g   $��	Fecha Fin��6   $��28��6,   $
��Left=�68   $��
670,19,0,0q�6S   $	��Top=�6u   ���	#FF22439B$��14(�6�   �� 5      -	   5        $��image1��5   S   $��72��6   $
��Left=�6$   $��
972,35,0,0q�6?   $
��Fill=�6a   $	��Top=�6p   $	��192��6�   $<��6/Reportes;component/Images/LOGO%20SUNSOL%20HOTELES.png��6�   �� 5      -
   5        $��image2��5   R   $��74��6   $
��Left=�6$   $��	35,17,0,0q�6?   $
��Fill=�6`   $	��Top=�6o   $��88��6�   $I��C/Reportes;component/Images/curso-correo-electronico%20-%20copia.png��6�    �� StretchDirection$
 Both=�6�   �� 5      -   5        $��label3��5   f   $��Correos��6   $��28��6*   $
��Left=�66   $��595,132,0,0q�6Q   $	��Top=�6t   ���	#FF22439B$��14(�6�   �� 5      -   5        $��label4��5   e   $��Salir��6   $��28��6(   $
��Left=�64   $��1195,0,0,488q�6O   $��Bottom=�6s   ���	#FF22439B6�   �� 5      -   5        $��btnSalir��5   V   $��30��6   $
��Left=�6%   $��1231,103,0,0q�6@   $	��Top=�6f   $��35��6~   $ Press=�6�   |�.  ��6�   Z� ��5      �� 5      $T	 N/Reportes;component/Images/Salida_puerta_con_la_flecha_hacia_la_derecha_32.png��6%   $
 Uniform=�6�   $
 None=�6�   5!      �� 5#      -   5        $��button1��5#   J   $
��Left=�6   $��1231,0,0,138q�64   $��36��6Y   $y�Visible=�6�   |�.  ��6d   Z� ��5$      �� 5%      $]	 W/Reportes;component/Images/Botón_de_ayuda_bocadillo_con_signo_de_interrogación_32.png��6%   $
 Uniform=�6�   $
 None=�6�   5'      �� 5(      -   5        $��label5��5(   m   $��Mail Client 1.3��6   $��29��62   $
��Left=�6>   $��
120,64,0,0q�6Y   $	��Top=�6{   $	��130��6�   ���	#FF22439B$
��Bold"�6�   $��16(�6�   �� 5)      -   5        $��label6��5)   e   $��Salir��6   $��28��6(   $
��Left=�64   $��1229,130,0,0q�6O   $	��Top=�6s   ���	#FF22439B$��14(�6�   �� 5*      -   5        $��label7��5*   e   $��Acerca��6   $��28��6)   $��Right=�65   $��
0,0,-6,116q�6Q   $��Bottom=�6s   ���	#FF22439B$��14(�6�   �� 5+      -   5        $��cbx_Empresa��5+   =   $��23��6   $��294,48,854,0q�6'   $	��Top=�6P   .@�5,      �� $��Isla Caribe��6#   �� 5-      $��Punta Blanca��6#   �� 5.      $��Vacation Club��6#   5/      �� 50      -   5        $��label8��50   e   $��Empresa��6   $��28��6*   $
��Left=�66   $��
323,20,0,0q�6Q   $	��Top=�6s   ���	#FF22439B$��14(�6�   �� 51      -   5         ��Name$ chkTelefonos��51      $��	Telefonos��61   $
��Left=�6E   $��
810,49,0,0q�6`   $	��Top=�6t   ���	#FF22439B$��16(�6�   $y�Hidden=�6�   52      53      54      ��55      �� 56   
   59      