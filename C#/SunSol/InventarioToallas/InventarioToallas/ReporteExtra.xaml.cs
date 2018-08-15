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
namespace InventarioToallas
{
    /// <summary>
    /// Lógica de interacción para ReporteExtra.xaml
    /// </summary>
    public partial class ReporteExtra : Page
    {
       dsReporteExtra dsext = new dsReporteExtra();
        ReportDataSource pdsext = new ReportDataSource();
        public ReporteExtra()
        {
            InitializeComponent();
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
            dsext.Clear();
            _reportViewer.Clear();
            dsext.BeginInit();
            pdsext.Name = "DataSet1";
            pdsext.Value = dsext._v_ReporteExtras;
            _reportViewer.LocalReport.DataSources.Add(pdsext);
            dsext.EndInit();
            this._reportViewer.LocalReport.ReportEmbeddedResource = "InventarioToallas.ReporteExtras.rdlc";
            dsReporteExtraTableAdapters._v_ReporteExtrasTableAdapter taExt =new dsReporteExtraTableAdapters._v_ReporteExtrasTableAdapter();
            taExt.ClearBeforeFill = true;

            if (!txtBuscarHab.Text.Equals("") && fi == null && ff == null)
            {
                titulo = titulo + " habitación " + txtBuscarHab.Text;
                taExt.Fill(dsext._v_ReporteExtras, txtBuscarHab.Text);

            }
            if (fi != null && ff != null && txtBuscarHab.Text.Equals(""))
            {
                titulo = titulo + " desde " + dpFechaI.SelectedDate.Value.ToShortDateString() + " hasta " + dpFechaF.SelectedDate.Value.ToShortDateString();
                taExt.FillFecha(dsext._v_ReporteExtras, dpFechaI.SelectedDate.Value.ToShortDateString(), dpFechaF.SelectedDate.Value.ToShortDateString());
            }
            if (!txtBuscarHab.Text.Equals("") && fi != null && ff != null)
            {
                titulo = titulo + " habitación " + txtBuscarHab.Text + " desde " + dpFechaI.SelectedDate.Value.ToShortDateString() + " hasta " + dpFechaF.SelectedDate.Value.ToShortDateString();
                taExt.FillTodo(dsext._v_ReporteExtras, txtBuscarHab.Text, dpFechaI.SelectedDate.Value.ToShortDateString(), dpFechaF.SelectedDate.Value.ToShortDateString());
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
