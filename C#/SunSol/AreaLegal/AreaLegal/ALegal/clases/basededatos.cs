using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ALegal
{
    public class basededatos
    {
        String cadenaConexion = @"Persist Security Info=False;User ID=contratos_reservas;Password=c0ntratos2016**;Initial Catalog=BD_AREA_LEGAL;Server=SUNSOLCARSQL03";
        public SqlConnection cnxn;
        public basededatos()
        {
            cnxn = new SqlConnection(cadenaConexion);
        }
        public int conectar()
        {
            try
            {
                if (cnxn.State == ConnectionState.Closed)
                    cnxn.Open();
                return 1;
            }


            catch (SqlException ex)
            {
                Console.WriteLine(ex.StackTrace);
                return 0;
            }

        }
        public void desconectar()
        {
            try
            {
                cnxn.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        public void ejecutar_consulta(string qr_sp, CommandType tipoconsulta, List<parametros> Parametros)
        {
            this.conectar();
            SqlCommand cmd = new SqlCommand(qr_sp, cnxn);
            cmd.CommandType = tipoconsulta;
            cmd.CommandText = qr_sp;

            foreach (parametros Param in Parametros)
                cmd.Parameters.AddWithValue(Param.nombre, Param.Valor);

            cmd.ExecuteNonQuery();
            desconectar();
        }

        public DataTable generar_datatable(string qr_sp, CommandType tipoconsulta, List<parametros> Parametros)
        {
            try
            {
                DataTable result = new DataTable();
                conectar();
                SqlCommand cmd = new SqlCommand(qr_sp, cnxn);
                cmd.CommandType = tipoconsulta;
                cmd.CommandTimeout = 10000;

                foreach (parametros Param in Parametros)
                    cmd.Parameters.AddWithValue(Param.nombre, Param.Valor);

                SqlDataReader dr = cmd.ExecuteReader();
                result.Load(dr);
                desconectar();
                return result;
            }
            catch
            {
                desconectar();
                return null;
            }
            
            
        }
    }
}
