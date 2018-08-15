using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace librerias
{
    public class montoPA
    {
        public string observacion;
        public double monto=0;
        public string inicio, fin;
        conexion con;

        public void agregar_montoPA()
        {

            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_SP_agregarMontoPA", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@monto", monto);
            cmd.Parameters.AddWithValue("@inicio", inicio);
            cmd.Parameters.AddWithValue("@fin", fin);
            cmd.Parameters.AddWithValue("@observacion", observacion);
            cmd.ExecuteNonQuery();
            con.desconectar();
        }
        public void buscar(string pIni)
        {
            string[] ini = pIni.Split('/');
            string fechI = ini[2] + "/" + ini[1] + "/" + ini[0];
           
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_SP_BuscarMontoPA", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fVenta", fechI);
          
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                monto = dr.GetDouble(0);
                observacion = dr.GetString(1).Trim(new char[] {' '});
                inicio = dr.GetDateTime(2).ToShortDateString();
                fin = dr.GetDateTime(3).ToShortDateString();

            }
            con.desconectar();
        }

        public SqlDataReader buscartodos()
        {
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_SP_listarMontoPA", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;           
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                return dr;
            }
            con.desconectar();
            return null;
        }

        public SqlDataReader buscarmontos()
        {
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_SP_buscarMontosCotizacion", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                return dr;
            }
            con.desconectar();
            return null;
        }

        public void actualizar_montos(double pmonto,int pref)
        {

            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_SP_actualizarMontos", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@monto", pmonto);
            cmd.Parameters.AddWithValue("@ref", pref);            
            cmd.ExecuteNonQuery();
            con.desconectar();
        }
        public void actualizar_pagosni(int idreserva)
        {
            string concepto;
            concepto = "NO TODO INCLUIDO";
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_SP_actualizarNoim", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@concepto", concepto);
            cmd.Parameters.AddWithValue("@idreserva", idreserva);
            cmd.ExecuteNonQuery();
            con.desconectar();
        }
        public void actualizar_estatus_rese(int idreserva)
        {
            if (con == null)
                con = new conexion();
            con.conectar();
            SqlCommand cmd = new SqlCommand("_SP_actualizar_esta_re", con.cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idreserva", idreserva);
            cmd.ExecuteNonQuery();
            con.desconectar();
        }
    }
}
