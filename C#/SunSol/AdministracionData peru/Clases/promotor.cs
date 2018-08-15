using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
    using System.Data.SqlClient;

namespace Clases
{
    public class promotor
    {
        public int id_promotor { get; set; }
        public Nullable<int> id_td { get; set; }
        public string doc_iden { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        public Nullable<int> id_locacion { get; set; }

        public virtual ICollection<C_Cita> C_Cita { get; set; }
        public virtual C_Locacion C_Locacion { get; set; }
        public virtual C_TipoDocumento C_TipoDocumento { get; set; }
        conexion con;

        public List<promotor> listarpromotor()
        {
            List<promotor> promotor = new List<promotor>();
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_sp_listarPromotor", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    promotor tele = new promotor();
                    tele.id_promotor = dr.GetInt32(0);
                    tele.doc_iden = dr.GetString(1).Trim(new char[] { ' ' });
                    tele.nombre = dr.GetString(2).Trim(new char[] { ' ' });
                    tele.apellido = dr.GetString(3).Trim(new char[] { ' ' });
                    tele.telefono = dr.GetString(4).Trim(new char[] { ' ' });
                    tele.correo = dr.GetString(5).Trim(new char[] { ' ' });
                    tele.C_Locacion = new C_Locacion();
                    tele.C_Locacion.codigo = dr.GetString(6).Trim(new char[] { ' ' });
                    tele.C_TipoDocumento = new C_TipoDocumento();
                    tele.C_TipoDocumento.descripcion = dr.GetString(7).Trim(new char[] { ' ' });
                    tele.id_td = dr.GetInt32(8);
                    tele.id_locacion = dr.GetInt32(9);
                    promotor.Add(tele);
                }
            }
            con.desconectar();
            return promotor;
        }

        public int NuevoPromotor()
        {
            try
            {
                if (con == null)
                    con = new conexion();
                con.conectar();
                SqlCommand cmd = new SqlCommand("_sp_nuevoPromotor", con.cnxn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@documento", doc_iden);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@apellido", apellido);
                cmd.Parameters.AddWithValue("@telefono", telefono);
                cmd.Parameters.AddWithValue("@correo", correo);
                cmd.Parameters.AddWithValue("@tipo", id_td);
                cmd.Parameters.AddWithValue("@locacion", id_locacion);
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

        public int editarPromotor()
        {
            try
            {
                if (con == null)
                    con = new conexion();
                con.conectar();
                SqlCommand cmd = new SqlCommand("_sp_editarPromotor", con.cnxn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id_promotor);
                cmd.Parameters.AddWithValue("@documento", doc_iden);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@apellido", apellido);
                cmd.Parameters.AddWithValue("@telefono", telefono);
                cmd.Parameters.AddWithValue("@correo", correo);
                cmd.Parameters.AddWithValue("@tipo", id_td);
                cmd.Parameters.AddWithValue("@locacion", id_locacion);
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
