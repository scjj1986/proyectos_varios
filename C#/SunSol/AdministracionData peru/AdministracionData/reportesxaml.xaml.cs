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
using System.Windows.Forms;
using System.Data;
using System.Windows.Controls.DataVisualization.Charting;

namespace AdministracionData
{
    /// <summary>
    /// Lógica de interacción para reportesxaml.xaml
    /// </summary>
    public partial class reportesxaml : Page
    {
        public reportesxaml()
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

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            statusPrincipal stsp = new statusPrincipal();
            cmbStatusPrincipal.ItemsSource = stsp.listarStatusPrincipal();
            cmbStatusPrincipal.DisplayMemberPath = "descripcion";
            cmbStatusPrincipal.SelectedValuePath = "id_statusPrincipal";
            C_Telemarketing tele = new C_Telemarketing();
            cmbTelemarketing.ItemsSource = llenarCombo();
            cmbTelemarketing.DisplayMemberPath = "Value";
            cmbTelemarketing.SelectedValuePath = "Key";
            C_Locacion loc = new C_Locacion();
            cmbLocacion.ItemsSource = loc.listarLocaciones();
            cmbLocacion.DisplayMemberPath = "codigo";
            cmbLocacion.SelectedValuePath = "idlocacion";
        }

        private void cmbStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            if (cmbStatus.SelectedValue != null)
            {

                Clases.C_Cliente cli = new Clases.C_Cliente();
                cli.id_status = (int)cmbStatus.SelectedValue;
                cli.Id_statusPrincipal = (int)cmbStatusPrincipal.SelectedValue;

                if(cmbLocacion.SelectedValue!=null)
                    dtgrdclientes.ItemsSource = cli.ReporteCLientes(null,null,(int)cmbLocacion.SelectedValue);
                else
                    dtgrdclientes.ItemsSource = cli.ReporteCLientes(null, null, null);
            }
            //if (Convert.ToInt32(cmbStatus.SelectedValue) == 3 || Convert.ToInt32(cmbStatus.SelectedValue) == 4)
            //{
            //    dpFechaDesde.IsEnabled = true;
            //    dpFechaHasta.IsEnabled = true;
            //}
            //else
            //{
            //    dpFechaDesde.IsEnabled = false;
            //    dpFechaHasta.IsEnabled = false;
            //}
           
            //if (dpFechaDesde.SelectedDate != null && dpFechaHasta.SelectedDate != null)
            //    dtgrdclientes.ItemsSource = cli.ReporteCLientes(dpFechaDesde.SelectedDate.Value, dpFechaHasta.SelectedDate.Value);
        }

        private void dpFechaHasta_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Clases.C_Cliente cli = new Clases.C_Cliente();
            if (cmbTelemarketing.SelectedValue != null)        
                dtgrdclientesAsig.ItemsSource = cli.ReporteAsignacion(dpFechaDesde.SelectedDate, dpFechaHasta.SelectedDate, (int)cmbTelemarketing.SelectedValue);
            else
                dtgrdclientesAsig.ItemsSource = cli.ReporteAsignacion(dpFechaDesde.SelectedDate, dpFechaHasta.SelectedDate, null);


            //cli.id_status = (int)cmbStatus.SelectedValue;
            //if (dpFechaDesde.SelectedDate != null && dpFechaHasta.SelectedDate != null)
            //    dtgrdclientes.ItemsSource = cli.ReporteCLientes(dpFechaDesde.SelectedDate.Value, dpFechaHasta.SelectedDate.Value);
        }

        private void dpFechaDesde_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            dpFechaHasta.DisplayDateStart = dpFechaDesde.SelectedDate;
        }

        private void cmbStatusPrincipal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Clases.C_Status sts = new Clases.C_Status();
            sts.id_statusPrincipal = (int)cmbStatusPrincipal.SelectedValue;
            cmbStatus.ItemsSource = sts.listarStatus();
            cmbStatus.DisplayMemberPath = "descripcion";
            cmbStatus.SelectedValuePath = "id_status";
        }
        private void txtCedula_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            C_Cliente cli = new C_Cliente();
            dtgrdclientesHis.ItemsSource = cli.filtarCLientes(txtCedula.Text, "",null,null);
            if (!txtTelefono.Text.Equals(""))
                dtgrdclientesHis.ItemsSource = cli.filtarCLientes(txtCedula.Text, txtTelefono.Text,null,null);
            if (txtCedula.Text.Equals(""))
            {
                txtTelefono.Text = "";
                dtgrdclientesHis.ItemsSource = cli.listarCLientes();
            }

        }
        private void txtTelefono_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            C_Cliente cli = new C_Cliente();
            dtgrdclientesHis.ItemsSource = cli.filtarCLientes("", txtTelefono.Text,null,null);
            if (!txtCedula.Text.Equals(""))
                dtgrdclientesHis.ItemsSource = cli.filtarCLientes(txtCedula.Text, txtTelefono.Text,null,null);
            if (txtTelefono.Text.Equals(""))
            {
                txtCedula.Text = "";
                dtgrdclientesHis.ItemsSource = cli.listarCLientes();
            }
        }

        private void dtgrdclientes_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            object clien = dtgrdclientesHis.SelectedItem;
            if (clien != null)
            {
                historial his = new historial();
                his.cli = (C_Cliente)clien;
                his.Show();
            }
           
        }

        private void btnImprimirRClientes_Click(object sender, RoutedEventArgs e)
        {
            ReporteProspecto rp = new ReporteProspecto();
            if (cmbStatusPrincipal.SelectedIndex != -1)
            {
                rp.sttsP = (int)cmbStatusPrincipal.SelectedValue;
                rp.sp = cmbStatusPrincipal.Text;
            }
            if (cmbStatus.SelectedIndex != -1)
            {
                rp.stts = (int)cmbStatus.SelectedValue;
                rp.s = cmbStatus.Text;
            }
            DateTime? fi = dpFechaDesdeD.SelectedDate;
            DateTime? ff = dpFechaHastaD.SelectedDate;
             int? loc=0;
            if(cmbLocacion.SelectedValue!=null)
                loc=(int)cmbLocacion.SelectedValue;
            rp.fi = fi;
            rp.ff = ff;
            if (cmbLocacion.SelectedValue != null)
                rp.locacion = cmbLocacion.Text;
            rp.loc = loc;

            rp.Show();

        }

        private void dpFechaHastaD_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
             Clases.C_Cliente cli = new Clases.C_Cliente();
             int loc = 0;
             if (cmbStatus.SelectedValue != null)
                cli.id_status = (int)cmbStatus.SelectedValue;
             if (cmbStatusPrincipal.SelectedValue != null)
                 cli.Id_statusPrincipal = (int)cmbStatusPrincipal.SelectedValue;
             if (cmbLocacion.SelectedValue != null)
                 loc = (int)cmbLocacion.SelectedValue;   
           
            if (dpFechaDesdeD.SelectedDate != null && dpFechaHastaD.SelectedDate != null)
                dtgrdclientes.ItemsSource = cli.ReporteCLientes(dpFechaDesdeD.SelectedDate.Value, dpFechaHastaD.SelectedDate.Value,loc);
        }

        private void dtgrdclientes_Copy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnImprimirRAsig_Click(object sender, RoutedEventArgs e)
        {
            ReporteTeleOp rc = new ReporteTeleOp();
            //rc.camarera = cam;
            int? loc = null;
            if (cmbLocacion.SelectedValue != null)
                loc = (int)cmbLocacion.SelectedValue;
            rc.idTele = loc;
            rc.Show();
        }
    }
}
