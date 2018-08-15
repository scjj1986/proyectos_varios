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
    /// Lógica de interacción para ReporteToallasPiscina.xaml
    /// </summary>
    public partial class ReporteToallasPiscina : Page
    {
        public ReporteToallasPiscina()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dpFecha.DisplayDateEnd = DateTime.Today;
        }

        private void tlGenerar_Click(object sender, RoutedEventArgs e)
        {
            _reportViewer.Clear();
            //dsbit.BeginInit();
            //pdsbit.Name = "DataSet1";
            this._reportViewer.LocalReport.ReportEmbeddedResource = "InventarioToallas.RepToaPisc.rdlc";
            this._reportViewer.LocalReport.DataSources.Clear();
            _reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            _reportViewer.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
            _reportViewer.RefreshReport();
        }
    }
}
