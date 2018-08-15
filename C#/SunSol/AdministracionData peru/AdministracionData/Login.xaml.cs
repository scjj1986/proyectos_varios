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


namespace AdministracionData
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class Login: MetroWindow
    {
        public Login()
        {
            InitializeComponent();
        }

        private  void btnaceptar_Click(object sender, RoutedEventArgs e)
        {
            if (txtUsuario.Text.Equals("") || txtClave.Password.Equals(""))
            {
                MessageBox.Show("Debe colocar el usuario y clave", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            Clases.C_Usuario user =new  Clases.C_Usuario();
            int resp = user.autenticar(txtUsuario.Text, txtClave.Password);
            if (resp == 1)
            {
                //MessageBox.Show("Bienvenido "+user.nombres + " " + user.apellidos + " Usuario: " + user.login);
                Principal ap = new Principal();
                ap.user = user;
                App.userApp = user;
                ap.Show();
                this.Hide();
                return;
            }
            if (resp == 0)
                MessageBox.Show("Usuario o clave incorrecta", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            if (resp == 2)
                MessageBox.Show("No hay conexión con el servidor", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
           
            
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
           
            
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            txtUsuario.Focus();
        }

        private void txtClave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnaceptar_Click(sender, e);
            }
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (!txtClave.Password.Equals(""))
                    btnaceptar_Click(sender, e);
            }
        }
    }
}
