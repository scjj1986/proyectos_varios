using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;

namespace librerias
{
    public class reservacion
    {
        public int  id=0, puntos = 0, diasreserva = 0, hoteles = 0,n_contrato=0,habitaciones=0,puntosacelerado=0;
        public double total = 0, todoincluido = 0,cargos=0,montoAcelerado=0;
        public String cliente,fechaI, fechaF,status,fechaL,calendario,observacion,reservado_por,fechaC,localizador;
        public conexion con;
        static Random random = new Random();
        public string anios_puntos, anios_puntosA;
        public void guardar_reserva()
        {
            if (con == null)
                con = new conexion();
            //con.conectar();
            SqlCommand cmd = new SqlCommand("_SP_guardaReserva", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cliente", cliente);
            cmd.Parameters.AddWithValue("@inicio", fechaI);
            cmd.Parameters.AddWithValue("@fin", fechaF);
            cmd.Parameters.AddWithValue("@puntos", puntos);
            cmd.Parameters.AddWithValue("@contrato", n_contrato);
            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@noches", diasreserva);
            cmd.Parameters.AddWithValue("@montoTI",todoincluido);
            cmd.Parameters.AddWithValue("@fechaL", fechaL);
            cmd.Parameters.AddWithValue("@calendario", calendario);
            cmd.Parameters.AddWithValue("@observacion", observacion);
            cmd.Parameters.AddWithValue("@puntosA",puntosacelerado );
            cmd.Parameters.AddWithValue("@montoPA", montoAcelerado);
            cmd.Parameters.AddWithValue("@reservado_por",reservado_por );
            cmd.Parameters.AddWithValue("@cargos",cargos );
            cmd.Parameters.AddWithValue("@fechaC", fechaC);
            cmd.Parameters.AddWithValue("@anPun", anios_puntos);
            cmd.Parameters.AddWithValue("@anPunA", anios_puntosA);
            localizador = crear_localizador(6);
            while (existe()==1)
                localizador = crear_localizador(6);
            cmd.Parameters.AddWithValue("@Localizador", localizador);
            cmd.Parameters.AddWithValue("@total", total);
            con.conectar();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                if (dr.Read())
                    id = dr.GetInt32(0);
            }
            con.desconectar();
        }
        public void modificar_reserva(int puntosAnt)
        {
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_SP_modificarReserva", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@reserva", id);
            cmd.Parameters.AddWithValue("@cliente", cliente);
            cmd.Parameters.AddWithValue("@inicio", fechaI);
            cmd.Parameters.AddWithValue("@fin", fechaF);
            cmd.Parameters.AddWithValue("@puntos", puntos);    
            cmd.Parameters.AddWithValue("@noches", diasreserva);
            cmd.Parameters.AddWithValue("@montoTI", todoincluido);                        
            cmd.Parameters.AddWithValue("@observacion", observacion);
            cmd.Parameters.AddWithValue("@puntosA", puntosacelerado);
            cmd.Parameters.AddWithValue("@montoPA", montoAcelerado);
            cmd.Parameters.AddWithValue("@puntosAnt", puntosAnt);
            cmd.Parameters.AddWithValue("@total", total);
            cmd.Parameters.AddWithValue("@anPun", anios_puntos);
            cmd.Parameters.AddWithValue("@anPunA", anios_puntosA);
            cmd.ExecuteNonQuery();
            con.desconectar();
        }
        public void quitar_puntos(int pPuntosNo,int pPuntosCon,int pAnio)
        {
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_SP_quitarPuntos", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cliente",cliente);
            cmd.Parameters.AddWithValue("@NroContrato",n_contrato.ToString());
            cmd.Parameters.AddWithValue("@PuntoNo", pPuntosNo);
            cmd.Parameters.AddWithValue("@PuntoCon", pPuntosCon);
            cmd.Parameters.AddWithValue("@anio", pAnio);
            cmd.ExecuteNonQuery();
            con.desconectar();
        }
        public void hotel_reserva(String photel, String pfechaI,String pfechaF,int pPuntos,double pmontoTI,double pdescuento)
        {
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_SP_hotelReserva", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@reserva", id);
            cmd.Parameters.AddWithValue("@hotel", photel);
            cmd.Parameters.AddWithValue("@fechaI",pfechaI);
            cmd.Parameters.AddWithValue("@FechaF", pfechaF);
            cmd.Parameters.AddWithValue("@puntos", pPuntos);
            cmd.Parameters.AddWithValue("@totalTI", pmontoTI);
            cmd.Parameters.AddWithValue("@descuento", pdescuento);
            cmd.ExecuteNonQuery();
            con.desconectar();
        }
        public void habitacion_reserva(String photel, String phabitacion, int pInfante,int pNinio,int pAdulto,string pfechaI,string pfechaF)
        {
            String[] ini = pfechaI.Split('/');
            String[] f = pfechaF.Split('/');
            String[] anioI = ini[2].Split(' ');
            String[] aniof = f[2].Split(' ');
            String fechaIni = anioI[0] + "/" + ini[1] + "/" + ini[0];
            String fechaFin = aniof[0] + "/" + f[1] + "/" + f[0];
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_SP_habitacionReserva", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@reserva", id);
            cmd.Parameters.AddWithValue("@hotel", photel);
            cmd.Parameters.AddWithValue("@habitacion", phabitacion);
            cmd.Parameters.AddWithValue("@infante", pInfante);
            cmd.Parameters.AddWithValue("@ninio", pNinio);
            cmd.Parameters.AddWithValue("@adulto",pAdulto);
            cmd.Parameters.AddWithValue("@NroContrato", n_contrato);
            cmd.Parameters.AddWithValue("@fechaI", fechaIni);
            cmd.Parameters.AddWithValue("@fechaF", fechaFin);

            cmd.ExecuteNonQuery();
            con.desconectar();
        }

        
        public static string crear_localizador(int digits)
        {
            byte[] buffer = new byte[digits / 2];
            random.NextBytes(buffer);
            string result = String.Concat(buffer.Select(x => x.ToString("X2")).ToArray());
            if (digits % 2 == 0)
                return result;
            return result + random.Next(16).ToString("X");
        }

        public int existe()
        {
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_sp_verificalocalizador", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@localizador", localizador);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                return 1;
            }
            con.desconectar();
            return 0;

        }
        public int existeNdocuemento(string documento)
        {
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_sp_existeNdocumento", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@documento", documento);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                return 1;
            }
            con.desconectar();
            return 0;

        }

        public SqlDataReader buscar_reserva(string pNumero,string pcliente,string pfecha,string pNcontrato)
        {
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_sp_buscarReservaCotizacion", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@numero", pNumero);
            cmd.Parameters.AddWithValue("@cliente", pcliente);
            cmd.Parameters.AddWithValue("@fecha", pfecha);
            cmd.Parameters.AddWithValue("@NroContrato", pNcontrato);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {

                return dr;
            }
            con.desconectar();
            return null;

        }

        public SqlDataReader buscar_reservas_por_ncontrato(string pNcontrato)
        {
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_sp_buscarReservaPorNContrato", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NroContrato", pNcontrato);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {

                return dr;
            }
            con.desconectar();
            return null;

        }




        public SqlDataReader buscar_reservaC(string pNumero, string pcliente, string pfecha, string pNcontrato,string pFechaF)
        {
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_sp_buscarReserva", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@numero", pNumero);
            cmd.Parameters.AddWithValue("@cliente", pcliente);
            cmd.Parameters.AddWithValue("@fecha", pfecha);
            cmd.Parameters.AddWithValue("@NroContrato", pNcontrato);
            cmd.Parameters.AddWithValue("@fechaF", pFechaF);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {

                return dr;
            }
            con.desconectar();
            return null;

        }
        public SqlDataReader buscar_reservaPa(string pNumero, string pcliente, string pfecha, string pNcontrato)
        {
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_sp_buscarReservaPago", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@numero", pNumero);
            cmd.Parameters.AddWithValue("@cliente", pcliente);
            cmd.Parameters.AddWithValue("@fecha", pfecha);
            cmd.Parameters.AddWithValue("@NroContrato", pNcontrato);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {

                return dr;
            }
            con.desconectar();
            return null;

        }
        public SqlDataReader buscar_reservaConfir(string pNumero, string pcliente, string pfecha, string pNcontrato,string pFechaF)
        {
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_sp_buscarReservaConfirmacion", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@numero", pNumero);
            cmd.Parameters.AddWithValue("@cliente", pcliente);
            cmd.Parameters.AddWithValue("@fecha", pfecha);
            cmd.Parameters.AddWithValue("@NroContrato", pNcontrato);
            cmd.Parameters.AddWithValue("@fechaF", pFechaF);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {

                return dr;
            }
            con.desconectar();
            return null;

        }
        public SqlDataReader buscar_reservaConfirLoc(string pNumero, string pcliente, string pfecha, string pNcontrato)
        {
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_sp_buscarReservaConfirmacionLoc", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@numero", pNumero);
            cmd.Parameters.AddWithValue("@cliente", pcliente);
            cmd.Parameters.AddWithValue("@fecha", pfecha);
            cmd.Parameters.AddWithValue("@NroContrato", pNcontrato);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {

                return dr;
            }
            con.desconectar();
            return null;

        }
        public SqlDataReader buscar_cargos()
        {
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_sp_buscarcargos", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {

                return dr;
            }
            con.desconectar();
            return null;

        }
        public SqlDataReader buscarPCReserva(int reserva)
        {
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_sp_buscarPCReserva", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@reserva", reserva);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {

                return dr;
            }
            con.desconectar();
            return null;

        }
        public void agregar_cargo(int preserva, String pcargo,double pmonto,int pAnulado,string pAnio,string pObservacion)
        {
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_SP_agregarCargoReserva", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@reserva", preserva);
            cmd.Parameters.AddWithValue("@cargo", pcargo);
            cmd.Parameters.AddWithValue("@monto", pmonto);
            cmd.Parameters.AddWithValue("@anulado", pAnulado);
            cmd.Parameters.AddWithValue("@anio", pAnio);
            cmd.Parameters.AddWithValue("@observacion", pObservacion);
            cmd.ExecuteNonQuery();
            con.desconectar();
        }
        public void actualizar_cargo(int preserva)
        {
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_SP_actualizarCargosR", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@reserva", preserva);            
            cmd.ExecuteNonQuery();
            con.desconectar();
        }
        public void actPuntosAniosReserva(int preserva)
        {
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_SP_actualizarPuntAniosReserva", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@reserva", preserva);
            cmd.ExecuteNonQuery();
            con.desconectar();
        }
        public void verificafechalimite()
        {
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_SP_verificaFechaReserva", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;           
            cmd.ExecuteNonQuery();
            con.desconectar();
        }

        public void actualizar_pago(int preserva)
        {
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_SP_actualizarPagosR", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@reserva", preserva);
            cmd.ExecuteNonQuery();
            con.desconectar();
        }
        
        public SqlDataReader buscar_bancos()
        {
            if (con == null)
                con = new conexion();
           // con.conectar();
            SqlCommand cmd = new SqlCommand("_sp_buscarbancos", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {

                return dr;
            }
            con.desconectar();
            return null;

        }
        public void agregar_Pago(int preserva, String pcargo, double pmonto,string ptransaccion,string pdocumento, string pbanco,string pfecha,string pobservacion,int pcon,int pAn,string pcuenta,string ptipo,string pPunto,double pPuntoA)
        {
            if (con == null)
                con = new conexion();
            pbanco = "0";
            con.conectar();
            SqlCommand cmd = new SqlCommand("_SP_agregarPagoReserva", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@reserva", preserva);
            cmd.Parameters.AddWithValue("@concepto", pcargo);
            cmd.Parameters.AddWithValue("@monto", pmonto);
            cmd.Parameters.AddWithValue("@transaccion", ptransaccion);
            cmd.Parameters.AddWithValue("@documento", pdocumento);
            cmd.Parameters.AddWithValue("@banco", pbanco);
            cmd.Parameters.AddWithValue("@fecha",pfecha);
            cmd.Parameters.AddWithValue("@observacion",pobservacion);
            cmd.Parameters.AddWithValue("@confirmado", pcon);
            cmd.Parameters.AddWithValue("@anulado", pAn);
            cmd.Parameters.AddWithValue("@cuenta", pcuenta);
            cmd.Parameters.AddWithValue("@tipo", ptipo);
            cmd.Parameters.AddWithValue("@punto", pPunto);
            cmd.Parameters.AddWithValue("@ejecutivo", reservado_por);
            cmd.Parameters.AddWithValue("@PA", pPuntoA);
            cmd.ExecuteNonQuery();
            con.desconectar();
        }

        public SqlDataReader buscar_pagos(int preserva)
        {
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_sp_buscarPagos", con.cnxn);
            cmd.Parameters.AddWithValue("@reserva", preserva);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {

                return dr;
            }
            con.desconectar();
            return null;

        }
        public SqlDataReader reporte_pagos(string concepto,string fecha,string status,int preserva,string pcontrato,string pfechaf,string photel,string pEjecutivo,string us)
        {
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_sp_ReportePagos", con.cnxn);
            cmd.Parameters.AddWithValue("@concepto", concepto);
            cmd.Parameters.AddWithValue("@fecha", fecha);
            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@reserva", preserva);
            cmd.Parameters.AddWithValue("@contrato",pcontrato);
            cmd.Parameters.AddWithValue("@fechafin", pfechaf);
            cmd.Parameters.AddWithValue("@hotel", photel);
            cmd.Parameters.AddWithValue("@ejecutivo", pEjecutivo);
            cmd.Parameters.AddWithValue("@usuario", us);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {

                return dr;
            }
            con.desconectar();
            return null;

        }
        public SqlDataReader buscar_pagosT(int preserva)
        {
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_sp_buscarPagosT", con.cnxn);
            cmd.Parameters.AddWithValue("@reserva", preserva);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {

                return dr;
            }
            con.desconectar();
            return null;

        }
        public SqlDataReader buscar_cargosR(int preserva)
        {

            con.conectar();
            SqlCommand cmd = new SqlCommand("_sp_buscarCargosReserva", con.cnxn);
            cmd.Parameters.AddWithValue("@reserva", preserva);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {

                return dr;
            }
            con.desconectar();
            return null;

        }

        public SqlDataReader reporte_reserva(int reserva, string cliente, string fecha, int contrato,string status,string fechaf)
        {
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_sp_ReporteReserva", con.cnxn);
            cmd.Parameters.AddWithValue("@reserva", reserva);
            cmd.Parameters.AddWithValue("@cliente", cliente);
            cmd.Parameters.AddWithValue("@fecha", fecha);
            cmd.Parameters.AddWithValue("@contrato", contrato);
            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@fechaF", fechaf);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {

                return dr;
            }
            con.desconectar();
            return null;

        }

        public SqlDataReader trasladoPagos()
        {
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_sp_listaReserva", con.cnxn);           
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {

                return dr;
            }
            con.desconectar();
            return null;

        }

        public void saldoTI(int preserva, double pmonto)
        {
            if (con == null)
                con = new conexion();

            con.conectar();
            SqlCommand cmd = new SqlCommand("_SP_saldoTI", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@reserva", preserva);
            cmd.Parameters.AddWithValue("@monto", pmonto);           
            cmd.ExecuteNonQuery();
            con.desconectar();
        }

        public void saldoPA(int preserva, double pmonto)
        {
            if (con == null)
                con = new conexion();

            con.conectar();
            SqlCommand cmd = new SqlCommand("_SP_saldoPA", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@reserva", preserva);
            cmd.Parameters.AddWithValue("@monto", pmonto);
            cmd.ExecuteNonQuery();
            con.desconectar();
        }

       

        public void confirmar(int preserva, double pmonto, string pconcepto,int pref)
        {
            if (con == null)
                con = new conexion();

            con.conectar();
            SqlCommand cmd = new SqlCommand("_SP_confirmarPago", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@reserva", preserva);
            cmd.Parameters.AddWithValue("@monto", pmonto);
            cmd.Parameters.AddWithValue("@concepto", pconcepto);
            cmd.Parameters.AddWithValue("@ref", pref);
            cmd.ExecuteNonQuery();
            con.desconectar();
        }

        public SqlDataReader buscar_reservaReporte(string pNumero, string pcliente, string pfecha, string pNcontrato,string pstatus)
        {
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_sp_buscarReservaReporte", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@numero", pNumero);
            cmd.Parameters.AddWithValue("@cliente", pcliente);
            cmd.Parameters.AddWithValue("@fecha", pfecha);
            cmd.Parameters.AddWithValue("@NroContrato", pNcontrato);
            cmd.Parameters.AddWithValue("@status", pstatus);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {

                return dr;
            }
            con.desconectar();
            return null;

        }

        public void anular_reserva(int preserva,int pPuntos,string pcliente,string pUser)
        {
            if (con == null)
                con = new conexion();

            con.conectar();
            string[] fecha = DateTime.Now.ToShortDateString().Split('/');
            string f = fecha[2] + '/' + fecha[1] + '/' + fecha[0];
            SqlCommand cmd = new SqlCommand("_SP_anularReserva", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@reserva", preserva);
            cmd.Parameters.AddWithValue("@puntos", pPuntos);
            cmd.Parameters.AddWithValue("@cliente", pcliente);
            cmd.Parameters.AddWithValue("@usuario", pUser);
            cmd.Parameters.AddWithValue("@fecha", f); 
            cmd.ExecuteNonQuery();
            con.desconectar();
        }

        public SqlDataReader buscarHabitacion(int preserva)
        {
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_sp_buscarhotelHabitacion", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@reserva", preserva);            
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                return dr;
            }
            con.desconectar();
            return null;

        }
        public SqlDataReader buscarHotel(int preserva)
        {
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_sp_buscarhotelreserva", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@reserva", preserva);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                return dr;
            }
            con.desconectar();
            return null;

        }

        public void guardarlocalizador(int preserva, string plocalizador, int pref,string pObservacion)
        {
            if (con == null)
                con = new conexion();

            con.conectar();
            SqlCommand cmd = new SqlCommand("_sp_guardalocalizador", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@reserva", preserva);        
            cmd.Parameters.AddWithValue("@localizador", plocalizador);
            cmd.Parameters.AddWithValue("@referencia", pref);
            cmd.Parameters.AddWithValue("@Obser", pObservacion);
            cmd.ExecuteNonQuery();
            con.desconectar();
        }

        public void localizadorPago(int preserva, string plocalizador, string photel)
        {
            if (con == null)
                con = new conexion();

            con.conectar();
            SqlCommand cmd = new SqlCommand("_sp_localizadorPago", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@reserva", preserva);
            cmd.Parameters.AddWithValue("@localizador", plocalizador);
            cmd.Parameters.AddWithValue("@hotel", photel);
            cmd.ExecuteNonQuery();
            con.desconectar();
        }
        public void log(string pUsuario,string pContrato,int puntos_ant,int puntos_act,int puntos_mod,string pAnios)
        {
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_SP_log_puntosContrato", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@usuario", pUsuario);
            cmd.Parameters.AddWithValue("@NroContrato", n_contrato.ToString());
            cmd.Parameters.AddWithValue("@PuntoAct", puntos_act);
            cmd.Parameters.AddWithValue("@PuntoAnt", puntos_ant);
            cmd.Parameters.AddWithValue("@PuntosMod", puntos_mod);
            cmd.Parameters.AddWithValue("@anios", pAnios);
            cmd.Parameters.AddWithValue("@fecha", DateTime.Now);
            cmd.ExecuteNonQuery();
            con.desconectar();
        }
        public void puntosConsumidosReserva(int reserva,int pPuntos, int pAnio)
        {
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_SP_PuntosAnioReserva", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@reserva", reserva);
            cmd.Parameters.AddWithValue("@puntos", pPuntos);
            cmd.Parameters.AddWithValue("@anio", pAnio);            
            cmd.ExecuteNonQuery();
            con.desconectar();
        }
        


    }
}
