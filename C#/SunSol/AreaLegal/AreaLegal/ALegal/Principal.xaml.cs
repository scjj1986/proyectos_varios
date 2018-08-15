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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using MahApps.Metro.Behaviours;
using System.Globalization;

namespace ALegal
{
    /// <summary>
    /// Lógica de interacción para Principal.xaml
    /// </summary>
    public partial class Principal : MetroWindow
    {

        public usuario usr;

        public Principal()
        {
            InitializeComponent();
        }

        #region EVENTOS CLICK ITEMS MENÚ

        private void tlEmpresa_Click(object sender, RoutedEventArgs e)
        {
            frmContenido.Content = null;
            Empresa frmEmp = new Empresa();
            frmContenido.Navigate(frmEmp);
        }

        private void tlUsuario_Click(object sender, RoutedEventArgs e)
        {
            frmContenido.Content = null;
            Usuario frmUsu = new Usuario();
            frmContenido.Navigate(frmUsu);
        }

        #endregion



        private void tlSalir_Click(object sender, RoutedEventArgs e)
        {

        }

        private void frmContenido_Navigated(object sender, NavigationEventArgs e)
        {
            frmContenido.NavigationService.RemoveBackEntry();
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            lblFecha.Content = DateTime.Today.ToString("D", CultureInfo.CreateSpecificCulture("es-VE"));
            lblUser.Content = usr.nombres + " " + usr.apellidos;
            lblPerfil.Content = usr.strnivel;
            globales.lemp = globales.cargar_lemp();
            globales.idemp = -1;
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("¿Desea cerrar la sesión del usuario actual?", "Cerrar sesión", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                evt = true;
                Login ini = new Login();
                ini.Show();
                this.Close();
            }
        }

        public bool evt=false;

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("¿Desea salir de la aplicación?", "Salir", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                evt = true;
                App.Current.Shutdown();
            }
                
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!evt)
            {
                if (MessageBox.Show("¿Desea salir de la aplicación?", "Salir", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    App.Current.Shutdown();
                else
                    e.Cancel = true;
            }
            
        }

        
    }
}
