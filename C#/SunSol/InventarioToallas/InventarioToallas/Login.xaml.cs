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


namespace InventarioToallas
{
    
    public partial class Login : MetroWindow
    {
        public Login()
        {
            InitializeComponent();
            closd = true;
        }

        public bool closd;

        private void btnaceptar_Click(object sender, RoutedEventArgs e)
        {

            
            
            if (txtUsuario.Text.Equals("") || txtClave.Password.Equals(""))
            {
                MessageBox.Show("Debe colocar el usuario y clave", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            Clases.C_Usuario user = new Clases.C_Usuario();
            int resp = user.autenticar(txtUsuario.Text, txtClave.Password);
            if (resp == 1)
            {

                closd = false;
                Principal ap = new Principal();
                ap.user = user;
                this.Close();
                ap.Show();
                return;
            }
            if (resp == 0)
                MessageBox.Show("Usuario o clave incorrecta", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            if (resp == 2)
                MessageBox.Show("No hay conexión con el servidor", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //if (closd)Close();
        }

        private void MetroWindow_Closed(object sender, EventArgs e)
        {
            
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            txtUsuario.Focus();
        }
    }
}
