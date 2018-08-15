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
using System.Data.SqlClient;
using System.Data;
using librerias;
using MahApps.Metro.Controls;
using System.Globalization;

namespace Reservas
{
    /// <summary>
    /// Lógica de interacción para trasladaPagos.xaml
    /// </summary>
    public partial class trasladaPagos : MetroWindow
    {
        public trasaccionPago p;
        public trasladaPagos()
        {
            InitializeComponent();
        }

        private void frmTraspaso_Loaded(object sender, RoutedEventArgs e)
        {
            lstCargos1.Items.Clear();
            lstReservas.Items.Clear();
            reservacion res=new reservacion();
            SqlDataReader sr = res.trasladoPagos();
            lstCargos1.Items.Add("TODO INCLUIDO");
            lstCargos1.Items.Add("PUNTOS ACELERADOS");     
            if (sr != null)
            {
                if (sr.HasRows)
                {
                    while (sr.Read())
                    {
                        lstReservas.Items.Add(sr.GetInt32(0) + "-" + sr.GetString(1).Trim(new char[] { ' ' }) + "-" + sr.GetInt32(3));
                    }
                }
            }
            sr.Close();
            DataTable dt = new DataTable();
            dt.Columns.Add("concepto");
            dt.Columns.Add("monto");
            dt.Columns.Add("puntosA");
            dt.Columns.Add("transaccion");
            dt.Columns.Add("documento");
            dt.Columns.Add("fecha");
            dt.Columns.Add("tipo");
            dt.Columns.Add("cuenta");
            dt.Columns.Add("hotel");
            dt.Columns.Add("observacion");
            DataRow row = dt.NewRow();
            row[0]=p.concepto;
            row[1] = p.monto.ToString("N2",CultureInfo.CreateSpecificCulture("es-VE"));
            row[2] = p.puntosA;
            row[3] = p.trasaccion;
            row[4] = p.documento;
            row[5] = p.fecha;
            row[6] = p.tipo;
            row[7] = p.cuenta;
            row[8] = p.hotel;
            row[9] = p.observacion;
            lstCargos1.Text = p.concepto;
            txtobservacion.Text = p.observacion;
            txtmonto1.Text = p.monto.ToString("N2", CultureInfo.CreateSpecificCulture("es-VE"));
            dt.Rows.Add(row);
            dtgPagos.ItemsSource = dt.DefaultView;           
            sr = res.buscar_cargos();           
            if (sr != null)
            {
                if (sr.HasRows)
                {
                    while (sr.Read())
                    {
                        lstCargos1.Items.Add(sr.GetString(0).Trim(new char[] { ' ' }));
                    }
                }
            }
        }

        private void txtmonto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void btnTraspasoPago_Click(object sender, RoutedEventArgs e)
        {
            if (txtmonto1.Text.Equals("")||lstCargos1.SelectedIndex==-1||lstReservas.SelectedIndex==-1)
            {
                MessageBox.Show("Debe todos los campos para el traspaso del pago", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            reservacion res = new reservacion();
            string[] r=lstReservas.SelectedItem.ToString().Split('-');
            res.agregar_Pago(p.reserva,lstCargos1.SelectedItem.ToString(),(-1*Convert.ToDouble(txtmonto1.Text)),p.trasaccion,p.documento,"",p.fecha,txtobservacion.Text,1,0,p.cuenta,p.tipo,"",p.puntosA);
            res.agregar_Pago(Convert.ToInt32(r[0]), lstCargos1.SelectedItem.ToString(), Convert.ToInt32(txtmonto1.Text), p.trasaccion, p.documento, "", p.fecha, txtobservacion.Text, 1, 0, p.cuenta, p.tipo, "", p.puntosA);
            MessageBox.Show("Se ha completado el traslado del pago correctamente", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Hide();
        }

        private void txtmonto1_KeyUp(object sender, KeyEventArgs e)
        {
            if (!txtmonto1.Text.Equals(""))
            {
                txtmonto1.Text = Convert.ToDouble(txtmonto1.Text).ToString("N2", CultureInfo.CreateSpecificCulture("es-ES"));
                string[] p = txtmonto1.Text.Split(',');
                txtmonto1.Select(p[0].Length, 0);
            }
        }

        private void lstReservas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnTraspasoPago.IsEnabled=true;
        }

       
        
    }
}
