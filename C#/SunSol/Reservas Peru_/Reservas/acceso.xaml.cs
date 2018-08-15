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
using librerias;

namespace Reservas
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txtusuario.Focus();
        }


        private void btnaceptar_click(object sender, RoutedEventArgs e)
        {
            if (txtusuario.Text.Equals("") || txtclave.Password.Equals(""))
            {
                MessageBox.Show("Debe colocar el usuario y clave", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            usuario user = new usuario();
            if (user.autenticar(txtusuario.Text, txtclave.Password) == 1)
            {
                //MessageBox.Show("Bienvenido "+user.nombres + " " + user.apellidos + " Usuario: " + user.login);
                Reservas.Window1 ap = new Window1();
                ap.Show();
                this.Hide();
                return;
            }
            MessageBox.Show("Usuario o clave incorrecta");
        }
        
        private void btncancelar_click(object sender, RoutedEventArgs e)
        {
            txtclave.Password = "";
            txtusuario.Text = "";
        }

      

       

        

       
    }
}
