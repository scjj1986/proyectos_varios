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
    public partial class frmPorcLiner : Form
    {
        public frmPorcLiner()
        {
            InitializeComponent();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (dtpFechaDesde.Value > dtpFechaHasta.Value)
            {
                MessageBox.Show("La fecha inicial no puede ser mayor que la fecha final", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Globales.BD.sp_reporte_porc_closer_liner(false, dtpFechaDesde.Value, dtpFechaHasta.Value);
            if (Globales.BD.dtt.Rows.Count == 0)
            {
                MessageBox.Show("No hubo coincidencias con los parámetros establecidos", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string dir = Application.StartupPath.Replace("\\bin\\Debug", "");
                rpvwPorcLiner.LocalReport.ReportPath = dir + "\\Reportes\\rptPorcLiner.rdlc";
                rpvwPorcLiner.LocalReport.DataSources.Clear();
                rpvwPorcLiner.LocalReport.DataSources.Add(new ReportDataSource("dsPLiner", Globales.BD.dtt));//Conjunto de Datos (Ver Datos de Informe en el archivo .rdlc)
                rpvwPorcLiner.LocalReport.DataSources.Add(new ReportDataSource("dsSumPLiner", Globales.BD.dtt_aux));//Conjunto de Datos (Ver Datos de Informe en el archivo .rdlc)
                ReportParameter[] parPLiner = new ReportParameter[3];
                parPLiner[0] = new ReportParameter("FechaInicio", dtpFechaDesde.Value.ToShortDateString());
                parPLiner[1] = new ReportParameter("FechaFin", dtpFechaHasta.Value.ToShortDateString());
                parPLiner[2] = new ReportParameter("Fecha", DateTime.Now.ToShortDateString());
                rpvwPorcLiner.LocalReport.SetParameters(parPLiner);
                rpvwPorcLiner.RefreshReport();
            }
        }
    }
}
