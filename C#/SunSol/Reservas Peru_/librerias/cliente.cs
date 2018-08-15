using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace librerias
{
    public class cliente
    {
        public String nombres, apellidos, cedula_rif, direccion, telefono1, telefono2, telefono3, email,agregado_por,modificado_por,
            borrado_por,estado,nacionalidad,twitter,instagram;        
        public int codigoPais, codigoEstado, codigoCiudad, zonaPostal, codigoOcupacion, codigoProfesion, codigoOficina;
        public double totalPuntos, puntosConsumidos, puntosDisponibles;
        public conexion con;

        void buscar(String pcedula_rif,String pnombre,String ptipo,String pnumeroContrato)
        {
            if (con == null)
               con = new conexion();
            if (con.conectar() == 0)
            {
                
            }
            SqlCommand cmd = new SqlCommand("SP_BuscarDatosAsociadosCliente", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Tipo", pcedula_rif);
            cmd.Parameters.AddWithValue("@Nombre", pcedula_rif);
            cmd.Parameters.AddWithValue("@Cedula", pcedula_rif);
            cmd.Parameters.AddWithValue("@NroContrato", pcedula_rif);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

            }

            con.desconectar();
        }

        public void ingresar()
        {
            if (con==null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("Insertar_Cliente", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Cedula_rif", "");
            cmd.Parameters.AddWithValue("@Nombres", "");
            cmd.Parameters.AddWithValue("@Apellidos", "");
            cmd.Parameters.AddWithValue("@Direccion","porlamar");
            cmd.Parameters.AddWithValue("@Telefono1", "");
            cmd.Parameters.AddWithValue("@Telefono2","");
            cmd.Parameters.AddWithValue("@Telefono3", "");
            cmd.Parameters.AddWithValue("@Email", "sdkjasdj@dfk.com");
            cmd.Parameters.AddWithValue("@FechaNacimiento", "");
            cmd.Parameters.AddWithValue("@CodigoPais", 0);
            cmd.Parameters.AddWithValue("@CodigoEstado", 0);
            cmd.Parameters.AddWithValue("@CodigoCiudad", 0);
            cmd.Parameters.AddWithValue("@ZonaPostal", "");
            cmd.Parameters.AddWithValue("@CodigoOcupacion", 0);
            cmd.Parameters.AddWithValue("@CodigoProfesion", 0);
            cmd.Parameters.AddWithValue("@CodigoOficina", 0);
            cmd.Parameters.AddWithValue("@RIF", "");
            cmd.Parameters.AddWithValue("@Twitter", "");
            cmd.Parameters.AddWithValue("@Instagram", "");
            cmd.Parameters.AddWithValue("@Agregado_por", "");
          //  cmd.Parameters.AddWithValue("@Modificado_por", "");
           // cmd.Parameters.AddWithValue("@Borrado_por", "");
            cmd.Parameters.AddWithValue("@Nacionalidad", "");
           

            cmd.ExecuteNonQuery();
            con.desconectar();

        }

        public SqlDataReader buscar_contratos(String pCedula,string pnombre,string pcontrato)
        {
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_sp_buscarContrato", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            cmd.Parameters.AddWithValue("@cedula", pCedula);
            cmd.Parameters.AddWithValue("@contrato", pcontrato);
            cmd.Parameters.AddWithValue("@nombres", pnombre);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows) {
               
                return dr; 
            }
            con.desconectar();
            return null;
           
        }

        public int buscar_cliente(string pCedula, string pcontrato)
        {
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_sp_buscarCliente", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cedula", pCedula);
            cmd.Parameters.AddWithValue("@contrato", pcontrato);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                if (dr.Read()) { 
                    nombres = dr.GetString(0);
                    apellidos = dr.GetString(1);
                    direccion = dr.GetString(2);
                    telefono1 = dr.GetString(3);
                    telefono2 = dr.GetString(4);
                    telefono3= dr.GetString(5);
                    email = dr.GetString(6);
                    totalPuntos =double.Parse(dr.GetSqlMoney(7).ToString());
                    puntosConsumidos = double.Parse(dr.GetSqlMoney(8).ToString());
                    puntosDisponibles = double.Parse(dr.GetSqlMoney(9).ToString());
                }
                con.desconectar();
                return 1;
            }
            con.desconectar();
            return 0;
        }

        public SqlDataReader buscar_puntos(String pCedula,Int32 pNroContrato)
        {
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_sp_puntosPorAnio", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cedula", pCedula);
            cmd.Parameters.AddWithValue("@n_contrato",pNroContrato);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
               
                return dr;
                
            }
            con.desconectar();
            return null;

        }

        public SqlDataReader EstadoCuenta(string pNroContrato)
        {
            if (con == null)
                con = new conexion();
            con.conectarProfit();
            SqlCommand cmd = new SqlCommand("EstadoDeCuentaCliente", con.cnxcP);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Num_Contrato", pNroContrato);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {

                return dr;

            }
            con.cerrarConexionProfit();
            return null;

        }

    }
}
