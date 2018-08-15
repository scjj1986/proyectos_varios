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
    public partial class frmPorcCloser : Form
    {
        public frmPorcCloser()
        {
            InitializeComponent();
        }

       


        public void cargar_parametros_sp()
        {

        }



        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (dtpFechaDesde.Value > dtpFechaHasta.Value)
            {
                MessageBox.Show("La fecha inicial no puede ser mayor que la fecha final", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            
            
            Globales.BD.sp_reporte_porc_closer_liner(true,dtpFechaDesde.Value, dtpFechaHasta.Value);
            if (Globales.BD.dtt.Rows.Count == 0)
            {
                MessageBox.Show("No hubo coincidencias con los parámetros establecidos", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            

            else
            {
                string dir = Application.StartupPath.Replace("\\bin\\Debug", "");
                rpvwPorcCloser.LocalReport.ReportPath = dir + "\\Reportes\\rptPorcCloser.rdlc";
                rpvwPorcCloser.LocalReport.DataSources.Clear();
                rpvwPorcCloser.LocalReport.DataSources.Add(new ReportDataSource("dsPCloser", Globales.BD.dtt));//Conjunto de Datos (Ver Datos de Informe en el archivo .rdlc)
                rpvwPorcCloser.LocalReport.DataSources.Add(new ReportDataSource("dsSumPCloser", Globales.BD.dtt_aux));//Conjunto de Datos (Ver Datos de Informe en el archivo .rdlc)
                ReportParameter[] parPCloser = new ReportParameter[3];
                parPCloser[0] = new ReportParameter("FechaInicio", dtpFechaDesde.Value.ToShortDateString());
                parPCloser[1] = new ReportParameter("FechaFin", dtpFechaHasta.Value.ToShortDateString());
                parPCloser[2] = new ReportParameter("Fecha", DateTime.Now.ToShortDateString());
                rpvwPorcCloser.LocalReport.SetParameters(parPCloser);
                rpvwPorcCloser.RefreshReport();
            }

        }
    }
}
