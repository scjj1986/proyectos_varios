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
using MahApps.Metro.Controls.Dialogs;

namespace AdministracionData
{
    /// <summary>
    /// Lógica de interacción para confirmador.xaml
    /// </summary>
    public partial class confirmador : Page
    {
        public Principal p;
        bool conselect = false;
        int id = 0;
        public confirmador()
        {
            InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //Clases.C_Locacion loc = new Clases.C_Locacion();
            //cmbLocacion.ItemsSource = loc.listarLocaciones();
            //cmbLocacion.DisplayMemberPath = "codigo";
            //cmbLocacion.SelectedValuePath = "idlocacion";
            Clases.C_TipoDocumento tdoc = new Clases.C_TipoDocumento();
            cmbtipo.ItemsSource = tdoc.listarDocumento();
            cmbtipo.DisplayMemberPath = "descripcion";
            cmbtipo.SelectedValuePath = "id_td";
            Clases.confirmador confi  = new Clases.confirmador();
            dtgrdconfirmador.ItemsSource = confi.listarConfirmador();
        }

        private void BtnNvTelemarketing_Click(object sender, RoutedEventArgs e)
        {
            flNuevo.IsOpen = true;
            flNuevo.Header = "Nuevo confirmador";
            conselect = false;
            tlCancelar.IsEnabled = true;
            tlCancelar_Click(sender, e);
        }

        private void txtNombre_LostFocus(object sender, RoutedEventArgs e)
        {
            txtNombre.Text = txtNombre.Text.ToUpper();
        }

        private void txtApellido_LostFocus(object sender, RoutedEventArgs e)
        {
            txtApellido.Text = txtApellido.Text.ToUpper();
        }


        private void txtcorreo_LostFocus(object sender, RoutedEventArgs e)
        {
            txtcorreo.Text = txtcorreo.Text.ToUpper();
        }

        private async void tlGuardar_Click(object sender, RoutedEventArgs e)
        {

            Clases.confirmador newCon = new Clases.confirmador();
            newCon.id_td = (int)cmbtipo.SelectedValue;
            newCon.doc_iden = txtCedul.Text;
            newCon.nombre = txtNombreN.Text;
            newCon.apellido = txtApellido.Text;
            newCon.correo = txtcorreo.Text;
            newCon.telefono = txtThabitacion.Text;
            //newCon.codigo = txtcodigo.Text;
            //newTele.id_locacion =(int) cmbLocacion.SelectedValue;
            if (conselect == false)
            {
                if (newCon.NuevoConfirmador() == 1)
                {
                    await p.ShowMessageAsync("Información", "Se ha guardado correctamente", MessageDialogStyle.Affirmative);
                    tlCancelar_Click(sender, e);
                    flNuevo.IsOpen = false;
                    Page_Loaded(sender, e);
                }
                else
                {
                    await p.ShowMessageAsync("Error", "Error al guardar el usuario", MessageDialogStyle.Affirmative);
                }
            }
            else
            {
                newCon.id_confirmador = id;
                if (newCon.editarConfirmador() == 1)
                {
                    await p.ShowMessageAsync("Información", "Se han actualizado correctamente los datos", MessageDialogStyle.Affirmative);
                    tlCancelar_Click(sender, e);
                    flNuevo.IsOpen = false;
                    Page_Loaded(sender, e);
                }
                else
                {
                    await p.ShowMessageAsync("Error", "Error al actualizar los datos", MessageDialogStyle.Affirmative);
                }
            }
        }

        private void tlCancelar_Click(object sender, RoutedEventArgs e)
        {
            cmbtipo.SelectedIndex = -1;
            txtCedul.Text = "";
            txtNombreN.Text = "";
            txtApellido.Text = "";
            txtThabitacion.Text = "";
            txtcorreo.Text = "";
            //cmbLocacion.SelectedIndex = -1;
            conselect = false;
            id = 0;

        }

        private void flNuevo_IsOpenChanged(object sender, RoutedEventArgs e)
        {
            cmbtipo.Focus();

        }

        private void cmbtipo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void txtNombreN_LostFocus(object sender, RoutedEventArgs e)
        {
            txtNombreN.Text = txtNombreN.Text.ToUpper();
        }

        private void dtgrdtelemarketing_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            object conf = dtgrdconfirmador.SelectedValue;
            if (conf != null)
            {

                tlCancelar.IsEnabled = false;
                Clases.confirmador conSelected = (Clases.confirmador)conf;
                id = conSelected.id_confirmador;
                flNuevo.Header = "Datos del confirmador " + conSelected.nombre + " " + conSelected.apellido;
                flNuevo.IsOpen = true;
                cmbtipo.SelectedValue = conSelected.id_td;
                txtCedul.Text = conSelected.doc_iden;
                txtNombreN.Text = conSelected.nombre;
                txtApellido.Text = conSelected.apellido;
                txtThabitacion.Text = conSelected.telefono;
                txtcorreo.Text = conSelected.correo;
                //cmbLocacion.SelectedValue = teleSelected.id_locacion; 
                conselect = true;
            }
        }

        private void flNuevo_LostFocus(object sender, RoutedEventArgs e)
        {
            // teleselect = false;
        }

        
    }
}
