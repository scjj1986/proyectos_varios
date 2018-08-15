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

namespace ALegal
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class Login : MetroWindow
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnaceptar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text)){
                MessageBox.Show("Campo usuario vacío", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtClave.Password))
            {
                MessageBox.Show("Campo contraseña vacío", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            usuario usr = new usuario();
            usr.login = txtUsuario.Text.ToUpper();
            usr.clave = txtClave.Password;
            int resp = usr.autenticar();

            if (resp == -1)
                MessageBox.Show("Usuario y/o contraseña incorrecto", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            else if (resp == -2)
                MessageBox.Show("Usuario Inactivo", "Denegado", MessageBoxButton.OK, MessageBoxImage.Error);
            else if (resp==-3)
                MessageBox.Show("Error al consultar Usuario", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                Principal p = new Principal();
                p.usr = usr;
                p.Show();
                this.Close();

            }
        }
    }
}
