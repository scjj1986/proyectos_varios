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
    /// Lógica de interacción para telemarketing.xaml
    /// </summary>
    public partial class telemarketing : Page
    {
        public Principal p;
        bool teleselect = false;
        int id = 0;
        public telemarketing()
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
            Clases.C_Telemarketing tele = new Clases.C_Telemarketing();
            dtgrdtelemarketing.ItemsSource=tele.listarTelemarketing();
        }

        private void BtnNvTelemarketing_Click(object sender, RoutedEventArgs e)
        {
            flNuevo.IsOpen = true;
            flNuevo.Header = "Nuevo teleoperador";
            teleselect = false;
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
            
            Clases.C_Telemarketing newTele = new Clases.C_Telemarketing();
            newTele.id_td = (int)cmbtipo.SelectedValue;
            newTele.doc_iden = txtCedul.Text;
            newTele.nombre = txtNombreN.Text;
            newTele.apellido = txtApellido.Text;
            newTele.correo = txtcorreo.Text;
            newTele.telefono = txtThabitacion.Text;
            newTele.codigo = txtcodigo.Text;
            //newTele.id_locacion =(int) cmbLocacion.SelectedValue;
            if (teleselect == false)
            {
                if (newTele.NuevoTelemarketing() == 1)
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
                newTele.id_telemarketing = id;
                if (newTele.editarTelemarketing() == 1)
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
            teleselect = false;
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
            object tele = dtgrdtelemarketing.SelectedValue;
             if (tele != null)
             {
                
                 tlCancelar.IsEnabled = false;
                 Clases.C_Telemarketing teleSelected = (Clases.C_Telemarketing)tele;
                 id = teleSelected.id_telemarketing;
                 flNuevo.Header = "Datos del teleoperador" + teleSelected.nombre + " " + teleSelected.apellido;
                 flNuevo.IsOpen = true;
                 cmbtipo.SelectedValue = teleSelected.id_td;
                 txtCedul.Text = teleSelected.doc_iden;
                 txtNombreN.Text = teleSelected.nombre;
                 txtApellido.Text = teleSelected.apellido;
                 txtThabitacion.Text = teleSelected.telefono;
                 txtcorreo.Text = teleSelected.correo;
                 //cmbLocacion.SelectedValue = teleSelected.id_locacion; 
                 teleselect = true;
             }
        }

        private void flNuevo_LostFocus(object sender, RoutedEventArgs e)
        {
           // teleselect = false;
        }
    }
}
