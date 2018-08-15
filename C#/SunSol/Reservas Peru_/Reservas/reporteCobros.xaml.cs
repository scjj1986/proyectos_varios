using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MahApps.Metro.Controls;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Reporting.WinForms;

namespace Reservas
{
    /// <summary>
    /// Lógica de interacción para reporteCobros.xaml
    /// </summary>
    public partial class reporteCobros : MetroWindow
    {
        public string us;
        dsreporteCobros dsCo = new dsreporteCobros();
        ReportDataSource rdscobros = new ReportDataSource();
        public string concepto, fecha, contrato, fechaf, status,hotel,ejecutivo;
        public int reserva;
        public reporteCobros()
        {
            InitializeComponent();
        }

        

        private void vtnReporteCobros_Loaded(object sender, RoutedEventArgs e)
        {
            dsCo.Clear();
            string titulo="";
            _reportViewer.Clear();
            dsCo.BeginInit();
            rdscobros.Name = "DataSet1";
            rdscobros.Value = dsCo._sp_ReportePagos;
            _reportViewer.LocalReport.DataSources.Add(rdscobros);
            dsCo.EndInit();
            this._reportViewer.LocalReport.ReportEmbeddedResource = "Reservas.reporteCobros.rdlc";
            dsreporteCobrosTableAdapters._sp_ReportePagosTableAdapter tc = new dsreporteCobrosTableAdapters._sp_ReportePagosTableAdapter();
            tc.ClearBeforeFill = true;
            tc.Fill(dsCo._sp_ReportePagos, concepto, fecha, status, reserva, contrato, fechaf,hotel,ejecutivo,us);
            if (!concepto.Equals("0")&&status.Equals("2")&&contrato.Equals("0")&&fecha.Equals("0")&&fechaf.Equals("0")&&reserva==0&&hotel.Equals("0")&&ejecutivo.Equals("0"))            
                titulo = "por concepto de " + concepto;
            if (!concepto.Equals("0") && !status.Equals("2") && contrato.Equals("0") && fecha.Equals("0") && fechaf.Equals("0") && reserva == 0 && hotel.Equals("0") && ejecutivo.Equals("0"))
                titulo = "por concepto de " + concepto +" de estatus "+status;
            if (!concepto.Equals("0") && !status.Equals("2") && !contrato.Equals("0") && fecha.Equals("0") && fechaf.Equals("0") && reserva == 0 && hotel.Equals("0") && ejecutivo.Equals("0"))
                titulo = "por concepto de " + concepto + " de estatus " + status+" del contrato número "+contrato;
            if (concepto.Equals("0") && status.Equals("2") && contrato.Equals("0") && !fecha.Equals("0") && !fechaf.Equals("0") && reserva == 0 && hotel.Equals("0") && ejecutivo.Equals("0"))
                titulo = "desde "+fecha+" hasta: "+fechaf;
            if (concepto.Equals("0") && !status.Equals("2") && contrato.Equals("0") && fecha.Equals("0") && fechaf.Equals("0") && reserva == 0 && hotel.Equals("0") && ejecutivo.Equals("0"))
            {
                if (status.Equals("1"))
                    status = "CONFIRMADOS";
                else status = "PENDIENTES";
                titulo = status;
            }
            if (concepto.Equals("0") && !status.Equals("2") && contrato.Equals("0") && !fecha.Equals("0") && fechaf.Equals("0") && reserva == 0 && hotel.Equals("0") && ejecutivo.Equals("0"))
                titulo = status + " al " + fecha;
            if (!concepto.Equals("0") && status.Equals("2") && contrato.Equals("0") && !fecha.Equals("0") && fechaf.Equals("0") && reserva == 0 && hotel.Equals("0") && ejecutivo.Equals("0"))
                titulo = "por el concepto de "+concepto+ " al " + fecha;

            if (concepto.Equals("0") && status.Equals("2") && contrato.Equals("0") && fecha.Equals("0") && fechaf.Equals("0") && reserva != 0 && hotel.Equals("0") && ejecutivo.Equals("0"))
                titulo = "de la reserva número " + reserva ;
            if (concepto.Equals("0") && status.Equals("2") && !contrato.Equals("0") && fecha.Equals("0") && fechaf.Equals("0") && reserva == 0 && hotel.Equals("0") && ejecutivo.Equals("0"))
                titulo = "del contrato número " + contrato;

            if (concepto.Equals("0") && status.Equals("2") && contrato.Equals("0") && fecha.Equals("0") && fechaf.Equals("0") && reserva == 0 && !hotel.Equals("0") && ejecutivo.Equals("0"))
                titulo = "del Hotel " + hotel;
           
            if (concepto.Equals("0") && status.Equals("2") && contrato.Equals("0") && fecha.Equals("0") && fechaf.Equals("0") && reserva == 0 && hotel.Equals("0") && !ejecutivo.Equals("0"))
                titulo = "del ejecutivo " + ejecutivo;

            if (concepto.Equals("0") && status.Equals("2") && contrato.Equals("0") && !fecha.Equals("0") && !fechaf.Equals("0") && reserva == 0 && !hotel.Equals("0") && ejecutivo.Equals("0"))
                titulo = "del Hotel " + hotel+ " del "+fecha+" al "+fechaf;

            if (concepto.Equals("0") && status.Equals("2") && contrato.Equals("0") && !fecha.Equals("0") && !fechaf.Equals("0") && reserva == 0 && hotel.Equals("0") && !ejecutivo.Equals("0"))
                titulo = "del ejecutivo " + ejecutivo + " del " + fecha + " al " + fechaf;

           
            if (concepto.Equals("0") && status.Equals("2") && contrato.Equals("0") && !fecha.Equals("0") && !fechaf.Equals("0") && reserva == 0 && !hotel.Equals("0") && !ejecutivo.Equals("0"))
                titulo = "del ejecutivo " + ejecutivo + " del hotel  " + hotel + " del " + fecha + " al " + fechaf;

            if (!concepto.Equals("0") && status.Equals("2") && contrato.Equals("0") && fecha.Equals("0") && fechaf.Equals("0") && reserva == 0 && hotel.Equals("0") && !ejecutivo.Equals("0"))
                titulo = "del ejecutivo " + ejecutivo + " por concepto  " + concepto;
            if (!concepto.Equals("0") && status.Equals("2") && contrato.Equals("0") && fecha.Equals("0") && fechaf.Equals("0") && reserva == 0 && !hotel.Equals("0") && !ejecutivo.Equals("0"))
                titulo = "del ejecutivo " + ejecutivo + " por concepto  " + concepto+" del hotel "+hotel;
           
            if (!concepto.Equals("0") && status.Equals("2") && contrato.Equals("0") && !fecha.Equals("0") && !fechaf.Equals("0") && reserva == 0 && !hotel.Equals("0") && !ejecutivo.Equals("0"))
                titulo = "del ejecutivo " + ejecutivo + " por concepto  " + concepto + " del hotel " + hotel + " del " + fecha + " al " + fechaf;

            if (!concepto.Equals("0") && !status.Equals("2") && contrato.Equals("0") && !fecha.Equals("0") && !fechaf.Equals("0") && reserva == 0 && !hotel.Equals("0") && !ejecutivo.Equals("0"))
            {
                if (status.Equals("1"))
                    status = "CONFIRMADOS";
                else status = "PENDIENTES";
                titulo = "del ejecutivo " + ejecutivo + " por concepto  " + concepto + " " + status + " del hotel " + hotel + " del " + fecha + " al " + fechaf;
            }

            if (!concepto.Equals("0") && status.Equals("2") && contrato.Equals("0") && !fecha.Equals("0") && !fechaf.Equals("0") && reserva == 0 && hotel.Equals("0") && ejecutivo.Equals("0"))
                titulo = " por concepto  " + concepto + " " + " del " + fecha + " al " + fechaf;

            if (concepto.Equals("0") && status.Equals("2") && contrato.Equals("0") && fecha.Equals("0") && fechaf.Equals("0") && reserva == 0 && !hotel.Equals("0") && !ejecutivo.Equals("0"))
                titulo = "del ejecutivo " + ejecutivo+" del hotel " + hotel;
            if (concepto.Equals("0") && !status.Equals("2") && contrato.Equals("0") && !fecha.Equals("0") && !fechaf.Equals("0") && reserva == 0 && hotel.Equals("0") && ejecutivo.Equals("0"))
            {
                if (status.Equals("1"))
                    status = "CONFIRMADOS";
                else status = "PENDIENTES";
                titulo = status + " del " + fecha + " al " + fechaf;
            }
            if (!concepto.Equals("0") && status.Equals("2") && contrato.Equals("0") && !fecha.Equals("0") && !fechaf.Equals("0") && reserva != 0 && hotel.Equals("0") && ejecutivo.Equals("0"))
                titulo = "de la reserva número " + reserva + " por concepto " + concepto;

            if (!concepto.Equals("0") && status.Equals("2") && contrato.Equals("0") && fecha.Equals("0") && fechaf.Equals("0") && reserva != 0 && !hotel.Equals("0") && !ejecutivo.Equals("0"))
                titulo = "del ejecutivo " + ejecutivo + " por concepto  " + concepto + " del hotel " + hotel + " de la reserva número " + reserva;

            if (!concepto.Equals("0") && status.Equals("2") && contrato.Equals("0") && !fecha.Equals("0") && !fechaf.Equals("0") && reserva == 0 && hotel.Equals("0") && !ejecutivo.Equals("0"))
                titulo = "del ejecutivo " + ejecutivo+" por concepto  " + concepto + " " + " del " + fecha + " al " + fechaf;

            if (!concepto.Equals("0") && status.Equals("2") && contrato.Equals("0") && !fecha.Equals("0") && !fechaf.Equals("0") && reserva == 0 && !hotel.Equals("0") && ejecutivo.Equals("0"))
                titulo = " por concepto  " + concepto + " del hotel " + hotel + " del " + fecha + " al " + fechaf;

            if (!concepto.Equals("0") && status.Equals("2") && contrato.Equals("0") && fecha.Equals("0") && fechaf.Equals("0") && reserva == 0 && !hotel.Equals("0") && ejecutivo.Equals("0"))
                titulo = " por concepto  " + concepto + " del hotel " + hotel;
                
                


            ReportParameter[] parameters = new ReportParameter[1];
            parameters[0] = new ReportParameter("titulo", titulo);

            _reportViewer.LocalReport.SetParameters(parameters);

            _reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            _reportViewer.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
            _reportViewer.RefreshReport();
        }
    }
}
