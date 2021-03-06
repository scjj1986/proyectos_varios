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
    
    public partial class C_Telemarketing
    {
        conexion con;
        public C_Telemarketing()
        {
            this.C_Cita = new HashSet<C_Cita>();
        }
    
        public int id_telemarketing { get; set; }
        public Nullable<int> id_td { get; set; }
        public string doc_iden { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        public string codigo { get; set; }
    
        public virtual ICollection<C_Cita> C_Cita { get; set; }
       
        public virtual C_TipoDocumento C_TipoDocumento { get; set; }


        public List<C_Telemarketing> listarTelemarketing()
        {
            List<C_Telemarketing> telemarketing = new List<C_Telemarketing>();
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_sp_listarTelemarketing", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    C_Telemarketing tele = new C_Telemarketing();
                    tele.id_telemarketing = dr.GetInt32(0);
                    tele.doc_iden = dr.GetString(1).Trim(new char[] { ' ' });
                    tele.nombre = dr.GetString(2).Trim(new char[] { ' ' });
                    tele.apellido = dr.GetString(3).Trim(new char[] { ' ' });
                    tele.telefono = dr.GetString(4).Trim(new char[] { ' ' });
                    tele.correo = dr.GetString(5).Trim(new char[] { ' ' });
                   
                   
                    tele.C_TipoDocumento = new C_TipoDocumento();
                    tele.C_TipoDocumento.descripcion = dr.GetString(6).Trim(new char[] { ' ' });                   
                    tele.id_td = dr.GetInt32(7);
                    tele.codigo = dr.GetString(8).Trim(new char[] { ' ' });
                    telemarketing.Add(tele);
                }
            }
            con.desconectar();
            return telemarketing;
        }

        public int NuevoTelemarketing()
        {
            try
            {
                if (con == null)
                    con = new conexion();
                con.conectar();
                SqlCommand cmd = new SqlCommand("_sp_nuevoTelemarketing", con.cnxn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@documento", doc_iden);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@apellido", apellido);
                cmd.Parameters.AddWithValue("@telefono", telefono);
                cmd.Parameters.AddWithValue("@correo", correo);
                cmd.Parameters.AddWithValue("@tipo", id_td);
                cmd.Parameters.AddWithValue("@codigo", codigo);               
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

        public int editarTelemarketing()
        {
            try
            {
                if (con == null)
                    con = new conexion();
                con.conectar();
                SqlCommand cmd = new SqlCommand("_sp_editarTelemarketing", con.cnxn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id_telemarketing);
                cmd.Parameters.AddWithValue("@documento", doc_iden);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@apellido", apellido);
                cmd.Parameters.AddWithValue("@telefono", telefono);
                cmd.Parameters.AddWithValue("@correo", correo);
                cmd.Parameters.AddWithValue("@tipo", id_td);
                cmd.Parameters.AddWithValue("@codigo", codigo);
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
