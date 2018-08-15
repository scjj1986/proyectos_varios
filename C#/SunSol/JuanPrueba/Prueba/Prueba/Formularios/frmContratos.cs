using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contratos
{
    public partial class frmContratos : Form
    {
        public frmContratos()
        {
            InitializeComponent();
        }

        #region VARIABLES

        public string accion;
        
        public int idcli;
        public string cedcli;
        public int idcopr;
        public int index_dtcopr;
        public int descuento;
        public string nrocontrato;

        public string codTCR;
        public int ptosporanio;
        public int aniouso;
        public int divisionPN;
        public int corrCR;
        public int cantidadanios;
        public string cantidadaniosletras;


        public double valorpunto;
        
        public double preciocompra;

        public double inicialpactada;

        public double inicialhoy;

        public double txt_inicialhoy;

        public double compl;

        public double txt_compl;


        public double total_financ;

        public double f_saf;

        public double mcuo_saf;

        public double mcuo_safe;

        public double fe_saf;

        public int nrocuotas;

        public bool evt = false;//Gestor de eventos

        public bool hasta24cuotas;



        //--------------------------

        public double fact_6m, fact_12m, fact_18m, fact_24m, fact_30m, fact_36m, fact_an, fact_tr, fact_sm;


        //--------------------------


        #endregion

        #region MÉTODOS GENERALES

        public void valorespordefectosala07()
        {
            cmbGteVtas.SelectedValue = "NOGV";
            txtCodGteVtas.Text = "NOGV";
            cmbGteMdo.SelectedValue = "NOGM";
            txtCodGteMdo.Text = "NOGV";
            cmbLiner1.SelectedValue = "VACIL";
            txtCodLiner1.Text = "VACIL";
            cmbCloser1.SelectedValue = "VACIC";
            txtCodCloser1.Text = "VACIC";
            cmbNCuotasFinanc.Items.Insert(3, "18");
            cmbNCuotasFinanc.Items.Insert(4, "24");
            cmbNCuotasFinanc.Items.Insert(5, "36");
        }

        public void cargar_cmbs_bancos()
        {
            evt = true;
            string txtSQL = "SELECT * FROM Bancos WHERE Activo=1 ORDER BY Descripcion";
            Globales.BD.dtt = Globales.BD.generar_datatable(txtSQL, CommandType.Text, new List<Clases.Parameters>());
            cmbBancoFPIH.DataSource = Globales.BD.dtt;
            cmbBancoFPIH.ValueMember = "Codigo";
            cmbBancoFPIH.DisplayMember = "Descripcion";
            cmbBancoFPIH.SelectedIndex = -1;

            Globales.BD.dtt = Globales.BD.generar_datatable(txtSQL, CommandType.Text, new List<Clases.Parameters>());
            cmbBancoComp.DataSource = Globales.BD.dtt;
            cmbBancoComp.ValueMember = "Codigo";
            cmbBancoComp.DisplayMember = "Descripcion";
            cmbBancoComp.SelectedIndex = -1;

            Globales.BD.dtt = Globales.BD.generar_datatable(txtSQL, CommandType.Text, new List<Clases.Parameters>());
            cmbBancoComp.DataSource = Globales.BD.dtt;
            cmbBancoComp.ValueMember = "Codigo";
            cmbBancoComp.DisplayMember = "Descripcion";
            cmbBancoComp.SelectedIndex = -1;

            Globales.BD.dtt = Globales.BD.generar_datatable(txtSQL, CommandType.Text, new List<Clases.Parameters>());
            cmbBancoGA.DataSource = Globales.BD.dtt;
            cmbBancoGA.ValueMember = "Codigo";
            cmbBancoGA.DisplayMember = "Descripcion";
            cmbBancoGA.SelectedIndex = -1;

            Globales.BD.dtt = Globales.BD.generar_datatable(txtSQL, CommandType.Text, new List<Clases.Parameters>());
            cmbBancoCA.DataSource = Globales.BD.dtt;
            cmbBancoCA.ValueMember = "Codigo";
            cmbBancoCA.DisplayMember = "Descripcion";
            cmbBancoCA.SelectedIndex = -1;

            evt = false;
        }

        public void cargar_cmbs_formasdepago()
        {
            evt = true;

            string txtSQL = "SELECT * FROM FormasDePago ORDER BY Descripcion";
            Globales.BD.dtt = Globales.BD.generar_datatable(txtSQL, CommandType.Text, new List<Clases.Parameters>());
            cmbInstrumentoFPIH.DataSource = Globales.BD.dtt;
            cmbInstrumentoFPIH.ValueMember = "Codigo";
            cmbInstrumentoFPIH.DisplayMember = "Descripcion";
            cmbInstrumentoFPIH.SelectedIndex = -1;

            txtSQL = "SELECT * FROM FormasDePago ORDER BY Descripcion";
            Globales.BD.dtt = Globales.BD.generar_datatable(txtSQL, CommandType.Text, new List<Clases.Parameters>());
            cmbInstrumentoComp.DataSource = Globales.BD.dtt;
            cmbInstrumentoComp.ValueMember = "Codigo";
            cmbInstrumentoComp.DisplayMember = "Descripcion";
            cmbInstrumentoComp.SelectedIndex = -1;

            txtSQL = "SELECT * FROM FormasDePago ORDER BY Descripcion";
            Globales.BD.dtt = Globales.BD.generar_datatable(txtSQL, CommandType.Text, new List<Clases.Parameters>());
            cmbInstrumentoGA.DataSource = Globales.BD.dtt;
            cmbInstrumentoGA.ValueMember = "Codigo";
            cmbInstrumentoGA.DisplayMember = "Descripcion";
            cmbInstrumentoGA.SelectedIndex = -1;





            evt = false;
        }

        public int dias_entre_fechas(DateTime fini, DateTime ffin)
        {

            TimeSpan ts = ffin - fini;
            return ts.Days;
        }

        public double calcular_monto_por_porc(string porc, double monto)
        {
            try
            {
                double cifra = string.IsNullOrWhiteSpace(porc) ? 0 : Convert.ToDouble(porc.Replace('.', ','));
                if (cifra > 100)
                {
                    return 0;
                }
                if (cifra == 0) return 0;
                else return Convert.ToDouble((cifra * monto) / 100);


                //txtIPactada.Text = String.Format("{0:N}", decimal.Parse(Convert.ToString(inicialpactada))); preciocompra


            }
            catch
            {
                return 0;
            }

        }

        public void guardarcontrato()
        {
            List<Clases.Parameters> Parametros = new List<Clases.Parameters>();
            Parametros.Add(new Clases.Parameters { nameValue = "@NroContrato", Valor = txtNroContrato.Text });
            Parametros.Add(new Clases.Parameters { nameValue = "@Tipo", Valor = cmbTContrato.SelectedValue });
            Parametros.Add(new Clases.Parameters { nameValue = "@CodigoOficina", Valor = Globales.gCodigoOficina });
            Parametros.Add(new Clases.Parameters { nameValue = "@CambioDolar", Valor = Globales.gCambioDolar });
            Parametros.Add(new Clases.Parameters { nameValue = "@Puntos", Valor = Globales.txt_a_double(txtPuntos.Text)});
            Parametros.Add(new Clases.Parameters { nameValue = "@ValorPuntos", Valor = Globales.txt_a_double(txtValorPunto.Text) });
            Parametros.Add(new Clases.Parameters { nameValue = "@PrimerAnioUso", Valor = Convert.ToString(nudPrimAUso.Value) });
            Parametros.Add(new Clases.Parameters { nameValue = "@MontoContrato", Valor = preciocompra });
            Parametros.Add(new Clases.Parameters { nameValue = "@Calendario", Valor = txtTCalendario.Text.ToUpper() });
            Parametros.Add(new Clases.Parameters { nameValue = "@IncialPactadaBs", Valor = inicialpactada });
            Parametros.Add(new Clases.Parameters { nameValue = "@InicialPactadaPorc", Valor = Globales.txt_a_double(txtPorcIPactada.Text) });
            Parametros.Add(new Clases.Parameters { nameValue = "@InicialHoyBs", Valor = inicialhoy });
            Parametros.Add(new Clases.Parameters { nameValue = "@InicialHoyPorc", Valor = Globales.txt_a_double(txtPIHoy.Text) });
            Parametros.Add(new Clases.Parameters { nameValue = "@MontoFinanciar", Valor = f_saf });
            Parametros.Add(new Clases.Parameters { nameValue = "@MontoFinanciarPorc", Valor = Globales.txt_a_double(txtPorcFinanc.Text) });
            Parametros.Add(new Clases.Parameters { nameValue = "@NroCoutasFinanciar", Valor = cmbNCuotasFinanc.SelectedIndex==-1?0 : Convert.ToInt32(cmbNCuotasFinanc.Text) });//Corroborar
            Parametros.Add(new Clases.Parameters { nameValue = "@TasaAnual", Valor = Globales.txt_a_double(cmbTAnualFinanc.Text) });
            Parametros.Add(new Clases.Parameters { nameValue = "@MontoCuota", Valor = txtMontoCuotaFinanc.Text==""? 0: Globales.txt_a_double(txtMontoCuotaFinanc.Text)/**/ });
            Parametros.Add(new Clases.Parameters { nameValue = "@FechaPrimeraCuota", Valor = dtpAPDFinanc.Value });
            
            
            //Pendiente

            /*
             lTieneDomiciliacion = fTieneDomiciliacion()
             lCmd.Parameters.Append lCmd.CreateParameter("@Domiciliacion", adInteger, adParamInput, , IIf(lTieneDomiciliacion, 1, 0))
             */
            //Parametros.Add(new Clases.Parameters { nameValue = "@Domiciliacion", Valor =  });



            Parametros.Add(new Clases.Parameters { nameValue = "@Observaciones", Valor = txtObsCtto.Text.ToUpper() });

            /*
             If UCase(txtEstatus.text) = "PROCESABLE" Then
                  lCmd.Parameters.Append lCmd.CreateParameter("@FechaProcesable", adDate, adParamInput, , FechaContrato.value)
               Else
                  Dim lReg As New ADODB.Recordset
                  Set lReg = gCn.Execute("Select * from FormaPagoContrato where nroContrato='" & txtNroContrato.text & "' Order By Vencimiento Desc")
                  If lReg.EOF = False Then
                     lCmd.Parameters.Append lCmd.CreateParameter("@FechaProcesable", adDate, adParamInput, , lReg!Vencimiento)
                  End If
               End If
             */




            Parametros.Add(new Clases.Parameters { nameValue = "@CodigoPrograma", Valor = cmbPrograma.SelectedValue });
            Parametros.Add(new Clases.Parameters { nameValue = "@Codigoloc", Valor = cmbLocacion.SelectedValue });
            Parametros.Add(new Clases.Parameters { nameValue = "@TipoFinanciamientoEspecial", Valor = cmbTFinFE.Text });
            Parametros.Add(new Clases.Parameters { nameValue = "@NroCuotas", Valor = nudNCuoFE });
            
            //Corroborar
            /*
             If txtMontoCuotaAnual.text <> "" Then
              lCmd.Parameters.Append lCmd.CreateParameter("@Monto", adCurrency, adParamInput, , txtMontoCuotaAnual.text)
           Else
              lCmd.Parameters.Append lCmd.CreateParameter("@Monto", adCurrency, adParamInput, , 0)
           End If
             */



            Parametros.Add(new Clases.Parameters { nameValue = "@FechaPrimeraCuotaEspecial", Valor = /**/ });//Corroborar
            Parametros.Add(new Clases.Parameters { nameValue = "@TasaCuotasEspeciales", Valor = Globales.txt_a_double(cmbPorcTAFE.Text) });
            Parametros.Add(new Clases.Parameters { nameValue = "@Estatus", Valor = txtEstatus.Text });
            Parametros.Add(new Clases.Parameters { nameValue = "@CodigoGerenteVentas", Valor = txtCodGteVtas.Text });
            Parametros.Add(new Clases.Parameters { nameValue = "@CodigoGerenteMercadeo", Valor = txtCodGteMdo.Text });
            Parametros.Add(new Clases.Parameters { nameValue = "@CodigoLiner", Valor = txtCodLiner1.Text });
            Parametros.Add(new Clases.Parameters { nameValue = "@CodigoLiner2", Valor = txtCodLiner2.Text });
            Parametros.Add(new Clases.Parameters { nameValue = "@CodigoLiner3", Valor = txtCodLiner3.Text });

            Parametros.Add(new Clases.Parameters { nameValue = "@CodigoCloser1", Valor = txtCodCloser1.Text });
            Parametros.Add(new Clases.Parameters { nameValue = "@CodigoCloser2", Valor = txtCodCloser2.Text });
            Parametros.Add(new Clases.Parameters { nameValue = "@CodigoCloser3", Valor = txtCodCloser3.Text });


            Parametros.Add(new Clases.Parameters { nameValue = "@CodigoPromotor", Valor = txtCodProm1.Text });
            Parametros.Add(new Clases.Parameters { nameValue = "@CodigoPromotor2", Valor = txtCodProm2.Text });



            Parametros.Add(new Clases.Parameters { nameValue = "@cedula", Valor = cedcli });
            Parametros.Add(new Clases.Parameters { nameValue = "@id", Valor = idcli });
            Parametros.Add(new Clases.Parameters { nameValue = "@FechaCreacion", Valor = dtpFContrato.Value });
            Parametros.Add(new Clases.Parameters { nameValue = "@CodigoSupervisor", Valor = txtCodSOPC1.Text });
            Parametros.Add(new Clases.Parameters { nameValue = "@CodigoSupervisor2", Valor = txtCodSOPC2.Text });

            /*
             If lCantidadAños = 0 Or lCantidadAñosLetras = "" Then
             Set lReg = gCn.Execute("Select CantidadAnios,GastosLegales,ValorPunto,CantidadAniosLetras from TiposContratosReservas where ID=" & val(cmbDBTipoContrato.BoundText))
             If lReg.EOF = False Then
                lCantidadAños = lReg!CantidadAnios
                lCantidadAñosLetras = lReg!CantidadAniosLetras
             End If
           End If
   
           lCmd.Parameters.Append lCmd.CreateParameter("@CantidadAños", adInteger, adParamInput, , lCantidadAños)
             
             
             */

            
            Parametros.Add(new Clases.Parameters { nameValue = "@CodigoCobrador", Valor = txtCodCobr1.Text });
            Parametros.Add(new Clases.Parameters { nameValue = "@CodigoSubtipoContrato", Valor = cmbSTContrato.SelectedValue });
            Parametros.Add(new Clases.Parameters { nameValue = "@ID_Tipo", Valor = cmbTContrato.Text });


            Parametros.Add(new Clases.Parameters { nameValue = "@CantidadAñosLetras", Valor = /**/ });//Corroborar
            Parametros.Add(new Clases.Parameters { nameValue = "@CreadoPor", Valor = Globales.usr.nick });
            Parametros.Add(new Clases.Parameters { nameValue = "@TablaPuntos", Valor = Convert.ToInt32(cmbTablaPuntos) });
            Parametros.Add(new Clases.Parameters { nameValue = "@ObservacionesHostess", Valor = txtObsHst.Text.ToUpper() });
            Parametros.Add(new Clases.Parameters { nameValue = "@NuevaTemporada", Valor = txtTemporada.Text });
            Parametros.Add(new Clases.Parameters { nameValue = "@PrimeraCuotaMantenimiento", Valor = chkPCMCancelada.Checked?1:0 });
            
            /*
               lCmd.Parameters.Append lCmd.CreateParameter("@CodigoGerenteSala", adVarChar, adParamInput, 10, gCodigoGerenteSala)
               lCmd.Parameters.Append lCmd.CreateParameter("@CodigoGerenteCalle", adVarChar, adParamInput, 10, gCodigoGerenteCalle)
               lCmd.Parameters.Append lCmd.CreateParameter("@CodigoAsistenteCalle", adVarChar, adParamInput, 10, gCodigoAsistenteCalle)
             
             */
            
            
            
            
            Parametros.Add(new Clases.Parameters { nameValue = "@CodigoDescuento", Valor = cmbDescuento.SelectedValue) });//Corroborar
            Parametros.Add(new Clases.Parameters { nameValue = "@TC", Valor = txtTC.Text });
            Parametros.Add(new Clases.Parameters { nameValue = "@Fusion", Valor = chkPFusion.Checked?1:0 });
            Parametros.Add(new Clases.Parameters { nameValue = "@pContado", Valor = chkPContado.Checked?1:0 });

            /*
             lCmd.ActiveConnection = gCn
   lCmd.CommandTimeout = 15
   lCmd.CommandText = "Guardar_Contrato"
   
   
   
             
             */




            Globales.BD.ejecutar_consulta("Insertar_FormaPagoContrato", CommandType.StoredProcedure, Parametros);
        }       

        public void ejecutarguardarcontrato()
        {
            
            foreach (DataGridViewRow rw in dtgrFPIH.Rows)
            {
                Clases.FormasDePago fdp = new Clases.FormasDePago(rw, 1, "CANCELADO", txtNroContrato.Text);
                fdp.guardarformapagocontrato();

            }
            foreach (DataGridViewRow rw in dtgrComp.Rows)
            {
                Clases.FormasDePago cmp = new Clases.FormasDePago(rw, 2, "", txtNroContrato.Text);
                cmp.guardarformapagocontrato();

            }

            guardarcontrato();
    
              
        }


        #endregion

        #region EVENTO CARGA DE LA PÁGINA
        private void frmContratos_Load(object sender, EventArgs e)
        {
            
            datprin_cargar_cmbtipocontrato();
            datprin_cargar_cmbsubtipocontrato();
            datprin_cargar_cmbprograma();
            datprin_cargar_cmbtablapuntos();
            datprin_cargar_cmbdescuento();
            copr_cargar_cmbparent();
            cargar_cmbs_bancos();
            cargar_cmbs_formasdepago();
            financ_cargar_cmbtipfin();
            financ_cargar_cmbncuotas();
            financ_cargar_factores();

            dtpFVencComp.MinDate = DateTime.Today;
            dtpFVencComp.MaxDate = DateTime.Today.AddDays(30);
            dtpFVencComp.Value = DateTime.Today.AddDays(30);

            dtpAPDFinanc.MinDate = DateTime.Today;
            dtpAPDFinanc.MaxDate = DateTime.Today.AddDays(90);
            dtpAPDFinanc.Value = DateTime.Today;

            dtpVencGA.MinDate = DateTime.Today;

            dtpVencCA.MinDate = DateTime.Today.AddDays(1);
               
            if (Globales.emp.codigo == "07")
                valorespordefectosala07();

            financ_cargar_cmbtasasanuales();
            empl_cargar_cmbempleados();
            index_dtcopr = -1;
            //txtNrFPIH.TextLength = 25;
            if (accion == "AGREGAR")
            {
                aniouso = DateTime.Now.Year % 2;

                nudPrimAUso.Minimum = DateTime.Now.Year - 1;
                nudPrimAUso.Maximum = DateTime.Now.Year + 50;
                nudPrimAUso.Value = aniouso == 0 ? DateTime.Now.Year + 2 : DateTime.Now.Year + 1;
                dtpAPDFinanc.Value = DateTime.Today.AddDays(30);
            }

            evt = false;
            
        }
        #endregion

        #region PESTAÑA DATOS PRINCIPALES

        #region Métodos

        public string datprin_ult_digts_ctto(int nr)
        {
            nr++;
            if (nr < 10) return "000" + Convert.ToString(nr);
            if (nr < 100) return "00" + Convert.ToString(nr);
            if (nr < 1000) return "0" + Convert.ToString(nr);
            return Convert.ToString(nr);
        }
        public string datprin_generar_nrctto()
        {
            string txtSQL;
            string cad_dig;
            if (codTCR.Length <= 1)//Cuando es un contrato...
            {
                txtSQL = "select max(Nrocontrato) as maximo from Contratos where CodigoOficina='" + Globales.emp.codigo + "' And Substring(NroContrato,1,1)='" +codTCR+ "'";
                Globales.BD.dtt_aux = Globales.BD.generar_datatable(txtSQL, CommandType.Text, new List<Clases.Parameters>());
                if (Globales.BD.dtt_aux.Rows.Count > 0)
                {
                    foreach (DataRow pRow in Globales.BD.dtt_aux.Rows)
                    {
                        if (pRow["maximo"] != DBNull.Value)
                        {
                            cad_dig = Convert.ToString(pRow["maximo"]);
                            cad_dig = cad_dig.Substring(3, cad_dig.Length - 3);
                            return codTCR + Globales.emp.codigo + datprin_ult_digts_ctto(Convert.ToInt32(cad_dig));
                        }
                        else
                            return codTCR + Globales.emp.codigo + "0001";
                    }
                }
                else
                    return codTCR + Globales.emp.codigo + "0001";
            }
                          
            else//Cuando es una reserva
            {
                txtSQL = "select max(Nrocontrato) as maximo from Contratos where CodigoOficina='" + Globales.emp.codigo + "' And Substring(NroContrato,1,2)='" +codTCR+ "'";
                Globales.BD.dtt_aux = Globales.BD.generar_datatable(txtSQL, CommandType.Text, new List<Clases.Parameters>());
                if (Globales.BD.dtt_aux.Rows.Count > 0)
                {
                    foreach (DataRow pRow in Globales.BD.dtt_aux.Rows)
                    {
                        if (accion == "AGREGAR")
                        {
                            if (pRow["maximo"] != DBNull.Value)
                            {
                                cad_dig = Convert.ToString(pRow["maximo"]);
                                cad_dig = cad_dig.Substring(4,cad_dig.Length-4);
                                return "R" + codTCR + Globales.emp.codigo + datprin_ult_digts_ctto(Convert.ToInt32(cad_dig));
                            }
                            else
                                return codTCR + Globales.emp.codigo + "0001";
                        }
                    }
                }
                else
                    return codTCR + Globales.emp.codigo + "0001";
            
            }

            return "";
            
        }
        public void datprin_cargar_cmbtipocontrato()
        {
            evt = true;
            string txtSQL = "SELECT * FROM TiposContratosReservas WHERE Codigo<>'' AND  Activo=1 ORDER BY Descripcion";
            Globales.BD.dtt = Globales.BD.generar_datatable(txtSQL, CommandType.Text, new List<Clases.Parameters>());
            cmbTContrato.DataSource = Globales.BD.dtt;
            cmbTContrato.ValueMember = "ID";
            cmbTContrato.DisplayMember = "Descripcion";
            cmbTContrato.SelectedIndex = -1;
            evt = false;
        }
        public void datprin_cargar_cmbsubtipocontrato()
        {
            string txtSQL = "SELECT * FROM SubtipoContratos ORDER BY Codigo";
            Globales.BD.dtt = Globales.BD.generar_datatable(txtSQL, CommandType.Text, new List<Clases.Parameters>());
            //cmbSTContrato.DataSource = null;
            cmbSTContrato.DataSource = Globales.BD.dtt;
            cmbSTContrato.ValueMember = "Codigo";
            cmbSTContrato.DisplayMember = "Descripcion";
            cmbSTContrato.SelectedIndex = -1;
        }
        public void datprin_cargar_cmbprograma()
        {
            evt = true;
            string txtSQL = "SELECT * FROM Programas WHERE Estado=1 ORDER BY Descripcion";
            Globales.BD.dtt = Globales.BD.generar_datatable(txtSQL, CommandType.Text, new List<Clases.Parameters>());
            cmbPrograma.DataSource = Globales.BD.dtt;
            cmbPrograma.ValueMember = "Codigo";
            cmbPrograma.DisplayMember = "Descripcion";
            cmbPrograma.SelectedIndex = -1;
            evt = false;
            
        }
        public void datprin_cargar_cmblocacion()
        {
            string txtSQL = "SELECT * FROM Locacion WHERE CodigoProg="+cmbPrograma.SelectedValue+"AND Activo=1 ORDER BY Descripcion";
            Globales.BD.dtt = Globales.BD.generar_datatable(txtSQL, CommandType.Text, new List<Clases.Parameters>());
            cmbLocacion.DataSource = Globales.BD.dtt;
            cmbLocacion.ValueMember = "Codigo";
            cmbLocacion.DisplayMember = "Descripcion";
            cmbLocacion.SelectedIndex = -1;
            
        }
        public void datprin_cargar_cmbtablapuntos()
        {
            if (accion == "AGREGAR")
            {
                string txtSQL = "Select * From TablaPuntos where FechaDesde <='" + Globales.yyyymmdd(DateTime.Now) + "' And Fechahasta >='" + Globales.yyyymmdd(DateTime.Now) + "'";
                Globales.BD.dtt = Globales.BD.generar_datatable(txtSQL, CommandType.Text, new List<Clases.Parameters>());
                cmbTablaPuntos.DataSource = Globales.BD.dtt;
                cmbTablaPuntos.ValueMember = "Codigo";
                cmbTablaPuntos.DisplayMember = "Descripcion";
                cmbTablaPuntos.SelectedIndex = 0;
            }
        }
        public void datprin_cargar_cmbdescuento()
        {


            string txtSQL = "SELECT valorParametro FROM Configuraciones WHERE nbParametro='Descuento'";
            Globales.BD.dtt = Globales.BD.generar_datatable(txtSQL, CommandType.Text, new List<Clases.Parameters>());
            foreach (DataRow pRow in Globales.BD.dtt.Rows)
                descuento = Convert.ToInt32(pRow["valorParametro"]);
            
            
            txtSQL = "SELECT * FROM DescuentosContratos WHERE Codigo IN (" + descuento + ") Order By Descripcion";
            Globales.BD.dtt = Globales.BD.generar_datatable(txtSQL, CommandType.Text, new List<Clases.Parameters>());
            cmbDescuento.DataSource = Globales.BD.dtt;
            cmbDescuento.ValueMember = "Codigo";
            cmbDescuento.DisplayMember = "Descripcion";
            cmbDescuento.SelectedIndex = -1;

        }

        public string datprin_descr_temp(int codigo)
        {
            string txtSQL = "Select Descripcion from Temporadas where codigo="+codigo.ToString();
            Globales.BD.dtt_aux = Globales.BD.generar_datatable(txtSQL, CommandType.Text, new List<Clases.Parameters>());
            foreach (DataRow pRow in Globales.BD.dtt_aux.Rows)
                return Convert.ToString(pRow["Descripcion"]);
            return "DESCONOCIDA";
        }

        
        #endregion

        #region Eventos

        private void cmbTContrato_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!evt)
            {
                string txtSQL = "Select * from tiposcontratosReservas where ID=" + cmbTContrato.SelectedValue;
                Globales.BD.dtt = Globales.BD.generar_datatable(txtSQL, CommandType.Text, new List<Clases.Parameters>());
                foreach (DataRow pRow in Globales.BD.dtt.Rows)
                {
                    codTCR = Convert.ToString(pRow["Codigo"]);
                    ptosporanio = Convert.ToInt32(pRow["PuntosporAño"]);
                    cantidadanios = Convert.ToInt32(pRow["CantidadAnios"]);
                    cantidadaniosletras = Convert.ToString(pRow["CantidadAniosLetras"]);
                    Globales.gGastosLegales = Convert.ToDouble(pRow["GastosLegales"]);
                    txtMontoGA.Text = Globales.gGastosLegales.ToString();
                    txtValorPunto.Text = Convert.ToDouble(pRow["ValorPunto"]).ToString();
                    valorpunto = Convert.ToDouble(pRow["ValorPunto"]);
                    txtAniosCT.Text = cantidadanios.ToString();
                    txtTemporada.Text = datprin_descr_temp(pRow["CodigoTemporada"] != DBNull.Value ? Convert.ToInt32(pRow["CodigoTemporada"]) : 0);
                    txtPuntos.Text = ptosporanio.ToString();

                    preciocompra = cantidadanios * valorpunto * ptosporanio;

                    txtPrecioCompra.Text = String.Format("{0:N}", decimal.Parse(Convert.ToString(preciocompra)));

                }


                switch (codTCR)
                {
                    case "1":
                        txtTCalendario.Text = "";
                        txtTCalendario.Enabled = true;
                        corrCR = Globales.gCorrelativoTodosLosAnos;
                        txtNroContrato.Text = "1";
                        break;
                    case "2":
                        txtTCalendario.Text = "A";
                        txtTCalendario.Enabled = false;
                        corrCR = Globales.gCorrelativoPares;
                        txtNroContrato.Text = "2";
                        divisionPN = 2;
                        break;
                    case "3":
                        txtTCalendario.Text = "A";
                        txtTCalendario.Enabled = false;
                        corrCR = Globales.gCorrelativoNones;
                        txtNroContrato.Text = "3";
                        divisionPN = 2;
                        break;
                    case "5":
                        txtTCalendario.Text = "";
                        txtTCalendario.Enabled = true;
                        corrCR = Globales.gCorrelativo5Anos2;
                        txtNroContrato.Text = "5";
                        break;
                    case "6":
                        txtTCalendario.Text = "";
                        txtTCalendario.Enabled = true;
                        corrCR = Globales.gCorrelativoPlatinum;
                        txtNroContrato.Text = "6";

                        if (chkVSContrato.Checked)
                            cmbSTContrato.SelectedValue = 6;
                        break;
                    case "R6":
                        txtTCalendario.Text = "";
                        txtTCalendario.Enabled = true;
                        corrCR = Globales.gCorrelativoReservasPL;
                        txtNroContrato.Text = "R6";
                        if (chkVSContrato.Checked)
                            cmbSTContrato.SelectedValue = 6;
                        break;
                    case "RT":
                        txtTCalendario.Text = "";
                        txtTCalendario.Enabled = true;
                        corrCR = Globales.gCorrelativoTodosLosAnosR;
                        txtNroContrato.Text = "RT";
                        break;
                    case "RP":
                        txtTCalendario.Text = "A";
                        txtTCalendario.Enabled = false;
                        corrCR = Globales.gCorrelativoParesR;
                        txtNroContrato.Text = "RP";
                        divisionPN = 2;
                        break;
                    case "RN":
                        txtTCalendario.Text = "A";
                        txtTCalendario.Enabled = false;
                        corrCR = Globales.gCorrelativoNonesR;
                        txtNroContrato.Text = "RN";
                        divisionPN = 2;
                        break;
                    case "RF":
                        txtTCalendario.Text = "";
                        txtTCalendario.Enabled = true;
                        corrCR = Globales.gCorrelativoReservasCF;
                        txtNroContrato.Text = "RF";
                        break;
                    case "7":
                        txtTCalendario.Text = "";
                        txtTCalendario.Enabled = true;
                        corrCR = Globales.gCorrelativoC7;
                        txtNroContrato.Text = "7";
                        cmbSTContrato.SelectedValue = 1;// 1=Normal
                        if (ptosporanio >= 680 && ptosporanio < 880) cmbSTContrato.SelectedValue = 5;
                        if (ptosporanio >= 880) cmbSTContrato.SelectedValue = 6;
                        break;
                    case "8":
                        txtTCalendario.Text = "";
                        txtTCalendario.Enabled = true;
                        corrCR = Globales.gCorrelativoC8;
                        txtNroContrato.Text = "8";
                        cmbSTContrato.SelectedValue = 1;// 1=Normal
                        break;
                    case "R8":
                        txtTCalendario.Text = "";
                        txtTCalendario.Enabled = true;
                        corrCR = Globales.gCorrelativoR8;
                        txtNroContrato.Text = "R8";
                        cmbSTContrato.SelectedValue = 1;// 1=Normal
                        break;
                    case "R7":
                        txtTCalendario.Text = "";
                        txtTCalendario.Enabled = true;
                        corrCR = Globales.gCorrelativoR7;
                        txtNroContrato.Text = "R7";
                        cmbSTContrato.SelectedValue = 1;// 1=Normal
                        if (ptosporanio >= 680 && ptosporanio < 880) cmbSTContrato.SelectedValue = 5;
                        if (ptosporanio >= 880) cmbSTContrato.SelectedValue = 6;
                        break;
                    case "4":
                        txtTCalendario.Text = "";
                        txtTCalendario.Enabled = true;
                        corrCR = Globales.gCorrelativoC4;
                        txtNroContrato.Text = "4";
                        cmbSTContrato.SelectedValue = 1;// 1=Normal
                        if (ptosporanio >= 680 && ptosporanio < 880) cmbSTContrato.SelectedValue = 5;
                        if (ptosporanio >= 880) cmbSTContrato.SelectedValue = 6;
                        break;
                    case "R4":
                        txtTCalendario.Text = "";
                        txtTCalendario.Enabled = true;
                        corrCR = Globales.gCorrelativoR4;
                        txtNroContrato.Text = "R4";
                        cmbSTContrato.SelectedValue = 1;// 1=Normal
                        if (ptosporanio >= 680 && ptosporanio < 880) cmbSTContrato.SelectedValue = 5;
                        if (ptosporanio >= 880) cmbSTContrato.SelectedValue = 6;
                        break;
                    case "9":
                        txtTCalendario.Text = "";
                        txtTCalendario.Enabled = true;
                        corrCR = Globales.gCorrelativoC9;
                        txtNroContrato.Text = "9";
                        cmbSTContrato.SelectedValue = 1;// 1=Normal
                        if (ptosporanio >= 680 && ptosporanio < 880) cmbSTContrato.SelectedValue = 5;
                        if (ptosporanio >= 880) cmbSTContrato.SelectedValue = 6;
                        break;
                    case "R9":
                        txtTCalendario.Text = "";
                        txtTCalendario.Enabled = true;
                        corrCR = Globales.gCorrelativoR9;
                        txtNroContrato.Text = "R9";
                        cmbSTContrato.SelectedValue = 1;// 1=Normal
                        if (ptosporanio >= 680 && ptosporanio < 880) cmbSTContrato.SelectedValue = 5;
                        if (ptosporanio >= 880) cmbSTContrato.SelectedValue = 6;
                        break;


                }

                if (codTCR != "9" && codTCR != "R9" && codTCR != "5" && codTCR != "6" && codTCR != "R6" && codTCR != "7" && codTCR != "R7" && codTCR != "4" && codTCR != "R4")
                {
                    cmbSTContrato.SelectedValue = 1;// 1=Normal
                    ptosporanio = 440;
                }

                if (codTCR == "5")
                {
                    cmbSTContrato.SelectedValue = 1;// 1=Normal
                    cmbSTContrato.Enabled = false;
                    hasta24cuotas = true;
                }
                else
                {
                    cmbSTContrato.Enabled = true;
                    hasta24cuotas = false;
                }


                /*
                corrCR++;*/
                //txtNroContrato.Text = txtNroContrato.Text.Trim() + Globales.emp.codigo + datprin_ult_4dig_ctto();
                txtNroContrato.Text = datprin_generar_nrctto();
                
            }
            

        }
        private void cmbPrograma_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!evt)
                datprin_cargar_cmblocacion();
                
            
        }

        private void btnResetInic_Click(object sender, EventArgs e)
        {
            txtIPactada.Text = "";
            txtPorcIPactada.Text = "0";
            txtIHoy.Text = "";
            txtPIHoy.Text = "0";
            cmbInstrumentoFPIH.SelectedIndex = -1;
            cmbBancoFPIH.SelectedIndex = -1;
            txtNrFPIH.Text = "";
            txtMontoFPIH.Text = "";
            dtpFVencFPIH.Value = DateTime.Today;
            dtgrFPIH.Rows.Clear();
            financ_limpiar_campos();
            compl_limpiar_campos();
        }

        private void txtPorcIPactada_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                
                compl_limpiar_campos();
                double nr = Globales.txt_a_double(txtPorcIPactada.Text);
                
                    if (nr < 30 || nr>100)
                    {
                        MessageBox.Show("El porcentaje de Inicial Pactada debe oscilar de 30 a 100%", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        inicialpactada = 0;
                        txtIPactada.Text = "";
                        txtPorcIPactada.Text = "0";
                        financ_limpiar_campos();
                        grbxF.Enabled = false;
                        grbxFE.Enabled = false;
                        return;
                    }
                    else
                    {
                        inicialpactada = calcular_monto_por_porc(txtPorcIPactada.Text, preciocompra);
                        txtIPactada.Text = String.Format("{0:N}", decimal.Parse(Convert.ToString(inicialpactada)));
                        financ_autollenado_campos_por_inic_pact();
                        compl_llenar_campos();
                        return;
                    }
                
            }
        }

        private void txtPIHoy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                double nr = Globales.txt_a_double(txtPIHoy.Text);
                double nr2 = Globales.txt_a_double(txtPorcIPactada.Text);
                compl_limpiar_campos();
                if (nr!=-1)
                {
                    if (nr2 != -1)
                    {
                        if (nr > nr2)
                        {
                            MessageBox.Show("El porcentaje de Inicial Hoy no puede ser mayor al porcentaje de Inicial Pactada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            inicialhoy = 0;
                            txtPIHoy.Text = "0";
                            txtIHoy.Text = "";
                            return;
                        }

                        inicialhoy = calcular_monto_por_porc(txtPIHoy.Text,preciocompra);
                        txt_inicialhoy = inicialhoy;
                        txtIHoy.Text = String.Format("{0:N}", decimal.Parse(Convert.ToString(inicialhoy)));
                        txtMontoFPIH.Text = Convert.ToString(inicialhoy);

                        if (nr < 10)
                            txtEstatus.Text = "RESERVA";
                        else if (nr < 30)
                            txtEstatus.Text = "PENDING";
                        else
                            txtEstatus.Text = "PROCESABLE";

                        
                        compl_llenar_campos();
                        dtgrFPIH.Rows.Clear();

                        return;
                    }

                    
                }

                inicialhoy = 0;
                txtPIHoy.Text = "0";
                txtIHoy.Text = "";
                return;
            }
        }

        private void txtMontoFPIH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                if (cmbInstrumentoFPIH.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe elegir un instrumento para la forma de pago inicial de hoy", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;        
                }
                if (cmbBancoFPIH.SelectedIndex == -1 && cmbInstrumentoFPIH.Text!="EFECTIVO")
                {
                    MessageBox.Show("Debe elegir un banco para la forma de pago inicial de hoy", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtNrFPIH.Text) && cmbInstrumentoFPIH.Text != "EFECTIVO")
                {
                    MessageBox.Show("Debe colocar un número para la forma de pago inicial de hoy", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (dias_entre_fechas(dtpFContrato.Value, dtpFVencFPIH.Value) > 30)
                {
                    MessageBox.Show("La Fecha de Vencimiento para la forma de pago inicial de hoy, no debe exceder de 30 días con respecto a la Fecha del Contrato", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (inicialhoy == 0)
                {
                    MessageBox.Show("Debe ingresar un porcentaje de Pago Inicial Hoy", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                double nr = Globales.txt_a_double(txtMontoFPIH.Text);
                if (nr!= -1)
                {
                    if (nr > txt_inicialhoy)
                    {
                        MessageBox.Show("El monto a ingresar supera al monto restante de Pago Inicial Hoy", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtMontoFPIH.Text = Convert.ToString(txt_inicialhoy).Replace(",", ".");
                        return;
                    }
                }

                cmbBancoFPIH.Text = cmbInstrumentoFPIH.Text == "EFECTIVO" ? "NO BANCO" : cmbBancoFPIH.Text;
                dtgrFPIH.Rows.Add(cmbInstrumentoFPIH.Text, cmbInstrumentoFPIH.SelectedValue, cmbBancoFPIH.Text, cmbBancoFPIH.SelectedValue, txtNrFPIH.Text, txtMontoFPIH.Text, dtpFVencFPIH.Value.ToShortDateString());
                txt_inicialhoy -= Convert.ToDouble(txtMontoFPIH.Text.Replace(".", ","));
                txtMontoFPIH.Text = Convert.ToString(txt_inicialhoy).Replace(",", ".");
            
            }
        }

        
        #endregion

        #endregion

        #region PESTAÑA CO-PROPIETARIOS

        #region Métodos
        public void copr_limpiar_form()
        {
            cmbTDocCopr.SelectedIndex = -1;
            txtCedulaCopr.Text = "";
            txtNombreCopr.Text = "";
            txtApellidoCopr.Text = "";
            cmbParentCopr.SelectedIndex = -1;
            idcopr = -1;
            index_dtcopr = -1;


        }


        //Busca cédula en datagrid (evitar repetición)
        public bool copr_cedula_repetida_dtgr()
        {
            if (!string.IsNullOrWhiteSpace(txtCedulaCopr.Text))
            {

                int index2 = 0;
                foreach (DataGridViewRow rw in dtgrCopr.Rows)
                {
                    if (  txtCedulaCopr.Text == Convert.ToString(rw.Cells[2].Value) && (index_dtcopr==-1 || index_dtcopr!=index2))
                        return true;

                    index2++;
                }
            }
            
            return false;
        }


        public void copr_cargar_cmbparent()
        {
            cmbParentCopr.Items.Insert(0, "HIJO(A)");
            cmbParentCopr.Items.Insert(1, "CÓNYUGE");
            cmbParentCopr.Items.Insert(2, "AMIGO(A)");
            cmbParentCopr.Items.Insert(3, "HERMANO(A)");
            cmbParentCopr.Items.Insert(4, "PRIMO(A)");
            cmbParentCopr.Items.Insert(5, "FAMILIAR");
            cmbParentCopr.Items.Insert(6, "SOCIO");
            cmbParentCopr.Items.Insert(7, "PADRE");
            cmbParentCopr.Items.Insert(8, "MADRE");
            cmbParentCopr.Items.Insert(9, "ABUELO(A)");
            cmbParentCopr.Items.Insert(10, "TÍO(A)");
            cmbParentCopr.Items.Insert(11, "DDESCONOCIDO");
        }

        //Busca asociados en base de datos por cédula, de haber  coincidencia, llena el resto de los campos automáticamente
        public void copr_llenar_campos_por_cedula()
        {


            if (copr_cedula_repetida_dtgr())
            {
                MessageBox.Show("La cédula ingresada, se encuentra en la lista", "Cédula repetida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                copr_limpiar_form();
            }
            else if (!string.IsNullOrWhiteSpace(txtCedulaCopr.Text))
            {
                string txtSQL = (cmbTDocCopr.SelectedIndex != -1) ? "SELECT * FROM Asociados WHERE Cedula='" + txtCedulaCopr.Text + "' AND Nacionalidad='" + cmbTDocCopr.Text + "'" : "SELECT * FROM Asociados WHERE Cedula='" + txtCedulaCopr.Text + "'";
                Globales.BD.dtt = Globales.BD.generar_datatable(txtSQL, CommandType.Text, new List<Clases.Parameters>());

                foreach (DataRow pRow in Globales.BD.dtt.Rows)
                {
                    txtNombreCopr.Text = Convert.ToString(pRow["Nombres"]).TrimEnd(' ');
                    txtApellidoCopr.Text = pRow["Apellidos"] != DBNull.Value ? Convert.ToString(pRow["Apellidos"]).TrimEnd(' ') : "";
                    cmbParentCopr.Text = pRow["Parentesco"] != DBNull.Value ? Convert.ToString(pRow["Parentesco"]).TrimEnd(' ') : "";
                    idcopr = Convert.ToInt32(pRow["ID"]);
                }

            }
        }

        public void copr_insertar_fila_dtgr()
        {
            dtgrCopr.Rows.Add("-1", cmbTDocCopr.Text, txtCedulaCopr.Text, cmbTDocCopr.Text + "-" + txtCedulaCopr.Text, txtNombreCopr.Text.ToUpper(), txtApellidoCopr.Text.ToUpper(), cmbParentCopr.Text);
                
        }

        public void copr_editar_fila_dtgr()
        {
            dtgrCopr.Rows[index_dtcopr].Cells[1].Value = cmbTDocCopr.Text;
            dtgrCopr.Rows[index_dtcopr].Cells[2].Value = txtCedulaCopr.Text;
            dtgrCopr.Rows[index_dtcopr].Cells[3].Value = cmbTDocCopr.Text +"-"+ txtCedulaCopr.Text;
            dtgrCopr.Rows[index_dtcopr].Cells[4].Value = txtNombreCopr.Text.ToUpper();
            dtgrCopr.Rows[index_dtcopr].Cells[5].Value = txtApellidoCopr.Text.ToUpper();
            dtgrCopr.Rows[index_dtcopr].Cells[6].Value = cmbParentCopr.Text;

        }
        #endregion

        #region Eventos

        private void btnNuevoCopr_Click(object sender, EventArgs e)
        {
            copr_limpiar_form();
        }

        private void cmbTDocCopr_Leave(object sender, EventArgs e)
        {
            copr_llenar_campos_por_cedula();
        }

        private void txtCedulaCopr_Leave(object sender, EventArgs e)
        {
            copr_llenar_campos_por_cedula();
        }

        private void btnGuardarCopr_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCedulaCopr.Text) || cmbTDocCopr.SelectedIndex == -1)
                MessageBox.Show("Campo cédula vacío", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (string.IsNullOrWhiteSpace(txtNombreCopr.Text))
                MessageBox.Show("Campo nombre vacío", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (string.IsNullOrWhiteSpace(txtApellidoCopr.Text))
                MessageBox.Show("Campo apellido vacío", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (cmbParentCopr.SelectedIndex == -1)
                MessageBox.Show("Campo parentesco vacío", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (copr_cedula_repetida_dtgr())
                MessageBox.Show("Cédula existente en la tabla de asociados", "Cédula repetida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {


                if (index_dtcopr == -1)
                    copr_insertar_fila_dtgr();
                else
                    copr_editar_fila_dtgr();

                copr_limpiar_form();
            }
        }

        private void dtgrCopr_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!(e.RowIndex > -1))
                return;

            index_dtcopr = e.RowIndex;
            
            cmbTDocCopr.Text = dtgrCopr.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtCedulaCopr.Text = dtgrCopr.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtNombreCopr.Text = dtgrCopr.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtApellidoCopr.Text = dtgrCopr.Rows[e.RowIndex].Cells[5].Value.ToString();
            cmbParentCopr.Text = dtgrCopr.Rows[e.RowIndex].Cells[6].Value.ToString();
            

        }

        private void btnEliminarCopr_Click(object sender, EventArgs e)
        {
            if (dtgrCopr.CurrentRow == null)
                MessageBox.Show("Debe elegir un co-propietario en la lista", "Co-propietario no seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {

                var result = MessageBox.Show("¿Está seguro que desea eliminar la fila seleccionada?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                    dtgrCopr.Rows.RemoveAt(dtgrCopr.CurrentRow.Index);
            }

        }


        #endregion


        #endregion

        #region PESTAÑA COMPLEMENTO

        #region Métodos

        public void compl_limpiar_campos(){
            txtMontoComp.Text = "";
            compl = 0;
            txt_compl = 0;
            txtComplemento.Text = "";
            txtPorcComp.Text = "";
            dtgrComp.Rows.Clear();

        }

        public void compl_llenar_campos()
        {
            compl = inicialpactada - inicialhoy;
            txt_compl = compl;
            txtComplemento.Text = String.Format("{0:N}", decimal.Parse(Convert.ToString(compl)));
            txtMontoComp.Text = Convert.ToString(compl);
            txtPorcComp.Text = String.Format("{0:N}", decimal.Parse(Convert.ToString(comp_porc())));
        }

        public double comp_porc()
        {
            double ip = string.IsNullOrWhiteSpace(txtPorcIPactada.Text) ? 0 : Convert.ToDouble(txtPorcIPactada.Text.Replace('.', ','));
            double ih = string.IsNullOrWhiteSpace(txtPIHoy.Text) ? 0 : Convert.ToDouble(txtPIHoy.Text.Replace('.', ','));
            return ip - ih;
        }

        #endregion

        #region Eventos

        private void txtMontoComp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                if (cmbInstrumentoComp.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe elegir un instrumento para la forma de pago del complemento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (cmbBancoComp.SelectedIndex == -1 && cmbInstrumentoComp.Text != "EFECTIVO")
                {
                    MessageBox.Show("Debe elegir un banco para la forma de pago del complemento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtNrComp.Text) && cmbInstrumentoComp.Text != "EFECTIVO")
                {
                    MessageBox.Show("Debe colocar un número para la forma de pago del complemento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (dias_entre_fechas(dtpFContrato.Value, dtpFVencComp.Value) > 30)
                {
                    MessageBox.Show("La Fecha de Vencimiento para la forma de pago inicial de hoy, no debe exceder de 30 días con respecto a la Fecha del Contrato", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtMontoComp.Text))
                {
                    MessageBox.Show("El Monto no debe estar vacío", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (Convert.ToDouble(txtMontoComp.Text) == 0)
                {
                    MessageBox.Show("El Monto debe ser mayor que 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                double nr = Globales.txt_a_double(txtMontoComp.Text);
                if (nr!=-1)
                {
                    if (nr > txt_compl)
                    {
                        MessageBox.Show("El monto a ingresar supera al monto restante del complemento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtMontoComp.Text = Convert.ToString(txt_compl).Replace(",", ".");
                        return;
                    }
                }

                if (dias_entre_fechas(dtpAPDFinanc.Value, dtpFVencComp.Value  ) > 0)
                {
                    MessageBox.Show("La fecha de la primera cuota mensual (financiamiento) no puede ser menor a la fecha de la cuota de la inicial complementaria", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                cmbBancoComp.Text = cmbInstrumentoComp.Text == "EFECTIVO" ? "NO BANCO" : cmbBancoComp.Text;
                dtgrComp.Rows.Add(cmbInstrumentoComp.Text, cmbInstrumentoComp.SelectedValue, cmbBancoComp.Text, cmbBancoComp.SelectedValue, txtNrComp.Text, txtMontoComp.Text, dtpFVencComp.Value.ToShortDateString());
                txt_compl -= Convert.ToDouble(txtMontoComp.Text.Replace(".", ","));
                txtMontoComp.Text = Convert.ToString(txt_compl).Replace(",", ".");

            }
        }

        #endregion

        #endregion

        #region PESTAÑA FINANCIAMIENTOS

        #region Métodos

        public void financ_cargar_factores()
        {
            string txtSQL = "Select * From FActores Where Tasa='" + cmbTAnualFinanc.Text + "'";
            Globales.BD.dtt = Globales.BD.generar_datatable(txtSQL, CommandType.Text, new List<Clases.Parameters>());
            foreach (DataRow pRow in Globales.BD.dtt.Rows)
            {
                fact_6m=Convert.ToDouble(pRow["6Meses"]);
                fact_12m = Convert.ToDouble(pRow["12Meses"]);
                fact_18m = Convert.ToDouble(pRow["18Meses"]);
                fact_24m = Convert.ToDouble(pRow["24Meses"]);
                fact_30m = Convert.ToDouble(pRow["30Meses"]);
                fact_36m = Convert.ToDouble(pRow["36Meses"]);
                fact_an = Convert.ToDouble(pRow["Anualidad"]);
                fact_sm = Convert.ToDouble(pRow["Semestralidad"]);
                fact_tr = Convert.ToDouble(pRow["Trimestralidad"]);
            }
        }

        public void financ_limpiar_campos()
        {
            //evt = true;
            f_saf = 0;
            fe_saf = 0;
            txtSAFFinanc.Text = "";
            txtPorcFinanc.Text = "";
            //cmbNCuotasFinanc.SelectedIndex = -1;
            txtMontoCuotaFinanc.Text = "";
            txtDiasFinanc.Text = "";
            dtpAPDFinanc.Value = DateTime.Today.AddDays(30);
            cmbTFinFE.SelectedIndex = -1;
            //cmbPorcTAFE.SelectedIndex = -1;
            txtSAFFE.Text = "";
            txtPorcFE.Text = "";
            nudNCuoFE.Text = "0";
            txtMonCuoFE.Text = "";
            dtpADEFE.Value = DateTime.Today;
            grbxF.Enabled = false;
            grbxFE.Enabled = false;
            //evt = false;
        }

        public void financ_autollenado_campos_por_inic_pact()
        {

            //evt = true;
            total_financ = preciocompra - inicialpactada;
            f_saf = total_financ;
            fe_saf = 0;
            txtSAFFinanc.Text = String.Format("{0:N}", decimal.Parse(Convert.ToString(f_saf)));
            txtPorcFinanc.Text = "100";
            txtPorcFE.Text = "0";
            cmbTFinFE.Enabled = false;
            cmbTFinFE.SelectedIndex = -1;
            txtSAFFE.Text = String.Format("{0:N}", decimal.Parse(Convert.ToString(fe_saf)));
            //cmbNCuotasFinanc.SelectedIndex = -1;
            txtMontoCuotaFinanc.Text = "";
            txtDiasFinanc.Text = "";
            dtpAPDFinanc.Value = DateTime.Today.AddDays(30);
            cmbTFinFE.SelectedIndex = -1;
            //cmbPorcTAFE.SelectedIndex = -1;
            txtSAFFE.Text = "";
            txtPorcFE.Text = "";
            nudNCuoFE.Text = "0";
            txtMonCuoFE.Text = "";
            dtpADEFE.Value = DateTime.Today;
            grbxF.Enabled = true;
            grbxFE.Enabled = false;
            //evt = false;

        }

        public void financ_cargar_cmbtipfin()
        {
            cmbTFinFE.Items.Insert(0, "TRIMESTRAL");
            cmbTFinFE.Items.Insert(1, "SEMESTRAL");
            cmbTFinFE.Items.Insert(2, "ANUAL");
        }

        public void financ_cargar_cmbncuotas()
        {
            cmbNCuotasFinanc.Items.Insert(0, "1");
            cmbNCuotasFinanc.Items.Insert(1, "6");
            cmbNCuotasFinanc.Items.Insert(2, "12");
            
        }

        

        public void financ_cargar_cmbtasasanuales()
        {

            evt = true;
            cmbTAnualFinanc.Items.Insert(0, "12");
            cmbTAnualFinanc.Items.Insert(1, "22");
            cmbTAnualFinanc.Text="22";

            cmbPorcTAFE.Items.Insert(0, "0");
            cmbPorcTAFE.Items.Insert(1, "12");
            cmbPorcTAFE.Items.Insert(2, "22");
            cmbPorcTAFE.Text = "22";

            evt = false;
        }

        #endregion

        #region Eventos

        private void txtDiasFinanc_KeyUp(object sender, KeyEventArgs e)
        {

            string strdias = txtDiasFinanc.Text;
            if (string.IsNullOrEmpty(strdias))
                dtpAPDFinanc.Value = DateTime.Today;
            else
            {

                int intdias = Convert.ToInt32(strdias);
                if (intdias > 90)
                {

                    MessageBox.Show("Debe elegir un banco para la forma de pago del complemento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDiasFinanc.Text = "";
                    dtpAPDFinanc.Value = DateTime.Today;

                }
                else
                    dtpAPDFinanc.Value = DateTime.Today.AddDays(intdias);

            }


        }

        private void dtpAPDFinanc_KeyUp(object sender, KeyEventArgs e)
        {
            if (dtpAPDFinanc.Value != null)
                txtDiasFinanc.Text = Convert.ToString(dias_entre_fechas(DateTime.Today, dtpAPDFinanc.Value));

        }

        private void dtpAPDFinanc_ValueChanged(object sender, EventArgs e)
        {
            if (dtpAPDFinanc.Value != null)
                txtDiasFinanc.Text = Convert.ToString(dias_entre_fechas(DateTime.Today, dtpAPDFinanc.Value));
        }

        private void txtPorcFinanc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                double nr = Globales.txt_a_double(txtPorcFinanc.Text);
                if (nr!=-1)
                {
                    if (nr > 100)
                    {
                        MessageBox.Show("El porcentaje de Saldo a Financiar no debe sobrepasar el 100%", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        financ_autollenado_campos_por_inic_pact();
                        return;
                    }


                    f_saf = calcular_monto_por_porc(txtPorcFinanc.Text, total_financ);
                    txtSAFFinanc.Text = String.Format("{0:N}", decimal.Parse(Convert.ToString(f_saf)));
                    txtPorcFE.Text = Convert.ToString(100-nr);
                    fe_saf = calcular_monto_por_porc(txtPorcFE.Text,total_financ);
                    txtSAFFE.Text = String.Format("{0:N}", decimal.Parse(Convert.ToString(fe_saf)));
                    

                    if (nr == 100)
                    {
                        grbxFE.Enabled = false;
                        cmbTFinFE.Enabled = false;
                        if (cmbTFinFE.Items.Count==2)
                            cmbTFinFE.Items.Insert(2, "ANUAL");

                    }
                    else
                    {
                        
                        grbxFE.Enabled = true;
                        cmbTFinFE.Enabled = true;
                        if (100 - nr >= 50 && cmbTFinFE.Items.Count == 3)
                            cmbTFinFE.Items.RemoveAt(2);
                        else if (100 - nr < 50 && cmbTFinFE.Items.Count == 2)
                            cmbTFinFE.Items.Insert(2, "ANUAL");

                    }

                    
                    cmbNCuotasFinanc_SelectedValueChanged(sender, e);

                    return;
                }
                inicialpactada = 0;
                txtIPactada.Text = "";
                cmbNCuotasFinanc_SelectedValueChanged(sender, e);
                return;
            }
        }

        private void cmbNCuotasFinanc_SelectedValueChanged(object sender, EventArgs e)
        {

                if (cmbNCuotasFinanc.SelectedIndex != -1)
                {
                    
                    if (cmbNCuotasFinanc.Text == "1" || cmbNCuotasFinanc.Text == "6")
                    {
                        mcuo_saf = f_saf / Convert.ToDouble(cmbNCuotasFinanc.Text);
                        cmbTFinFE.SelectedIndex = -1;
                        cmbTFinFE.Enabled = false;
                        financ_autollenado_campos_por_inic_pact();
                        txtMontoCuotaFinanc.Text = String.Format("{0:N}", decimal.Parse(Convert.ToString(mcuo_saf)));
                        //cmbTFinFE_SelectedIndexChanged(sender, e);
                        
                    }
                    else if (cmbNCuotasFinanc.Text == "12" || cmbNCuotasFinanc.Text == "18" || cmbNCuotasFinanc.Text == "24")
                    {
                        if (cmbPorcTAFE.Text == "0")
                            mcuo_saf = f_saf / Convert.ToDouble(cmbNCuotasFinanc.Text);
                        else if (cmbNCuotasFinanc.Text == "12")
                            mcuo_saf = f_saf * fact_12m;
                        else if (cmbNCuotasFinanc.Text == "18")
                            mcuo_saf = f_saf * fact_18m;   
                        else if (cmbNCuotasFinanc.Text == "24")
                            mcuo_saf = f_saf * fact_24m;
                            

                        txtMontoCuotaFinanc.Text = String.Format("{0:N}", decimal.Parse(Convert.ToString(mcuo_saf)));
                        cmbTFinFE_SelectedIndexChanged(sender, e);
                    }
                    else if (cmbNCuotasFinanc.Text == "36")
                    {
                            
                            if ((codTCR != "1" && codTCR != "RT" && codTCR != "R6" && codTCR != "6") || (txtAniosCT.Text == "10" && (codTCR == "1" || codTCR == "RT")))
                            {
                                MessageBox.Show("Financiamiento  a 36 meses es sólo para los contratos CT/RT mayores a 10 años y los LP/R6", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                MessageBox.Show("El financiamiento a 36 no se puede usar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                cmbNCuotasFinanc.SelectedIndex = -1;
                                mcuo_saf = 0;
                                txtMontoCuotaFinanc.Text = "";
                                mcuo_safe = 0;
                                txtMonCuoFE.Text = "";
                                nrocuotas = 0;
                                nudNCuoFE.Text = "";
                                return;
                            }

                            if (dias_entre_fechas(new DateTime(2013, 11, 5, 0, 0, 0), dtpFContrato.Value) >= 0)
                            {
                                if (chkVSContrato.Checked)
                                {
                                    mcuo_saf = f_saf / Convert.ToDouble(cmbNCuotasFinanc.Text);
                                    cmbTFinFE.SelectedIndex = -1;
                                    cmbTFinFE.Enabled = false;
                                    financ_autollenado_campos_por_inic_pact();
                                    txtMontoCuotaFinanc.Text = String.Format("{0:N}", decimal.Parse(Convert.ToString(mcuo_saf)));
                                    cmbTFinFE_SelectedIndexChanged(sender, e);

                                }
                            }

                            if (hasta24cuotas)
                            {
                                MessageBox.Show("No se pueden seleccionar mas de 24 cuotas porque es una contrato de tipo CF", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                cmbNCuotasFinanc.Text = "24";
                                txtMontoCuotaFinanc.Text = "0";
                                mcuo_saf = 0;
                                txtMontoCuotaFinanc.Text = String.Format("{0:N}", decimal.Parse(Convert.ToString(mcuo_saf)));
                                cmbTFinFE_SelectedIndexChanged(sender, e);
                                return;
                            }

                            if (cmbTAnualFinanc.Text== "0")
                                mcuo_saf = f_saf / 36;
                            else 
                                mcuo_saf = f_saf * fact_36m;
                            
                        
                        txtMontoCuotaFinanc.Text = String.Format("{0:N}", decimal.Parse(Convert.ToString(mcuo_saf)));
                        cmbTFinFE_SelectedIndexChanged(sender, e);

                    }
                    

                }
            
            
            
        }

        private void cmbTFinFE_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            //if (cmbTFinFE.SelectedIndex != 1)
            if (cmbNCuotasFinanc.SelectedIndex != -1 && cmbPorcTAFE.Text != "0" && cmbNCuotasFinanc.Text != "1")
            {

                string txtSQL = "Select * From FactoresFinanciamientoEspecial Where Tasa='" + cmbPorcTAFE.Text + "' And NroMesesFinanciar=" + cmbNCuotasFinanc.Text;
                Globales.BD.dtt = Globales.BD.generar_datatable(txtSQL, CommandType.Text, new List<Clases.Parameters>());
                double anldd=0;
                double smstrldd=0;
                double trmstrldd=0;
                foreach (DataRow pRow in Globales.BD.dtt.Rows)
                {
                    anldd = pRow["Anualidad"] != DBNull.Value ? Convert.ToDouble(pRow["Anualidad"]) : 0;
                    smstrldd = pRow["Semestralidad"] != DBNull.Value ? Convert.ToDouble(pRow["Semestralidad"]) : 0;
                    trmstrldd = pRow["trimestralidad"] != DBNull.Value ? Convert.ToDouble(pRow["trimestralidad"]) : 0;
                }


                switch (cmbTFinFE.Text)
                {
                    case "ANUAL":
                        if (cmbNCuotasFinanc.Text == "18")
                        {
                            MessageBox.Show("No se puede tomar Financiamiento Especial Anual en cuotas de 18 meses", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            cmbTFinFE.SelectedIndex = -1;
                            nrocuotas = 0;
                            nudNCuoFE.Text = "";
                            txtMonCuoFE.Text = "";
                            return;
                        }
                        if (cmbNCuotasFinanc.Text == "6")
                        {
                            MessageBox.Show("No se puede tomar Financiamiento Especial Anual en cuotas de 6 meses", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            cmbTFinFE.SelectedIndex = -1;
                            nrocuotas = 0;
                            nudNCuoFE.Text = "";
                            txtMonCuoFE.Text = "";
                            return;
                        }
                        dtpADEFE.Value = DateTime.Today.AddMonths(12);
                        nrocuotas = Convert.ToInt32(cmbNCuotasFinanc.Text) / 12;
                        mcuo_safe = fe_saf * anldd;
                        break;
                    case "SEMESTRAL":
                        dtpADEFE.Value = DateTime.Today.AddMonths(6);
                        nrocuotas = Convert.ToInt32(cmbNCuotasFinanc.Text) / 6;
                        mcuo_safe = fe_saf * smstrldd;
                        break;
                    case "TRIMESTRAL":
                        dtpADEFE.Value = DateTime.Today.AddMonths(3);
                        nrocuotas = Convert.ToInt32(cmbNCuotasFinanc.Text) / 3;
                        mcuo_safe = fe_saf * trmstrldd;
                        break;
                }
                nudNCuoFE.Text = Convert.ToString(nrocuotas);
                txtMonCuoFE.Text = String.Format("{0:N}", decimal.Parse(Convert.ToString(mcuo_safe)));


            }
            else if (cmbPorcTAFE.Text == "0")
            {
                nudNCuoFE.Text = "";
                txtMonCuoFE.Text = "";
                nrocuotas = 0;
                mcuo_safe = 0;   
            }
            
        }

        private void cmbTAnualFinanc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!evt && cmbTAnualFinanc.SelectedIndex != -1)
                cmbNCuotasFinanc_SelectedValueChanged(sender, e);
        }

        private void txtPorcFE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                double nr = Globales.txt_a_double(txtPorcFE.Text);
                if (nr!=-1)
                {
                    if (nr >= 100)
                    {
                        MessageBox.Show("El porcentaje de Saldo a Financiar debe sermenor que 100%", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        financ_autollenado_campos_por_inic_pact();
                        return;
                    }

                    fe_saf = calcular_monto_por_porc(txtPorcFE.Text, total_financ);
                    txtSAFFE.Text = String.Format("{0:N}", decimal.Parse(Convert.ToString(fe_saf)));


                    txtPorcFinanc.Text = Convert.ToString(100 - nr);

                    f_saf = calcular_monto_por_porc(txtPorcFinanc.Text, total_financ);
                    txtSAFFinanc.Text = String.Format("{0:N}", decimal.Parse(Convert.ToString(f_saf)));


                    


                    if (nr == 100)
                    {
                        grbxFE.Enabled = false;
                        cmbTFinFE.Enabled = false;
                        if (cmbTFinFE.Items.Count == 2)
                            cmbTFinFE.Items.Insert(2, "ANUAL");

                    }
                    else
                    {

                        grbxFE.Enabled = true;
                        cmbTFinFE.Enabled = true;
                        if (100 - nr >= 50 && cmbTFinFE.Items.Count == 3)
                            cmbTFinFE.Items.RemoveAt(2);
                        else if (100 - nr < 50 && cmbTFinFE.Items.Count == 2)
                            cmbTFinFE.Items.Insert(2, "ANUAL");

                    }


                    cmbNCuotasFinanc_SelectedValueChanged(sender, e);

                    return;
                }
                inicialpactada = 0;
                txtIPactada.Text = "";
                cmbNCuotasFinanc_SelectedValueChanged(sender, e);
                return;
            }
        }

        private void cmbPorcTAFE_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbTFinFE_SelectedIndexChanged(sender, e);
        }

        
        #endregion

        #endregion

        #region PESTAÑA EMPLEADOS

        #region Métodos

        public void empl_cargar_cmbempleados()
        {
            evt = true;

            #region Gerentes

            string txtSQL = "SELECT * FROM empleados WHERE codigoCargo=2";
            Globales.BD.dtt = Globales.BD.generar_datatable(txtSQL, CommandType.Text, new List<Clases.Parameters>());
            cmbGteVtas.DataSource = Globales.BD.dtt;
            cmbGteVtas.ValueMember = "CODIGO";
            cmbGteVtas.DisplayMember = "NOMBRE";
            /*
            cmbGteVtas.SelectedValue = "NOGV";
            txtCodGteVtas.Text = "NOGV";*/

            txtSQL = "SELECT * FROM empleados WHERE codigoCargo=3";
            Globales.BD.dtt = Globales.BD.generar_datatable(txtSQL, CommandType.Text, new List<Clases.Parameters>());
            cmbGteMdo.DataSource = Globales.BD.dtt;
            cmbGteMdo.ValueMember = "CODIGO";
            cmbGteMdo.DisplayMember = "NOMBRE";/*
            cmbGteMdo.SelectedValue = "NOGM";
            txtCodGteMdo.Text = "NOGM";*/

            #endregion
            #region Liners

            txtSQL = "SELECT * FROM empleados WHERE codigoCargo=4 AND Estado=1";
            Globales.BD.dtt = Globales.BD.generar_datatable(txtSQL, CommandType.Text, new List<Clases.Parameters>());
            cmbLiner1.DataSource = Globales.BD.dtt;
            cmbLiner1.ValueMember = "CODIGO";
            cmbLiner1.DisplayMember = "NOMBRE";
            

            txtSQL = "SELECT * FROM empleados WHERE codigoCargo=4 AND Estado=1";
            Globales.BD.dtt = Globales.BD.generar_datatable(txtSQL, CommandType.Text, new List<Clases.Parameters>());
            cmbLiner2.DataSource = Globales.BD.dtt;
            cmbLiner2.ValueMember = "CODIGO";
            cmbLiner2.DisplayMember = "NOMBRE";
            cmbLiner2.SelectedIndex = -1;

            txtSQL = "SELECT * FROM empleados WHERE codigoCargo=4 AND Estado=1";
            Globales.BD.dtt = Globales.BD.generar_datatable(txtSQL, CommandType.Text, new List<Clases.Parameters>());
            cmbLiner3.DataSource = Globales.BD.dtt;
            cmbLiner3.ValueMember = "CODIGO";
            cmbLiner3.DisplayMember = "NOMBRE";
            cmbLiner3.SelectedIndex = -1;

            #endregion
            #region Closers

            txtSQL = "SELECT * FROM empleados WHERE codigoCargo=5 AND Estado=1";
            Globales.BD.dtt = Globales.BD.generar_datatable(txtSQL, CommandType.Text, new List<Clases.Parameters>());
            cmbCloser1.DataSource = Globales.BD.dtt;
            cmbCloser1.ValueMember = "CODIGO";
            cmbCloser1.DisplayMember = "NOMBRE";
            

            txtSQL = "SELECT * FROM empleados WHERE codigoCargo=5 AND Estado=1";
            Globales.BD.dtt = Globales.BD.generar_datatable(txtSQL, CommandType.Text, new List<Clases.Parameters>());
            cmbCloser2.DataSource = Globales.BD.dtt;
            cmbCloser2.ValueMember = "CODIGO";
            cmbCloser2.DisplayMember = "NOMBRE";
            cmbCloser2.SelectedIndex = -1;

            txtSQL = "SELECT * FROM empleados WHERE codigoCargo=5 AND Estado=1";
            Globales.BD.dtt = Globales.BD.generar_datatable(txtSQL, CommandType.Text, new List<Clases.Parameters>());
            cmbCloser3.DataSource = Globales.BD.dtt;
            cmbCloser3.ValueMember = "CODIGO";
            cmbCloser3.DisplayMember = "NOMBRE";
            cmbCloser3.SelectedIndex = -1;

            #endregion
            #region Promotores

            txtSQL = "SELECT * FROM empleados WHERE codigoCargo=12 AND Estado=1";
            Globales.BD.dtt = Globales.BD.generar_datatable(txtSQL, CommandType.Text, new List<Clases.Parameters>());
            cmbProm1.DataSource = Globales.BD.dtt;
            cmbProm1.ValueMember = "CODIGO";
            cmbProm1.DisplayMember = "NOMBRE";
            cmbProm1.SelectedIndex = -1;

            txtSQL = "SELECT * FROM empleados WHERE codigoCargo=12 AND Estado=1";
            Globales.BD.dtt = Globales.BD.generar_datatable(txtSQL, CommandType.Text, new List<Clases.Parameters>());
            cmbProm2.DataSource = Globales.BD.dtt;
            cmbProm2.ValueMember = "CODIGO";
            cmbProm2.DisplayMember = "NOMBRE";
            cmbProm2.SelectedIndex = -1;

            #endregion
            #region Sup OPC

            txtSQL = "SELECT * FROM empleados WHERE codigoCargo=21 AND Estado=1";
            Globales.BD.dtt = Globales.BD.generar_datatable(txtSQL, CommandType.Text, new List<Clases.Parameters>());
            cmbSOPC1.DataSource = Globales.BD.dtt;
            cmbSOPC1.ValueMember = "CODIGO";
            cmbSOPC1.DisplayMember = "NOMBRE";
            cmbSOPC1.SelectedIndex = -1;

            txtSQL = "SELECT * FROM empleados WHERE codigoCargo=21 AND Estado=1";
            Globales.BD.dtt = Globales.BD.generar_datatable(txtSQL, CommandType.Text, new List<Clases.Parameters>());
            cmbSOPC2.DataSource = Globales.BD.dtt;
            cmbSOPC2.ValueMember = "CODIGO";
            cmbSOPC2.DisplayMember = "NOMBRE";
            cmbSOPC2.SelectedIndex = -1;

            #endregion
            #region Cobrador

            txtSQL = "SELECT * FROM Cobradores";
            Globales.BD.dtt = Globales.BD.generar_datatable(txtSQL, CommandType.Text, new List<Clases.Parameters>());
            cmbCobr1.DataSource = Globales.BD.dtt;
            cmbCobr1.ValueMember = "Codigo";
            cmbCobr1.DisplayMember = "Nombre";
            cmbCobr1.SelectedIndex = -1;

            #endregion

            evt = false;

        }


        #endregion

        #region Eventos

        private void cmbGteVtas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!evt)
            {
                if (cmbGteVtas.SelectedIndex != -1)
                    txtCodGteVtas.Text = cmbGteVtas.SelectedValue.ToString();
            }
        }

        private void cmbGteMdo_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!evt)
            {
                if (cmbGteMdo.SelectedIndex != -1)
                    txtCodGteMdo.Text = cmbGteMdo.SelectedValue.ToString();
            }
        }

        private void cmbLiner1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!evt)
            {
                if (cmbLiner1.SelectedIndex != -1)
                    txtCodLiner1.Text = cmbLiner1.SelectedValue.ToString();
            }
        }

        private void cmbLiner2_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!evt)
            {
                if (cmbLiner2.SelectedIndex != -1)
                    txtCodLiner2.Text = cmbLiner2.SelectedValue.ToString();
            }
        }

        private void cmbLiner3_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!evt)
            {
                if (cmbLiner3.SelectedIndex != -1)
                    txtCodLiner3.Text = cmbLiner3.SelectedValue.ToString();
            }
        }

        private void cmbCloser1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!evt)
            {
                if (cmbCloser1.SelectedIndex != -1)
                    txtCodCloser1.Text = cmbCloser1.SelectedValue.ToString();
            }
        }

        private void cmbCloser2_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!evt)
            {
                if (cmbCloser2.SelectedIndex != -1)
                    txtCodCloser2.Text = cmbCloser2.SelectedValue.ToString();
            }
        }

        private void cmbCloser3_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!evt)
            {
                if (cmbCloser3.SelectedIndex != -1)
                    txtCodCloser3.Text = cmbCloser3.SelectedValue.ToString();
            }
        }

        private void cmbProm1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!evt)
            {
                if (cmbProm1.SelectedIndex != -1)
                    txtCodProm1.Text = cmbProm1.SelectedValue.ToString();
            }
        }

        private void cmbSOPC1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!evt)
            {
                if (cmbSOPC1.SelectedIndex != -1)
                    txtCodSOPC1.Text = cmbSOPC1.SelectedValue.ToString();
            }
        }

        private void cmbCobr1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!evt)
            {
                if (cmbCobr1.SelectedIndex != -1)
                    txtCodCobr1.Text = cmbCobr1.SelectedValue.ToString();
            }
        }

        private void cmbProm2_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!evt)
            {
                if (cmbProm2.SelectedIndex != -1)
                    txtCodProm2.Text = cmbProm2.SelectedValue.ToString();
            }
        }

        private void cmbSOPC2_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!evt)
            {
                if (cmbSOPC2.SelectedIndex != -1)
                    txtCodSOPC2.Text = cmbSOPC2.SelectedValue.ToString();
            }
        }

        #endregion

        #endregion

        #region CANCELAR (CIERRE DEL FORM)
        private void btnCancelarContrato_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region EVENTO CLICK GUARDAR

        private void btnGuardarContrato_Click(object sender, EventArgs e)
        {
            

            #region Pestaña DATOS PERSONALES (Validaciones y confirmación de campos vacíos)
            if (cmbTContrato.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un tipo de Contrato o Reserva", "Pestaña DATOS PRINCIPALES", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (nudPrimAUso.Value % 2 == 0 && codTCR == "3")
            {
                MessageBox.Show("El contrato que esta guardando/actualizando es de tipo CN y el primer año de uso es par", "Pestaña DATOS PRINCIPALES", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (nudPrimAUso.Value % 2 != 0 && codTCR == "2")
            {
                MessageBox.Show("El contrato que esta guardando/actualizando es de tipo CP y el primer año de uso es impar", "Pestaña DATOS PRINCIPALES", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbSTContrato.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar el Subtipo de Contrato", "Pestaña DATOS PRINCIPALES", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbPrograma.SelectedIndex == -1)
            {
                MessageBox.Show("Debe Seleccionar el Programa", "Pestaña DATOS PRINCIPALES", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtPuntos.Text == "")
            {
                MessageBox.Show("Debe Introducir la cantidad de Puntos", "Pestaña DATOS PRINCIPALES", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTCalendario.Text))
            {
                var result = MessageBox.Show("No ha seleccionado el tipo de calendario para el contrato. ¿Desea continuar de todas formas?", "Pestaña DATOS PERSONALES", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                    return;
            }

            double nr = Globales.txt_a_double(txtPorcIPactada.Text);

            if (nr==-1)
            {
                MessageBox.Show("Porcentaje de Inicial Pactada no numérico", "Pestaña DATOS PRINCIPALES", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (nr < 30)
            {
                MessageBox.Show("El Porcentaje de inicial Pactada debe ser mínimo de 30%", "Pestaña DATOS PRINCIPALES", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txt_inicialhoy > 0)
            {
                MessageBox.Show("Debe completar las formas de pago para la inicial hoy", "Pestaña DATOS PRINCIPALES", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            nr = Globales.txt_a_double(txtPorcIPactada.Text);

            if (nr == -1)
            {
                MessageBox.Show("Porcentaje de Inicial Pactada no numérico", "Pestaña DATOS PRINCIPALES", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (nr < 30)
            {
                MessageBox.Show("El Porcentaje de inicial Pactada debe ser mínimo de 30%", "Pestaña DATOS PRINCIPALES", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion

            #region Pestaña CO-PROPIETARIO (Validaciones y confirmación de campos vacíos)
            if (dtgrCopr.Rows.Count == 0)
            {
                var result = MessageBox.Show("No ha agregado Co-Propietario. ¿Desea continuar?", "Pestaña CO-PROPIETARIO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                    return;
            }
            #endregion

            #region Pestaña COMPLEMENTO (Validaciones y confirmación de campos vacíos)

            if (txt_compl > 0)
            {
                MessageBox.Show("Debe Completar las formas de pago para la inicial complementaria", "Pestaña COMPLEMENTO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            #endregion

            #region Pestaña GASTOS Y CARGOS (Validaciones y confirmación de campos vacíos)

            nr = Globales.txt_a_double(txtMontoGA.Text);
            if (cmbInstrumentoGA.SelectedIndex == -1 && nr > 0)
            {
                MessageBox.Show("Debe elegir un Instrumento de Pago en Gastos Administrativos", "Pestaña GASTOS Y CARGOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Convert.ToInt32(cmbInstrumentoGA.SelectedValue) > 0 && cmbBancoGA.SelectedIndex == -1)
            {
                MessageBox.Show("Debe elegir un Banco en Gastos Administrativos", "Pestaña GASTOS Y CARGOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbInstrumentoGA.SelectedIndex == 0 && cmbBancoGA.SelectedIndex == -1 && nr > 0)
            {
                cmbBancoGA.SelectedIndex = 0;
            }

            if (nr == -1)
            {
                MessageBox.Show("Monto de Gastos Administrativos no numérico", "Pestaña GASTOS Y CARGOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (cmbInstrumentoGA.Text=="GIRO" && dtpVencGA.Value==DateTime.Today)
            {
                var result = MessageBox.Show("La Fecha tope de los Gastos Administrativos es igual a la actual. ¿Continuar de todas formas?", "Pestaña GASTOS Y CARGOS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                    return;
            }




            if (txtNTarjCA.Text != "" && txtCodSegCA.Text != "" && cmbBancoCA.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un banco en Cargos Automáticos", "Pestaña GASTOS Y CARGOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtNTarjCA.Text != "" && txtCodSegCA.Text == "" && !rbAhorros.Checked && !rbCorriente.Checked)
            {
                MessageBox.Show("Debe introducir el código de seguridad de la tarjeta de credito en Cargos Automáticos", "Pestaña GASTOS Y CARGOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (string.IsNullOrWhiteSpace(txtNTarjCA.Text) && string.IsNullOrWhiteSpace(txtCodSegCA.Text) && cmbBancoCA.SelectedIndex != -1)
            {
                var result = MessageBox.Show("Se ha seleccionado un banco en el área de domiciliación. ¿Desea continuar? no se guardará ninguna domiciliación?", "Pestaña GASTOS Y CARGOS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                    return;
            }

            if (string.IsNullOrWhiteSpace(txtNTarjCA.Text) && !string.IsNullOrWhiteSpace(txtCodSegCA.Text))
            {
                var result = MessageBox.Show("Se ha introducido un código de seguridad en el área de domiciliación. ¿Desea continuar? no se guardará ninguna domiciliación?", "Pestaña GASTOS Y CARGOS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                    return;
            }

            #endregion

            #region Pestaña FINANCIAMIENTOS (Validaciones y confirmación de campos vacíos)

            if (cmbNCuotasFinanc.SelectedIndex == -1)
            {
                var result = MessageBox.Show("Debe Seleccionar el Nro de cuotas para el financiamiento. ¿Continuar?", "Pestaña FINANCIAMIENTOS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                    return;
            }

            if (cmbNCuotasFinanc.Text == "36" && dtpFContrato.Value >= Globales.str_a_fecha("24/12/2013") && chkVSContrato.Checked)
            {
                MessageBox.Show("No puede seleccionar cuotas mayores a 30 meses en el financiamiento", "Pestaña FINANCIAMIENTOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            nr = Globales.txt_a_double(txtPorcFinanc.Text);
            double nr2 = Globales.txt_a_double(txtPorcFE.Text);
            nr = nr == -1 ? 0 : nr;
            nr2 = nr2 == -1 ? 0 : nr2;
            if (nr + nr2 != 100)
            {
                MessageBox.Show("Existe un problema en los porcentajes de los financiamientos (normal y especial). Verifique por favor sus datos", "Pestaña FINANCIAMIENTOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (nr2 > 0 && nr2 < 100 && cmbTFinFE.SelectedIndex == -1)
            {
                MessageBox.Show("Debe Seleccionar el tipo de Financiamiento Especial", "Pestaña FINANCIAMIENTOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            if (dias_entre_fechas(dtpFContrato.Value, dtpADEFE.Value) > 90 && codTCR.Contains("R"))
            {
                MessageBox.Show("La fecha del financiamiento es mayor a la del contrato por más de 90 días", "Pestaña FINANCIAMIENTOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (cmbTAnualFinanc.Text == "")
            {
                MessageBox.Show("El porcentaje de la tasa anual para el financiamiento debe ser 0 Ó 22", "Pestaña FINANCIAMIENTOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            #endregion

            #region Pestaña EMPLEADOS (Validaciones y confirmación de campos vacíos)

            if (cmbGteVtas.SelectedIndex == -1)
            {
                MessageBox.Show("Debe Seleccionar al Gerente de Ventas", "Pestaña EMPLEADOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cmbGteMdo.SelectedIndex == -1)
            {
                MessageBox.Show("Debe Seleccionar al Gerente de Mercadeo", "Pestaña EMPLEADOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cmbLiner1.SelectedIndex == -1 && cmbLiner2.SelectedIndex == -1 && cmbLiner3.SelectedIndex == -1)
            {
                MessageBox.Show("Debe Seleccionar por lo menos un Liner", "Pestaña EMPLEADOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cmbCloser1.SelectedIndex == -1 && cmbCloser2.SelectedIndex == -1 && cmbCloser3.SelectedIndex == -1)
            {
                MessageBox.Show("Debe Seleccionar por lo menos un Closer", "Pestaña EMPLEADOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cmbCobr1.SelectedIndex==-1)
            {
                var result = MessageBox.Show("No ha seleccionado un Cobrador. ¿Desea continuar?", "Pestaña EMPLEADOS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                    return;
            }

            #endregion

            #region Pestaña OBSERVACIONES (Validaciones y confirmación de campos vacíos)

            if (string.IsNullOrWhiteSpace(txtObsCtto.Text))
            {
                var result = MessageBox.Show("El campo observaciones de contrato esta vacío. ¿Desea continuar de todas formas?", "Pestaña OBSERVACIONES", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                    return;
            }

            #endregion


            if (accion == "AGREGAR")
            {
                var result = MessageBox.Show("¿Seguro que desea guardar este contrato?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                    return;
                ejecutarguardarcontrato();

            }
            else
            {

            }




        }

        #endregion

        

        

        


        

        

        

        

        

        

        

        

        

        

        

        

        

        

        

        



        


        

        

        

        

        

        

        

        

        

        

        

        

        
        

        

    }
}
