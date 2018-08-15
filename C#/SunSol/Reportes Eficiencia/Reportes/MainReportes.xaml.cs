using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Configuration;
using Librerias;
using System.Data;
using Microsoft.Reporting.WinForms;
using Reportes;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;


namespace Reportes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
  

        #region VARIABLES PUBLICAS

        ConexionBaseDatos Conexion = new ConexionBaseDatos();
        DataTable dtReportes = new DataTable();
        DataTable dtReportes2 = new DataTable();
        DataTable dtOficinas = new DataTable();
        string Observaciones;
        string SP;
        string conexion;
        string fecha;
        string hora;
        int valor;
        decimal acumulado;
        #endregion 
        
        #region Generar Conexion
        //public DataTable GeneralConexion(string NameConnection, string SintaxSQL, CommandType TypeMethod, List<Parameters> Parametros)
        //{
        //    DataTable dtFinal = new DataTable();
        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[NameConnection].ConnectionString.ToString()))
        //        {
        //            using (SqlCommand command = new SqlCommand())
        //            {
        //                connection.Open();
        //                command.Connection = connection;
        //                command.CommandType = TypeMethod;
        //                command.CommandText = SintaxSQL;
        //                command.CommandTimeout = 10;
        //                foreach (Parameters Param in Parametros)
        //                {
        //                    command.Parameters.AddWithValue(Param.nameValue, Param.Valor);
        //                }
        //                dtFinal.Load(command.ExecuteReader());
        //                connection.Close();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return dtFinal;
        //}

        #endregion

        public MainWindow()
        {
            InitializeComponent();
        }

        private void cargarOficinas()
        {
            dtOficinas = Conexion.GeneralConexion("Conexion03", "sp_mos_oficinas", CommandType.StoredProcedure, new List<Parameters>());
           
            cbx_Empresa.DisplayMemberPath = "Descripcion";
            cbx_Empresa.SelectedValuePath = "Codigo";
            cbx_Empresa.ItemsSource = dtOficinas.DefaultView;
            cbx_Empresa.SelectedIndex = 0;

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cargarOficinas();
            cbx_Empresa_DropDownClosed(null, null);
        }

        private void btn_GenerarReporte_Click(object sender, RoutedEventArgs e)
       {
           var dtObservaciones = new DataTable();
           
           List<Parameters> Parametros = new List<Parameters>();
           Parametros.Add(new Parameters { nameValue = "Fecha", Valor = dtp_fecha1.SelectedDate });
           dtObservaciones = Conexion.GeneralConexion(conexion, "SELECT * FROM Observaciones WHERE fecha='" + dtp_fecha1.SelectedDate + "'",CommandType.Text,new List<Parameters>());
           
           try
           {
               dtReportes = Conexion.GeneralConexion(conexion, "spRepEficiencia", CommandType.StoredProcedure, Parametros);
               dtReportes2 = Conexion.GeneralConexion(conexion, "spRepPresencias", CommandType.StoredProcedure, Parametros);
               if (dtObservaciones.Rows.Count==0)
               {
                   dtObservaciones = new DataTable();
                   Parametros.Add(new Parameters { nameValue = "@pobservaciones", Valor = txtObservacion.Text });
                   if (txtObservacion.Text!="")
                   {
                       dtObservaciones = Conexion.GeneralConexion(conexion, "sp_ins_Observaciones", CommandType.StoredProcedure, Parametros);
                       Observaciones = txtObservacion.Text;
                   }
                   else
                   {
                       Observaciones = " ";
                   }
                  
                 
               }
               else
               {
                   dtObservaciones = new DataTable();                  
                   Parametros = new List<Parameters>();
                   Parametros.Add(new Parameters { nameValue = "@pobservaciones", Valor = txtObservacion.Text });                   
                   dtObservaciones = Conexion.GeneralConexion(conexion, "sp_mod_Observaciones", CommandType.StoredProcedure, Parametros);
                   dtObservaciones = Conexion.GeneralConexion(conexion, "SELECT * FROM Observaciones WHERE fecha='" + dtp_fecha1.SelectedDate + "'", CommandType.Text, new List<Parameters>());
                   Observaciones = dtObservaciones.Rows[0]["Observaciones"].ToString();
               }              
               
               var dtReporteAux = (from dt in dtReportes.AsEnumerable()
                                   where dt.Field<string>("INDICADOR").Equals("1")
                                   select dt).AsDataView();
               var dtReporteSum = (from dt in dtReportes.AsEnumerable()
                                   where dt.Field<string>("INDICADOR").Equals("0")
                                   select dt).AsDataView();
             
              

                   RwReportes.LocalReport.DataSources.Clear();

                   RwReportes.LocalReport.ReportEmbeddedResource = "Reportes.Reportes.ReportEficiencia.rdlc";                   
                   RwReportes.LocalReport.DataSources.Add(new ReportDataSource("dsEficiencia", dtReporteAux));
                   RwReportes.LocalReport.DataSources.Add(new ReportDataSource("dsPresencia", dtReportes2));
                   RwReportes.LocalReport.DataSources.Add(new ReportDataSource("dsSum", dtReporteSum));
                   ReportParameter[] parametrosEficiencia = new ReportParameter[3];
                   parametrosEficiencia[0] = new ReportParameter("Fecha", Convert.ToDateTime(dtp_fecha1.Text).ToShortDateString());
                   parametrosEficiencia[1] = new ReportParameter("Observaciones", Observaciones);
                   parametrosEficiencia[2] = new ReportParameter("oficina", "Oficina: "+cbx_Empresa.Text);
                   //cbx_Empresa.SelectedValue
                   RwReportes.LocalReport.SetParameters(parametrosEficiencia);   
                   RwReportes.LocalReport.Refresh();
                   RwReportes.RefreshReport();
                   RwReportes.Refresh();
                   txtObservacion.Text = "";
               
           }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error con la conexión esto puede ser ocasionado por un problema de red o de configuración de la aplicación. Comunicarse con el Departamento de Sistemas. " + ex);
                }
            }
       

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Desea Salir del Reporte de Eficiencia","Confirmación",MessageBoxButton.YesNo,MessageBoxImage.Warning)==MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Acercade acerca= new Acercade();
            acerca.Show();
            
            
        }

        private void cbx_Empresa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void cbx_Empresa_MouseLeave(object sender, MouseEventArgs e)
        {
            //if (cbx_Empresa.Text == "Isla Caribe" || cbx_Empresa.Text == "Punta Blanca")
            //{
            //    chkTelefonos.Visibility = Visibility.Visible;
            //}
            //else
            //{
            //    chkTelefonos.Visibility = Visibility.Hidden;
            //}
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();


        }

        private void cbx_Empresa_DropDownClosed(object sender, EventArgs e)
        {
            conexion = dtOficinas.Select("Codigo='" + cbx_Empresa.SelectedValue + "'")[0]["nbConexion"].ToString();
        }
    }

}

