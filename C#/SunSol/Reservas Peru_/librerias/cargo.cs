using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace librerias
{
    public class cargo
    {
        public string descripcion, observacion;
        conexion con;

        public void agregar_cargo()
        {

            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_SP_agregarCargo", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@descripcion", descripcion);
            cmd.Parameters.AddWithValue("@observacion", observacion);
            cmd.ExecuteNonQuery();
            con.desconectar();
        }
        public bool existe()
        {
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_sp_verificaCargo", con.cnxn);
            cmd.Parameters.AddWithValue("@cargo", descripcion);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                con.desconectar();
                return true;
            }
            con.desconectar();
            return false;
        }
        public SqlDataReader listar()
        {
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_sp_listarCargo", con.cnxn);          
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                
                return dr;
            }
            con.desconectar();
            return null;
        }
    }
}
