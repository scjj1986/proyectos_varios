using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace librerias
{
    public class formasdepago
    {
        public int codigo { get; set; }
        public string descripcion { get; set; }

        public string estatus { get; set; }
        conexion con;

        public List<formasdepago> listar()
        {
            List<formasdepago> list = new List<formasdepago>();
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_SP_ListarFormasDePago", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    formasdepago nodo = new formasdepago();
                    nodo.codigo = Convert.ToInt32(dr["Codigo"]);
                    nodo.descripcion = Convert.ToString(dr["Descripcion"]).Trim(new char[] { ' ' });
                    nodo.estatus = Convert.ToString(dr["Estatus"]).Trim(new char[] { ' ' });
                    list.Add(nodo);
                }
            }
            con.desconectar();
            return list;
        }

        public List<formasdepago> listaractivas()
        {
            List<formasdepago> list = new List<formasdepago>();
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_SP_ListarFormasDePagoActivas", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    formasdepago nodo = new formasdepago();
                    nodo.codigo = Convert.ToInt32(dr["Codigo"]);
                    nodo.descripcion = Convert.ToString(dr["Descripcion"]).Trim(new char[] { ' ' });
                    nodo.estatus = Convert.ToString(dr["Estatus"]).Trim(new char[] { ' ' });
                    list.Add(nodo);
                }
            }
            con.desconectar();
            return list;
        }

        

        public bool existeFDP()
        {
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_SP_existeFormaDePago", con.cnxn);
            cmd.Parameters.AddWithValue("@codigo", codigo);
            cmd.Parameters.AddWithValue("@descr", descripcion);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                con.desconectar();
                return true;
            }
            con.desconectar();
            return false;
        }

        public int guardar_editar()
        {

            if (con == null)
                con = new conexion();
            con.conectar();
            try
            {
                SqlCommand cmd = new SqlCommand("_SP_guardar-editarFormaDePago", con.cnxn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo", codigo);
                cmd.Parameters.AddWithValue("@descr", descripcion);
                cmd.Parameters.AddWithValue("@estatus", estatus);
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
