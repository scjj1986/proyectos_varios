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
    public partial class AccionesModulo
    {

        conexion con;

        public int idaccion { get; set; }

        public string nombre { get; set; }

        public List<AccionesModulo> listar()
        {
            List<AccionesModulo> list = new List<AccionesModulo>();
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_sp_listarAccionesModulo", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    AccionesModulo nodo = new AccionesModulo();
                    nodo.idaccion = dr.GetInt32(0);
                    nodo.nombre = dr.GetString(1).Trim(new char[] { ' ' });
                    list.Add(nodo);
                }
            }
            con.desconectar();
            return list;
        }
    }
}
