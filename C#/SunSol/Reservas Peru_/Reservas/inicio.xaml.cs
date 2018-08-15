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

namespace Reservas
{
    /// <summary>
    /// Lógica de interacción para prueba.xaml
    /// </summary>
    public partial class inicio : MetroWindow
    {
        public inicio()
        {
            InitializeComponent();
            txtUsuario.Focus();
        }
        private void btnaceptar_click(object sender, RoutedEventArgs e)
        {
            if (txtUsuario.Text.Equals("") || txtClave.Password.Equals(""))
            {
                MessageBox.Show("Debe colocar el usuario y clave", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            usuario user = new usuario();
            int resp=user.autenticar(txtUsuario.Text, txtClave.Password);
            if (resp == 1)
            {
                //MessageBox.Show("Bienvenido "+user.nombres + " " + user.apellidos + " Usuario: " + user.login);

                if (user.coper == 0)
                {
                    MessageBox.Show("Permiso Denegado", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                


                menu ap = new menu();
                ap.user = user;
                ap.Show();
                this.Hide();
                return;
            }
            if (resp == 0)
                MessageBox.Show("Usuario o clave incorrecta", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            if (resp == 2)
                MessageBox.Show("No hay conexión con el servidor", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        

        private void txtClave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnaceptar_click(sender, e);
            }
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (!txtClave.Password.Equals(""))
                    btnaceptar_click(sender, e);
            }
        }

        

       
    }
}
