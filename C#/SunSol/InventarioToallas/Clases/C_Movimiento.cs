//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Clases
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using Clases;
    using System.ComponentModel;
    public partial class C_Movimiento
    {

        conexion con;
        
        public int idMovimiento { get; set; }
        public Nullable<int> idSuministro { get; set; }
        public Nullable<int> idHabitacion { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public Nullable<int> cantidadEstimada { get; set; }
        public Nullable<int> cantidadReal { get; set; }

        public Nullable<int> suciaEstimada { get; set; }
        public Nullable<int> suciaReal { get; set; }
        public string tipo { get; set; }
        public Nullable<int> idUsuario { get; set; }
        public Nullable<System.DateTime> fechaModificacion { get; set; }
        public Nullable<int> idCamarera { get; set; }
        public Nullable<int> idsupervisor { get; set; }

        public string hora { get; set; }

        public string nomsum { get; set; }

        public string observacion { get; set; }

        public string nhab { get; set; }

        public string mod_hab { get; set; }

        public int piso_hab { get; set; }

        public C_Movimiento BuscarMovCamFecha()
        {
            
            if (con == null)
                con = new conexion();
            con.conectar();
            C_Movimiento nodo = null;
            SqlCommand cmd = new SqlCommand("_sp_BuscarMovCamFecha", con.cnxn);
            cmd.Parameters.AddWithValue("@idc", idCamarera);
            cmd.Parameters.AddWithValue("@fecha", fecha);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    nodo = new C_Movimiento();
                    
                    try
                    {
                        nodo.idMovimiento = dr.GetInt32(0);

                    }
                    catch
                    {
                        con.desconectar();
                        return null;
                    }
                }
            }
            con.desconectar();
            return nodo;
        }

        public List<C_Movimiento> lista_estimados_cambio_cam(int idc, DateTime fch)
        {
            List<C_Movimiento> list = new List<C_Movimiento>();
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_sp_estimadosCambio", con.cnxn);
            cmd.Parameters.AddWithValue("@fecha", fch);
            cmd.Parameters.AddWithValue("@camarera", idc);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    C_Movimiento nodo = new C_Movimiento();
                    nodo.idCamarera = dr.GetInt32(0);
                    nodo.idHabitacion = dr.GetInt32(1);
                    nodo.nhab = dr.GetString(2).Trim(new char[] { ' ' });
                    nodo.fecha = dr.GetDateTime(3);
                    nodo.idSuministro = dr.GetInt32(4);
                    nodo.nomsum = dr.GetString(5).Trim(new char[] { ' ' });
                    nodo.suciaEstimada = dr.GetInt32(6);
                    nodo.suciaReal = dr.GetInt32(7);
                    nodo.cantidadEstimada = dr.GetInt32(8);
                    nodo.cantidadReal = dr.GetInt32(9);

                    nodo.idsupervisor = dr.GetInt32(10);
                    list.Add(nodo);
                }
            }
            con.desconectar();
            return list;
        }

        public List<C_Movimiento> lista_estimados_rep_cam(int idc, DateTime fch)
        {
            List<C_Movimiento> list = new List<C_Movimiento>();
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_sp_estimadosReposicion", con.cnxn);
            cmd.Parameters.AddWithValue("@fecha", fch);
            cmd.Parameters.AddWithValue("@camarera", idc);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    C_Movimiento nodo = new C_Movimiento();
                    nodo.idCamarera = dr.GetInt32(0);
                    nodo.idHabitacion = dr.GetInt32(1);
                    nodo.nhab = dr.GetString(2).Trim(new char[] { ' ' });
                    nodo.fecha = dr.GetDateTime(3);
                    nodo.idSuministro = dr.GetInt32(4);
                    nodo.nomsum = dr.GetString(5).Trim(new char[] { ' ' });
                    nodo.cantidadEstimada = dr.GetInt32(6);
                    nodo.cantidadReal = dr.GetInt32(7);

                    nodo.idsupervisor = dr.GetInt32(8);
                    list.Add(nodo);
                }
            }
            con.desconectar();
            return list;
        }

        
        public int Guardar()
        {
            try
            {
                if (con == null)
                    con = new conexion();
                con.conectar();
                SqlCommand cmd = new SqlCommand("_sp_nuevoMovimiento", con.cnxn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idsum", idSuministro);
                cmd.Parameters.AddWithValue("@idh", idHabitacion);
                cmd.Parameters.AddWithValue("@fecha", fecha);

                cmd.Parameters.AddWithValue("@sucest", suciaEstimada);
                cmd.Parameters.AddWithValue("@sucreal", suciaReal);


                cmd.Parameters.AddWithValue("@cantest", cantidadEstimada);
                cmd.Parameters.AddWithValue("@cantreal", cantidadReal);
                cmd.Parameters.AddWithValue("@tipo", tipo);
                cmd.Parameters.AddWithValue("@idus", idUsuario);
                cmd.Parameters.AddWithValue("@fechamod", fechaModificacion);
                cmd.Parameters.AddWithValue("@idcam", idCamarera);
                cmd.Parameters.AddWithValue("@idsup", idsupervisor);
                cmd.Parameters.AddWithValue("@hora", hora);
                cmd.Parameters.AddWithValue("@nhab", nhab);
                cmd.Parameters.AddWithValue("@modhab", mod_hab);
                cmd.Parameters.AddWithValue("@pisohab", piso_hab);
                cmd.ExecuteNonQuery();
                con.desconectar();
                return 1;

            }
            catch
            {
                con.desconectar();
                return 0;

            }


        }

        public int Editar()
        {
            try
            {
                if (con == null)
                    con = new conexion();
                con.conectar();
                SqlCommand cmd = new SqlCommand("_sp_editarMovimiento", con.cnxn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idsum", idSuministro);
                cmd.Parameters.AddWithValue("@idh", idHabitacion);
                cmd.Parameters.AddWithValue("@fecha", fecha);

                cmd.Parameters.AddWithValue("@sucest", suciaEstimada);
                cmd.Parameters.AddWithValue("@sucreal", suciaReal);


                cmd.Parameters.AddWithValue("@cantest", cantidadEstimada);
                cmd.Parameters.AddWithValue("@cantreal", cantidadReal);
                cmd.Parameters.AddWithValue("@tipo", tipo);
                cmd.Parameters.AddWithValue("@idus", idUsuario);
                cmd.Parameters.AddWithValue("@fechamod", fechaModificacion);
                cmd.Parameters.AddWithValue("@idcam", idCamarera);
                cmd.Parameters.AddWithValue("@idsup", idsupervisor);
                cmd.Parameters.AddWithValue("@hora", hora);
                cmd.Parameters.AddWithValue("@modhab", mod_hab);
                cmd.Parameters.AddWithValue("@pisohab", piso_hab);
                cmd.ExecuteNonQuery();
                con.desconectar();
                return 1;

            }
            catch
            {
                con.desconectar();
                return 0;

            }


        }

        public int EditarMovPerdida()
        {
            try
            {
                if (con == null)
                    con = new conexion();
                con.conectar();
                SqlCommand cmd = new SqlCommand("_sp_editarMovimientoPerdida", con.cnxn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idsum", idSuministro);
                cmd.Parameters.AddWithValue("@idh", idHabitacion);
                cmd.Parameters.AddWithValue("@fecha", fecha);
                cmd.Parameters.AddWithValue("@idcam", idCamarera);
                cmd.Parameters.AddWithValue("@obs", observacion.ToUpper());
                cmd.ExecuteNonQuery();
                con.desconectar();
                return 1;

            }
            catch
            {
                con.desconectar();
                return 0;

            }


        }

        public int EditarMovSup()
        {
            try
            {
                if (con == null)
                    con = new conexion();
                con.conectar();
                SqlCommand cmd = new SqlCommand("_sp_editarMovimientoSupervisor", con.cnxn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idsup", idsupervisor);
                cmd.Parameters.AddWithValue("@fecha", fecha);
                cmd.Parameters.AddWithValue("@idcam", idCamarera);
                cmd.ExecuteNonQuery();
                con.desconectar();
                return 1;

            }
            catch
            {
                con.desconectar();
                return 0;

            }


        }


    }
}