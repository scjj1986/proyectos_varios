using System;
using MahApps.Metro.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using librerias;
using System.Globalization;

namespace Reservas
{
    /// <summary>
    /// Lógica de interacción para menu.xaml
    /// </summary>
    public partial class menu : MetroWindow
    {
        public usuario user;
       
        public menu()
        {
            InitializeComponent();
        }

        private void VtnPrincipal_Activated(object sender, EventArgs e)
        {
            
        }

        private void btnNuevaReserva_Click(object sender, RoutedEventArgs e)
        {
            frmContenido.Content = null;
            nuevareserva nr = new nuevareserva();
            nr.us = user;
            nr.user = user.login;
            frmContenido.Navigate(nr);           
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {

            frmContenido.Content = null;
            
            frmContenido.Navigate(new primera());
        }

        private void VtnPrincipal_Loaded(object sender, RoutedEventArgs e)
        {
            lblUser.Content = user.login;
            DateTime hoy = DateTime.Today;
            lblFecha.Content = hoy.ToString("D", CultureInfo.CreateSpecificCulture("es-VE"));
            frmContenido.Navigate(new primera());
            reservacion res = new reservacion();
            res.verificafechalimite();

            switch (user.codigoPerfil){
                case 3:
                    btnConfiguracion.IsEnabled=false;
                    break;
                case 4:
                    btnNuevaReserva.IsEnabled=false;
                    btnConfiguracion.IsEnabled=false;
                    btnPagos.IsEnabled=false;
                    btnLocalizador.IsEnabled=false;
                    btnPuntosDisponibles.IsEnabled=false;
                    break;
            }


            //if (user.codigoPerfil==3 || user.codigoPerfil==4)

            //System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            //dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            //dispatcherTimer.Interval = new TimeSpan(0,1,0);
            //dispatcherTimer.Start();
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            //this.IsEnabled = false;
            //inicio ini = new inicio();
            //ini.Show();
            
        }

        private void frmContenido_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            frmContenido.NavigationService.RemoveBackEntry();
          
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("¿Desea salir de la aplicación?", "Salir", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                App.Current.Shutdown();
        }

        private void btnModificarReserva_Click(object sender, RoutedEventArgs e)
        {
            frmContenido.Content = null;
            modificareserva mr = new modificareserva();
            mr.user = user.nombres+" "+user.apellidos;
            frmContenido.Navigate(mr);  
        }

        private void btnReportes_Click(object sender, RoutedEventArgs e)
        {
            frmContenido.Content = null;
            cotizacion cot = new cotizacion();
            cot.us = user;
            cot.user = user.nombres + " " + user.apellidos;
            frmContenido.Navigate(cot);
        }

        private void btnPagos_Click(object sender, RoutedEventArgs e)
        {
            frmContenido.Content = null;
            pagos pa = new pagos();
            pa.user = user.nombres + " " + user.apellidos;
            pa.us = user;
            frmContenido.Navigate(pa);
        }

        private void btnConfiguracion_Click(object sender, RoutedEventArgs e)
        {
            frmContenido.Content = null;

            configuracion cnf = new configuracion();
            cnf.usrio = user;
            frmContenido.Navigate(cnf);
        }

        private void btnLocalizador_Click(object sender, RoutedEventArgs e)
        {
            frmContenido.Content = null;
            localizador loc = new localizador();
            loc.us = user;
            loc.user = user.nombres + " " + user.apellidos;
            frmContenido.Navigate(loc);
        }

        private void btnPuntosDisponibles_Click(object sender, RoutedEventArgs e)
        {
            frmContenido.Content = null;
            PuntosDisponibles pd = new PuntosDisponibles();
            pd.us = user;
            frmContenido.Navigate(pd);
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("¿Desea cerrar la sesión del usuario actual?", "Cerrar sesión", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                this.Hide();
                inicio ini = new inicio();
                ini.Show();
            }
        }

        private void btnAyuda_Click(object sender, RoutedEventArgs e)
        {

            ayuda ay = new ayuda();
            ay.Show();
            
        }

      
    }
   
}
