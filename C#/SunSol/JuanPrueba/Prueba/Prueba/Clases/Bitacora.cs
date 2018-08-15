using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Net;

namespace Contratos.Clases
{
    public class Bitacora
    {

        public Bitacora(string ctto, string dsc)
        {
            this.contrato = ctto;
            this.evento = dsc;
        }
        
        
        
        public string usuario;
        public string contrato;
        public string evento;
        //public string host;

        
        public string string_de_un_campo(string txtSQL)
        {
            
            DataTable aux = Globales.BD.generar_datatable(txtSQL,CommandType.Text,new List<Parameters>());
            string campo = "";
            foreach (DataRow rw in aux.Rows)
                campo=Convert.ToString(rw[0]);

            return campo;
        }





        #region Módulo Clientes

        #region String Evento (Inserción)
        
        
        
        public string desc_ins_cli()
        {

            this.contrato = Globales.cli.cedulapas;
            string cad = "SE AGREGÓ EL CLIENTE '" + Globales.cli.nombres + " " + Globales.cli.apellidos + " CON CÉDULA=" + Globales.cli.nac +"-"+ Globales.cli.cedulapas;
            return cad;
        }


        #endregion

        #region String Evento (Modificación)


        #endregion

        #region Comparativa de campos (Base de Datos vs Nuevos)

        public bool campos_distintos_cliente()
        {

            bool encontrado = false;
            this.evento = "MODIFICACION DE CLIENTE DE ID " + Globales.cli.idcliente + " (";
            string campo = "";
            foreach (DataRow rw in Globales.BD.dtt.Rows)
            {

                if (Convert.ToString(rw["Nacionalidad"]).TrimEnd(' ') != Globales.cli.nac || Convert.ToString(rw["cedula_rif"]).TrimEnd(' ') != Globales.cli.cedulapas)
                {
                    encontrado=true;
                    this.evento += " CED. PAS. ANT.:" + Convert.ToString(rw["Nacionalidad"]).TrimEnd(' ') + "-" + Convert.ToString(rw["cedula_rif"]).TrimEnd(' ') + ", CED. PAS. NVO.:" + Globales.cli.nac + "-" + Globales.cli.cedulapas + ";";
                }
                if (Convert.ToString(rw["rif"]).TrimEnd(' ') != Globales.cli.rif)
                {
                    encontrado = true;
                    this.evento += " RIF. ANT.:" + Convert.ToString(rw["rif"]).TrimEnd(' ') + ", RIF. NVO.:" + Globales.cli.rif + ";";

                }

                if (Convert.ToString(rw["Nombres"]).TrimEnd(' ') != Globales.cli.nombres)
                {

                    encontrado = true;
                    this.evento += " NOMBRE. ANT.:" + Convert.ToString(rw["Nombres"]).TrimEnd(' ') + ", NOMBRE. NVO.:" + Globales.cli.nombres + ";";
                }

                campo = rw["Apellidos"] != DBNull.Value ? Convert.ToString(rw["Apellidos"]).TrimEnd(' ') : "";

                if (campo != Globales.cli.apellidos)
                {
                    encontrado = true;
                    this.evento += " APELLIDO. ANT.:" + campo + ", NOMBRE. NVO.:" + Globales.cli.apellidos + ";";
                }


                if (Convert.ToDateTime(rw["FechaNacimiento"]) != Globales.cli.fnac)
                {
                    encontrado = true;
                    this.evento += " FNAC. ANT.:" + Convert.ToDateTime(rw["FechaNacimiento"]).ToShortDateString() + ", FNAC. NVO.:" + Globales.cli.fnac.ToShortDateString() + ";";
                }

                campo = rw["Direccion"] != DBNull.Value ? Convert.ToString(rw["Direccion"]).TrimEnd(' ') : "";
                if (campo != Globales.cli.direccion)
                {
                    encontrado = true;
                    this.evento += " DIR. ANT.:" + campo + ", DIR. NVO.:" + Globales.cli.direccion + ";";
                }

                campo = rw["Email"] != DBNull.Value ? Convert.ToString(rw["Email"]).TrimEnd(' ') : "";
                if (campo != Globales.cli.email)
                {
                    encontrado = true;
                    this.evento += " EMAIL. ANT.:" + campo + ", EMAIL. NVO.:" + Globales.cli.email + ";";
                }

                campo = rw["Twitter"] != DBNull.Value ? Convert.ToString(rw["Twitter"]).TrimEnd(' ') : "";
                if (campo != Globales.cli.twitter)
                {
                    encontrado = true;
                    this.evento += " TWITT. ANT.:" + campo + ", TWITT. NVO.:" + Globales.cli.twitter + ";";
                }

                campo = rw["Instagram"] != DBNull.Value ? Convert.ToString(rw["Instagram"]).TrimEnd(' ') : "";
                if (campo != Globales.cli.instagram)
                {
                    encontrado = true;
                    this.evento += " INSTGR. ANT.:" + campo + ", INSTGR. NVO.:" + Globales.cli.instagram + ";";
                }




                if (Convert.ToInt32(rw["CodigoPais"]) != Convert.ToInt32(Globales.cli.codigopais))
                {
                    encontrado = true;
                    this.evento += " PAÍS. ANT.:" + string_de_un_campo("SELECT Descripcion FROM Paises WHERE Codigo=" + Convert.ToInt32(rw["CodigoPais"]).ToString().TrimEnd(' ')) + ", PAÍS. NVO.:" + string_de_un_campo("SELECT Descripcion FROM Paises WHERE Codigo=" + Globales.cli.codigopais) + ";";
                }
                if (Convert.ToInt32(rw["CodigoEstado"]) != Convert.ToInt32(Globales.cli.codigoestado))
                {
                    encontrado = true;
                    this.evento += " EDO. ANT.:" + string_de_un_campo("SELECT Descripcion FROM Estados WHERE Codigo=" + Convert.ToInt32(rw["CodigoEstado"]).ToString().TrimEnd(' ')) + ", EDO. NVO.:" + string_de_un_campo("SELECT Descripcion FROM Estados WHERE Codigo=" + Globales.cli.codigoestado) + ";";
                }
                if (Convert.ToInt32(rw["CodigoCiudad"]) != Convert.ToInt32(Globales.cli.codigociudad))
                {
                    encontrado = true;
                    this.evento += " CIU. ANT.:" + string_de_un_campo("SELECT Descripcion FROM Ciudades WHERE Codigo=" + Convert.ToInt32(rw["CodigoCiudad"]).ToString().TrimEnd(' ')) + ", CIU. NVA.:" + string_de_un_campo("SELECT Descripcion FROM Ciudades WHERE Codigo=" + Globales.cli.codigociudad) + ";";
                }
                if (Convert.ToInt32(rw["CodigoProfesion"]) != Convert.ToInt32(Globales.cli.codigoprofesion))
                {
                    encontrado = true;
                    this.evento += " PROF. ANT.:" + string_de_un_campo("SELECT Descripcion FROM Profesiones WHERE Codigo=" + Convert.ToInt32(rw["CodigoProfesion"]).ToString().TrimEnd(' ')) + ", PROF. NVA.:" + string_de_un_campo("SELECT Descripcion FROM Profesiones WHERE Codigo=" + Globales.cli.codigoprofesion) + ";";
                }

                campo = rw["Telefono1"] != DBNull.Value ? Convert.ToString(rw["Telefono1"]).TrimEnd(' ') : "";
                if (campo != Globales.cli.tlf1)
                {
                    encontrado = true;
                    this.evento += " TLF. ANT.:" + campo + ", TLF. NVO.:" + Globales.cli.tlf1 + ";";
                }
                campo = rw["Telefono2"] != DBNull.Value ? Convert.ToString(rw["Telefono2"]).TrimEnd(' ') : "";
                if (campo != Globales.cli.tlf2)
                {
                    encontrado = true;
                    this.evento += " TLF2. ANT.:" + campo + ", TLF2. NVO.:" + Globales.cli.tlf2 + ";";
                }

                campo = rw["Telefono3"] != DBNull.Value ? Convert.ToString(rw["Telefono3"]).TrimEnd(' ') : "";
                if (campo != Globales.cli.tlf3)
                {
                    encontrado = true;
                    this.evento += " TLF3. ANT.:" + campo + ", TLF3. NVO.:" + Globales.cli.tlf3 + ";";
                }
                
            }

            this.evento = this.evento.Remove(this.evento.Length - 1);
            this.evento += ")";
            return encontrado;

        }
        #endregion



        #endregion







        public void registrar_suceso()
        {
            Globales.BD.conectar();
            SqlCommand cmd = new SqlCommand("InsertarSuceso", Globales.BD.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Fecha", SqlDbType.DateTime2);
            cmd.Parameters.Add("@Usuario", SqlDbType.Char, 50);
            cmd.Parameters.Add("@Contrato", SqlDbType.Char, 50);
            cmd.Parameters.Add("@Evento", SqlDbType.Char, 700);
            cmd.Parameters.Add("@Host", SqlDbType.Char, 50);
            cmd.Parameters["@Fecha"].Value = DateTime.Now;
            cmd.Parameters["@Usuario"].Value = Globales.usr.nick;
            cmd.Parameters["@Contrato"].Value = contrato;
            cmd.Parameters["@Evento"].Value = evento;
            cmd.Parameters["@Host"].Value = Convert.ToString(Dns.GetHostName());
            cmd.ExecuteNonQuery();
            Globales.BD.cerrar();

        }

        /*
         
   
   
   
   lCmd.Parameters.Append lCmd.CreateParameter("@CreadoPor", adVarChar, adParamInput, 50, gUsuarioActual) '---
   lCmd.Parameters.Append lCmd.CreateParameter("@TablaPuntos", adInteger, adParamInput, , cmbDbTablaPuntos.BoundText)
   lCmd.Parameters.Append lCmd.CreateParameter("@ObservacionesHostess", adVarChar, adParamInput, 150, UCase(txtObservacionesHostess.text))
   ''cambio para agregar identificador de nueva temporada
   
   ''If (cmbAños.Text = 10 Or cmbAños.Text = 5) And (FechaContrato.value >= CDate("01/07/2013")) And (lEsNuevaTemporada = True) Then
   lCmd.Parameters.Append lCmd.CreateParameter("@NuevaTemporada", adVarChar, adParamInput, 2, lblTemporada.Caption)
   lCmd.Parameters.Append lCmd.CreateParameter("@PrimeraCuotaMantenimiento", adInteger, adParamInput, , ChPrimeraCuotaMantenimiento.value)
   
   lCmd.Parameters.Append lCmd.CreateParameter("@CodigoGerenteSala", adVarChar, adParamInput, 10, gCodigoGerenteSala)
   lCmd.Parameters.Append lCmd.CreateParameter("@CodigoGerenteCalle", adVarChar, adParamInput, 10, gCodigoGerenteCalle)
   lCmd.Parameters.Append lCmd.CreateParameter("@CodigoAsistenteCalle", adVarChar, adParamInput, 10, gCodigoAsistenteCalle)
   
   ''para descuento a partir del 01/01/2015*****************************************************************************************
   lCmd.Parameters.Append lCmd.CreateParameter("@CodigoDescuento", adVarChar, adParamInput, 10, cmbDbDescuentos.BoundText)
   ''*******************************************************************************************************************************
   lCmd.Parameters.Append lCmd.CreateParameter("@TC", adCurrency, adParamInput, , Replace(txtTC.text, ".", ","))
   lCmd.Parameters.Append lCmd.CreateParameter("@Fusion", adInteger, adParamInput, , chkFusion.value)
   lCmd.Parameters.Append lCmd.CreateParameter("@pContado", adInteger, adParamInput, , chkCarta.value)
             
         
         */


    }
}
