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
using System.Data.SqlClient;
using System.Data;
using librerias;
using System.ComponentModel;
using System.Globalization;
namespace Reservas
{
    /// <summary>
    /// Lógica de interacción para modificareserva.xaml
    /// </summary>
    public partial class modificareserva : Page
    {
        DataTable puntosAnios;
        string calendario;
        int puntosporanio;
        //variables de cantidades de la reserva
        int n_contrato = 0,  capacidad = 0, diasReserva = 0, infate = 0, ninio = 0, anioAc = 0, puntosacelerados = 0, totalnoches = 0,
            adulto = 0, puntosreserva = 0, agregado = 0, habitacion = 0, totalhabitacion = 0, hoteles = 0, cambiarow = 0;
        int numeroReserva = 0,puntosAnt = 0;
        string hotelHabqui;
        bool cambiahab = false;
        public String user, cliente;
        // datatables q manejan los datos de todos los grid contratos, puntos por año, persona, puntos de reserva, todo incluido y hoteles
        DataTable dtp, dtpun, dtTi, dtpunAnio, dtDes;
        //variable de adicion de habitaciones
        bool otra = false, otro = false;
        double totalTodoIncluido = 0, totalacelerado = 0, descuento = 0,total=0;
        string status, ultimohotel, ultimahabitacion,an_puntos,an_puntosA;
        DateTime? ultimaini, ultimafinal;
        int lp = 0, lt = 0;
        List<persona> tmp;
        public modificareserva()
        {
            InitializeComponent();

            hotel h = new hotel();
            SqlDataReader sr1 = h.buscar_hoteles();

            int i = 0;

            if (sr1 != null)
            {

                while (sr1.Read())
                {
                    lstHotel.Items.Add(sr1.GetString(i));
                }
                lstPersona.Items.Add("INFANTE(0 A 6 AÑOS)");
                lstPersona.Items.Add("NIÑO(7 A 12 AÑOS)");
                lstPersona.Items.Add("ADULTO");

            }
        }


        private void txtNroReserva_KeyUp(object sender, KeyEventArgs e)
        {
            DateTime? f = dpfecha.SelectedDate;
            reservacion res = new reservacion();
            if ((txtCliente.Text.Equals("")) && (txtNroContrato.Text.Equals("")) && (f == null))
                dtgReservas.ItemsSource = res.buscar_reserva(txtNroReserva.Text, "0", "", "0");
            else
            {
                if ((!txtCliente.Text.Equals("")) && (txtNroContrato.Text.Equals("")) && (f == null))
                    dtgReservas.ItemsSource = res.buscar_reserva(txtNroReserva.Text, txtCliente.Text, "", "0");
                else
                {
                    if ((!txtCliente.Text.Equals("")) && (!txtNroContrato.Text.Equals("")) && (f == null))
                        dtgReservas.ItemsSource = res.buscar_reserva(txtNroReserva.Text, txtCliente.Text, "", txtNroContrato.Text);
                    else
                    {
                        if ((!txtCliente.Text.Equals("")) && (!txtNroContrato.Text.Equals("")) && (f != null))
                        {
                            String[] ini = f.Value.ToShortDateString().Split('/');
                            String fechI = ini[2] + "/" + ini[1] + "/" + ini[0];
                            dtgReservas.ItemsSource = res.buscar_reserva(txtNroReserva.Text, txtCliente.Text, fechI, txtNroContrato.Text);
                        }
                    }
                }
            }
        }

        private void txtCliente_KeyUp(object sender, KeyEventArgs e)
        {
            DateTime? f = dpfecha.SelectedDate;
            reservacion res = new reservacion();
            if ((txtNroReserva.Text.Equals("")) && (txtNroContrato.Text.Equals("")) && (f == null))
                dtgReservas.ItemsSource = res.buscar_reserva("0", txtCliente.Text, "", "0");
            else
            {
                if ((!txtNroReserva.Text.Equals("")) && (txtNroContrato.Text.Equals("")) && (f == null))
                    dtgReservas.ItemsSource = res.buscar_reserva(txtNroReserva.Text, txtCliente.Text, "", "0");
                else
                {
                    if ((!txtNroReserva.Text.Equals("")) && (!txtNroContrato.Text.Equals("")) && (f == null))
                        dtgReservas.ItemsSource = res.buscar_reserva(txtNroReserva.Text, txtCliente.Text, "", txtNroContrato.Text);
                    else
                    {
                        if ((!txtNroReserva.Text.Equals("")) && (!txtNroContrato.Text.Equals("")) && (f != null))
                        {
                            String[] ini = f.Value.ToShortDateString().Split('/');
                            String fechI = ini[2] + "/" + ini[1] + "/" + ini[0];
                            dtgReservas.ItemsSource = res.buscar_reserva(txtNroReserva.Text, txtCliente.Text, fechI, txtNroContrato.Text);
                        }
                    }
                }
            }
        }

        private void txtNroContrato_KeyUp(object sender, KeyEventArgs e)
        {
            DateTime? f = dpfecha.SelectedDate;
            reservacion res = new reservacion();
            if ((txtCliente.Text.Equals("")) && (txtNroReserva.Text.Equals("")) && (f == null))
                dtgReservas.ItemsSource = res.buscar_reserva("0", "0", "", txtNroContrato.Text);
            else
            {
                if ((!txtCliente.Text.Equals("")) && (txtNroReserva.Text.Equals("")) && (f == null))
                    dtgReservas.ItemsSource = res.buscar_reserva("0", txtCliente.Text, "", txtNroContrato.Text);
                else
                {
                    if ((!txtCliente.Text.Equals("")) && (!txtNroReserva.Text.Equals("")) && (f == null))
                        dtgReservas.ItemsSource = res.buscar_reserva(txtNroReserva.Text, txtCliente.Text, "", txtNroContrato.Text);
                    else
                    {
                        if ((!txtCliente.Text.Equals("")) && (!txtNroReserva.Text.Equals("")) && (f != null))
                        {
                            String[] ini = f.Value.ToShortDateString().Split('/');
                            String fechI = ini[2] + "/" + ini[1] + "/" + ini[0];
                            dtgReservas.ItemsSource = res.buscar_reserva(txtNroReserva.Text, txtCliente.Text, fechI, txtNroContrato.Text);
                        }
                    }
                }
            }
        }

        private void dpfecha_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? f = dpfecha.SelectedDate;
            if (f != null)
            {
                String[] ini = f.Value.ToShortDateString().Split('/');
                String fechI = ini[2] + "/" + ini[1] + "/" + ini[0];
                reservacion res = new reservacion();
                if ((txtCliente.Text.Equals("")) && (txtNroReserva.Text.Equals("")) && (txtNroContrato.Text.Equals("")))
                    dtgReservas.ItemsSource = res.buscar_reserva("0", "0", fechI, "0");
                else
                {
                    if ((!txtCliente.Text.Equals("")) && (txtNroReserva.Text.Equals("")) && (txtNroContrato.Text.Equals("")))
                        dtgReservas.ItemsSource = res.buscar_reserva("0", txtCliente.Text, fechI, "0");
                    else
                    {
                        if ((!txtCliente.Text.Equals("")) && (!txtNroReserva.Text.Equals("")) && (txtNroContrato.Text.Equals("")))
                            dtgReservas.ItemsSource = res.buscar_reserva(txtNroReserva.Text, txtCliente.Text, fechI, "0");
                        else
                        {
                            if ((!txtCliente.Text.Equals("")) && (!txtNroReserva.Text.Equals("")) && (!txtNroContrato.Text.Equals("")))
                            {

                                dtgReservas.ItemsSource = res.buscar_reserva(txtNroReserva.Text, txtCliente.Text, fechI, txtNroContrato.Text);
                            }
                        }
                    }
                }
            }
        }

        private void dtgReservas_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //seleccion de una reserva
            object item = dtgReservas.SelectedItem;
            if ((dtgReservas.Items.Count > 0) && (item != null))
            {
                dtgPersona.IsEnabled = true;
                gdes.IsEnabled = true;
                dtp = null;
                dtpun = null;
                dtTi = null;
                dtDes = null;
                agregado = 0;
                dtgPersona.ItemsSource = null;
                dtgPersonaDes.ItemsSource = null;
                dtgPunto.ItemsSource = null;
                dtgTodoIncluido.ItemsSource = null;
                hoteles = 0;
                habitacion = 0;
                totalhabitacion = 0;
                totalacelerado = 0;
                totalTodoIncluido = 0;
                lt = 0;
                puntosacelerados = Convert.ToInt32((dtgReservas.SelectedCells[8].Column.GetCellContent(item) as TextBlock).Text);
                numeroReserva = Convert.ToInt32((dtgReservas.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
                puntosreserva = Convert.ToInt32((dtgReservas.SelectedCells[6].Column.GetCellContent(item) as TextBlock).Text);
                total = Convert.ToDouble((dtgReservas.SelectedCells[12].Column.GetCellContent(item) as TextBlock).Text);
                txtobservacion.Text = (dtgReservas.SelectedCells[13].Column.GetCellContent(item) as TextBlock).Text;
                status = (dtgReservas.SelectedCells[14].Column.GetCellContent(item) as TextBlock).Text.Trim(new char[] {' '});
                cliente = (dtgReservas.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
               
                
                n_contrato = Convert.ToInt32((dtgReservas.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text);
                cliente cli = new cliente();
                cli.buscar_cliente(cliente,n_contrato.ToString());
                DataTable dt1 = new DataTable();
                dt1.Columns.Add("contrato");
                dt1.Columns.Add("tipo");
                dt1.Columns.Add("puntos");
                dt1.Columns.Add("valor");
                dt1.Columns.Add("monto");
                dt1.Columns.Add("fp");
                dt1.Columns.Add("primerA");
                dt1.Columns.Add("cedula");                
                dt1.Columns.Add("calendario");
                dt1.Columns.Add("venta");
                dt1.Columns.Add("subtipo");
                dt1.Columns.Add("tabla");
                SqlDataReader sr1=cli.buscar_contratos(cliente,"",n_contrato.ToString());
                while (sr1.Read())
                {
                    DataRow r = dt1.NewRow();
                    r[0] = sr1.GetString(0);
                    r[1] = sr1.GetString(1);
                    r[2] = sr1.GetDecimal(2);
                    r[3] = sr1.GetDecimal(3);
                    r[4] = sr1.GetDecimal(4);
                    r[5] = sr1.GetDateTime(5);
                    r[6] = sr1.GetString(6);
                    r[7] = sr1.GetString(7);
                    r[8] = sr1.GetString(8);
                    r[9] = sr1.GetDateTime(9);
                    r[10] = sr1.GetInt32(10);
                    r[11] = sr1.GetInt32(11);
                    dt1.Rows.Add(r);
                    
               }
                sr1.Close();
                DateTime fechaVenta = Convert.ToDateTime(dt1.Rows[0][9].ToString());
                int subtipo = Convert.ToInt32(dt1.Rows[0][10].ToString());
                calendario = dt1.Rows[0][8].ToString();
                int tablaPuntos = Convert.ToInt32(dt1.Rows[0][11].ToString());
                //validaciones de los hoteles segun contrato******************************
                hotel h = new hotel();
                SqlDataReader sr2 = h.buscar_hoteles();
                DataTable dt = new DataTable();
                dt.Columns.Add("hoteles");

              
                while (sr2.Read())
                {
                    DataRow r = dt.NewRow();
                    r[0] = sr2.GetString(0);
                    dt.Rows.Add(r);
                }
                sr2.Close();
                lstHotel.Items.Clear();
                for (int l = 0; l < dt.Rows.Count; l++)
                {
                    lstHotel.Items.Add(dt.Rows[l][0].ToString());
                }
                if (!n_contrato.ToString()[0].Equals('6'))
                {
                    for (int l = 0; l < dt.Rows.Count; l++)
                    {
                        if (dt.Rows[l][0].ToString().Equals("COSTA AZUL"))
                            dt.Rows.RemoveAt(l);
                    }
                    lstHotel.Items.Clear();
                    for (int l = 0; l < dt.Rows.Count; l++)
                    {
                        lstHotel.Items.Add(dt.Rows[l][0].ToString());
                    }

                }
                if (tablaPuntos == 5)
                {
                    for (int l = 0; l < dt.Rows.Count; l++)
                    {
                        if (dt.Rows[l][0].ToString().Equals("PLAYA EL AGUA"))
                            dt.Rows.RemoveAt(l);
                    }
                    lstHotel.Items.Clear();
                    for (int l = 0; l < dt.Rows.Count; l++)
                    {
                        lstHotel.Items.Add(dt.Rows[l][0].ToString());
                    }
                }

                //contratos membresia platinum*********************************
                DateTime fechaPlatinumD = new DateTime(2013, 8, 1);
                DateTime fechaPlatinumH = new DateTime(2016, 12, 30);
                if (subtipo != 6 && (fechaVenta < fechaPlatinumD || fechaVenta > fechaPlatinumH))
                {
                    MessageBox.Show("Este contrato no incluye el hotel INTERNATIONAL DRIVE", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    //for (int l = 0; l < dt.Rows.Count; l++)
                    //{
                    //    if (dt.Rows[l][0].ToString().Equals("INTERNATIONAL DRIVE"))
                    //        dt.Rows.RemoveAt(l);
                    //}
                    //lstHotel.Items.Clear();
                    //for (int l = 0; l < dt.Rows.Count; l++)
                    //{
                    //    lstHotel.Items.Add(dt.Rows[l][0].ToString());
                    //}
                }

                //contratos membresia plus*********************************
                DateTime fechaPlusD = new DateTime(2012, 8, 1);
                DateTime fechaPlusH = new DateTime(2016, 3, 7);
                if (subtipo != 5 && fechaVenta < fechaPlusD || fechaVenta > fechaPlusH)
                {
                    MessageBox.Show("Este contrato no incluye el hotel INTERNATIONAL DRIVE","Advertencia",MessageBoxButton.OK,MessageBoxImage.Warning);
                    //for (int l = 0; l < dt.Rows.Count; l++)
                    //{
                    //    if (dt.Rows[l][0].ToString().Equals("INTERNATIONAL DRIVE"))
                    //        dt.Rows.RemoveAt(l);
                    //}
                    //lstHotel.Items.Clear();
                    //for (int l = 0; l < dt.Rows.Count; l++)
                    //{
                    //    lstHotel.Items.Add(dt.Rows[l][0].ToString());
                    //}
                }

                lbltitulo.Content = "Reserva N° ** " + numeroReserva.ToString() + " ** Cliente: "+cli.nombres+" "+cli.apellidos+"** Contrato Nº"+n_contrato.ToString();
                String[] fecha = (dtgReservas.SelectedCells[10].Column.GetCellContent(item) as TextBlock).Text.Split('-');
                cliente = (dtgReservas.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
               
                anioAc = Convert.ToInt32(fecha[2]);
                btnGuardaReserva.IsEnabled = true;
                dtgReservas.IsEnabled = false;
                puntosreserva = Convert.ToInt32((dtgReservas.SelectedCells[6].Column.GetCellContent(item) as TextBlock).Text);
                puntosAnt = puntosreserva;

                lblValorPuntosacelerados.Content = (dtgReservas.SelectedCells[8].Column.GetCellContent(item) as TextBlock).Text;
              
                double bspa = Convert.ToDouble((dtgReservas.SelectedCells[9].Column.GetCellContent(item) as TextBlock).Text);


                //lblValorTotalacelerado.Content = bspa.ToString("N2", CultureInfo.CreateSpecificCulture("es-VE"));

            

                // quitar_puntos();
                btnAgregarHabitacion.IsEnabled = true;
                btnAnular.IsEnabled = true;
                dtpunAnio = new DataTable();
                
                //ojo try catch****************************************************
                dtpunAnio.Load(cli.buscar_puntos(cliente,n_contrato));
                dtgrdPuntosPorAnio.ItemsSource = dtpunAnio.DefaultView;
                string[] p = dtpunAnio.Rows[0][4].ToString().Split(',');
                puntosporanio=Convert.ToInt32(p[0]);
                reservacion res = new reservacion();
                puntosAnios.Load(res.buscarPCReserva(numeroReserva));
                SqlDataReader sr = res.buscarHabitacion(numeroReserva);
                DataTable dtp1 = new DataTable();
                dtp1.Columns.Add("hotel");
                dtp1.Columns.Add("habitación");
                dtp1.Columns.Add("infantes");
                dtp1.Columns.Add("niños");
                dtp1.Columns.Add("adultos");
                if (sr != null)
                {
                    while (sr.Read())
                    {
                        DataRow row6 = dtp1.NewRow();
                        row6[0] = sr.GetString(0);
                        row6[1] = sr.GetString(1);
                        row6[2] = sr.GetInt32(2);
                        row6[3] = sr.GetInt32(3);
                        row6[4] = sr.GetInt32(4);
                        dtp1.Rows.Add(row6);
                    }
                    sr.Close();
                    sr = res.buscarHotel(numeroReserva);
                    int j = 0;
                    while (sr.Read())
                    {
                        descuento = sr.GetDouble(5);
                        for (int i = j; i <= dtp1.Rows.Count - 1; i++)
                        {
                            if (dtp1.Rows[i][0].ToString().Equals(sr.GetString(0)))
                            {

                                lstHotel.SelectedItem = dtp1.Rows[i][0].ToString();
                                lstHabitacion.SelectedItem = dtp1.Rows[i][1].ToString();
                                capacidad = Convert.ToInt32(lblValorCapacidad.Content);
                                if (lstHotel.SelectedValue.ToString().Equals("ISLA CARIBE"))
                                    capacidad++;
                                dpFechaI.SelectedDate = sr.GetDateTime(1);
                                dpFechaF.SelectedDate = sr.GetDateTime(2).AddDays(1);

                                if (Convert.ToInt32(dtp1.Rows[i][2].ToString()) > 0)
                                {
                                    for (int inf = 0; inf <= Convert.ToInt32(dtp1.Rows[i][2].ToString()) - 1; inf++)
                                    {
                                        lstPersona.SelectedIndex = 0;
                                        btnAgregar_Click(sender, e);
                                    }
                                }
                                if (Convert.ToInt32(dtp1.Rows[i][3].ToString()) > 0)
                                {
                                    for (int n = 0; n <= Convert.ToInt32(dtp1.Rows[i][3].ToString()) - 1; n++)
                                    {
                                        lstPersona.SelectedIndex = 1;
                                        btnAgregar_Click(sender, e);
                                    }
                                }
                                if (Convert.ToInt32(dtp1.Rows[i][4].ToString()) > 0)
                                {
                                    for (int a = 0; a <= Convert.ToInt32(dtp1.Rows[i][4].ToString()) - 1; a++)
                                    {
                                        lstPersona.SelectedIndex = 2;
                                        btnAgregar_Click(sender, e);
                                    }
                                }
                                otra = true;
                              //  lt = 0;
                                infate = 0;
                                ninio = 0;
                                adulto = 0;
                                agregado = 0;

                            }
                            else
                            {
                                infate = 0;
                                ninio = 0;
                                adulto = 0;
                                agregado = 0;
                               // lt = 0;
                                otra = false;
                                otro = true;
                                totalTodoIncluido = 0;
                                j = i;
                                break;
                            }
                        }
                      


                    }
                    //double totaTI = Convert.ToDouble(lblValorTotalTodoIncluido.Content) - descuento;
                    /// lblValorTotalTodoIncluido.Content = totaTI.ToString("N2", CultureInfo.CreateSpecificCulture("es-VE"));
                    lblValorPuntosReserva.Content = puntosAnt.ToString();
                    puntosreserva = puntosAnt;
                    otra = false;
                    otro = false;
                    infate = Convert.ToInt32(dtp.Rows[dtp.Rows.Count - 1][2].ToString());
                    ninio = Convert.ToInt32(dtp.Rows[dtp.Rows.Count - 1][3].ToString());
                    adulto = Convert.ToInt32(dtp.Rows[dtp.Rows.Count - 1][4].ToString());
                    agregado = infate + ninio + adulto;
                    if (status.Equals("ANULADA"))
                    {
                        dpFechaI.IsEnabled = false;
                        dpFechaF.IsEnabled = false;
                        lstHotel.IsEnabled = false;
                        lstHabitacion.IsEnabled = false;
                        lstPersona.IsEnabled = false;
                        btnAgregar.IsEnabled = false;
                        btnQuitarHabitacion.IsEnabled = false;
                        btnQuitarHotel.IsEnabled = false;
                        btnAgregarHabitacion.IsEnabled = false;
                        btnAgregarHotel.IsEnabled = false;
                        dtgPersona.IsEnabled = false;
                        gdes.IsEnabled = false;
                        btnAnular.IsEnabled = false;
                        btnGuarda.IsEnabled = false;
                        txtobservacion.IsEnabled = false;
                        btnGuardaReserva.IsEnabled = false;
                    }

                }
                lblValorTotalacelerado.Content = bspa.ToString("N2", CultureInfo.CreateSpecificCulture("es-VE"));
            }
        }

        private void inhabilita(String parte)
        {
            switch (parte)
            {
                case "tipo":
                    inhabilita("fecha");
                    dpFechaI.SelectedDate = null;
                    n_contrato = 0;
                    lbltitulo.Content = "";
                    dtgrdPuntosPorAnio.ItemsSource = null;
                    dpFechaF.IsEnabled = false;
                    dpFechaI.IsEnabled = false;
                    lstHotel.IsEnabled = false;
                    lstHabitacion.IsEnabled = false;
                    break;
                case "fecha":
                    lblValorPuntosReserva.Content = "";
                    dtp = null;
                    dtpun = null;
                    lstPersona.SelectedIndex = -1;
                    if (dtgPersona.ItemsSource != null && dtgPunto.ItemsSource != null)
                    {
                        dtgPersona.ItemsSource = null;
                        dtgPunto.ItemsSource = null;
                    }
                    if (dtgTodoIncluido.ItemsSource != null)
                        dtgTodoIncluido.ItemsSource = null;
                    dtTi = null;
                    puntosreserva = 0;
                    infate = 0;
                    ninio = 0;
                    adulto = 0;
                    agregado = 0;
                    btnAgregarHabitacion.IsEnabled = false;
                    btnAgregarHotel.IsEnabled = false;
                    habitacion = 0;
                    totalhabitacion = 0;
                    totalTodoIncluido = 0;
                    lblValorCantidadHabitaciones.Content = "";
                    lblValorTotalTodoIncluido.Content = 0;
                    break;
                case "todo":
                    hoteles = 0;
                    dtgrdPuntosPorAnio.ItemsSource = null;
                    dtgReservas.ItemsSource = null;
                    lblValorPuntosReserva.Content = "";
                    dtp = null;
                    dtpun = null;
                    dtTi = null;

                    lstPersona.SelectedIndex = -1;
                    lstHotel.SelectedIndex = -1;
                    lstHabitacion.SelectedIndex = -1;
                    if (dtgPersona.ItemsSource != null && dtgPunto.ItemsSource != null)
                    {
                        dtgPersona.ItemsSource = null;
                        dtgPunto.ItemsSource = null;
                    }
                    if (dtgTodoIncluido.ItemsSource != null)
                        dtgTodoIncluido.ItemsSource = null;

                    puntosreserva = 0;
                    infate = 0;
                    ninio = 0;
                    adulto = 0;
                    agregado = 0;
                    capacidad = 0;
                    n_contrato = 0;
                    lblValorCapacidad.Content = "";
                    dpFechaI.SelectedDate = null;
                    dpFechaF.SelectedDate = null;
                    dpFechaF.IsEnabled = false;
                    dpFechaI.IsEnabled = false;
                    lstHabitacion.IsEnabled = false;
                    lstHotel.IsEnabled = false;
                    btnAgregarHabitacion.IsEnabled = false;
                    btnAgregarHotel.IsEnabled = false;
                    habitacion = 0;
                    totalhabitacion = 0;
                    totalTodoIncluido = 0;
                    lblValorCantidadHabitaciones.Content = "";
                    lblValorTotalTodoIncluido.Content = 0;
                    //txtcedula.Text = "";
                    lbltitulo.Content = "";
                    otra = false;
                    dpFechaI.DisplayDateStart = DateTime.Today;
                    otro = false;
                    hoteles = 0;
                    //totalhabitacion = 0;
                    btnAgregarHotel.IsEnabled = false;
                    btnQuitarHotel.IsEnabled = false;
                    btnQuitarHabitacion.IsEnabled = false;
                    lblValortotalhabitaciones.Content = "";
                    lblValorHotelesreserva.Content = "";
                    lblValorTotalacelerado.Content = "";
                    lblValorPuntosacelerados.Content = "";
                    totalnoches = 0;
                    lp = 0;
                    numeroReserva = 0;
                    dtDes = null;
                    btnGuardaReserva.IsEnabled = false;
                    dtgReservas.IsEnabled = true;
                    txtobservacion.Text = "";
                    //txtNroReserva.Text = "";
                    //txtCliente.Text = "";
                    // dpfecha.SelectedDate = null;
                    // txtNroContrato.Text = "";
                    // dtgPersonaDes.ItemsSource = null;
                      an_puntos = "";
                      an_puntosA = "";
                      puntosAnios.Rows.Clear();
                    break;
            }
        }

        private void dpFechaI_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? fi = dpFechaI.SelectedDate;
            if (fi != null)
            {
                dpFechaF.DisplayDateStart = dpFechaI.SelectedDate;
            }
            if (dtp != null)
            {
                if (dtp.Rows.Count == 0)
                    inhabilita("fecha");
            }
        }

        private void dpFechaF_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? ff = dpFechaF.SelectedDate;
            DateTime? fi = dpFechaI.SelectedDate;
            if ((ff != null) && (fi != null))
            {
                TimeSpan dias = dpFechaF.SelectedDate.Value - dpFechaI.SelectedDate.Value;
                diasReserva = dias.Days-1;
            }
            if (dtp != null)
            {
                if (dtp.Rows.Count == 0)
                    inhabilita("fecha");
            }
        }

        private void lstHotel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //selecccion de un hotel
            if (n_contrato > 0 && lstHotel.SelectedIndex != -1)
            {
                lstHabitacion.IsEnabled = true;
                hotel h = new hotel();
                SqlDataReader sr = h.buscar_habitacion(lstHotel.SelectedItem.ToString(), n_contrato);
                int i = 0;
                lstHabitacion.Items.Clear();
                if (dtp != null)
                {
                    if (dtp.Rows.Count == 0)
                        inhabilita("fecha");
                }

                tbContenedor.SelectedIndex = 0;
                while (sr.Read())
                    lstHabitacion.Items.Add(sr.GetString(i));

                //TODO INCLUIDO*********************************************************************************
                if (hoteles == 0)
                {
                    if (lstHotel.SelectedItem.ToString().Equals("ISLA CARIBE") || lstHotel.SelectedItem.ToString().Equals("COCHE PUNTA BLANCA"))
                        tbTodoIncluido.IsEnabled = true;
                    else
                        tbTodoIncluido.IsEnabled = false;
                }
                else
                {
                    tbTodoIncluido.IsEnabled = true;
                }
            }

        }

        private void lstHabitacion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //seleccion de una habitacion

            if (lstHabitacion.Items.Count > 0 && lstHabitacion.SelectedIndex > -1)
            {
                hotel h = new hotel();
                h.buscar_capacidad(lstHabitacion.SelectedItem.ToString(), lstHotel.SelectedItem.ToString());
                lblValorCapacidad.Content = h.capacidad.ToString();
                capacidad = h.capacidad;
                //HOTEL**************************************************************
                if (lstHotel.SelectedItem.ToString().Equals("ISLA CARIBE"))
                    capacidad++;
                lstPersona.IsEnabled = true;
            }
            if (lstHabitacion.SelectedIndex == -1)
            {
                lblValorCapacidad.Content = "";
                capacidad = 0;
                lstPersona.IsEnabled = false;
                return;

            }
            if (dtp != null)
            {
                if (dtp.Rows.Count == 0)
                    inhabilita("fecha");
            }
            if (cambiahab)
            {
                btnModificar.IsEnabled = true;
            }
        }

        private void lstPersona_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnAgregar.IsEnabled = true;
            if (lstPersona.SelectedIndex == -1)
                btnAgregar.IsEnabled = false;
        }
        private void totalTi()
        {
            if (dtTi != null)
            {
                totalTodoIncluido = 0;
                for (int n = 0; n <= dtTi.Rows.Count - 1; n++)
                {
                    if (!dtTi.Rows[n][8].ToString().Equals(""))
                        totalTodoIncluido = totalTodoIncluido + Convert.ToDouble(dtTi.Rows[n][8].ToString());
                }
                lblValorTotalTodoIncluido.Content = totalTodoIncluido.ToString("N2",CultureInfo.CreateSpecificCulture("es-VE"));

            }
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            //********************agregando personas a la reserva*******************************
            if (dpFechaI.SelectedDate == null || dpFechaF.SelectedDate == null)
            {
                MessageBox.Show("Debe colocar el rango de fecha", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                btnModificar.IsEnabled = false;
                return;
            }
            if (lstPersona.SelectedIndex != 0)
              agregado++;
            if (agregado >capacidad)
            {
                MessageBox.Show("Capacidad de la habitación completa", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                btnModificar.IsEnabled = true;
                //return;
            }
            hotel h = new hotel();
            DataTable dt = new DataTable();
            dt.Load(h.buscar_temporada(dpFechaI.SelectedDate.ToString(), dpFechaF.SelectedDate.ToString(), lstHotel.SelectedItem.ToString(), lstHabitacion.SelectedItem.ToString(), n_contrato, dpFechaI.SelectedDate.Value.Year));
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No hay temporadas configuradas para el rango de fechas seleccionado", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                btnModificar.IsEnabled = false;
                return;
            }
            if (tbTodoIncluido.IsEnabled == true && (lstHotel.SelectedItem.ToString().Equals("ISLA CARIBE") || lstHotel.SelectedItem.ToString().Equals("COCHE PUNTA BLANCA")))
            {

                if (h.buscar_tarifa(dpFechaI.SelectedDate.ToString(),lstHotel.SelectedItem.ToString()) == 0)
                {

                    MessageBox.Show("No hay tarifas configuradas para el rango de fechas seleccionado", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    btnModificar.IsEnabled = false;
                    return;

                }
            }
            devolver_puntos();
          
            if (lstPersona.SelectedIndex == 0)
                infate++;
            if (lstPersona.SelectedIndex == 1)
                ninio++;
            if (lstPersona.SelectedIndex == 2)
                adulto++;
            lstHabitacion.IsEnabled = false;
            btnAgregarHotel.IsEnabled = true;
            if (!status.Equals("CONFIRMADA") || !status.Equals("ANULADA"))                    
                    btnGuardaReserva.IsEnabled = true;
            if (hoteles > 1)
                btnQuitarHotel.IsEnabled = true;


            if (dtp == null)
            {
                dtp = new DataTable();
                dtp.Columns.Add("hotel");
                dtp.Columns.Add("habitacion");
                dtp.Columns.Add("infantes");
                dtp.Columns.Add("niños");
                dtp.Columns.Add("adultos");
                dtp.Columns.Add("Entrada");
                dtp.Columns.Add("Salida");
                //dtgPersona.ItemsSource = dtp.DefaultView;      
                DataRow row5 = dtp.NewRow();
                row5[0] = lstHotel.SelectedItem.ToString();
                row5[1] = lstHabitacion.SelectedItem.ToString();
                row5[2] = infate;
                row5[3] = ninio;
                row5[4] = adulto;
                row5[5] = dpFechaI.SelectedDate.Value.ToShortDateString();
                row5[6] = dpFechaF.SelectedDate.Value.ToShortDateString();
                dtp.Rows.Add(row5);
                dtgPersona.ItemsSource = dtp.DefaultView;
                puntosreserva = 0;
                habitacion++;
                lblValorCantidadHabitaciones.Content = habitacion;
                totalhabitacion++;
                lblValortotalhabitaciones.Content = totalhabitacion;
                hoteles++;
                lblValorHotelesreserva.Content = hoteles;
                totalnoches = totalnoches + diasReserva;
            }
            else
            {

                if (otro == true)
                {
                    btnQuitarHabitacion.IsEnabled = false;
                    habitacion = 0;
                    DataRow rowotra = dtp.NewRow();
                    rowotra[0] = lstHotel.SelectedItem.ToString();
                    rowotra[1] = lstHabitacion.SelectedItem.ToString();
                    rowotra[2] = infate;
                    rowotra[3] = ninio;
                    rowotra[4] = adulto;
                    rowotra[5] = dpFechaI.SelectedDate.Value.ToShortDateString();
                    rowotra[6] = dpFechaF.SelectedDate.Value.ToShortDateString();
                    dtp.Rows.Add(rowotra);
                    dtgPersona.ItemsSource = dtp.DefaultView;
                    habitacion++;
                    lblValorCantidadHabitaciones.Content = habitacion;
                    totalhabitacion++;
                    lblValortotalhabitaciones.Content = totalhabitacion;
                    hoteles++;
                    lblValorHotelesreserva.Content = hoteles;
                    totalnoches = totalnoches + diasReserva;
                }
                if (otra != true)
                {
                    dtp.Rows[dtp.Rows.Count - 1][2] = infate;
                    dtp.Rows[dtp.Rows.Count - 1][3] = ninio;
                    dtp.Rows[dtp.Rows.Count - 1][4] = adulto;
                    dtgPersona.ItemsSource = dtp.DefaultView;

                }
                else
                {
                    DataRow rowotra = dtp.NewRow();
                    rowotra[0] = "****";
                    rowotra[1] = lstHabitacion.SelectedItem.ToString();
                    rowotra[2] = infate;
                    rowotra[3] = ninio;
                    rowotra[4] = adulto;
                    rowotra[5] = dpFechaI.SelectedDate.Value.ToShortDateString();
                    rowotra[6] = dpFechaF.SelectedDate.Value.ToShortDateString();
                    dtp.Rows.Add(rowotra);
                    dtgPersona.ItemsSource = dtp.DefaultView;
                    habitacion++;
                    lblValorCantidadHabitaciones.Content = habitacion;
                    totalhabitacion++;
                    lblValortotalhabitaciones.Content = totalhabitacion;
                }
            }

            if (dtpun == null)
            {
                dtpun = new DataTable();
                dtpun.Columns.Add("hotel");
                dtpun.Columns.Add("habitación");
                dtpun.Columns.Add("día");
                dtpun.Columns.Add("temporada");
                dtpun.Columns.Add("puntos");
                dtpun.Columns.Add("total");

                // dtgPunto.ItemsSource = dtpun.DefaultView;
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    DataRow row7 = dtpun.NewRow();
                    if (i == 0)
                    {
                        row7[0] = lstHotel.SelectedItem.ToString();
                        row7[1] = lstHabitacion.SelectedItem.ToString();
                    }
                    else
                    {
                        row7[0] = "****";
                        row7[1] = "****";
                    }
                    String[] f = dt.Rows[i][4].ToString().Split(' ');
                    row7[2] = f[0];

                    row7[3] = dt.Rows[i][0];

                    if (row7[3].ToString().Equals("MEDIA"))
                        row7[4] = dt.Rows[i][3];
                    if (row7[3].ToString().Equals("ALTA"))
                        row7[4] = dt.Rows[i][2];
                    if (row7[3].ToString().Equals("SUPERALTA"))
                        row7[4] = dt.Rows[i][1];
                    if (Convert.ToInt32(dt.Rows[i][5].ToString()) == 1 || Convert.ToInt32(dt.Rows[i][5].ToString()) == 2)
                    {
                        if (Convert.ToDateTime(dt.Rows[i][4].ToString()).DayOfWeek == DayOfWeek.Friday || Convert.ToDateTime(dt.Rows[i][4].ToString()).DayOfWeek == DayOfWeek.Saturday)
                        {
                            if (row7[3].ToString().Equals("MEDIA"))
                                row7[4] = dt.Rows[i][8];
                            if (row7[3].ToString().Equals("ALTA"))
                                row7[4] = dt.Rows[i][7];
                            if (row7[3].ToString().Equals("SUPERALTA"))
                                row7[4] = dt.Rows[i][6];
                        }
                    }

                    int p = Convert.ToInt32(row7[4].ToString());
                    puntosreserva = puntosreserva + p;
                    dtpun.Rows.Add(row7);
                }
                int puntoshotel = 0;
                for (int m = 0; m <= dtpun.Rows.Count - 1; m++)
                {
                    int p = Convert.ToInt32(dtpun.Rows[m][4].ToString());
                    puntoshotel = puntoshotel + p;
                }
                dtpun.Rows[dtpun.Rows.Count - 1][5] = puntoshotel;

                dtgPunto.ItemsSource = dtpun.DefaultView;
                lblValorPuntosReserva.Content = puntosreserva;
                // quitar_puntos();
                btnAgregarHabitacion.IsEnabled = true;

            }
            else
            {
                if (otra == true)
                {
                    btnQuitarHabitacion.IsEnabled = true;



                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        DataRow row1 = dtpun.NewRow();
                        if (i == 0)
                        {
                            row1[0] = "****";
                            row1[1] = lstHabitacion.SelectedItem.ToString();
                        }
                        else
                        {
                            row1[0] = "****";
                            row1[1] = "****";
                        }
                        String[] f = dt.Rows[i][4].ToString().Split(' ');
                        row1[2] = f[0];

                        row1[3] = dt.Rows[i][0];

                        if (row1[3].ToString().Equals("MEDIA"))
                            row1[4] = dt.Rows[i][3];
                        if (row1[3].ToString().Equals("ALTA"))
                            row1[4] = dt.Rows[i][2];
                        if (row1[3].ToString().Equals("SUPERALTA"))
                            row1[4] = dt.Rows[i][1];
                        if (Convert.ToInt32(dt.Rows[i][5].ToString()) == 1 || Convert.ToInt32(dt.Rows[i][5].ToString()) == 2)
                        {
                            if (Convert.ToDateTime(dt.Rows[i][4].ToString()).DayOfWeek == DayOfWeek.Friday || Convert.ToDateTime(dt.Rows[i][4].ToString()).DayOfWeek == DayOfWeek.Saturday)
                            {
                                if (row1[3].ToString().Equals("MEDIA"))
                                    row1[4] = dt.Rows[i][8];
                                if (row1[3].ToString().Equals("ALTA"))
                                    row1[4] = dt.Rows[i][7];
                                if (row1[3].ToString().Equals("SUPERALTA"))
                                    row1[4] = dt.Rows[i][6];
                            }
                        }


                        int pun = Convert.ToInt32(row1[4].ToString());
                        puntosreserva = puntosreserva + pun;
                        dtpun.Rows.Add(row1);
                    }
                    int puntoshotel = 0;
                    for (int m = lp; m <= dtpun.Rows.Count - 1; m++)
                    {


                        dtpun.Rows[m][5] = "";
                        int p = Convert.ToInt32(dtpun.Rows[m][4].ToString());
                        puntoshotel = puntoshotel + p;


                    }
                    dtpun.Rows[dtpun.Rows.Count - 1][5] = puntoshotel;
                    dtgPunto.ItemsSource = dtpun.DefaultView;
                    lblValorPuntosReserva.Content = puntosreserva;
                    //quitar_puntos();
                    btnAgregarHabitacion.IsEnabled = true;
                    //otra = false;
                }
                if (otro == true)
                {
                    lp = dtpun.Rows.Count;
                    btnQuitarHabitacion.IsEnabled = false;
                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        DataRow row7 = dtpun.NewRow();
                        if (i == 0)
                        {
                            row7[0] = lstHotel.SelectedItem.ToString();
                            row7[1] = lstHabitacion.SelectedItem.ToString();
                        }
                        else
                        {
                            row7[0] = "****";
                            row7[1] = "****";
                        }
                        String[] f = dt.Rows[i][4].ToString().Split(' ');
                        row7[2] = f[0];
                        row7[3] = dt.Rows[i][0];

                        if (row7[3].ToString().Equals("MEDIA"))
                            row7[4] = dt.Rows[i][3];
                        if (row7[3].ToString().Equals("ALTA"))
                            row7[4] = dt.Rows[i][2];
                        if (row7[3].ToString().Equals("SUPERALTA"))
                            row7[4] = dt.Rows[i][1];
                        if (Convert.ToInt32(dt.Rows[i][5].ToString()) == 1 || Convert.ToInt32(dt.Rows[i][5].ToString()) == 2)
                        {
                            if (Convert.ToDateTime(dt.Rows[i][4].ToString()).DayOfWeek == DayOfWeek.Friday || Convert.ToDateTime(dt.Rows[i][4].ToString()).DayOfWeek == DayOfWeek.Saturday)
                            {
                                if (row7[3].ToString().Equals("MEDIA"))
                                    row7[4] = dt.Rows[i][8];
                                if (row7[3].ToString().Equals("ALTA"))
                                    row7[4] = dt.Rows[i][7];
                                if (row7[3].ToString().Equals("SUPERALTA"))
                                    row7[4] = dt.Rows[i][6];
                            }
                        }

                        int p = Convert.ToInt32(row7[4].ToString());
                        puntosreserva = puntosreserva + p;
                        dtpun.Rows.Add(row7);
                    }
                    int puntoshotel = 0;
                    for (int m = 0; m <= dtpun.Rows.Count - 1; m++)
                    {
                        if (dtpun.Rows[m][5].ToString().Equals(""))
                        {
                            int p = Convert.ToInt32(dtpun.Rows[m][4].ToString());
                            puntoshotel = puntoshotel + p;
                        }
                        else puntoshotel = 0;
                    }
                    dtpun.Rows[dtpun.Rows.Count - 1][5] = puntoshotel;

                    dtgPunto.ItemsSource = dtpun.DefaultView;
                    lblValorPuntosReserva.Content = puntosreserva;
                    //quitar_puntos();
                    btnAgregarHabitacion.IsEnabled = true;


                }
            }
            if (tbTodoIncluido.IsEnabled == true && (lstHotel.SelectedItem.ToString().Equals("ISLA CARIBE") || lstHotel.SelectedItem.ToString().Equals("COCHE PUNTA BLANCA")))
            {
                TimeSpan dias = dpFechaF.SelectedDate.Value - dpFechaI.SelectedDate.Value;
                int diasTI = dias.Days - 1;
                tbDescuento.IsEnabled = true;
                if (dtTi == null)
                {
                    dtTi = new DataTable();
                    dtTi.Columns.Add("hotel");
                    dtTi.Columns.Add("habitación");
                    dtTi.Columns.Add("fecha");
                    dtTi.Columns.Add("infate");
                    dtTi.Columns.Add("niño");
                    dtTi.Columns.Add("adulto");
                    dtTi.Columns.Add("sub total");
                    dtTi.Columns.Add("descuento");
                    dtTi.Columns.Add("total");
                   
                    for (int j = 0; j <= diasTI; j++)
                    {
                        DataRow row8 = dtTi.NewRow();
                        if (j == 0)
                        {
                            row8[0] = lstHotel.SelectedItem.ToString();
                            row8[1] = lstHabitacion.SelectedItem.ToString();

                        }
                        else
                        {
                            row8[0] = "****";
                            row8[1] = "****";
                        }
                        row8[2] = dpFechaI.SelectedDate.Value.AddDays(j).ToShortDateString();
                        h.buscar_tarifa(row8[2].ToString(),lstHotel.SelectedItem.ToString());
                        double inf = h.bsInfante * infate;
                        double ni = h.bsNinio * ninio;
                        double ad = h.bsAdulto * adulto;
                       
                        row8[3] = inf.ToString("N2",CultureInfo.CreateSpecificCulture("es-VE"));
                        row8[4] = ni.ToString("N2", CultureInfo.CreateSpecificCulture("es-VE"));
                        row8[5] = ad.ToString("N2", CultureInfo.CreateSpecificCulture("es-VE"));
                        row8[6] = "";
                        row8[7] = "";
                        row8[8] = "";

                        // totalTodoIncluido = totalTodoIncluido + Convert.ToDouble(row3[4].ToString());
                        dtTi.Rows.Add(row8);
                    }

                    double montohotelTI = 0;
                    for (int m = 0; m <= dtTi.Rows.Count - 1; m++)
                    {
                        if (dtTi.Rows[m][6].ToString().Equals(""))
                        {
                            double p = Convert.ToDouble(dtTi.Rows[m][3].ToString()) + Convert.ToDouble(dtTi.Rows[m][4].ToString()) + Convert.ToDouble(dtTi.Rows[m][5].ToString());
                            montohotelTI = montohotelTI + p;
                        }
                        else montohotelTI = 0;
                    }
                    dtTi.Rows[dtTi.Rows.Count - 1][6] = montohotelTI.ToString("N2", CultureInfo.CreateSpecificCulture("es-VE")); 
                    dtTi.Rows[dtTi.Rows.Count - 1][7] = descuento.ToString("N2",CultureInfo.CreateSpecificCulture("es-VE"));
                    dtTi.Rows[dtTi.Rows.Count - 1][8] = montohotelTI - descuento;
                    dtgTodoIncluido.ItemsSource = dtTi.DefaultView;
                    totalTi();
                    dtDes = new DataTable();
                    dtDes.Columns.Add("hotel");
                    dtDes.Columns.Add("habitación");
                    dtDes.Columns.Add("Persona");
                    dtDes.Columns.Add("Monto");
                    dtDes.Columns.Add("descuento");
                    dtDes.Columns.Add("descuentob");
                    dtDes.Columns.Add("total");



                }
                else
                {
                    if (otro == true)
                    {
                        lt = dtTi.Rows.Count;
                        btnQuitarHabitacion.IsEnabled = false;
                        for (int j = 0; j <= diasTI; j++)
                        {
                            DataRow row8 = dtTi.NewRow();
                            if (j == 0)
                            {
                                row8[0] = lstHotel.SelectedItem.ToString();
                                row8[1] = lstHabitacion.SelectedItem.ToString();

                            }
                            else
                            {
                                row8[0] = "****";
                                row8[1] = "****";
                            }
                            row8[2] = dpFechaI.SelectedDate.Value.AddDays(j).ToShortDateString();
                            h.buscar_tarifa(row8[2].ToString(), lstHotel.SelectedItem.ToString());
                            double inf = h.bsInfante * infate;
                            double ni = h.bsNinio * ninio;
                            double ad = h.bsAdulto * adulto;
                            
                            row8[3] = inf.ToString("N2", CultureInfo.CreateSpecificCulture("es-VE"));
                            row8[4] = ni.ToString("N2", CultureInfo.CreateSpecificCulture("es-VE"));
                            row8[5] = ad.ToString("N2", CultureInfo.CreateSpecificCulture("es-VE"));                            
                            row8[6] = "";
                            row8[7] = "";
                            row8[8] = "";
                            // totalTodoIncluido = totalTodoIncluido + Convert.ToDouble(row3[4].ToString());
                            dtTi.Rows.Add(row8);
                        }
                        double montohotelTI = 0;
                        for (int m = 0; m <= dtTi.Rows.Count - 1; m++)
                        {
                            if (dtTi.Rows[m][6].ToString().Equals(""))
                            {
                                double p = Convert.ToDouble(dtTi.Rows[m][3].ToString()) + Convert.ToDouble(dtTi.Rows[m][4].ToString()) + Convert.ToDouble(dtTi.Rows[m][5].ToString());
                                montohotelTI = montohotelTI + p;
                            }
                            else montohotelTI = 0;
                        }
                        dtTi.Rows[dtTi.Rows.Count - 1][6] = montohotelTI.ToString("N2",CultureInfo.CreateSpecificCulture("es-VE"));
                        dtTi.Rows[dtTi.Rows.Count - 1][7] = descuento.ToString("N2", CultureInfo.CreateSpecificCulture("es-VE")); ;
                        double tt = montohotelTI - descuento;
                        dtTi.Rows[dtTi.Rows.Count - 1][8] = tt.ToString("N2", CultureInfo.CreateSpecificCulture("es-VE"));
                        dtgTodoIncluido.ItemsSource = dtTi.DefaultView;
                        totalTi();

                    }
                    if (otra == false)
                    {
                        btnQuitarHabitacion.IsEnabled = false;
                        for (int m = dtTi.Rows.Count - diasTI - 1; m <= dtTi.Rows.Count - 1; m++)
                        {
                            h.buscar_tarifa(dtTi.Rows[m][2].ToString(), lstHotel.SelectedItem.ToString());
                            double inf = h.bsInfante * infate;
                            double ni = h.bsNinio * ninio;
                            double ad = h.bsAdulto * adulto;
                            dtTi.Rows[m][3] = inf.ToString("N2", CultureInfo.CreateSpecificCulture("es-VE")); 
                            dtTi.Rows[m][4] = ni.ToString("N2", CultureInfo.CreateSpecificCulture("es-VE")); 
                            dtTi.Rows[m][5] = ad.ToString("N2", CultureInfo.CreateSpecificCulture("es-VE")); 
                            dtTi.Rows[m][6] = "";
                            dtTi.Rows[m][7] = "";
                            dtTi.Rows[m][8] = "";
                            // totalTodoIncluido = totalTodoIncluido + Convert.ToDouble(dtTi.Rows[m][4].ToString());
                        }
                        double montohotelTI = 0;
                        for (int m = 0; m <= dtTi.Rows.Count - 1; m++)
                        {
                            if (dtTi.Rows[m][6].ToString().Equals(""))
                            {
                                double p = Convert.ToDouble(dtTi.Rows[m][3].ToString()) + Convert.ToDouble(dtTi.Rows[m][4].ToString()) + Convert.ToDouble(dtTi.Rows[m][5].ToString());
                                montohotelTI = montohotelTI + p;
                            }
                            else montohotelTI = 0;
                        }
                        dtTi.Rows[dtTi.Rows.Count - 1][6] = montohotelTI.ToString("N2", CultureInfo.CreateSpecificCulture("es-VE")); 
                        dtTi.Rows[dtTi.Rows.Count - 1][7] = descuento.ToString("N2", CultureInfo.CreateSpecificCulture("es-VE"));
                        double tt = montohotelTI - descuento;
                        dtTi.Rows[dtTi.Rows.Count - 1][8] = tt.ToString("N2", CultureInfo.CreateSpecificCulture("es-VE"));
                        //lblValorTotalTodoIncluido.Content = totalTodoIncluido.ToString("N0");
                        dtgTodoIncluido.ItemsSource = dtTi.DefaultView;
                        totalTi();

                    }
                    else
                    {
                        btnQuitarHabitacion.IsEnabled = true;
                        for (int j = 0; j <= diasTI; j++)
                        {
                            DataRow row4 = dtTi.NewRow();
                            if (j == 0)
                            {
                                row4[0] = "****";
                                row4[1] = lstHabitacion.SelectedItem.ToString();
                            }
                            else
                            {
                                row4[0] = "****";
                                row4[1] = "****";
                            }
                            double inf = h.bsInfante * infate;
                            double ni = h.bsNinio * ninio;
                            double ad = h.bsAdulto * adulto;
                            row4[2] = dpFechaI.SelectedDate.Value.AddDays(j).ToShortDateString();
                            row4[3] = inf.ToString("N2", CultureInfo.CreateSpecificCulture("es-VE"));
                            row4[4] = ni.ToString("N2", CultureInfo.CreateSpecificCulture("es-VE"));
                            row4[5] = ad.ToString("N2", CultureInfo.CreateSpecificCulture("es-VE"));                  
                            row4[6] = "";
                            row4[7] = "";
                            row4[8] = "";

                            // totalTodoIncluido = totalTodoIncluido + Convert.ToDouble(row4[4].ToString());
                            dtTi.Rows.Add(row4);
                        }
                        //lblValorTotalTodoIncluido.Content = totalTodoIncluido.ToString("N0");
                        double montohotelTI = 0;
                        for (int m = lt; m <= dtTi.Rows.Count - 1; m++)
                        {
                            dtTi.Rows[m][6] = "";
                            dtTi.Rows[m][7] = "";
                            dtTi.Rows[m][8] = "";

                            double p = Convert.ToDouble(dtTi.Rows[m][3].ToString()) + Convert.ToDouble(dtTi.Rows[m][4].ToString()) + Convert.ToDouble(dtTi.Rows[m][5].ToString());
                            montohotelTI = montohotelTI + p;


                        }
                        dtTi.Rows[dtTi.Rows.Count - 1][6] = montohotelTI.ToString("N2", CultureInfo.CreateSpecificCulture("es-VE"));
                        dtTi.Rows[dtTi.Rows.Count - 1][7] = descuento.ToString("N2", CultureInfo.CreateSpecificCulture("es-VE"));
                        double tt = montohotelTI - descuento;
                        dtTi.Rows[dtTi.Rows.Count - 1][8] = tt.ToString("N2", CultureInfo.CreateSpecificCulture("es-VE"));
                        dtgTodoIncluido.ItemsSource = dtTi.DefaultView;
                        totalTi();


                    }


                }
                DataRow rowdes = dtDes.NewRow();
                rowdes[0] = lstHotel.SelectedItem.ToString();
                rowdes[1] = lstHabitacion.SelectedItem.ToString();
                rowdes[2] = lstPersona.SelectedItem.ToString();
                double infD = 0, niD = 0, adlD = 0;
                for (int i = 0; i <= diasTI; i++)
                {
                    h.buscar_tarifa(dpFechaI.SelectedDate.Value.AddDays(i).ToShortDateString(), lstHotel.SelectedItem.ToString());
                    if (lstPersona.SelectedItem.ToString().Equals("INFANTE(0 A 6 AÑOS)"))
                        infD = infD + h.bsInfante;
                    if (lstPersona.SelectedItem.ToString().Equals("NIÑO(7 A 12 AÑOS)"))
                        niD = niD + h.bsNinio;
                    if (lstPersona.SelectedItem.ToString().Equals("ADULTO"))
                        adlD = adlD + h.bsAdulto;

                }
                if (lstPersona.SelectedItem.ToString().Equals("INFANTE(0 A 6 AÑOS)"))
                    rowdes[3] = infD;
                if (lstPersona.SelectedItem.ToString().Equals("NIÑO(7 A 12 AÑOS)"))
                    rowdes[3] = niD;
                if (lstPersona.SelectedItem.ToString().Equals("ADULTO"))
                    rowdes[3] = adlD;
                rowdes[4] = 0;
                rowdes[5] = 0;
                rowdes[6] = rowdes[3];
                dtDes.Rows.Add(rowdes);
                if (dtDes != null)
                {
                    tmp = new List<persona>();
                    for (int i = 0; i <= dtDes.Rows.Count - 1; i++)
                    {
                        tmp.Add(new persona()
                        {
                            hotel = dtDes.Rows[i][0].ToString(),
                            habitacion = dtDes.Rows[i][1].ToString(),
                            personas = dtDes.Rows[i][2].ToString(),
                            monto = Convert.ToDouble(dtDes.Rows[i][3].ToString()).ToString("N2",CultureInfo.CreateSpecificCulture("es-VE")),
                            descuento = Convert.ToDouble(dtDes.Rows[i][4].ToString()).ToString("N2", CultureInfo.CreateSpecificCulture("es-VE")),
                            descuentob = Convert.ToDouble(dtDes.Rows[i][5].ToString()).ToString("N2", CultureInfo.CreateSpecificCulture("es-VE")),
                            total = Convert.ToDouble(dtDes.Rows[i][6].ToString()).ToString("N2", CultureInfo.CreateSpecificCulture("es-VE"))
                        });
                    }

                    dtgPersonaDes.ItemsSource = tmp;
                }
            }
            otra = false;
            if (otro == true)
                otro = false;
            lstPersona.SelectedIndex = -1;
            if (quitar_puntos() == 0)
            {
                MessageBox.Show("Este contrato no puede hacer reservas, no cuenta con puntos suficientes disponibles", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                btnGuarda.IsEnabled = false;

            }
            else { btnGuarda.IsEnabled = true; }

        }
        private int devolver_puntos()
        {
            for (int i = 0; i <= puntosAnios.Rows.Count - 1; i++)
            {
                int anio = Convert.ToInt32(puntosAnios.Rows[i][2].ToString());
                string[] pr = puntosAnios.Rows[i][1].ToString().Split(',');

                int puntos = Convert.ToInt32(pr[0]);
                for (int j = 0; j <= dtpunAnio.Rows.Count - 1; j++)
                {
                    string[] pd = dtpunAnio.Rows[j][2].ToString().Split(',');
                    string[] pc = dtpunAnio.Rows[j][3].ToString().Split(',');
                    if (anio == Convert.ToInt32(dtpunAnio.Rows[j][1].ToString()))
                    {
                        dtpunAnio.Rows[j][2] = Convert.ToInt32(pd[0]) + puntos;
                        dtpunAnio.Rows[j][3] = Convert.ToInt32(pc[0]) - puntos;
                    }
                }
            }
            puntosAnios.Rows.Clear();
            //int consumido = 0;
            /*
            int puntosconsumidos = 0;
            int total = puntosreserva;
            String[] pc = dtpunAnio.Rows[0][4].ToString().Split(',');
            int puntosporanio = Convert.ToInt32(pc[0]);

            if (puntosacelerados > 0)
            {
                an_puntosA = "";
                total = puntosacelerados;
                if (total > 0)
                {

                    int m = dtpunAnio.Rows.Count - 1;
                    puntosconsumidos = 0;
                    while (total > 0)
                    {
                        if (m >= 0)
                        {
                            String[] p = dtpunAnio.Rows[m][3].ToString().Split(',');
                            puntosconsumidos = Convert.ToInt32(p[0]);
                            if (puntosconsumidos > total)
                            {
                                int puntos = puntosconsumidos - total;
                                dtpunAnio.Rows[m][3] = puntos;
                                String[] pr = dtpunAnio.Rows[m][2].ToString().Split(',');
                                dtpunAnio.Rows[m][2] = total + Convert.ToInt32(pr[0]);
                                total = 0;
                                break;
                            }
                            else
                            {
                                total = total - Convert.ToInt32(p[0]);
                                dtpunAnio.Rows[m][3] = 0;
                                //String[] pr = dtpunAnio.Rows[m][3].ToString().Split(',');
                                dtpunAnio.Rows[m][2] = puntosporanio;
                            }
                            m--;
                        }
                        else break;
                    }
                }
                else
                {
                    //lblValorPuntosacelerados.Content = 0;
                    //lblValorTotalacelerado.Content = 0;
                }
            }

            total = puntosreserva - puntosacelerados;
            an_puntos = "";
            int pos = 0;
            for (int i = 0; i <= dtpunAnio.Rows.Count - 1; i++)
            {
                if (Convert.ToInt32(dtpunAnio.Rows[i][1].ToString()) == anioAc)
                {
                    pos = i;
                    break;
                }

            }
            for (int i = pos; i >= 0; i--)
            {
                String[] p = dtpunAnio.Rows[i][3].ToString().Split(',');
                String[] pc1 = dtpunAnio.Rows[i][2].ToString().Split(',');
                if (Convert.ToInt32(p[0]) > 0)
                {
                    puntosconsumidos = Convert.ToInt32(p[0]);
                    if (puntosconsumidos > total)
                    {
                        int puntos = puntosconsumidos - total;
                        dtpunAnio.Rows[i][3] = puntos;
                        dtpunAnio.Rows[i][2] = Convert.ToInt32(pc1[0]) + total;
                        total = 0;
                        break;
                    }
                    else
                    {
                        total = total - puntosconsumidos;
                        dtpunAnio.Rows[i][2] = puntosporanio;
                        //String[] pr = dtpunAnio.Rows[i][3].ToString().Split(',');

                        //cambio habia =0
                        dtpunAnio.Rows[i][3] = 0;
                    }
                }

            }*/
            return 1;

        }
        private int quitar_puntos()
        {
            //int consumido = 0;
            int puntosdisponibles = 0;
            int total = puntosreserva;
            for (int i = 0; i <= dtpunAnio.Rows.Count - 1; i++)
            {
                String[] p = dtpunAnio.Rows[i][2].ToString().Split(',');
                puntosdisponibles = puntosdisponibles + Convert.ToInt32(p[0]);

            }
            if (puntosdisponibles < puntosreserva)
            {
                return 0;
            }
            puntosdisponibles = 0;
            for (int i = 0; i <= dtpunAnio.Rows.Count - 1; i++)
            {
                if (Convert.ToInt32(dtpunAnio.Rows[i][1].ToString()) <= anioAc)
                {
                    String[] p = dtpunAnio.Rows[i][2].ToString().Split(',');
                    String[] pnc = dtpunAnio.Rows[i][3].ToString().Split(',');
                    if (Convert.ToInt32(p[0]) > 0)
                    {
                        if (dtpunAnio.Rows[i][1].ToString().Equals("2017"))
                        {
                            if (calendario.Equals("B") && dpFechaI.SelectedDate.Value.Month <= 5)
                                break;
                        }
                       // an_puntos = dtpunAnio.Rows[i][1].ToString() + " " + an_puntos;
                        puntosdisponibles = Convert.ToInt32(p[0]);
                        if (puntosdisponibles >= total)
                        {
                            int puntos = puntosdisponibles - total;
                            DataRow r = puntosAnios.NewRow();
                            r[0] = 0;
                            r[1] = total;
                            r[2] = dtpunAnio.Rows[i][1].ToString();                           
                            dtpunAnio.Rows[i][2] = puntos;
                            r[3] = dtpunAnio.Rows[i][2].ToString();
                            r[4] = 0;
                            puntosAnios.Rows.Add(r);
                            dtpunAnio.Rows[i][3] = Convert.ToInt32(pnc[0]) + total;
                            //an_puntos =an_puntos+" "+ total + " Ptos. año " + dtpunAnio.Rows[i][1].ToString() + " Disponibles Año " + dtpunAnio.Rows[i][1].ToString() + " " + puntos + " Ptos.";
                            total = 0;
                            break;
                        }
                        else
                        {
                            DataRow r = puntosAnios.NewRow();                           
                            r[0] = 0;
                            r[1] = dtpunAnio.Rows[i][2];
                            r[2] = dtpunAnio.Rows[i][1].ToString();                          
                            total = total - Convert.ToInt32(p[0]); 
                            dtpunAnio.Rows[i][2] = 0;                          
                            r[3] = dtpunAnio.Rows[i][2].ToString(); 
                            r[4] = 0;
                            puntosAnios.Rows.Add(r);
                            String[] pr = dtpunAnio.Rows[i][3].ToString().Split(',');
                            dtpunAnio.Rows[i][3] = Convert.ToInt32(pr[0]) + Convert.ToInt32(p[0]);
                           // an_puntos = p[0].ToString() + " Ptos. año " + dtpunAnio.Rows[i][1].ToString() + " Disponibles Año " + dtpunAnio.Rows[i][1].ToString() + " " + 0 + " Ptos."+" "+an_puntos;
                        }
                    }
                }
                else break;
            }


            if (total > 0)
            {
                puntosacelerados = total;
                lblValorPuntosacelerados.Content = puntosacelerados;
                montoPA mpa = new montoPA();
                DataTable dtContrato = new DataTable();
                cliente cli = new cliente();
                dtContrato.Load(cli.buscar_contratos("", "", n_contrato.ToString()));
                DateTime fechaVenta = new DateTime();
                fechaVenta = Convert.ToDateTime(dtContrato.Rows[0][9].ToString());
                mpa.buscar(fechaVenta.Date.ToShortDateString());
                totalacelerado = puntosacelerados * mpa.monto;
                lblValorTotalacelerado.Content = totalacelerado.ToString("N2",CultureInfo.CreateSpecificCulture("es-VE"));
                int m = dtpunAnio.Rows.Count - 1;
                puntosdisponibles = 0;
                while (total > 0)
                {
                    String[] p = dtpunAnio.Rows[m][2].ToString().Split(',');
                    String[] pnc = dtpunAnio.Rows[m][3].ToString().Split(',');
                    puntosdisponibles = Convert.ToInt32(p[0]);
                    if (puntosdisponibles > 0)
                    {
                        // an_puntosA =  dtpunAnio.Rows[m][1].ToString() + " " +an_puntosA;
                        if (puntosdisponibles >= total)
                        {
                            int puntos = puntosdisponibles - total;
                            dtpunAnio.Rows[m][2] = puntos;
                            dtpunAnio.Rows[m][3] = Convert.ToInt32(pnc[0]) + total;
                            // an_puntosA =an_puntosA+" "+dtpunAnio.Rows[m][3].ToString() + " Ptos. año " + dtpunAnio.Rows[m][1].ToString() + " Disponibles Año " + dtpunAnio.Rows[m][1].ToString() + " " + puntos + " Ptos.";
                            DataRow r = puntosAnios.NewRow();
                            r[0] = 0;
                            r[1] = total;
                            r[2] = dtpunAnio.Rows[m][1].ToString();
                            r[3] = dtpunAnio.Rows[m][2].ToString();
                            r[4] = 1;
                            puntosAnios.Rows.Add(r);
                            total = 0;
                            break;
                        }
                        else
                        {
                            total = total - Convert.ToInt32(p[0]);
                            DataRow r = puntosAnios.NewRow();
                            r[0] = 0;
                            r[1] = dtpunAnio.Rows[m][2];
                            r[2] = dtpunAnio.Rows[m][1].ToString();
                            dtpunAnio.Rows[m][2] = 0;
                            r[3] = dtpunAnio.Rows[m][2].ToString();
                            r[4] = 1;
                            puntosAnios.Rows.Add(r);
                            String[] pr = dtpunAnio.Rows[m][3].ToString().Split(',');
                            dtpunAnio.Rows[m][3] = Convert.ToInt32(pr[0]) + Convert.ToInt32(p[0]);
                            // an_puntosA = dtpunAnio.Rows[m][3].ToString() + " Ptos. año " + dtpunAnio.Rows[m][1].ToString() + " Disponibles Año " + dtpunAnio.Rows[m][1].ToString() + " " + 0 + " Ptos." + " " + an_puntosA;
                        }
                    }
                    m--;
                }
            }
            else
            {
                lblValorPuntosacelerados.Content = 0;
                lblValorTotalacelerado.Content = 0;
            }

            return 1;

        }

        private void btnQuitarHabitacion_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("¿Desea agregar quitar habitación de la reserva?", "Pregunta", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (cambiahab)
                {
                    if (!dtp.Rows[cambiarow][0].ToString().Equals("****"))
                    {
                        MessageBox.Show("No puede quitar esta habitación", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    dtp.Rows.RemoveAt(cambiarow);
                    cambiahab = false;
                    btnModificar_Click(sender, e);
                    return;
                }
                otra = false;
                lstHotel.IsEnabled = true;
                lstHabitacion.SelectedItem = ultimahabitacion;
                dpFechaF.IsEnabled = false;
                dpFechaI.IsEnabled = false;
                
                if (totalhabitacion > 0)
                {
                    totalhabitacion = totalhabitacion - habitacion;
                    lblValortotalhabitaciones.Content = totalhabitacion;
                }
                habitacion--;
                lblValorCantidadHabitaciones.Content = habitacion;

                quitar();
                infate = Convert.ToInt32(dtp.Rows[dtp.Rows.Count - 1][2].ToString());
                ninio = Convert.ToInt32(dtp.Rows[dtp.Rows.Count - 1][3].ToString());
                adulto = Convert.ToInt32(dtp.Rows[dtp.Rows.Count - 1][4].ToString());
                agregado = infate + ninio + adulto;
                if (tbTodoIncluido.IsEnabled == true && (hotelHabqui.Equals("ISLA CARIBE") || hotelHabqui.Equals("COCHE PUNTA BLANCA")))
                {
                    double montohotelTI = 0;
                    for (int m = lt; m <= dtTi.Rows.Count - 1; m++)
                    {
                        dtTi.Rows[m][6] = "";

                        double p = Convert.ToDouble(dtTi.Rows[m][3].ToString()) + Convert.ToDouble(dtTi.Rows[m][4].ToString()) + Convert.ToDouble(dtTi.Rows[m][5].ToString());
                        montohotelTI = montohotelTI + p;

                    }
                    dtTi.Rows[dtTi.Rows.Count - 1][6] = montohotelTI;
                    dtTi.Rows[dtTi.Rows.Count - 1][7] = descuento;
                    dtTi.Rows[dtTi.Rows.Count - 1][8] = montohotelTI-descuento;
                    totalTi();
                    dtgTodoIncluido.ItemsSource = dtTi.DefaultView;
                }
                int puntoshotel = 0;
                for (int m = lp; m <= dtpun.Rows.Count - 1; m++)
                {

                    dtpun.Rows[m][5] = "";
                    int p = Convert.ToInt32(dtpun.Rows[m][4].ToString());
                    puntoshotel = puntoshotel + p;
                }
                dtpun.Rows[dtpun.Rows.Count - 1][5] = puntoshotel;
                dtgPunto.ItemsSource = dtpun.DefaultView;
                //lstHabitacion.SelectedIndex = -1;

            }
        }

        private void btnAgregarHabitacion_Click(object sender, RoutedEventArgs e)
        {
            if (infate == 0 && ninio == 0 && adulto == 0)
            {
                MessageBox.Show("Debe agregar personas a la habitación antes de agregar una nueva", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (MessageBox.Show("¿Desea agregar otra habitación a la reserva?", "Pregunta", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (cambiahab)
                {
                    int rs=0;
                    for (int n=cambiarow;n<=dtp.Rows.Count-1;n++)
                    {
                        if (n > cambiarow)
                        {
                            if (!dtp.Rows[n][0].ToString().Equals("****"))
                                break;
                            else
                                rs++;
                        }
                    }
                    DataRow r = dtp.NewRow();
                    r[0] = "****";
                    r[1] = lstHabitacion.SelectedItem.ToString();
                    r[2] = 0;
                    r[3] = 0;
                    r[4] = 1;
                    r[5] = dpFechaI.SelectedDate.Value.ToShortDateString();
                    r[6] = dpFechaF.SelectedDate.Value.ToShortDateString();
                    dtp.Rows.InsertAt(r,cambiarow+rs+1);
                    dtgPersona.ItemsSource = dtp.DefaultView;
                    btnAgregar.IsEnabled = false;
                    cambiahab = false;
                    btnModificar_Click(sender, e);
                    return;
                }
                otra = true;
                lstHotel.IsEnabled = false;
                infate = 0;
                ninio = 0;
                adulto = 0;
                agregado = 0;
                if (lstHabitacion.SelectedIndex!=-1)
                ultimahabitacion = lstHabitacion.SelectedItem.ToString();
                lstHabitacion.IsEnabled = true;
                lstHabitacion.SelectedIndex = -1;
                dpFechaF.IsEnabled = false;
                dpFechaI.IsEnabled = false;
                /* habitacion++;
                 if (totalhabitacion > 0)
                 {
                     totalhabitacion = totalhabitacion + habitacion;
                     lblValortotalhabitaciones.Content = totalhabitacion;
                 }
                 else
                 {
                     lblValortotalhabitaciones.Content = habitacion;
                 }
                 lblValorCantidadHabitaciones.Content = habitacion;*/

                if (tbTodoIncluido.IsEnabled == true && lstHotel.SelectedItem.ToString().Equals("ISLA CARIBE") || lstHotel.SelectedItem.ToString().Equals("COCHE PUNTA BLANCA"))
                {
                    DataView view = (DataView)dtgTodoIncluido.ItemsSource;
                    dtTi = view.Table.Clone();
                    foreach (DataRowView drv in view)
                        dtTi.ImportRow(drv.Row);
                }

                // totalTodoIncluido = Convert.ToDouble(lblValorTotalTodoIncluido.Content);
            }

        }

        private void quitar()
        {
            
            for (int n = dtp.Rows.Count - 1; n >= 0; n--)
            {
                if (!dtp.Rows[n][0].ToString().Equals("****"))
                {
                    hotelHabqui = dtp.Rows[n][0].ToString();
                    break;
                }
            }

                dtp.Rows.RemoveAt(dtp.Rows.Count - 1);

            int hasta = 0;
            if (totalhabitacion > 0)
            {

                hasta = (dtpun.Rows.Count - 1) - (diasReserva + 1);

            }
            else
            {

                if (habitacion > 1)
                    hasta = diasReserva * habitacion + 1;
                else
                    hasta = diasReserva * habitacion;
            }
            devolver_puntos();
            for (int i = dtpun.Rows.Count - 1; i > hasta; i--)
            {
                int p = Convert.ToInt32(dtpun.Rows[i][4].ToString());
                puntosreserva = puntosreserva - p;
                dtpun.Rows.RemoveAt(i);
            }
            lp = dtp.Rows.Count-1;
            lblValorPuntosReserva.Content = puntosreserva;
            quitar_puntos();
            if (habitacion == 1)
            {
                dpFechaF.IsEnabled = true;
                dpFechaI.IsEnabled = true;
                btnQuitarHabitacion.IsEnabled = false;
            }
            if (tbTodoIncluido.IsEnabled && (hotelHabqui.Equals("ISLA CARIBE") || hotelHabqui.Equals("COCHE PUNTA BLANCA")))
            {
                for (int i = dtTi.Rows.Count - 1; i > hasta; i--)
                {
                    dtTi.Rows.RemoveAt(i);
                }
                lt = dtTi.Rows.Count;
                totalTi();
                for (int i = tmp.Count - 1; i >= hasta; i--)
                {
                    tmp.RemoveAt(i);
                }               
                dtgPersonaDes.ItemsSource = tmp;
                dtgPersonaDes.Items.Refresh();
            }

        }

        private void quitarhotel()
        {
            String hotelq = "";
            int hasta = 0;
            for (int i = dtp.Rows.Count - 1; i > 0; i--)
            {
                if (dtp.Rows[i][0].ToString().Equals("****"))
                {
                    hasta++;
                    habitacion++;
                }
                else
                {
                    hasta++;
                    habitacion++;
                    hotelq = dtp.Rows[i][0].ToString();
                    break;
                }
            }
            int h = (dtp.Rows.Count - 1) - hasta;
            for (int j = dtp.Rows.Count - 1; j > h; j--)
                dtp.Rows.RemoveAt(j);
            dtgPersona.ItemsSource = dtp.DefaultView;
            hasta = 0;

            for (int i = dtpun.Rows.Count - 1; i > 0; i--)
            {

                if (dtpun.Rows[i][0].ToString().Equals("****"))
                {
                    hasta++;
                }
                else
                {
                    hasta++;
                    break;
                }
            }
            h = (dtpun.Rows.Count - 1) - hasta;
            devolver_puntos();
            for (int j = dtpun.Rows.Count - 1; j > h; j--)
            {
                int p = Convert.ToInt32(dtpun.Rows[j][4].ToString());
                puntosreserva = puntosreserva - p;
                dtpun.Rows.RemoveAt(j);
            }
            dtgPunto.ItemsSource = dtpun.DefaultView;
            lblValorPuntosReserva.Content = puntosreserva;
            quitar_puntos();
            if (tbTodoIncluido.IsEnabled == true && (hotelq.Equals("ISLA CARIBE") || hotelq.Equals("COCHE PUNTA BLANCA")))
            {
                hasta = 0;
                if (dtTi == null)
                {
                    DataView view = (DataView)dtgTodoIncluido.ItemsSource;
                    dtTi = view.Table.Clone();
                    foreach (DataRowView drv in view)
                        dtTi.ImportRow(drv.Row);
                }
                for (int i = dtTi.Rows.Count - 1; i > 0; i--)
                {

                    if (dtTi.Rows[i][0].ToString().Equals("****"))
                    {
                        hasta++;
                    }
                    else
                    {
                        hasta++;
                        break;
                    }
                }
                h = (dtTi.Rows.Count - 1) - hasta;
                if (h == 0)
                {
                    dtgTodoIncluido.ItemsSource = null;
                    lblValorTotalTodoIncluido.Content = "";
                    dtDes = null;
                }
                else
                {
                    for (int j = dtTi.Rows.Count - 1; j > h; j--)
                    {
                        dtTi.Rows.RemoveAt(j);

                    }
                    dtgTodoIncluido.ItemsSource = dtTi.DefaultView;
                    totalTi();
                    for (int i = tmp.Count - 1; i >= h; i--)
                    {
                        tmp.RemoveAt(i);
                    }
                    
                    dtgPersonaDes.ItemsSource = tmp;
                    dtgPersonaDes.Items.Refresh();
                   
                  
                }
            }

        }

        private void btnQuitarHotel_Click(object sender, RoutedEventArgs e)
        {
            hoteles--;
            if (hoteles > 0)
            {
                if (MessageBox.Show("¿Desea agregar quitar el hotel de la reserva?", "Pregunta", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    totalhabitacion = totalhabitacion - habitacion;
                    lblValortotalhabitaciones.Content = totalhabitacion;
                    lblValorHotelesreserva.Content = hoteles;
                    habitacion = 0;
                    quitarhotel();
                    lblValorCantidadHabitaciones.Content = habitacion;
                    infate = Convert.ToInt32(dtp.Rows[dtp.Rows.Count - 1][2].ToString());
                    ninio = Convert.ToInt32(dtp.Rows[dtp.Rows.Count - 1][3].ToString());
                    adulto = Convert.ToInt32(dtp.Rows[dtp.Rows.Count - 1][4].ToString());
                    agregado = infate + ninio + adulto;
                    if (hoteles == 1)
                        btnQuitarHotel.IsEnabled = false;
                    dpFechaF.IsEnabled = true;
                    dpFechaI.IsEnabled = true;
                    dpFechaI.SelectedDate = ultimaini;
                    dpFechaF.SelectedDate = ultimafinal;
                    dpFechaI.DisplayDateStart = ultimaini;
                    lstHotel.SelectedItem = ultimohotel;
                }
            }
            else
            {
                btnQuitarHotel.IsEnabled = false;
            }
        }

        private void btnAgregarHotel_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("¿Desea agregar otro hotel a la reserva?", "Pregunta", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                otro = true;
                //hoteles++;
                // lblValorHotelesreserva.Content = hoteles;
                dpFechaF.IsEnabled = true;
                dpFechaI.IsEnabled = true;
                dpFechaI.DisplayDateStart = dpFechaF.SelectedDate;
                ultimaini = dpFechaI.SelectedDate.Value.Date;
                ultimafinal = dpFechaF.SelectedDate.Value.Date;
                ultimohotel = lstHotel.SelectedItem.ToString();
                dpFechaI.SelectedDate = null;
                dpFechaF.SelectedDate = null;
                lstHotel.IsEnabled = true;
                infate = 0;
                ninio = 0;
                adulto = 0;
                agregado = 0;
                lstHabitacion.IsEnabled = true;
                lstHabitacion.SelectedIndex = -1;

                habitacion = 0;
                lblValorCantidadHabitaciones.Content = habitacion;
                if (tbTodoIncluido.IsEnabled == true && (lstHotel.SelectedItem.ToString().Equals("ISLA CARIBE") || lstHotel.SelectedItem.ToString().Equals("COCHE PUNTA BLANCA")))
                {
                    DataView view = (DataView)dtgTodoIncluido.ItemsSource;
                    dtTi = view.Table.Clone();
                    foreach (DataRowView drv in view)
                        dtTi.ImportRow(drv.Row);
                }
                lstHotel.SelectedIndex = -1;

                // totalTodoIncluido = Convert.ToDouble(lblValorTotalTodoIncluido.Content);
            }
        }

        private void btnGuardaReserva_Click(object sender, RoutedEventArgs e)
        {
            if (btnModificar.IsEnabled == true)
            {
                MessageBox.Show("Hay cambios sin aplicar", "ADVERTENCIA", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }


            if (MessageBox.Show("¿Desea actualizar los datos de la reserva?", "Pregunta", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    reservacion reserva = new reservacion();
                    reserva.id = numeroReserva;
                    reserva.cliente = cliente;
                    String[] ini = dtpun.Rows[0][2].ToString().Split('/');
                    String fechI = ini[2] + "/" + ini[1] + "/" + ini[0];
                    reserva.fechaI = fechI;
                    String[] fin = Convert.ToDateTime(dtpun.Rows[dtpun.Rows.Count-1][2].ToString()).AddDays(1).ToShortDateString().Split('/');
                    String fechF = fin[2] + "/" + fin[1] + "/" + fin[0];
                    reserva.fechaF = fechF;
                    reserva.puntos = Convert.ToInt32(lblValorPuntosReserva.Content);
                    reserva.diasreserva = totalnoches + 1;
                    if (lblValorTotalTodoIncluido.Content.Equals(""))
                        reserva.todoincluido = 0;
                    else
                        reserva.todoincluido = Convert.ToDouble(lblValorTotalTodoIncluido.Content);
                    //String[] lim = DateTime.Today.AddDays(3).ToShortDateString().Split('/');
                   // String fechL = lim[2] + "/" + lim[1] + "/" + lim[0];
                   // reserva.fechaL = fechL;
                    reserva.n_contrato = n_contrato;
                    reserva.observacion = txtobservacion.Text;
                    reserva.puntosacelerado = Convert.ToInt32(lblValorPuntosacelerados.Content);
                    reserva.montoAcelerado = Convert.ToDouble(lblValorTotalacelerado.Content);
                    reserva.observacion = txtobservacion.Text;

                    reserva.total = reserva.montoAcelerado + reserva.todoincluido;
                    if (reserva.total>0)
                    {
                        if (total == 1)
                            reserva.total = reserva.total + 1;
                    }
                    reserva.anios_puntos = an_puntos;
                    if (an_puntosA == null)
                        an_puntosA = " ";
                    reserva.anios_puntosA = an_puntosA;
                    for (int x = 0; x <= puntosAnios.Rows.Count - 1; x++)
                    {
                        string[] p = puntosAnios.Rows[x][1].ToString().Split(',');
                        if (puntosAnios.Rows[x][4].ToString().Equals("0"))
                            reserva.anios_puntos = reserva.anios_puntos + p[0] + " Pts. año " + puntosAnios.Rows[x][2].ToString() + " Disponibles " + puntosAnios.Rows[x][3].ToString() + " Pts. año " + puntosAnios.Rows[x][2].ToString() + " ";
                        else
                            reserva.anios_puntosA = reserva.anios_puntosA + p[0] + " Pts. año " + puntosAnios.Rows[x][2].ToString() + " Disponibles " + puntosAnios.Rows[x][3].ToString() + " Pts. año " + puntosAnios.Rows[x][2].ToString() + " ";
                    }

                    reserva.modificar_reserva(puntosAnt);
                    reserva.actPuntosAniosReserva(numeroReserva);
                    for (int x = 0; x <= puntosAnios.Rows.Count - 1; x++)
                    {
                        string[] p = puntosAnios.Rows[x][1].ToString().Split(',');
                        reserva.puntosConsumidosReserva(numeroReserva, Convert.ToInt32(p[0]), Convert.ToInt32(puntosAnios.Rows[x][2].ToString()));
                    }
                    int[] dias = new int[hoteles];
                    int d = 0;
                    int h = 0;
                    for (int i = 0; i <= dtpun.Rows.Count - 1; i++)
                    {
                        if (dtpun.Rows[i][0].ToString().Equals("****"))
                        {
                            d++;
                            if (i == dtpun.Rows.Count - 1)
                            {
                                dias[h] = d;
                            }
                        }
                        else
                        {

                            if (i > 0)
                            {
                                dias[h] = d;
                                h++;
                                d = 0;
                            }
                        }
                    }

                    h = 0;
                    int l = 0;
                    for (int i = 0; i <= dtpun.Rows.Count - 1; i++)
                    {

                        if (!dtpun.Rows[i][0].ToString().Equals("****"))
                        {
                            ini = dtpun.Rows[i][2].ToString().Split('/');
                            fechI = ini[2] + "/" + ini[1] + "/" + ini[0];
                            fin = dtpun.Rows[i + dias[h]][2].ToString().Split('/');
                            fechF = fin[2] + "/" + fin[1] + "/" + fin[0];
                            if (dtpun.Rows[i][0].ToString().Equals("COCHE PUNTA BLANCA") || dtpun.Rows[i][0].ToString().Equals("ISLA CARIBE"))
                            {
                                l = l + dias[h];
                                reserva.hotel_reserva(dtpun.Rows[i][0].ToString(), fechI, fechF, Convert.ToInt32(dtpun.Rows[i + dias[h]][5].ToString()), Convert.ToDouble(dtTi.Rows[l][8].ToString()), Convert.ToDouble(dtTi.Rows[l][7].ToString()));
                                l++;

                            }
                            else reserva.hotel_reserva(dtpun.Rows[i][0].ToString(), fechI, fechF, Convert.ToInt32(dtpun.Rows[i + dias[h]][5].ToString()), 0, 0);
                            h++;
                        }

                    }
                    String hotel = "";
                    for (int i = 0; i <= dtp.Rows.Count - 1; i++)
                    {

                        if (!dtp.Rows[i][0].ToString().Equals("****"))
                            hotel = dtp.Rows[i][0].ToString();
                        reserva.habitacion_reserva(hotel, dtp.Rows[i][1].ToString(), Convert.ToInt32(dtp.Rows[i][2].ToString()), Convert.ToInt32(dtp.Rows[i][3].ToString()), Convert.ToInt32(dtp.Rows[i][4].ToString()), dtp.Rows[i][5].ToString(), dtp.Rows[i][6].ToString());
                    }
                    for (int i = 0; i <= dtpunAnio.Rows.Count - 1; i++)
                    {
                        String[] p = dtpunAnio.Rows[i][2].ToString().Split(',');
                        String[] p1 = dtpunAnio.Rows[i][3].ToString().Split(',');
                        reserva.quitar_puntos(Convert.ToInt32(p[0]), Convert.ToInt32(p1[0]), Convert.ToInt32(dtpunAnio.Rows[i][1].ToString()));
                    }
                    MessageBox.Show("Se ha modificado correctamente la reserva", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                    MessageBox.Show("Si ya la reserva tenia localizadores asignados, debe colocarlos nuevamente", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                    inhabilita("todo");
                    // txtcedula.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.StackTrace);
                }
            }
            else
            {
                puntosAnioCliente();
            }


        }
        private void puntosAnioCliente()
        {
            cliente cli = new cliente();
            dtpunAnio = new DataTable();
            //ojo try catch****************************************************
            dtpunAnio.Load(cli.buscar_puntos(cliente, n_contrato));
            dtgrdPuntosPorAnio.ItemsSource = dtpunAnio.DefaultView;
        }

        private void limpiar()
        {
            
            tbContenedor.SelectedIndex = 0;
            if (dtgReservas.ItemsSource != null)
                dtgReservas.ItemsSource = null;
            numeroReserva = 0;
            lbltitulo.Content = "";
            txtCliente.Text = "";
            txtNroContrato.Text = "";
            txtNroReserva.Text = "";
            dpfecha.SelectedDate = null;

        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            limpiar();
            inhabilita("todo");
            dtgReservas.IsEnabled = true;
        }

        private void txtdescuento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                e.Handled = false;
            else if (e.Key == Key.OemPeriod)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtdescuento_KeyUp(object sender, KeyEventArgs e)
        {
            txtdexcuentobs.IsEnabled = false;
            btnGuarda.IsEnabled = true;
        }

        private void tbDescuento_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void txtdexcuentobs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                e.Handled = false;
            else if (e.Key == Key.OemPeriod)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtdexcuentobs_KeyUp(object sender, KeyEventArgs e)
        {
            txtdescuento.IsEnabled = false;
            btnGuarda.IsEnabled = true;
        }


        private void chkSelectAll_Checked(object sender, RoutedEventArgs e)
        {
            if (txtdescuento.Text.Equals("") && txtdexcuentobs.Text.Equals(""))
            {
                MessageBox.Show("Debe colocar porcentaje ó monto de descuento", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            txtdescuento.IsEnabled = false;
            foreach (persona p in dtgPersonaDes.ItemsSource)
            {
                p.IsSelected = true;
                if (!txtdescuento.Text.Equals(""))
                {
                    if (Convert.ToDouble(txtdescuento.Text) > 100)
                    {
                        MessageBox.Show("El porcentaje no puede ser mayor a 100%", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    p.descuento = Convert.ToDouble(txtdescuento.Text).ToString("N2", CultureInfo.CreateSpecificCulture("es-VE"));
                    p.descuentob = Math.Round(Convert.ToDouble(p.monto) * (Convert.ToDouble(p.descuento) / 100), 2).ToString("N2", CultureInfo.CreateSpecificCulture("es-VE"));
                    double t = Convert.ToDouble(p.monto) - Convert.ToDouble(p.descuentob);
                    p.total = t.ToString("N2", CultureInfo.CreateSpecificCulture("es-VE"));

                }
                else
                {
                    if (Convert.ToDouble(txtdexcuentobs.Text) >Convert.ToDouble(p.monto))
                    {
                        MessageBox.Show("El monto a descontar no puede ser mayor al monto por persona", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    p.descuentob = Convert.ToDouble(txtdexcuentobs.Text).ToString("N2", CultureInfo.CreateSpecificCulture("es-VE"));
                    double t = Convert.ToDouble(p.monto) - Convert.ToDouble(p.descuentob);
                    p.total = t.ToString("N2", CultureInfo.CreateSpecificCulture("es-VE"));
                    p.descuento = Math.Round(Convert.ToDouble(p.descuentob) * 100 / Convert.ToDouble(p.monto), 2).ToString("N2", CultureInfo.CreateSpecificCulture("es-VE")); 
                }
                dtgPersonaDes.Items.Refresh();

            }
        }

        private void chkSelectAll_Unchecked(object sender, RoutedEventArgs e)
        {
            foreach (persona p in dtgPersonaDes.ItemsSource)
            {
                p.IsSelected = false;
                p.descuento =" 0";
                p.total = p.monto;
                p.descuentob =" 0";
                dtgPersonaDes.Items.Refresh();
            }
        }

        private void btnCancelarDes_Click(object sender, RoutedEventArgs e)
        {
            txtdescuento.IsEnabled = true;
            txtdexcuentobs.IsEnabled = true;
            btnGuarda.IsEnabled = false;
        }
        private void OnChecked(object sender, RoutedEventArgs e)
        {

        }

        private void dtgPersonaDes_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (dtgPersonaDes.SelectedItem != null)
            {
                if (txtdescuento.Text.Equals("") && txtdexcuentobs.Text.Equals(""))
                {
                    MessageBox.Show("Debe colocar porcentaje ó monto de descuento", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                persona p = dtgPersonaDes.SelectedItem as persona;
                if (p.IsSelected)
                {
                    p.IsSelected = false;
                    p.descuento = "0";
                    p.total = p.monto;
                    p.descuentob = "0";
                    dtgPersonaDes.Items.Refresh();
                }
                else
                {
                    p.IsSelected = true;
                    if (!txtdescuento.Text.Equals(""))
                    {
                        if (Convert.ToDouble(txtdescuento.Text) > 100)
                        {
                            MessageBox.Show("El porcentaje no puede ser mayor a 100%", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        p.descuento = Convert.ToDouble(txtdescuento.Text).ToString("N2", CultureInfo.CreateSpecificCulture("es-VE"));
                        p.descuentob = Math.Round(Convert.ToDouble(p.monto) * (Convert.ToDouble(p.descuento) / 100), 2).ToString("N2",CultureInfo.CreateSpecificCulture("es-VE"));
                        double t=Convert.ToDouble( p.monto)-Convert.ToDouble(p.descuentob);
                        p.total = t.ToString("N2", CultureInfo.CreateSpecificCulture("es-VE"));

                    }
                    else
                    {
                        if (Convert.ToDouble(txtdexcuentobs.Text) >Convert.ToDouble( p.monto))
                        {
                            MessageBox.Show("El monto a descontar no puede ser mayor al monto por persona", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        p.descuentob = Convert.ToDouble(txtdexcuentobs.Text).ToString("N2", CultureInfo.CreateSpecificCulture("es-VE"));
                        double t = Convert.ToDouble(p.monto) - Convert.ToDouble(p.descuentob);
                        p.total = t.ToString("N2", CultureInfo.CreateSpecificCulture("es-VE"));
                        p.descuento = Math.Round(Convert.ToDouble(p.descuentob) * 100 / Convert.ToDouble(p.monto), 2).ToString("N2", CultureInfo.CreateSpecificCulture("es-VE")); 
                    }
                    dtgPersonaDes.Items.Refresh();

                }
            }
        }

        private void btnGuarda_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("¿Desea aplicar el descuento?", "Pregunta", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                double totaldes = 0;
               
                int l = 0;
                string ho = "";
                bool s = false;
                foreach (persona pr in dtgPersonaDes.ItemsSource)
                {
                    if (ho.Equals(""))
                        ho = pr.hotel;
                    l++;
                    if (!pr.hotel.Equals(ho))
                    {

                        if (totaldes > 0)
                        {
                            for (int p = 0; p <= dtTi.Rows.Count - 1; p++)
                            {
                                if (dtTi.Rows[p][0].ToString().Equals(ho))
                                {
                                    for (int j = p; j <= dtTi.Rows.Count - 1; j++)
                                    {
                                        if (!dtTi.Rows[j][6].ToString().Equals(""))
                                        {
                                            dtTi.Rows[j][7] = totaldes.ToString("N2", CultureInfo.CreateSpecificCulture("es-VE"));
                                            double tt = Convert.ToDouble(dtTi.Rows[j][6].ToString()) - totaldes;
                                            dtTi.Rows[j][8] = tt.ToString("N2", CultureInfo.CreateSpecificCulture("es-VE"));
                                            totaldes = 0;
                                            s = true;
                                            break;
                                        }
                                    }
                                    if (s == true)
                                    {
                                        s = false;
                                        break;
                                    }
                                }

                            }
                        }
                        ho = pr.hotel;
                        totaldes = totaldes +Convert.ToDouble(pr.descuentob);
                    }
                    else
                    {
                        totaldes = totaldes +Convert.ToDouble(pr.descuentob);
                        if (l == dtgPersonaDes.Items.Count)
                        {
                            if (totaldes > 0)
                            {
                                for (int p = 0; p <= dtTi.Rows.Count - 1; p++)
                                {
                                    if (dtTi.Rows[p][0].ToString().Equals(ho))
                                    {
                                        for (int j = p; j <= dtTi.Rows.Count - 1; j++)
                                        {
                                            if (!dtTi.Rows[j][6].ToString().Equals(""))
                                            {
                                                dtTi.Rows[j][7] = totaldes.ToString("N2",CultureInfo.CreateSpecificCulture("es-VE"));
                                                double tt = Convert.ToDouble(dtTi.Rows[j][6].ToString()) - totaldes;
                                                dtTi.Rows[j][8] = tt.ToString("N2", CultureInfo.CreateSpecificCulture("es-VE"));
                                                totaldes = 0;
                                                s = true;
                                                break;
                                            }
                                        }
                                        if (s == true)
                                        {
                                            s = false;
                                            break;
                                        }
                                    }

                                }
                            }
                        }
                    }

                }
                dtgTodoIncluido.Items.Refresh();
                totalTi();
                MessageBox.Show("Se ha aplicado correctamente el descuento", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnAnular_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("¿Seguro desea anular la reserva?", "Pregunta", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    devolver_puntos();
                    reservacion reserva = new reservacion();
                    reserva.cliente = cliente;
                    reserva.n_contrato = n_contrato;
                    for (int i = 0; i <= dtpunAnio.Rows.Count - 1; i++)
                    {
                        String[] p = dtpunAnio.Rows[i][2].ToString().Split(',');
                        String[] p1 = dtpunAnio.Rows[i][3].ToString().Split(',');
                        reserva.quitar_puntos(Convert.ToInt32(p[0]), Convert.ToInt32(p1[0]), Convert.ToInt32(dtpunAnio.Rows[i][1].ToString()));
                    }
                    reserva.anular_reserva(numeroReserva, puntosreserva, cliente, user);
                    MessageBox.Show("Se ha anulado la reserva", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                    inhabilita("todo");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.StackTrace);
                }
            }
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (cambiahab)
            {
                if (dtp != null)
                {
                    dtp.Rows[cambiarow][1] = lstHabitacion.SelectedItem.ToString();
                    cambiahab = false;
                    btnModificar.IsEnabled = true;
                }
            }
            try
            {
                bool errorPersonas = false;
                for (int n = 0; n <= dtp.Rows.Count - 1; n++)
                {
                    
                    if (Convert.ToInt32(dtp.Rows[n][4].ToString()) <= 0)
                        errorPersonas = true;
                }
                if (errorPersonas)
                {
                    MessageBox.Show("Verifique la cantidad de personas en las habitaciones ", "ADVERTENCIA", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Verifique el formato de la cantidad de personas en las habitaciones", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            DataTable dtp1 = dtp;

            try
            {
                bool error = false,errfechaini=false;
                //DateTime fe = Convert.ToDateTime(dtp1.Rows[0][5].ToString());
                DateTime fs = Convert.ToDateTime(dtp1.Rows[0][6].ToString());
                for (int i = 0; i <= dtp1.Rows.Count - 1; i++)
                {
                    if (Convert.ToDateTime(dtp1.Rows[i][5].ToString()).CompareTo(DateTime.Today) < 0)
                        errfechaini = true;
                    if (i > 0 && !dtp1.Rows[i][0].ToString().Equals("****"))
                    {

                        if (DateTime.Compare(Convert.ToDateTime(dtp1.Rows[i][5].ToString()), fs) < 0)
                        {
                            error = true;
                        }
                        else
                        {
                            fs = Convert.ToDateTime(dtp1.Rows[i][6].ToString());
                        }
                    }
                }
                if (error)
                {
                    MessageBox.Show("Verifique las fechas de entrada y salida", "ADVERTENCIA", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                if (errfechaini)
                {
                    MessageBox.Show("Verifique la fecha de entrada no puede ser anterior a la actual", "ADVERTENCIA", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Verifique el formato de las fechas de entrada y salida", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            dtp = null;
            dtpun = null;
            dtTi = null;
            dtDes = null;
            //puntosreserva = 0;
            dtgPersona.ItemsSource = null;
            dtgPersonaDes.ItemsSource = null;
            dtgTodoIncluido.ItemsSource = null;
            dtgPunto.ItemsSource = null;
            infate = 0;
            ninio = 0;
            adulto = 0;
            agregado = 0;
            capacidad = 0;
            lp = 0;
            lt = 0;
            //diasReserva = 0;
            totalnoches = 0;
            hoteles = 0;
            habitacion = 0;
            totalhabitacion = 0;
            totalacelerado = 0;
            totalTodoIncluido = 0;
            string ho = "";
            for (int i = 0; i <= dtp1.Rows.Count - 1; i++)
            {
                if (!dtp1.Rows[i][0].ToString().Equals("****"))
                {
                    if (i > 0)
                    {
                        otra = false;
                        otro = true;
                        habitacion = 0;
                        agregado = 0;
                        infate = 0;
                        ninio = 0;
                        adulto = 0;
                        
                    }
                    lstHotel.SelectedItem = dtp1.Rows[i][0].ToString();
                    ho = lstHotel.SelectedItem.ToString();
                    lstHabitacion.SelectedItem = dtp1.Rows[i][1].ToString();
                    capacidad = Convert.ToInt32(lblValorCapacidad.Content);
                    if (lstHotel.SelectedValue.ToString().Equals("ISLA CARIBE"))
                        capacidad++;
                    dpFechaI.SelectedDate = Convert.ToDateTime(dtp1.Rows[i][5].ToString());
                    dpFechaF.SelectedDate = Convert.ToDateTime(dtp1.Rows[i][6].ToString());
                    TimeSpan dias = dpFechaF.SelectedDate.Value - dpFechaI.SelectedDate.Value;
                    diasReserva = dias.Days - 1;
                    if (Convert.ToInt32(dtp1.Rows[i][2].ToString()) > 0)
                    {
                        for (int inf = 0; inf <= Convert.ToInt32(dtp1.Rows[i][2].ToString()) - 1; inf++)
                        {
                            lstPersona.SelectedIndex = 0;
                            btnAgregar_Click(sender, e);
                        }
                    }
                    if (Convert.ToInt32(dtp1.Rows[i][3].ToString()) > 0)
                    {
                        for (int n = 0; n <= Convert.ToInt32(dtp1.Rows[i][3].ToString()) - 1; n++)
                        {
                            lstPersona.SelectedIndex = 1;
                            btnAgregar_Click(sender, e);
                        }
                    }
                    if (Convert.ToInt32(dtp1.Rows[i][4].ToString()) > 0)
                    {
                        for (int a = 0; a <= Convert.ToInt32(dtp1.Rows[i][4].ToString()) - 1; a++)
                        {
                            lstPersona.SelectedIndex = 2;
                            btnAgregar_Click(sender, e);
                        }
                    }
                    infate = 0;
                    ninio = 0;
                    adulto = 0;
                    agregado = 0;
                    capacidad = 0;

                }
                else
                {
                    otra = true;
                    
                    otro = false;
                    infate = 0;
                    ninio = 0;
                    adulto = 0;
                    agregado = 0;
                    capacidad = 0;
                    lstHotel.SelectedItem = ho;
                    lstHabitacion.SelectedItem = dtp1.Rows[i][1].ToString();
                    capacidad = Convert.ToInt32(lblValorCapacidad.Content);
                    dpFechaI.SelectedDate = Convert.ToDateTime(dtp1.Rows[i][5]);
                    dpFechaF.SelectedDate = Convert.ToDateTime(dtp1.Rows[i][6]);
                    TimeSpan dias = dpFechaF.SelectedDate.Value - dpFechaI.SelectedDate.Value;
                    diasReserva = dias.Days - 1;

                    if (Convert.ToInt32(dtp1.Rows[i][2].ToString()) > 0)
                    {
                        for (int inf = 0; inf <= Convert.ToInt32(dtp1.Rows[i][2].ToString()) - 1; inf++)
                        {
                            lstPersona.SelectedIndex = 0;
                            btnAgregar_Click(sender, e);
                        }
                    }
                    if (Convert.ToInt32(dtp1.Rows[i][3].ToString()) > 0)
                    {
                        for (int n = 0; n <= Convert.ToInt32(dtp1.Rows[i][3].ToString()) - 1; n++)
                        {
                            lstPersona.SelectedIndex = 1;
                            btnAgregar_Click(sender, e);
                        }
                    }
                    if (Convert.ToInt32(dtp1.Rows[i][4].ToString()) > 0)
                    {
                        for (int a = 0; a <= Convert.ToInt32(dtp1.Rows[i][4].ToString()) - 1; a++)
                        {
                            lstPersona.SelectedIndex = 2;
                            btnAgregar_Click(sender, e);
                        }
                    }

                }
            }
            infate = Convert.ToInt32(dtp1.Rows[dtp1.Rows.Count - 1][2].ToString());
            ninio = Convert.ToInt32(dtp1.Rows[dtp1.Rows.Count - 1][3].ToString());
            adulto = Convert.ToInt32(dtp1.Rows[dtp1.Rows.Count - 1][4].ToString());
            btnModificar.IsEnabled = false;
        }

        private void dtgPersona_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            btnModificar.IsEnabled = true;
        }

        private void dtgPersona_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dtgPersona.SelectedIndex != -1)
            {
                cambiahab = true;
                btnQuitarHabitacion.IsEnabled = true;
                cambiarow = dtgPersona.SelectedIndex;
                dpFechaI.SelectedDate = Convert.ToDateTime(dtp.Rows[cambiarow][5].ToString());
                dpFechaF.SelectedDate = Convert.ToDateTime(dtp.Rows[cambiarow][6].ToString());
                if (dtp.Rows[cambiarow][0].ToString().Equals("****"))
                {
                    for (int i = cambiarow; i >= 0; i--)
                    {
                        if (!dtp.Rows[i][0].ToString().Equals("****"))
                        {
                            lstHotel.SelectedItem = dtp.Rows[i][0].ToString();
                            break;
                        }
                    }
                }
                else
                    lstHotel.SelectedItem = dtp.Rows[cambiarow][0].ToString();
                lstHabitacion.SelectedItem = dtp.Rows[cambiarow][1].ToString();
                dpFechaI.IsEnabled = false;
                dpFechaF.IsEnabled = false;
                lstHotel.IsEnabled = false;
                lstHabitacion.IsEnabled = true;

                btnAgregar.IsEnabled = false;
                lstPersona.IsEnabled = false;
            }

        }

        private void txtNroReserva_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtNroContrato_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            puntosAnios = new DataTable();
            puntosAnios.Columns.Add("reserva");
            puntosAnios.Columns.Add("puntos");
            puntosAnios.Columns.Add("anio");
            puntosAnios.Columns.Add("puntoDisponibles");
            puntosAnios.Columns.Add("acelerados");
        }

        private void dtgReservas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
    }
  
