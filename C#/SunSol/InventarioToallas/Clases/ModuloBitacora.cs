using System;
using System.Collections.Generic;
using System.Linq;


namespace Clases
{
    using System.Text;
    using System.Threading.Tasks;
    using System.Data;
    using System.Data.SqlClient;
    using System.ComponentModel;
    using System.Windows;
    public partial class ModuloBitacora
    {

        conexion con;

        public int idmodulo { get; set; }

        public string nombre { get; set; }

        public List<ModuloBitacora> listar()
        {
            List<ModuloBitacora> list = new List<ModuloBitacora>();
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_sp_listarModuloBitacora", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    ModuloBitacora nodo = new ModuloBitacora();
                    nodo.idmodulo = dr.GetInt32(0);
                    nodo.nombre = dr.GetString(1).Trim(new char[] { ' ' });
                    list.Add(nodo);
                }
            }
            con.desconectar();
            return list;
        }

    }
}
