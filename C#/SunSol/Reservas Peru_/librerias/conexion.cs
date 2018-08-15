using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace librerias
{
    public class conexion
    {
       //------------------------------------------ Prueba ------------------------------------//
       //String cadenaConexion = @"Persist Security Info=False;User ID=contratos_reservas;Password=c0ntratos2016**;Initial Catalog=CONTRATOS_PRU;Server=SUNSOLCARSQL03";    
        
        
        
        //String cadenaConexion = @"Persist Security Info=False;User ID=contratos_reservas;Password=reserv@s2016**;Initial Catalog=CONTRATOS;Server=SUNSOLCARSQL04";

       String cadenaConexion = @"Persist Security Info=False;User ID=contratos2;Password=123456;Initial Catalog=CONTRATOS_PRUEBA;Server=192.168.138.29";
       String conexionProfit = @"Persist Security Info=False;User ID=contratos2;Password=123456;Initial Catalog=SEAPER_A;Server=192.168.138.29";
        public SqlConnection cnxn,cnxcP;
        public conexion()
        {
            cnxn = new SqlConnection(cadenaConexion);            
        }
        public int conectar()
        {
            try
            {
                if(cnxn.State==ConnectionState.Closed)                
                    cnxn.Open();
                return 1;
            }
            catch (SqlException ex) {
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
            catch (SqlException ex) {
                Console.WriteLine(ex.StackTrace);
            } 
        }
        public int conectarProfit()
        {
            try
            {
                cnxcP = new SqlConnection(conexionProfit);
                cnxcP.Open();
                return 1;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.StackTrace);
                return 0;
            }
        }
        public void cerrarConexionProfit()
        {
            if (cnxn.State == ConnectionState.Open)
                cnxn.Close();
        }

    }
}
