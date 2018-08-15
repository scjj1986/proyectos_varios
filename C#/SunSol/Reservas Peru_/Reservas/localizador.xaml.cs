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
using librerias;

namespace Reservas
{
    /// <summary>
    /// Lógica de interacción para localizador.xaml
    /// </summary>
    public partial class localizador : Page
    {
        dsCotizacionHabitacion dsH = new dsCotizacionHabitacion();
        public string user,contrato;
        public usuario us;
        public int numeroReserva = 0;
        bool depago = false;
        public localizador()
        {
            InitializeComponent();
        }

        private void txtNroReserva1_KeyUp(object sender, KeyEventArgs e)
        {
            DateTime? f = dpfecha1.SelectedDate;
            reservacion res = new reservacion();
            if ((txtCliente1.Text.Equals("")) && (txtNroContrato1.Text.Equals("")) && (f == null))
                dtgReservas1.ItemsSource = res.buscar_reservaConfirLoc(txtNroReserva1.Text, "0", "", "0");
            else
            {

                if ((!txtCliente1.Text.Equals("")) && (txtNroContrato1.Text.Equals("")) && (f == null))
                    dtgReservas1.ItemsSource = res.buscar_reservaConfirLoc(txtNroReserva1.Text, txtCliente1.Text, "", "0");
                else
                {
                    if ((!txtCliente1.Text.Equals("")) && (!txtNroContrato1.Text.Equals("")) && (f == null))
                        dtgReservas1.ItemsSource = res.buscar_reservaConfirLoc(txtNroReserva1.Text, txtCliente1.Text, "", txtNroContrato1.Text);
                    else
                    {
                        if ((!txtCliente1.Text.Equals("")) && (!txtNroContrato1.Text.Equals("")) && (f != null))
                        {
                            String[] ini = f.Value.ToShortDateString().Split('/');
                            String fechI = ini[2] + "/" + ini[1] + "/" + ini[0];
                            dtgReservas1.ItemsSource = res.buscar_reservaConfirLoc(txtNroReserva1.Text, txtCliente1.Text, fechI, txtNroContrato1.Text);
                        }

                    }
                }
            }
        }

        private void txtCliente1_KeyUp(object sender, KeyEventArgs e)
        {
            DateTime? f = dpfecha1.SelectedDate;
            reservacion res = new reservacion();
            if ((txtNroReserva1.Text.Equals("")) && (txtNroContrato1.Text.Equals("")) && (f == null))
                dtgReservas1.ItemsSource = res.buscar_reservaConfirLoc("0", txtCliente1.Text, "", "0");
            else
            {

                if ((!txtNroReserva1.Text.Equals("")) && (txtNroContrato1.Text.Equals("")) && (f == null))
                    dtgReservas1.ItemsSource = res.buscar_reservaConfirLoc(txtNroReserva1.Text, txtCliente1.Text, "", "0");
                else
                {
                    if ((!txtNroReserva1.Text.Equals("")) && (!txtNroContrato1.Text.Equals("")) && (f == null))
                        dtgReservas1.ItemsSource = res.buscar_reservaConfirLoc(txtNroReserva1.Text, txtCliente1.Text, "", txtNroContrato1.Text);
                    else
                    {
                        if ((!txtNroReserva1.Text.Equals("")) && (!txtNroContrato1.Text.Equals("")) && (f != null))
                        {
                            String[] ini = f.Value.ToShortDateString().Split('/');
                            String fechI = ini[2] + "/" + ini[1] + "/" + ini[0];
                            dtgReservas1.ItemsSource = res.buscar_reservaConfirLoc(txtNroReserva1.Text, txtCliente1.Text, fechI, txtNroContrato1.Text);
                        }

                    }
                }
            }
        }

        private void dpfecha1_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? f = dpfecha1.SelectedDate;
            if (f != null)
            {
                String[] ini = f.Value.ToShortDateString().Split('/');
                String fechI = ini[2] + "/" + ini[1] + "/" + ini[0];
                reservacion res = new reservacion();
                if ((txtCliente1.Text.Equals("")) && (txtNroReserva1.Text.Equals("")) && (txtNroContrato1.Text.Equals("")))
                    dtgReservas1.ItemsSource = res.buscar_reservaConfirLoc("0", "0", fechI, "0");
                else
                {
                    
                    if ((!txtCliente1.Text.Equals("")) && (txtNroReserva1.Text.Equals("")) && (txtNroContrato1.Text.Equals("")))
                        dtgReservas1.ItemsSource = res.buscar_reservaConfirLoc("0", txtCliente1.Text, fechI, "0");
                    else
                    {
                        if ((!txtCliente1.Text.Equals("")) && (!txtNroReserva1.Text.Equals("")) && (txtNroContrato1.Text.Equals("")))
                            dtgReservas1.ItemsSource = res.buscar_reservaConfirLoc(txtNroReserva1.Text, txtCliente1.Text, fechI, "0");
                        else
                        {
                            if ((!txtCliente1.Text.Equals("")) && (!txtNroReserva1.Text.Equals("")) && (!txtNroContrato1.Text.Equals("")))
                            {

                                dtgReservas1.ItemsSource = res.buscar_reservaConfirLoc(txtNroReserva1.Text, txtCliente1.Text, fechI, txtNroContrato1.Text);
                            }

                        }
                    }
                }
            }
        }

        private void txtNroContrato1_KeyUp(object sender, KeyEventArgs e)
        {
            DateTime? f = dpfecha1.SelectedDate;
            reservacion res = new reservacion();
            if ((txtCliente1.Text.Equals("")) && (txtNroReserva1.Text.Equals("")) && (f == null))
                dtgReservas1.ItemsSource = res.buscar_reservaConfirLoc("0", "0", "", txtNroContrato1.Text);
            else
            {
                
                if ((!txtCliente1.Text.Equals("")) && (txtNroReserva1.Text.Equals("")) && (f == null))
                    dtgReservas1.ItemsSource = res.buscar_reservaConfirLoc("0", txtCliente1.Text, "", txtNroContrato1.Text);
                else
                {
                    if ((!txtCliente1.Text.Equals("")) && (!txtNroReserva1.Text.Equals("")) && (f == null))
                        dtgReservas1.ItemsSource = res.buscar_reservaConfirLoc(txtNroReserva1.Text, txtCliente1.Text, "", txtNroContrato1.Text);
                    else
                    {
                        if ((!txtCliente1.Text.Equals("")) && (!txtNroReserva1.Text.Equals("")) && (f != null))
                        {
                            String[] ini = f.Value.ToShortDateString().Split('/');
                            String fechI = ini[2] + "/" + ini[1] + "/" + ini[0];
                            dtgReservas1.ItemsSource = res.buscar_reservaConfirLoc(txtNroReserva1.Text, txtCliente1.Text, fechI, txtNroContrato1.Text);
                        }

                    }
                }
            }
        }

        private void dtgReservas1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            object item = dtgReservas1.SelectedItem;
            if ((dtgReservas1.Items.Count > 0) && (item != null))
            {
                numeroReserva = Convert.ToInt32((dtgReservas1.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
                contrato = (dtgReservas1.SelectedCells[11].Column.GetCellContent(item) as TextBlock).Text;
                dsH.Clear();
                dsCotizacionHabitacionTableAdapters._V_cotizacionHabitacionTableAdapter tH = new dsCotizacionHabitacionTableAdapters._V_cotizacionHabitacionTableAdapter();
                tH.ClearBeforeFill = true;
                //tH.Fill(dsH._V_cotizacionHabitacion, numeroReserva);
                dtgdetalle.ItemsSource = tH.GetData(numeroReserva);
                btnGuardalocalizador.IsEnabled = true;
            }
        }

        private void btnGuardalocalizador_Click(object sender, RoutedEventArgs e)
        {
            if ((dtgReservas1.Items.Count > 0))
            {
                int loc = 0;
               
                for (int j = 0; j <= dtgdetalle.Items.Count - 1; j++)
                {
                    if ((dtgdetalle.Items[j] as System.Data.DataRowView).Row.ItemArray[9].ToString().Trim(new char[] {' '}).Equals(""))
                        loc++;

                }
                if (loc == dtgdetalle.Items.Count)
                {
                    MessageBox.Show("No ha proporcionado ningún localizador", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                if (loc > 0)
                {
                    if (MessageBox.Show("Hay " + loc + " habitacion(es) sin localizador, ¿Seguro desea continuar?", "Pregunta", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                    {
                        return;                        
                    }
                }
                reservacion res = new reservacion();

                for (int i = 0; i <= dtgdetalle.Items.Count - 1; i++)
                {

                    res.guardarlocalizador(numeroReserva, (dtgdetalle.Items[i] as System.Data.DataRowView).Row.ItemArray[9].ToString(), Convert.ToInt32((dtgdetalle.Items[i] as System.Data.DataRowView).Row.ItemArray[6].ToString()),txtObservacion.Text);
                    
                }
                //COncatenar localizador en pagos
                string locIC = "",locCPB="";
                for (int i = 0; i <= dtgdetalle.Items.Count - 1; i++)
                {
                    if ((dtgdetalle.Items[i] as System.Data.DataRowView).Row.ItemArray[0].ToString().Equals("COCHE PUNTA BLANCA"))
                        locCPB = locCPB + "," + (dtgdetalle.Items[i] as System.Data.DataRowView).Row.ItemArray[9].ToString();
                    if ((dtgdetalle.Items[i] as System.Data.DataRowView).Row.ItemArray[0].ToString().Equals("ISLA CARIBE"))
                        locIC = locIC + "," + (dtgdetalle.Items[i] as System.Data.DataRowView).Row.ItemArray[9].ToString();
                }
                if (!locIC.Equals(""))
                {
                    locIC = locIC.TrimStart(',');
                    locIC = locIC.TrimEnd(',');
                    res.localizadorPago(numeroReserva, locIC, "ISLA CARIBE");
                }
                if (!locCPB.Equals(""))
                {
                    locCPB = locCPB.TrimStart(',');
                    locCPB = locCPB.TrimEnd(',');
                    res.localizadorPago(numeroReserva, locCPB, "COCHE PUNTA BLANCA");
                }
                MessageBox.Show("Se han guardado los localizadores correctamente", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                if (loc == 0)
                {
                    MessageBox.Show("Se puede generar la confirmación de la reserva", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                    btnConfirmacion.IsEnabled = true;
                }else
                    btnConfirmacion.IsEnabled = false;
                
                /*dtgdetalle.ItemsSource = null;
                dtgReservas1.ItemsSource = null;
                txtCliente1.Text = "";
                txtNroContrato1.Text = "";
                txtNroReserva1.Text = "";
                dpfecha1.SelectedDate = null;*/
            }
        }

        private void dtgReservas1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (depago)
            {
                object item = dtgReservas1.SelectedItem;
                if ((dtgReservas1.Items.Count > 0) && (item != null))
                {
                    //numeroReserva = Convert.ToInt32((dtgReservas1.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);

                    dsH.Clear();
                    dsCotizacionHabitacionTableAdapters._V_cotizacionHabitacionTableAdapter tH = new dsCotizacionHabitacionTableAdapters._V_cotizacionHabitacionTableAdapter();
                    tH.ClearBeforeFill = true;
                    //tH.Fill(dsH._V_cotizacionHabitacion, numeroReserva);
                    dtgdetalle.ItemsSource = tH.GetData(numeroReserva);
                    btnGuardalocalizador.IsEnabled = true;
                    depago = false;
                }
            }
            else
            { 
                dtgdetalle.ItemsSource = null; 
                depago = false; 
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (numeroReserva > 0)
            {
                depago = true;
                txtNroReserva1.Text = numeroReserva.ToString();

               
            }
        }

        private void txtNroReserva1_TextChanged(object sender, TextChangedEventArgs e)
        {
            DateTime? f = dpfecha1.SelectedDate;
            reservacion res = new reservacion();
            if ((txtCliente1.Text.Equals("")) && (txtNroContrato1.Text.Equals("")) && (f == null))
                dtgReservas1.ItemsSource = res.buscar_reservaConfirLoc(txtNroReserva1.Text, "0", "", "0");
            else
            {

                if ((!txtCliente1.Text.Equals("")) && (txtNroContrato1.Text.Equals("")) && (f == null))
                    dtgReservas1.ItemsSource = res.buscar_reservaConfirLoc(txtNroReserva1.Text, txtCliente1.Text, "", "0");
                else
                {
                    if ((!txtCliente1.Text.Equals("")) && (!txtNroContrato1.Text.Equals("")) && (f == null))
                        dtgReservas1.ItemsSource = res.buscar_reservaConfirLoc(txtNroReserva1.Text, txtCliente1.Text, "", txtNroContrato1.Text);
                    else
                    {
                        if ((!txtCliente1.Text.Equals("")) && (!txtNroContrato1.Text.Equals("")) && (f != null))
                        {
                            String[] ini = f.Value.ToShortDateString().Split('/');
                            String fechI = ini[2] + "/" + ini[1] + "/" + ini[0];
                            dtgReservas1.ItemsSource = res.buscar_reservaConfirLoc(txtNroReserva1.Text, txtCliente1.Text, fechI, txtNroContrato1.Text);
                        }

                    }
                }
            }
            dtgReservas1.SelectedIndex = 0;
            
        }

        private void btnConfirmacion_Click(object sender, RoutedEventArgs e)
        {
            cotizacion cot = new cotizacion();
            cot.user = user;
            cot.us = us;
            cot.contrato = contrato;
            cot.numeroReserva = numeroReserva;
            this.NavigationService.Navigate(cot);
        }

        private void txtNroReserva1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtNroContrato1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                e.Handled = false;
            else
                e.Handled = true;
        }
    }
}
