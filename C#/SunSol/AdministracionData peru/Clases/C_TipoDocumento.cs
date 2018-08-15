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
    
    public partial class C_TipoDocumento
    {
        public C_TipoDocumento()
        {
            this.C_Cliente = new HashSet<C_Cliente>();
            this.C_Telemarketing = new HashSet<C_Telemarketing>();
        }
        conexion con;
        public int id_td { get; set; }
        public string descripcion { get; set; }
        public string formato { get; set; }
        public int id_pais { get; set; }    
        public virtual ICollection<C_Cliente> C_Cliente { get; set; }
        public virtual ICollection<C_Telemarketing> C_Telemarketing { get; set; }

        public int nuevoDocumento()
        {
            try
            {
                if (con == null)
                    con = new conexion();
                con.conectar();
                SqlCommand cmd = new SqlCommand("_sp_nuevoDocumento", con.cnxn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@descripcion", descripcion);
                cmd.Parameters.AddWithValue("@formato", formato);
                cmd.Parameters.AddWithValue("@idpais", id_pais);
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

        public List<C_TipoDocumento> listarDocumento()
        {
            List<C_TipoDocumento> documentos = new List<C_TipoDocumento>();
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_sp_listarDocumentos", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    C_TipoDocumento doc = new C_TipoDocumento();
                    doc.id_td = dr.GetInt32(0);
                    doc.descripcion = dr.GetString(1).Trim(new char[] { ' ' });
                    doc.formato = dr.GetString(2).Trim(new char[] { ' ' });
                    doc.id_pais = dr.GetInt32(3);
                    documentos.Add(doc);
                }
            }
            con.desconectar();
            return documentos;
        }

    }
}