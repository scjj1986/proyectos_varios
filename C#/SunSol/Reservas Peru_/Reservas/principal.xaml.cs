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
using librerias;
using System.Data.SqlClient;

namespace Reservas
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    /// 
    
    public partial class Window1 : Window
    {
        int n_contrato = 0;

        public Window1()
        {
            InitializeComponent();
            txtcedula.Focus();
            hotel h = new hotel();
            SqlDataReader sr= h.buscar_hoteles();
           
            int i = 0;
            while (sr.Read()) { 
                 lstHotel.Items.Add(sr.GetString(i));               
            }
            
            
        }

        private void txtcedula_KeyUp(object sender, KeyEventArgs e)
        {
            cliente cli = new cliente();
            if (cli.buscar_cliente(txtcedula.Text) == 1)
            {
                lblValorNombre.Content = cli.nombres + " " + cli.apellidos;
                lblValorDireccion.Content = cli.direccion;
                lblValorTelefonos.Content = cli.telefono1 + " / " + cli.telefono2 + " / " + cli.telefono3;
                lblValorEmail.Content = cli.email;
                lblValorTotalPuntos.Content = cli.totalPuntos;
                lblValorPuntosConsumidos.Content = cli.puntosConsumidos;
                lblValorPuntosDisponibles.Content = cli.puntosDisponibles;
                SqlDataReader dr = cli.buscar_contratos(txtcedula.Text);
                dtgrdContratos.ItemsSource = dr;
                return;
            }
            dtgrdContratos.ItemsSource = null;
            dtgrdPuntosPorAnio.ItemsSource = null;
            lblValorNombre.Content = "";
            lblValorDireccion.Content = "";
            lblValorTelefonos.Content = "";
            lblValorEmail.Content = "";
            lblValorTotalPuntos.Content = "";
            lblValorPuntosConsumidos.Content = "";
            lblValorPuntosDisponibles.Content = "";

        }

       

        private void principal_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("¿Desea salir de la aplicación?", "Salir", MessageBoxButton.YesNo,MessageBoxImage.Question) == MessageBoxResult.Yes)
                App.Current.Shutdown();
            else{
                Window1 w=new Window1();
                w.Show();
            }
        }

       

        private void dtgrdContratos_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            cliente cli = new cliente();
            object item = dtgrdContratos.SelectedItem;
            n_contrato =Convert.ToInt32( (dtgrdContratos.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
            lblValorNcontrato.Content = n_contrato.ToString();
            dtgrdPuntosPorAnio.ItemsSource = cli.buscar_puntos(txtcedula.Text, n_contrato);
        }

        private void lstHotel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            hotel h = new hotel();
            SqlDataReader sr = h.buscar_habitacion(lstHotel.SelectedItem.ToString());
            int i = 0;
            lstHabitacion.Items.Clear();
            while (sr.Read())
            {
                lstHabitacion.Items.Add(sr.GetString(i));               
            }
        }

        private void lstHabitacion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstHabitacion.Items.Count > 0) { 
            hotel h = new hotel();
            h.buscar_capacidad(lstHabitacion.SelectedItem.ToString());
            lblValorCapacidad.Content = h.capacidad.ToString();
            }
            if (lstHabitacion.SelectedIndex==-1)
            {
                lblValorCapacidad.Content = "";
            }
        }

        private void dpFechaI_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            String[] fecha = dpFechaI.SelectedDate.Value.ToString().Split('/');
           // int anioAc
        }

      
    }
}

