using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Clases
{
    public class historial
    {
        public int idCliente { get; set; }
        public DateTime? fecha { get; set; }
        public string observacion { get; set; }
        public int? veces { get; set; }
        public string hora{ get; set; }
        public string teleoperador { get; set; }

        conexion con;

        public List<historial> buscar(int cliente)
        {
            List<historial> list = new List<historial>();
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
                        historial h = new historial();
                        h.idCliente=dr.GetInt32(0);
                        DateTime? f = (Convert.IsDBNull(dr["fecha"]) ? null : (DateTime?)Convert.ToDateTime(dr["fecha"]));
                        h.fecha = f;
                        h.observacion = (dr["observacion"].Equals(null) ? null : dr["observacion"].ToString().Trim(new char[] { ' ' }));
                        // confirmador = dr.GetString(4).Trim(new char[] { ' ' });

                       h.veces = (Convert.IsDBNull(dr["veces"]) ? null : (int?)Convert.ToInt32(dr["veces"]));
                       h.hora = (dr["hora"].Equals(null) ? null : dr["hora"].ToString().Trim(new char[] { ' ' }));
                       h.teleoperador = (dr["teleoperador"].Equals(null) ? null : dr["teleoperador"].ToString().Trim(new char[] { ' ' }));
                       list.Add(h);
                    }
                    con.desconectar();
                   
                }               
                return list;
            } 
           
            catch
            {
                con.desconectar();
                return list;
            }
        }

    }
}
