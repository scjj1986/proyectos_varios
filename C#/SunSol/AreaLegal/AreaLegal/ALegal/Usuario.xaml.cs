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
using MahApps.Metro.Controls;
using MahApps.Metro.Behaviours;
using System.Globalization;

namespace ALegal
{
    /// <summary>
    /// Lógica de interacción para Usuario.xaml
    /// </summary>
    public partial class Usuario : Page
    {
        public Usuario()
        {
            InitializeComponent();
        }


        public List<usuario> l = new List<usuario>();

        public usuario u = new usuario();

        
        private void dtgUsr_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            if (dtgUsr.ItemsSource != null)
            {
                usuario item = dtgUsr.SelectedItem as usuario;
                u.id = item.id;
                u.nac = item.nac;
                u.ndoc = item.ndoc;
                u.login = item.login;
                u.clave = item.clave;

                cmbNac.Text = item.nac;
                txtCedUsr.Text = item.ndoc;
                txtNomUsr.Text = item.nombres;
                txtApeUsr.Text = item.apellidos;
                txtEmailUsr.Text = item.email;
                cmbPerfilUsr.SelectedValue = item.idnivel;
                txtLgnUsr.Text = item.login;
                cmbEst.SelectedValue = item.idestatus;
            }
            
            
        }

        private void txtLgnUsr_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtLgnUsr.Text))
            {

                u.login = txtLgnUsr.Text;
                if (u.existe_login())
                {
                    MessageBox.Show("El login debe ser irrepetible", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    if (u.id == -1)
                        txtLgnUsr.Text = "";
                    else
                        txtLgnUsr.Text = u.login;

                }


            }
        }

        public void copiar_form()
        {
            u.nac = cmbNac.Text;
            u.ndoc = txtCedUsr.Text;
            u.nombres = txtNomUsr.Text;
            u.apellidos = txtApeUsr.Text;
            u.email = txtEmailUsr.Text;
            u.idnivel = Convert.ToInt32(cmbPerfilUsr.SelectedValue);
            u.login = txtLgnUsr.Text;
            if (u.id == -1 || (u.id != -1 && txtClvUsr.Password != ""))
            {
                u.clave = txtClvUsr.Password;
                u.clave = u.clave_md5();
            }
                
            u.idestatus = Convert.ToInt32(cmbEst.SelectedValue);
        }


        public void filtrar_coincidencias_datagrid()
        {
            List<usuario> laux = new List<usuario>();
            usuario nvo;
            foreach (usuario item in l)
            {
                if (item.ndoc.Contains(txtBsqUsu.Text) || item.nombres.Contains(txtBsqUsu.Text.ToUpper()) || item.email.Contains(txtBsqUsu.Text.ToUpper()) || item.login.Contains(txtBsqUsu.Text.ToUpper()) || item.login.Contains(txtBsqUsu.Text.ToUpper()) || item.strnivel.Contains(txtBsqUsu.Text.ToUpper()) || item.strestatus.Contains(txtBsqUsu.Text.ToUpper()))
                {
                    nvo = new usuario();
                    nvo.id = item.id;
                    nvo.idnivel = item.idnivel;
                    nvo.idestatus = nvo.idestatus;
                    nvo.nac = item.nac;
                    nvo.ndoc = item.ndoc;
                    nvo.cedula = nvo.nac + "-" + nvo.ndoc;
                    nvo.nombres = item.nombres;
                    nvo.apellidos = item.apellidos;
                    nvo.login = item.login;
                    nvo.idnivel = item.idnivel;
                    nvo.idestatus = item.idestatus;
                    nvo.email = item.email;
                    nvo.strnivel = item.strnivel;
                    nvo.strestatus = item.strestatus;
                    laux.Add(nvo);
                }
            }
            dtgUsr.ItemsSource = laux;
        }

        private void txtBsqUsu_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtBsqUsu.Text != "")
                filtrar_coincidencias_datagrid();
            else
                dtgUsr.ItemsSource = l;
                

        }

        private void btnGuardaUsr_Click(object sender, RoutedEventArgs e)
        {
            if (cmbNac.Text == "")
            {
                MessageBox.Show("Campo Nacionalidad vacío", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCedUsr.Text))
            {
                MessageBox.Show("Campo Cédula vacío", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNomUsr.Text))
            {
                MessageBox.Show("Campo Nombre vacío", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtApeUsr.Text))
            {
                MessageBox.Show("Campo Apellido vacío", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEmailUsr.Text))
            {
                MessageBox.Show("Campo E-mail vacío", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(cmbPerfilUsr.Text))
            {
                MessageBox.Show("Campo Perfil vacío", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (u.id == -1 && (string.IsNullOrWhiteSpace(txtClvUsr.Password) || string.IsNullOrWhiteSpace(txtClv2Usr.Password)))
            {
                MessageBox.Show("Los campos de contraseña no deben estar vacíos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;

            }
            if (u.id != 1 && (!string.IsNullOrWhiteSpace(txtClvUsr.Password) || !string.IsNullOrWhiteSpace(txtClv2Usr.Password)) && (string.IsNullOrWhiteSpace(txtClvUsr.Password) || string.IsNullOrWhiteSpace(txtClv2Usr.Password)))
            {
                MessageBox.Show("Si desea cambiar la contraseña, debe ingresar la misma en sus campos correspondientes", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (txtClvUsr.Password != txtClv2Usr.Password)
            {
                MessageBox.Show("Las contraseñas no coinciden", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (txtClvUsr.Password.Length > 0 && txtClvUsr.Password.Length < 6)
            {
                MessageBox.Show("La contraseña debe tener un mínimo de seis (6) caracteres", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            copiar_form();

            u.guardar_editar();
            MessageBox.Show("Datos guardados satisfactoriamente", "Completado", MessageBoxButton.OK, MessageBoxImage.Information);
            limpiar_form();
            recargar_lista_y_datagrid();
        }

        private void btnNuevoUsr_Click(object sender, RoutedEventArgs e)
        {
            
            limpiar_form();
            btnGuardaUsr.IsEnabled = true;
        }

        private void txtCedUsr_LostFocus(object sender, RoutedEventArgs e)
        {
            existe_cedula();
        }

        private void cmbNac_LostFocus(object sender, RoutedEventArgs e)
        {
            existe_cedula();
        }

        public void existe_cedula()
        {
            if (!string.IsNullOrWhiteSpace(cmbNac.Text) && !string.IsNullOrWhiteSpace(txtCedUsr.Text)){
                
                u.nac = cmbNac.Text;
                u.ndoc = txtCedUsr.Text;
                if (u.existe_cedula())
                {
                    MessageBox.Show("La cédula debe ser irrepetible", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    if (u.id == -1)
                    {
                        cmbNac.Text = "";
                        txtCedUsr.Text = "";
                    }
                    else
                    {
                        cmbNac.Text = u.nac;
                        txtCedUsr.Text = u.ndoc;
                    }

                }
                    

            }
        }


        public void limpiar_form()
        {
            
            cmbNac.Text = "";
            cmbPerfilUsr.SelectedValue = -1;
            txtCedUsr.Text = "";
            txtNomUsr.Text = "";
            txtApeUsr.Text = "";
            txtEmailUsr.Text = "";
            txtLgnUsr.Text = "";
            txtClvUsr.Password = "";
            txtClv2Usr.Password = "";
            cmbEst.Text = "";
            u.id = -1;

        }

        public void cargar_cmbs()
        {
            cmbNac.Items.Add("V");
            cmbNac.Items.Add("E");
            cmbNac.Text = "V";
            u = new usuario();
            cmbPerfilUsr.ItemsSource = u.lista_niveles();
            cmbPerfilUsr.DisplayMemberPath = "strnivel";
            cmbPerfilUsr.SelectedValuePath = "idnivel";
            cmbEst.ItemsSource = u.lista_estatus();
            cmbEst.DisplayMemberPath = "strestatus";
            cmbEst.SelectedValuePath = "idestatus";
            //cmbPerfilUsr.


        }

        public void recargar_lista_y_datagrid()
        {
            
            l = u.lista_usuarios();
            dtgUsr.ItemsSource = l;
        }


        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            cargar_cmbs();
            limpiar_form();
            recargar_lista_y_datagrid();
        }

        
    }
}
