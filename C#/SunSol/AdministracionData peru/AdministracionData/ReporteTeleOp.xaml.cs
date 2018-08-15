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
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using Microsoft.Reporting.WinForms;

namespace AdministracionData
{
    /// <summary>
    /// Lógica de interacción para ReporteTeleOp.xaml
    /// </summary>
    public partial class ReporteTeleOp : MetroWindow
    {
        dsReporteTeleOp dshab = new dsReporteTeleOp();
        ReportDataSource rphab = new ReportDataSource();
        
        public int? idTele = 0;
        public string ola = "";
        public int cantidad = 0;
        public DateTime? desde;
        public DateTime? hasta;

        public ReporteTeleOp()
        {
            InitializeComponent();
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            dshab.Clear();


            _reportViewer.Clear();
            dshab.BeginInit();
            rphab.Name = "DataSet1";
            rphab.Value = dshab._v_PendientesTele;
            _reportViewer.LocalReport.DataSources.Add(rphab);
            dshab.EndInit();
            this._reportViewer.LocalReport.ReportEmbeddedResource = "AdministracionData.ReportTeleOp.rdlc";

            dsReporteTeleOpTableAdapters._v_PendientesTeleTableAdapter ha = new dsReporteTeleOpTableAdapters._v_PendientesTeleTableAdapter();
            ha.ClearBeforeFill = true;
            // ha.Fill(dshab._sp_ReporteCamarera,DateTime.Today.Date, Convert.ToInt32(camarera.idCamarera));
            ha.Fill(dshab._v_PendientesTele,DateTime.Today.Date.ToShortDateString());

            //ReportParameter[] parameters = new ReportParameter[2];
            //parameters[0] = new ReportParameter("camarera", camarera.nombre + " " + camarera.apellido);
            //parameters[1] = new ReportParameter("supervisor", supervisor.nombre + " " + supervisor.apellido);

            //_reportViewer.LocalReport.SetParameters(parameters);

            _reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            _reportViewer.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
            _reportViewer.RefreshReport();
        }
    }
}
