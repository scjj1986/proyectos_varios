using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Clases
{
    public class conexion
    {
        //conexion oficina**********************************************
       //string cadenaConexion = @"Persist Security Info=False;User ID=sa;Password=15422252;Initial Catalog=_CUPONES;Server=DESKTOP-I6EEKAF\SUNSOLCARSQL03";
        //conexion sunsol**********************************************
      //string cadenaConexion = @"Persist Security Info=False;User ID=contratos_reservas;Password=c0ntratos2017**;Initial Catalog=_BD_CUPONES;Server=192.168.138.29"; 

        string cadenaConexion = @"Persist Security Info=False;User ID=contratos2;Password=123456;Initial Catalog=_BD_CUPONES;Server=192.168.138.29"; 
        //string cadenaConexion = @"Persist Security Info=False;User ID=contratos_reservas;Password=c0ntratos2016**;Initial Catalog=_BD_CUPONES;Server=SUNSOLCARSQL03";       
        
        public SqlConnection cnxn;
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
      
    }
}
