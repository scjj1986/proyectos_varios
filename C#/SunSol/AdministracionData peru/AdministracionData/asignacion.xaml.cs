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
using System.Data;
using System.Windows.Forms;
using MahApps.Metro.Controls.Dialogs;


namespace AdministracionData
{
    /// <summary>
    /// Lógica de interacción para asignacion.xaml
    /// </summary>
    public partial class asignacion : Page
    {
        public Principal p;
        public asignacion()
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
                row[2] = item.codigo;
                table.Rows.Add(row);
            }
            DataRowCollection rows = table.Rows;

            object[] cell;
            Dictionary<int, string> dic = new Dictionary<int, string>();
            BindingSource binding = new BindingSource();

            foreach (DataRow item in rows)
            {
                cell = item.ItemArray;

                dic.Add(Convert.ToInt32(cell[0]), cell[2].ToString());

                cell = null;
            }

            binding.DataSource = dic;
            return binding;
        }
        private BindingSource llenarComboConfirmador()
        {
            Clases.confirmador tele = new Clases.confirmador();
            DataTable table = new DataTable();
            table.Columns.Add("id");
            table.Columns.Add("nomnbre");
            table.Columns.Add("apellido");
            foreach (var item in tele.listarConfirmador())
            {
                DataRow row = table.NewRow();
                row[0] = item.id_confirmador;
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
            //llenar los combobox con listas teleoperador           
            cmbTelemarketing.ItemsSource = llenarCombo();
            cmbTelemarketing.DisplayMemberPath = "Value";
            cmbTelemarketing.SelectedValuePath = "Key";

            //llenar los combobox con listas confirmador           
            cmbConfirmador.ItemsSource = llenarComboConfirmador();
            cmbConfirmador.DisplayMemberPath = "Value";
            cmbConfirmador.SelectedValuePath = "Key";

            //llenar los combobox con listas locacion
            C_Locacion loc = new C_Locacion();
            cmbLocacion.ItemsSource = loc.listarLocaciones();
            cmbLocacion.DisplayMemberPath = "codigo";
            cmbLocacion.SelectedValuePath = "idlocacion";
        }

        private void txtCantidad_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (!txtCantidad.Text.Equals(""))
            {
                C_Cliente cli = new C_Cliente();
                dtgrdclientes.ItemsSource = cli.listarAsignacion(Convert.ToInt16(txtCantidad.Text),null,null,null);
                if (dpFechaDesdeTele.SelectedDate != null && dpFechaHastaTele.SelectedDate != null && cmbLocacion.SelectedValue==null)
                    dtgrdclientes.ItemsSource = cli.listarAsignacion(Convert.ToInt16(txtCantidad.Text),dpFechaDesdeTele.SelectedDate.Value, dpFechaHastaTele.SelectedDate.Value,null);
                if (dpFechaDesdeTele.SelectedDate == null && dpFechaHastaTele.SelectedDate == null && cmbLocacion.SelectedValue != null)
                    dtgrdclientes.ItemsSource = cli.listarAsignacion(Convert.ToInt16(txtCantidad.Text), null, null, (int)cmbLocacion.SelectedValue);
                if (dpFechaDesdeTele.SelectedDate != null && dpFechaHastaTele.SelectedDate != null && cmbLocacion.SelectedValue != null)
                    dtgrdclientes.ItemsSource = cli.listarAsignacion(Convert.ToInt16(txtCantidad.Text), dpFechaDesdeTele.SelectedDate.Value, dpFechaHastaTele.SelectedDate.Value,(int) cmbLocacion.SelectedValue);
            }
        }

        private async void btnAsignar_Click(object sender, RoutedEventArgs e)
        {
            if (dtgrdclientes.Items.Count>0)
            {
                int? tele = null;
                if (cmbTelemarketing.SelectedValue != null)
                    tele =(int) cmbTelemarketing.SelectedValue;
                int seleccionado = 0;
                foreach (Clases.C_Cliente item in dtgrdclientes.ItemsSource)
                {
                    if (item.IsSelected == true)
                        seleccionado++;
                        
                }
                if (seleccionado ==0)
                {
                    await p.ShowMessageAsync("Advertencia", "Debe seleccionar al menos un prospecto para imprimir el reporte", MessageDialogStyle.Affirmative);
                    return;
                }
                
                    foreach (Clases.C_Cliente item in dtgrdclientes.ItemsSource)
                    {
                        if (item.IsSelected == true)
                        {
                            Clases.C_Cliente cli = new C_Cliente();
                            cli.id_cliente = item.id_cliente;
                            cli.guardarAsignacion(tele, item.id_cliente);
                            cli.registarCambioStatus(App.userApp.iduser);
                        }
                    }


                    /* MessageDialogResult result = await p.ShowMessageAsync("Confirmación", "Asignación guardada satisfactoriamente, ¿Desea imprimir el reporte al teleoperador?", MessageDialogStyle.AffirmativeAndNegative);
                     if (result == MessageDialogResult.Affirmative)
                     {*/
                    ReporteTeleOp rc = new ReporteTeleOp();
                    rc.idTele = tele;
                    rc.cantidad = Convert.ToInt32(txtCantidad.Text);
                    rc.desde = dpFechaDesdeTele.SelectedDate;
                    rc.hasta = dpFechaHastaTele.SelectedDate;
                    rc.Show();
                    //   }    
                    foreach (Clases.C_Cliente item in dtgrdclientes.ItemsSource)
                    {
                        if (item.IsSelected == true)
                        {
                            Clases.C_Cliente cli = new C_Cliente();
                            //cli.id_cliente = item.id_cliente;
                            cli.actualizarAsignacion(tele, item.id_cliente);
                            //cli.registarCambioStatus(App.userApp.iduser);
                        }
                    }
                    cmbTelemarketing.SelectedIndex = -1;
                    txtCantidad.Text = "";
                    dtgrdclientes.ItemsSource = null;
                     
            }
            else
            {
               await p.ShowMessageAsync("Advertencia", "Debe haber al menos un prospecto para imprimir el reporte", MessageDialogStyle.Affirmative);
            }
        }

        private void chkSelectAll_Checked(object sender, RoutedEventArgs e)
        {

            if (dtgrdclientes.Items.Count > 0)
            {
                foreach (Clases.C_Cliente c in dtgrdclientes.ItemsSource)
                {
                    c.IsSelected = true;
                }
                dtgrdclientes.Items.Refresh();
            }
        }

        private void chkSelectAll_Unchecked(object sender, RoutedEventArgs e)
        {
            if (dtgrdclientes.Items.Count > 0)
            {
                foreach (Clases.C_Cliente c in dtgrdclientes.ItemsSource)
                {
                    c.IsSelected = false;

                }
                dtgrdclientes.Items.Refresh();
            }
        }
        private void chkSelectAll_CheckedCon(object sender, RoutedEventArgs e)
        {

            if (dtgrdclientesCon.Items.Count > 0)
            {
                foreach (Clases.C_Cliente c in dtgrdclientesCon.ItemsSource)
                {
                    c.IsSelected = true;
                }
                dtgrdclientesCon.Items.Refresh();
            }
        }

        private void chkSelectAll_UncheckedCon(object sender, RoutedEventArgs e)
        {
            if (dtgrdclientesCon.Items.Count > 0)
            {
                foreach (Clases.C_Cliente c in dtgrdclientesCon.ItemsSource)
                {
                    c.IsSelected = false;

                }
                dtgrdclientesCon.Items.Refresh();
            }
        }
        private void OnChecked(object sender, RoutedEventArgs e)
        {

        }

        private void txtCantidad_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtCantidadCon_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (!txtCantidadCon.Text.Equals(""))
            {
                C_Cliente cli = new C_Cliente();
                if (hora.Value.Equals(null) && min.Value.Equals(null))
                {

                  
                    dtgrdclientesCon.ItemsSource = cli.listarParaConfirmar(Convert.ToInt16(txtCantidadCon.Text),"",dpFechaDesdeD.SelectedDate);
                }
                else
                {
                    if (!hora.Value.Equals(null))
                    {
                        if (!min.Value.Equals(null))
                        {
                            string ola=hora.Value.ToString()+":"+min.Value.ToString();
                            dtgrdclientesCon.ItemsSource = cli.listarParaConfirmar(Convert.ToInt16(txtCantidadCon.Text), ola, dpFechaDesdeD.SelectedDate); ////************************************
                        }
                    }

                }
            }
        }

        private async void btnAsignarCon_Click(object sender, RoutedEventArgs e)
        {
            DateTime? f=dpFechaDesdeD.SelectedDate;
            if (dtgrdclientesCon.Items.Count > 0)
            {
                if (cmbConfirmador.SelectedValue != null)
                {
                    foreach (Clases.C_Cliente item in dtgrdclientesCon.ItemsSource)
                    {
                        if (item.IsSelected == true)
                        {
                            Clases.C_Cliente cli = new C_Cliente();
                            cli.guardarAsignacionCon((int)cmbConfirmador.SelectedValue, item.id_cliente);
                        }
                    }
                }

                MessageDialogResult result = await p.ShowMessageAsync("Confirmación", "Asignación guardada satisfactoriamente, ¿Desea imprimir el reporte al confirmador?", MessageDialogStyle.AffirmativeAndNegative);
                if (result == MessageDialogResult.Affirmative)
                {
                    reporteConfirmador rc = new reporteConfirmador();
                    if(cmbConfirmador.SelectedValue!=null)
                        rc.idCom = (int)cmbConfirmador.SelectedValue;
                    if (f != null)
                        rc.fecha = dpFechaDesdeD.SelectedDate;
                    if (hora.Value != null)
                    {
                        if (min.Value != null) 
                            rc.hora=hora.Value.ToString()+":"+min.Value.ToString();
                    }
                    if (!txtCantidadCon.Text.Equals(""))
                        rc.cantidad = Convert.ToInt32(txtCantidadCon.Text);
                    rc.Show();
                }
                cmbConfirmador.SelectedIndex = -1;
                txtCantidadCon.Text = "";
                dtgrdclientesCon.ItemsSource = null;
            }
            else
            {
                await p.ShowMessageAsync("Advertencia", "Debe haber al menos un prospecto para imprimir el reporte", MessageDialogStyle.Affirmative);
            }
        }

       
    }
}
