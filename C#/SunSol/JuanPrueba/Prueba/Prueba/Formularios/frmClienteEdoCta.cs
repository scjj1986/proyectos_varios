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
    public partial class frmClienteEdoCta : Form
    {

        public string cedcli = "";
        public string nombrecompleto = "";
        public frmClienteEdoCta()
        {
            InitializeComponent();
        }

        private void frmClienteEdoCta_Load(object sender, EventArgs e)
        {
            

            this.rpvwClienteEdoCta.ProcessingMode = ProcessingMode.Local;
            string txtSQL = "SELECT * FROM GIROS WHERE CEDULA='" + this.cedcli + "' And Estatus IN ('PENDIENTE','CANCELADO') ORDER BY NROCONTRATO,FechaCuota";
            Globales.BD.dtt = Globales.BD.generar_datatable(txtSQL, CommandType.Text, new List<Clases.Parameters>());
            string dir = Application.StartupPath.Replace("\\bin\\Debug","");
            this.rpvwClienteEdoCta.LocalReport.ReportPath =  dir + "\\Reportes\\rptClienteEdoCta.rdlc";
            ReportDataSource rds = new ReportDataSource("dsClEdCt", Globales.BD.dtt); //(OJO) Coincidir con el conjunto de datos en el informe 
            this.rpvwClienteEdoCta.LocalReport.DataSources.Clear();
            this.rpvwClienteEdoCta.LocalReport.DataSources.Add(rds);
            ReportParameter[] parametrosEcta = new ReportParameter[2];
            parametrosEcta[0] = new ReportParameter("Fecha", DateTime.Now.ToShortDateString());
            parametrosEcta[1] = new ReportParameter("Nombre", this.nombrecompleto);
            Console.WriteLine(DateTime.Now.ToShortDateString());
            this.rpvwClienteEdoCta.LocalReport.SetParameters(parametrosEcta); 
            this.rpvwClienteEdoCta.RefreshReport();
        }
    }
}
