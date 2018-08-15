using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace librerias
{
   public class temporada
    {
        public string descripcion, fechaI, fechaF,hotel;
        public double bsInfante, bsNinio, bsAdulto;
        conexion con;

        public void agregar_temporada()
        {
            String[] ini = fechaI.Split('/');
            String[] f = fechaF.Split('/');
            String[] anioI = ini[2].Split(' ');
            String[] aniof = f[2].Split(' ');
            String fechaIni = anioI[0] + "/" + ini[1] + "/" + ini[0];
            String fechaFin = aniof[0] + "/" + f[1] + "/" + f[0];
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_SP_agregarTemporada", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@descripcion", descripcion);
            cmd.Parameters.AddWithValue("@fechaI", fechaIni);
            cmd.Parameters.AddWithValue("@fechaF", fechaFin);
            cmd.Parameters.AddWithValue("@bsInfante", bsInfante);
            cmd.Parameters.AddWithValue("@bsNinio", bsNinio);
            cmd.Parameters.AddWithValue("@bsAdulto", bsAdulto);
            cmd.Parameters.AddWithValue("@hotel", hotel);
            cmd.ExecuteNonQuery();
            con.desconectar();
        }

        public SqlDataReader listarTemporada()
        {
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_sp_listarTemporada", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;           
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)            {

                return dr;
            }
            con.desconectar();
            return null;

        }
    }
}
