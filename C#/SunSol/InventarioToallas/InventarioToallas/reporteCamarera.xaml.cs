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
using Clases;
using Microsoft.Reporting.WinForms;

namespace InventarioToallas
{
    /// <summary>
    /// Lógica de interacción para reporteCamarera.xaml
    /// </summary>
    public partial class reporteCamarera : MetroWindow
    {
        public C_Camarera camarera = new C_Camarera();
        public C_Supervisor supervisor = new C_Supervisor();
        dsReporteCamarera dshab = new dsReporteCamarera();
        ReportDataSource rphab = new ReportDataSource();
        //dsSuministros dssum = new dsSuministros();
        ReportDataSource rpsum = new ReportDataSource();
        public bool todos = false;
        public DateTime fecha;
        public reporteCamarera()
        {
            InitializeComponent();
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            dshab.Clear();
            

            _reportViewer.Clear();
            dshab.BeginInit();
            rphab.Name = "DataSet1";
            rphab.Value = dshab._sp_ReporteCamarera;
            _reportViewer.LocalReport.DataSources.Add(rphab);
            dshab.EndInit();
            this._reportViewer.LocalReport.ReportEmbeddedResource = "InventarioToallas.ReporteCam.rdlc";

            

            dsReporteCamareraTableAdapters._sp_ReporteCamareraTableAdapter ha = new dsReporteCamareraTableAdapters._sp_ReporteCamareraTableAdapter();
            ha.ClearBeforeFill = true;
            if (todos)
                ha.Fill(dshab._sp_ReporteCamarera,fecha,-1); 
            else
                ha.Fill(dshab._sp_ReporteCamarera,fecha, Convert.ToInt32(camarera.idCamarera));
                     

            //ReportParameter[] parameters = new ReportParameter[2];
            //parameters[0] = new ReportParameter("camarera", camarera.nombre+" "+camarera.apellido);
            //parameters[1] = new ReportParameter("supervisor", supervisor.nombre + " " + supervisor.apellido);

             //_reportViewer.LocalReport.SetParameters(parameters);

            _reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            _reportViewer.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
            _reportViewer.RefreshReport();
        }
    }
}
