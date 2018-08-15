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
using MahApps.Metro.Controls.Dialogs;




namespace AdministracionData
{
    /// <summary>
    /// Lógica de interacción para Principal.xaml
    /// </summary>
    public partial class Principal : MetroWindow
    {
        public Clases.C_Usuario user;
        public Principal()
        {
            InitializeComponent();
        }

        private void tlUsuario_Click(object sender, RoutedEventArgs e)
        {
            frmContenido.Content = null;
            frmContenido.Navigate(new usuario());
            flmenu.IsOpen = false;
        }
      
        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            string perfil="";
            if(user.nivel==0)
                perfil="ADMINISTRADOR";
            if(user.nivel==1)
                perfil="CONFIRMADOR";
            if(user.nivel==2)
                perfil="TELEOPERADOR";
            //lblUser.Content = user.nombre+" "+user.apellido+" "+"PERFIL: "+perfil;
            DateTime hoy = DateTime.Today;
            flmenu.Header = user.nombre + " " + user.apellido;            
            lblFecha.Content = hoy.ToString("D", CultureInfo.CreateSpecificCulture("es-VE"));
            lblPerfil.Content="PERFIL: " + perfil;
            aplicarPerfil();
            flmenu.IsOpen = true;
           
        }

        private void tlConfiguracion_Click(object sender, RoutedEventArgs e)
        {
            frmContenido.Content = null;
            frmContenido.Navigate(new configuracion());
            flmenu.IsOpen = false;
        }

        private void Tile_Click(object sender, RoutedEventArgs e)
        {
            Cliente cli = new Cliente();
            cli.p = this;
            frmContenido.Content = null;
            frmContenido.Navigate(cli);
            flmenu.IsOpen = false;
        }

        private void tlReportes_Click(object sender, RoutedEventArgs e)
        {
            frmContenido.Content = null;
            frmContenido.Navigate(new reportesxaml());
            flmenu.IsOpen = false;
        }

        private void MetroWindow_Closed(object sender, EventArgs e)
        {
            App.Current.Shutdown();
        }

        private void tlLocacion_Click(object sender, RoutedEventArgs e)
        {
            frmContenido.Content = null;
            frmContenido.Navigate(new locacion());
            flmenu.IsOpen = false;
        }

        private void tlTelemarketing_Click(object sender, RoutedEventArgs e)
        {
            frmContenido.Content = null;
            telemarketing tele = new telemarketing();
            tele.p = this;
            frmContenido.Navigate(tele);
            flmenu.IsOpen = false;
        }

        private void Tile_Click_1(object sender, RoutedEventArgs e)
        {
            frmContenido.Content = null;
            afiliado afi = new afiliado();
            afi.p = this;
            frmContenido.Navigate(afi);
            flmenu.IsOpen = false;
        }

        private void tlAsignacion_Click(object sender, RoutedEventArgs e)
        {
            frmContenido.Content = null;
            asignacion asing = new asignacion();
            asing.p = this;
            frmContenido.Navigate(asing);
            flmenu.IsOpen = false;
        }
        private void aplicarPerfil()
        {
            if (user.nivel == 2)
            {
                tlprospecto.Visibility = Visibility.Hidden;
                tlAfiliado.Visibility = Visibility.Hidden;
                tlUsuario.Visibility = Visibility.Hidden;
                tlAsignacion.Visibility = Visibility.Hidden;
                tlLocacion.Visibility = Visibility.Hidden;
                tlTelemarketing.Visibility = Visibility.Hidden;
                tlConfiguracion.Visibility = Visibility.Hidden;
                tlpendiente.Visibility = Visibility.Visible;
                tlReportes.Visibility = Visibility.Hidden;
                tlpromotor.Visibility = Visibility.Hidden;
                tlconfirmador.Visibility = Visibility.Hidden;
            }
            if (user.nivel == 0)
            {
                tlprospecto.Visibility = Visibility.Visible;
                tlAfiliado.Visibility = Visibility.Visible;
                tlUsuario.Visibility = Visibility.Visible;
                tlAsignacion.Visibility = Visibility.Visible;
                tlLocacion.Visibility = Visibility.Visible;
                tlTelemarketing.Visibility = Visibility.Visible;
                tlConfiguracion.Visibility = Visibility.Visible;
                tlpendiente.Visibility = Visibility.Hidden;
                tlReportes.Visibility = Visibility.Visible;
                tlpromotor.Visibility = Visibility.Visible;
                tlconfirmador.Visibility = Visibility.Visible;
            }
        }

        private void tlpendiente_Click(object sender, RoutedEventArgs e)
        {
            frmContenido.Content = null;
            Pendiente p = new Pendiente();
            p.user = user;
            p.p = this;
            frmContenido.Navigate(p);
            flmenu.IsOpen = false;
        }

        private void BtnMenu_Click(object sender, RoutedEventArgs e)
        {
            flmenu.IsOpen = true;
        }

        private async void cerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            MessageDialogResult result= await this.ShowMessageAsync("Cerrar Sesión", "¿Desea Cerrar la sesión del usuario actual?", MessageDialogStyle.AffirmativeAndNegative);
            if (result == MessageDialogResult.Affirmative)
            {
                this.Hide();
                Login log = new Login();
                log.Show();
            }
        }

        private void tlpromotor_Click(object sender, RoutedEventArgs e)
        {
            frmContenido.Content = null;
            promotor pro = new promotor();
            pro.p = this;
            frmContenido.Navigate(pro);
            flmenu.IsOpen = false;
        }

        private void tlconfirmador_Click(object sender, RoutedEventArgs e)
        {
            frmContenido.Content = null;
            confirmador conf = new confirmador();
            conf.p = this;
            frmContenido.Navigate(conf);
            flmenu.IsOpen = false;
        }
    }
}
