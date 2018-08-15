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

namespace Reservas
{
    /// <summary>
    /// Lógica de interacción para reporteReserva.xaml
    /// </summary>
    public partial class reporteReserva : MetroWindow
    {
        dsreporteReserva dsRe = new dsreporteReserva();
        ReportDataSource rdsReserva = new ReportDataSource();
        public string cliente, fecha, contrato, fechaf, status;
        public int reserva;
        public reporteReserva()
        {
            InitializeComponent();
        }

        private void vtnReporteReserva_Loaded(object sender, RoutedEventArgs e)
        {
            dsRe.Clear();
            string titulo = "";
            _reportViewer.Clear();
            dsRe.BeginInit();
            rdsReserva.Name = "DataSet1";
            rdsReserva.Value = dsRe._sp_ReporteReserva;
            _reportViewer.LocalReport.DataSources.Add(rdsReserva);
            dsRe.EndInit();
            this._reportViewer.LocalReport.ReportEmbeddedResource = "Reservas.reporteReservas.rdlc";
            dsreporteReservaTableAdapters._sp_ReporteReservaTableAdapter tc = new dsreporteReservaTableAdapters._sp_ReporteReservaTableAdapter();
            tc.ClearBeforeFill = true;
            tc.Fill(dsRe._sp_ReporteReserva, reserva, cliente,fecha,Convert.ToInt32(contrato),status,fechaf);
            if (!cliente.Equals("0") && status.Equals("0") && contrato.Equals("0") && fecha.Equals("0") && fechaf.Equals("0") && reserva == 0)
                titulo = "del cliente de " + cliente;
            if (!cliente.Equals("0") && !status.Equals("0") && contrato.Equals("0") && fecha.Equals("0") && fechaf.Equals("0") && reserva == 0)
                titulo = "del cliente de " + cliente + " de estatus " + status;
            if (!cliente.Equals("0") && !status.Equals("0") && !contrato.Equals("0") && fecha.Equals("0") && fechaf.Equals("0") && reserva == 0)
                titulo = "por cliente de " + cliente + " de estatus " + status + " del contrato número " + contrato;
            if (cliente.Equals("0") && status.Equals("0") && contrato.Equals("0") && !fecha.Equals("0") && !fechaf.Equals("0") && reserva == 0)
                titulo = "desde " + fecha + " hasta: " + fechaf;
            if (cliente.Equals("0") && !status.Equals("0") && contrato.Equals("0") && fecha.Equals("0") && fechaf.Equals("0") && reserva == 0)
                titulo = status;
            if (cliente.Equals("0") && !status.Equals("0") && contrato.Equals("0") && !fecha.Equals("0") && fechaf.Equals("0") && reserva == 0)
                titulo = status + " al " + fecha;
            if (!cliente.Equals("0") && status.Equals("0") && contrato.Equals("0") && !fecha.Equals("0") && fechaf.Equals("0") && reserva == 0)
                titulo = "por el cliente de " + cliente + " al " + fecha;

            if (cliente.Equals("0") && status.Equals("0") && contrato.Equals("0") && fecha.Equals("0") && fechaf.Equals("0") && reserva != 0)
                titulo = "de la reserva número " + reserva;
            if (cliente.Equals("0") && status.Equals("0") && !contrato.Equals("0") && fecha.Equals("0") && fechaf.Equals("0") && reserva == 0)
                titulo = "del contrato número " + contrato;


            ReportParameter[] parameters = new ReportParameter[1];
            parameters[0] = new ReportParameter("titulo", titulo);

            _reportViewer.LocalReport.SetParameters(parameters);

            _reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            _reportViewer.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
            _reportViewer.RefreshReport();
        }
    }
}
