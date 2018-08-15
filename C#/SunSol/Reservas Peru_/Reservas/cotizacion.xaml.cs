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
using librerias;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;

namespace Reservas
{
    /// <summary>
    /// Lógica de interacción para cotizacion.xaml
    /// </summary>
    public partial class cotizacion : Page
    {
        DataTable dt;
        public string user;
        public usuario us;
        string fech1CB, fech2CB, fech1IC, fech2IC, fech1ID, fech2ID, fech1CPB, fech2CPB, fechF1CPB, fechF2CPB, fechF1IC, fechF2IC, fechaI1CA,fechaI2CA,fechaF1CA,fechaF2CA;
        bool delocalizador = false,dereserva=false;
        public int numeroReserva = 0;
        public string contrato = "";
        ReportDataSource rdstemporada = new ReportDataSource();
        dsTemporadaTI dstemp = new dsTemporadaTI();
        ReportDataSource rdshotel = new ReportDataSource();
        dscotizacion datasetC = new dscotizacion();
        ReportDataSource rdshabitacion = new ReportDataSource();
        ReportDataSource rdscargos = new ReportDataSource();
        dsReservas datasetR = new dsReservas();
        dsCotizacionHabitacion dsH = new dsCotizacionHabitacion();
        dsCotizacionHotel dsh = new dsCotizacionHotel();
        dsCotizacionCargos dsc = new dsCotizacionCargos();
        dsMontoPA dsm = new dsMontoPA();
        ReportDataSource rdsmontoPA = new ReportDataSource();
        ReportDataSource rdsconfirmacion = new ReportDataSource();
        ReportDataSource rdsconHab = new ReportDataSource();
        dsConfirmacion dscon = new dsConfirmacion();
        dsConfirmacionHabitacion dsconHabi = new dsConfirmacionHabitacion();
        ReportDataSource rpdsPagosTI = new ReportDataSource();
        ReportDataSource rpdsPagosTI1 = new ReportDataSource();
        ReportDataSource rpdsPagosTI2 = new ReportDataSource();
        dsConfirmacionPagosTI dsconPagosTI = new dsConfirmacionPagosTI();
        dsConfirmacionPagosTI dsconPagosTI1 = new dsConfirmacionPagosTI();
        dsConfirmacionPagosTI dsconPagosTI2 = new dsConfirmacionPagosTI();
        ReportDataSource rpdsPaxloca1 = new ReportDataSource();
        dsPaxlocalizador dsPaxloca1 = new dsPaxlocalizador();
        ReportDataSource rpdsPaxloca2 = new ReportDataSource();
        dsPaxlocalizador dsPaxloca2 = new dsPaxlocalizador();

        ReportDataSource rpdsConcaTempIC1 = new ReportDataSource();
        dsConcaTemporadas dsConcaTempISC1 = new dsConcaTemporadas();
        ReportDataSource rpdsConcaTempIC2 = new ReportDataSource();
        dsConcaTemporadas dsConcaTempISC2 = new dsConcaTemporadas();

        ReportDataSource rpdsConcaTempCPB1 = new ReportDataSource();
        dsConcaTemporadas dsConcaTempCPB1 = new dsConcaTemporadas();
        ReportDataSource rpdsConcaTempCPB2 = new ReportDataSource();
        dsConcaTemporadas dsConcaTempCPB2 = new dsConcaTemporadas();

        ReportDataSource rpdsConcaTempCoti = new ReportDataSource();
        dsConcaTemporadas dsConcaTempCoti = new dsConcaTemporadas();

        ReportDataSource rpdsConcaTempCoti1 = new ReportDataSource();
        dsConcaTemporadas dsConcaTempCoti1 = new dsConcaTemporadas();

        ReportDataSource rpdsConceptos = new ReportDataSource();
        dsConceptos dsConceptos = new dsConceptos();
        public string ini = "";
        public string fin = "";
        string gconcepto, gfecha, gstatus,gcontrato, gfechaf,ghotel,gEjecutivo;
        int greserva;
        string gRcliente, gRfecha, gRstatus, gRcontrato, gRfechaf;
        int gRreserva;
        public cotizacion()
        {
            InitializeComponent();
            lstCargos1.Items.Add("");
            lstCargos1.Items.Add("TODO INCLUIDO");
            lstCargos1.Items.Add("PUNTOS ACELERADOS");
            lstEstatus1.Items.Add("");
            lstEstatus1.Items.Add("CONFIRMADO");
            lstEstatus1.Items.Add("PENDIENTE");
            lstEstatus.Items.Add("");
            lstHotel.Items.Add("");
            lstHotel.Items.Add("COCHE PUNTA BLANCA");
            lstHotel.Items.Add("ISLA CARIBE");
            lstEjecutivo.Items.Add("");           
            reservacion res = new reservacion();
            SqlDataReader sr = res.buscar_cargos();
            int i = 0;

            if (sr != null)
            {




                while (sr.Read())
                {

                    lstCargos1.Items.Add(sr.GetString(i));
                }
                sr.Close();

            }
            
            

        }




        private void ReportViewer_LoadReserva(object sender, EventArgs e)
        {

        }

        private void dtgReservas_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            object item = dtgReservas.SelectedItem;
            if ((dtgReservas.Items.Count > 0) && (item != null))
            {
                numeroReserva = Convert.ToInt32((dtgReservas.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
                string[] fi = (dtgReservas.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text.Split('-');
                string[] ff = (dtgReservas.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text.Split('-');
                ini = fi[2] + "/" + fi[1] + "/" + fi[0];
                fin = ff[2] + "/" + ff[1] + "/" + ff[0];
                dsh.Clear();
                dsH.Clear();
                _reportViewer.Clear();
                dsh.BeginInit();
                rdshotel.Name = "DataSet1";
                rdshotel.Value = dsh._V_cotizacionHotel;
                _reportViewer.LocalReport.DataSources.Add(rdshotel);
                dsh.EndInit();
                dsH.BeginInit();
                rdshabitacion.Name = "DataSet2";
                rdshabitacion.Value = dsH._V_cotizacionHabitacion;
                _reportViewer.LocalReport.DataSources.Add(rdshabitacion);
                dsH.EndInit();
                dsc.BeginInit();
                rdscargos.Name = "DataSet3";
                rdscargos.Value = dsc._V_CotizacionCargos;
                _reportViewer.LocalReport.DataSources.Add(rdscargos);
                dsc.EndInit();
                dsm.BeginInit();
                rdsmontoPA.Name = "DataSet4";
                rdsmontoPA.Value = dsm._MontoPuntoAcelerado;
                _reportViewer.LocalReport.DataSources.Add(rdsmontoPA);
                dsm.EndInit();
                dstemp.BeginInit();
                rdstemporada.Name = "DataSet5";
                rdstemporada.Value = dstemp._temporada_TI;
                _reportViewer.LocalReport.DataSources.Add(rdstemporada);
                dstemp.EndInit();

                dsConcaTempCoti.BeginInit();
                rpdsConcaTempCoti.Name = "DataSet6";
                rpdsConcaTempCoti.Value = dsConcaTempCoti._sp_ConcaTemporada;
                _reportViewer.LocalReport.DataSources.Add(rpdsConcaTempCoti);
                dsConcaTempCoti.EndInit();

                dsConcaTempCoti1.BeginInit();
                rpdsConcaTempCoti1.Name = "DataSet7";
                rpdsConcaTempCoti1.Value = dsConcaTempCoti1._sp_ConcaTemporada;
                _reportViewer.LocalReport.DataSources.Add(rpdsConcaTempCoti1);
                dsConcaTempCoti1.EndInit();

                dsConceptos.BeginInit();
                rpdsConceptos.Name = "DataSet8";
                rpdsConceptos.Value = dsConceptos._ConceptoCotizacion;
                _reportViewer.LocalReport.DataSources.Add(rpdsConceptos);
                dsConceptos.EndInit();

                this._reportViewer.LocalReport.ReportEmbeddedResource = "Reservas.cotizacionN.rdlc";
                dsCotizacionHotelTableAdapters._V_cotizacionHotelTableAdapter th = new dsCotizacionHotelTableAdapters._V_cotizacionHotelTableAdapter();
                th.ClearBeforeFill = true;
                th.Fill(dsh._V_cotizacionHotel, numeroReserva);

                dsCotizacionHabitacionTableAdapters._V_cotizacionHabitacionTableAdapter tH = new dsCotizacionHabitacionTableAdapters._V_cotizacionHabitacionTableAdapter();
                tH.ClearBeforeFill = true;
                tH.Fill(dsH._V_cotizacionHabitacion, numeroReserva);

                dsCotizacionCargosTableAdapters._V_CotizacionCargosTableAdapter tc = new dsCotizacionCargosTableAdapters._V_CotizacionCargosTableAdapter();
                tc.ClearBeforeFill = true;
                tc.Fill(dsc._V_CotizacionCargos, numeroReserva);

                dsMontoPATableAdapters._MontoPuntoAceleradoTableAdapter tm = new dsMontoPATableAdapters._MontoPuntoAceleradoTableAdapter();
                tm.ClearBeforeFill = true;
                tm.Fill(dsm._MontoPuntoAcelerado);

                dsTemporadaTITableAdapters._temporada_TITableAdapter tt = new dsTemporadaTITableAdapters._temporada_TITableAdapter();
                tt.ClearBeforeFill = true;
                tt.Fill(dstemp._temporada_TI, ini, fin);

                dsConcaTemporadasTableAdapters._sp_ConcaTemporadaTableAdapter ct = new dsConcaTemporadasTableAdapters._sp_ConcaTemporadaTableAdapter();
                ct.ClearBeforeFill = true;
                ct.Fill(dsConcaTempCoti._sp_ConcaTemporada, ini, fin,"COCHE PUNTA BLANCA");

                dsConcaTemporadasTableAdapters._sp_ConcaTemporadaTableAdapter ct1 = new dsConcaTemporadasTableAdapters._sp_ConcaTemporadaTableAdapter();
                ct1.ClearBeforeFill = true;
                ct1.Fill(dsConcaTempCoti1._sp_ConcaTemporada, ini, fin,"ISLA CARIBE");

                dsConceptosTableAdapters._ConceptoCotizacionTableAdapter cta = new dsConceptosTableAdapters._ConceptoCotizacionTableAdapter();
                cta.ClearBeforeFill = true;
                cta.Fill(dsConceptos._ConceptoCotizacion);

                ReportParameter[] parameters = new ReportParameter[2];
                parameters[0] = new ReportParameter("reserva", numeroReserva.ToString());
                parameters[1] = new ReportParameter("usuario", user);
                _reportViewer.LocalReport.SetParameters(parameters);
                _reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
                _reportViewer.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;

                _reportViewer.RefreshReport();
            }


        }

        private void txtNroReserva_KeyUp(object sender, KeyEventArgs e)
        {
            DateTime? f = dpfecha.SelectedDate;
            DateTime? ff = dpfin.SelectedDate;
            reservacion res = new reservacion();
            if ((txtCliente.Text.Equals("")) && (txtNroContrato.Text.Equals("")) && (f == null) && (ff == null))
                dtgReservas.ItemsSource = res.buscar_reservaC(txtNroReserva.Text, "0", "", "0","");
            else
            {

                if ((!txtCliente.Text.Equals("")) && (txtNroContrato.Text.Equals("")) && (f == null) && (ff == null))
                    dtgReservas.ItemsSource = res.buscar_reservaC(txtNroReserva.Text, txtCliente.Text, "", "0","");
                else
                {
                    if ((!txtCliente.Text.Equals("")) && (!txtNroContrato.Text.Equals("")) && (f == null) && (ff == null))
                        dtgReservas.ItemsSource = res.buscar_reservaC(txtNroReserva.Text, txtCliente.Text, "", txtNroContrato.Text,"") ;
                    else
                    {
                        if ((!txtCliente.Text.Equals("")) && (!txtNroContrato.Text.Equals("")) && (f != null) && (ff == null))
                        {
                            String[] ini = f.Value.ToShortDateString().Split('/');
                            String fechI = ini[2] + "/" + ini[1] + "/" + ini[0];
                            dtgReservas.ItemsSource = res.buscar_reservaC(txtNroReserva.Text, txtCliente.Text, fechI, txtNroContrato.Text,"");
                        }

                    }
                }
            }
        }

        private void txtCliente_KeyUp(object sender, KeyEventArgs e)
        {
            DateTime? f = dpfecha.SelectedDate;
            DateTime? ff = dpfin.SelectedDate;
            reservacion res = new reservacion();
            if ((txtNroReserva.Text.Equals("")) && (txtNroContrato.Text.Equals("")) && (f == null) && (ff == null))
                dtgReservas.ItemsSource = res.buscar_reservaC("0", txtCliente.Text, "", "0","");
            else
            {
                _reportViewer.Clear();
                if ((!txtNroReserva.Text.Equals("")) && (txtNroContrato.Text.Equals("")) && (f == null) && (ff == null))
                    dtgReservas.ItemsSource = res.buscar_reservaC(txtNroReserva.Text, txtCliente.Text, "", "0","");
                else
                {
                    if ((!txtNroReserva.Text.Equals("")) && (!txtNroContrato.Text.Equals("")) && (f == null) && (ff == null))
                        dtgReservas.ItemsSource = res.buscar_reservaC(txtNroReserva.Text, txtCliente.Text, "", txtNroContrato.Text,"");
                    else
                    {
                        if ((!txtNroReserva.Text.Equals("")) && (!txtNroContrato.Text.Equals("")) && (f != null) && (ff == null))
                        {
                            String[] ini = f.Value.ToShortDateString().Split('/');
                            String fechI = ini[2] + "/" + ini[1] + "/" + ini[0];
                            dtgReservas.ItemsSource = res.buscar_reservaC(txtNroReserva.Text, txtCliente.Text, fechI, txtNroContrato.Text,"");
                        }

                    }
                }
            }
        }

        private void dpfecha_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? f = dpfecha.SelectedDate;
            DateTime? ff = dpfin.SelectedDate;
            if (f != null)
            {
                String[] ini = f.Value.ToShortDateString().Split('/');
                String fechI = ini[2] + "/" + ini[1] + "/" + ini[0];
                reservacion res = new reservacion();
                if ((txtCliente.Text.Equals("")) && (txtNroReserva.Text.Equals("")) && (txtNroContrato.Text.Equals("")) &&ff==null)
                    dtgReservas.ItemsSource = res.buscar_reservaC("0", "0", fechI, "0","");
                else
                {
                    _reportViewer.Clear();
                    if ((!txtCliente.Text.Equals("")) && (txtNroReserva.Text.Equals("")) && (txtNroContrato.Text.Equals("")) && ff == null)
                        dtgReservas.ItemsSource = res.buscar_reservaC("0", txtCliente.Text, fechI, "0","");
                    else
                    {
                        if ((!txtCliente.Text.Equals("")) && (!txtNroReserva.Text.Equals("")) && (txtNroContrato.Text.Equals("")) && ff == null)
                            dtgReservas.ItemsSource = res.buscar_reservaC(txtNroReserva.Text, txtCliente.Text, fechI, "0","");
                        else
                        {
                            if ((!txtCliente.Text.Equals("")) && (!txtNroReserva.Text.Equals("")) && (!txtNroContrato.Text.Equals("")) && ff == null)
                            {

                                dtgReservas.ItemsSource = res.buscar_reservaC(txtNroReserva.Text, txtCliente.Text, fechI, txtNroContrato.Text,"");
                            }
                            else
                            {
                                if ((txtCliente.Text.Equals("")) && (txtNroReserva.Text.Equals("")) && (txtNroContrato.Text.Equals("")) && ff != null)
                                {
                                    String[] fin = ff.Value.ToShortDateString().Split('/');
                                    String fechF = fin[2] + "/" + fin[1] + "/" + fin[0];
                                    dtgReservas.ItemsSource = res.buscar_reservaC("0", "0", fechI, "0", fechF);
                                }
                            }

                        }
                    }
                }
            }
        }

        private void txtNroContrato_KeyUp(object sender, KeyEventArgs e)
        {
            DateTime? f = dpfecha.SelectedDate;
            DateTime? ff = dpfin.SelectedDate;
            reservacion res = new reservacion();
            if ((txtCliente.Text.Equals("")) && (txtNroReserva.Text.Equals("")) && (f == null) && (ff == null))
                dtgReservas.ItemsSource = res.buscar_reservaC("0", "0", "", txtNroContrato.Text,"");
            else
            {
                _reportViewer.Clear();
                if ((!txtCliente.Text.Equals("")) && (txtNroReserva.Text.Equals("")) && (f == null) && (ff == null))
                    dtgReservas.ItemsSource = res.buscar_reservaC("0", txtCliente.Text, "", txtNroContrato.Text,"");
                else
                {
                    if ((!txtCliente.Text.Equals("")) && (!txtNroReserva.Text.Equals("")) && (f == null) && (ff == null))
                        dtgReservas.ItemsSource = res.buscar_reservaC(txtNroReserva.Text, txtCliente.Text, "", txtNroContrato.Text,"");
                    else
                    {
                        if ((!txtCliente.Text.Equals("")) && (!txtNroReserva.Text.Equals("")) && (f != null) && (ff == null))
                        {
                            String[] ini = f.Value.ToShortDateString().Split('/');
                            String fechI = ini[2] + "/" + ini[1] + "/" + ini[0];
                            dtgReservas.ItemsSource = res.buscar_reservaC(txtNroReserva.Text, txtCliente.Text, fechI, txtNroContrato.Text,"");
                        }

                    }
                }
            }
        }

        private void tbReporteReservas_GotFocus(object sender, RoutedEventArgs e)
        {



        }

        private void tbReporteReservas_Loaded(object sender, RoutedEventArgs e)
        {
            ReportViewer_LoadReserva(sender, e);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            if (us.codigoPerfil > 2)
                tbReportesGralRelPtosAnio.IsEnabled = false;
            

            
            
            
            lstEstatus.Items.Add("COTIZADA");
            lstEstatus.Items.Add("CONFIRMADA");
            lstEstatus.Items.Add("PRÓRROGA");
            lstEstatus.Items.Add("ANULADA");
            if (numeroReserva > 0 && !contrato.Equals(""))
            {
                delocalizador = true;
                TabPrimario.SelectedIndex = 1;
                txtNroReserva1.Text = numeroReserva.ToString();
               
            }
            if (numeroReserva > 0 && contrato.Equals(""))
            {
                dereserva = true;
                TabPrimario.SelectedIndex = 0;
                txtNroReserva.Text = numeroReserva.ToString();
            }

            SqlDataReader sr = us.buscar_ejecutivo(us.login);
            if (sr != null)
            {
                if (sr.HasRows)
                {
                    while (sr.Read())
                    {
                        lstEjecutivo.Items.Add(sr.GetString(1).Trim(new char[] { ' ' }) + " " + sr.GetString(2).Trim(new char[] { ' ' }));
                    }
                }
            }
            
        }

        public void cargarPagos(string concepto, string fecha, string status, int reserva, string contrato, string fechaf, string photel, string pEjecutivo)
        {
            if (concepto.Equals("0") && fecha.Equals("0") && reserva == 0 && contrato.Equals("0") && fechaf.Equals("0") && photel.Equals("0") && pEjecutivo.Equals("0") &(status.Equals("0") || status.Equals("2")))
                return;
            reservacion res = new reservacion();
            gconcepto = concepto;
            gfecha = fecha;
            gstatus = status;
            greserva = reserva;
            gcontrato = contrato;
            gfechaf = fechaf;
            ghotel = photel;
            gEjecutivo = pEjecutivo;
            SqlDataReader sr = res.reporte_pagos(concepto, fecha, status, reserva, contrato, fechaf, photel, pEjecutivo,us.login);
            List<trasaccionPago> tmp = new List<trasaccionPago>();
            if (sr != null)
            {
                if (sr.HasRows)
                {
                    while (sr.Read())
                    {
                        tmp.Add(new trasaccionPago()
                        {
                            concepto = sr.GetString(0).Trim(new char[] { ' ' }),
                            trasaccion = sr.GetString(1).Trim(new char[] { ' ' }),
                            documento = sr.GetString(2).Trim(new char[] { ' ' }),
                            monto = sr.GetDouble(3),
                            fecha = sr.GetDateTime(4).ToShortDateString().Trim(new char[] { ' ' }),
                            observacion = sr.GetString(5).Trim(new char[] { ' ' }),
                            confir = sr.GetInt32(7),
                            puntosA=sr.GetDouble(17),
                            referencia = sr.GetInt32(8),
                            anula = sr.GetInt32(9),
                            tipo = sr.GetString(10).Trim(new char[] { ' ' }),
                            ejecutivo = sr.GetString(15).Trim(new char[] { ' ' }),
                            hotel = sr.GetString(14).Trim(new char[] { ' ' }),
                            cuenta = sr.GetString(12).Trim(new char[] { ' ' }),
                            reserva = sr.GetInt32(6),
                            contrato = sr.GetInt32(13).ToString(),
                            estatus = "",
                            anulado = "",
                            loc  = sr.GetString(16).Trim(new char[] { ' ' }),
                            cliente = sr.GetString(18).Trim(new char[] { ' ' })
                        });
                    }
                    dtgPagos.ItemsSource = tmp;
                }
                sr.Close();
            }

            if (dtgPagos.ItemsSource != null)
            {
                foreach (trasaccionPago p in dtgPagos.ItemsSource)
                {
                    if (p.confir == 0)
                        p.estatus = "PENDIENTE";
                    else
                        p.estatus = "CONFIRMADO";
                    if (p.anula == 0)
                        p.anulado = "NO";
                    else
                        p.anulado = "SI";
                }
            }

        }




        private void lstCargos1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            DateTime? f = dpfechaPago.SelectedDate;
            DateTime? ff = dpfechafinPago.SelectedDate;
            string concepto = "";
            string ejecutivo = "";
            string hotel = "";
            if (lstCargos1.SelectedItem != null)
                concepto = lstCargos1.SelectedItem.ToString();
            if (lstEjecutivo.SelectedItem != null)
                ejecutivo = lstEjecutivo.SelectedItem.ToString();
            if (lstHotel.SelectedItem != null)
                hotel = lstHotel.SelectedItem.ToString();
            string reserva = txtNroReservaCobros.Text;
            string contrato = txtNroContratoCobros.Text;
            string status = "";
            String fechI = "";
            String fechF = "";
            dtgPagos.ItemsSource = null;

            if (concepto.Equals(""))
                concepto = "0";
            if (ejecutivo.Equals(""))
                ejecutivo = "0";
            if (hotel.Equals(""))
                hotel = "0";
            if (reserva.Equals(""))
                reserva = "0";
            if (contrato.Equals(""))
                contrato = "0";
            if (lstEstatus1.SelectedIndex == 0)
                status = "2";
            else
            {
                if (lstEstatus1.SelectedIndex == 1)
                    status = "1";
                else
                    status = "0";
            }
            if (f == null)
            {
                fechI = "0";
            }
            else
            {
                String[] ini = f.Value.ToShortDateString().Split('/');
                fechI = ini[2] + "/" + ini[1] + "/" + ini[0];
            }
            if (ff == null)
            {
                fechF = "0";
            }
            else
            {
                String[] fin = ff.Value.ToShortDateString().Split('/');
                fechF = fin[2] + "/" + fin[1] + "/" + fin[0];
            }
            cargarPagos(concepto, fechI, status, Convert.ToInt32(reserva), contrato, fechF, hotel, ejecutivo);
        }

        private void dpfechaPago_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? f = dpfechaPago.SelectedDate;
            DateTime? ff = dpfechafinPago.SelectedDate;
            string concepto = "";
            string ejecutivo = "";
            string hotel = "";
            if (lstCargos1.SelectedItem != null)
                concepto = lstCargos1.SelectedItem.ToString();
            if (lstEjecutivo.SelectedItem != null)
                ejecutivo = lstEjecutivo.SelectedItem.ToString();
            if (lstHotel.SelectedItem != null)
                hotel = lstHotel.SelectedItem.ToString();
            string reserva = txtNroReservaCobros.Text;
            string contrato = txtNroContratoCobros.Text;
            string status = "";
            String fechI = "";
            String fechF = "";
            dtgPagos.ItemsSource = null;
            if (concepto.Equals(""))
                concepto = "0";
            if (ejecutivo.Equals(""))
                ejecutivo = "0";
            if (hotel.Equals(""))
                hotel = "0";
            if (reserva.Equals(""))
                reserva = "0";
            if (contrato.Equals(""))
                contrato = "0";
            if (lstEstatus1.SelectedIndex == 0)
                status = "2";
            else
            {
                if (lstEstatus1.SelectedIndex == 1)
                    status = "1";
                else
                    status = "0";
            }
            if (f == null)
            {
                fechI = "0";
            }
            else
            {
                String[] ini = f.Value.ToShortDateString().Split('/');
                fechI = ini[2] + "/" + ini[1] + "/" + ini[0];
            }
            if (ff == null)
            {
                fechF = "0";
            }
            else
            {
                String[] fin = ff.Value.ToShortDateString().Split('/');
                fechF = fin[2] + "/" + fin[1] + "/" + fin[0];
            }
            cargarPagos(concepto, fechI, status, Convert.ToInt32(reserva), contrato, fechF, hotel, ejecutivo);
        }

        private void lstEstatus1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? f = dpfechaPago.SelectedDate;
            DateTime? ff = dpfechafinPago.SelectedDate;
            string concepto = "";
            string ejecutivo = "";
            string hotel = "";
            if (lstCargos1.SelectedItem != null)
                concepto = lstCargos1.SelectedItem.ToString();
            if (lstEjecutivo.SelectedItem != null)
                ejecutivo = lstEjecutivo.SelectedItem.ToString();
            if (lstHotel.SelectedItem != null)
                hotel = lstHotel.SelectedItem.ToString();
            string reserva = txtNroReservaCobros.Text;
            string contrato = txtNroContratoCobros.Text;
            string status = "";
            String fechI = "";
            String fechF = "";
            dtgPagos.ItemsSource = null;

            if (concepto.Equals(""))
                concepto = "0";
            if (ejecutivo.Equals(""))
                ejecutivo = "0";
            if (hotel.Equals(""))
                hotel = "0";
            if (reserva.Equals(""))
                reserva = "0";
            if (contrato.Equals(""))
                contrato = "0";
            if (lstEstatus1.SelectedIndex == 0)
                status = "2";
            else
            {
                if (lstEstatus1.SelectedIndex == 1)
                    status = "1";
                else
                    status = "0";
            }
            if (f == null)
            {
                fechI = "0";
            }
            else
            {
                String[] ini = f.Value.ToShortDateString().Split('/');
                fechI = ini[2] + "/" + ini[1] + "/" + ini[0];
            }
            if (ff == null)
            {
                fechF = "0";
            }
            else
            {
                String[] fin = ff.Value.ToShortDateString().Split('/');
                fechF = fin[2] + "/" + fin[1] + "/" + fin[0];
            }
            cargarPagos(concepto, fechI, status, Convert.ToInt32(reserva), contrato, fechF, hotel, ejecutivo);
        }

        private void txtNroReservaReporte_KeyUp(object sender, KeyEventArgs e)
        {
            if (!txtNroReservaReporte.Text.Equals(""))
            {
                DateTime? f = dpfechaReporte.SelectedDate;
                DateTime? ff = dpfechaReportefin.SelectedDate;
                reservacion res = new reservacion();
                if (txtClienteReporte.Text.Equals("") && f == null && txtNroContratoReporte.Text.Equals("") && lstEstatus.SelectedIndex == 0 && ff == null)
                {
                    dtgReservasReporte.ItemsSource = res.reporte_reserva(Convert.ToInt32(txtNroReservaReporte.Text), "0", "0", 0, "0", "0");
                    gRreserva = Convert.ToInt32(txtNroReservaReporte.Text);
                    gRcliente = "0";
                    gRcontrato = "0";
                    gRstatus = "0";
                    gRfecha = "0";
                    gRfechaf = "0";
                }
                else
                {
                    if (!txtClienteReporte.Text.Equals("") && f == null && txtNroContratoReporte.Text.Equals("") && lstEstatus.SelectedIndex == 0 && ff == null)
                    {
                        dtgReservasReporte.ItemsSource = res.reporte_reserva(Convert.ToInt32(txtNroReservaReporte.Text), txtClienteReporte.Text, "0", 0, "0", "0");
                        gRreserva = Convert.ToInt32(txtNroReservaReporte.Text);
                        gRcliente = txtClienteReporte.Text;
                        gRcontrato = "0";
                        gRstatus = "0";
                        gRfecha = "0";
                        gRfechaf = "0";
                    }
                    else
                    {
                        if (!txtClienteReporte.Text.Equals("") && f == null && !txtNroContratoReporte.Text.Equals("") && lstEstatus.SelectedIndex == 0 && ff == null)
                        {
                            dtgReservasReporte.ItemsSource = res.reporte_reserva(Convert.ToInt32(txtNroReservaReporte.Text), txtClienteReporte.Text, "0", Convert.ToInt32(txtNroContratoReporte.Text), "0", "0");
                            gRreserva = Convert.ToInt32(txtNroReservaReporte.Text);
                            gRcliente = txtClienteReporte.Text;
                            gRcontrato = txtNroContratoReporte.Text;
                            gRstatus = "0";
                            gRfecha = "0";
                            gRfechaf = "0";
                        }
                        else
                        {
                            if (!txtClienteReporte.Text.Equals("") && f == null && !txtNroContratoReporte.Text.Equals("") && lstEstatus.SelectedIndex != 0 && ff == null)
                            {
                                dtgReservasReporte.ItemsSource = res.reporte_reserva(Convert.ToInt32(txtNroReservaReporte.Text), txtClienteReporte.Text, "0", Convert.ToInt32(txtNroContratoReporte.Text), lstEstatus.SelectedValue.ToString(), "0");
                                gRreserva = Convert.ToInt32(txtNroReservaReporte.Text);
                                gRcliente = txtClienteReporte.Text;
                                gRcontrato = txtNroContratoReporte.Text;
                                gRstatus = lstEstatus.SelectedValue.ToString();
                                gRfecha = "0";
                                gRfechaf = "0";
                            }
                            else
                            {
                                if (!txtClienteReporte.Text.Equals("") && f != null && !txtNroContratoReporte.Text.Equals("") && lstEstatus.SelectedIndex != 0 && ff == null)
                                {
                                    String[] ini = f.Value.ToShortDateString().Split('/');
                                    String fechI = ini[2] + "/" + ini[1] + "/" + ini[0];
                                    dtgReservasReporte.ItemsSource = res.reporte_reserva(Convert.ToInt32(txtNroReservaReporte.Text), txtClienteReporte.Text, fechI, Convert.ToInt32(txtNroContratoReporte.Text), lstEstatus.SelectedValue.ToString(), "0");
                                    gRreserva = Convert.ToInt32(txtNroReservaReporte.Text);
                                    gRcliente = txtClienteReporte.Text;
                                    gRcontrato = txtNroContratoReporte.Text;
                                    gRstatus = lstEstatus.SelectedValue.ToString();
                                    gRfecha = fechI;
                                    gRfechaf = "0";
                                }
                                else
                                {
                                    if (!txtClienteReporte.Text.Equals("") && f != null && !txtNroContratoReporte.Text.Equals("") && lstEstatus.SelectedIndex != 0 && ff != null)
                                    {
                                        String[] ini = f.Value.ToShortDateString().Split('/');
                                        String fechI = ini[2] + "/" + ini[1] + "/" + ini[0];
                                        String[] fin = ff.Value.ToShortDateString().Split('/');
                                        String fechF = fin[2] + "/" + fin[1] + "/" + fin[0];
                                        dtgReservasReporte.ItemsSource = res.reporte_reserva(Convert.ToInt32(txtNroReservaReporte.Text), txtClienteReporte.Text, fechI, Convert.ToInt32(txtNroContratoReporte.Text), lstEstatus.SelectedValue.ToString(), fechF);
                                        gRreserva = Convert.ToInt32(txtNroReservaReporte.Text);
                                        gRcliente = txtClienteReporte.Text;
                                        gRcontrato = txtNroContratoReporte.Text;
                                        gRstatus = lstEstatus.SelectedValue.ToString();
                                        gRfecha = fechI;
                                        gRfechaf = fechF;
                                    }
                                }
                            }
                        }

                    }

                }
            }

        }

        private void txtClienteReporte_KeyUp(object sender, KeyEventArgs e)
        {
            if (!txtClienteReporte.Text.Equals(""))
            {
                DateTime? f = dpfechaReporte.SelectedDate;
                DateTime? ff = dpfechaReportefin.SelectedDate;
                reservacion res = new reservacion();
                if (txtNroReservaReporte.Text.Equals("") && f == null && txtNroContratoReporte.Text.Equals("") && lstEstatus.SelectedIndex == 0 && ff == null)
                {
                    dtgReservasReporte.ItemsSource = res.reporte_reserva(0, txtClienteReporte.Text, "0", 0, "0", "0");
                    gRreserva = 0;
                    gRcliente = txtClienteReporte.Text;
                    gRcontrato = "0";
                    gRstatus = "0";
                    gRfecha = "0";
                    gRfechaf = "0";
                }
                else
                {
                    if (!txtNroReservaReporte.Text.Equals("") && f == null && txtNroContratoReporte.Text.Equals("") && lstEstatus.SelectedIndex == 0 && ff == null)
                    {
                        dtgReservasReporte.ItemsSource = res.reporte_reserva(Convert.ToInt32(txtNroReservaReporte.Text), txtClienteReporte.Text, "0", 0, "0", "0");
                        gRreserva = Convert.ToInt32(txtNroReservaReporte.Text);
                        gRcliente = txtClienteReporte.Text;
                        gRcontrato = "0";
                        gRstatus = "0";
                        gRfecha = "0";
                        gRfechaf = "0";
                    }
                    else
                    {
                        if (!txtNroReservaReporte.Text.Equals("") && f == null && !txtNroContratoReporte.Text.Equals("") && lstEstatus.SelectedIndex == 0 && ff == null)
                        {
                            dtgReservasReporte.ItemsSource = res.reporte_reserva(Convert.ToInt32(txtNroReservaReporte.Text), txtClienteReporte.Text, "0", Convert.ToInt32(txtNroContratoReporte.Text), "0", "0");
                            gRreserva = Convert.ToInt32(txtNroReservaReporte.Text);
                            gRcliente = txtClienteReporte.Text;
                            gRcontrato = txtNroContratoReporte.Text;
                            gRstatus = "0";
                            gRfecha = "0";
                            gRfechaf = "0";
                        }
                        else
                        {
                            if (!txtNroReservaReporte.Text.Equals("") && f == null && !txtNroContratoReporte.Text.Equals("") && lstEstatus.SelectedIndex != 0 && ff == null)
                            {
                                dtgReservasReporte.ItemsSource = res.reporte_reserva(Convert.ToInt32(txtNroReservaReporte.Text), txtClienteReporte.Text, "0", Convert.ToInt32(txtNroContratoReporte.Text), lstEstatus.SelectedValue.ToString(), "0");
                                gRreserva = Convert.ToInt32(txtNroReservaReporte.Text);
                                gRcliente = txtClienteReporte.Text;
                                gRcontrato = txtNroContratoReporte.Text;
                                gRstatus = lstEstatus.SelectedValue.ToString();
                                gRfecha = "0";
                                gRfechaf = "0";
                            }
                            else
                            {
                                if (!txtNroReservaReporte.Text.Equals("") && f != null && !txtNroContratoReporte.Text.Equals("") && lstEstatus.SelectedIndex != 0 && ff == null)
                                {
                                    String[] ini = f.Value.ToShortDateString().Split('/');
                                    String fechI = ini[2] + "/" + ini[1] + "/" + ini[0];
                                    dtgReservasReporte.ItemsSource = res.reporte_reserva(Convert.ToInt32(txtNroReservaReporte.Text), txtClienteReporte.Text, fechI, Convert.ToInt32(txtNroContratoReporte.Text), lstEstatus.SelectedValue.ToString(), "0");
                                    gRreserva = Convert.ToInt32(txtNroReservaReporte.Text);
                                    gRcliente = txtClienteReporte.Text;
                                    gRcontrato = txtNroContratoReporte.Text;
                                    gRstatus = lstEstatus.SelectedValue.ToString();
                                    gRfecha = fechI;
                                    gRfechaf = "0";
                                }
                                else
                                {
                                    if (!txtNroReservaReporte.Text.Equals("") && f != null && !txtNroContratoReporte.Text.Equals("") && lstEstatus.SelectedIndex != 0 && ff == null)
                                    {
                                        String[] ini = f.Value.ToShortDateString().Split('/');
                                        String fechI = ini[2] + "/" + ini[1] + "/" + ini[0];
                                        String[] fin = ff.Value.ToShortDateString().Split('/');
                                        String fechF = fin[2] + "/" + fin[1] + "/" + fin[0];
                                        dtgReservasReporte.ItemsSource = res.reporte_reserva(Convert.ToInt32(txtNroReservaReporte.Text), txtClienteReporte.Text, fechI, Convert.ToInt32(txtNroContratoReporte.Text), lstEstatus.SelectedValue.ToString(), fechF);
                                        gRreserva = Convert.ToInt32(txtNroReservaReporte.Text);
                                        gRcliente = txtClienteReporte.Text;
                                        gRcontrato = txtNroContratoReporte.Text;
                                        gRstatus = lstEstatus.SelectedValue.ToString();
                                        gRfecha = fechI;
                                        gRfechaf = fechF;
                                    }
                                }
                            }
                        }

                    }

                }
            }
        }

        private void txtNroContratoReporte_KeyUp(object sender, KeyEventArgs e)
        {
            if (!txtNroContratoReporte.Text.Equals(""))
            {
                DateTime? f = dpfechaReporte.SelectedDate;
                DateTime? ff = dpfechaReporte.SelectedDate;
                reservacion res = new reservacion();
                if (txtNroReservaReporte.Text.Equals("") && f == null && txtClienteReporte.Text.Equals("") && lstEstatus.SelectedIndex == 0 && ff == null)
                {
                    dtgReservasReporte.ItemsSource = res.reporte_reserva(0, "0", "0", Convert.ToInt32(txtNroContratoReporte.Text), "0", "0");
                    gRreserva = 0;
                    gRcliente = "0";
                    gRcontrato = txtNroContratoReporte.Text;
                    gRstatus = "0";
                    gRfecha = "0";
                    gRfechaf = "0";
                }
                else
                {
                    if (!txtNroReservaReporte.Text.Equals("") && f == null && txtClienteReporte.Text.Equals("") && lstEstatus.SelectedIndex == 0 && ff == null)
                    {
                        dtgReservasReporte.ItemsSource = res.reporte_reserva(Convert.ToInt32(txtNroReservaReporte.Text), "0", "0", Convert.ToInt32(txtNroContratoReporte.Text), "0", "0");
                        gRreserva = Convert.ToInt32(txtNroReservaReporte.Text);
                        gRcliente = "0";
                        gRcontrato = txtNroContratoReporte.Text;
                        gRstatus = "0";
                        gRfecha = "0";
                        gRfechaf = "0";
                    }
                    else
                    {
                        if (!txtNroReservaReporte.Text.Equals("") && f == null && !txtClienteReporte.Text.Equals("") && lstEstatus.SelectedIndex == 0 && ff == null)
                        {
                            dtgReservasReporte.ItemsSource = res.reporte_reserva(Convert.ToInt32(txtNroReservaReporte.Text), txtClienteReporte.Text, "0", Convert.ToInt32(txtNroContratoReporte.Text), "0", "0");
                            gRreserva = Convert.ToInt32(txtNroReservaReporte.Text);
                            gRcliente = txtClienteReporte.Text;
                            gRcontrato = txtNroContratoReporte.Text;
                            gRstatus = "0";
                            gRfecha = "0";
                            gRfechaf = "0";
                        }
                        else
                        {
                            if (!txtNroReservaReporte.Text.Equals("") && f == null && !txtClienteReporte.Text.Equals("") && lstEstatus.SelectedIndex != 0 && ff == null)
                            {
                                dtgReservasReporte.ItemsSource = res.reporte_reserva(Convert.ToInt32(txtNroReservaReporte.Text), txtClienteReporte.Text, "0", Convert.ToInt32(txtNroContratoReporte.Text), lstEstatus.SelectedValue.ToString(), "0");
                                gRreserva = Convert.ToInt32(txtNroReservaReporte.Text);
                                gRcliente = txtClienteReporte.Text;
                                gRcontrato = txtNroContratoReporte.Text;
                                gRstatus = lstEstatus.SelectedValue.ToString();
                                gRfecha = "0";
                                gRfechaf = "0";
                            }
                            else
                            {
                                if (!txtNroReservaReporte.Text.Equals("") && f != null && !txtClienteReporte.Text.Equals("") && lstEstatus.SelectedIndex != 0 && ff == null)
                                {
                                    String[] ini = f.Value.ToShortDateString().Split('/');
                                    String fechI = ini[2] + "/" + ini[1] + "/" + ini[0];
                                    dtgReservasReporte.ItemsSource = res.reporte_reserva(Convert.ToInt32(txtNroReservaReporte.Text), txtClienteReporte.Text, fechI, Convert.ToInt32(txtNroContratoReporte.Text), lstEstatus.SelectedValue.ToString(), "0");
                                    gRreserva = Convert.ToInt32(txtNroReservaReporte.Text);
                                    gRcliente = txtClienteReporte.Text;
                                    gRcontrato = txtNroContratoReporte.Text;
                                    gRstatus = lstEstatus.SelectedValue.ToString();
                                    gRfecha = fechI;
                                    gRfechaf = "0";
                                }
                                else
                                {
                                    if (!txtNroReservaReporte.Text.Equals("") && f != null && !txtClienteReporte.Text.Equals("") && lstEstatus.SelectedIndex != 0 && ff != null)
                                    {
                                        String[] ini = f.Value.ToShortDateString().Split('/');
                                        String fechI = ini[2] + "/" + ini[1] + "/" + ini[0];
                                        String[] fin = ff.Value.ToShortDateString().Split('/');
                                        String fechF = fin[2] + "/" + fin[1] + "/" + fin[0];
                                        dtgReservasReporte.ItemsSource = res.reporte_reserva(Convert.ToInt32(txtNroReservaReporte.Text), txtClienteReporte.Text, fechI, Convert.ToInt32(txtNroContratoReporte.Text), lstEstatus.SelectedValue.ToString(), fechF);
                                        gRreserva = Convert.ToInt32(txtNroReservaReporte.Text);
                                        gRcliente = txtClienteReporte.Text;
                                        gRcontrato = txtNroContratoReporte.Text;
                                        gRstatus = lstEstatus.SelectedValue.ToString();
                                        gRfecha = fechI;
                                        gRfechaf = fechI;
                                    }
                                }
                            }
                        }

                    }

                }
            }
        }

        private void dpfechaReporte_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? f = dpfechaReporte.SelectedDate;
            if (f != null)
            {
                String[] ini = f.Value.ToShortDateString().Split('/');
                String fechI = ini[2] + "/" + ini[1] + "/" + ini[0];
                reservacion res = new reservacion();
                if (txtNroReservaReporte.Text.Equals("") && txtNroContratoReporte.Text.Equals("") && txtClienteReporte.Text.Equals("") && lstEstatus.SelectedIndex == 0 && dpfechaReportefin.SelectedDate == null)
                {
                    dtgReservasReporte.ItemsSource = res.reporte_reserva(0, "0", fechI, 0, "0", "0");
                    gRreserva = 0;
                    gRcliente = "0";
                    gRcontrato = "0";
                    gRstatus = "0";
                    gRfecha = fechI;
                    gRfechaf = "0";
                }
                else
                {
                    if (!txtNroReservaReporte.Text.Equals("") && txtNroContratoReporte.Text.Equals("") && txtClienteReporte.Text.Equals("") && lstEstatus.SelectedIndex == 0 && dpfechaReportefin.SelectedDate == null)
                    {
                        dtgReservasReporte.ItemsSource = res.reporte_reserva(Convert.ToInt32(txtNroReservaReporte.Text), "0", fechI, 0, "0", "0");
                        gRreserva = Convert.ToInt32(txtNroReservaReporte.Text);
                        gRcliente = "0";
                        gRcontrato = "0";
                        gRstatus = "0";
                        gRfecha = fechI;
                        gRfechaf = "0";
                    }
                    else
                    {
                        if (!txtNroReservaReporte.Text.Equals("") && !txtNroContratoReporte.Text.Equals("") && txtClienteReporte.Text.Equals("") && lstEstatus.SelectedIndex == 0 && dpfechaReportefin.SelectedDate == null)
                        {
                            dtgReservasReporte.ItemsSource = res.reporte_reserva(Convert.ToInt32(txtNroReservaReporte.Text), "0", fechI, Convert.ToInt32(txtNroContratoReporte.Text), "0", "0");
                            gRreserva = Convert.ToInt32(txtNroReservaReporte.Text);
                            gRcliente = "0";
                            gRcontrato = txtNroContratoReporte.Text;
                            gRstatus = "0";
                            gRfecha = fechI;
                            gRfechaf = "0";
                        }
                        else
                        {
                            if (!txtNroReservaReporte.Text.Equals("") && !txtNroContratoReporte.Text.Equals("") && !txtClienteReporte.Text.Equals("") && lstEstatus.SelectedIndex == 0 && dpfechaReportefin.SelectedDate == null)
                            {
                                dtgReservasReporte.ItemsSource = res.reporte_reserva(Convert.ToInt32(txtNroReservaReporte.Text), txtClienteReporte.Text, fechI, Convert.ToInt32(txtNroContratoReporte.Text), "0", "0");
                                gRreserva = Convert.ToInt32(txtNroReservaReporte.Text);
                                gRcliente = txtClienteReporte.Text;
                                gRcontrato = txtNroContratoReporte.Text;
                                gRstatus = "0";
                                gRfecha = fechI;
                                gRfechaf = "0";
                            }
                            else
                            {
                                if (!txtNroReservaReporte.Text.Equals("") && !txtNroContratoReporte.Text.Equals("") && !txtClienteReporte.Text.Equals("") && lstEstatus.SelectedIndex != 0 && dpfechaReportefin.SelectedDate == null)
                                {
                                    dtgReservasReporte.ItemsSource = res.reporte_reserva(Convert.ToInt32(txtNroReservaReporte.Text), txtClienteReporte.Text, fechI, Convert.ToInt32(txtNroContratoReporte.Text), lstEstatus.SelectedValue.ToString(), "0");
                                    gRreserva = Convert.ToInt32(txtNroReservaReporte.Text);
                                    gRcliente = txtClienteReporte.Text;
                                    gRcontrato = txtNroContratoReporte.Text;
                                    gRstatus = lstEstatus.SelectedValue.ToString();
                                    gRfecha = fechI;
                                    gRfechaf = "0";
                                }
                                else
                                {
                                    DateTime? ff = dpfechaReportefin.SelectedDate;
                                    if (ff != null)
                                    {
                                        String[] fin = ff.Value.ToShortDateString().Split('/');
                                        String fechF = fin[2] + "/" + fin[1] + "/" + fin[0];
                                        dtgReservasReporte.ItemsSource = res.reporte_reserva(0, "0", fechI, 0, "0", fechF);
                                        gRreserva = 0;
                                        gRcliente = "0";
                                        gRcontrato = "0";
                                        gRstatus = "0";
                                        gRfecha = fechI;
                                        gRfechaf = fechF;
                                    }
                                }
                            }
                        }
                    }

                }

            }
        }

        private void lstEstatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dtgReservasReporte.ItemsSource = null;
            if (lstEstatus.SelectedIndex != 0)
            {
                DateTime? f = dpfechaReporte.SelectedDate;
                DateTime? ff = dpfechaReporte.SelectedDate;
                reservacion res = new reservacion();
                if (txtNroReservaReporte.Text.Equals("") && f == null && txtClienteReporte.Text.Equals("") && txtNroContratoReporte.Text.Equals("") && ff == null)
                {
                    dtgReservasReporte.ItemsSource = res.reporte_reserva(0, "0", "0", 0, lstEstatus.SelectedItem.ToString(), "0");
                    gRreserva = 0;
                    gRcliente = "0";
                    gRcontrato = "0";
                    gRstatus = lstEstatus.SelectedItem.ToString();
                    gRfecha = "0";
                    gRfechaf = "0";
                }
                else
                {
                    if (!txtNroReservaReporte.Text.Equals("") && f == null && txtClienteReporte.Text.Equals("") && txtNroContratoReporte.Text.Equals("") && ff == null)
                    {
                        dtgReservasReporte.ItemsSource = res.reporte_reserva(Convert.ToInt32(txtNroReservaReporte.Text), "0", "0", 0, lstEstatus.SelectedItem.ToString(), "0");
                        gRreserva = Convert.ToInt32(txtNroReservaReporte.Text);
                        gRcliente = "0";
                        gRcontrato = "0";
                        gRstatus = lstEstatus.SelectedItem.ToString();
                        gRfecha = "0";
                        gRfechaf = "0";
                    }
                    else
                    {
                        if (!txtNroReservaReporte.Text.Equals("") && f == null && !txtClienteReporte.Text.Equals("") && txtNroContratoReporte.Text.Equals("") && ff == null)
                        {
                            dtgReservasReporte.ItemsSource = res.reporte_reserva(Convert.ToInt32(txtNroReservaReporte.Text), txtClienteReporte.Text, "0", 0, lstEstatus.SelectedItem.ToString(), "0");
                            gRreserva = Convert.ToInt32(txtNroReservaReporte.Text);
                            gRcliente = txtClienteReporte.Text;
                            gRcontrato = "0";
                            gRstatus = lstEstatus.SelectedItem.ToString();
                            gRfecha = "0";
                            gRfechaf = "0";
                        }
                        else
                        {
                            if (!txtNroReservaReporte.Text.Equals("") && f == null && !txtClienteReporte.Text.Equals("") && !txtNroContratoReporte.Text.Equals("") && ff == null)
                            {
                                dtgReservasReporte.ItemsSource = res.reporte_reserva(Convert.ToInt32(txtNroReservaReporte.Text), txtClienteReporte.Text, "0", Convert.ToInt32(txtNroContratoReporte.Text), lstEstatus.SelectedItem.ToString(), "0");
                                gRreserva = Convert.ToInt32(txtNroReservaReporte.Text);
                                gRcliente = txtClienteReporte.Text;
                                gRcontrato = txtNroContratoReporte.Text;
                                gRstatus = lstEstatus.SelectedItem.ToString();
                                gRfecha = "0";
                                gRfechaf = "0";
                            }
                            else
                            {
                                if (!txtNroReservaReporte.Text.Equals("") && f != null && !txtClienteReporte.Text.Equals("") && !txtNroContratoReporte.Text.Equals("") && ff == null)
                                {
                                    String[] ini = f.Value.ToShortDateString().Split('/');
                                    String fechI = ini[2] + "/" + ini[1] + "/" + ini[0];
                                    dtgReservasReporte.ItemsSource = res.reporte_reserva(Convert.ToInt32(txtNroReservaReporte.Text), txtClienteReporte.Text, fechI, Convert.ToInt32(txtNroContratoReporte.Text), lstEstatus.SelectedItem.ToString(), "0");
                                    gRreserva = Convert.ToInt32(txtNroReservaReporte.Text);
                                    gRcliente = txtClienteReporte.Text;
                                    gRcontrato = txtNroContratoReporte.Text;
                                    gRstatus = lstEstatus.SelectedItem.ToString();
                                    gRfecha = fechI;
                                    gRfechaf = "0";
                                }
                                else
                                {
                                    if (!txtNroReservaReporte.Text.Equals("") && f != null && !txtClienteReporte.Text.Equals("") && !txtNroContratoReporte.Text.Equals("") && ff != null)
                                    {

                                        String[] ini = f.Value.ToShortDateString().Split('/');
                                        String fechI = ini[2] + "/" + ini[1] + "/" + ini[0];
                                        String[] fin = ff.Value.ToShortDateString().Split('/');
                                        String fechF = fin[2] + "/" + fin[1] + "/" + fin[0];
                                        dtgReservasReporte.ItemsSource = res.reporte_reserva(Convert.ToInt32(txtNroReservaReporte.Text), txtClienteReporte.Text, fechI, Convert.ToInt32(txtNroContratoReporte.Text), lstEstatus.SelectedValue.ToString(), fechF);
                                        gRreserva = Convert.ToInt32(txtNroReservaReporte.Text);
                                        gRcliente = txtClienteReporte.Text;
                                        gRcontrato = txtNroContratoReporte.Text;
                                        gRstatus = lstEstatus.SelectedItem.ToString();
                                        gRfecha = fechI;
                                        gRfechaf = fechF;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void txtNroReserva1_KeyUp(object sender, KeyEventArgs e)
        {
            DateTime? f = dpfecha1.SelectedDate;
            DateTime? ff = dpfin1.SelectedDate;
            reservacion res = new reservacion();
            if ((txtCliente1.Text.Equals("")) && (txtNroContrato1.Text.Equals("")) && (f == null) && (ff == null))
                dtgReservas1.ItemsSource = res.buscar_reservaConfir(txtNroReserva1.Text, "0", "", "0","");
            else
            {

                if ((!txtCliente1.Text.Equals("")) && (txtNroContrato1.Text.Equals("")) && (f == null) && (ff == null))
                    dtgReservas1.ItemsSource = res.buscar_reservaConfir(txtNroReserva1.Text, txtCliente1.Text, "", "0","");
                else
                {
                    if ((!txtCliente1.Text.Equals("")) && (!txtNroContrato1.Text.Equals("")) && (f == null) && (ff == null))
                        dtgReservas1.ItemsSource = res.buscar_reservaConfir(txtNroReserva1.Text, txtCliente1.Text, "", txtNroContrato1.Text,"");
                    else
                    {
                        if ((!txtCliente1.Text.Equals("")) && (!txtNroContrato1.Text.Equals("")) && (f != null) && (ff == null))
                        {
                            String[] ini = f.Value.ToShortDateString().Split('/');
                            String fechI = ini[2] + "/" + ini[1] + "/" + ini[0];
                            dtgReservas1.ItemsSource = res.buscar_reservaConfir(txtNroReserva1.Text, txtCliente1.Text, fechI, txtNroContrato1.Text,"");
                        }
                        else
                        {
                            if ((!txtCliente1.Text.Equals("")) && (!txtNroContrato1.Text.Equals("")) && (f != null) && (ff != null))
                            {
                                String[] ini = f.Value.ToShortDateString().Split('/');
                                String fechI = ini[2] + "/" + ini[1] + "/" + ini[0];
                                String[] fin = ff.Value.ToShortDateString().Split('/');
                                String fechF = fin[2] + "/" + fin[1] + "/" + fin[0];
                                dtgReservas1.ItemsSource = res.buscar_reservaConfir(txtNroReserva1.Text, txtCliente1.Text, fechI, txtNroContrato1.Text, fechF);
                            }
                            
                        }

                    }
                }
            }
        }

        private void txtCliente1_KeyUp(object sender, KeyEventArgs e)
        {
            DateTime? f = dpfecha1.SelectedDate;
            DateTime? ff = dpfin1.SelectedDate;
            reservacion res = new reservacion();
            if ((txtNroReserva1.Text.Equals("")) && (txtNroContrato1.Text.Equals("")) && (f == null) && (ff == null))
                dtgReservas1.ItemsSource = res.buscar_reservaConfir("0", txtCliente1.Text, "", "0","");
            else
            {

                if ((!txtNroReserva1.Text.Equals("")) && (txtNroContrato1.Text.Equals("")) && (f == null) && (ff == null))
                    dtgReservas1.ItemsSource = res.buscar_reservaConfir(txtNroReserva1.Text, txtCliente1.Text, "", "0","");
                else
                {
                    if ((!txtNroReserva1.Text.Equals("")) && (!txtNroContrato1.Text.Equals("")) && (f == null) && (ff == null))
                        dtgReservas1.ItemsSource = res.buscar_reservaConfir(txtNroReserva1.Text, txtCliente1.Text, "", txtNroContrato1.Text,"");
                    else
                    {
                        if ((!txtNroReserva1.Text.Equals("")) && (!txtNroContrato1.Text.Equals("")) && (f != null) && (ff == null))
                        {
                            String[] ini = f.Value.ToShortDateString().Split('/');
                            String fechI = ini[2] + "/" + ini[1] + "/" + ini[0];
                            dtgReservas1.ItemsSource = res.buscar_reservaConfir(txtNroReserva1.Text, txtCliente1.Text, fechI, txtNroContrato1.Text,"");
                        }

                    }
                }
            }
        }

        private void dpfecha1_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? f = dpfecha1.SelectedDate;
            DateTime? ff = dpfecha1.SelectedDate;
            if (f != null)
            {
                String[] ini = f.Value.ToShortDateString().Split('/');
                String fechI = ini[2] + "/" + ini[1] + "/" + ini[0];
                reservacion res = new reservacion();
                if ((txtCliente1.Text.Equals("")) && (txtNroReserva1.Text.Equals("")) && (txtNroContrato1.Text.Equals("")) && (ff == null))
                    dtgReservas1.ItemsSource = res.buscar_reservaConfir("0", "0", fechI, "0","");
                else
                {
                    _reportViewer.Clear();
                    if ((!txtCliente1.Text.Equals("")) && (txtNroReserva1.Text.Equals("")) && (txtNroContrato1.Text.Equals("")) && (ff == null))
                        dtgReservas1.ItemsSource = res.buscar_reservaConfir("0", txtCliente1.Text, fechI, "0","");
                    else
                    {
                        if ((!txtCliente1.Text.Equals("")) && (!txtNroReserva1.Text.Equals("")) && (txtNroContrato1.Text.Equals("")) && (ff == null))
                            dtgReservas1.ItemsSource = res.buscar_reservaConfir(txtNroReserva1.Text, txtCliente1.Text, fechI, "0","");
                        else
                        {
                            if ((!txtCliente1.Text.Equals("")) && (!txtNroReserva1.Text.Equals("")) && (!txtNroContrato1.Text.Equals("")) && (ff == null))
                            {

                                dtgReservas1.ItemsSource = res.buscar_reservaConfir(txtNroReserva1.Text, txtCliente1.Text, fechI, txtNroContrato1.Text,"");
                            }
                            else
                            {
                                if ((txtCliente1.Text.Equals("")) && (txtNroReserva1.Text.Equals("")) && (txtNroContrato1.Text.Equals("")) && (ff != null))
                                {
                                    String[] fin = ff.Value.ToShortDateString().Split('/');
                                    String fechF = fin[2] + "/" + fin[1] + "/" + fin[0];
                                    dtgReservas1.ItemsSource = res.buscar_reservaConfir("0", "0", fechI, "0",fechF);
                                }
                            }

                        }
                    }
                }
            }
        }

        private void txtNroContrato1_KeyUp(object sender, KeyEventArgs e)
        {
            DateTime? f = dpfecha1.SelectedDate;
            DateTime? ff = dpfecha1.SelectedDate;
            reservacion res = new reservacion();
            if ((txtCliente1.Text.Equals("")) && (txtNroReserva1.Text.Equals("")) && (f == null) && (ff == null))
                dtgReservas1.ItemsSource = res.buscar_reservaConfir("0", "0", "", txtNroContrato1.Text,"");
            else
            {
                _reportViewer.Clear();
                if ((!txtCliente1.Text.Equals("")) && (txtNroReserva1.Text.Equals("")) && (f == null) && (ff == null))
                    dtgReservas1.ItemsSource = res.buscar_reservaConfir("0", txtCliente1.Text, "", txtNroContrato1.Text,"");
                else
                {
                    if ((!txtCliente1.Text.Equals("")) && (!txtNroReserva1.Text.Equals("")) && (f == null) && (ff == null))
                        dtgReservas1.ItemsSource = res.buscar_reservaConfir(txtNroReserva1.Text, txtCliente1.Text, "", txtNroContrato1.Text,"");
                    else
                    {
                        if ((!txtCliente1.Text.Equals("")) && (!txtNroReserva1.Text.Equals("")) && (f != null) && (ff == null))
                        {
                            String[] ini = f.Value.ToShortDateString().Split('/');
                            String fechI = ini[2] + "/" + ini[1] + "/" + ini[0];
                            dtgReservas1.ItemsSource = res.buscar_reservaConfir(txtNroReserva1.Text, txtCliente1.Text, fechI, txtNroContrato1.Text,"");
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
                _reportViewer1.Clear();
                _ConfirmacionIC.Clear();
                _ConfirmacionPB.Clear();
                _ConfirmacionID.Clear();
                _ConfirmacionCA.Clear();
                numeroReserva = Convert.ToInt32((dtgReservas1.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
                contrato = (dtgReservas1.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                estadoCuenta ed = new estadoCuenta();
                ed.contrato = contrato;
                ed.Show();
                dt = new DataTable();
                reservacion reserva = new reservacion();
                dt.Load(reserva.buscarHabitacion(numeroReserva));
                int CB = 0, ID = 0, IC = 0, CPB = 0,CA=0;
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    switch (dt.Rows[i][0].ToString())
                    {
                        case "PLAYA EL AGUA":
                            if (CB == 0)
                            {
                                fech1CB = Convert.ToDateTime(dt.Rows[i][7].ToString()).ToShortDateString();
                                CB++;
                            }
                            if (Convert.ToDateTime(fech1CB).CompareTo(Convert.ToDateTime(dt.Rows[i][7].ToString())) != 0)
                                fech2CB = Convert.ToDateTime(dt.Rows[i][7].ToString()).ToShortDateString();
                            else
                                fech2CB = "";
                            btnImprimirCB.IsEnabled = true;
                            tbCB.IsEnabled = true;
                            break;
                        case "INTERNATIONAL DRIVE":
                             if (ID == 0)
                            {
                                fech1ID = Convert.ToDateTime(dt.Rows[i][7].ToString()).ToShortDateString();
                                ID++;
                            }
                             if (Convert.ToDateTime(fech1ID).CompareTo(Convert.ToDateTime(dt.Rows[i][7].ToString())) != 0)
                                 fech2ID = Convert.ToDateTime(dt.Rows[i][7].ToString()).ToShortDateString();
                            else
                                 fech2ID = "";
                            btnImprimirID.IsEnabled = true;
                            tbID.IsEnabled = true;
                            break;
                        case "ISLA CARIBE":
                             if (IC == 0)
                            {
                                fech1IC = Convert.ToDateTime(dt.Rows[i][7].ToString()).ToShortDateString();
                                fechF1IC = Convert.ToDateTime(dt.Rows[i][8].ToString()).AddDays(-1).ToShortDateString();
                                IC++;
                            }
                             if (Convert.ToDateTime(fech1IC).CompareTo(Convert.ToDateTime(dt.Rows[i][7].ToString())) != 0)
                             {
                                 fech2IC = Convert.ToDateTime(dt.Rows[i][7].ToString()).ToShortDateString();
                                 fechF2IC = Convert.ToDateTime(dt.Rows[i][8].ToString()).AddDays(-1).ToShortDateString();
                             }
                             else
                             {
                                 fech2IC = "";
                                 fechF2IC = "";
                             }
                            btnImprimirIC.IsEnabled = true;
                            tbIC.IsEnabled = true;
                            break;
                        case "COCHE PUNTA BLANCA":
                             if (CPB == 0)
                            {
                                fech1CPB = Convert.ToDateTime(dt.Rows[i][7].ToString()).ToShortDateString();
                                fechF1CPB = Convert.ToDateTime(dt.Rows[i][8].ToString()).AddDays(-1).ToShortDateString();
                                CPB++;
                            }
                             if (Convert.ToDateTime(fech1CPB).CompareTo(Convert.ToDateTime(dt.Rows[i][7].ToString())) != 0)
                             {
                                 fech2CPB = Convert.ToDateTime(dt.Rows[i][7].ToString()).ToShortDateString();
                                 fechF2CPB = Convert.ToDateTime(dt.Rows[i][8].ToString()).AddDays(-1).ToShortDateString();
                             }
                             else
                             {
                                 fech2CPB = "";
                                 fechF2CPB = "";
                             }
                            btnImprimirPB.IsEnabled = true;
                            tbCPB.IsEnabled = true;
                            break;
                        case "COSTA AZUL":
                            if (CA == 0)
                            {
                                fechaI1CA = Convert.ToDateTime(dt.Rows[i][7].ToString()).ToShortDateString();
                                CA++;
                            }
                            if (Convert.ToDateTime(fechaI1CA).CompareTo(Convert.ToDateTime(dt.Rows[i][7].ToString())) != 0)
                                fechaF2CA = Convert.ToDateTime(dt.Rows[i][7].ToString()).ToShortDateString();
                            else
                                fechaF2CA = "";
                            btnImprimirCA.IsEnabled = true;
                            tbCA.IsEnabled = true;
                            break;
                    }
                }
            }

        }

        private void mostrarConfirmacionCaribbean()
        {
            dscon.Clear();
            dsconHabi.Clear();
            _reportViewer1.Clear();
            _reportViewer1.Reset();
            String[] fin;
            String fechI2;
            String[] ini = fech1CB.Split('/');
            String fechI = ini[2] + "/" + ini[1] + "/" + ini[0];
            if (!fech2CB.Equals(""))
            {
                fin = fech2CB.Split('/');
                fechI2 = fin[2] + "/" + fin[1] + "/" + fin[0];
            }
            else
            {
                fin = DateTime.Today.ToShortDateString().Split('/');
                fechI2 = fin[2] + "/" + fin[1] + "/" + fin[0];
            }
           
            dscon.BeginInit();
            rdsconfirmacion.Name = "DataSet1";
            rdsconfirmacion.Value = dscon._V_Confirmacion;
            _reportViewer1.LocalReport.DataSources.Add(rdsconfirmacion);
            dscon.EndInit();

            dsconHabi.BeginInit();
            rdshabitacion.Name = "DataSet2";
            rdshabitacion.Value = dsconHabi._V_cotizacionHabitacion;
            _reportViewer1.LocalReport.DataSources.Add(rdshabitacion);
            dsconHabi.EndInit();

            dsPaxloca1.BeginInit();
            rpdsPaxloca1.Name = "DataSet3";
            rpdsPaxloca1.Value = dsPaxloca1._sp_ConcaLocalizador;
            _reportViewer1.LocalReport.DataSources.Add(rpdsPaxloca1);
            dsPaxloca1.EndInit();

            dsPaxloca2.BeginInit();
            rpdsPaxloca2.Name = "DataSet4";
            rpdsPaxloca2.Value = dsPaxloca2._sp_ConcaLocalizador;
            _reportViewer1.LocalReport.DataSources.Add(rpdsPaxloca2);
            dsPaxloca2.EndInit();

            dsConceptos.BeginInit();
            rpdsConceptos.Name = "DataSet5";
            rpdsConceptos.Value = dsConceptos._ConceptoCotizacion;
            _reportViewer1.LocalReport.DataSources.Add(rpdsConceptos);
            dsConceptos.EndInit();

            dsConfirmacionTableAdapters._V_ConfirmacionTableAdapter tc = new dsConfirmacionTableAdapters._V_ConfirmacionTableAdapter();
            tc.ClearBeforeFill = true;
            tc.Fill(dscon._V_Confirmacion, numeroReserva, "PLAYA EL AGUA");
            dsConfirmacionHabitacionTableAdapters._V_cotizacionHabitacionTableAdapter tH = new dsConfirmacionHabitacionTableAdapters._V_cotizacionHabitacionTableAdapter();
            tH.ClearBeforeFill = true;
            tH.Fill(dsconHabi._V_cotizacionHabitacion, "PLAYA EL AGUA", numeroReserva);

            dsPaxlocalizadorTableAdapters._sp_ConcaLocalizadorTableAdapter dscl = new dsPaxlocalizadorTableAdapters._sp_ConcaLocalizadorTableAdapter();
            dscl.ClearBeforeFill = true;
            dscl.Fill(dsPaxloca1._sp_ConcaLocalizador, numeroReserva, "PLAYA EL AGUA", fechI);

            dsPaxlocalizadorTableAdapters._sp_ConcaLocalizadorTableAdapter dscl2 = new dsPaxlocalizadorTableAdapters._sp_ConcaLocalizadorTableAdapter();
            dscl2.ClearBeforeFill = true;
            dscl2.Fill(dsPaxloca2._sp_ConcaLocalizador, numeroReserva, "PLAYA EL AGUA", fechI2);

            dsConceptosTableAdapters._ConceptoCotizacionTableAdapter cta = new dsConceptosTableAdapters._ConceptoCotizacionTableAdapter();
            cta.ClearBeforeFill = true;
            cta.Fill(dsConceptos._ConceptoCotizacion);
            
            ReportParameter[] parameters = new ReportParameter[2];
            parameters[0] = new ReportParameter("reserva", numeroReserva.ToString());
            parameters[1] = new ReportParameter("usuario", user);
           

            this._reportViewer1.LocalReport.ReportEmbeddedResource = "Reservas.confirmacion.rdlc";
            _reportViewer1.LocalReport.SetParameters(parameters);

            _reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            _reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;




            _reportViewer1.RefreshReport();


        }
        private void mostrarConfirmacionInternational()
        {
            dscon.Clear();
            dsconHabi.Clear();
            _ConfirmacionID.Clear();
            _ConfirmacionID.Reset();
            String[] fin;
            String fechI2;
            String[] ini = fech1ID.Split('/');
            String fechI = ini[2] + "/" + ini[1] + "/" + ini[0];
            if (!fech2ID.Equals(""))
            {
                fin = fech2ID.Split('/');
                fechI2 = fin[2] + "/" + fin[1] + "/" + fin[0];
            }
            else
            {
                fin = DateTime.Today.ToShortDateString().Split('/');
                fechI2 = fin[2] + "/" + fin[1] + "/" + fin[0];
            }
           
            dscon.BeginInit();
            rdsconfirmacion.Name = "DataSet1";
            rdsconfirmacion.Value = dscon._V_Confirmacion;
            _ConfirmacionID.LocalReport.DataSources.Add(rdsconfirmacion);
            dscon.EndInit();

            dsconHabi.BeginInit();
            rdshabitacion.Name = "DataSet2";
            rdshabitacion.Value = dsconHabi._V_cotizacionHabitacion;
            _ConfirmacionID.LocalReport.DataSources.Add(rdshabitacion);
            dsconHabi.EndInit();

            dsPaxloca1.BeginInit();
            rpdsPaxloca1.Name = "DataSet3";
            rpdsPaxloca1.Value = dsPaxloca1._sp_ConcaLocalizador;
            _ConfirmacionID.LocalReport.DataSources.Add(rpdsPaxloca1);
            dsPaxloca1.EndInit();

            dsPaxloca2.BeginInit();
            rpdsPaxloca2.Name = "DataSet4";
            rpdsPaxloca2.Value = dsPaxloca2._sp_ConcaLocalizador;
            _ConfirmacionID.LocalReport.DataSources.Add(rpdsPaxloca2);
            dsPaxloca2.EndInit();

            dsconPagosTI.BeginInit();
            rpdsPagosTI.Name = "DataSet5";
            rpdsPagosTI.Value = dsconPagosTI._V_Pagos;
            _ConfirmacionID.LocalReport.DataSources.Add(rpdsPagosTI);
            dsconPagosTI.EndInit();

            dsConceptos.BeginInit();
            rpdsConceptos.Name = "DataSet6";
            rpdsConceptos.Value = dsConceptos._ConceptoCotizacion;
            _ConfirmacionID.LocalReport.DataSources.Add(rpdsConceptos);
            dsConceptos.EndInit();

            this._ConfirmacionID.LocalReport.ReportEmbeddedResource = "Reservas.confirmacionID.rdlc";
            dsConfirmacionTableAdapters._V_ConfirmacionTableAdapter tc = new dsConfirmacionTableAdapters._V_ConfirmacionTableAdapter();
            tc.ClearBeforeFill = true;
            tc.Fill(dscon._V_Confirmacion, numeroReserva, "INTERNATIONAL DRIVE");
            dsConfirmacionHabitacionTableAdapters._V_cotizacionHabitacionTableAdapter tH = new dsConfirmacionHabitacionTableAdapters._V_cotizacionHabitacionTableAdapter();
            tH.ClearBeforeFill = true;
            tH.Fill(dsconHabi._V_cotizacionHabitacion, "INTERNATIONAL DRIVE", numeroReserva);

            dsPaxlocalizadorTableAdapters._sp_ConcaLocalizadorTableAdapter dscl = new dsPaxlocalizadorTableAdapters._sp_ConcaLocalizadorTableAdapter();
            dscl.ClearBeforeFill = true;
            dscl.Fill(dsPaxloca1._sp_ConcaLocalizador, numeroReserva, "INTERNATIONAL DRIVE", fechI);

            dsPaxlocalizadorTableAdapters._sp_ConcaLocalizadorTableAdapter dscl2 = new dsPaxlocalizadorTableAdapters._sp_ConcaLocalizadorTableAdapter();
            dscl2.ClearBeforeFill = true;
            dscl2.Fill(dsPaxloca2._sp_ConcaLocalizador, numeroReserva, "INTERNATIONAL DRIVE", fechI2);

            dsConfirmacionPagosTITableAdapters._V_PagosTableAdapter tp = new dsConfirmacionPagosTITableAdapters._V_PagosTableAdapter();
            tp.ClearBeforeFill = true;
            tp.Fill(dsconPagosTI._V_Pagos, numeroReserva, "CUOTA ESPECIAL DE RESERVA", "N/A");

            dsConceptosTableAdapters._ConceptoCotizacionTableAdapter cta = new dsConceptosTableAdapters._ConceptoCotizacionTableAdapter();
            cta.ClearBeforeFill = true;
            cta.Fill(dsConceptos._ConceptoCotizacion);

            ReportParameter[] parameters = new ReportParameter[2];
            parameters[0] = new ReportParameter("reserva", numeroReserva.ToString());
            parameters[1] = new ReportParameter("usuario", user);
            _ConfirmacionID.LocalReport.SetParameters(parameters);

            _ConfirmacionID.SetDisplayMode(DisplayMode.PrintLayout);
            _ConfirmacionID.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
            _ConfirmacionID.RefreshReport();



        }

        private void mostrarConfirmacionIsla()
        {
            dscon.Clear();
            dsconHabi.Clear();
            dsconPagosTI.Clear();
            _ConfirmacionIC.Clear();
            _ConfirmacionIC.Reset();
            String[] fin, fin2;
            String fechI2, fechF2;
            String[] ini = fech1IC.Split('/');
            String fechI = ini[2] + "/" + ini[1] + "/" + ini[0];
            String[] iniF1 = fechF1IC.Split('/');
            String fechF1 = iniF1[2] + "/" + iniF1[1] + "/" + iniF1[0];
            if (!fech2IC.Equals(""))
            {
                fin = fech2IC.Split('/');
                fechI2 = fin[2] + "/" + fin[1] + "/" + fin[0];
                fin2 = fechF2IC.Split('/');
                fechF2 = fin2[2] + "/" + fin2[1] + "/" + fin2[0];

            }
            else
            {
                fin = DateTime.Today.ToShortDateString().Split('/');
                fechI2 = fin[2] + "/" + fin[1] + "/" + fin[0];
                fechF2 = fechI2;
            }

            dscon.BeginInit();
            rdsconfirmacion.Name = "DataSet1";
            rdsconfirmacion.Value = dscon._V_Confirmacion;
            _ConfirmacionIC.LocalReport.DataSources.Add(rdsconfirmacion);
            dscon.EndInit();

            dsconHabi.BeginInit();
            rdshabitacion.Name = "DataSet2";
            rdshabitacion.Value = dsconHabi._V_cotizacionHabitacion;
            _ConfirmacionIC.LocalReport.DataSources.Add(rdshabitacion);
            dsconHabi.EndInit();

            dsconPagosTI.BeginInit();
            rpdsPagosTI.Name = "DataSet3";
            rpdsPagosTI.Value = dsconPagosTI._V_Pagos;
            _ConfirmacionIC.LocalReport.DataSources.Add(rpdsPagosTI);
            dsconPagosTI.EndInit();

            dsPaxloca1.BeginInit();
            rpdsPaxloca1.Name = "DataSet4";
            rpdsPaxloca1.Value = dsPaxloca1._sp_ConcaLocalizador;
            _ConfirmacionIC.LocalReport.DataSources.Add(rpdsPaxloca1);
            dsPaxloca1.EndInit();

            dsPaxloca2.BeginInit();
            rpdsPaxloca2.Name = "DataSet5";
            rpdsPaxloca2.Value = dsPaxloca2._sp_ConcaLocalizador;
            _ConfirmacionIC.LocalReport.DataSources.Add(rpdsPaxloca2);
            dsPaxloca2.EndInit();

            dsConcaTempISC1.BeginInit();
            rpdsConcaTempIC1.Name = "DataSet6";
            rpdsConcaTempIC1.Value = dsConcaTempISC1._sp_ConcaTemporada;
            _ConfirmacionIC.LocalReport.DataSources.Add(rpdsConcaTempIC1);
            dsConcaTempISC1.EndInit();

            dsConcaTempISC2.BeginInit();
            rpdsConcaTempIC2.Name = "DataSet7";
            rpdsConcaTempIC2.Value = dsConcaTempISC2._sp_ConcaTemporada;
            _ConfirmacionIC.LocalReport.DataSources.Add(rpdsConcaTempIC2);
            dsConcaTempISC2.EndInit();

            dsconPagosTI1.BeginInit();
            rpdsPagosTI1.Name = "DataSet8";
            rpdsPagosTI1.Value = dsconPagosTI1._V_Pagos;
            _ConfirmacionIC.LocalReport.DataSources.Add(rpdsPagosTI1);
            dsconPagosTI1.EndInit();

            dsconPagosTI2.BeginInit();
            rpdsPagosTI2.Name = "DataSet9";
            rpdsPagosTI2.Value = dsconPagosTI2._V_Pagos;
            _ConfirmacionIC.LocalReport.DataSources.Add(rpdsPagosTI2);
            dsconPagosTI2.EndInit();

            dsConceptos.BeginInit();
            rpdsConceptos.Name = "DataSet10";
            rpdsConceptos.Value = dsConceptos._ConceptoCotizacion;
            _ConfirmacionIC.LocalReport.DataSources.Add(rpdsConceptos);
            dsConceptos.EndInit();

            this._ConfirmacionIC.LocalReport.ReportEmbeddedResource = "Reservas.confirmacioIC.rdlc";
            dsConfirmacionTableAdapters._V_ConfirmacionTableAdapter tc = new dsConfirmacionTableAdapters._V_ConfirmacionTableAdapter();
            tc.ClearBeforeFill = true;
            tc.Fill(dscon._V_Confirmacion, numeroReserva, "ISLA CARIBE");
            dsConfirmacionHabitacionTableAdapters._V_cotizacionHabitacionTableAdapter tH = new dsConfirmacionHabitacionTableAdapters._V_cotizacionHabitacionTableAdapter();
            tH.ClearBeforeFill = true;
            tH.Fill(dsconHabi._V_cotizacionHabitacion, "ISLA CARIBE", numeroReserva);

            dsConfirmacionPagosTITableAdapters._V_PagosTableAdapter tp = new dsConfirmacionPagosTITableAdapters._V_PagosTableAdapter();
            tp.ClearBeforeFill = true;
            tp.Fill(dsconPagosTI._V_Pagos, numeroReserva,"TODO INCLUIDO","ISLA CARIBE");

            dsPaxlocalizadorTableAdapters._sp_ConcaLocalizadorTableAdapter dscl = new dsPaxlocalizadorTableAdapters._sp_ConcaLocalizadorTableAdapter();
            dscl.ClearBeforeFill = true;
            dscl.Fill(dsPaxloca1._sp_ConcaLocalizador, numeroReserva, "ISLA CARIBE", fechI);

            dsPaxlocalizadorTableAdapters._sp_ConcaLocalizadorTableAdapter dscl2 = new dsPaxlocalizadorTableAdapters._sp_ConcaLocalizadorTableAdapter();
            dscl.ClearBeforeFill = true;
            dscl.Fill(dsPaxloca2._sp_ConcaLocalizador, numeroReserva, "ISLA CARIBE", fechI2);

            dsConcaTemporadasTableAdapters._sp_ConcaTemporadaTableAdapter dsct1 = new dsConcaTemporadasTableAdapters._sp_ConcaTemporadaTableAdapter();
            dsct1.ClearBeforeFill = true;
            dsct1.Fill(dsConcaTempISC1._sp_ConcaTemporada, fechI, fechF1, "ISLA CARIBE");

            dsConcaTemporadasTableAdapters._sp_ConcaTemporadaTableAdapter dsct2 = new dsConcaTemporadasTableAdapters._sp_ConcaTemporadaTableAdapter();
            dsct2.ClearBeforeFill = true;
            dsct2.Fill(dsConcaTempISC2._sp_ConcaTemporada, fechI2, fechF2,"ISLA CARIBE");

            dsConfirmacionPagosTITableAdapters._V_PagosTableAdapter tp1 = new dsConfirmacionPagosTITableAdapters._V_PagosTableAdapter();
            tp1.ClearBeforeFill = true;
            tp1.Fill(dsconPagosTI1._V_Pagos, numeroReserva, "SUPLEMENTO NAVIDAD", "ISLA CARIBE");

            dsConfirmacionPagosTITableAdapters._V_PagosTableAdapter tp2 = new dsConfirmacionPagosTITableAdapters._V_PagosTableAdapter();
            tp2.ClearBeforeFill = true;
            tp2.Fill(dsconPagosTI2._V_Pagos, numeroReserva, "SUPLEMENTO CENA FIN DE AÑO", "ISLA CARIBE");

            dsConceptosTableAdapters._ConceptoCotizacionTableAdapter cta = new dsConceptosTableAdapters._ConceptoCotizacionTableAdapter();
            cta.ClearBeforeFill = true;
            cta.Fill(dsConceptos._ConceptoCotizacion);

            ReportParameter[] parameters = new ReportParameter[2];
            parameters[0] = new ReportParameter("reserva", numeroReserva.ToString());
            parameters[1] = new ReportParameter("usuario", user);
            _ConfirmacionIC.LocalReport.SetParameters(parameters);

            _ConfirmacionIC.SetDisplayMode(DisplayMode.PrintLayout);
            _ConfirmacionIC.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
            _ConfirmacionIC.RefreshReport();



        }

        private void mostrarConfirmacionCoche()
        {
            dscon.Clear();
            dsconHabi.Clear();
            dsconPagosTI.Clear();
            _ConfirmacionPB.Clear();
            _ConfirmacionPB.Reset();

            String[] fin,fin2;
            String fechI2,fechF2;
            String[] ini = fech1CPB.Split('/');
            String fechI = ini[2] + "/" + ini[1] + "/" + ini[0];
             String[] iniF1 = fechF1CPB.Split('/');
            String fechF1 = iniF1[2] + "/" + iniF1[1] + "/" + iniF1[0];

            if (!fech2CPB.Equals(""))
            {
                fin = fech2CPB.Split('/');
                fechI2 = fin[2] + "/" + fin[1] + "/" + fin[0];
                fin2 = fechF2CPB.Split('/');
                fechF2 = fin2[2] + "/" + fin2[1] + "/" + fin2[0];
            }
            else
            {
                fin = DateTime.Today.ToShortDateString().Split('/');
                fechI2 = fin[2] + "/" + fin[1] + "/" + fin[0];
                fechF2 = fechI2;
            }

            dscon.BeginInit();
            rdsconfirmacion.Name = "DataSet1";
            rdsconfirmacion.Value = dscon._V_Confirmacion;
            _ConfirmacionPB.LocalReport.DataSources.Add(rdsconfirmacion);
            dscon.EndInit();

            dsconHabi.BeginInit();
            rdshabitacion.Name = "DataSet2";
            rdshabitacion.Value = dsconHabi._V_cotizacionHabitacion;
            _ConfirmacionPB.LocalReport.DataSources.Add(rdshabitacion);
            dsconHabi.EndInit();

            dsconPagosTI.BeginInit();
            rpdsPagosTI.Name = "DataSet3";
            rpdsPagosTI.Value = dsconPagosTI._V_Pagos;
            _ConfirmacionPB.LocalReport.DataSources.Add(rpdsPagosTI);
            dsconPagosTI.EndInit();

            dsPaxloca1.BeginInit();
            rpdsPaxloca1.Name = "DataSet4";
            rpdsPaxloca1.Value = dsPaxloca1._sp_ConcaLocalizador;
            _ConfirmacionPB.LocalReport.DataSources.Add(rpdsPaxloca1);
            dsPaxloca1.EndInit();

            dsPaxloca2.BeginInit();
            rpdsPaxloca2.Name = "DataSet5";
            rpdsPaxloca2.Value = dsPaxloca2._sp_ConcaLocalizador;
            _ConfirmacionPB.LocalReport.DataSources.Add(rpdsPaxloca2);
            dsPaxloca2.EndInit();

            dsConcaTempCPB1.BeginInit();
            rpdsConcaTempCPB1.Name = "DataSet6";
            rpdsConcaTempCPB1.Value = dsConcaTempCPB1._sp_ConcaTemporada;
            _ConfirmacionPB.LocalReport.DataSources.Add(rpdsConcaTempCPB1);
            dsConcaTempCPB1.EndInit();

            dsConcaTempCPB2.BeginInit();
            rpdsConcaTempCPB2.Name = "DataSet7";
            rpdsConcaTempCPB2.Value = dsConcaTempCPB2._sp_ConcaTemporada;
            _ConfirmacionPB.LocalReport.DataSources.Add(rpdsConcaTempCPB2);
            dsConcaTempCPB2.EndInit();

            dsconPagosTI1.BeginInit();
            rpdsPagosTI1.Name = "DataSet8";
            rpdsPagosTI1.Value = dsconPagosTI1._V_Pagos;
            _ConfirmacionPB.LocalReport.DataSources.Add(rpdsPagosTI1);
            dsconPagosTI1.EndInit();

            dsconPagosTI2.BeginInit();
            rpdsPagosTI2.Name = "DataSet9";
            rpdsPagosTI2.Value = dsconPagosTI2._V_Pagos;
            _ConfirmacionPB.LocalReport.DataSources.Add(rpdsPagosTI2);
            dsconPagosTI2.EndInit();

            dsConceptos.BeginInit();
            rpdsConceptos.Name = "DataSet10";
            rpdsConceptos.Value = dsConceptos._ConceptoCotizacion;
            _ConfirmacionPB.LocalReport.DataSources.Add(rpdsConceptos);
            dsConceptos.EndInit();

            this._ConfirmacionPB.LocalReport.ReportEmbeddedResource = "Reservas.confirmacionCPB.rdlc";
            dsConfirmacionTableAdapters._V_ConfirmacionTableAdapter tc = new dsConfirmacionTableAdapters._V_ConfirmacionTableAdapter();
            tc.ClearBeforeFill = true;
            tc.Fill(dscon._V_Confirmacion, numeroReserva, "COCHE PUNTA BLANCA");

            dsConfirmacionHabitacionTableAdapters._V_cotizacionHabitacionTableAdapter tH = new dsConfirmacionHabitacionTableAdapters._V_cotizacionHabitacionTableAdapter();
            tH.ClearBeforeFill = true;
            tH.Fill(dsconHabi._V_cotizacionHabitacion, "COCHE PUNTA BLANCA", numeroReserva);

            dsConfirmacionPagosTITableAdapters._V_PagosTableAdapter tp = new dsConfirmacionPagosTITableAdapters._V_PagosTableAdapter();
            tp.ClearBeforeFill = true;
            tp.Fill(dsconPagosTI._V_Pagos, numeroReserva,"TODO INCLUIDO","COCHE PUNTA BLANCA");

            dsPaxlocalizadorTableAdapters._sp_ConcaLocalizadorTableAdapter dscl = new dsPaxlocalizadorTableAdapters._sp_ConcaLocalizadorTableAdapter();
            dscl.ClearBeforeFill = true;
            dscl.Fill(dsPaxloca1._sp_ConcaLocalizador, numeroReserva, "COCHE PUNTA BLANCA", fechI);

            dsPaxlocalizadorTableAdapters._sp_ConcaLocalizadorTableAdapter dscl2 = new dsPaxlocalizadorTableAdapters._sp_ConcaLocalizadorTableAdapter();
            dscl.ClearBeforeFill = true;
            dscl.Fill(dsPaxloca2._sp_ConcaLocalizador, numeroReserva, "COCHE PUNTA BLANCA", fechI2);

            dsConcaTemporadasTableAdapters._sp_ConcaTemporadaTableAdapter dsct1 = new dsConcaTemporadasTableAdapters._sp_ConcaTemporadaTableAdapter();
            dsct1.ClearBeforeFill = true;
            dsct1.Fill(dsConcaTempCPB1._sp_ConcaTemporada, fechI, fechF1, "COCHE PUNTA BLANCA");

            dsConcaTemporadasTableAdapters._sp_ConcaTemporadaTableAdapter dsct2 = new dsConcaTemporadasTableAdapters._sp_ConcaTemporadaTableAdapter();
            dsct2.ClearBeforeFill = true;
            dsct2.Fill(dsConcaTempCPB2._sp_ConcaTemporada, fechI2, fechF2, "COCHE PUNTA BLANCA");

            dsConfirmacionPagosTITableAdapters._V_PagosTableAdapter tp1 = new dsConfirmacionPagosTITableAdapters._V_PagosTableAdapter();
            tp1.ClearBeforeFill = true;
            tp1.Fill(dsconPagosTI1._V_Pagos, numeroReserva, "SUPLEMENTO NAVIDAD", "COCHE PUNTA BLANCA");

            dsConfirmacionPagosTITableAdapters._V_PagosTableAdapter tp2 = new dsConfirmacionPagosTITableAdapters._V_PagosTableAdapter();
            tp2.ClearBeforeFill = true;
            tp2.Fill(dsconPagosTI2._V_Pagos, numeroReserva, "SUPLEMENTO CENA FIN DE AÑO", "COCHE PUNTA BLANCA");

            dsConceptosTableAdapters._ConceptoCotizacionTableAdapter cta = new dsConceptosTableAdapters._ConceptoCotizacionTableAdapter();
            cta.ClearBeforeFill = true;
            cta.Fill(dsConceptos._ConceptoCotizacion);

            //String[] inicio=dt;
            //String f1=
            //String[] final = fech1CPB.Split('/');
            //String f2 = ini[2] + "/" + ini[1] + "/" + ini[0];

            ReportParameter[] parameters = new ReportParameter[2];
            parameters[0] = new ReportParameter("reserva", numeroReserva.ToString());
            parameters[1] = new ReportParameter("usuario", user);
            _ConfirmacionPB.LocalReport.SetParameters(parameters);

            _ConfirmacionPB.SetDisplayMode(DisplayMode.PrintLayout);
            _ConfirmacionPB.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
            _ConfirmacionPB.RefreshReport();


        }

        private void mostrarConfirmacionCostaAzul()
        {
            dscon.Clear();
            dsconHabi.Clear();
            _ConfirmacionCA.Clear();
            _ConfirmacionCA.Reset();
            String[] fin;
            String fechI2;
            String[] ini = fechaI1CA.Split('/');
            String fechI = ini[2] + "/" + ini[1] + "/" + ini[0];
            if (!fechaF2CA.Equals(""))
            {
                fin = fechaF2CA.Split('/');
                fechI2 = fin[2] + "/" + fin[1] + "/" + fin[0];
            }
            else
            {
                fin = DateTime.Today.ToShortDateString().Split('/');
                fechI2 = fin[2] + "/" + fin[1] + "/" + fin[0];
            }

            dscon.BeginInit();
            rdsconfirmacion.Name = "DataSet1";
            rdsconfirmacion.Value = dscon._V_Confirmacion;
            _ConfirmacionCA.LocalReport.DataSources.Add(rdsconfirmacion);
            dscon.EndInit();

            dsconHabi.BeginInit();
            rdshabitacion.Name = "DataSet2";
            rdshabitacion.Value = dsconHabi._V_cotizacionHabitacion;
            _ConfirmacionCA.LocalReport.DataSources.Add(rdshabitacion);
            dsconHabi.EndInit();

            dsPaxloca1.BeginInit();
            rpdsPaxloca1.Name = "DataSet3";
            rpdsPaxloca1.Value = dsPaxloca1._sp_ConcaLocalizador;
            _ConfirmacionCA.LocalReport.DataSources.Add(rpdsPaxloca1);
            dsPaxloca1.EndInit();

            dsPaxloca2.BeginInit();
            rpdsPaxloca2.Name = "DataSet4";
            rpdsPaxloca2.Value = dsPaxloca2._sp_ConcaLocalizador;
            _ConfirmacionCA.LocalReport.DataSources.Add(rpdsPaxloca2);
            dsPaxloca2.EndInit();

            dsConceptos.BeginInit();
            rpdsConceptos.Name = "DataSet5";
            rpdsConceptos.Value = dsConceptos._ConceptoCotizacion;
            _ConfirmacionCA.LocalReport.DataSources.Add(rpdsConceptos);
            dsConceptos.EndInit();

            dsConfirmacionTableAdapters._V_ConfirmacionTableAdapter tc = new dsConfirmacionTableAdapters._V_ConfirmacionTableAdapter();
            tc.ClearBeforeFill = true;
            tc.Fill(dscon._V_Confirmacion, numeroReserva, "COSTA AZUL");
            dsConfirmacionHabitacionTableAdapters._V_cotizacionHabitacionTableAdapter tH = new dsConfirmacionHabitacionTableAdapters._V_cotizacionHabitacionTableAdapter();
            tH.ClearBeforeFill = true;
            tH.Fill(dsconHabi._V_cotizacionHabitacion, "COSTA AZUL", numeroReserva);

            dsPaxlocalizadorTableAdapters._sp_ConcaLocalizadorTableAdapter dscl = new dsPaxlocalizadorTableAdapters._sp_ConcaLocalizadorTableAdapter();
            dscl.ClearBeforeFill = true;
            dscl.Fill(dsPaxloca1._sp_ConcaLocalizador, numeroReserva, "COSTA AZUL", fechI);

            dsPaxlocalizadorTableAdapters._sp_ConcaLocalizadorTableAdapter dscl2 = new dsPaxlocalizadorTableAdapters._sp_ConcaLocalizadorTableAdapter();
            dscl2.ClearBeforeFill = true;
            dscl2.Fill(dsPaxloca2._sp_ConcaLocalizador, numeroReserva, "COSTA AZUL", fechI2);

            dsConceptosTableAdapters._ConceptoCotizacionTableAdapter cta = new dsConceptosTableAdapters._ConceptoCotizacionTableAdapter();
            cta.ClearBeforeFill = true;
            cta.Fill(dsConceptos._ConceptoCotizacion);

            ReportParameter[] parameters = new ReportParameter[2];
            parameters[0] = new ReportParameter("reserva", numeroReserva.ToString());
            parameters[1] = new ReportParameter("usuario", user);


            this._ConfirmacionCA.LocalReport.ReportEmbeddedResource = "Reservas.confirmacionCA.rdlc";
            _ConfirmacionCA.LocalReport.SetParameters(parameters);

            _ConfirmacionCA.SetDisplayMode(DisplayMode.PrintLayout);
            _ConfirmacionCA.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;

            _ConfirmacionCA.RefreshReport();


        }

        private void txtNroReservaCobros_KeyUp(object sender, KeyEventArgs e)
        {
            DateTime? f = dpfechaPago.SelectedDate;
            DateTime? ff = dpfechafinPago.SelectedDate;
            string concepto = "";
            string ejecutivo = "";
            string hotel = "";
            if (lstCargos1.SelectedItem != null)
                concepto = lstCargos1.SelectedItem.ToString();
            if (lstEjecutivo.SelectedItem != null)
                ejecutivo = lstEjecutivo.SelectedItem.ToString();
            if (lstHotel.SelectedItem != null)
                hotel = lstHotel.SelectedItem.ToString();
            string reserva = txtNroReservaCobros.Text;
            string contrato = txtNroContratoCobros.Text;
            string status = "";
            String fechI = "";
            String fechF = "";
            dtgPagos.ItemsSource = null;

            if (concepto.Equals(""))
                concepto = "0";
            if (ejecutivo.Equals(""))
                ejecutivo = "0";
            if (hotel.Equals(""))
                hotel = "0";
            if (reserva.Equals(""))
                reserva = "0";
            if (contrato.Equals(""))
                contrato = "0";
            if (lstEstatus1.SelectedIndex == 0)
                status = "2";
            else
            {
                if (lstEstatus1.SelectedIndex == 1)
                    status = "1";
                else
                    status = "0";
            }
            if (f == null)
            {
                fechI = "0";
            }
            else
            {
                String[] ini = f.Value.ToShortDateString().Split('/');
                fechI = ini[2] + "/" + ini[1] + "/" + ini[0];
            }
            if (ff == null)
            {
                fechF = "0";
            }
            else
            {
                String[] fin = ff.Value.ToShortDateString().Split('/');
                fechF = fin[2] + "/" + fin[1] + "/" + fin[0];
            }
            cargarPagos(concepto, fechI, status, Convert.ToInt32(reserva), contrato, fechF, hotel, ejecutivo);
        }

        private void txtNroContratoCobros_KeyUp(object sender, KeyEventArgs e)
        {
            DateTime? f = dpfechaPago.SelectedDate;
            DateTime? ff = dpfechafinPago.SelectedDate;
            string concepto = "";
            string ejecutivo = "";
            string hotel = "";
            if (lstCargos1.SelectedItem != null)
                concepto = lstCargos1.SelectedItem.ToString();
            if (lstEjecutivo.SelectedItem != null)
                ejecutivo = lstEjecutivo.SelectedItem.ToString();
            if (lstHotel.SelectedItem != null)
                hotel = lstHotel.SelectedItem.ToString();
            string reserva = txtNroReservaCobros.Text;
            string contrato = txtNroContratoCobros.Text;
            string status = "";
            String fechI = "";
            String fechF = "";
            dtgPagos.ItemsSource = null;

            if (concepto.Equals(""))
                concepto = "0";
            if (ejecutivo.Equals(""))
                ejecutivo = "0";
            if (hotel.Equals(""))
                hotel = "0";
            if (reserva.Equals(""))
                reserva = "0";
            if (contrato.Equals(""))
                contrato = "0";
            if (lstEstatus1.SelectedIndex == 0)
                status = "2";
            else
            {
                if (lstEstatus1.SelectedIndex == 1)
                    status = "1";
                else
                    status = "0";
            }
            if (f == null)
            {
                fechI = "0";
            }
            else
            {
                String[] ini = f.Value.ToShortDateString().Split('/');
                fechI = ini[2] + "/" + ini[1] + "/" + ini[0];
            }
            if (ff == null)
            {
                fechF = "0";
            }
            else
            {
                String[] fin = ff.Value.ToShortDateString().Split('/');
                fechF = fin[2] + "/" + fin[1] + "/" + fin[0];
            }
            cargarPagos(concepto, fechI, status, Convert.ToInt32(reserva), contrato, fechF, hotel, ejecutivo);
        }

        private void dpfechaReportefin_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? f = dpfechaReportefin.SelectedDate;
            if (f != null)
            {
                String[] ini = f.Value.ToShortDateString().Split('/');
                String fechI = ini[2] + "/" + ini[1] + "/" + ini[0];
                reservacion res = new reservacion();
                if (txtNroReservaReporte.Text.Equals("") && txtNroContratoReporte.Text.Equals("") && txtClienteReporte.Text.Equals("") && lstEstatus.SelectedIndex == 0 && dpfechaReporte.SelectedDate == null)
                {
                    dtgReservasReporte.ItemsSource = res.reporte_reserva(0, "0", "0", 0, "0", fechI);
                    gRreserva = 0;
                    gRcliente = "0";
                    gRcontrato = "0";
                    gRstatus = "0";
                    gRfecha = "0";
                    gRfechaf = fechI;
                }
                else
                {
                    if (!txtNroReservaReporte.Text.Equals("") && txtNroContratoReporte.Text.Equals("") && txtClienteReporte.Text.Equals("") && lstEstatus.SelectedIndex == 0 && dpfechaReporte.SelectedDate == null)
                    {
                        dtgReservasReporte.ItemsSource = res.reporte_reserva(Convert.ToInt32(txtNroReservaReporte.Text), "0", "0", 0, "0", fechI);
                        gRreserva = Convert.ToInt32(txtNroReservaReporte.Text);
                        gRcliente = "0";
                        gRcontrato = "0";
                        gRstatus = "0";
                        gRfecha = "0";
                        gRfechaf = fechI;
                    }
                    else
                    {
                        if (!txtNroReservaReporte.Text.Equals("") && !txtNroContratoReporte.Text.Equals("") && txtClienteReporte.Text.Equals("") && lstEstatus.SelectedIndex == 0 && dpfechaReporte.SelectedDate == null)
                        {
                            dtgReservasReporte.ItemsSource = res.reporte_reserva(Convert.ToInt32(txtNroReservaReporte.Text), "0", "0", Convert.ToInt32(txtNroContratoReporte.Text), "0", fechI);
                            gRreserva = Convert.ToInt32(txtNroReservaReporte.Text);
                            gRcliente = "0";
                            gRcontrato = txtNroContratoReporte.Text;
                            gRstatus = "0";
                            gRfecha = "0";
                            gRfechaf = fechI;
                        }
                        else
                        {
                            if (!txtNroReservaReporte.Text.Equals("") && !txtNroContratoReporte.Text.Equals("") && !txtClienteReporte.Text.Equals("") && lstEstatus.SelectedIndex == 0 && dpfechaReporte.SelectedDate == null)
                            {
                                dtgReservasReporte.ItemsSource = res.reporte_reserva(Convert.ToInt32(txtNroReservaReporte.Text), txtClienteReporte.Text, "0", Convert.ToInt32(txtNroContratoReporte.Text), "0", fechI);
                                gRreserva = Convert.ToInt32(txtNroReservaReporte.Text);
                                gRcliente = txtClienteReporte.Text;
                                gRcontrato = txtNroContratoReporte.Text;
                                gRstatus = "0";
                                gRfecha = "0";
                                gRfechaf = fechI;
                            }
                            else
                            {
                                if (!txtNroReservaReporte.Text.Equals("") && !txtNroContratoReporte.Text.Equals("") && !txtClienteReporte.Text.Equals("") && lstEstatus.SelectedIndex != 0 && dpfechaReporte.SelectedDate == null)
                                {
                                    dtgReservasReporte.ItemsSource = res.reporte_reserva(Convert.ToInt32(txtNroReservaReporte.Text), txtClienteReporte.Text, "0", Convert.ToInt32(txtNroContratoReporte.Text), lstEstatus.SelectedValue.ToString(), fechI);
                                    gRreserva = Convert.ToInt32(txtNroReservaReporte.Text);
                                    gRcliente = txtClienteReporte.Text;
                                    gRcontrato = txtNroContratoReporte.Text;
                                    gRstatus = lstEstatus.SelectedValue.ToString();
                                    gRfecha = "0";
                                    gRfechaf = fechI;
                                }
                                else
                                {
                                    DateTime? ff = dpfechaReporte.SelectedDate;
                                    if (ff != null)
                                    {
                                        String[] fin = ff.Value.ToShortDateString().Split('/');
                                        String fechF = fin[2] + "/" + fin[1] + "/" + fin[0];
                                        dtgReservasReporte.ItemsSource = res.reporte_reserva(0, "0", fechF, 0, "0", fechI);
                                        gRreserva = 0;
                                        gRcliente = "0";
                                        gRcontrato = "0";
                                        gRstatus = "0";
                                        gRfecha = fechF;
                                        gRfechaf = fechI;
                                    }
                                }
                            }
                        }
                    }

                }

            }
        }

        private void dpfechafinPago_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? f = dpfechaPago.SelectedDate;
            DateTime? ff = dpfechafinPago.SelectedDate;
            string concepto = "";
            string ejecutivo = "";
            string hotel = "";
            if (lstCargos1.SelectedItem != null)
                concepto = lstCargos1.SelectedItem.ToString();
            if (lstEjecutivo.SelectedItem != null)
                ejecutivo = lstEjecutivo.SelectedItem.ToString();
            if (lstHotel.SelectedItem != null)
                hotel = lstHotel.SelectedItem.ToString();
            string reserva = txtNroReservaCobros.Text;
            string contrato = txtNroContratoCobros.Text;
            string status = "";
            String fechI = "";
            String fechF = "";
            dtgPagos.ItemsSource = null;

            if (concepto.Equals(""))
                concepto = "0";
            if (ejecutivo.Equals(""))
                ejecutivo = "0";
            if (hotel.Equals(""))
                hotel = "0";
            if (reserva.Equals(""))
                reserva = "0";
            if (contrato.Equals(""))
                contrato = "0";
            if (lstEstatus1.SelectedIndex == 0)
                status = "2";
            else
            {
                if (lstEstatus1.SelectedIndex == 1)
                    status = "1";
                else
                    status = "0";
            }
            if (f == null)
            {
                fechI = "0";
            }
            else
            {
                String[] ini = f.Value.ToShortDateString().Split('/');
                fechI = ini[2] + "/" + ini[1] + "/" + ini[0];
            }
            if (ff == null)
            {
                fechF = "0";
            }
            else
            {
                String[] fin = ff.Value.ToShortDateString().Split('/');
                fechF = fin[2] + "/" + fin[1] + "/" + fin[0];
            }
            cargarPagos(concepto, fechI, status, Convert.ToInt32(reserva), contrato, fechF, hotel, ejecutivo);
        }

        private void btnImprimirCB_Click(object sender, RoutedEventArgs e)
        {
            mostrarConfirmacionCaribbean();
        }

        private void btnImprimirID_Click(object sender, RoutedEventArgs e)
        {
            mostrarConfirmacionInternational();
        }

        private void btnImprimirIC_Click(object sender, RoutedEventArgs e)
        {
            mostrarConfirmacionIsla();
        }

        private void btnImprimirPB_Click(object sender, RoutedEventArgs e)
        {
            mostrarConfirmacionCoche();
        }

        private void dtgReservas1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (delocalizador)
            {
                object item = dtgReservas1.SelectedItem;
                if ((dtgReservas1.Items.Count > 0) && (item != null))
                {
                    _reportViewer1.Clear();
                    _ConfirmacionIC.Clear();
                    _ConfirmacionPB.Clear();
                    _ConfirmacionID.Clear();
                    // numeroReserva = Convert.ToInt32((dtgReservas1.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
                    // contrato = (dtgReservas1.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                    estadoCuenta ed = new estadoCuenta();
                    ed.contrato = contrato;
                    ed.Show();
                    dt = new DataTable();
                    reservacion reserva = new reservacion();
                    dt.Load(reserva.buscarHabitacion(numeroReserva));
                    int CB = 0, ID = 0, IC = 0, CPB = 0,CA=0;
                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        switch (dt.Rows[i][0].ToString())
                        {
                            case "PLAYA EL AGUA":
                                if (CB == 0)
                                {
                                    fech1CB = Convert.ToDateTime(dt.Rows[i][7].ToString()).ToShortDateString();
                                    CB++;
                                }
                                if (Convert.ToDateTime(fech1CB).CompareTo(Convert.ToDateTime(dt.Rows[i][7].ToString())) != 0)
                                    fech2CB = Convert.ToDateTime(dt.Rows[i][7].ToString()).ToShortDateString();
                                else
                                    fech2CB = "";
                                btnImprimirCB.IsEnabled = true;
                                tbCB.IsEnabled = true;
                                break;
                            case "INTERNATIONAL DRIVE":
                                if (ID == 0)
                                {
                                    fech1ID = Convert.ToDateTime(dt.Rows[i][7].ToString()).ToShortDateString();
                                    ID++;
                                }
                                if (Convert.ToDateTime(fech1ID).CompareTo(Convert.ToDateTime(dt.Rows[i][7].ToString())) != 0)
                                    fech2ID = Convert.ToDateTime(dt.Rows[i][7].ToString()).ToShortDateString();
                                else
                                    fech2ID = "";
                                btnImprimirID.IsEnabled = true;
                                tbID.IsEnabled = true;
                                break;
                            case "ISLA CARIBE":
                                if (IC == 0)
                                {
                                    fech1IC = Convert.ToDateTime(dt.Rows[i][7].ToString()).ToShortDateString();
                                    fechF1IC = Convert.ToDateTime(dt.Rows[i][8].ToString()).AddDays(-1).ToShortDateString();
                                    IC++;
                                }
                                if (Convert.ToDateTime(fech1IC).CompareTo(Convert.ToDateTime(dt.Rows[i][7].ToString())) != 0)
                                {
                                    fech2IC = Convert.ToDateTime(dt.Rows[i][7].ToString()).ToShortDateString();
                                    fechF2IC = Convert.ToDateTime(dt.Rows[i][8].ToString()).AddDays(-1).ToShortDateString();
                                }
                                else
                                {
                                    fech2IC = "";
                                    fechF2IC = "";
                                }
                                btnImprimirIC.IsEnabled = true;
                                tbIC.IsEnabled = true;
                                break;
                            case "COCHE PUNTA BLANCA":
                                if (CPB == 0)
                                {
                                    fech1CPB = Convert.ToDateTime(dt.Rows[i][7].ToString()).ToShortDateString();
                                    fechF1CPB = Convert.ToDateTime(dt.Rows[i][8].ToString()).AddDays(-1).ToShortDateString();
                                    CPB++;
                                }
                                if (Convert.ToDateTime(fech1CPB).CompareTo(Convert.ToDateTime(dt.Rows[i][7].ToString())) != 0)
                                {
                                    fech2CPB = Convert.ToDateTime(dt.Rows[i][7].ToString()).ToShortDateString();
                                    fechF2CPB = Convert.ToDateTime(dt.Rows[i][8].ToString()).AddDays(-1).ToShortDateString();
                                }
                                else
                                {
                                    fech2CPB = "";
                                    fechF2CPB = "";
                                }
                                btnImprimirPB.IsEnabled = true;
                                tbCPB.IsEnabled = true;
                                break;
                            case "COSTA AZUL":
                                if (CA == 0)
                                {
                                    fechaI1CA = Convert.ToDateTime(dt.Rows[i][7].ToString()).ToShortDateString();
                                    CA++;
                                }
                                if (Convert.ToDateTime(fechaI1CA).CompareTo(Convert.ToDateTime(dt.Rows[i][7].ToString())) != 0)
                                    fechaF2CA = Convert.ToDateTime(dt.Rows[i][7].ToString()).ToShortDateString();
                                else
                                    fechaF2CA = "";
                                btnImprimirCA.IsEnabled = true;
                                tbCA.IsEnabled = true;
                                break;
                        }
                    }
                    delocalizador = false;
                }



            }
            else
            {
                _reportViewer1.Clear();
                _ConfirmacionIC.Clear();
                _ConfirmacionPB.Clear();
                _ConfirmacionID.Clear();
                btnImprimirPB.IsEnabled = false;
                btnImprimirIC.IsEnabled = false;
                btnImprimirID.IsEnabled = false;
                btnImprimirCB.IsEnabled = false;
                tbCB.IsEnabled = false;
                tbID.IsEnabled = false;
                tbIC.IsEnabled = false;
                tbCPB.IsEnabled = false;
                tbCA.IsEnabled = false;
            }
        }

        private void txtNroReserva1_TextChanged(object sender, TextChangedEventArgs e)
        {
            DateTime? f = dpfecha1.SelectedDate;
            DateTime? ff = dpfecha1.SelectedDate;
            reservacion res = new reservacion();
            if ((txtCliente1.Text.Equals("")) && (txtNroContrato1.Text.Equals("")) && (f == null) && (ff == null))
                dtgReservas1.ItemsSource = res.buscar_reservaConfir(txtNroReserva1.Text, "0", "", "0","");
            else
            {

                if ((!txtCliente1.Text.Equals("")) && (txtNroContrato1.Text.Equals("")) && (f == null) && (ff == null))
                    dtgReservas1.ItemsSource = res.buscar_reservaConfir(txtNroReserva1.Text, txtCliente1.Text, "", "0","");
                else
                {
                    if ((!txtCliente1.Text.Equals("")) && (!txtNroContrato1.Text.Equals("")) && (f == null) && (ff == null))
                        dtgReservas1.ItemsSource = res.buscar_reservaConfir(txtNroReserva1.Text, txtCliente1.Text, "", txtNroContrato1.Text,"");
                    else
                    {
                        if ((!txtCliente1.Text.Equals("")) && (!txtNroContrato1.Text.Equals("")) && (f != null) && (ff == null))
                        {
                            String[] ini = f.Value.ToShortDateString().Split('/');
                            String fechI = ini[2] + "/" + ini[1] + "/" + ini[0];
                            dtgReservas1.ItemsSource = res.buscar_reservaConfir(txtNroReserva1.Text, txtCliente1.Text, fechI, txtNroContrato1.Text,"");
                        }

                    }
                }
            }
            dtgReservas1.SelectedIndex = 0;
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

        private void txtNroReservaCobros_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtNroContratoCobros_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtNroReservaReporte_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtNroContratoReporte_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void btnImprimir_Click(object sender, RoutedEventArgs e)
        {
            if (dtgPagos.Items.Count > 0)
            {
                reporteCobros rc = new reporteCobros();
                rc.concepto = gconcepto;
                rc.contrato = gcontrato;
                rc.fecha = gfecha;
                rc.fechaf = gfechaf;
                rc.status = gstatus;
                rc.reserva = greserva;
                rc.hotel = ghotel;
                rc.ejecutivo = gEjecutivo;
                rc.us = us.login;
                rc.Show();
            }
        }

        private void dpfin1_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? f = dpfecha1.SelectedDate;
            DateTime? ff = dpfin1.SelectedDate;
            if (ff != null)
            {
                String[] ini = ff.Value.ToShortDateString().Split('/');
                String fechI = ini[2] + "/" + ini[1] + "/" + ini[0];
                reservacion res = new reservacion();
                if ((txtCliente1.Text.Equals("")) && (txtNroReserva1.Text.Equals("")) && (txtNroContrato1.Text.Equals("")) && (f == null))
                    dtgReservas1.ItemsSource = res.buscar_reservaConfir("0", "0","" , "0",fechI );
                else
                {                   
                    if ((txtCliente1.Text.Equals("")) && (txtNroReserva1.Text.Equals("")) && (txtNroContrato1.Text.Equals("")) && (f != null))
                    {
                        String[] fin = f.Value.ToShortDateString().Split('/');
                        String fechF = fin[2] + "/" + fin[1] + "/" + fin[0];
                        dtgReservas1.ItemsSource = res.buscar_reservaConfir("0", "0", fechF, "0",fechI );
                     }
                }          
            }
        }

        private void dpfin_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? f = dpfecha.SelectedDate;
            DateTime? ff = dpfin.SelectedDate;
            if (ff != null)
            {
                String[] ini = f.Value.ToShortDateString().Split('/');
                String fechI = ini[2] + "/" + ini[1] + "/" + ini[0];
                reservacion res = new reservacion();
                if ((txtCliente.Text.Equals("")) && (txtNroReserva.Text.Equals("")) && (txtNroContrato.Text.Equals("")) && f == null)
                    dtgReservas.ItemsSource = res.buscar_reservaC("0", "0","" , "0", fechI);
                else
                {
                    
                   if ((txtCliente.Text.Equals("")) && (txtNroReserva.Text.Equals("")) && (txtNroContrato.Text.Equals("")) && f != null)
                   {
                      String[] fin = f.Value.ToShortDateString().Split('/');
                      String fechF = fin[2] + "/" + fin[1] + "/" + fin[0];
                      dtgReservas.ItemsSource = res.buscar_reservaC("0", "0",fechF , "0",fechI );
                   }
              }                     
                    
                
            }
        }

        private void btnImprimirReservas_Click(object sender, RoutedEventArgs e)
        {
            if (dtgReservasReporte.Items.Count > 0)
            {
                reporteReserva rc = new reporteReserva();
                rc.cliente = gRcliente;
                rc.contrato = gRcontrato;
                rc.fecha = gRfecha;
                rc.fechaf = gRfechaf;
                rc.status = gRstatus;
                rc.reserva = gRreserva;
                rc.Show();
            }
        }

        private void lstEjecutivo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? f = dpfechaPago.SelectedDate;
            DateTime? ff = dpfechafinPago.SelectedDate;
            string concepto = "";
            string ejecutivo = "";
            string hotel = "";
            if (lstCargos1.SelectedItem != null)
                concepto = lstCargos1.SelectedItem.ToString();
            if (lstEjecutivo.SelectedItem != null)
                ejecutivo = lstEjecutivo.SelectedItem.ToString();
            if (lstHotel.SelectedItem != null)
                hotel = lstHotel.SelectedItem.ToString();
            string reserva = txtNroReservaCobros.Text;
            string contrato = txtNroContratoCobros.Text;
            string status = "";
            String fechI = "";
            String fechF = "";
            dtgPagos.ItemsSource = null;

            if (concepto.Equals(""))
                concepto = "0";
            if (ejecutivo.Equals(""))
                ejecutivo = "0";
            if (hotel.Equals(""))
                hotel = "0";
            if (reserva.Equals(""))
                reserva = "0";
            if (contrato.Equals(""))
                contrato = "0";
            if (lstEstatus1.SelectedIndex == 0)
                status = "2";
            else
            {
                if (lstEstatus1.SelectedIndex == 1)
                    status = "1";
                else
                    status = "0";
            }
            if (f == null)
            {
                fechI = "0";
            }
            else
            {
                String[] ini = f.Value.ToShortDateString().Split('/');
                fechI = ini[2] + "/" + ini[1] + "/" + ini[0];
            }
            if (ff == null)
            {
                fechF = "0";
            }
            else
            {
                String[] fin = ff.Value.ToShortDateString().Split('/');
                fechF = fin[2] + "/" + fin[1] + "/" + fin[0];
            }
            cargarPagos(concepto, fechI, status, Convert.ToInt32(reserva), contrato, fechF, hotel, ejecutivo);
        }

        private void lstHotel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? f = dpfechaPago.SelectedDate;
            DateTime? ff = dpfechafinPago.SelectedDate;
            string concepto = "";
            string ejecutivo = "";
            string hotel = "";
            if (lstCargos1.SelectedItem != null)
                concepto = lstCargos1.SelectedItem.ToString();
            if (lstEjecutivo.SelectedItem != null)
                ejecutivo = lstEjecutivo.SelectedItem.ToString();
            if (lstHotel.SelectedItem != null)
                hotel = lstHotel.SelectedItem.ToString();
            string reserva = txtNroReservaCobros.Text;
            string contrato = txtNroContratoCobros.Text;
            string status = "";
            String fechI = "";
            String fechF = "";
            dtgPagos.ItemsSource = null;

            if (concepto.Equals(""))
                concepto = "0";
            if (ejecutivo.Equals(""))
                ejecutivo = "0";
            if (hotel.Equals(""))
                hotel = "0";
            if (reserva.Equals(""))
                reserva = "0";
            if (contrato.Equals(""))
                contrato = "0";
            if (lstEstatus1.SelectedIndex == 0)
                status = "2";
            else
            {
                if (lstEstatus1.SelectedIndex == 1)
                    status = "1";
                else
                  status = "0";
            }
            if (f == null)
            {
                fechI = "0";
            }
            else
            {
                String[] ini = f.Value.ToShortDateString().Split('/');
                fechI = ini[2] + "/" + ini[1] + "/" + ini[0];
            }
            if (ff == null)
            {
                fechF = "0";
            }
            else
            {
                String[] fin = ff.Value.ToShortDateString().Split('/');
                fechF = fin[2] + "/" + fin[1] + "/" + fin[0];
            }
            cargarPagos(concepto, fechI, status, Convert.ToInt32(reserva), contrato, fechF, hotel, ejecutivo);
        }

        private void txtNroReserva_TextChanged(object sender, TextChangedEventArgs e)
        {
            DateTime? f = dpfecha.SelectedDate;
            DateTime? ff = dpfin.SelectedDate;
            reservacion res = new reservacion();
            if ((txtCliente.Text.Equals("")) && (txtNroContrato.Text.Equals("")) && (f == null) && (ff == null))
                dtgReservas.ItemsSource = res.buscar_reservaC(txtNroReserva.Text, "0", "", "0", "");
            else
            {

                if ((!txtCliente.Text.Equals("")) && (txtNroContrato.Text.Equals("")) && (f == null) && (ff == null))
                    dtgReservas.ItemsSource = res.buscar_reservaC(txtNroReserva.Text, txtCliente.Text, "", "0", "");
                else
                {
                    if ((!txtCliente.Text.Equals("")) && (!txtNroContrato.Text.Equals("")) && (f == null) && (ff == null))
                        dtgReservas.ItemsSource = res.buscar_reservaC(txtNroReserva.Text, txtCliente.Text, "", txtNroContrato.Text, "");
                    else
                    {
                        if ((!txtCliente.Text.Equals("")) && (!txtNroContrato.Text.Equals("")) && (f != null) && (ff == null))
                        {
                            String[] ini = f.Value.ToShortDateString().Split('/');
                            String fechI = ini[2] + "/" + ini[1] + "/" + ini[0];
                            dtgReservas.ItemsSource = res.buscar_reservaC(txtNroReserva.Text, txtCliente.Text, fechI, txtNroContrato.Text, "");
                        }

                    }
                }
            }
            dtgReservas.SelectedIndex = 0;
        }

        private void dtgReservas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dereserva)
            {
                object item = dtgReservas.SelectedItem;
                if ((dtgReservas.Items.Count > 0) && (item != null))
                {
                    //numeroReserva = Convert.ToInt32((dtgReservas.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
                    //string[] fi = (dtgReservas.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text.Split('-');
                    //string[] ff = (dtgReservas.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text.Split('-');
                    //ini = fi[2] + "/" + fi[1] + "/" + fi[0];
                    //fin = ff[2] + "/" + ff[1] + "/" + ff[0];
                    dsh.Clear();
                    dsH.Clear();
                    _reportViewer.Clear();
                    dsh.BeginInit();
                    rdshotel.Name = "DataSet1";
                    rdshotel.Value = dsh._V_cotizacionHotel;
                    _reportViewer.LocalReport.DataSources.Add(rdshotel);
                    dsh.EndInit();
                    dsH.BeginInit();
                    rdshabitacion.Name = "DataSet2";
                    rdshabitacion.Value = dsH._V_cotizacionHabitacion;
                    _reportViewer.LocalReport.DataSources.Add(rdshabitacion);
                    dsH.EndInit();
                    dsc.BeginInit();
                    rdscargos.Name = "DataSet3";
                    rdscargos.Value = dsc._V_CotizacionCargos;
                    _reportViewer.LocalReport.DataSources.Add(rdscargos);
                    dsc.EndInit();
                    dsm.BeginInit();
                    rdsmontoPA.Name = "DataSet4";
                    rdsmontoPA.Value = dsm._MontoPuntoAcelerado;
                    _reportViewer.LocalReport.DataSources.Add(rdsmontoPA);
                    dsm.EndInit();
                    dstemp.BeginInit();
                    rdstemporada.Name = "DataSet5";
                    rdstemporada.Value = dstemp._temporada_TI;
                    _reportViewer.LocalReport.DataSources.Add(rdstemporada);
                    dstemp.EndInit();

                    dsConcaTempCoti.BeginInit();
                    rpdsConcaTempCoti.Name = "DataSet6";
                    rpdsConcaTempCoti.Value = dsConcaTempCoti._sp_ConcaTemporada;
                    _reportViewer.LocalReport.DataSources.Add(rpdsConcaTempCoti);
                    dsConcaTempCoti.EndInit();

                   dsConcaTempCoti1.BeginInit();
                rpdsConcaTempCoti1.Name = "DataSet7";
                rpdsConcaTempCoti1.Value = dsConcaTempCoti1._sp_ConcaTemporada;
                _reportViewer.LocalReport.DataSources.Add(rpdsConcaTempCoti1);
                dsConcaTempCoti1.EndInit();

                    this._reportViewer.LocalReport.ReportEmbeddedResource = "Reservas.cotizacionN.rdlc";
                    dsCotizacionHotelTableAdapters._V_cotizacionHotelTableAdapter th = new dsCotizacionHotelTableAdapters._V_cotizacionHotelTableAdapter();
                    th.ClearBeforeFill = true;
                    th.Fill(dsh._V_cotizacionHotel, numeroReserva);

                    dsCotizacionHabitacionTableAdapters._V_cotizacionHabitacionTableAdapter tH = new dsCotizacionHabitacionTableAdapters._V_cotizacionHabitacionTableAdapter();
                    tH.ClearBeforeFill = true;
                    tH.Fill(dsH._V_cotizacionHabitacion, numeroReserva);

                    dsCotizacionCargosTableAdapters._V_CotizacionCargosTableAdapter tc = new dsCotizacionCargosTableAdapters._V_CotizacionCargosTableAdapter();
                    tc.ClearBeforeFill = true;
                    tc.Fill(dsc._V_CotizacionCargos, numeroReserva);

                    dsMontoPATableAdapters._MontoPuntoAceleradoTableAdapter tm = new dsMontoPATableAdapters._MontoPuntoAceleradoTableAdapter();
                    tm.ClearBeforeFill = true;
                    tm.Fill(dsm._MontoPuntoAcelerado);

                    dsTemporadaTITableAdapters._temporada_TITableAdapter tt = new dsTemporadaTITableAdapters._temporada_TITableAdapter();
                    tt.ClearBeforeFill = true;
                    tt.Fill(dstemp._temporada_TI, ini, fin);

                    dsConcaTemporadasTableAdapters._sp_ConcaTemporadaTableAdapter ct = new dsConcaTemporadasTableAdapters._sp_ConcaTemporadaTableAdapter();
                    ct.ClearBeforeFill = true;
                    ct.Fill(dsConcaTempCoti._sp_ConcaTemporada, ini, fin, "COCHE PUNTA BLANCA");

                    dsConcaTemporadasTableAdapters._sp_ConcaTemporadaTableAdapter ct1 = new dsConcaTemporadasTableAdapters._sp_ConcaTemporadaTableAdapter();
                    ct1.ClearBeforeFill = true;
                    ct1.Fill(dsConcaTempCoti._sp_ConcaTemporada, ini, fin, "ISLA CARIBE");

                    ReportParameter[] parameters = new ReportParameter[2];
                    parameters[0] = new ReportParameter("reserva", numeroReserva.ToString());
                    parameters[1] = new ReportParameter("usuario", user);
                    _reportViewer.LocalReport.SetParameters(parameters);
                    _reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
                    _reportViewer.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;

                    _reportViewer.RefreshReport();
                    dereserva = false;
                }
            }
        }

        private void btnImprimirCA_Click(object sender, RoutedEventArgs e)
        {
            mostrarConfirmacionCostaAzul();
        }

        private void dtgrdContratos_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            object item = dtgrdContratos.SelectedItem;
            if (item != null)
            {
                contrato = Convert.ToString((dtgrdContratos.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text);
                reservacion rs = new reservacion();
                dtgRsvECC.ItemsSource = rs.buscar_reservas_por_ncontrato(contrato);

                /*
                if (dtgRsvECC.Items.Count >0)*/
                btnImpr.IsEnabled = true;

            }
            
        }

        private void tbReportesEdoCtaCli_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void tbReportesEdoCtaCli_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void txtcedula_KeyDown(object sender, KeyEventArgs e)
        {

            cliente cli = new cliente();
            dtgrdContratos.ItemsSource = cli.buscar_contratos(txtcedula.Text, "", "");

        }

        private void txtcedula_KeyUp(object sender, KeyEventArgs e)
        {
            cliente cli = new cliente();
            dtgRsvECC.ItemsSource = null;
            btnImpr.IsEnabled = false;
            dtgrdContratos.ItemsSource = cli.buscar_contratos(txtcedula.Text, "", "");
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtNombre_KeyUp(object sender, KeyEventArgs e)
        {
            cliente cli = new cliente();
            dtgRsvECC.ItemsSource = null;
            btnImpr.IsEnabled = false;
            dtgrdContratos.ItemsSource = cli.buscar_contratos("", txtNombre.Text, "");
        }

        private void txtContrato_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtContrato_KeyUp(object sender, KeyEventArgs e)
        {
            cliente cli = new cliente();
            dtgRsvECC.ItemsSource=null;
            btnImpr.IsEnabled = false;
            dtgrdContratos.ItemsSource = cli.buscar_contratos("", "", txtContrato.Text);
        }

        private void btnImpr_Click(object sender, RoutedEventArgs e)
        {
            reporteEdoCtaCliCon recc = new reporteEdoCtaCliCon();
            recc.ncontrato = contrato;
            recc.ShowDialog();
        }

        private void txtAnioRPA_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox tb = sender as TextBox;
            int i = 0;
            if (!int.TryParse(Convert.ToString(tb.Text), out i) && tb.Text != "")
                tb.Text = "";
            else if (tb.Text.Contains(" "))
                tb.Text = "";
            
        }

        private void btnImprRPA_Click(object sender, RoutedEventArgs e)
        {
            //_rptRPA

            if (txtAnioRPA.Text != "" && txtAnioRPAHasta.Text != "")
            {
                if (Convert.ToInt32(txtAnioRPA.Text) > Convert.ToInt32(txtAnioRPAHasta.Text))
                {
                    MessageBox.Show("El Año Desde no debe ser mayor que el Año Hasta", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;

                }

            }

            
               


            _rptRPA.Clear();
            _rptRPA.Reset();


            dsRPAGral dsRPAG = new dsRPAGral();
            ReportDataSource rdsPAG = new ReportDataSource();
            dsRPAG.EnforceConstraints = false;
            dsRPAG.Clear();
            
            dsRPAG.BeginInit();
            rdsPAG.Name = "DataSet1";
            rdsPAG.Value = dsRPAG.RelacionPuntosPorAnio;
            _rptRPA.LocalReport.DataSources.Add(rdsPAG);
            dsRPAG.EndInit();
            _rptRPA.LocalReport.ReportEmbeddedResource = "Reservas.reporteRPAG.rdlc";
            dsRPAGralTableAdapters.RelacionPuntosPorAnioTableAdapter ta = new dsRPAGralTableAdapters.RelacionPuntosPorAnioTableAdapter();
            ta.ClearBeforeFill=true;


            int aniodesde, aniohasta;
            string param;

            if (txtAnioRPA.Text == "" && txtAnioRPAHasta.Text == ""){
                ta.FillGral(dsRPAG.RelacionPuntosPorAnio);
                param = "TODOS";
            }
            else {

                if (txtAnioRPA.Text != "" && txtAnioRPAHasta.Text != ""){

                    aniodesde=Convert.ToInt32(txtAnioRPA.Text);
                    aniohasta=Convert.ToInt32(txtAnioRPAHasta.Text);
                    param = txtAnioRPA.Text + " HASTA " + txtAnioRPAHasta.Text;
                }
                else if (txtAnioRPA.Text != "") {

                    aniodesde=Convert.ToInt32(txtAnioRPA.Text);
                    aniohasta=Convert.ToInt32(txtAnioRPA.Text);
                    param = txtAnioRPA.Text;
                }
                else {

                    aniodesde=Convert.ToInt32(txtAnioRPAHasta.Text);
                    aniohasta=Convert.ToInt32(txtAnioRPAHasta.Text);
                    param = txtAnioRPAHasta.Text;

                }

                ta.FillAnio(dsRPAG.RelacionPuntosPorAnio,aniodesde,aniohasta);


            }
                


            ReportParameter[] parameters = new ReportParameter[1];
            parameters[0] = new ReportParameter("Param", param);

            _rptRPA.LocalReport.SetParameters(parameters);
            _rptRPA.SetDisplayMode(DisplayMode.PrintLayout);
            _rptRPA.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
            _rptRPA.RefreshReport();


        }

        /*
         
         private void btnImprimirReservas_Click(object sender, RoutedEventArgs e)
        {
            if (dtgReservasReporte.Items.Count > 0)
            {
                reporteReserva rc = new reporteReserva();
                rc.cliente = gRcliente;
                rc.contrato = gRcontrato;
                rc.fecha = gRfecha;
                rc.fechaf = gRfechaf;
                rc.status = gRstatus;
                rc.reserva = gRreserva;
                rc.Show();
            }
        }
         
         
         */


    }



}



       
    

        
        

       
    

