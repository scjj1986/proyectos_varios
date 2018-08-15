using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Clases
{
   public class C_detalleCita
    {
        public int id_DetalleCita { get; set; }
        public DateTime? fecha { get; set; }
        public string observacion { get; set; }
        public int confirmador { get; set; }
        public int teleoperador { get; set; }
        public int idstatusCita { get; set; }
        public int veces { get; set; }
        public string hora { get; set; }
        public int id_cliente { get; set; }

        conexion con;
        public int agregardetalleCita()
        {
            try
            {
                if (con == null)
                    con = new conexion();
                con.conectar();
                SqlCommand cmd = new SqlCommand("_sp_detalleCita", con.cnxn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@fecha", fecha);
                cmd.Parameters.AddWithValue("@observacion", observacion);
                cmd.Parameters.AddWithValue("@confirmador", confirmador);
                cmd.Parameters.AddWithValue("@idStatus", idstatusCita);
                cmd.Parameters.AddWithValue("@veces", veces);
                cmd.Parameters.AddWithValue("@hora", hora);
                cmd.Parameters.AddWithValue("@cliente", id_cliente);
                cmd.Parameters.AddWithValue("@teleoperador", teleoperador);                
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
        public int buscar(int cliente)
        {
            try
            {
                if (con == null)
                    con = new conexion();
                con.conectar();
                SqlCommand cmd = new SqlCommand("_sp_BuscardetalleCita", con.cnxn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cliente", cliente);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        id_DetalleCita = dr.GetInt32(0);
                        cliente = dr.GetInt32(1);
                        DateTime? f = (Convert.IsDBNull(dr["fecha"]) ? null : (DateTime?)Convert.ToDateTime(dr["fecha"]));
                        fecha= f;
                        observacion = dr.GetString(3).Trim(new char[] { ' ' });
                       // confirmador = dr.GetString(4).Trim(new char[] { ' ' });
                        idstatusCita = dr.GetInt32(5);
                        veces = dr.GetInt32(6);
                        hora = dr.GetString(7).Trim(new char[] { ' ' });                       
                    }
                    con.desconectar();  
                    return 1;
                }
                else
                {
                    con.desconectar();
                    return 0;
                }
                       
            }
            catch
            {
                con.desconectar();
                return 2;
            }
        }
        
    }
}
