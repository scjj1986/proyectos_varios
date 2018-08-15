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

namespace AdministracionData
{
    /// <summary>
    /// Lógica de interacción para locacion.xaml
    /// </summary>
    public partial class locacion : Page
    {
        int id = 0;
        bool locacionSelected = false;
        string cod_actual = "";
        public locacion()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Clases.C_Locacion loc = new Clases.C_Locacion();
            dtgrdlocaciones.ItemsSource = loc.listarLocaciones();
        }

        private void BtnNvLocacion_Click(object sender, RoutedEventArgs e)
        {
            flNuevo.IsOpen = true;
            tlCancelar.IsEnabled = true;
            flNuevo.Header = "Nueva locación";
            locacionSelected = false;
            tlCancelar_Click(sender, e);
            
        }

        private void tlGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (txtDescripcion.Text.Equals("") || txtCodigo.Text.Equals("") || txtDireccion.Text.Equals(""))
            {
                MessageBox.Show("Debe completar campos oblgatorios", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            Clases.C_Locacion newLoc = new Clases.C_Locacion();
            newLoc.descripcion = txtDescripcion.Text;
            newLoc.codigo =txtCodigo.Text;
            newLoc.direccion = txtDireccion.Text;
            if (locacionSelected == false)
            {
                if (newLoc.nuevaLocacion() == 1)
                {
                    MessageBox.Show("Se ha guardado correctamente", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                    tlCancelar_Click(sender, e);
                    flNuevo.IsOpen = false;
                    Page_Loaded(sender, e);

                }
                else
                {
                    MessageBox.Show("Error al guardar la locación", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                newLoc.idlocacion = id;
                if (newLoc.editarLocacion() == 1)
                {
                    MessageBox.Show("Se ha actualizado correctamente", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                    tlCancelar_Click(sender, e);
                    flNuevo.IsOpen = false;
                    Page_Loaded(sender, e);
                    locacionSelected = false;

                }
                else
                {
                    MessageBox.Show("Error al actualizar los datos de la locación", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
        }

        private void tlCancelar_Click(object sender, RoutedEventArgs e)
        {
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
            txtDireccion.Text = "";
            id = 0;
            cod_actual = "";
        }

        private void txtDescripcion_LostFocus(object sender, RoutedEventArgs e)
        {
            txtDescripcion.Text = txtDescripcion.Text.ToUpper();
        }

        private void txtDireccion_LostFocus(object sender, RoutedEventArgs e)
        {
            txtDireccion.Text = txtDireccion.Text.ToUpper();
        }

        private void flNuevo_IsOpenChanged(object sender, RoutedEventArgs e)
        {
            txtCodigo.Focus();
        }

        private void dtgrdlocaciones_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            object loc = dtgrdlocaciones.SelectedItem;
            if (loc != null)
            {
                Clases.C_Locacion locac = (Clases.C_Locacion)loc;                
                cod_actual = locac.codigo;
                txtCodigo.Text = locac.codigo.ToString();
                txtDescripcion.Text = locac.descripcion;
                txtDireccion.Text = locac.direccion;
                id = locac.idlocacion;
                flNuevo.IsOpen = true;
                flNuevo.Header = "Datos de la locación " + locac.codigo.ToString();
                locacionSelected = true;
                tlCancelar.IsEnabled = false;
            }
        }

        private void txtCodigo_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!txtCodigo.Text.Equals(""))
            {
                if (!txtCodigo.Text.Equals(cod_actual))
                {
                    Clases.C_Locacion loc = new Clases.C_Locacion();
                    loc.codigo = txtCodigo.Text;
                    if (loc.existeCodigo() == 1)
                    {
                        MessageBox.Show("Ya el código esta asignado a una locación", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                        txtCodigo.Text = "";
                    }
                }
            }
            
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        

        
    }
}
