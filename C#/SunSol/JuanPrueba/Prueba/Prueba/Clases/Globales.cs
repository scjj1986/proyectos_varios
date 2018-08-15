using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Net;
//using System.DateTime;
using System.Windows.Forms;

namespace Contratos
{
    public static class Globales
    {
        
        public static Usuario usr = new Usuario();
        public static string nombrehost;
        public static Empresa emp= new Empresa();
        public static conexionBD BD = new conexionBD();
        public static Contratos.Clases.Cliente cli = new Contratos.Clases.Cliente();

        public static string lServidor;
        public static string Asunto;
        public static string Cc;
        public static string NombrePuntos;
        public static string Mantenimiento;
        //public static string lForm1;
       // public static string lCodigoEmpresa;
        public static string gCodigosBanco;
        public static string EsConsultarSeniat;
        public static string EsConProxy;

        public static bool gEsMantenimiento;

        public static bool gPermitirForm1;

        public static bool GForzarFinalizar;
        public static bool gEsReporte;
        public static bool gEsReservaciones;
        public static int gDiasEvaluacion;


        public static string gRutaFotos;
        public static int gCorrelativoTodosLosAnos;
        public static int gCorrelativoPares;
        public static int gCorrelativoNones;
        public static int gCorrelativoTodosLosAnosR;
        public static int gCorrelativoParesR;
        public static int gCorrelativoNonesR;
        public static int gCorrelativoFusion;
        public static int gCorrelativo5Anos;
        public static int gCorrelativo5Anos2;
        public static int gCorrelativoReservasCF;
        public static int gCorrelativoReservasPL;
        public static int gCorrelativoPlatinum;
        public static int gCorrelativoR4;
        public static int gCorrelativoR7;
        public static int gCorrelativoR8;
        public static int gCorrelativoR9;
        public static int gCorrelativoC4;
        public static int gCorrelativoC7;
        public static int gCorrelativoC8;
        public static int gCorrelativoC9;
        public static int gCantidadAnosFusion;
        public static int gCantidadAnosTodosLosAnos;
        public static int gCantidadAnosPares;
        public static int gCantidadAnosNones;
        public static Double gGastosLegales;
        public static Double gTasaAnual;
        public static string gCodigoOficina;
        public static Double gCuotaMantenimiento;

        public static Double gValorPuntosAlta=0;
        public static Double gValorPuntosBaja=0;

        public static Double gCambioDolar=0;

        public static string gNombreEmpresa;

        public static int gTablaPuntos;

        public static string gCodigoGerenteSala;

        public static string gCodigoGerenteCalle;
        public static string gCodigoAsistenteCalle;

        public static int valor_perfil(string nombrecampo)
        {
            foreach (DataRow pRow in BD.dsGlobal.Tables["Perfiles"].Rows)
                return Convert.ToInt32(pRow[nombrecampo]);

            return 0;
        }




        public static void reset() {

            usr = new Usuario();
        
        }


        public static bool fVerificarAcceso(int valor)
        {
            if (valor == 1) return true;
            return false; 
        }

        public static string yyyy_mm_dd_hhmmss_actual()
        {
            string fecha = DateTime.Now.ToString("s");
            return fecha.Replace('T', ' ');

        }

        public static string yyyy_mm_dd_hhmmss_otra(DateTime fch,string hora)
        {
            string fecha = fch.ToString("s");
            return fecha.Substring(0,10)+hora;

        }

        public static string yyyy_mm_dd(DateTime fch)
        {
            string fecha = fch.ToString("s");
            return fecha.Substring(0, 10);


        }

        public static string yyyymmdd(DateTime fch)
        {
            string fecha = fch.ToString("s");
            fecha = fecha.Substring(0, 10);
            return fecha.Replace("-", "");

        }

        public static string yyyy_mm_dd_hhmmss_singuion(DateTime fch, string hora)
        {
            string fecha = fch.ToString("s");

            fecha = fecha.Substring(0, 10) + hora;
            return fecha.Replace("-", "");

        }

        public static DateTime str_a_fecha(string dd_mm_aaaa)
        {
            String[] sbs = dd_mm_aaaa.Split('/');
            return Convert.ToDateTime(sbs[2] + "-" + sbs[1] + "-" + sbs[0]);
        }

        public static double txt_a_double(string txt)
        {

            double nr;
            if (!Double.TryParse(txt.Replace(".", ","), out nr))
                return -1;
            else
                return nr;
        }

        #region inserción y modificación de contratos

        #endregion

        public static void cargartablasdsglobal()
        {
            
            string txtSQL = "Select * from Clientes Where Estado ='activo' Order by Nombres";

            BD.llenardsglobal(txtSQL, "Clientes");//Carga de clientes al dataset

            txtSQL = "Select * from Profesiones order by descripcion";

            BD.llenardsglobal(txtSQL, "Profesiones");//Carga de profesiones al dataset

            txtSQL = "Select * from Oficinas";

            BD.llenardsglobal(txtSQL, "Oficinas");//Carga de oficinas al dataset

            txtSQL = "Select * from FormasDePago Order By Descripcion";

            BD.llenardsglobal(txtSQL, "FormasDePago");//Carga de formas de pago al dataset

            txtSQL = "Select * from Bancos";

            BD.llenardsglobal(txtSQL, "Bancos");//Carga de bancos al dataset

            txtSQL = "Select * from Concepto";

            BD.llenardsglobal(txtSQL, "Concepto");//Carga de conceptos al dataset

        }
        /*
        public static void cargartabladscontrato(string txtSQL, string tabla)
        {

            BD.llenardscontratos(txtSQL, tabla);//Carga de clientes al dataset
        }*/

        public static void cargar_parametros()
        {
            int counter = 1;
            string line;

            string lServidor;

            string lmantenimiento="";

            string lCodigoEmpresa;
            string lForm1="";
            //string lServidorProfit;
            //bool lPermitirForm1 = false;

            System.IO.StreamReader file = new System.IO.StreamReader("servidor.txt");
            while ((line = file.ReadLine()) != null && counter <=10)
            {
                switch (counter)
                {
                    case 1:
                        lServidor = line;
                        break;
                    case 2:
                        Asunto = line;
                        break;
                    case 3:
                        Cc = line;
                        break;
                    case 4:
                        NombrePuntos = line;
                        break;
                    case 5:
                        lmantenimiento = line;
                        break;
                    case 6:
                        lForm1 = line;
                        break;
                    case 7:
                        lCodigoEmpresa = line;
                        break;
                    case 8:
                        gCodigosBanco = line;
                        break;
                    case 9:
                        EsConsultarSeniat = line;
                        break;
                    case 10:
                        EsConProxy = line;
                        break;
                }

                counter++;
            }

            gEsMantenimiento = (lmantenimiento == "Mant") ? true : false;

            gPermitirForm1 = (lForm1 == "1") ? true : false;

            GForzarFinalizar = false;
            gEsReporte = false;
            gEsReservaciones = false;
            gDiasEvaluacion = 45;

            string txtSQL = "Select * from Parametros where codigoempresa='" + emp.codigo + "'";
            BD.dtt = BD.generar_datatable(txtSQL, CommandType.Text, new List<Clases.Parameters>());
            foreach (DataRow pRow in BD.dtt.Rows)
            {
                 gRutaFotos = Convert.ToString(pRow["rutafotos"]);
                 gCorrelativoTodosLosAnos = Convert.ToInt32(pRow["ContadorTodosLosAnios"]);
                 gCorrelativoPares =  Convert.ToInt32(pRow["ContadorPares"]);
                 gCorrelativoNones = Convert.ToInt32(pRow["ContadorNones"]);
                 gCorrelativoTodosLosAnosR = Convert.ToInt32(pRow["ContadorReservasTA"]);
                 gCorrelativoParesR = Convert.ToInt32(pRow["ContadorReservasPares"]);
                 gCorrelativoNonesR = Convert.ToInt32(pRow["ContadorReservasNones"]);
                 gCorrelativoFusion = Convert.ToInt32(pRow["contadorfusion"]);
                 gCorrelativo5Anos = Convert.ToInt32(pRow["Contador5Años"]);
                 gCorrelativo5Anos2 = Convert.ToInt32(pRow["Contador5Años2"]);
                 gCorrelativoReservasCF = Convert.ToInt32(pRow["ContadorReservasCF"]);
                 gCorrelativoReservasPL = Convert.ToInt32(pRow["ContadorReservasPL"]);
                 gCorrelativoPlatinum = Convert.ToInt32(pRow["ContadorPlatinum"]);
     
                 gCorrelativoR4 = Convert.ToInt32(pRow["ContadorR4"]);//
                 gCorrelativoR7 = Convert.ToInt32(pRow["ContadorR7"]);//
                 gCorrelativoR8 = Convert.ToInt32(pRow["ContadorR8"]);
                 gCorrelativoR9 = Convert.ToInt32(pRow["ContadorR9"]);


                 gCorrelativoC4 = Convert.ToInt32(pRow["ContadorC4"]);//
                 gCorrelativoC7 = Convert.ToInt32(pRow["ContadorC7"]);
                 gCorrelativoC8 = Convert.ToInt32(pRow["ContadorC8"]);
                 gCorrelativoC9 = Convert.ToInt32(pRow["ContadorC9"]);
     
                 gCantidadAnosFusion = Convert.ToInt32(pRow["aniosfusion"]);
                 gCantidadAnosTodosLosAnos = Convert.ToInt32(pRow["AniosTodosLosAnios"]);
                 gCantidadAnosPares = Convert.ToInt32(pRow["AniosPares"]);
                 gCantidadAnosNones = Convert.ToInt32(pRow["AniosNones"]);
                 gGastosLegales = Convert.ToDouble(pRow["GastosLegales"]);
                 gTasaAnual = Convert.ToDouble(pRow["TasaAnual"]);
                 gCodigoOficina = Convert.ToString(pRow["CodigoEmpresa"]);
                 gCuotaMantenimiento = Convert.ToDouble(pRow["CuotaMantenimiento"]);


            }


            txtSQL = "Select * from ValorPuntos where anio='" + Convert.ToString(DateTime.Now.Year) +"'";

            BD.dtt = BD.generar_datatable(txtSQL, CommandType.Text, new List<Clases.Parameters>());

            foreach (DataRow row in BD.dtt.Rows)
            {
                gValorPuntosAlta = Convert.ToDouble(row["Alta"]);
                gValorPuntosBaja = Convert.ToDouble(row["Baja"]);
            }

            txtSQL = "Select * from cambioMoneda where AnioCambio ='" + Convert.ToString(DateTime.Now.Year) +"'";
            BD.dtt = BD.generar_datatable(txtSQL, CommandType.Text, new List<Clases.Parameters>());

            foreach (DataRow row in BD.dtt.Rows)
                gCambioDolar = Convert.ToDouble(row["CambioDolar"]);

            txtSQL = "Select * from Oficinas where Codigo ='" + gCodigoOficina +"'";
            BD.dtt = BD.generar_datatable(txtSQL, CommandType.Text, new List<Clases.Parameters>());


            foreach (DataRow row in BD.dtt.Rows)
                gNombreEmpresa = Convert.ToString(row["Descripcion"]);

            txtSQL = "Select * From TablaPuntos where FechaDesde <='" + DateTime.Now.ToString("yyyyMMdd") + "' And Fechahasta >='" + DateTime.Now.ToString("yyyyMMdd") + "'";

            if (BD.nregistros(txtSQL)>0){
                BD.dtt = BD.generar_datatable(txtSQL, CommandType.Text, new List<Clases.Parameters>());

                foreach (DataRow row in BD.dtt.Rows)
                    gTablaPuntos = Convert.ToInt32(row["codigo"]);

            }
            else {

                gTablaPuntos = 4;

            }

            if (fConsultarFechaDisponible(DateTime.Now.ToString("s"),20)){

                MessageBox.Show("No se ha creado el cronograma del Gerente de Sala para la fecha actual. Debe crearlo en el menu de mantenimiento, opcion Cronograma Gerente de Sala.");
            }

            if (fConsultarFechaDisponible(DateTime.Now.ToString("s"), 9))
            {

                MessageBox.Show("No se ha creado el cronograma del gerente de Calle para la fecha actual. Debe crearlo en el menu de mantenimiento, opcion Cronograma Gerente de Sala.");
            }

            if (fConsultarFechaDisponible(DateTime.Now.ToString("s"), 18))
            {

                MessageBox.Show("No se ha creado el cronograma del Asistente de Gerente de Calle para la fecha actual. Debe crearlo en el menu de mantenimiento, opcion Cronograma Gerente de Sala.");
            }
            

        }


        public static bool fConsultarFechaDisponible (string fechadesde, int cargo){


            BD.conectar();
            bool respuesta = false;
            fechadesde = fechadesde.Replace('T', ' ');
            SqlCommand cmd = new SqlCommand("SP_ConsultaGerenteSala", BD.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FechaInicio", SqlDbType.DateTime2);
            cmd.Parameters.Add("@CodigoSala", SqlDbType.Char, 10);
            cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
            cmd.Parameters["@FechaInicio"].Value = fechadesde;
            cmd.Parameters["@CodigoSala"].Value = gCodigoOficina;
            cmd.Parameters["@CodigoCargo"].Value = cargo;
            SqlDataReader lector = cmd.ExecuteReader();

            if (lector == null || !lector.HasRows)
            {
                
                gCodigoGerenteSala = "";
                respuesta = true;
            }
            else {
            
                while (lector.Read()){

                    switch (cargo){
                        case 20:
                            gCodigoGerenteSala = Convert.ToString(lector["codigo"]);
                            break;
                        case 9:
                            gCodigoGerenteCalle = Convert.ToString(lector["codigo"]);
                            break;
                        case 18:
                            gCodigoAsistenteCalle = Convert.ToString(lector["codigo"]);
                            break;

                    }

                    respuesta = false;

                }
            
            
            }
            BD.cerrar();

            return respuesta;
        
        }

    }
}
