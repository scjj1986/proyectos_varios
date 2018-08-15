using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Windows;

namespace Clases
{
    public partial class C_Incidencia
    {
        conexion con;

        public int idIncidencia { get; set; }
        public Nullable<int> idSuministro { get; set; }
        public Nullable<int> idHabitacion { get; set; }
        public Nullable<int> idCamarera { get; set; }
        public Nullable<int> cantidad { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public Nullable<int> idUsuario { get; set; }
        public Nullable<System.DateTime> fechaModificacion { get; set; }

        public string observacion { get; set; }

        public string hora { get; set; }

        public string nhab { get; set; }

        public string nomsum { get; set; }

        public int EliminarPorSumHabFecha()
        {
            try
            {
                if (con == null)
                    con = new conexion();
                con.conectar();

                SqlCommand cmd = new SqlCommand("_sp_EliminarIncPorSumHabFecha", con.cnxn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idh", idHabitacion);
                cmd.Parameters.AddWithValue("@ids", idSuministro);
                cmd.Parameters.AddWithValue("@fecha", fecha);
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

        public int EliminarPorCamyFecha()//Eliminar omitidas
        {
            try
            {
                if (con == null)
                    con = new conexion();
                con.conectar();

                SqlCommand cmd = new SqlCommand("_sp_EliminarIncPorCamyFecha", con.cnxn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idc", idCamarera);
                cmd.Parameters.AddWithValue("@fecha", fecha);
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

        public List<C_Incidencia> listarIncCamFecha()
        {
            List<C_Incidencia> list = new List<C_Incidencia>();
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_sp_ListIncPorCamyFecha", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idc", idCamarera);
            cmd.Parameters.AddWithValue("@fecha", fecha);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    C_Incidencia nodo = new C_Incidencia();
                    nodo.idSuministro = dr.GetInt32(1);
                    nodo.idHabitacion = dr.GetInt32(2);
                    nodo.cantidad = dr.GetInt32(3);
                    nodo.nhab = dr.GetString(10).Trim(new char[] { ' ' });
                    nodo.observacion = dr.GetString(7).Trim(new char[] { ' ' });
                    nodo.nomsum = dr.GetString(11).Trim(new char[] { ' ' });
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
                SqlCommand cmd = new SqlCommand("_sp_nuevaIncidencia", con.cnxn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idsum", idSuministro);
                cmd.Parameters.AddWithValue("@idh", idHabitacion);
                cmd.Parameters.AddWithValue("@fecha", fecha);
                cmd.Parameters.AddWithValue("@cant", cantidad);
                cmd.Parameters.AddWithValue("@idus", idUsuario);
                cmd.Parameters.AddWithValue("@fechamod", fechaModificacion);
                cmd.Parameters.AddWithValue("@idcam", idCamarera);
                cmd.Parameters.AddWithValue("@hora", hora);
                cmd.Parameters.AddWithValue("@obs", observacion);
                cmd.Parameters.AddWithValue("@nhab", nhab);
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
                SqlCommand cmd = new SqlCommand("_sp_editarIncidencia", con.cnxn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idsum", idSuministro);
                cmd.Parameters.AddWithValue("@idh", idHabitacion);
                cmd.Parameters.AddWithValue("@fecha", fecha);
                cmd.Parameters.AddWithValue("@cant", cantidad);
                cmd.Parameters.AddWithValue("@hora", hora);
                cmd.Parameters.AddWithValue("@obs", observacion);
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

        public List<C_Incidencia> listarMotivos()
        {
            List<C_Incidencia> list = new List<C_Incidencia>();
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_sp_listarMotivoIncidencia", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    C_Incidencia nodo = new C_Incidencia();
                    nodo.observacion = dr.GetString(1).Trim(new char[] { ' ' });
                    list.Add(nodo);
                }
            }
            con.desconectar();
            return list;
        }
    }
}
