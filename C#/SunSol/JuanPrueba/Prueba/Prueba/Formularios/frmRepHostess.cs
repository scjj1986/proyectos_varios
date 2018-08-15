using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Contratos
{
    public partial class frmRepHostess : Form
    {
        public frmRepHostess()
        {
            InitializeComponent();
        }

        private void rpvwRepHostess_Load(object sender, EventArgs e)
        {
            

        }

        private void frmRepHostess_Load(object sender, EventArgs e)
        {
            rdReservas.Checked = true;
            string txtSQL = "Select * from Oficinas order by Descripcion";
            cargar_cmbOficina(txtSQL);
        }

        public void cargar_cmbOficina(string txtSQL)
        {
            cmbOficina.DataSource = null;
            Globales.BD.dtt = Globales.BD.generar_datatable(txtSQL, CommandType.Text, new List<Clases.Parameters>());
            cmbOficina.DataSource = Globales.BD.dtt;
            cmbOficina.ValueMember = "Codigo";
            cmbOficina.DisplayMember = "Descripcion";
            if (cmbOficina.Items.Count>0)
                cmbOficina.SelectedIndex = 0;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (dtpFechaDesde.Value == null || dtpFechaDesde.Value == null)
            {
                MessageBox.Show("Las fechas no deben estar vacías", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (dtpFechaDesde.Value > dtpFechaHasta.Value)
            {
                MessageBox.Show("La fecha inicial no puede ser mayor que la fecha final", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string txtSQL="";
            string tipo="";

            if (rdContratos.Checked)
            {
                
                txtSQL = " set dateFormat DMY SELECT a.FechaCreacion,A.NroContrato,(a.Nombres + ' ' +  a.Apellidos) as Nombre , a.Estatus,a.DescripcionPrograma,(Select Nombre from empleados where Codigo = a.CodigoLiner) as Nombreliner1 , (Select Nombre from empleados where Codigo = a.CodigoLiner2) as Nombreliner2, (Select Nombre from empleados where Codigo = a.CodigoLiner3) as Nombreliner3, (Select Nombre from empleados where Codigo = a.CodigoCloser1) as NombreCloser1, (Select Nombre from empleados where Codigo = a.CodigoCloser2) as NombreCloser2, (Select Nombre from empleados where Codigo = a.CodigoCloser3) as NombreCloser3, (Select OPC from MANIFIESTO where CONTRATO = a.NROCONTRATO and convert(date,fechacreacion) = convert(date,a.fechacreacion)) as NombreOPC, (Select e.NOMBRE from MANIFIESTO m left join Empleados e on m.CodigoSupervisorOPC=e.CODIGO where CONTRATO = a.NROCONTRATO and convert(date,fechacreacion) = convert(date,a.fechacreacion)) as NombreSUP, a.Observacioneshostess ,a.montocontrato as monto, A.DESCRIPCIONLOC,case when (CodigoCobrador = 'PPF')THEN CodigoCobrador WHEN (CodigoCobrador = 'PVB') THEN CodigoCobrador  ELSE '' END AS CodigoCobrador FROM V_CONTRATOS a WHERE Estado='ACTIVO' and estatus in('PENDING','PROCESABLE') AND CodigoOficina='" + cmbOficina.SelectedValue + "' AND  a.FechaCreacion Between '" + Globales.yyyy_mm_dd_hhmmss_singuion(Convert.ToDateTime(dtpFechaDesde.Value), " 00:00") + "' And '" + Globales.yyyy_mm_dd_hhmmss_singuion(Convert.ToDateTime(dtpFechaHasta.Value), " 23:59") + "'";
                tipo = "CONTRATOS";

            }
            else
            {
                txtSQL = " set dateFormat DMY SELECT a.FechaCreacion,A.NroContrato,(a.Nombres + ' ' +  a.Apellidos) as Nombre , a.Estatus,a.DescripcionPrograma,(Select Nombre from empleados where Codigo = a.CodigoLiner) as Nombreliner1 , (Select Nombre from empleados where Codigo = a.CodigoLiner2) as Nombreliner2, (Select Nombre from empleados where Codigo = a.CodigoLiner3) as Nombreliner3, (Select Nombre from empleados where Codigo = a.CodigoCloser1) as NombreCloser1, (Select Nombre from empleados where Codigo = a.CodigoCloser2) as NombreCloser2, (Select Nombre from empleados where Codigo = a.CodigoCloser3) as NombreCloser3, (Select OPC from MANIFIESTO where CONTRATO = a.NROCONTRATO and cedula=a.cedula_rif AND fechacreacion = Convert(date,a.fechacreacion)) as NombreOPC, (Select e.NOMBRE from MANIFIESTO m left join Empleados e on m.CodigoSupervisorOPC=e.CODIGO where CONTRATO = a.NROCONTRATO and cedula=a.cedula_rif AND fechacreacion = Convert(date,a.fechacreacion)) as NombreSUP, a.Observacioneshostess ,a.montocontrato as monto, A.DESCRIPCIONLOC,case when (CodigoCobrador = 'PPF')THEN CodigoCobrador WHEN (CodigoCobrador = 'PVB') THEN CodigoCobrador  ELSE '' END AS CodigoCobrador FROM V_CONTRATOS a  WHERE Estado='ACTIVO' AND ESTATUS = 'RESERVA' AND CodigoOficina='" + cmbOficina.SelectedValue + "' AND  a.FechaCreacion Between '" + Globales.yyyy_mm_dd_hhmmss_singuion(Convert.ToDateTime(dtpFechaDesde.Value), " 00:00") + "' And '" + Globales.yyyy_mm_dd_hhmmss_singuion(Convert.ToDateTime(dtpFechaHasta.Value), " 23:59") + "'";
                tipo = "RESERVAS";
            }


            Globales.BD.dtt = Globales.BD.generar_datatable(txtSQL, CommandType.Text, new List<Clases.Parameters>());
            if (Globales.BD.dtt.Rows.Count == 0)
            {
                MessageBox.Show("No hubo coincidencias con los parámetros establecidos", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                string dir = Application.StartupPath.Replace("\\bin\\Debug", "");
                rpvwRepHostess.LocalReport.ReportPath = dir + "\\Reportes\\rptHostess.rdlc";
                rpvwRepHostess.LocalReport.DataSources.Clear();
                rpvwRepHostess.LocalReport.DataSources.Add(new ReportDataSource("dsRepHostess", Globales.BD.dtt));//Conjunto de Datos (Ver Datos de Informe en el archivo .rdlc)
                ReportParameter[] parRepHostess = new ReportParameter[4];
                parRepHostess[0] = new ReportParameter("FechaInicio", dtpFechaDesde.Value.ToShortDateString());
                parRepHostess[1] = new ReportParameter("FechaFin", dtpFechaHasta.Value.ToShortDateString());
                parRepHostess[2] = new ReportParameter("Oficina", cmbOficina.Text);
                parRepHostess[3] = new ReportParameter("Tipo", tipo);
                rpvwRepHostess.LocalReport.SetParameters(parRepHostess);
                rpvwRepHostess.RefreshReport();

            }
        }

        
    }
}
