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
    /// Lógica de interacción para reporteEdoCtaCliCon.xaml
    /// </summary>
    public partial class reporteEdoCtaCliCon : MetroWindow
    {

        dsRepEdoCtaCliCon dsRep = new dsRepEdoCtaCliCon();
        ReportDataSource rdsRepRes = new ReportDataSource();
        ReportDataSource rdsRepRes2 = new ReportDataSource();
        ReportDataSource rdsRepRes3 = new ReportDataSource();
        ReportDataSource rdsRepRes4 = new ReportDataSource();
        
        public reporteEdoCtaCliCon()
        {
            InitializeComponent();
        }

        public string ncontrato;

        private void vtnReporteEdoCtaCliCon_Loaded(object sender, RoutedEventArgs e)
        {



            dsRep.EnforceConstraints = false;
            dsRep.Clear();
            //string titulo = "";
            _reportViewer.Clear();
            dsRep.BeginInit();
            rdsRepRes.Name = "DataSet1";
            rdsRepRes.Value = dsRep._sp_buscarContrato;

            rdsRepRes2.Name = "DataSet2";
            rdsRepRes2.Value = dsRep._sp_buscarReservaPorNContrato;

            rdsRepRes3.Name = "DataSet3";
            rdsRepRes3.Value = dsRep.SumReservas;

            rdsRepRes4.Name = "DataSet4";
            rdsRepRes4.Value = dsRep.RelacionPuntosPorAnio;


            _reportViewer.LocalReport.DataSources.Add(rdsRepRes);
            _reportViewer.LocalReport.DataSources.Add(rdsRepRes2);
            _reportViewer.LocalReport.DataSources.Add(rdsRepRes3);
            _reportViewer.LocalReport.DataSources.Add(rdsRepRes4);

            dsRep.EndInit();
            this._reportViewer.LocalReport.ReportEmbeddedResource = "Reservas.reporteECC.rdlc";

            dsRepEdoCtaCliConTableAdapters._sp_buscarContratoTableAdapter tc = new dsRepEdoCtaCliConTableAdapters._sp_buscarContratoTableAdapter();
            tc.ClearBeforeFill = true;
            tc.Fill(dsRep._sp_buscarContrato,ncontrato);

            dsRepEdoCtaCliConTableAdapters._sp_buscarReservaPorNContratoTableAdapter tc2 = new dsRepEdoCtaCliConTableAdapters._sp_buscarReservaPorNContratoTableAdapter();
            tc2.ClearBeforeFill = true;
            tc2.Fill(dsRep._sp_buscarReservaPorNContrato, Convert.ToInt32(ncontrato));

            dsRepEdoCtaCliConTableAdapters.SumReservasTableAdapter tc3 = new dsRepEdoCtaCliConTableAdapters.SumReservasTableAdapter();
            tc3.ClearBeforeFill = true;
            tc3.Fill(dsRep.SumReservas,Convert.ToInt32(ncontrato));


            dsRepEdoCtaCliConTableAdapters.RelacionPuntosPorAnioTableAdapter tc4 = new dsRepEdoCtaCliConTableAdapters.RelacionPuntosPorAnioTableAdapter();
            tc4.ClearBeforeFill = true;
            tc4.Fill(dsRep.RelacionPuntosPorAnio,ncontrato);

            


            _reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            _reportViewer.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
            _reportViewer.RefreshReport();


        }
    }
}
