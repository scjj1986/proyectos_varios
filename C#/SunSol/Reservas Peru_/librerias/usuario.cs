using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows;



namespace librerias
{
    public class usuario
    {
        public int codigo { get; set; }
        public string login{ get; set; }
        public string nombres{ get; set; }
        public string apellidos{ get; set; }
        public string clave { get; set; }
        public string cedula{ get; set; }
        public string telefono { get; set; }
        public string email{ get; set; }
        public string estatus{ get; set; }
        public string nombreperfil { get; set; } 
        public int codigoPerfil{ get; set; }
        public int activo { get; set; }

        public int coper { get; set; }
        conexion con;
        public int autenticar(String pUsuario,String pClave)
        {
            try
            {
                if (con == null)
                    con = new conexion();
                con.conectar();
                SqlCommand cmd = new SqlCommand("_sp_login", con.cnxn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usuario", pUsuario);
                cmd.Parameters.AddWithValue("@clave", pClave);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        login = dr.GetString(0);
                        nombres = dr.GetString(1);
                        apellidos = dr.GetString(2);
                        coper = dr.GetInt32(3);
                        codigoPerfil = dr.GetInt32(8);
                        email = dr.GetString(4);
                        activo = dr.GetInt16(5);
                        cedula = dr.GetString(6);
                        telefono = dr.GetString(7);
                    }
                    con.desconectar();
                    return 1;

                }
                else
                {
                    con.desconectar();
                    return 0;
                }
            }
            catch 
            {               
                return 2;
            }
            
        }

        public SqlDataReader buscar_ejecutivo(string pUser)
        {
            
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_sp_buscaEjecutivo", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@usuario", pUser);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)            {

                return dr;
            }
            con.desconectar();
            return null;

        }

        public int guardar_editar()
        {

            if (con == null)
                con = new conexion();
            con.conectar();
            try
            {
                SqlCommand cmd = new SqlCommand("_SP_guardar-editarUsuario", con.cnxn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo", codigo);
                cmd.Parameters.AddWithValue("@nombre", nombres);
                cmd.Parameters.AddWithValue("@apellido", apellidos);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@tlf", telefono);
                cmd.Parameters.AddWithValue("@codperf", codigoPerfil);
                cmd.Parameters.AddWithValue("@login", login);
                cmd.Parameters.AddWithValue("@clave", clave);
                cmd.Parameters.AddWithValue("@activo", activo);
                cmd.Parameters.AddWithValue("@cedula", cedula);
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

        public List<usuario> listar()
        {
            List<usuario> list = new List<usuario>();
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_SP_ListarUsuarios", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    usuario nodo = new usuario();
                    nodo.codigo = Convert.ToInt32(dr["Codigo"]);
                    nodo.login = Convert.ToString(dr["Login"]).Trim(new char[] { ' ' });
                    nodo.nombres = Convert.ToString(dr["Nombres"]).Trim(new char[] { ' ' });
                    nodo.apellidos = dr.IsDBNull(4) ? "" : Convert.ToString(dr["Apellidos"]).Trim(new char[] { ' ' });
                    nodo.email = Convert.ToString(dr["Email"]).Trim(new char[] { ' ' });
                    nodo.activo = Convert.ToInt32(dr["Activo"]);

                    if (nodo.activo == 1)
                        nodo.estatus = "ACTIVO";
                    else
                        nodo.estatus = "INACTIVO";

                    nodo.cedula = Convert.ToString(dr["Cedula"]).Trim(new char[] { ' ' });
                    nodo.nombreperfil = Convert.ToString(dr["Nombre"]).Trim(new char[] { ' ' });
                    nodo.codigoPerfil = Convert.ToInt32(dr["reservaciones"]);
                    nodo.clave = Convert.ToString(dr["Clave"]);
                    nodo.telefono = dr.IsDBNull(10) ? "" : Convert.ToString(dr["Telefonos"]).Trim(new char[] { ' ' });

                    list.Add(nodo);
                }
            }
            con.desconectar();
            return list;
        }

        public List<usuario> filtrar(string valor)
        {
            List<usuario> list = new List<usuario>();
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_SP_FiltrarUsuarios", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@valor", valor);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    usuario nodo = new usuario();
                    nodo.codigo = Convert.ToInt32(dr["Codigo"]);
                    nodo.login = Convert.ToString(dr["Login"]).Trim(new char[] { ' ' });
                    nodo.nombres = Convert.ToString(dr["Nombres"]).Trim(new char[] { ' ' });
                    nodo.apellidos = dr.IsDBNull(4) ? "" : Convert.ToString(dr["Apellidos"]).Trim(new char[] { ' ' });
                    nodo.email = Convert.ToString(dr["Email"]).Trim(new char[] { ' ' });
                    nodo.activo = Convert.ToInt32(dr["Activo"]);

                    if (nodo.activo == 1)
                        nodo.estatus = "ACTIVO";
                    else
                        nodo.estatus = "INACTIVO";

                    nodo.cedula = Convert.ToString(dr["Cedula"]).Trim(new char[] { ' ' });
                    nodo.nombreperfil = Convert.ToString(dr["Nombre"]).Trim(new char[] { ' ' });
                    nodo.codigoPerfil = Convert.ToInt32(dr["reservaciones"]);
                    nodo.clave = Convert.ToString(dr["Clave"]);
                    nodo.telefono = dr.IsDBNull(10) ? "" : Convert.ToString(dr["Telefonos"]).Trim(new char[] { ' ' });

                    list.Add(nodo);
                }
            }
            con.desconectar();
            return list;
        }

        public List<usuario> listarPerfiles()
        {
            List<usuario> list = new List<usuario>();
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_SP_ListarPerfiles", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    usuario nodo = new usuario();
                    nodo.codigo = Convert.ToInt32(dr["Codigo"]);
                    nodo.nombreperfil = Convert.ToString(dr["Nombre"]).Trim(new char[] { ' ' });
                    list.Add(nodo);
                }
            }
            con.desconectar();
            return list;


        }

        public bool existeCedula()
        {
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_SP_existeCedulaUsuario", con.cnxn);
            cmd.Parameters.AddWithValue("@codigo", codigo);
            cmd.Parameters.AddWithValue("@cedula", cedula);
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

        public bool existeLogin()
        {
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_SP_existeLoginUsuario", con.cnxn);
            cmd.Parameters.AddWithValue("@codigo", codigo);
            cmd.Parameters.AddWithValue("@login", login);
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

        
    }
}
