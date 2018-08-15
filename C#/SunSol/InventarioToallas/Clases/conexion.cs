using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Clases
{
    class conexion
    {
        //conexion prueba*************
       String cadenaConexion = @"Persist Security Info=False;User ID=contratos_reservas;Password=c0ntratos2016**;Initial Catalog=_BD_INVENTARIO_HABITACION;Server=SUNSOLCARSQL03";
        
        //conexion produccion****************
        //String cadenaConexion = @"Persist Security Info=False;User ID=cotizador;Password=c0tizador2015*;Initial Catalog=_BD_INVENTARIO_HABITACION;Server=SUNSOLCARSQL04\Iqware";
        
        //Conexion IQWARE************
        String cadenaConexionIqware = @"Persist Security Info=False;User ID=cotizador;Password=c0tizador2015*;Initial Catalog=IslaCaribePMS;Server=SUNSOLCARSQL04\Iqware";
        public SqlConnection cnxn;
        public SqlConnection cnxnIq;
        public conexion()
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
        public void conexionIqware()
        {
            cnxnIq = new SqlConnection(cadenaConexionIqware);
        }
        public int conectarIqware()
        {
            try
            {
                if (cnxnIq.State == ConnectionState.Closed)
                    cnxnIq.Open();
                return 1;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.StackTrace);
                return 0;
            }

        }
        public void desconectaIqware()
        {
            try
            {
                cnxnIq.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
