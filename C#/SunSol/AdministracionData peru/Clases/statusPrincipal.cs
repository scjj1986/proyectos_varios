using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Clases
{
    public class statusPrincipal
    {
        public int id_statusPrincipal { get; set; }
        public string descripcion { get; set; }
        public string observacion { get; set; }
        conexion con;

        public List<statusPrincipal> listarStatusPrincipal()
        {
            List<statusPrincipal> status = new List<statusPrincipal>();
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_sp_listarStatusPrincipal", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    statusPrincipal sts = new statusPrincipal();
                    sts.id_statusPrincipal = dr.GetInt32(0);
                    sts.descripcion = dr.GetString(1).Trim(new char[] { ' ' });
                    //sts.observacion = dr.GetString(2).Trim(new char[] { ' ' });                
                    status.Add(sts);
                }
            }
            con.desconectar();
            return status;
        }

    }
}
