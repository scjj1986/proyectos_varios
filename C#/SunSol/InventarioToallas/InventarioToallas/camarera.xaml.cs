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

namespace InventarioToallas
{
    /// <summary>
    /// Lógica de interacción para camarera.xaml
    /// </summary>
    public partial class camarera : Page
    {

        public string accion = "";
        public string nac_actual, ced_actual;
        public camarera()
        {
            InitializeComponent();
        }

        #region CARGA DE LA PÁGINA
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            Clases.C_Camarera cam = new Clases.C_Camarera();
            cmbEstadoCam.Items.Clear();
            cmbEstadoCam.Items.Add("ACTIVO");
            cmbEstadoCam.Items.Add("INACTIVO");
            cmbCedCam.Items.Clear();
            cmbCedCam.Items.Add("V");
            cmbCedCam.Items.Add("E");

            if (cmbSupCam.Items.Count == 0)
            {
                cmbSupCam.Items.Clear();
                cmbSupCam.ItemsSource = null;
                cmbSupCam.ItemsSource = cam.C_Supervisor.listarSupervisores();
                cmbSupCam.SelectedValuePath = "idSupervisor";
                cmbSupCam.DisplayMemberPath = "nombrecompleto";
            }


            dtgrdcam.ItemsSource = cam.listarCamareras();
        }

        #endregion

        #region EVENTO PARA INVOCAR EL FORM (INSERCIÓN)
        private void BtnNvCam_Click(object sender, RoutedEventArgs e)
        {
            flNuevaCam.IsOpen = true;
            flNuevaCam.Header = "Nueva Camarera";
            accion = "INSERTAR";
            limpiarform();

        }
        #endregion

        #region EVENTOS PÉRDIDA DE FOCO EN NOMBRE Y APELLIDO PARA CONVERTIRLOS EN MAYÚSCULA
        private void txtNombreCam_LostFocus(object sender, RoutedEventArgs e)
        {
            txtNombreCam.Text = txtNombreCam.Text.ToUpper();
        }

        private void txtApellidoCam_LostFocus_1(object sender, RoutedEventArgs e)
        {
            txtApellidoCam.Text = txtApellidoCam.Text.ToUpper();
        }

        #endregion

        #region EVENTO PARA CANCELAR EN EL FORM


        private void tlCancelarCam_Click(object sender, RoutedEventArgs e)
        {
            flNuevaCam.IsOpen = false;
            limpiarform();
        }

        #endregion

        private void flNuevaCam_IsOpenChanged(object sender, RoutedEventArgs e)
        {
            if (!flNuevaCam.IsOpen)
            {

                txtBuscarCam.IsEnabled = true;
            }
            else
            {

                txtBuscarCam.IsEnabled = false;
            }
        }

        #region EVENTO GUARDAR EN EL FORM (INSERTAR Y MODIFICAR)

        private void tlGuardarCam_Click(object sender, RoutedEventArgs e)
        {
            if (cmbCedCam.SelectedIndex == -1 || string.IsNullOrWhiteSpace(txtCedulaCam.Text) || string.IsNullOrWhiteSpace(txtNombreCam.Text) || string.IsNullOrWhiteSpace(txtApellidoCam.Text) || cmbEstadoCam.SelectedIndex == -1 || cmbSupCam.SelectedIndex==-1)
            {
                MessageBox.Show("Debe completar campos obligatorios", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            Clases.C_Camarera newCam = new Clases.C_Camarera();
            newCam.nac = cmbCedCam.Text;
            newCam.documento = txtCedulaCam.Text;
            newCam.nombre = txtNombreCam.Text;
            newCam.apellido = txtApellidoCam.Text;
            newCam.activo = cmbEstadoCam.SelectedIndex == 0 ? 1 : 0;
            newCam.idSupervisor = Convert.ToInt32(cmbSupCam.SelectedValue);
            if (accion == "INSERTAR")
            {
                if (newCam.NuevaCamarera() == 1)
                {
                    MessageBox.Show("Se ha guardado correctamente", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                    tlCancelarCam_Click(sender, e);
                    Page_Loaded(sender, e);
                }
                else
                {
                    MessageBox.Show("Error al guardar la camarera", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else 
            {
                newCam.idCamarera = Convert.ToInt32(txtIdCam.Text);
                if (newCam.EditarCamarera() == 1)
                {
                    MessageBox.Show("Se ha modificado correctamente", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                    tlCancelarCam_Click(sender, e);
                    Page_Loaded(sender, e);
                }
                else
                {
                    MessageBox.Show("Error al guardar el supervisor", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        #endregion

        #region EVENTOS PÉRDIDA DE FOCO EN CÉDULA PARA BÚSQUEDA (EVITAR REDUNDANCIA)
        private void cmbCedCam_LostFocus(object sender, RoutedEventArgs e)
        {
            buscarcedula();
        }

       
        private void txtCedulaCam_LostFocus(object sender, RoutedEventArgs e)
        {
            buscarcedula();
        }

        #endregion

        #region EVENTO DOBLECLICK EN FILA DE UNA CAMARERA EN EL DATAGRID (LLAMADA AL FORM PARA EDITAR)

        private void dtgrdcam_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dtgrdcam.SelectedIndex >= 0)
            {

                Clases.C_Camarera cam = dtgrdcam.SelectedItem as Clases.C_Camarera;
                accion = "EDITAR";
                flNuevaCam.Header = "Editar Camarera";
                ced_actual=cam.documento;
                nac_actual=cam.nac;
                llenarform(cam);
                flNuevaCam.IsOpen = true;

            }
        }

        #endregion

        #region EVENTO PARA BUSCAR COINCIDENCIA DE CADA CAMPO EN EL DATAGRID

        private void txtBuscarCam_KeyUp(object sender, KeyEventArgs e)
        {
            
            
                Clases.C_Camarera cam = new Clases.C_Camarera();
                dtgrdcam.ItemsSource=null;
                if (cam.BuscarCamareras(txtBuscarCam.Text).Count > 0)
                {
                    dtgrdcam.ItemsSource = cam.BuscarCamareras(txtBuscarCam.Text);

                }
            
        }

        #endregion

        #region MÉTODO PARA LIMPIAR EL FORM

        public void limpiarform()
        {
            txtIdSupCam.Text = "";
            txtCedulaCam.Text = "";
            txtNombreCam.Text = "";
            txtApellidoCam.Text = "";
            cmbEstadoCam.SelectedIndex = -1;
            cmbCedCam.SelectedIndex = -1;
            cmbSupCam.SelectedIndex = -1;
        }

        #endregion

        #region MÉTODO PARA BÚSQUEDA DE CÉDULA (EVITAR REDUNDANCIA)

        public void buscarcedula()
        {
            if (accion == "INSERTAR")
            {
                if (txtCedulaCam.Text != "")
                {
                    Clases.C_Camarera cam = new Clases.C_Camarera();
                    cam.nac = cmbCedCam.Text;
                    cam.documento = txtCedulaCam.Text;
                    if (cam.existeCedula() == 1)
                    {
                        MessageBox.Show("Existe una camarera con ese número de cédula", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        cmbCedCam.SelectedIndex = -1;
                        txtCedulaCam.Text = "";
                        return;
                    }
                }

            }
            else
            {
                if (txtCedulaCam.Text != "")
                {
                    Clases.C_Camarera cam = new Clases.C_Camarera();
                    cam.idCamarera = Convert.ToInt32(txtIdCam.Text);
                    cam.nac = cmbCedCam.Text;
                    cam.documento = txtCedulaCam.Text;
                    if (cam.existeCedula2() == 1)
                    {
                        MessageBox.Show("Existe otra camarera con ese número de cédula", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        cmbCedCam.Text = nac_actual;
                        txtCedulaCam.Text = ced_actual;
                        return;
                    }
                }
            }
        }

        #endregion

        #region MÉTODO PARA CARGAR DATOS EN EL FORM (EDITAR)

        public void llenarform(Clases.C_Camarera cam)
        {
            txtIdCam.Text = Convert.ToString(cam.idCamarera);
            txtIdSupCam.Text = Convert.ToString(cam.idSupervisor);
            cmbCedCam.Text = cam.nac;
            txtCedulaCam.Text = cam.documento;
            txtNombreCam.Text = cam.nombre;
            txtApellidoCam.Text = cam.apellido;
            cmbEstadoCam.SelectedIndex = Convert.ToInt32(cam.activo) == 1 ? 0 : 1;
            cmbSupCam.SelectedValue = cam.idSupervisor;

        }

        #endregion
    }
}
