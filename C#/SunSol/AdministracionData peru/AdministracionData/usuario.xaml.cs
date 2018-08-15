using MetroFramework;

using MetroFramework.Interfaces;
using MetroFramework.Controls;
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
using System.Windows.Forms;
using Clases;
using System.Data;


namespace AdministracionData
{
    /// <summary>
    /// Lógica de interacción para usuario.xaml
    /// </summary>
    public partial class usuario : Page
    {
        bool usuarioSelected=false;
        int id = 0;
        
        public usuario()
        {
            InitializeComponent();
        }
        private BindingSource llenarCombo()
        {
            C_Telemarketing tele = new C_Telemarketing();
            DataTable table = new DataTable();
            table.Columns.Add("id");
            table.Columns.Add("nomnbre");
            table.Columns.Add("apellido");
            foreach (var item in tele.listarTelemarketing())
            {
                DataRow row = table.NewRow();
                row[0] = item.id_telemarketing;
                row[1] = item.nombre;
                row[2] = item.apellido;
                table.Rows.Add(row);
            }
            DataRowCollection rows = table.Rows;

            object[] cell;
            Dictionary<int, string> dic = new Dictionary<int, string>();
            BindingSource binding = new BindingSource();

            foreach (DataRow item in rows)
            {
                cell = item.ItemArray;

                dic.Add(Convert.ToInt32(cell[0]), cell[1].ToString() + " " + cell[2].ToString());

                cell = null;
            }

            binding.DataSource = dic;
            return binding;
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //Llenar los combos
            cmbTipo.Items.Clear();
            cmbTipo.Items.Add("ADMINISTRADOR");
            cmbTipo.Items.Add("CONFIRMADOR");
            cmbTipo.Items.Add("TELEMARKETING");

            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("ACTIVO");
            cmbStatus.Items.Add("INACTIVO");

            cmbPre1.Items.Clear();
            cmbPre1.Items.Add("¿Cuál es su color favorito?");
            cmbPre1.Items.Add("¿Cuál es su comida favorita?");
            cmbPre1.Items.Add("¿Cuál es su película favorita?");
            cmbPre1.Items.Add("¿Cuál es el nombre de su mascota?");
            cmbPre1.Items.Add("¿Cuál es su canción favorita?");

            Clases.C_Usuario user = new Clases.C_Usuario();
            dtgrdusuarios.ItemsSource = user.listarUsuario();
            if (dtgrdusuarios.ItemsSource != null)
            {
                foreach (Clases.C_Usuario u in dtgrdusuarios.ItemsSource)
                {
                    if (u.status == 0)
                    {
                        u.estatus = "INACTIVO";
                        u.IsSelected = false;
                    }
                    else
                    {
                        u.estatus = "ACTIVO";
                        u.IsSelected = true;
                    }
                    switch (u.nivel)
                    {
                        case 0:
                            u.tipo = "ADMINISTRADOR";
                            break;
                        case 1:
                             u.tipo = "CONFIRMADOR";
                            break;
                        case 2:
                            u.tipo = "TELEMARKETING";
                            break;
                    }
                }

            }
            //llenar los combobox con listas dependiendo del tipo
            C_Telemarketing tele = new C_Telemarketing();
            cmbTelemarketing.ItemsSource = llenarCombo();
            cmbTelemarketing.DisplayMemberPath = "Value";
            cmbTelemarketing.SelectedValuePath = "Key";

        }
        //Visualizar lo que tienen los campos de password (3 imagenes) --->
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

        private void ojo_2_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            txtRespuestaoculta.Visibility = System.Windows.Visibility.Visible;
            txtResp1.Visibility = System.Windows.Visibility.Hidden;
            txtRespuestaoculta.Text = txtResp1.Password;
        }

        private void ojo_2_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            txtRespuestaoculta.Visibility = System.Windows.Visibility.Hidden;
            txtResp1.Visibility = System.Windows.Visibility.Visible;
        }
        //                                                      <-----
        private void BtnNvUsuario_Click(object sender, RoutedEventArgs e)
        {
            flNuevo.IsOpen = true;
            usuarioSelected = false;
            flNuevo.Header = "Nuevo usuario";
            tlCancelar_Click(sender, e);
            tlCancelar.IsEnabled = true;
            cmbStatus.Visibility = Visibility.Hidden;
        }

        private void txtNombre_LostFocus(object sender, RoutedEventArgs e)
        {
            txtNombre.Text = txtNombre.Text.ToUpper();
        }

        private void txtApellido_LostFocus(object sender, RoutedEventArgs e)
        {
            txtApellido.Text = txtApellido.Text.ToUpper();
        }

        private void txtLogin_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtLogin.Text != "" && usuarioSelected == false)
            {
                Clases.C_Usuario us = new Clases.C_Usuario();
                us.login = txtLogin.Text;
                if (us.existeLogin() == 1)
                {
                    System.Windows.MessageBox.Show("Existe un usuario con ese login", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtLogin.Text = "";
                    txtLogin.Focus();
                    return;
                }
                txtLogin.Text = txtLogin.Text.ToUpper();
            }
        }
       
        private void tlGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (txtCedula.Text.Equals("")||txtNombre.Text.Equals("")||txtLogin.Text.Equals("")||txtClave.Password.Equals("")||txtConfirmar.Password.Equals("")
                || cmbTipo.SelectedIndex == -1 || cmbPre1.SelectedIndex == -1 || txtResp1.Password.Equals(""))
            {
                System.Windows.MessageBox.Show("Debe completar campos oblgatorios", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            Clases.C_Usuario newUser = new Clases.C_Usuario();
            newUser.cedula = txtCedula.Text;
            newUser.nombre = txtNombre.Text;
            newUser.apellido = txtApellido.Text;
            newUser.login = txtLogin.Text;
            newUser.pass = txtClave.Password;
            newUser.nivel = cmbTipo.SelectedIndex;
            newUser.status = 1;
            newUser.pregunta = cmbPre1.Text;
            newUser.respuesta = txtResp1.Password;
            if (cmbTelemarketing.SelectedValue == null)
                newUser.telemark = null;
            else
                newUser.telemark = (int)cmbTelemarketing.SelectedValue;
            if (usuarioSelected == false)
            {
                if (newUser.NuevoUsuario() == 1)
                {
                    System.Windows.MessageBox.Show("Se ha guardado correctamente", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                    tlCancelar_Click(sender, e);
                    flNuevo.IsOpen = false;
                    Page_Loaded(sender, e);
                }
                else
                {
                    System.Windows.MessageBox.Show("Error al guardar el usuario", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                newUser.iduser = id;
                if (cmbStatus.SelectedItem.ToString().Equals("ACTIVO"))
                    newUser.status = 1;
                else
                    newUser.status = 0;
                if (newUser.editarUsuario() == 1)
                {
                    System.Windows.MessageBox.Show("Se ha actualizado correctamente", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                    tlCancelar_Click(sender, e);
                    flNuevo.IsOpen = false;
                    Page_Loaded(sender, e);
                }
            }
        }
    

        private void txtCedula_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtCedula.Text != "" && usuarioSelected==false)
            {
                Clases.C_Usuario us = new Clases.C_Usuario();
                us.cedula = txtCedula.Text;
                if (us.existeDocIdentidad("usuario",-1,-1) == 1)
                {
                    System.Windows.MessageBox.Show("Existe un usuario con ese documento de identidad", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtCedula.Text = "";
                    txtCedula.Focus();
                    return;
                }
            
            }
        }

        private void txtConfirmar_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtConfirmar.Password != "")
            {
                if (txtClave.Password != "")
                {
                    if (!txtClave.Password.Equals(txtConfirmar.Password))
                    {
                        System.Windows.MessageBox.Show("No coinciden las claves", "Error", MessageBoxButton.OK, MessageBoxImage.Error);                        
                        txtConfirmar.Password = "";
                    }
                }
            }
        }

        private void tlCancelar_Click(object sender, RoutedEventArgs e)
        {
            txtCedula.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtLogin.Text = "";
            txtClave.Password = "";
            txtConfirmar.Password = "";
            cmbTipo.SelectedIndex = -1;
            cmbPre1.SelectedIndex = -1;
            txtResp1.Password = "";
            id = 0;
            usuarioSelected = false;
        }

        private void dtgrdusuarios_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
             object us = dtgrdusuarios.SelectedItem;
             if (us != null)
             {
                 Clases.C_Usuario usu = (Clases.C_Usuario)us;
                 txtCedula.Text = usu.cedula;
                 txtNombre.Text = usu.nombre;
                 txtApellido.Text = usu.apellido;
                 txtLogin.Text = usu.login;
                 txtClave.Password = usu.pass;
                 txtConfirmar.Password = usu.pass;
                 switch (usu.nivel)
                 {
                     case 0:
                         cmbTipo.SelectedItem = "ADMINISTRADOR";
                         break;
                     case 1:
                         cmbTipo.SelectedItem = "OPERADOR";
                         break;
                     case 2:
                         cmbTipo.SelectedItem = "TELEMARKETING";
                         break;
                 }
                 cmbPre1.SelectedItem = usu.pregunta;
                 txtResp1.Password = usu.respuesta;
                 id = usu.iduser;
                 usuarioSelected = true;
                 flNuevo.IsOpen = true;
                 flNuevo.Header = "Datos del usuario " + usu.login;
                 tlCancelar.IsEnabled = false;
                 cmbStatus.Visibility = Visibility.Visible;
                 if (usu.status == 1)
                     cmbStatus.SelectedItem = "ACTIVO";
                 else
                     cmbStatus.SelectedItem = "INACTIVO";
                 if (usu.telemark == -1)
                     cmbTelemarketing.SelectedIndex = -1;
                 else
                     cmbTelemarketing.SelectedValue = usu.telemark;


             
             }
        }

        private void dtgrdusuarios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void cmbTipo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbTipo.SelectedIndex == 2)
                cmbTelemarketing.IsEnabled = true;
            else
                cmbTelemarketing.IsEnabled = false;
        }
        
    }
}
