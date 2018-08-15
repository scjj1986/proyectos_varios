using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace librerias
{
    public class hotel
    {
       public String[] temporada;
       conexion con;
       public int capacidad = 0;
       public double bsInfante = 0, bsNinio = 0, bsAdulto = 0;
        public SqlDataReader buscar_hoteles()
        {
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_sp_buscarHotel", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;          
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {

                return dr;
            }
            con.desconectar();
            return null;

        }
        public SqlDataReader buscar_habitacion(String photel,int pNumContrato)
        {
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_sp_buscarHabitacion", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@hotel", photel);
            cmd.Parameters.AddWithValue("@NroContrato", pNumContrato);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {

                return dr;
            }
            con.desconectar();
            return null;

        }

        public void buscar_capacidad(String phabitacion,String photel)
        {
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_sp_buscarCapacidad", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@habitacion", phabitacion);
            cmd.Parameters.AddWithValue("@hotel", photel);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                if (dr.Read())
                    if (!dr.GetInt32(0).Equals(null))
                    capacidad = dr.GetInt32(0);               
            }
            con.desconectar();
            

        }
        public SqlDataReader buscar_temporada(String pfechaI,String pfechaF,String photel,String phabitacion,int pNmrContrato,int anio)
        {
            String[] ini = pfechaI.Split('/');
            String[] f = pfechaF.Split('/');
            String[] anioI = ini[2].Split(' ');
            String[] aniof = f[2].Split(' ');
            String fechaIni = anioI[0] +"/"+ ini[1] +"/"+ ini[0];
            String fechaFin = aniof[0] +"/"+ f[1] +"/"+ f[0];
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_sp_buscaTemporada", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fechai", fechaIni);
            cmd.Parameters.AddWithValue("@fechaf", fechaFin);
            cmd.Parameters.AddWithValue("@hotel", photel);
            cmd.Parameters.AddWithValue("@habitacion", phabitacion);
            cmd.Parameters.AddWithValue("@NroContrato", pNmrContrato);
            cmd.Parameters.AddWithValue("@anio", anio);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                return dr;              
                
            }
            con.desconectar();
            return dr;


        }

        public int buscar_tarifa(String pfechaI,string photel)
        {
            String[] ini = pfechaI.Split('/');
           
            String[] anioI = ini[2].Split(' ');
           
            String fechaIni = anioI[0] + "/" + ini[1] + "/" + ini[0];
           
            if (con == null)
                con = new conexion();
            
            con.conectar();
            SqlCommand cmd = new SqlCommand("_sp_buscaTarifa", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fechai", fechaIni);
            cmd.Parameters.AddWithValue("@hotel", photel);    
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                if (dr.Read())
                {
                    bsInfante = dr.GetDouble(0);
                    bsNinio = dr.GetDouble(1);
                    bsAdulto = dr.GetDouble(2);

                }
                dr.Close();
                return 1;

            }         
            con.desconectar();
            return 0;
        }
    }
}
