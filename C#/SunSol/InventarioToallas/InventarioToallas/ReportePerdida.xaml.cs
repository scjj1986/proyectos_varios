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
using Microsoft.Reporting.WinForms;
using System.Data;

namespace InventarioToallas
{
    /// <summary>
    /// Lógica de interacción para ReportePerdida.xaml
    /// </summary>
    public partial class ReportePerdida : Page
    {
        dsReportePerdida dsper = new dsReportePerdida();
        ReportDataSource pdsper = new ReportDataSource();
        public ReportePerdida()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void dpFechaI_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? f = dpFechaI.SelectedDate;
            if (f != null)
                dpFechaF.DisplayDateStart = dpFechaI.SelectedDate;
        }

        private void tlGuardar_Click(object sender, RoutedEventArgs e)
        {
            DateTime? fi = dpFechaI.SelectedDate;
            DateTime? ff = dpFechaF.SelectedDate;
            if (txtBuscarHab.Text.Equals("") && fi == null && ff == null)
            {
                return;
            }
            string titulo = "";
            dsper.Clear();
            _reportViewer.Clear();
            dsper.BeginInit();
            pdsper.Name = "DataSet1";
            pdsper.Value = dsper._v_ReportePerdida;
            _reportViewer.LocalReport.DataSources.Add(pdsper);
            dsper.EndInit();
            this._reportViewer.LocalReport.ReportEmbeddedResource = "InventarioToallas.ReportePerdida.rdlc";
            dsReportePerdidaTableAdapters._v_ReportePerdidaTableAdapter taPer = new dsReportePerdidaTableAdapters._v_ReportePerdidaTableAdapter();
            taPer.ClearBeforeFill = true;

            if (!txtBuscarHab.Text.Equals("") && fi == null && ff == null)
            {
                titulo = titulo + " habitación " + txtBuscarHab.Text;
                taPer.Fill(dsper._v_ReportePerdida, txtBuscarHab.Text);

            }
            if (fi != null && ff != null && txtBuscarHab.Text.Equals(""))
            {
                titulo = titulo + " desde " + dpFechaI.SelectedDate.Value.ToShortDateString() + " hasta " + dpFechaF.SelectedDate.Value.ToShortDateString();
                taPer.FillFecha(dsper._v_ReportePerdida, dpFechaI.SelectedDate.Value.ToShortDateString(), dpFechaF.SelectedDate.Value.ToShortDateString());
                Console.WriteLine(dpFechaI.SelectedDate.Value.ToShortDateString());
                Console.WriteLine(dpFechaF.SelectedDate.Value.ToShortDateString());
            }
            if (!txtBuscarHab.Text.Equals("") && fi != null && ff != null)
            {
                titulo = titulo + " habitación " + txtBuscarHab.Text + " desde " + dpFechaI.SelectedDate.Value.ToShortDateString() + " hasta " + dpFechaF.SelectedDate.Value.ToShortDateString();
                taPer.FillTodo(dsper._v_ReportePerdida, txtBuscarHab.Text, dpFechaI.SelectedDate.Value.ToShortDateString(), dpFechaF.SelectedDate.Value.ToShortDateString());
            }
            ReportParameter[] parameters = new ReportParameter[1];
            parameters[0] = new ReportParameter("titulo", titulo);

            _reportViewer.LocalReport.SetParameters(parameters);
            _reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            _reportViewer.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
            _reportViewer.RefreshReport();
        }

        private void txtBuscarHab_LostFocus(object sender, RoutedEventArgs e)
        {
            txtBuscarHab.Text = txtBuscarHab.Text.ToUpper();
        }
    }
}
