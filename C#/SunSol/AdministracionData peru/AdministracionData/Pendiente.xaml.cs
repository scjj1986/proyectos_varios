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
using Clases;
using MahApps.Metro.Controls.Dialogs;
using System.Data;
using System.Windows.Forms;

namespace AdministracionData
{
    /// <summary>
    /// Lógica de interacción para Pendiente.xaml
    /// </summary>
    public partial class Pendiente : Page
    {
        public C_Usuario user;
        public Principal p;

        bool clientSelect = false;
        int statusAnt, idStatusPrinAnt, idSubStatusCitaAnt, tdAnt, tdAntAc;
        string docAnt = "", docAntAc = "", telhabAnt = "", telCel1Ant = "", telCel2Ant = "", telAcAnt = "";

        int id = 0;
        C_Cliente clientSelected;
        public Pendiente()
        {
            InitializeComponent();
        }
        private BindingSource llenarCombo()
        {
            Clases.promotor prom = new Clases.promotor();
            DataTable table = new DataTable();
            table.Columns.Add("id");
            table.Columns.Add("nomnbre");
            table.Columns.Add("apellido");
            foreach (var item in prom.listarpromotor())
            {
                DataRow row = table.NewRow();
                row[0] = item.id_promotor;
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
            C_Cliente cli = new C_Cliente();
            dtgrdclientes.ItemsSource = cli.listarPendientes((int)user.telemark);
                 //llenar los combobox con listas dependiendo del tipo
            
            
            C_TipoDocumento tdoc=new C_TipoDocumento();
            cmbtipo.ItemsSource = tdoc.listarDocumento();
            cmbtipo.DisplayMemberPath = "descripcion";
            cmbtipo.SelectedValuePath = "id_td";

            cmbtipoA.ItemsSource = tdoc.listarDocumento();
            cmbtipoA.DisplayMemberPath = "descripcion";
            cmbtipoA.SelectedValuePath = "id_td";

            C_Pais pais = new C_Pais();
            cmbPais.ItemsSource = pais.listarPaises();
            cmbPais.DisplayMemberPath = "nombre";
            cmbPais.SelectedValuePath = "id_pais";

            statusPrincipal stsp = new statusPrincipal();
            cmbStatusPrincipal.ItemsSource = stsp.listarStatusPrincipal();
            cmbStatusPrincipal.DisplayMemberPath = "descripcion";
            cmbStatusPrincipal.SelectedValuePath = "id_statusPrincipal";
          
            C_Locacion loc = new C_Locacion();
            cmbLocacion.ItemsSource = loc.listarLocaciones();
            cmbLocacion.DisplayMemberPath = "codigo";
            cmbLocacion.SelectedValuePath = "idlocacion";
            cmbtipo.Focus();

            cmbPromotor.ItemsSource = llenarCombo();
            cmbPromotor.DisplayMemberPath = "Value";
            cmbPromotor.SelectedValuePath = "Key";
            //lista de edos civiles
            cmbEdoCivil.Items.Add("CASADO(A)");
            cmbEdoCivil.Items.Add("SOLTERO(A) SOLO(A)");
            cmbEdoCivil.Items.Add("SOLTERO(A) CON PAREJA");
            cmbEdoCivil.Items.Add("VIUDO(A)");
            cmbEdoCivil.Items.Add("DIVORCIADO(A)");
            cmbEdoCivil.Items.Add("CONVIVIENTE");
        }
        private void comboStatus()
        {
            C_Status sts = new C_Status();
            sts.id_statusPrincipal = (int)cmbStatusPrincipal.SelectedValue;
            cmbStatus.ItemsSource = sts.listarStatus();
            cmbStatus.DisplayMemberPath = "descripcion";
            cmbStatus.SelectedValuePath = "id_status";
        }
        private void comboStatusCita()
        {
            statusCita sts = new statusCita();
            // sts.idSubStatus = (int)cmbStatusCita.SelectedValue;
            cmbStatusCita.ItemsSource = sts.listarStatus();
            cmbStatusCita.DisplayMemberPath = "descripcion";
            cmbStatusCita.SelectedValuePath = "idSubStatus";
        }
        private void flNuevo_LostFocus(object sender, RoutedEventArgs e)
        {
            // clientSelect = false;
            //  cmbStatus.SelectedValuePath = "id_status";
        }
        private void tlCancelar_Click(object sender, RoutedEventArgs e)
        {
            cmbtipo.SelectedIndex = -1;
            cmbPais.SelectedIndex = -1;
            cmbLocacion.SelectedIndex = -1;
            cmbStatus.SelectedIndex = -1;
            cmbStatusPrincipal.SelectedIndex = -1;
            cmbStatusCita.SelectedIndex = -1;
            txtCedul.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtcorreo.Text = "";
            txtDireccion.Text = "";
            txtEdad.Text = "";
            cmbEdoCivil.SelectedIndex = -1;

            txtProfesion.Text = "";

            txtTcelular.Text = "";
            //txtTelefono.Text = "";
            txtThabitacion.Text = "";
            txtTcelular2.Text = "";
            dpFechaNac.SelectedDate = null;
            txtobservacion.Text = "";
            txtCedul.SetValue(MahApps.Metro.Controls.TextBoxHelper.WatermarkProperty, "Documento de identidad");
            id = 0;

        }
        private void dtgrdclientes_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            object cli = dtgrdclientes.SelectedItem;
            if (cli != null)
            {
                tlCancelar.IsEnabled = false;                
                clientSelected = (C_Cliente)cli;
                flNuevo.Header = "Datos del prospecto de cliente " + clientSelected.nombre + " " + clientSelected.apellido;
                flNuevo.IsOpen = true;
                cmbtipo.SelectedValue = clientSelected.id_td;
                tdAnt = (int) clientSelected.id_td;
                txtCedul.Text = clientSelected.documento_identidad;
                docAnt = clientSelected.documento_identidad;
                txtNombre.Text = clientSelected.nombre;
                txtApellido.Text = clientSelected.apellido;
                cmbPais.SelectedValue = clientSelected.id_pais;
                txtDireccion.Text = clientSelected.direccion;
                txtThabitacion.Text = clientSelected.t_habitacion;
                telhabAnt = clientSelected.t_habitacion;
                txtTcelular2.Text = clientSelected.t_oficina;
                telCel2Ant = clientSelected.t_oficina;
                txtTcelular.Text = clientSelected.t_celular;
                telCel1Ant = clientSelected.t_celular;
                //cmbStatus.SelectedValue = clientSelected.id_status;
                cmbLocacion.SelectedValue = clientSelected.id_locacion;
                txtcorreo.Text = clientSelected.correo;
                txtProfesion.Text = clientSelected.profesion;
                cmbEdoCivil.SelectedItem = clientSelected.edo_civil;
                txtEdad.Text = clientSelected.edad.ToString();
                dpFechaNac.SelectedDate = clientSelected.f_nacimiento;
                txtobservacion.Text = clientSelected.observacion;
                id = clientSelected.id_cliente;
                clientSelect = true;
                tlAcompanante.IsEnabled = true;
                cmbStatus.IsEnabled = true;
                cmbStatusPrincipal.IsEnabled = true;
                cmbStatusPrincipal.SelectedValue = clientSelected.Id_statusPrincipal;
                comboStatus();
                cmbStatus.SelectedValue = (int) clientSelected.id_status;
                if (clientSelected.Id_subStatusCita == 0)
                    cmbStatusCita.SelectedValue = -1;
                else
                {
                    comboStatusCita();
                    cmbStatusCita.SelectedValue = (int)clientSelected.Id_subStatusCita;
                }
                idStatusPrinAnt = clientSelected.Id_statusPrincipal;
                idSubStatusCitaAnt = clientSelected.Id_subStatusCita.Value;
                statusAnt = clientSelected.id_status.Value;
                cmbtipoA.SelectedValue = clientSelected.id_tdA;
                if( clientSelected.id_tdA!=null)
                tdAntAc = (int)clientSelected.id_tdA;
                txtidentidad.Text = clientSelected.documento_identidadA;
                docAntAc = clientSelected.documento_identidadA;
                txtNombreA.Text = clientSelected.nombreA;
                txtApellidoA.Text = clientSelected.apellidoA;
                txtEdadA.Text = clientSelected.edadA.ToString();
                txtProfesionA.Text = clientSelected.profesionA;
                txtcorreoA.Text = clientSelected.correoA;
                txtTelefonoA.Text = clientSelected.telefonoA;
                telAcAnt = clientSelected.telefonoA;
                cmbPromotor.SelectedValue = clientSelected.idPromotor;
            }            
        
        }
        private async void cmbStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbStatus.SelectedValue != null)
            {
                if (cmbStatus.SelectedValue.ToString().Equals("2"))
                {
                    statusCita sstsc = new statusCita();
                    cmbStatusCita.ItemsSource = sstsc.listarStatus();
                    cmbStatusCita.DisplayMemberPath = "descripcion";
                    cmbStatusCita.SelectedValuePath = "idSubStatus";
                    cmbStatusCita.IsEnabled = true;
                }
                else
                {
                    cmbStatusCita.ItemsSource = null;
                    cmbStatusCita.IsEnabled = false;
                }
                if (!cmbStatus.SelectedValue.Equals(null))
                {
                    if (cmbStatus.SelectedValue.ToString().Equals("11") || cmbStatus.SelectedValue.ToString().Equals("12"))
                    {
                        tlDetalleCita.IsEnabled = true;
                        await p.ShowMessageAsync("Información", "Debe de proporcionar datos de adicionales al estatus", MessageDialogStyle.Affirmative);
                    }
                    else
                        tlDetalleCita.IsEnabled = false;
                }
            }


        }

        private void cmbtipo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (clientSelect == false)
            {
                if (cmbtipo.SelectedIndex != -1)
                {
                    C_TipoDocumento td = (C_TipoDocumento)cmbtipo.SelectedItem;
                    cmbPais.SelectedValue = td.id_pais;
                    cmbPais.IsEnabled = false;
                    txtCedul.SetValue(MahApps.Metro.Controls.TextBoxHelper.WatermarkProperty, td.formato);
                }
            }
        }
        private async void tlGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (txtApellido.Text.Equals("") || txtTcelular.Text.Equals("") || txtNombre.Text.Equals(""))
            {
                await p.ShowMessageAsync("Advertencia", "Debe completar los campos obligatorios", MessageDialogStyle.Affirmative);
                return;
            }
            C_Cliente clieNew = new C_Cliente();
            if (cmbtipo.SelectedValue != null)
                clieNew.id_td = (int)cmbtipo.SelectedValue;
            clieNew.documento_identidad = txtCedul.Text;
            clieNew.nombre = txtNombre.Text;
            clieNew.apellido = txtApellido.Text;
            if (cmbPais.SelectedValue != null)
                clieNew.id_pais = (int)cmbPais.SelectedValue;
            clieNew.direccion = txtDireccion.Text;
            clieNew.t_habitacion = txtThabitacion.Text;
            clieNew.t_celular = txtTcelular.Text;
            clieNew.t_oficina = txtTcelular2.Text;
            if (clientSelect == true)
                clieNew.id_status = (int)cmbStatus.SelectedValue;
            if (cmbLocacion.SelectedValue != null)
                clieNew.id_locacion = (int)cmbLocacion.SelectedValue;
            clieNew.correo = txtcorreo.Text;
            clieNew.profesion = txtProfesion.Text;
            if (!txtEdad.Text.Equals(""))
                clieNew.edad = Convert.ToInt32(txtEdad.Text);
            clieNew.edo_civil = cmbEdoCivil.Text;
            clieNew.f_nacimiento = dpFechaNac.SelectedDate;
            clieNew.asignado = 0;
            clieNew.Id_statusPrincipal = (int)cmbStatusPrincipal.SelectedValue;
            clieNew.id_status = (int)cmbStatus.SelectedValue;
            if (cmbStatusCita.SelectedIndex != -1)
                clieNew.Id_subStatusCita = (int)cmbStatusCita.SelectedValue;
            else
                clieNew.Id_subStatusCita = null;
            clieNew.observacion = txtobservacion.Text;
            if (cmbPromotor.SelectedIndex != -1)
                clieNew.idPromotor = (int)cmbPromotor.SelectedValue;


            if (clientSelect == false)
            {

                if (clieNew.NuevoCliente(App.userApp.iduser) == 1)
                {
                    await p.ShowMessageAsync("Información", "Se ha guardado correctamente", MessageDialogStyle.Affirmative);
                    //MessageBox.Show("Se ha guardado correctamente", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                    // clieNew.registarCambioStatus(App.userApp.iduser);
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
                clieNew.id_cliente = id;

                if (clieNew.editarCliente() == 1)
                {
                    await p.ShowMessageAsync("Información", "Se han actualizado correctamente los datos", MessageDialogStyle.Affirmative);
                    int sts = 0;
                    if (cmbStatusCita.SelectedValue != null)
                    {
                        sts = (int)cmbStatusCita.SelectedValue;
                        if (sts == -1)
                            sts = 0;
                    }
                    if (statusAnt != (int)cmbStatus.SelectedValue || idStatusPrinAnt != (int)cmbStatusPrincipal.SelectedValue || idSubStatusCitaAnt != sts)
                        clieNew.registarCambioStatus(App.userApp.iduser);
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

        private void txtNombre_LostFocus(object sender, RoutedEventArgs e)
        {
            txtNombre.Text = txtNombre.Text.ToUpper();
        }

        private void txtApellido_LostFocus(object sender, RoutedEventArgs e)
        {
            txtApellido.Text = txtApellido.Text.ToUpper();
        }

        private void txtDireccion_LostFocus(object sender, RoutedEventArgs e)
        {
            txtDireccion.Text = txtDireccion.Text.ToUpper();
        }

        private void txtcorreo_LostFocus(object sender, RoutedEventArgs e)
        {
            txtcorreo.Text = txtcorreo.Text.ToUpper();
        }

        private void txtProfesion_LostFocus(object sender, RoutedEventArgs e)
        {
            txtProfesion.Text = txtProfesion.Text.ToUpper();
        }

        private void txtEdoCivil_LostFocus(object sender, RoutedEventArgs e)
        {
            // txtEdoCivil.Text = txtEdoCivil.Text.ToUpper();
        }
        private void txtEdad_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void flNuevo_IsOpenChanged(object sender, RoutedEventArgs e)
        {
            cmbtipo.Focus();
        }

        private void tlAcompanante_Click(object sender, RoutedEventArgs e)
        {
            flAcompanante.IsOpen = true;
        }

        private void cmbtipoA_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (clientSelect == false)
            {
                if (cmbtipoA.SelectedIndex != -1)
                {
                    C_TipoDocumento td = (C_TipoDocumento)cmbtipoA.SelectedItem;
                    txtidentidad.SetValue(MahApps.Metro.Controls.TextBoxHelper.WatermarkProperty, td.formato);
                }
            }
        }

        private void cmbStatusPrincipal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbStatusPrincipal.SelectedValue != null)
            {
                C_Status sts = new C_Status();
                sts.id_statusPrincipal = (int)cmbStatusPrincipal.SelectedValue;
                cmbStatus.ItemsSource = sts.listarStatus();
                cmbStatus.DisplayMemberPath = "descripcion";
                cmbStatus.SelectedValuePath = "id_status";

            }
        }

        private async void cmbStatusCita_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbStatus.SelectedValue != null)
            {
                if (cmbStatus.SelectedValue.ToString().Equals("2") || cmbStatus.SelectedValue.ToString().Equals("11") || cmbStatus.SelectedValue.ToString().Equals("12"))
                {
                    tlDetalleCita.IsEnabled = true;
                    await p.ShowMessageAsync("Información", "Debe de proporcionar datos de adicionales al estatus", MessageDialogStyle.Affirmative);
                }
                else
                    tlDetalleCita.IsEnabled = false;
            }
        }

        private void txtobservacion_LostFocus(object sender, RoutedEventArgs e)
        {
            txtobservacion.Text = txtobservacion.Text.ToUpper();
        }

        private async void tlGuardaAcomp_Click(object sender, RoutedEventArgs e)
        {
            if (cmbtipoA.SelectedIndex == -1 || txtidentidad.Text.Equals("") || txtNombreA.Text.Equals("") || txtApellidoA.Text.Equals(""))
            {
                await p.ShowMessageAsync("Advertencia", "Debe completar los campos obligatorios", MessageDialogStyle.Affirmative);
                return;
            }
            bool editarAcom = false;
            if (clientSelected.verificaAcomp() == 1)
                editarAcom = true;
            clientSelected.id_tdA = (int)cmbtipoA.SelectedValue;
            clientSelected.documento_identidadA = txtidentidad.Text;
            clientSelected.nombreA = txtNombreA.Text;
            clientSelected.apellidoA = txtApellidoA.Text;
            if (!txtEdadA.Text.Equals(""))
                clientSelected.edadA = Convert.ToInt32(txtEdadA.Text);
            clientSelected.telefonoA = txtTelefonoA.Text;
            clientSelected.correoA = txtcorreoA.Text;
            clientSelected.profesionA = txtProfesionA.Text;
            if (editarAcom == false)
            {
                if (clientSelected.NuevoAcomp() == 1)
                {
                    await p.ShowMessageAsync("Información", "Se ha guardado correctamente el acompañante", MessageDialogStyle.Affirmative);
                    flAcompanante.IsOpen = false;
                }
                else
                    await p.ShowMessageAsync("Error", "No se ha guardado los cambios", MessageDialogStyle.Affirmative);
            }
            else
            {
                if (clientSelected.editarAcomp() == 1)
                {
                    await p.ShowMessageAsync("Información", "Se ha actualizado los datos de el acompañante", MessageDialogStyle.Affirmative);
                    flAcompanante.IsOpen = false;
                }
                else
                    await p.ShowMessageAsync("Error", "No se ha guardado los cambios", MessageDialogStyle.Affirmative);
            }
        }

        private void txtNombreA_LostFocus(object sender, RoutedEventArgs e)
        {
            txtNombreA.Text = txtNombreA.Text.ToUpper();
        }

        private void txtApellidoA_LostFocus(object sender, RoutedEventArgs e)
        {
            txtApellidoA.Text = txtApellidoA.Text.ToUpper();
        }

        private void txtProfesionA_LostFocus(object sender, RoutedEventArgs e)
        {
            txtProfesionA.Text = txtProfesionA.Text.ToUpper();
        }

        private void txtcorreoA_LostFocus(object sender, RoutedEventArgs e)
        {
            txtcorreoA.Text = txtcorreoA.Text.ToUpper();
        }

        private void tlDetalleCita_Click(object sender, RoutedEventArgs e)
        {
            DetalleCita dc = new DetalleCita();
            if (cmbStatusCita.SelectedIndex != -1)
                dc.subStatus = (statusCita)cmbStatusCita.SelectedItem;
            if (cmbStatusPrincipal.SelectedIndex != -1 && cmbStatus.SelectedIndex != 1)
            {
                dc.stsP = (statusPrincipal)cmbStatusPrincipal.SelectedItem;
                dc.subStt = (C_Status)cmbStatus.SelectedItem;
            }
            dc.cli = clientSelected;
            dc.Show();
        }

        private async void txtCedul_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!txtCedul.Text.Equals("") && cmbtipo.SelectedValue != null && cmbPais.SelectedValue != null)
            {
                if (tdAnt != (int)cmbtipo.SelectedValue || !docAnt.Equals(txtCedul.Text))
                {
                    C_Usuario cli = new C_Usuario();
                    cli.cedula = txtCedul.Text;
                    if (cli.existeDocIdentidad("cliente", (int)cmbPais.SelectedValue, (int)cmbtipo.SelectedValue) == 1)
                    {
                        await p.ShowMessageAsync("Error", "Existe ya un documento de identidad con ese número", MessageDialogStyle.Affirmative);
                        txtCedul.Text = "";
                        txtCedul.Focus();
                    }
                }
            }
        }

        private async void txtidentidad_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!txtidentidad.Text.Equals("") && cmbtipoA.SelectedValue != null)
            {
                if (tdAntAc != (int)cmbtipoA.SelectedValue || !docAntAc.Equals(txtidentidad.Text))
                {
                    C_Usuario cli = new C_Usuario();
                    cli.cedula = txtidentidad.Text;
                    if (cli.existeDocIdentidad("acomp", 0, (int)cmbtipoA.SelectedValue) == 1)
                    {
                        await p.ShowMessageAsync("Error", "El número ya está registrado", MessageDialogStyle.Affirmative);
                        txtidentidad.Text = "";
                        txtidentidad.Focus();
                    }
                }
            }
        }

        private async void txtThabitacion_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!txtThabitacion.Text.Equals(""))
            {
                if (!telhabAnt.Equals(txtThabitacion.Text))
                {
                    C_Cliente cli = new C_Cliente();
                    if (cli.existeNumero(txtThabitacion.Text) == 1)
                    {
                        await p.ShowMessageAsync("Error", "El número ya está registrado", MessageDialogStyle.Affirmative);
                        txtThabitacion.Text = "";
                        txtThabitacion.Focus();
                    }
                }
            }
        }

        private async void txtTcelular_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!txtTcelular.Text.Equals(""))
            {
                if (!telCel1Ant.Equals(txtTcelular.Text))
                {
                    C_Cliente cli = new C_Cliente();
                    if (cli.existeNumero(txtTcelular.Text) == 1)
                    {
                        await p.ShowMessageAsync("Error", "El número ya está registrado", MessageDialogStyle.Affirmative);
                        txtTcelular.Text = "";
                        txtTcelular.Focus();
                    }
                }
            }
        }

        private async void txtTcelular2_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!txtTcelular2.Text.Equals(""))
            {
                if (!telCel2Ant.Equals(txtTcelular2.Text))
                {
                    C_Cliente cli = new C_Cliente();
                    if (cli.existeNumero(txtTcelular2.Text) == 1)
                    {
                        await p.ShowMessageAsync("Error", "El número ya está registrado", MessageDialogStyle.Affirmative);
                        txtTcelular2.Text = "";
                        txtTcelular2.Focus();
                    }
                }
            }
        }

        private async void txtTelefonoA_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!txtTelefonoA.Text.Equals(""))
            {
                if (!telAcAnt.Equals(txtTelefonoA.Text))
                {
                    C_Cliente cli = new C_Cliente();
                    if (cli.existeNumero(txtTelefonoA.Text) == 1)
                    {
                        await p.ShowMessageAsync("Error", "El número ya está registrado", MessageDialogStyle.Affirmative);
                        txtTelefonoA.Text = "";
                        txtTelefonoA.Focus();
                    }
                }
            }
        }
    }

}
