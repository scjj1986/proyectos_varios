using System;
using System.IO;
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
    public partial class frmListadoClientes : Form
    {
        public frmListadoClientes()
        {
            InitializeComponent();
        }

        private void frmListadoClientes_Load(object sender, EventArgs e)
        {

            this.rpvwListCli.ProcessingMode = ProcessingMode.Local;
            string txtSQL = "Select top 10 * from Clientes Order by Cedula_Rif";
            Globales.BD.dtt = Globales.BD.generar_datatable(txtSQL, CommandType.Text, new List<Clases.Parameters>());
            string dir = Application.StartupPath.Replace("\\bin\\Debug", "");
            this.rpvwListCli.LocalReport.ReportPath = dir + "\\Reportes\\rptListadoClientes.rdlc";
            ReportDataSource rds = new ReportDataSource("dsClientes", Globales.BD.dtt);
            this.rpvwListCli.LocalReport.DataSources.Clear();
            this.rpvwListCli.LocalReport.DataSources.Add(rds);
            ReportParameter[] parametrosCli = new ReportParameter[1];
            parametrosCli[0] = new ReportParameter("Fecha", DateTime.Now.ToShortDateString());
            Console.WriteLine(DateTime.Now.ToShortDateString());
            this.rpvwListCli.LocalReport.SetParameters(parametrosCli);
            this.rpvwListCli.RefreshReport();
        }

        private void rpvwListCli_Load(object sender, EventArgs e)
        {
            
        }
    }
}
