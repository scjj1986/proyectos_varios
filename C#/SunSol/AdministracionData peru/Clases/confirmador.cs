using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Clases
{
    public class confirmador
    {
        conexion con;
         public int id_confirmador { get; set; }
        public Nullable<int> id_td { get; set; }
        public string doc_iden { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        //public string codigo { get; set; }
    
        public virtual ICollection<C_Cita> C_Cita { get; set; }
       
        public virtual C_TipoDocumento C_TipoDocumento { get; set; }


        public List<confirmador> listarConfirmador()
        {
            List<confirmador> confirmador = new List<confirmador>();
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_sp_listarConfirmador", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    confirmador conf = new confirmador();
                    conf.id_confirmador = dr.GetInt32(0);
                    conf.doc_iden = dr.GetString(1).Trim(new char[] { ' ' });
                    conf.nombre = dr.GetString(2).Trim(new char[] { ' ' });
                    conf.apellido = dr.GetString(3).Trim(new char[] { ' ' });
                    conf.telefono = dr.GetString(4).Trim(new char[] { ' ' });
                    conf.correo = dr.GetString(5).Trim(new char[] { ' ' });
                   
                   
                    conf.C_TipoDocumento = new C_TipoDocumento();
                    conf.C_TipoDocumento.descripcion = dr.GetString(6).Trim(new char[] { ' ' });                   
                    conf.id_td = dr.GetInt32(7);
                   // conf.codigo = dr.GetString(8).Trim(new char[] { ' ' });
                    confirmador.Add(conf);
                }
            }
            con.desconectar();
            return confirmador;
        }

        public int NuevoConfirmador()
        {
            try
            {
                if (con == null)
                    con = new conexion();
                con.conectar();
                SqlCommand cmd = new SqlCommand("_sp_nuevoConfirmador", con.cnxn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@documento", doc_iden);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@apellido", apellido);
                cmd.Parameters.AddWithValue("@telefono", telefono);
                cmd.Parameters.AddWithValue("@correo", correo);
                cmd.Parameters.AddWithValue("@tipo", id_td);
               // cmd.Parameters.AddWithValue("@codigo", codigo);               
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

        public int editarConfirmador()
        {
            try
            {
                if (con == null)
                    con = new conexion();
                con.conectar();
                SqlCommand cmd = new SqlCommand("_sp_editarConfirmador", con.cnxn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id_confirmador);
                cmd.Parameters.AddWithValue("@documento", doc_iden);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@apellido", apellido);
                cmd.Parameters.AddWithValue("@telefono", telefono);
                cmd.Parameters.AddWithValue("@correo", correo);
                cmd.Parameters.AddWithValue("@tipo", id_td);
               // cmd.Parameters.AddWithValue("@codigo", codigo);
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
