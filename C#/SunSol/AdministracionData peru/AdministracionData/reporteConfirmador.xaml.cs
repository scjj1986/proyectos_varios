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
using MahApps.Metro.Controls;
using Microsoft.Reporting.WinForms;

namespace AdministracionData
{
    /// <summary>
    /// Lógica de interacción para reporteConfirmador.xaml
    /// </summary>
    public partial class reporteConfirmador : MetroWindow
    {
        dsReporteConfirmador dsCon=new dsReporteConfirmador();
        ReportDataSource rdsCon=new ReportDataSource();
        public int idCom = 0;
        public string hora = "";
        public DateTime? fecha=null;
        public int cantidad = 0;
        public reporteConfirmador()
        {
            InitializeComponent();
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _reportViewer.Clear();
            dsCon.BeginInit();
            rdsCon.Name = "DataSet1";
            rdsCon.Value = dsCon._v_ReporteConfirmador;
            _reportViewer.LocalReport.DataSources.Add(rdsCon);
            dsCon.EndInit();
            this._reportViewer.LocalReport.ReportEmbeddedResource = "AdministracionData.ReporteConfirmador.rdlc";

            dsReporteConfirmadorTableAdapters._v_ReporteConfirmadorTableAdapter ha = new dsReporteConfirmadorTableAdapters._v_ReporteConfirmadorTableAdapter();
            ha.ClearBeforeFill = true;
            if(hora.Equals("")&&fecha==null&&idCom!=0)
                 ha.Fill(dsCon._v_ReporteConfirmador,cantidad,idCom);
            if (!hora.Equals("") && fecha != null && idCom != 0)
                ha.FillByFO(dsCon._v_ReporteConfirmador,cantidad,idCom,fecha.Value.ToShortDateString(),hora);
            if (!hora.Equals("") && fecha == null && idCom == 0)
                ha.FillByOS(dsCon._v_ReporteConfirmador,cantidad, hora);
            if (hora.Equals("") && fecha != null && idCom == 0)
                ha.FillByFS(dsCon._v_ReporteConfirmador,cantidad, fecha.Value.ToShortDateString());
            if (!hora.Equals("") && fecha != null && idCom == 0)
                ha.FillByFOS(dsCon._v_ReporteConfirmador, cantidad, fecha.Value.ToShortDateString(),hora);
            



            ReportParameter[] parameters = new ReportParameter[1];
            parameters[0] = new ReportParameter("hora", hora);
            //parameters[1] = new ReportParameter("supervisor", supervisor.nombre + " " + supervisor.apellido);
            _reportViewer.LocalReport.SetParameters(parameters);
            _reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            _reportViewer.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
            _reportViewer.RefreshReport();
        }
    }
}
