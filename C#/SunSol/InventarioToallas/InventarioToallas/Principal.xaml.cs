using System;
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
using MahApps.Metro.Controls;
using System.Globalization;
using MetroFramework.Forms;
using MetroFramework.Interfaces;
using System.Windows.Navigation;



namespace InventarioToallas
{
    /// <summary>
    /// Lógica de interacción para Principal.xaml
    /// </summary>
    public partial class Principal : MetroWindow
    {
        public Clases.C_Usuario user;
        public bool cerrar;
        public Principal()
        {
            InitializeComponent();
            //this.SizeChanged += MetroWindow_SizeChanged;
            cerrar = false;
        }

        #region EVENTO CARGA DE LA VENTANA
        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            string perfil = "";
            if (user.nivel == 0)
                perfil = "ADMINISTRADOR";
            if (user.nivel == 1)
                perfil = "SUPERVISOR";
            if (user.nivel == 2)
                perfil = "COSTOS";
            if (user.nivel == 3)
                perfil = "OPERADOR";



            if (perfil != "ADMINISTRADOR")
            {
                tlUsuario.IsEnabled = false;
                tlReportesBitacora.IsEnabled = false;
            }
                


            if (perfil != "SUPERVISOR" && perfil != "ADMINISTRADOR")
            {

                tlSupervisor.IsEnabled = false;
                tlCamareras.IsEnabled = false;
                tlSuministros.IsEnabled = false;
                tlMovHab.IsEnabled = false;
                tlMovimiento.IsEnabled = false;
                tlExtra.IsEnabled = false;

            }
            flmenu.Header = user.nombre + " " + user.apellido;
            lblUser.Content ="PERFIL: " + perfil;
            DateTime hoy = DateTime.Today;
            lblfecha.Content = hoy.ToString("D", CultureInfo.CreateSpecificCulture("es-VE"));
            flmenu.IsOpen = true;
        }

        #endregion

        #region EVENTO LLAMADA AL MÓDULO USUARIO

        private void tlUsuario_Click(object sender, RoutedEventArgs e)
        {
            frmContenido.Content = null;
            frmContenido.Navigate(new usuario());
            flmenu.IsOpen = false;
        }

        #endregion

        

        private void MetroWindow_Closed(object sender, EventArgs e)
        {
            
            
            
            
        }

        #region EVENTO LLAMADA AL MÓDULO SUPERVISOR


        private void tlSupervisor_Click(object sender, RoutedEventArgs e)
        {
            frmContenido.Content = null;
            frmContenido.Navigate(new supervisor());
            flmenu.IsOpen = false;
        }

        #endregion

        #region EVENTO LLAMADA AL MÓDULO CAMARERAS

        private void tlCamareras_Click(object sender, RoutedEventArgs e)
        {
            frmContenido.Content = null;
            frmContenido.Navigate(new camarera());
            flmenu.IsOpen = false;
        }

        #endregion

        #region EVENTO LLAMADA AL MÓDULO SUMINISTROS

        private void tlSuministros_Click(object sender, RoutedEventArgs e)
        {
            frmContenido.Content = null;
            frmContenido.Navigate(new suministro());
            flmenu.IsOpen = false;
        }

        #endregion

        #region SALIR DE LA APLICACIÓN

        private void tlSalir_Click(object sender, RoutedEventArgs e)
        {

            if (!cerrar)
            {
                if (MessageBox.Show("Desea salir de la aplicación?", "Confirmación", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    cerrar = true;
                    Application.Current.Shutdown();
                }

            }

            
        }

        private void tlSalir_Unloaded(object sender, RoutedEventArgs e)
        {

        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            if (!cerrar)
            {
                if (MessageBox.Show("Desea salir de la aplicación?", "Confirmación", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Application.Current.Shutdown();

                }
                else
                {
                    cerrar = false;
                    e.Cancel = true;
                }
            }
            
        }

        private void MetroWindow_Unloaded(object sender, RoutedEventArgs e)
        {

        }

        #endregion

        #region EVENTO LLAMADA ASIGNAR HABITACIONES

        private void tlMovHab_Click(object sender, RoutedEventArgs e)
        {
            frmContenido.Content = null;
            asignacion asi=new asignacion();
            asi.user=user;
            frmContenido.Navigate(asi);
            flmenu.IsOpen = false;
          
        }

        #endregion

        private void tlMovimiento_Click(object sender, RoutedEventArgs e)
        {
            frmContenido.Content = null;
            AsigSuministro asum = new AsigSuministro();
            asum.user = user;
            frmContenido.Navigate(asum);
            flmenu.IsOpen = false;
        }

        private void tlAsigHabHoy_Click(object sender, RoutedEventArgs e)
        {
            frmContenido.Content = null;
            ListAsignHabCamHoy lahc = new ListAsignHabCamHoy();
            lahc.user = user;
            frmContenido.Navigate(lahc);
            flmenu.IsOpen = false;
        }

        private void tlMovPorFecha_Click(object sender, RoutedEventArgs e)
        {
            frmContenido.Content = null;
            MovHabPorFecha mhf = new MovHabPorFecha();
            mhf.user = user;
            frmContenido.Navigate(mhf);
            flmenu.IsOpen = false;
        }

        private void tlPerPorFecha_Click(object sender, RoutedEventArgs e)
        {
            frmContenido.Content = null;
            PerPorFecha ppf = new PerPorFecha();
            ppf.user = user;
            frmContenido.Navigate(ppf);
            flmenu.IsOpen = false;
        }

        private void tlExtra_Click(object sender, RoutedEventArgs e)
        {
            frmContenido.Content = null;
            SuministroExtra ext = new SuministroExtra();
            ext.user = user;
            frmContenido.Navigate(ext);
            flmenu.IsOpen = false;
        }

        private void tlReportes_Click(object sender, RoutedEventArgs e)
        {
            frmContenido.Content = null;
            frmContenido.Navigate(new ReportePerdida());
            flmenu.IsOpen = false;

        }

        private void tlRepSumHab_Click(object sender, RoutedEventArgs e)
        {
            frmContenido.Content = null;
            frmContenido.Navigate(new reporteAsigMov());
            flmenu.IsOpen = false;
        }

        private void MetroWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            
        }

        private void BtnMenu_Click(object sender, RoutedEventArgs e)
        {
            flmenu.IsOpen = true;
        }

        private void tlReportesExtra_Click(object sender, RoutedEventArgs e)
        {
            frmContenido.Content = null;
            frmContenido.Navigate(new ReporteExtra());
            flmenu.IsOpen = false;
        }

        private void tlReportesBitacora_Click(object sender, RoutedEventArgs e)
        {
            frmContenido.Content = null;
            frmContenido.Navigate(new ReporteBitacora());
            flmenu.IsOpen = false;
        }

        private void tlRepToaPisc_Click(object sender, RoutedEventArgs e)
        {


            frmContenido.Content = null;
            frmContenido.Navigate(new ReporteToallasPiscina());
            flmenu.IsOpen = false;


        }


    }
}


