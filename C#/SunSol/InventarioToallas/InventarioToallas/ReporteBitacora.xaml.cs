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
    /// Lógica de interacción para ReporteBitacora.xaml
    /// </summary>
    public partial class ReporteBitacora : Page
    {

        dsReporteBitacora dsbit = new dsReporteBitacora();
        ReportDataSource pdsbit = new ReportDataSource();
        
        public ReporteBitacora()
        {
            InitializeComponent();
        }

        #region EVENTO CARGAR DE LA PÁGINA
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            dpFecha.DisplayDateEnd = DateTime.Today;
            cargar_cmbModulo();
            cargar_cmbAccion();


        }

        #endregion

        #region MÉTODOS DE APOYO PARA CARGAR COMBOBOX DE MÓDULO Y ACCIÓN

        public void cargar_cmbModulo()
        {
            Clases.ModuloBitacora mb = new Clases.ModuloBitacora();
            cmbModulo.ItemsSource = mb.listar();
            cmbModulo.DisplayMemberPath = "nombre";
            cmbModulo.SelectedValuePath = "idmodulo";
        }

        public void cargar_cmbAccion()
        {
            
            Clases.AccionesModulo am = new Clases.AccionesModulo();
            cmbAccion.ItemsSource = am.listar();
            cmbAccion.DisplayMemberPath = "nombre";
            cmbAccion.SelectedValuePath = "idaccion";

        }

        #endregion


        

        #region MÉTODOS TIPO STRING QUE DEVUELVE UNA CADENA DE CARACTERES EN FORMATO DATETIME (AAAA-MM-DD hh:mm:ss)  
        public string convertirfechahora(string hora)
        {
            string fecha = Convert.ToString(dpFecha.SelectedDate);
            fecha = fecha.Replace(" 12:00:00 a.m.", "");
            String[] fch = fecha.Split('/');
            fecha = fch[2] + fch[1] + fch[0];
            fecha += hora;
            return fecha;

        }

        #endregion



        #region EVENTO CLICK BOTÓN GENERAR

        private void tlGenerar_Click(object sender, RoutedEventArgs e)
        {
            DateTime? f = dpFecha.SelectedDate;
            string titulo="";
            string txtSQL = "SELECT * FROM v_Bitacora WHERE ";

            if (f == null && string.IsNullOrWhiteSpace(txtNHab.Text) && string.IsNullOrWhiteSpace(cmbModulo.Text) &&  string.IsNullOrWhiteSpace(cmbAccion.Text) &&   string.IsNullOrWhiteSpace(txtUsuario.Text))
                return;
            
           
            
            //--------------- Procesamiento de la consulta (txtSQL), dependiendo de los parámetros seleccionados por el usuario -----------------------//


            if (f != null)
            {

                if (Convert.ToDateTime(dpFecha.SelectedDate).ToShortDateString() != "01/01/0001")
                {
                    txtSQL += "(fecha BETWEEN '" + convertirfechahora(" 00:00:00") + "' AND '" + convertirfechahora(" 23:59:59") + "') AND ";
                    titulo = "Fecha='" + Convert.ToDateTime(dpFecha.SelectedDate).ToShortDateString() + "', ";

                }
            }

            if (!string.IsNullOrWhiteSpace(txtNHab.Text)) {

                txtSQL += " descripcion like '%" + txtNHab.Text.ToUpper() + "%' AND";
                titulo += "N. Hab.='" + txtNHab.Text.ToUpper() + "', ";
            
            }


            if (cmbModulo.SelectedValue!=null)
            {

                txtSQL += " idModulo=" + cmbModulo.SelectedValue.ToString() + " AND";
                titulo += "Módulo='" + cmbModulo.Text + "', ";
            }


            if (cmbAccion.SelectedValue != null)
            {

                txtSQL += " idaccion=" + cmbAccion.SelectedValue.ToString() + " AND";
                titulo += "Acción='" + cmbAccion.Text + "', ";
            }


            if (!string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                txtSQL += " usuario like '%" + txtUsuario.Text.ToUpper() + "%' AND";
                titulo += "Usuario='" + txtUsuario.Text + "', ";

            }

            txtSQL = txtSQL.Substring(0, txtSQL.Length - 4);
            titulo = titulo.Substring(0, titulo.Length - 2);
            //-------------------------------------------------------------------------------------------------------------------------------------//



            //--Limpieza de los parámetros ---//
            cmbAccion.SelectedValue = -1;
            cmbModulo.SelectedValue = -1;
            txtUsuario.Text = "";
            txtNHab.Text = "";
            //------------------------------//


            //-----Limpieza del informe---------//
            dsbit.Clear();
            _reportViewer.Clear();
            dsbit.BeginInit();
            pdsbit.Name = "DataSet1";
            this._reportViewer.LocalReport.ReportEmbeddedResource = "InventarioToallas.ReporteBitacoras.rdlc";
            this._reportViewer.LocalReport.DataSources.Clear();
            //-----------------------------------//

            Clases.Bitacora bit = new Clases.Bitacora();
            bit.cargar_dtt(txtSQL);//Carga del datatable con la consulta generada de acuerdo con los parámetros ingresados
            if (bit.dtt.Rows.Count == 0)
            {

                MessageBox.Show("No hubo coincidencias con los parámetros establecidos", "Sin Resultados", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            


            //-------- Carga de las coincidencias en el informe ---------------------------------------------------//
            _reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", bit.dtt));//Conjunto de Datos (Ver Datos de Informe en el archivo .rdlc)
            ReportParameter[] parameters = new ReportParameter[1];
            parameters[0] = new ReportParameter("titulo", titulo);
            _reportViewer.LocalReport.SetParameters(parameters);
            _reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            _reportViewer.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
            _reportViewer.RefreshReport();
            //---------------------------------------------------------------------------------------------------//

            
        }

        #endregion
    }
}
