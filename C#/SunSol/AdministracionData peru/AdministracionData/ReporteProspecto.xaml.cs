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
    /// Lógica de interacción para ReporteProspecto.xaml
    /// </summary>
    public partial class ReporteProspecto : MetroWindow
    {
        dsReporteProspecto dshab = new dsReporteProspecto();
        ReportDataSource rphab = new ReportDataSource();
        public int sttsP=0, stts=0;
        public string sp, s;
        public DateTime? fi=null, ff=null;
        string titulo="";
        public int? loc=0;
        public string locacion = "";
        public ReporteProspecto()
        {
            InitializeComponent();
        }
        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            dshab.Clear();


            _reportViewer.Clear();
            dshab.BeginInit();
            rphab.Name = "DataSet1";
            rphab.Value = dshab.v_clientes;
            _reportViewer.LocalReport.DataSources.Add(rphab);
            dshab.EndInit();
            this._reportViewer.LocalReport.ReportEmbeddedResource = "AdministracionData.ReporteProspecto.rdlc";

            dsReporteProspectoTableAdapters.v_clientesTableAdapter ha = new dsReporteProspectoTableAdapters.v_clientesTableAdapter();
            ha.ClearBeforeFill = true;
            if (stts != 0 && sttsP != 0 &&fi.Equals(null) &&ff.Equals(null)&&loc==0)
            {
                titulo = titulo + "Estatus " + sp+" "+s;
                 ha.Fill(dshab.v_clientes,sttsP,stts);
            }
            if (stts != 0 && sttsP != 0 && !fi.Equals(null) && !ff.Equals(null) && loc == 0)
            {
                titulo = titulo + "Estatus " + sp + " " + s + " fecha de ingreso del " + fi.Value.ToShortDateString() + " hasta" + ff.Value.ToShortDateString();
                ha.FillByTodo(dshab.v_clientes, sttsP, stts,fi.Value.ToShortDateString(),ff.Value.ToShortDateString());
            }
            if (stts == 0 && sttsP == 0 && !fi.Equals(null) && !ff.Equals(null) && loc == 0)
            {
                titulo = titulo + " fecha de ingreso del "+ fi.Value.ToShortDateString() + " hasta" + ff.Value.ToShortDateString();
                ha.FillByFecha(dshab.v_clientes, fi.Value.ToShortDateString(), ff.Value.ToShortDateString());
            }

            if (stts != 0 && sttsP != 0 && fi.Equals(null) && ff.Equals(null) && loc != 0)
            {
                titulo = titulo + "Estatus " + sp + " " + s + " Locación/Campaña " + locacion;
                ha.FillL(dshab.v_clientes, sttsP, stts,loc);
            }
            if (stts != 0 && sttsP != 0 && !fi.Equals(null) && !ff.Equals(null) && loc != 0)
            {
                titulo = titulo + "Estatus " + sp + " " + s + " fecha de ingreso del " + fi.Value.ToShortDateString() + " hasta" + ff.Value.ToShortDateString() + " Locación/Campaña " + locacion;
                ha.FillByTodoL(dshab.v_clientes, sttsP, stts, fi.Value.ToShortDateString(), ff.Value.ToShortDateString(),loc);
            }
            if (stts == 0 && sttsP == 0 && !fi.Equals(null) && !ff.Equals(null) && loc != 0)
            {
                titulo = titulo + " fecha de ingreso del " + fi.Value.ToShortDateString() + " hasta" + ff.Value.ToShortDateString() + " Locación/Campaña " + locacion;
                ha.FillByFechaL(dshab.v_clientes, fi.Value.ToShortDateString(), ff.Value.ToShortDateString(),loc);
            }
           

            ReportParameter[] parameters = new ReportParameter[1];
            parameters[0] = new ReportParameter("titulo",titulo);
            //parameters[1] = new ReportParameter("supervisor", supervisor.nombre + " " + supervisor.apellido);

            _reportViewer.LocalReport.SetParameters(parameters);

            _reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            _reportViewer.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
            _reportViewer.RefreshReport();
        }
    }
}
