   M S B A M L   `   `   `  ����g  cMicrosoft.ReportViewer.WinForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3atSclr-namespace:Microsoft.Reporting.WinForms;assembly=Microsoft.ReportViewer.WinFormsMicrosoft.Reporting.WinForms  5   	   T PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5   	    Reportes   Reportes.MainWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   brvSclr-namespace:Microsoft.Reporting.WinForms;assembly=Microsoft.ReportViewer.WinForms     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6H  -   5          � Title$0  *Reporte Eficiencia - Sunsol Vacation Club.��5   	    � Icon$8 2/Reportes;component/Images/LOGO_SUNSOL_HOTELES.ico��6<      AccentColorBrush#���   6�   
������� J� 	AllowDrop .  {�. $��740.75��6�  $
��1335��6�   � WindowStartupLocation$ CenterScreen=�6�  .��5      ]� $��Stretch=�6   $��Stretch=�6,   .+�5   
   � $��10,8,10,549q�6   $��
Right,Left=�6$   $	��Top=�6@   $��Stretch=�6X   $
��auto��6v   .+�5	      � -   5        $��grid1��5	   G   $��Stretch=�6   $��20,146,15,0q�62   $	��Top=�6T   .+�5
      7  1System.Windows.Forms.Integration.WindowsFormsHost  -   5        $��windowsFormsHost1��5
   X   $��Stretch=�6#   $��18,25,24,-545q�6A   $��Stretch=�6q      Child. 5      /   )Microsoft.Reporting.WinForms.ReportViewer  [ WSystem.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"  System.Windows.Forms.Control   Margin+  %System.Windows.Forms.PaddingConverter$ 	10,0,12,0 6&   -   5        
RwReportes��5   9   5      5      � 5      $��Center=�6   $	��Top=�61   $
��1268��6I   $	��154��6V   $��	24,0,15,0q�6c   .+�5      (  "System.Windows.Controls.DatePicker  -   5        $��
dtp_fecha1��5   X   $��25��6   $
��Left=�6)   $��
606,46,0,0q�6D   $	��Top=�6j   $	��148��6�   �� 5      -   5        $��btn_GenerarReporte��5   T   $��45��6   $
��Left=�6%   $��
870,38,0,0q�6@   $	��Top=�6n   $��46��6�   {�.  �� 	IsDefault .   �� IsCancel .   �� 	ClickMode$ Press=�6�   |�.  ���	#FF24B8E4��6�   Z� 	 J� OpacityMask	 5      �� 5      
 �� ImageSource$
 Images/File Search.png��6%   5      �� 5      -   5        $��label1��5   c   $��Fecha��6   $��28��6(   $
��Left=�64   $��
651,17,0,0q�6O   $	��Top=�6q   ���	#FF22439B$��14(�6�   �� 5      -   5        $��label3��5   e   $��Reporte��6   $��28��6*   $
��Left=�66   $��
863,83,0,0q�6Q   $	��Top=�6s   ���	#FF22439B$��14(�6�   �� 5      -	   5        $��label4��5   e   $��Salir��6   $��28��6(   $
��Left=�64   $��1195,0,0,488q�6O   $��Bottom=�6s   ���	#FF22439B6�   �� 5      -
   5        $��btnSalir��5   V   $��30��6   $
��Left=�6%   $��1231,103,0,0q�6@   $	��Top=�6f   $��35��6~   $ Press=�6�   |�.  ���	#FF24B8E4��6�   Z� 	 5      �� 5      $@
 :Images/Salida_puerta_con_la_flecha_hacia_la_derecha_32.png��6%   5      �� 5      -   5        $��label6��5   e   $��Salir��6   $��28��6(   $
��Left=�64   $��1229,130,0,0q�6O   $	��Top=�6s   ���	#FF22439B$��14(�6�   �� 5       -   5        $��cbx_Empresa��5    =   $��23��6   $��386,45,705,0q�6'   $	��Top=�6P   5"      �� 5#      -   5        $��label8��5#   e   $��Empresa��6   $��28��6*   $
��Left=�66   $��
444,17,0,0q�6Q   $	��Top=�6s   ���	#FF22439B$��14(�6�   �� 5$      -   5         ��Name$ chkTelefonos��5$      $��	Telefonos��61   $
��Left=�6E   $��
810,49,0,0q�6`   $	��Top=�6t   ���	#FF22439B$��16(�6�   $y�Hidden=�6�   �� 5%      $
��Left=�6   $��86��63   $��17,2,0,0q�6?   $	��Top=�6Q   $	��171��6i   $#��Images/LOGO VACATION CLUB.png��6u   $
��Fill=�6�   �� 5&      -   5         ��Name$ txtObservacion��5&      $
��Left=�62   $��43��6M   $��386,103,0,0q�6Y    �� TextWrapping$
 Wrap=�6n   $�� ��6�   $	��Top=�6�   $	��368��6�   �� 5'      -   5         ��Name$ label8_Copy��5'   k   $��Observaciones��6   $��28��60   $
��Left=�6<   $��
385,76,0,0q�6W   $	��Top=�6�   ���	#FF22439B$��14(�6�   5(      5)      5*      ��5+      �� 5,   
   5/      