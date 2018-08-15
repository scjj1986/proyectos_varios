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
    /// Lógica de interacción para configuracion.xaml
    /// </summary>
    public partial class configuracion : Page
    {
        public configuracion()
        {
            InitializeComponent();
        }

        private void tlGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (txtdescripcion.Text.Equals("") || txtFormato.Text.Equals("") )
            {
                MessageBox.Show("Debe completar campos oblgatorios", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            Clases.C_TipoDocumento newDoc = new Clases.C_TipoDocumento();
            newDoc.descripcion = txtdescripcion.Text;
            newDoc.formato = txtFormato.Text;
            newDoc.id_pais = (int)cmbpais.SelectedValue;
            if (newDoc.nuevoDocumento() == 1)
            {
                MessageBox.Show("Se ha guardado correctamente", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                tlCancelar_Click(sender, e);
               
            }
            else
            {
                MessageBox.Show("Error al guardar el documento", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txtdescripcion_LostFocus(object sender, RoutedEventArgs e)
        {
            txtdescripcion.Text = txtdescripcion.Text.ToUpper();
        }

        private void tlCancelar_Click(object sender, RoutedEventArgs e)
        {
            cmbpais.SelectedIndex = -1;
            txtdescripcion.Text = "";
            txtFormato.Text = "";
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Clases.C_Pais pais = new Clases.C_Pais();
            cmbpais.ItemsSource = pais.listarPaises();
            cmbpais.DisplayMemberPath = "nombre";
            cmbpais.SelectedValuePath = "id_pais";
        }

        private void tlGuardarPais_Click(object sender, RoutedEventArgs e)
        {
            if (txtnombre.Text.Equals(""))
            {
                MessageBox.Show("Debe completar campos oblgatorios", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            Clases.C_Pais paisNew = new Clases.C_Pais();
            paisNew.nombre = txtnombre.Text;
            if (paisNew.nuevoPais() == 1)
            {
                MessageBox.Show("Se ha guardado correctamente", "Información", MessageBoxButton.OK, MessageBoxImage.Information);                
                tlCancelarpais_Click(sender, e);
                Page_Loaded(sender, e);

            }
            else
            {
                MessageBox.Show("Error al guardar el documento", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void tlCancelarpais_Click(object sender, RoutedEventArgs e)
        {
            txtnombre.Text = "";
        }

        private void txtnombre_LostFocus(object sender, RoutedEventArgs e)
        {
            txtnombre.Text = txtnombre.Text.ToUpper();
        }
    }
}
