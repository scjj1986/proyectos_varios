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
    /// Lógica de interacción para reporteAsigMov.xaml
    /// </summary>
    
    public partial class reporteAsigMov : Page
    {
        dsReporteAsigSum dsras = new dsReporteAsigSum();
        ReportDataSource rdsras = new ReportDataSource();
        public reporteAsigMov()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
           

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
            dsras.Clear();
            _reportViewer.Clear();
            dsras.BeginInit();
            rdsras.Name = "DataSet1";
            rdsras.Value = dsras._v_reporteAsigSum;
            _reportViewer.LocalReport.DataSources.Add(rdsras);
            dsras.EndInit();
            if (rbSoloToalla.IsChecked == false)
            {
                this._reportViewer.LocalReport.ReportEmbeddedResource = "InventarioToallas.AsignacionSum.rdlc";
                dsReporteAsigSumTableAdapters._v_reporteAsigSumTableAdapter asigSumTa = new dsReporteAsigSumTableAdapters._v_reporteAsigSumTableAdapter();
                asigSumTa.ClearBeforeFill = true;

                if (!txtBuscarHab.Text.Equals("") && fi == null && ff == null)
                {
                    titulo = titulo + " habitación " + txtBuscarHab.Text;
                    asigSumTa.Fill(dsras._v_reporteAsigSum, txtBuscarHab.Text);

                }
                if (fi != null && ff != null && txtBuscarHab.Text.Equals(""))
                {
                    titulo = titulo + " desde " + dpFechaI.SelectedDate.Value.ToShortDateString() + " hasta " + dpFechaF.SelectedDate.Value.ToShortDateString();
                    asigSumTa.FillFecha(dsras._v_reporteAsigSum, dpFechaI.SelectedDate.Value.ToShortDateString(), dpFechaF.SelectedDate.Value.ToShortDateString());
                }
                if (!txtBuscarHab.Text.Equals("") && fi != null && ff != null)
                {
                    titulo = titulo + " habitación " + txtBuscarHab.Text + " desde " + dpFechaI.SelectedDate.Value.ToShortDateString() + " hasta " + dpFechaF.SelectedDate.Value.ToShortDateString();
                    asigSumTa.FillTodo(dsras._v_reporteAsigSum, txtBuscarHab.Text, dpFechaI.SelectedDate.Value.ToShortDateString(), dpFechaF.SelectedDate.Value.ToShortDateString());
                }
              
            }
            else
            {
                this._reportViewer.LocalReport.ReportEmbeddedResource = "InventarioToallas.ReporteToallas.rdlc";
                dsReporteAsigSumTableAdapters._v_reporteAsigSumTableAdapter asigSumTa = new dsReporteAsigSumTableAdapters._v_reporteAsigSumTableAdapter();
                asigSumTa.ClearBeforeFill = true;
                if (!txtBuscarHab.Text.Equals("") && fi == null && ff == null&&cmbModulo.SelectedIndex==-1&&cmbPiso.SelectedIndex==-1)
                {
                    titulo = titulo + " habitación " + txtBuscarHab.Text;
                    asigSumTa.FillSoloToallaHab(dsras._v_reporteAsigSum, txtBuscarHab.Text);

                }
                if (fi != null && ff != null && txtBuscarHab.Text.Equals("") && cmbModulo.SelectedIndex == -1 && cmbPiso.SelectedIndex == -1)
                {
                    titulo = titulo + " desde " + dpFechaI.SelectedDate.Value.ToShortDateString() + " hasta " + dpFechaF.SelectedDate.Value.ToShortDateString();
                    asigSumTa.FillToallasFech(dsras._v_reporteAsigSum, dpFechaI.SelectedDate.Value.ToShortDateString(), dpFechaF.SelectedDate.Value.ToShortDateString());
                }
                if (!txtBuscarHab.Text.Equals("") && fi != null && ff != null && cmbModulo.SelectedIndex == -1 && cmbPiso.SelectedIndex == -1)
                {
                    titulo = titulo + " habitación " + txtBuscarHab.Text + " desde " + dpFechaI.SelectedDate.Value.ToShortDateString() + " hasta " + dpFechaF.SelectedDate.Value.ToShortDateString();
                    asigSumTa.FillToallaTodo(dsras._v_reporteAsigSum, txtBuscarHab.Text, dpFechaI.SelectedDate.Value.ToShortDateString(), dpFechaF.SelectedDate.Value.ToShortDateString());
                }
                if (fi != null && ff != null && txtBuscarHab.Text.Equals("") && cmbModulo.SelectedIndex != -1 && cmbPiso.SelectedIndex != -1)
                {
                    titulo = titulo + "Módulo "+cmbModulo.SelectedValue.ToString()+" desde " + dpFechaI.SelectedDate.Value.ToShortDateString() + " hasta " + dpFechaF.SelectedDate.Value.ToShortDateString();
                    asigSumTa.FillToaFEchModPs(dsras._v_reporteAsigSum, cmbModulo.SelectedValue.ToString(), cmbPiso.SelectedValue.ToString(), dpFechaI.SelectedDate.Value.ToShortDateString(), dpFechaF.SelectedDate.Value.ToShortDateString());
                }
                if (fi != null && ff != null && txtBuscarHab.Text.Equals("") && cmbModulo.SelectedIndex != -1 && cmbPiso.SelectedIndex == -1)
                {
                    titulo = titulo + "Módulo " + cmbModulo.SelectedValue.ToString() + " desde " + dpFechaI.SelectedDate.Value.ToShortDateString() + " hasta " + dpFechaF.SelectedDate.Value.ToShortDateString();
                    asigSumTa.FillToaFechMod(dsras._v_reporteAsigSum,cmbModulo.SelectedValue.ToString(), dpFechaI.SelectedDate.Value.ToShortDateString(), dpFechaF.SelectedDate.Value.ToShortDateString());
                }

            }
          
            ReportParameter[] parameters = new ReportParameter[1];
            parameters[0] = new ReportParameter("titulo", titulo);

            _reportViewer.LocalReport.SetParameters(parameters);
            _reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            _reportViewer.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
            _reportViewer.RefreshReport();

        }


        private void dpFechaI_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? f = dpFechaI.SelectedDate;
            if (f != null) 
                dpFechaF.DisplayDateStart = dpFechaI.SelectedDate;
        }

        
        private void rbSoloToalla_Checked(object sender, RoutedEventArgs e)
        {
            cmbModulo.IsEnabled = true;
            cmbPiso.IsEnabled = true;
            Clases.habitacionIqware hI = new Clases.habitacionIqware();
            cmbModulo.ItemsSource = hI.listarModulos();
            cmbModulo.DisplayMemberPath = "descripcion";
            cmbModulo.SelectedValuePath = "descripcion";
        }

        private void cmbModulo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbModulo.SelectedValue != null)
            {
                Clases.habitacionIqware hI = new Clases.habitacionIqware();
                cmbPiso.ItemsSource = hI.listarPisos(cmbModulo.SelectedValue.ToString());
                cmbPiso.DisplayMemberPath = "descripcion";
                cmbPiso.SelectedValuePath = "idModulo";
                if (cmbModulo.SelectedValue.ToString().Equals("Tropical"))
                {
                    List<Clases.modulo> lis = new List<Clases.modulo>();
                    foreach (Clases.modulo m in cmbPiso.ItemsSource)
                    {
                        if (m.idModulo!=186)
                            lis.Add(m);
                    }
                    cmbPiso.ItemsSource =lis;
                    cmbPiso.DisplayMemberPath = "descripcion";
                    cmbPiso.SelectedValuePath = "idModulo";
                }
            }
        }

        private void rbSoloToalla_Unchecked(object sender, RoutedEventArgs e)
        {
            cmbModulo.ItemsSource = null;
            cmbPiso.ItemsSource = null;
            cmbModulo.IsEnabled = false;
            cmbPiso.IsEnabled = false;
        }
    }
}
