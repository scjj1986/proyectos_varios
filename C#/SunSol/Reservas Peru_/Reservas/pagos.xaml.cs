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
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel;
using System.Globalization;


namespace Reservas
{
    /// <summary>
    /// Lógica de interacción para pagos.xaml
    /// </summary>
    public partial class pagos : Page
    {
        MouseButtonEventArgs e1;
        int numeroReserva = 0, item = 0;
        public string user,contratos;
        public usuario us;
        DataTable dtCar;
        double todoIncluido = 0, puntosAcelerados = 0,saldoReserva=0,totalReserva;
        List<trasaccionPago> tmp;
        List<cargos> car;
        dsCotizacionHotel dsHotelTI = new dsCotizacionHotel();


        public pagos()
        {
            InitializeComponent();
            lstCargos1.Items.Add("TODO INCLUIDO");
            lstCargos1.Items.Add("PUNTOS ACELERADOS");

            /*
            
            lstTransaccion.Items.Add("DEPÓSITO");
            lstTransaccion.Items.Add("CHEQUE");
            lstTransaccion.Items.Add("DÉBITO");
            lstTransaccion.Items.Add("CRÉDITO");
            lstTransaccion.Items.Add("TRANSFERENCIA");
            lstTransaccion.Items.Add("EFECTIVO");*/


            formasdepago fdp = new formasdepago();
            //lstTransaccion.ItemsSource = null;
            lstTransaccion.ItemsSource = fdp.listaractivas();
            lstTransaccion.DisplayMemberPath = "descripcion";
            lstTransaccion.SelectedValuePath = "codigo";

            banco bnc = new banco();
            lstCuenta.ItemsSource = bnc.listaractivos();
            lstCuenta.DisplayMemberPath = "descripcion";
            lstCuenta.SelectedValuePath = "codigo";


            






            /*

            lstCuenta.Items.Add("ACTIVO VACATION");
            lstCuenta.Items.Add("BOD VACATION");
            lstCuenta.Items.Add("BANESCO VACATION");
            lstCuenta.Items.Add("BICENTENARIO VACATION");
            lstCuenta.Items.Add("EXTERIOR VACATION");
            lstCuenta.Items.Add("MERCANTIL VACATION");
            lstCuenta.Items.Add("PROVINCIAL VACATION");
            lstCuenta.Items.Add("VENEZUELA VACATION");
            lstCuenta.Items.Add("ACTIVO VACATION");
            lstCuenta.Items.Add("BANESCO ARMIL");
            lstCuenta.Items.Add("BOD ARMIL");
            lstCuenta.Items.Add("EXTERIOR ARMIL");
            lstCuenta.Items.Add("BOD CORPORACION HOTELERA EL TIRANO");
            lstCuenta.Items.Add("BANESCO CORPORACION HOTELERA EL TIRANO");
            lstCuenta.Items.Add("EXTERIOR CORPORACION HOTELERA EL TIRANO");*/


            lstAnnio.Items.Clear();
            int anio = DateTime.Today.Year;
            anio = anio - 2;
            for (int a = anio; a <= anio + 30;a++)
            {
                lstAnnio.Items.Add(a.ToString());
            }

                //lsttipo.Items.Add("TDD PTO. MERCANTIL");                                                         
                //lsttipo.Items.Add("VISA");                                                      
                //lsttipo.Items.Add("TDC BANESCO 5401/4966 PTO BAN");                              
                //lsttipo.Items.Add("PLAN DE PAGO PREF. PTO. CORP BANCA");                        
                //lsttipo.Items.Add("CREDICONSUMO PTO. EXTERIOR");                                 
                //lsttipo.Items.Add("CREDICOMPRA PTO. VZLA");                                      
                //lsttipo.Items.Add("MASTER CARD");                                                 
                //lsttipo.Items.Add("TDC OTROS BCOS PTO. BANESCO");                                
                //lsttipo.Items.Add("TDC TODOS LOS BCOS PTO. CORP BANCA");                         
                //lsttipo.Items.Add("TDC TODOS LOS BCOS PTO. EXTERIOR");                           
                //lsttipo.Items.Add("TDC TODOS LOS BCOS. PTO. VZLA");                               
                //lsttipo.Items.Add("AMERICAN EXPRESS");                                           
                //lsttipo.Items.Add("DD PTO. BANESCO 6012");                                      
                //lsttipo.Items.Add("TDC AMEX PTO. CORP.BANCA");                                   
                //lsttipo.Items.Add("TDD PTO. EXTERIOR");                                           
                //lsttipo.Items.Add("TDD Y ELECTRON PTO. VENEZUELA");                              
                //lsttipo.Items.Add("DINERS CLUB");                                                
                //lsttipo.Items.Add("EXTRACREDITOS BANESCO PTO. BANESCO");                         
                //lsttipo.Items.Add("TDD PTO. CORP BANCA");                                         
                //lsttipo.Items.Add("TARJETA ELECTRON PTO. EXTERIOR");                             
                //lsttipo.Items.Add("TDC OTROS BANCOS PTO. MERCANTIL");
                //lsttipo.Items.Add("TDC MERCANTIL PTO. MERCANTIL");

            lstHolel.Items.Add("COCHE PUNTA BLANCA");
            lstHolel.Items.Add("ISLA CARIBE");

            tipotarjeta tt = new tipotarjeta();
            lsttipo.ItemsSource = tt.listaractivas();
            lsttipo.DisplayMemberPath="descripcion";
            lsttipo.SelectedValuePath = "codigo";
            lsttipo.IsEnabled = false;

            /*
            lsttipo.Items.Add("AMERICAN EXPRESS");
            lsttipo.Items.Add("DEBITO MAESTRO");
            lsttipo.Items.Add("DINERS CLUB"); 
            lsttipo.Items.Add("MASTER CARD");
            lsttipo.Items.Add("VISA"); */
                                  

            reservacion res = new reservacion();
            SqlDataReader sr = res.buscar_cargos();
            int i = 0;

            if (sr != null)
            {

                while (sr.Read())
                {
                    lstCargos.Items.Add(sr.GetString(i));
                    lstCargos1.Items.Add(sr.GetString(i));
                }
                sr.Close();

            }
            //SqlDataReader sr1 = res.buscar_bancos();
            //i = 0;
            //while (sr1.Read())
            //{
            //    lstBancos.Items.Add(sr1.GetString(i));
            //}
            
        }
        public void cargarPagos(int reserva)
        {
            reservacion res = new reservacion();
            
           
            SqlDataReader sr1 = res.buscar_pagosT(reserva);
            tmp = new List<trasaccionPago>();
            if (sr1 != null)
            {
                if (sr1.HasRows)
                {
                    while (sr1.Read())
                    {
                        tmp.Add(new trasaccionPago()
                        {
                            concepto = sr1.GetString(0).Trim(new char[] { ' ' }),
                            trasaccion = sr1.GetString(1).Trim(new char[] { ' ' }),
                            documento = sr1.GetString(2).Trim(new char[] { ' ' }),
                            monto = sr1.GetDouble(3),
                            fecha = sr1.GetDateTime(4).ToShortDateString().Trim(new char[] { ' ' }),
                            observacion = sr1.GetString(5).Trim(new char[] { ' ' }),
                            confir = sr1.GetInt32(7),
                            puntosA=sr1.GetDouble(17),
                            referencia = sr1.GetInt32(8),
                            anula=sr1.GetInt32(9),
                            tipo = sr1.GetString(10).Trim(new char[] { ' ' }),                           
                            cuenta = sr1.GetString(12).Trim(new char[] { ' ' }),
                            hotel=sr1.GetString(14).Trim(new char[] { ' ' }),
                            ejecutivo = sr1.GetString(15).Trim(new char[] { ' ' }),
                            estatus = "",
                            anulado="",
                            
                        });
                    }

                    dtgConfirmar.ItemsSource = tmp;
                    dtgConfirmar.Items.Refresh();
                    if (dtgConfirmar.ItemsSource != null)
                    {
                        foreach (trasaccionPago p in dtgConfirmar.ItemsSource)
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
                sr1.Close();
            }
            
            
            SqlDataReader sr2=res.buscar_cargosR(numeroReserva);
            car = new List<cargos>();
             if (sr2 != null)
             {
                 if (sr2.HasRows)
                 {
                    
                     while (sr2.Read())
                     {
                        car.Add(new cargos() { 
                       
                        concepto=sr2.GetString(0).Trim(new char[] {' '}),
                        monto=sr2.GetDouble(1),
                        anular=sr2.GetInt32(3),
                        anio = sr2.GetString(4).Trim(new char[] { ' ' }),
                        observacion = sr2.GetString(5).Trim(new char[] { ' ' })
                        });
                     }
                 }
                 dtgMostrarCargos.ItemsSource = car;
                 if (dtgMostrarCargos.ItemsSource != null)
                 {
                     foreach (cargos p in dtgMostrarCargos.ItemsSource)
                     {
                         
                         if (p.anular== 0)
                             p.anulado= "NO";
                         else
                             p.anulado = "SI";
                     }
                 }
             }
            
        }

        private void btnAgregarPago_Click(object sender, RoutedEventArgs e)
        {
            if (lstTransaccion.SelectedIndex != -1)
            {
                DateTime? f = dpfechatransaccion.SelectedDate;
                //


                //----------------------- Código Juan (01-06-2017) ----------------//
                formasdepago itm = lstTransaccion.SelectedItem as formasdepago;

                banco bnk = lstCuenta.SelectedItem as banco;

               
                //-----------------------------------------------------------------//



                //if (lstTransaccion.SelectedItem.ToString().Equals("EFECTIVO") || lstTransaccion.SelectedItem.ToString().Equals("CHEQUE"))
                if (itm.descripcion.Equals("EFECTIVO") || itm.descripcion.Equals("CHEQUE"))
                {
                    if ((txtmonto1.Text.Equals("")) || (lstCargos1.SelectedIndex == -1) || txtdocumento.Text.Equals("") || lstTransaccion.SelectedIndex == -1 || f == null)
                    {
                        MessageBox.Show("Debe llenar todos los campos para agregar el pago a la reserva", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                }
                else
                {
                    if ((txtmonto1.Text.Equals("")) || (lstCargos1.SelectedIndex == -1) || txtdocumento.Text.Equals("") || lstTransaccion.SelectedIndex == -1 || f == null || lstCuenta.SelectedIndex == -1)
                    {
                        MessageBox.Show("Debe llenar todos los campos para agregar el pago a la reserva", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                }
                //if (lstTransaccion.SelectedItem.ToString().Equals("DÉBITO") || lstTransaccion.SelectedItem.ToString().Equals("CRÉDITO"))
                if (itm.descripcion.Equals("TDB") || itm.descripcion.Equals("TDC"))
                {
                    if ((lsttipo.Text.Equals("")) || lstCuenta.SelectedIndex == -1)
                    {
                        MessageBox.Show("Debe llenar todos los campos para agregar el pago a la reserva", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }


                }
                //if (lstTransaccion.SelectedItem.ToString().Equals("DEPÓSITO") || lstTransaccion.SelectedItem.ToString().Equals("TRANSFERENCIA"))
                //{
                //    if (lstCuenta.SelectedIndex == -1)
                //    {
                //        MessageBox.Show("Debe todos los campos para agregar el pago a la reserva", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                //        return;
                //    }
                //}
                if (dtgConfirmar.ItemsSource != null)
                {
                
                foreach (trasaccionPago tp in dtgConfirmar.ItemsSource)
                {
                    if (tp.documento == txtdocumento.Text)
                    {

                        MessageBox.Show("El numero de documento ya esta registrado", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                }
                }

                if (lstCargos1.SelectedItem.ToString().Equals("TODO INCLUIDO") && (todoIncluido == 0))
                {
                    MessageBox.Show("La reserva no tiene monto para todo incluido", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                if (lstCargos1.SelectedItem.ToString().Equals("TODO INCLUIDO"))
                {

                    if (Convert.ToDouble(txtmonto1.Text) > todoIncluido)
                    {
                        MessageBox.Show("El monto excede al saldo por todo incluido de la reserva", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    todoIncluido = todoIncluido - Convert.ToDouble(txtmonto1.Text);
                }

                if (lstCargos1.SelectedItem.ToString().Equals("PUNTOS ACELERADOS") && (puntosAcelerados == 0))
                {
                    MessageBox.Show("La reserva no tiene monto para puntos acelerados", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (lstCargos1.SelectedItem.ToString().Equals("PUNTOS ACELERADOS"))
                {
                    if (Convert.ToDouble(txtmonto1.Text) > puntosAcelerados)
                    {
                        MessageBox.Show("El monto excede al saldo por puntos acelereados de la reserva", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    puntosAcelerados = puntosAcelerados - Convert.ToDouble(txtmonto1.Text);
                }
                if (Convert.ToDouble(txtmonto1.Text) == 0)
                {
                    MessageBox.Show("Debe colocar un monto para agregar el pago a la reserva", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                reservacion res=new reservacion();
                if (res.existeNdocuemento(txtdocumento.Text) == 1)
                {
                    MessageBox.Show("Existe un pago registrado con ese número de documento", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    txtdocumento.Focus();
                    return;
                }
                item++;
                if (tmp == null)
                    tmp = new List<trasaccionPago>();
                double puntosAc = 0;
                if (!lstCargos1.SelectedItem.ToString().Equals("PUNTOS ACELERADOS"))
                    txtpuntosA.Text = "";
                if (txtpuntosA.Text.Equals(""))
                    puntosAc = 0;
                else
                    puntosAc = Convert.ToDouble(txtpuntosA.Text);

                //----------------------- Código Juan (01-06-2017) ----------------//
                //formasdepago itm = lstTransaccion.SelectedItem as formasdepago;
                //Console.WriteLine(itm.descripcion);
                //if (itm.descripcion.Equals("TDB") || itm.descripcion.Equals("TDC"))
                //-----------------------------------------------------------------//

                
                //if (lstTransaccion.SelectedItem.ToString().Equals("TDC") || lstTransaccion.SelectedItem.ToString().Equals("TDB"))
                if (itm.descripcion.Equals("TDC") || itm.descripcion.Equals("TDB"))
                {

                    if (lstCargos1.SelectedItem.ToString().Equals("TODO INCLUIDO") || (lstCargos1.SelectedItem.ToString().Trim(new char[] { ' ' }).Equals("SUPLEMENTO NAVIDAD")) || (lstCargos1.SelectedItem.ToString().Trim(new char[] { ' ' }).Equals("SUPLEMENTO CENA FIN DE AÑO")))
                    {
                        tmp.Add(new trasaccionPago()
                        {
                            concepto = lstCargos1.Items[lstCargos1.SelectedIndex].ToString().Trim(new char[] { ' ' }),
                            //trasaccion = lstTransaccion.SelectedItem.ToString(),
                            trasaccion = itm.descripcion,
                            documento = txtdocumento.Text,
                            monto = Convert.ToDouble(txtmonto1.Text),
                            fecha = dpfechatransaccion.SelectedDate.Value.ToShortDateString(),
                            observacion = txtobservacion.Text.ToUpper(),
                            confir = 0,
                            // banco = lstBancos.SelectedItem.ToString(),
                            cuenta = bnk.descripcion,
                            referencia = 0,
                            //cuenta = lstCuenta.SelectedItem.ToString(),
                            tipo = lsttipo.Text,
                            hotel = lstHolel.SelectedItem.ToString(),
                            anula = 0,
                            estatus = "",
                            puntosA = puntosAc,
                            anulado = ""
                        });
                    }
                    else
                    {

                        tmp.Add(new trasaccionPago()
                        {
                            concepto = lstCargos1.Items[lstCargos1.SelectedIndex].ToString(),
                            //trasaccion = lstTransaccion.SelectedItem.ToString(),
                            trasaccion = itm.descripcion,
                            documento = txtdocumento.Text,
                            monto = Convert.ToDouble(txtmonto1.Text),
                            fecha = dpfechatransaccion.SelectedDate.Value.ToShortDateString(),
                            observacion = txtobservacion.Text.ToUpper(),
                            confir = 0,
                            // banco = lstBancos.SelectedItem.ToString(),
                            cuenta = bnk.descripcion,
                            referencia = 0,
                            //cuenta = lstCuenta.SelectedItem.ToString(),
                            tipo = lsttipo.Text,
                            hotel = "N/A",
                            anula = 0,
                            estatus = "",
                            puntosA = puntosAc,
                            anulado = ""
                        });
                    }

                }
                else
                {
                    //if (lstTransaccion.SelectedItem.ToString().Equals("DEPÓSITO") || lstTransaccion.SelectedItem.ToString().Equals("TRANSFERENCIA"))
                    if (itm.descripcion.Equals("DEP") || itm.descripcion.Equals("TRANSF"))
                    
                    {
                        if (lstCargos1.SelectedItem.ToString().Equals("TODO INCLUIDO") || (lstCargos1.SelectedItem.ToString().Trim(new char[] { ' ' }).Equals("SUPLEMENTO NAVIDAD")) || (lstCargos1.SelectedItem.ToString().Trim(new char[] { ' ' }).Equals("SUPLEMENTO CENA FIN DE AÑO")))
                        {
                            tmp.Add(new trasaccionPago()
                            {
                                concepto = lstCargos1.Items[lstCargos1.SelectedIndex].ToString().Trim(new char[] { ' ' }),
                                trasaccion = lstTransaccion.SelectedItem.ToString(),
                                documento = txtdocumento.Text,
                                monto = Convert.ToDouble(txtmonto1.Text),
                                fecha = dpfechatransaccion.SelectedDate.Value.ToShortDateString(),
                                observacion = txtobservacion.Text,
                                confir = 0,
                                //banco = lstBancos.SelectedItem.ToString(),
                                referencia = 0,
                                cuenta = lstCuenta.SelectedItem.ToString(),
                                tipo = "N/A",
                                hotel = lstHolel.SelectedItem.ToString(),
                                anula = 0,
                                estatus = "",
                                puntosA = puntosAc,
                                anulado = ""
                            });
                        }
                        else
                        {
                            tmp.Add(new trasaccionPago()
                            {
                                concepto = lstCargos1.Items[lstCargos1.SelectedIndex].ToString(),
                                trasaccion = lstTransaccion.SelectedItem.ToString(),
                                documento = txtdocumento.Text,
                                monto = Convert.ToDouble(txtmonto1.Text),
                                fecha = dpfechatransaccion.SelectedDate.Value.ToShortDateString(),
                                observacion = txtobservacion.Text,
                                confir = 0,
                                puntosA = puntosAc,
                                //banco = lstBancos.SelectedItem.ToString(),
                                referencia = 0,
                                cuenta = lstCuenta.SelectedItem.ToString(),
                                tipo = "N/A",
                                hotel = "N/A",
                                anula = 0,
                                estatus = "",
                                anulado = ""
                            });
                        }

                    }
                    else
                    {
                        //if (lstTransaccion.SelectedItem.ToString().Equals("CHEQUE") || lstTransaccion.SelectedItem.ToString().Equals("EFECTIVO"))
                        if (itm.descripcion.Equals("EFECTIVO") || itm.descripcion.Equals("CHEQUE"))
                        {
                            //string banco = "";
                            if (lstCargos1.SelectedItem.ToString().Equals("TODO INCLUIDO") || (lstCargos1.SelectedItem.ToString().Trim(new char[] { ' ' }).Equals("SUPLEMENTO NAVIDAD")) || (lstCargos1.SelectedItem.ToString().Trim(new char[] { ' ' }).Equals("SUPLEMENTO CENA FIN DE AÑO")))
                            {
                                //if (lstBancos.SelectedItem == null)
                                //    banco = "NO BANCO";
                                tmp.Add(new trasaccionPago()
                                {
                                    concepto = lstCargos1.Items[lstCargos1.SelectedIndex].ToString().Trim(new char[] { ' ' }),
                                    trasaccion = lstTransaccion.SelectedItem.ToString(),
                                    documento = txtdocumento.Text,
                                    monto = Convert.ToDouble(txtmonto1.Text),
                                    fecha = dpfechatransaccion.SelectedDate.Value.ToShortDateString(),
                                    observacion = txtobservacion.Text,
                                    confir = 0,
                                    // banco = banco,
                                    referencia = 0,
                                    cuenta = "N/A",
                                    tipo = "N/A",
                                    hotel = lstHolel.SelectedItem.ToString(),
                                    anula = 0,
                                    estatus = "",
                                    puntosA = puntosAc,
                                    anulado = ""
                                });
                            }
                            else
                            {
                                tmp.Add(new trasaccionPago()
                                {
                                    concepto = lstCargos1.Items[lstCargos1.SelectedIndex].ToString(),
                                    trasaccion = lstTransaccion.SelectedItem.ToString(),
                                    documento = txtdocumento.Text,
                                    monto = Convert.ToDouble(txtmonto1.Text),
                                    fecha = dpfechatransaccion.SelectedDate.Value.ToShortDateString(),
                                    observacion = txtobservacion.Text,
                                    confir = 0,
                                    // banco = banco,
                                    referencia = 0,
                                    cuenta = "N/A",
                                    tipo = "N/A",
                                    hotel = "N/A",
                                    anula = 0,
                                    estatus = "",
                                    puntosA = puntosAc,
                                    anulado = ""
                                });
                            }
                        }


                    }


                }



                /* for (int i = 0; i <= dtPa.Rows.Count - 1; i++)
                 {
                     if (dtPa.Rows[i][1].ToString().Equals(lstCargos1.SelectedItem.ToString())&&dtPa.Rows[i][4].ToString().Equals(txtdocumento.Text))
                     {
                         MessageBox.Show("Ya hay un concepto registrado con ese nombre", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                         item--;
                         return;
                     }
                 }*/


                // btnQuitarPago.IsEnabled = true;
                lstCargos1.SelectedIndex = -1;
                txtmonto1.Text = "";
                lstTransaccion.SelectedIndex = -1;
                txtdocumento.Text = "";
                dpfechatransaccion.SelectedDate = null;
                //lstBancos.SelectedIndex = -1;
                txtobservacion.Text = "";
                lstCuenta.SelectedIndex = -1;
                lsttipo.Text = "";
                lstHolel.SelectedIndex = -1;
                txtpuntosA.Text = "";

                dtgConfirmar.ItemsSource = tmp;
                dtgConfirmar.Items.Refresh();

                foreach (trasaccionPago p in dtgConfirmar.ItemsSource)
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

        private void txtNroReserva_KeyUp(object sender, KeyEventArgs e)
        {
            DateTime? f = dpfecha.SelectedDate;
            reservacion res = new reservacion();
            dtgConfirmar.ItemsSource = null;
            dtgMostrarCargos.ItemsSource = null;
            lbltitulo.Content = "";
            if ((txtCliente.Text.Equals("")) && (txtNroContrato.Text.Equals("")) && (f == null))
                dtgReservas.ItemsSource = res.buscar_reservaPa(txtNroReserva.Text, "0", "", "0");
            else
            {
              
                if ((!txtCliente.Text.Equals("")) && (txtNroContrato.Text.Equals("")) && (f == null))
                    dtgReservas.ItemsSource = res.buscar_reservaPa(txtNroReserva.Text, txtCliente.Text, "", "0");
                else
                {
                    if ((!txtCliente.Text.Equals("")) && (!txtNroContrato.Text.Equals("")) && (f == null))
                        dtgReservas.ItemsSource = res.buscar_reservaPa(txtNroReserva.Text, txtCliente.Text, "", txtNroContrato.Text);
                    else
                    {
                        if ((!txtCliente.Text.Equals("")) && (!txtNroContrato.Text.Equals("")) && (f != null))
                        {
                            String[] ini = f.Value.ToShortDateString().Split('/');
                            String fechI = ini[2] + "/" + ini[1] + "/" + ini[0];
                            dtgReservas.ItemsSource = res.buscar_reservaPa(txtNroReserva.Text, txtCliente.Text, fechI, txtNroContrato.Text);
                        }

                    }
                }
            }
        }

        private void txtCliente_KeyUp(object sender, KeyEventArgs e)
        {
            DateTime? f = dpfecha.SelectedDate;
            reservacion res = new reservacion();
            dtgConfirmar.ItemsSource = null;
            dtgMostrarCargos.ItemsSource = null;
            lbltitulo.Content = "";
            if ((txtNroReserva.Text.Equals("")) && (txtNroContrato.Text.Equals("")) && (f == null))
                dtgReservas.ItemsSource = res.buscar_reservaPa("0", txtCliente.Text, "", "0");
            else
            {
               
                if ((!txtNroReserva.Text.Equals("")) && (txtNroContrato.Text.Equals("")) && (f == null))
                    dtgReservas.ItemsSource = res.buscar_reservaPa(txtNroReserva.Text, txtCliente.Text, "", "0");
                else
                {
                    if ((!txtNroReserva.Text.Equals("")) && (!txtNroContrato.Text.Equals("")) && (f == null))
                        dtgReservas.ItemsSource = res.buscar_reservaPa(txtNroReserva.Text, txtCliente.Text, "", txtNroContrato.Text);
                    else
                    {
                        if ((!txtNroReserva.Text.Equals("")) && (!txtNroContrato.Text.Equals("")) && (f != null))
                        {
                            String[] ini = f.Value.ToShortDateString().Split('/');
                            String fechI = ini[2] + "/" + ini[1] + "/" + ini[0];
                            dtgReservas.ItemsSource = res.buscar_reservaPa(txtNroReserva.Text, txtCliente.Text, fechI, txtNroContrato.Text);
                        }

                    }
                }
            }
        }

        private void txtNroContrato_KeyUp(object sender, KeyEventArgs e)
        {
            DateTime? f = dpfecha.SelectedDate;
            reservacion res = new reservacion();
            dtgConfirmar.ItemsSource = null;
            dtgMostrarCargos.ItemsSource = null;
            lbltitulo.Content = "";
            if ((txtCliente.Text.Equals("")) && (txtNroReserva.Text.Equals("")) && (f == null))
                dtgReservas.ItemsSource = res.buscar_reservaPa("0", "0", "", txtNroContrato.Text);
            else
            {
               
                if ((!txtCliente.Text.Equals("")) && (txtNroReserva.Text.Equals("")) && (f == null))
                    dtgReservas.ItemsSource = res.buscar_reservaPa("0", txtCliente.Text, "", txtNroContrato.Text);
                else
                {
                    if ((!txtCliente.Text.Equals("")) && (!txtNroReserva.Text.Equals("")) && (f == null))
                        dtgReservas.ItemsSource = res.buscar_reservaPa(txtNroReserva.Text, txtCliente.Text, "", txtNroContrato.Text);
                    else
                    {
                        if ((!txtCliente.Text.Equals("")) && (!txtNroReserva.Text.Equals("")) && (f != null))
                        {
                            String[] ini = f.Value.ToShortDateString().Split('/');
                            String fechI = ini[2] + "/" + ini[1] + "/" + ini[0];
                            dtgReservas.ItemsSource = res.buscar_reservaPa(txtNroReserva.Text, txtCliente.Text, fechI, txtNroContrato.Text);
                        }

                    }
                }
            }
        }

        private void dpfecha_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? f = dpfecha.SelectedDate;
            dtgConfirmar.ItemsSource = null;
            dtgMostrarCargos.ItemsSource = null;
            lbltitulo.Content = "";
            if (f != null)
            {
                String[] ini = f.Value.ToShortDateString().Split('/');
                String fechI = ini[2] + "/" + ini[1] + "/" + ini[0];
                reservacion res = new reservacion();
                if ((txtCliente.Text.Equals("")) && (txtNroReserva.Text.Equals("")) && (txtNroContrato.Text.Equals("")))
                    dtgReservas.ItemsSource = res.buscar_reservaPa("0", "0", fechI, "0");
                else
                {
                    
                    if ((!txtCliente.Text.Equals("")) && (txtNroReserva.Text.Equals("")) && (txtNroContrato.Text.Equals("")))
                        dtgReservas.ItemsSource = res.buscar_reservaPa("0", txtCliente.Text, fechI, "0");
                    else
                    {
                        if ((!txtCliente.Text.Equals("")) && (!txtNroReserva.Text.Equals("")) && (txtNroContrato.Text.Equals("")))
                            dtgReservas.ItemsSource = res.buscar_reservaPa(txtNroReserva.Text, txtCliente.Text, fechI, "0");
                        else
                        {
                            if ((!txtCliente.Text.Equals("")) && (!txtNroReserva.Text.Equals("")) && (!txtNroContrato.Text.Equals("")))
                            {

                                dtgReservas.ItemsSource = res.buscar_reservaPa(txtNroReserva.Text, txtCliente.Text, fechI, txtNroContrato.Text);
                            }

                        }
                    }
                }
            }
        }

        private void btnQuitarPago_Click(object sender, RoutedEventArgs e)
        {
           /* if (dtgCargos.Items.Count > 0)
            {
                dtPa.Rows.RemoveAt(dtPa.Rows.Count - 1);
                item--;
                dtgCargos.ItemsSource = dtPa.DefaultView;
                if (dtPa.Rows.Count == 0)
                {
                    btnQuitarPago.IsEnabled = false;
                    item = 0;

                }
                
            }*/
        }

        private void dtgReservas_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            object item = dtgReservas.SelectedItem;
            if ((dtgReservas.Items.Count > 0) && (item != null))
            {
                //dtgMostrar.ItemsSource = null;
                e1 = e;
                numeroReserva = Convert.ToInt32((dtgReservas.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
                saldoReserva = Convert.ToDouble((dtgReservas.SelectedCells[12].Column.GetCellContent(item) as TextBlock).Text);
                totalReserva = Convert.ToDouble((dtgReservas.SelectedCells[11].Column.GetCellContent(item) as TextBlock).Text);
                todoIncluido = Convert.ToDouble((dtgReservas.SelectedCells[6].Column.GetCellContent(item) as TextBlock).Text);
                puntosAcelerados = Convert.ToDouble((dtgReservas.SelectedCells[9].Column.GetCellContent(item) as TextBlock).Text);
                string cliente = (dtgReservas.SelectedCells[14].Column.GetCellContent(item) as TextBlock).Text;
                contratos = (dtgReservas.SelectedCells[15].Column.GetCellContent(item) as TextBlock).Text;
                int contrato = Convert.ToInt32((dtgReservas.SelectedCells[15].Column.GetCellContent(item) as TextBlock).Text);
                cliente cli = new cliente();
                cli.buscar_cliente(cliente,contrato.ToString());
                lbltitulo.Content = "Reserva N° ** " + numeroReserva.ToString() + " **Cliente: " + cli.nombres + " " + cli.apellidos + "** Contrato Nº" + contrato.ToString();
                cargarPagos(numeroReserva);
                dsHotelTI.Clear();
                dsCotizacionHotelTableAdapters._V_cotizacionHotelTableAdapter th = new dsCotizacionHotelTableAdapters._V_cotizacionHotelTableAdapter();
                th.ClearBeforeFill = true;
                DataTable t = new DataTable();
                DataTable t2 = new DataTable();
                t2.Columns.Add("hotel");
                t2.Columns.Add("monto");
                t = th.GetData(numeroReserva);
                
                for (int n = 0; n <= t.Rows.Count - 1; n++)
                {
                    if (t.Rows[n][11].ToString().Equals("COCHE PUNTA BLANCA") || t.Rows[n][11].ToString().Equals("ISLA CARIBE"))
                    {
                        DataRow r = t2.NewRow();
                        r[0] = t.Rows[n][11].ToString();
                        r[1] = Convert.ToDouble(t.Rows[n][3].ToString()).ToString("N2", CultureInfo.CreateSpecificCulture("es-VE"));
                        t2.Rows.Add(r);
                    }

                }
                dtgMontosTI.ItemsSource = t2.DefaultView;
                if (dtgConfirmar.ItemsSource != null)
                {
                    foreach (trasaccionPago p in dtgConfirmar.ItemsSource)
                    {
                        if (p.confir == 0)
                            p.IsSelected = false;
                        else
                            p.IsSelected = true;
                        if (p.anula == 0)
                            p.IsAnulado = false;
                        else
                            p.IsAnulado = true;
                    }
                }
                if (dtgMostrarCargos.ItemsSource != null)
                {
                    foreach (cargos c in dtgMostrarCargos.ItemsSource)
                    {
                        if (c.anular == 0)
                            c.IsSelected = false;
                        else
                            c.IsSelected = true;
                    }
                }
                btnAgregarPago.IsEnabled = true;
                btnGuardaPago.IsEnabled = true;
                btnAgregarCargo.IsEnabled = true;

                //btnGuardacargo.IsEnabled = true;
                //btnGuardaConfirmacion.IsEnabled = true;

            }
        }
        private void OnChecked(object sender, RoutedEventArgs e)
        {

        }

        private void btnGuardaPago_Click(object sender, RoutedEventArgs e)
        {
            bool cargo = false,pago=false;

            if (dtgMostrarCargos.Items.Count > 0)
            {
                
                    reservacion res = new reservacion();
                    res.actualizar_cargo(numeroReserva);
                    foreach (cargos c in dtgMostrarCargos.ItemsSource)
                    {
                        if (c.IsSelected)
                            res.agregar_cargo(numeroReserva, c.concepto, c.monto, 1, c.anio, c.observacion);
                        else
                        {
                            res.agregar_cargo(numeroReserva, c.concepto, c.monto, 0, c.anio, c.observacion);
                            //saldoReserva = saldoReserva - c.monto;
                        }
                    }
                    cargo = true;
                    //limpiar();
                

            }
            if (dtgConfirmar.Items.Count > 0)
            {
                pago = true;
                    reservacion res = new reservacion();
                    res.actualizar_pago(numeroReserva);
                    res.reservado_por = user;
                   foreach (trasaccionPago p in dtgConfirmar.ItemsSource)
                    {
                       
                        String[] ini = p.fecha.Split('/');
                        String fechI = ini[2] + "/" + ini[1] + "/" + ini[0];
                        if (p.trasaccion.Equals("DÉBITO") || p.trasaccion.Equals("CRÉDITO"))
                        {
                            if (p.concepto.Equals("TODO INCLUIDO") || (p.concepto.Equals("SUPLEMENTO NAVIDAD")) || (p.concepto.Equals("SUPLEMENTO CENA FIN DE AÑO")))
                            {
                                if (p.IsSelected && p.IsAnulado)
                                    res.agregar_Pago(numeroReserva, p.concepto, p.monto, p.trasaccion, p.documento, p.banco, fechI, p.observacion.ToUpper(), 1, 1, p.cuenta, p.tipo, p.hotel,p.puntosA);
                                if (!p.IsSelected && !p.IsAnulado)
                                    res.agregar_Pago(numeroReserva, p.concepto, p.monto, p.trasaccion, p.documento, p.banco, fechI, p.observacion.ToUpper(), 0, 0, p.cuenta, p.tipo, p.hotel, p.puntosA);
                                if (p.IsSelected && !p.IsAnulado)
                                    res.agregar_Pago(numeroReserva, p.concepto, p.monto, p.trasaccion, p.documento, p.banco, fechI, p.observacion.ToUpper(), 1, 0, p.cuenta, p.tipo, p.hotel, p.puntosA);
                                if (!p.IsSelected && p.IsAnulado)
                                    res.agregar_Pago(numeroReserva, p.concepto, p.monto, p.trasaccion, p.documento, p.banco, fechI, p.observacion.ToUpper(), 0, 1, p.cuenta, p.tipo, p.hotel, p.puntosA);
                            }
                            else
                            {
                                if (p.IsSelected && p.IsAnulado)
                                    res.agregar_Pago(numeroReserva, p.concepto, p.monto, p.trasaccion, p.documento, p.banco, fechI, p.observacion.ToUpper(), 1, 1, p.cuenta, p.tipo, "N/A", p.puntosA);
                                if (!p.IsSelected && !p.IsAnulado)
                                    res.agregar_Pago(numeroReserva, p.concepto, p.monto, p.trasaccion, p.documento, p.banco, fechI, p.observacion.ToUpper(), 0, 0, p.cuenta, p.tipo, "N/A", p.puntosA);
                                if (p.IsSelected && !p.IsAnulado)
                                    res.agregar_Pago(numeroReserva, p.concepto, p.monto, p.trasaccion, p.documento, p.banco, fechI, p.observacion.ToUpper(), 1, 0, p.cuenta, p.tipo, "N/A", p.puntosA);
                                if (!p.IsSelected && p.IsAnulado)
                                    res.agregar_Pago(numeroReserva, p.concepto, p.monto, p.trasaccion, p.documento, p.banco, fechI, p.observacion.ToUpper(), 0, 1, p.cuenta, p.tipo, "N/A", p.puntosA);
                            }
                        }
                        else
                        {
                            if (p.trasaccion.Equals("DEPÓSITO") || p.trasaccion.ToString().Equals("TRANSFERENCIA"))
                            {
                                if (p.concepto.Equals("TODO INCLUIDO") || (p.concepto.Equals("SUPLEMENTO NAVIDAD")) || (p.concepto.Equals("SUPLEMENTO CENA FIN DE AÑO")))
                                {
                                    if (p.IsSelected && p.IsAnulado)
                                        res.agregar_Pago(numeroReserva, p.concepto, p.monto, p.trasaccion, p.documento, p.banco, fechI, p.observacion.ToUpper(), 1, 1, p.cuenta, "N/A", p.hotel, p.puntosA);
                                    if (!p.IsSelected && !p.IsAnulado)
                                        res.agregar_Pago(numeroReserva, p.concepto, p.monto, p.trasaccion, p.documento, p.banco, fechI, p.observacion.ToUpper(), 0, 0, p.cuenta, "N/A", p.hotel, p.puntosA);
                                    if (p.IsSelected && !p.IsAnulado)
                                        res.agregar_Pago(numeroReserva, p.concepto, p.monto, p.trasaccion, p.documento, p.banco, fechI, p.observacion.ToUpper(), 1, 0, p.cuenta, "N/A", p.hotel, p.puntosA);
                                    if (!p.IsSelected && p.IsAnulado)
                                        res.agregar_Pago(numeroReserva, p.concepto, p.monto, p.trasaccion, p.documento, p.banco, fechI, p.observacion.ToUpper(), 0, 1, p.cuenta, "N/A", p.hotel, p.puntosA);
                                }
                                else
                                {
                                    if (p.IsSelected && p.IsAnulado)
                                        res.agregar_Pago(numeroReserva, p.concepto, p.monto, p.trasaccion, p.documento, p.banco, fechI, p.observacion.ToUpper(), 1, 1, p.cuenta, "N/A", "N/A", p.puntosA);
                                    if (!p.IsSelected && !p.IsAnulado)
                                        res.agregar_Pago(numeroReserva, p.concepto, p.monto, p.trasaccion, p.documento, p.banco, fechI, p.observacion.ToUpper(), 0, 0, p.cuenta, "N/A", "N/A", p.puntosA);
                                    if (p.IsSelected && !p.IsAnulado)
                                        res.agregar_Pago(numeroReserva, p.concepto, p.monto, p.trasaccion, p.documento, p.banco, fechI, p.observacion.ToUpper(), 1, 0, p.cuenta, "N/A", "N/A", p.puntosA);
                                    if (!p.IsSelected && p.IsAnulado)
                                        res.agregar_Pago(numeroReserva, p.concepto, p.monto, p.trasaccion, p.documento, p.banco, fechI, p.observacion.ToUpper(), 0, 1, p.cuenta, "N/A", "N/A", p.puntosA);
                                }
                            }
                            else
                            {
                                if (p.concepto.Equals("TODO INCLUIDO") || (p.concepto.Equals("SUPLEMENTO NAVIDAD")) || (p.concepto.Equals("SUPLEMENTO CENA FIN DE AÑO")))
                                {

                                    if (p.IsSelected && p.IsAnulado)
                                        res.agregar_Pago(numeroReserva, p.concepto, p.monto, p.trasaccion, p.documento, p.banco, fechI, p.observacion.ToUpper(), 1, 1, p.cuenta, "N/A", p.hotel, p.puntosA);
                                    if (!p.IsSelected && !p.IsAnulado)
                                        res.agregar_Pago(numeroReserva, p.concepto, p.monto, p.trasaccion, p.documento, p.banco, fechI, p.observacion.ToUpper(), 0, 0, p.cuenta, "N/A", p.hotel, p.puntosA);
                                    if (p.IsSelected && !p.IsAnulado)
                                        res.agregar_Pago(numeroReserva, p.concepto, p.monto, p.trasaccion, p.documento, p.banco, fechI, p.observacion.ToUpper(), 1, 0, p.cuenta, "N/A", p.hotel, p.puntosA);
                                    if (!p.IsSelected && p.IsAnulado)
                                        res.agregar_Pago(numeroReserva, p.concepto, p.monto, p.trasaccion, p.documento, p.banco, fechI, p.observacion.ToUpper(), 0, 1, p.cuenta, "N/A", p.hotel, p.puntosA);
                                }
                                else
                                {
                                    if (p.trasaccion.Equals("N/A"))
                                    {
                                        if (p.IsSelected && p.IsAnulado)
                                            res.agregar_Pago(numeroReserva, p.concepto, p.monto, p.trasaccion, p.documento, p.banco, fechI, p.observacion.ToUpper(), 1, 1, "N/A", "N/A", "N/A", p.puntosA);
                                        if (!p.IsSelected && !p.IsAnulado)
                                            res.agregar_Pago(numeroReserva, p.concepto, p.monto, p.trasaccion, p.documento, p.banco, fechI, p.observacion.ToUpper(), 0, 0, "N/A", "N/A", "N/A", p.puntosA);
                                        if (p.IsSelected && !p.IsAnulado)
                                            res.agregar_Pago(numeroReserva, p.concepto, p.monto, p.trasaccion, p.documento, p.banco, fechI, p.observacion.ToUpper(), 1, 0, "N/A", "N/A", "N/A", p.puntosA);
                                        if (!p.IsSelected && p.IsAnulado)
                                            res.agregar_Pago(numeroReserva, p.concepto, p.monto, p.trasaccion, p.documento, p.banco, fechI, p.observacion.ToUpper(), 0, 1, "N/A", "N/A", "N/A", p.puntosA);

                                    }
                                    else
                                    {
                                        if (p.IsSelected && p.IsAnulado)
                                            res.agregar_Pago(numeroReserva, p.concepto, p.monto, p.trasaccion, p.documento, p.banco, fechI, p.observacion.ToUpper(), 1, 1, "N/A", "N/A", "N/A", p.puntosA);
                                        if (!p.IsSelected && !p.IsAnulado)
                                            res.agregar_Pago(numeroReserva, p.concepto, p.monto, p.trasaccion, p.documento, p.banco, fechI, p.observacion.ToUpper(), 0, 0, "N/A", "N/A", "N/A", p.puntosA);
                                        if (p.IsSelected && !p.IsAnulado)
                                            res.agregar_Pago(numeroReserva, p.concepto, p.monto, p.trasaccion, p.documento, p.banco, fechI, p.observacion.ToUpper(), 1, 0, "N/A", "N/A", "N/A", p.puntosA);
                                        if (!p.IsSelected && p.IsAnulado)
                                            res.agregar_Pago(numeroReserva, p.concepto, p.monto, p.trasaccion, p.documento, p.banco, fechI, p.observacion.ToUpper(), 0, 1, "N/A", "N/A", "N/A", p.puntosA);
                                    }
                                }
                            }

                        }
                        
                            if (p.concepto.Equals("TODO INCLUIDO") && !p.IsAnulado && p.IsSelected)
                            {
                                totalReserva = totalReserva - p.monto;
                            }
                            if (p.concepto.Equals("PUNTOS ACELERADOS") && !p.IsAnulado && p.IsSelected)
                            {
                                totalReserva = totalReserva - p.monto;
                            }
                            if (p.concepto.Equals("NO TODO INCLUIDO") && !p.IsAnulado && p.IsSelected)
                            {
                                totalReserva = totalReserva - p.monto;
                            }
                           
                        
                            
                   }
                   
                   // limpiar();
                }
           if (cargo && pago == false)           
               MessageBox.Show("Se ha guardado correctamente los cargos", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
           if (cargo==false && pago)
               MessageBox.Show("Se ha guardado correctamente los pagos", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
           if (cargo && pago)
               MessageBox.Show("Se ha guardado correctamente los cambios", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
          
           txtNroReserva.Text = "";
           txtNroReserva.Text = numeroReserva.ToString();
           dtgConfirmar.ItemsSource = null;
           dtgMostrarCargos.ItemsSource = null;
           dtgMontosTI.ItemsSource = null;
           btnAgregarPago.IsEnabled = false;

          
         
        }

        private void txtmonto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                e.Handled = false;
            else
                e.Handled = true;
        }
        private void limpiar()
        {
            
            
          
            lstCargos1.SelectedIndex = -1;
            txtmonto.Text = "";
            //tbContenedor.SelectedIndex = 0;
            if (dtgReservas.ItemsSource != null)
                dtgReservas.ItemsSource = null;
            numeroReserva = 0;
            lbltitulo.Content = "";
            txtCliente.Text = "";
            txtNroContrato.Text = "";
            txtNroReserva.Text = "";
            dpfecha.SelectedDate = null;
          
            lstCargos.SelectedIndex = -1;
            txtmonto1.Text = "";
           // lstBancos.SelectedIndex = -1;
            lstTransaccion.SelectedIndex = -1;
            dpfechatransaccion.SelectedDate = null;
            txtdocumento.Text = "";
            txtobservacion.Text = "";
            if (dtgConfirmar.ItemsSource != null)
                dtgConfirmar.ItemsSource = null;
            if (dtgMontosTI.ItemsSource != null)
                dtgMontosTI .ItemsSource = null;
            //dtCon = null;
            dtCar = null;
           
        }
        private void sumar_cargos()
        {
            //double totalcargo = 0;
            //if (dtCar != null)
            //{
            //    if (dtCar.Rows.Count > 0)
            //    {
            //        for (int i = 0; i <= dtCar.Rows.Count - 1; i++)
            //        {
            //            totalcargo = totalcargo + Convert.ToDouble(dtCar.Rows[i][2].ToString());
            //        }
            //        lblvalorTotal.Content =Convert.ToDouble(totalcargo).ToString("N2",CultureInfo.CreateSpecificCulture("es-VE"));
            //    }
            //    else
            //    {
            //        lblvalorTotal.Content = "0,00";
            //    }
            //}
        }

        private void btnGuardacargo_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void btnQuitarCargo_Click(object sender, RoutedEventArgs e)
        {
           /* if (dtgCargos.Items.Count > 0)
            {
                dtCar.Rows.RemoveAt(dtCar.Rows.Count - 1);
                item--;
                dtgCargos.ItemsSource = dtCar.DefaultView;
                if (dtCar.Rows.Count == 0)
                {
                    btnQuitarCargo.IsEnabled = false;
                    item = 0;

                }
                sumar_cargos();
            }*/
        }

        private void btnAgregarCargo_Click(object sender, RoutedEventArgs e)
        {
            if ((txtmonto.Text.Equals("")) || (lstCargos.SelectedIndex == -1))
            {
                MessageBox.Show("Debe colocar un monto y concepto del cargo a la reserva", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (lstCargos.SelectedItem.ToString().Trim(new char[] {' '}).Equals("MANTENIMIENTO"))
            {
                if (lstAnnio.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe colocar un año por concepto de mantenimiento", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
            }



            item++;
            /*if (dtMcar.Rows.Count > 0)
            {
                for (int i = 0; i <= dtMcar.Rows.Count - 1; i++)
                {
                    if (dtMcar.Rows[i][1].ToString().Equals(lstCargos.SelectedItem.ToString()))
                    {
                        MessageBox.Show("Ya hay un concepto registrado con ese nombre", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                        item--;
                        return;
                    }
                }
            }*/
            if (car.Count == 0)
                car = new List<cargos>();
            if (lstCargos.SelectedItem.ToString().Trim(new char[] { ' ' }).Equals("MANTENIMIENTO"))
            {
                car.Add(new cargos()
                {

                    concepto = lstCargos.SelectedItem.ToString().Trim(new char[] { ' ' }),
                    monto = Convert.ToDouble(txtmonto.Text),
                    anular = 0,
                    anio = lstAnnio.SelectedItem.ToString(),
                    observacion = txtObservacion.Text.ToUpper()
                });
            }
            else{
                car.Add(new cargos()
                {

                    concepto = lstCargos.SelectedItem.ToString().Trim(new char[] { ' ' }),
                    monto = Convert.ToDouble(txtmonto.Text),
                    anular = 0,
                    anio = "",
                    observacion = txtObservacion.Text.ToUpper()
                });
            }
            dtgMostrarCargos.ItemsSource = car;
            dtgMostrarCargos.Items.Refresh();
            foreach (cargos c in dtgMostrarCargos.ItemsSource)
            {
                if (c.anular == 0)
                    c.anulado = "NO";
                else c.anulado = "SI";
            }
            lstCargos.SelectedIndex = -1;
            lstAnnio.SelectedIndex = -1;
            txtmonto.Text = "";
            txtObservacion.Text = "";
        }
        

        private void chkSelectAll_Checked(object sender, RoutedEventArgs e)
        {

            if (dtgConfirmar.Items.Count > 0)
            {
                foreach (trasaccionPago p in dtgConfirmar.ItemsSource)
                {
                    p.IsSelected = true;
                    p.IsAnulado = false;

                }
            }
        }

        private void chkSelectAll_Unchecked(object sender, RoutedEventArgs e)
        {
            if (dtgConfirmar.Items.Count > 0)
            {
                foreach (trasaccionPago p in dtgConfirmar.ItemsSource)
                {
                    p.IsSelected = false;

                }
            }
        }
        private void chkCargoSelectAll_Checked(object sender, RoutedEventArgs e)
        {

            if (dtgMostrarCargos.Items.Count > 0)
            {
                foreach (cargos p in dtgMostrarCargos.ItemsSource)
                {
                    p.IsSelected = true;

                }
            }
        }

        private void chkSelectCargoAll_Unchecked(object sender, RoutedEventArgs e)
        {
            if (dtgMostrarCargos.Items.Count > 0)
            {
                foreach (cargos p in dtgMostrarCargos.ItemsSource)
                {
                    p.IsSelected = false;

                }
            }
        }

        private void chkanulaAll_Checked(object sender, RoutedEventArgs e)
        {

            if (dtgConfirmar.Items.Count > 0)
            {
                foreach (trasaccionPago p in dtgConfirmar.ItemsSource)
                {
                    p.IsAnulado = true;
                    p.IsSelected = false;

                }
            }
        }

        private void chkanulaAll_Unchecked(object sender, RoutedEventArgs e)
        {
            if (dtgConfirmar.Items.Count > 0)
            {
                foreach (trasaccionPago p in dtgConfirmar.ItemsSource)
                {
                    p.IsAnulado = false;
                    
                }
            }
        }

        private void dtgConfirmar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           /* if (dtgConfirmar.ItemsSource!=null)
            {
                trasaccionPago tp = dtgConfirmar.SelectedItem as trasaccionPago;
                if (tp.IsSelected)
                    tp.IsSelected = false;
                else tp.IsSelected = true;
            }*/
        }

        private void btnGuardaConfirmacion_Click(object sender, RoutedEventArgs e)
        {
           /* bool check = false;
           foreach (trasaccionPago tp in dtgConfirmar.ItemsSource) {
               if (tp.IsSelected == true)
               {
                   check = true;
                   break;
               }

           }
           if (check == false)
           {
               MessageBox.Show("Debe seleccionar un pago para confirmar", "ADVERTENCIA", MessageBoxButton.OK, MessageBoxImage.Warning);
               return;
           }            
            if (MessageBox.Show("¿Desea confirmar los pagos seleccionados?", "Pregunta", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                reservacion res = new reservacion();
                foreach (trasaccionPago tp in dtgConfirmar.ItemsSource)
                {
                    if (tp.IsSelected == true)                    
                        res.confirmar(numeroReserva, tp.monto, tp.concepto,tp.referencia);
                }
                MessageBox.Show("Se han confirmado los pagos correctamente de la reserva", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                limpiar();
            }*/
        }

        private void dtgMostrarCargos_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }

        private void lstTransaccion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //

            ComboBox cmb = sender as ComboBox;
            Console.WriteLine(cmb.SelectedItem);

            if (lstTransaccion.SelectedIndex != -1)
            {
                //if (lstTransaccion.SelectedItem.ToString().Equals("DÉBITO") || lstTransaccion.SelectedItem.ToString().Equals("CRÉDITO"))

                //----------------------- Código Juan (01-06-2017) ----------------//
                formasdepago itm = lstTransaccion.SelectedItem as formasdepago;
                Console.WriteLine(itm.descripcion);
                if (itm.descripcion.Equals("TDB") || itm.descripcion.Equals("TDC"))
                //-----------------------------------------------------------------//

                {
                    lsttipo.IsEnabled = true;
                   
                }
                else
                {
                    lsttipo.IsEnabled = false;
                  
                }
                if (lstTransaccion.SelectedItem.ToString().Equals("EFECTIVO") || lstTransaccion.SelectedItem.ToString().Equals("CHEQUE"))
                {
                    lstCuenta.IsEnabled = false;

                }
                else
                {
                    lstCuenta.IsEnabled = true;

                }
                //if (lstTransaccion.SelectedItem.ToString().Equals("DEPÓSITO") || lstTransaccion.SelectedItem.ToString().Equals("TRANSFERENCIA"))
                //    lstCuenta.IsEnabled = true;
                //else
                //    lstCuenta.IsEnabled = false;
                 //if (lstTransaccion.SelectedItem.ToString().Equals("EFECTIVO"))
                 //    lstBancos.IsEnabled=false;
                 //else
                 //    lstBancos.IsEnabled=true;               

            }
        }

        private void btnLocalizador_Click(object sender, RoutedEventArgs e)
        {
            localizador loc =new localizador();
            loc.user = user;
            loc.us = us;
            loc.contrato = contratos;
            loc.numeroReserva=numeroReserva;
            this.NavigationService.Navigate(loc);
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

        private void lstCargos1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstCargos1.SelectedItem != null)
            {
                if (lstCargos1.SelectedItem.ToString().Equals("TODO INCLUIDO") || (lstCargos1.SelectedItem.ToString().Trim(new char[] { ' ' }).Equals("SUPLEMENTO NAVIDAD")) || (lstCargos1.SelectedItem.ToString().Trim(new char[] { ' ' }).Equals("SUPLEMENTO CENA FIN DE AÑO")))
                    lstHolel.IsEnabled = true;
                else
                    lstHolel.IsEnabled = false;
            }
        }

        private void txtNroReserva_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!txtNroReserva.Text.Equals(""))
            {
                DateTime? f = dpfecha.SelectedDate;
                reservacion res = new reservacion();
                if ((txtCliente.Text.Equals("")) && (txtNroContrato.Text.Equals("")) && (f == null))
                    dtgReservas.ItemsSource = res.buscar_reservaPa(txtNroReserva.Text, "0", "", "0");
                else
                {

                    if ((!txtCliente.Text.Equals("")) && (txtNroContrato.Text.Equals("")) && (f == null))
                        dtgReservas.ItemsSource = res.buscar_reservaPa(txtNroReserva.Text, txtCliente.Text, "", "0");
                    else
                    {
                        if ((!txtCliente.Text.Equals("")) && (!txtNroContrato.Text.Equals("")) && (f == null))
                            dtgReservas.ItemsSource = res.buscar_reservaPa(txtNroReserva.Text, txtCliente.Text, "", txtNroContrato.Text);
                        else
                        {
                            if ((!txtCliente.Text.Equals("")) && (!txtNroContrato.Text.Equals("")) && (f != null))
                            {
                                String[] ini = f.Value.ToShortDateString().Split('/');
                                String fechI = ini[2] + "/" + ini[1] + "/" + ini[0];
                                dtgReservas.ItemsSource = res.buscar_reservaPa(txtNroReserva.Text, txtCliente.Text, fechI, txtNroContrato.Text);
                            }

                        }
                    }
                }
                dtgConfirmar.SelectedIndex = 0;
            }
        }

        private void dtgReservas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            object item = dtgReservas.SelectedItem;
            if ((dtgReservas.Items.Count > 0) && (item != null))
            {
                //dtgMostrar.ItemsSource = null;
                numeroReserva = Convert.ToInt32((dtgReservas.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
                saldoReserva = Convert.ToDouble((dtgReservas.SelectedCells[12].Column.GetCellContent(item) as TextBlock).Text);
                todoIncluido = Convert.ToDouble((dtgReservas.SelectedCells[6].Column.GetCellContent(item) as TextBlock).Text);
                puntosAcelerados = Convert.ToDouble((dtgReservas.SelectedCells[9].Column.GetCellContent(item) as TextBlock).Text);
                string cliente = (dtgReservas.SelectedCells[14].Column.GetCellContent(item) as TextBlock).Text;
                contratos = (dtgReservas.SelectedCells[15].Column.GetCellContent(item) as TextBlock).Text;
                int contrato = Convert.ToInt32((dtgReservas.SelectedCells[15].Column.GetCellContent(item) as TextBlock).Text);
                cliente cli = new cliente();
                cli.buscar_cliente(cliente,contratos);
                lbltitulo.Content = "Reserva N° ** " + numeroReserva.ToString() + " **Cliente: " + cli.nombres + " " + cli.apellidos + "** Contrato Nº" + contrato.ToString();
                cargarPagos(numeroReserva);
                if (dtgConfirmar.ItemsSource != null)
                {
                    foreach (trasaccionPago p in dtgConfirmar.ItemsSource)
                    {
                        if (p.confir == 0)
                            p.IsSelected = false;
                        else
                            p.IsSelected = true;
                        if (p.anula == 0)
                            p.IsAnulado = false;
                        else
                            p.IsAnulado = true;
                    }
                }
                if (dtgMostrarCargos.ItemsSource != null)
                {
                    foreach (cargos c in dtgMostrarCargos.ItemsSource)
                    {
                        if (c.anular == 0)
                            c.IsSelected = false;
                        else
                            c.IsSelected = true;
                    }
                }
                
                btnAgregarPago.IsEnabled = true;
                btnGuardaPago.IsEnabled = true;
                btnAgregarCargo.IsEnabled = true;
                if (saldoReserva == 0)
                {

                    numeroReserva = Convert.ToInt32((dtgReservas.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
                    montoPA actu = new montoPA();
                    actu.actualizar_estatus_rese(numeroReserva);
                    MessageBox.Show("La reserva cambió a estatus CONFIRMADA, se deben de proporcionar los localizadores para emitir la confirmación", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                    btnLocalizador.IsEnabled = true;
                    txtNroReserva.Text = "";
                    txtNroReserva.Text = numeroReserva.ToString();

                }
                else
                    btnLocalizador.IsEnabled = false;
                //btnGuardacargo.IsEnabled = true;
                //btnGuardaConfirmacion.IsEnabled = true;

            }
        }

        private void txtmonto1_KeyUp(object sender, KeyEventArgs e)
        {
            if (!txtmonto1.Text.Equals(""))
            {
                txtmonto1.Text = Convert.ToDouble(txtmonto1.Text).ToString("N2", CultureInfo.CreateSpecificCulture("es-ES"));
                string[] p = txtmonto1.Text.Split(',');
                txtmonto1.Select(p[0].Length, 0);
                if (lstCargos1.SelectedItem.ToString().Equals("PUNTOS ACELERADOS"))
                {
                    montoPA mA=new montoPA();
                    DataTable dtContrato = new DataTable();
                    cliente cli = new cliente();
                    dtContrato.Load(cli.buscar_contratos("", "", contratos));
                    DateTime fechaVenta = new DateTime();
                    fechaVenta = Convert.ToDateTime(dtContrato.Rows[0][9].ToString());
                    mA.buscar(fechaVenta.Date.ToShortDateString());                   
                    double puntos = Convert.ToDouble(txtmonto1.Text) / mA.monto;
                    txtpuntosA.Text = puntos.ToString("N2", CultureInfo.CreateSpecificCulture("es-ES"));
                }
            }
        }

        private void dtgMontosTI_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dtgMontosTI.Items.Count > 0)
            {
                object item = dtgMontosTI.SelectedItem;
                lstCargos1.SelectedIndex = 0;
                txtmonto1.Text = (dtgMontosTI.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                lstHolel.SelectedItem = (dtgMontosTI.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
            }
        }

        private void txtmonto_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtmonto_KeyUp(object sender, KeyEventArgs e)
        {
            if (!txtmonto.Text.Equals(""))
            {
                txtmonto.Text = Convert.ToDouble(txtmonto.Text).ToString("N2", CultureInfo.CreateSpecificCulture("es-ES"));
                string[] p = txtmonto.Text.Split(',');
                txtmonto.Select(p[0].Length, 0);
            }
        }

        private void lstCargos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstCargos.SelectedIndex != -1)
            {
                if (lstCargos.SelectedItem.ToString().Trim(new char[] { ' ' }).Equals("MANTENIMIENTO"))                
                    lstAnnio.IsEnabled = true;
                else
                    lstAnnio.IsEnabled = false;       
            }
        }

        private void dtgConfirmar_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dtgConfirmar.Items.Count > 0)
            {
                if (MessageBox.Show("¿Desea traspasar el pago a otra reserva?", "Pregunta", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    trasladaPagos tp = new trasladaPagos();
                    trasaccionPago p = (trasaccionPago)dtgConfirmar.Items[dtgConfirmar.SelectedIndex];
                    tp.p = p;
                    tp.Show();
                }
            }
        }

       
    }
    public class trasaccionPago : INotifyPropertyChanged
    {
        public int reserva{ get; set; }
        public string contrato { get; set; }
        public int referencia{ get; set; }
        public string concepto { get; set; }
        public string trasaccion { get; set; }
        public string documento { get; set; }
        public string banco { get; set; }
        public string fecha{ get; set; }
        public string observacion { get; set; }
        public string cuenta { get; set; }
        public string tipo { get; set; }
        public string ejecutivo { get; set; }
        public string estatus { get; set; }
        public string anulado{ get; set; }
        public double monto { get; set; }
        public int confir { get; set; }
        public int anula { get; set; }
        public string hotel { get; set; }
        public string loc { get; set; }
        public string cliente { get; set; }
        public double puntosA { get; set; }
       
        private bool _IsSelected = false;
        private bool _IsAnulado = false;
        public bool IsSelected { get { return _IsSelected; } set { _IsSelected = value; OnChanged("IsSelected"); } }
        public bool IsAnulado { get { return _IsAnulado; } set { _IsAnulado = value; OnChanged("IsAnulado"); } }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnChanged(string prop)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        #endregion
    }
    public class cargos : INotifyPropertyChanged
    {
       
        public string concepto { get; set; }
        
        public double monto { get; set; }
        public string anio { get; set; }
        public string observacion { get; set; }
      
        public int anular { get; set; }
        public string anulado { get; set; }
        private bool _IsSelected = false;
       
        public bool IsSelected { get { return _IsSelected; } set { _IsSelected = value; OnChanged("IsSelected"); } }
      

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnChanged(string prop)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        #endregion
    }
}
