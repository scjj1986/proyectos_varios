using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Clases
{
    public class statusCita
    {
        public int idSubStatus { get; set; }
        public string descripcion { get; set; }
        public string observacion { get; set; }

        conexion con;

        public List<statusCita> listarStatus()
        {
            List<statusCita> status = new List<statusCita>();
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_sp_listarSubStatusCita", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;           
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    statusCita sts = new statusCita();
                    sts.idSubStatus = dr.GetInt32(0);
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
