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
using System.Security.Cryptography;
using System.Configuration;
using System.IO;

namespace InventarioToallas
{
    /// <summary>
    /// Lógica de interacción para supervisor.xaml
    /// </summary>
    public partial class supervisor : Page
    {
        public supervisor()
        {
            InitializeComponent();
        }

        public string accion;

        public string nac_actual, cedula_actual;

        #region CARGA DE LA PÁGINA
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            cmbEstado.Items.Clear();
            cmbEstado.Items.Add("ACTIVO");
            cmbEstado.Items.Add("INACTIVO");
            cmbCed.Items.Clear();
            cmbCed.Items.Add("V");
            cmbCed.Items.Add("E");
            Clases.C_Supervisor sup = new Clases.C_Supervisor();
            dtgrdsup.ItemsSource = sup.listarSupervisores(); 
        }
        #endregion

        #region MOSTRAR FORMULARIO SUPERVISOR (INSERTAR)

        private void BtnNvSup_Click(object sender, RoutedEventArgs e)
        {
            flNuevo.Header = "Nuevo Supervisor";
            limpiarform();
            flNuevo.IsOpen = true;
            accion = "INSERTAR";
        }

        #endregion

        #region CONVERTIR A MAYÚSCULA CAMPOS NOMBRE Y APELLIDO
        private void txtNombre_LostFocus(object sender, RoutedEventArgs e)
        {
            txtNombre.Text = txtNombre.Text.ToUpper();
        }

        private void txtApellido_LostFocus(object sender, RoutedEventArgs e)
        {
            txtApellido.Text = txtApellido.Text.ToUpper();
        }
        #endregion

        #region CLICK AL GUARDAR (INSERTAR Y EDITAR)
        private void tlGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (cmbCed.SelectedIndex==-1 ||  string.IsNullOrWhiteSpace(txtCedula.Text) || string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellido.Text) || cmbEstado.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe completar campos obligatorios", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                Clases.C_Supervisor newSup = new Clases.C_Supervisor();
                newSup.nac = cmbCed.Text;
                newSup.documento = txtCedula.Text;
                newSup.nombre = txtNombre.Text;
                newSup.apellido = txtApellido.Text;
                newSup.activo = cmbEstado.SelectedIndex == 0 ? 1 : 0;
                if (accion == "INSERTAR")
                {
                    if (newSup.NuevoSupervisor() == 1)
                    {
                        MessageBox.Show("Se ha guardado correctamente", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                        tlCancelar_Click(sender, e);
                        Page_Loaded(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Error al guardar el supervisor", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    newSup.idSupervisor = Convert.ToInt32(txtIdSup.Text);
                    if (newSup.EditarSupervisor() == 1)
                    {
                        MessageBox.Show("Se ha modificado correctamente", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                        tlCancelar_Click(sender, e);
                        Page_Loaded(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Error al guardar el supervisor", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
        }

        #endregion

        #region CANCELAR
        private void tlCancelar_Click(object sender, RoutedEventArgs e)
        {
            limpiarform();
            flNuevo.IsOpen = false;
        }

        #endregion

        #region ELEGIR UN SUPERVISOR EN EL DATAGRID (EDITAR)
        private void dtgrdsup_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            if (dtgrdsup.SelectedIndex >= 0)
            {

                Clases.C_Supervisor sup = dtgrdsup.SelectedItem as Clases.C_Supervisor;
                accion = "EDITAR";
                flNuevo.Header = "Editar Supervisor";
                nac_actual = sup.nac;
                cedula_actual = sup.documento;
                llenarform(sup);
                flNuevo.IsOpen = true;

            }

        }
        #endregion

        #region BUSCAR SUPERVISOR

        private void txtBuscarSup_KeyUp(object sender, KeyEventArgs e)
        {
            
                Clases.C_Supervisor sup = new Clases.C_Supervisor();
                dtgrdsup.ItemsSource = null;
                if (sup.BuscarSupervisores(txtBuscarSup.Text).Count > 0)
                {
                    dtgrdsup.ItemsSource = sup.BuscarSupervisores(txtBuscarSup.Text);

                }
        }

        #endregion

        #region BLOQUEAR/DESBLOQUEAR CAMPO DE BÚSQUEDA AL MOSTRAR/OCULTAR LISTADO DE CAMARERAS

        private void flCamarera_IsOpenChanged(object sender, RoutedEventArgs e)
        {
            if (!flCamarera.IsOpen)
            {

                txtBuscarSup.IsEnabled = true;
            }
            else
            {

                txtBuscarSup.IsEnabled = false;
            }
        }

        #endregion

        #region BLOQUEAR/DESBLOQUEAR CAMPO DE BÚSQUEDA AL MOSTRAR/OCULTAR LISTADO DE SUPERVISORES

        private void flNuevo_IsOpenChanged(object sender, RoutedEventArgs e)
        {
            if (!flNuevo.IsOpen)
            {

                txtBuscarSup.IsEnabled = true;
            }
            else
            {

                txtBuscarSup.IsEnabled = false;
            }
        }

        #endregion

        #region PÉRDIDA DE FOCO EN CÉDULA PARA BÚSQUEDA EN BASE DE DATOS (EVITAR REDUNDANCIA)

        private void cmbCed_LostFocus(object sender, RoutedEventArgs e)
        {
            buscarcedula();
        }

        private void txtCedula_LostFocus(object sender, RoutedEventArgs e)
        {
            buscarcedula();
        }

        #endregion

        #region LISTADO DE CAMARERAS

        //Evento para el listado de camareras

        private void BtnCam_Click(object sender, RoutedEventArgs e)
        {

            if (dtgrdsup.SelectedIndex >= 0)
            {
                Clases.C_Supervisor sup = dtgrdsup.SelectedItem as Clases.C_Supervisor;
                Clases.C_Camarera cam = new Clases.C_Camarera();
                flCamarera.Header = "Listado de Camareras del Sup. " + sup.nombre + " " + sup.apellido;
                flCamarera.IsOpen = true;
                dtgrdcam.ItemsSource = cam.BuscarCamarerasPorSupervisor(sup.idSupervisor);


            }
            else
            {

                MessageBox.Show("Debe elegir un supervisor, presionando click en la fila del mismo", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        #endregion


        //Carga de datos en el formulario de supervisor (Para editar)

        public void llenarform(Clases.C_Supervisor sup)
        {
            txtIdSup.Text = Convert.ToString(sup.idSupervisor);
            cmbCed.Text = sup.nac;
            txtCedula.Text = sup.documento;
            txtNombre.Text = sup.nombre;
            txtApellido.Text = sup.apellido;
            cmbEstado.SelectedIndex = Convert.ToInt32(sup.activo) == 1 ? 0 : 1;
            cmbCed.Text = sup.nac;

        }

        //Método para limpiar el formulario

        public void limpiarform()
        {
            txtIdSup.Text = "";
            txtCedula.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            cmbEstado.SelectedIndex = -1;
            cmbCed.SelectedIndex = -1;
        }

        //Método para validar redundancias en cédulas

        public void buscarcedula()
        {
            if (accion == "INSERTAR")//En la inserción
            {
                if (txtCedula.Text != "")
                {
                    Clases.C_Supervisor sup = new Clases.C_Supervisor();
                    sup.nac = cmbCed.Text;
                    sup.documento = txtCedula.Text;
                    if (sup.existeCedula() == 1)
                    {
                        MessageBox.Show("Existe un supervisor con ese número de cédula", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        cmbCed.SelectedIndex = -1;
                        txtCedula.Text = "";
                        return;
                    }
                }

            }
            else//En modificacion
            {
                if (txtCedula.Text != "")
                {
                    Clases.C_Supervisor sup = new Clases.C_Supervisor();
                    sup.idSupervisor = Convert.ToInt32(txtIdSup.Text);
                    sup.nac = cmbCed.Text;
                    sup.documento = txtCedula.Text;
                    if (sup.existeCedula2() == 1)
                    {
                        MessageBox.Show("Existe otro supervisor con ese número de cédula", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        cmbCed.Text = nac_actual;
                        txtCedula.Text = cedula_actual;
                        return;
                    }
                }
            }
        }

       
        

        

        private void txtBuscarSup_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        
    }
}
