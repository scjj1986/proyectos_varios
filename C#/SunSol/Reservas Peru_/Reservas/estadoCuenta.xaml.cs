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
using librerias;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace Reservas
{
    /// <summary>
    /// Lógica de interacción para estadoCuenta.xaml
    /// </summary>
    public partial class estadoCuenta : MetroWindow
    {
        public string contrato = "";
        public estadoCuenta()
        {
            InitializeComponent();
        }

        private void estadocuenta_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

        private void dtgrdContratos_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void dtgrdEstado_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                cliente cli = new cliente();
                DataTable dt = new DataTable();
                SqlDataReader sr = cli.EstadoCuenta(contrato);
                dt.Columns.Add("Num_Contrato");
                dt.Columns.Add("Cod_Cliente");
                dt.Columns.Add("Descripcion");
                dt.Columns.Add("Monto_Total");
                dt.Columns.Add("Monto_Pendiente");
                dt.Columns.Add("fec_venc");
                dt.Columns.Add("co_ven");
                if (sr != null)
                {
                    while (sr.Read())
                    {
                        DataRow r = dt.NewRow();
                        r[0] = sr.GetString(0).Trim(new char[] { ' ' });
                        r[1] = sr.GetString(1).Trim(new char[] { ' ' });
                        r[2] = sr.GetString(2).Trim(new char[] { ' ' });
                        r[3] = sr.GetDecimal(3).ToString("N2", CultureInfo.CreateSpecificCulture("es-VE"));
                        r[4] = sr.GetDecimal(4).ToString("N2", CultureInfo.CreateSpecificCulture("es-VE"));
                        r[5] = sr.GetDateTime(5).ToShortDateString();
                        r[6] = sr.GetString(6).Trim(new char[] { ' ' });
                        dt.Rows.Add(r);
                    }
                }
                dtgrdEstado.ItemsSource = dt.DefaultView;
                cli.con.cnxcP.Close();
                for (int i = 0; i <= dtgrdEstado.Items.Count - 1; i++)
                {
                    DateTime f=Convert.ToDateTime((dtgrdEstado.Items[i] as System.Data.DataRowView).Row.ItemArray[5].ToString());
                    if (!(dtgrdEstado.Items[i] as System.Data.DataRowView).Row.ItemArray[4].ToString().Equals("0,00") && DateTime.Compare(f, DateTime.Today) < 0)
                    {
                        lblAprobado.Visibility = System.Windows.Visibility.Hidden;
                        lblMora.Visibility = System.Windows.Visibility.Visible;
                        lblMora.Content = "EL CLIENTE TIENE PAGOS PENDIENTES";
                        break;

                    }
                    else
                    {
                        lblAprobado.Visibility = System.Windows.Visibility.Visible;
                        lblMora.Visibility = System.Windows.Visibility.Hidden;
                        lblAprobado.Content = "EL CLIENTE NO TIENE PAGOS PENDIENTES";
                    }
                }
                lblTitulo.Content = lblTitulo.Content + contrato;

            }
            catch 
            {
                MessageBox.Show("No se puede establecer conexión con el servidor de profit", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Visibility=System.Windows.Visibility.Hidden;
            }
        }
    }
}
