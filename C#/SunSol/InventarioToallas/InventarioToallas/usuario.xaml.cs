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

    public partial class usuario : Page
    {

        public string nck_actual;
        public usuario()
        {
            InitializeComponent();
        }

        public string accion;

        #region CARGA DE LA PÁGINA
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //Llenar los combos
            cmbTipo.Items.Clear();
            cmbTipo.Items.Add("ADMINISTRADOR");
            cmbTipo.Items.Add("SUPERVISOR");
            cmbTipo.Items.Add("COSTOS");
            cmbTipo.Items.Add("OPERADOR");

            cmbEstado.Items.Clear();
            cmbEstado.Items.Add("ACTIVO");
            cmbEstado.Items.Add("INACTIVO");

            Clases.C_Usuario user = new Clases.C_Usuario();
            dtgrdusuarios.ItemsSource = user.listarUsuario();
            if (dtgrdusuarios.ItemsSource != null)
            {
                foreach (Clases.C_Usuario u in dtgrdusuarios.ItemsSource)
                {
                    switch (u.nivel)
                    {
                        case 0:
                            u.tipo= "ADMINISTRADOR";
                            break;
                        case 1:
                            u.tipo = "SUPERVISOR";
                            break;
                        case 2:
                            u.tipo = "COSTOS";
                            break;
                        case 3:
                            u.tipo = "OPERADOR";
                            break;
                    }
                }
            }
        }

        #endregion

        #region MOSTRAR FORMULARIO USUARIO (INSERTAR)

        private void BtnNvUsuario_Click(object sender, RoutedEventArgs e)
        {
            flNuevo.Header = "Nuevo Usuario";
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

        #region PÉRDIDA DE FOCO EN LOGIN PARA BÚSQUEDA EN BASE DE DATOS (EVITAR REDUNDANCIA)

        private void txtLogin_LostFocus(object sender, RoutedEventArgs e)
        {

            if (accion == "INSERTAR")
            {
                if (txtLogin.Text != "")
                {
                    Clases.C_Usuario us = new Clases.C_Usuario();
                    us.login = txtLogin.Text;
                    if (us.existeLogin() == 1)
                    {
                        MessageBox.Show("Existe un usuario con ese login", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        txtLogin.Text = "";
                        txtLogin.Focus();
                        return;
                    }
                    txtLogin.Text = txtLogin.Text.ToUpper();
                }

            }
            else
            {
                if (txtLogin.Text != "")
                {
                    Clases.C_Usuario us = new Clases.C_Usuario();
                    us.login = txtLogin.Text;
                    us.idUsuario = Convert.ToInt32(txtIdUsuario.Text);
                    if (us.existeLogin2() == 1)
                    {
                        MessageBox.Show("Existe otro usuario con ese login", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        txtLogin.Text = nck_actual;
                        txtLogin.Focus();
                        return;
                    }
                    txtLogin.Text = txtLogin.Text.ToUpper();
                }
            }
        }

        #endregion

        #region BUSCAR USUARIO

        private void txtBuscarUsu_KeyUp(object sender, KeyEventArgs e)
        {

            Clases.C_Usuario usu = new Clases.C_Usuario();
            dtgrdusuarios.ItemsSource = null;
            if (usu.BuscarUsuarios(txtBuscarUsu.Text).Count > 0)
            {
                dtgrdusuarios.ItemsSource = usu.BuscarUsuarios(txtBuscarUsu.Text);

            }
        }

        #endregion

        #region CLICK AL GUARDAR (INSERTAR Y EDITAR)
        private void tlGuardar_Click(object sender, RoutedEventArgs e)
        {
                if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtLogin.Text) || string.IsNullOrWhiteSpace(txtClave.Password) || string.IsNullOrWhiteSpace(txtConfirmar.Password)
                || cmbTipo.SelectedIndex == -1 || cmbEstado.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe completar campos obligatorios", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                Clases.C_Usuario newUser = new Clases.C_Usuario();
                newUser.nombre = txtNombre.Text;
                newUser.apellido = txtApellido.Text;
                newUser.login = txtLogin.Text;
                newUser.clave = txtClave.Password;
                newUser.nivel = cmbTipo.SelectedIndex;
                newUser.activo = cmbEstado.SelectedIndex == 0 ? 1 : 0;
                if (accion == "INSERTAR")
                {
                    if (newUser.NuevoUsuario() == 1)
                    {
                        MessageBox.Show("Se ha guardado correctamente", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                        tlCancelar_Click(sender, e);
                        Page_Loaded(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Error al guardar el usuario", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    newUser.idUsuario = Convert.ToInt32(txtIdUsuario.Text);
                    if (newUser.EditarUsuario() == 1)
                    {
                        MessageBox.Show("Se ha modificado correctamente", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                        tlCancelar_Click(sender, e);
                        Page_Loaded(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Error al guardar el usuario", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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

        #region ELEGIR UN USUARIO EN EL DATAGRID (EDITAR)
        private void dtgrdusuarios_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            if (dtgrdusuarios.SelectedIndex >= 0)
            {

                Clases.C_Usuario us = dtgrdusuarios.SelectedItem as Clases.C_Usuario;
                nck_actual = us.login;
                accion = "EDITAR";
                flNuevo.Header = "Editar Usuario";
                llenarform(us);
                flNuevo.IsOpen = true;
            }

        }

        #endregion

        #region PÉRDIDA DE FOCO EN LAS CONTRASEÑAS PARA VALIDAR COINCIDENCIA
        private void txtConfirmar_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtConfirmar.Password != "")
            {
                if (txtClave.Password != "")
                {
                    if (!txtClave.Password.Equals(txtConfirmar.Password))
                    {
                        MessageBox.Show("No coinciden las claves", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        txtConfirmar.Password = "";
                    }
                }
            }
        }

        #endregion
        //Método para limpiar el formulario
        public void limpiarform()
        {
            txtIdUsuario.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtLogin.Text = "";
            txtClave.Password = "";
            txtConfirmar.Password = "";
            cmbTipo.SelectedIndex = -1;
            cmbEstado.SelectedIndex = -1;
        }

        //Carga de datos en el formulario de usuario (Para editar)
        public void llenarform(Clases.C_Usuario usuario)
        {
            txtIdUsuario.Text = Convert.ToString(usuario.idUsuario);
            txtNombre.Text = usuario.nombre;
            txtApellido.Text = usuario.apellido;
            txtLogin.Text = usuario.login;
            txtClave.Password = usuario.clave;
            txtConfirmar.Password = usuario.clave;
            cmbTipo.SelectedIndex = Convert.ToInt32(usuario.nivel);
            cmbEstado.SelectedIndex = Convert.ToInt32(usuario.activo) == 1 ? 0 : 1;

        }


        

        private void ojo_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            txtClaveoculta.Visibility = System.Windows.Visibility.Visible;
            txtClave.Visibility = System.Windows.Visibility.Hidden;
            txtClaveoculta.Text = txtClave.Password;
        }

        private void ojo_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            txtClaveoculta.Visibility = System.Windows.Visibility.Hidden;
            txtClave.Visibility = System.Windows.Visibility.Visible;
        }

        private void ojo_1_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            txtConfirmaroculta.Visibility = System.Windows.Visibility.Visible;
            txtConfirmar.Visibility = System.Windows.Visibility.Hidden;
            txtConfirmaroculta.Text = txtConfirmar.Password;
        }

        private void ojo_1_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            txtConfirmaroculta.Visibility = System.Windows.Visibility.Hidden;
            txtConfirmar.Visibility = System.Windows.Visibility.Visible;
        }

        private void dtgrdusuarios_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
        }
        
    }
}
