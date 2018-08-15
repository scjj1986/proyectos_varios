using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Net;
//using System.DateTime;
using System.Windows.Forms;

namespace Contratos.Clases
{
    public class Cliente
    {

        public string idcliente;
        public string nac;
        public string cedulapas;
        public string rif;
        public string nombres;
        public string apellidos;
        public string direccion;
        public string email;
        public string twitter;
        public string instagram;
        public DateTime fnac;
        public string codigopais;
        public string codigoestado;
        public string codigociudad;
        public string codigoprofesion;
        public string tlf1;
        public string tlf2;
        public string tlf3;
        public string nck;

        #region inserción y modificación de clientes
        public void registrar_cliente()
        {

            List<Parameters> Parametros = new List<Parameters>();
            Parametros.Add(new Parameters { nameValue = "@cedula_rif", Valor = cedulapas });
            Parametros.Add(new Parameters { nameValue = "@nombres", Valor = nombres });
            Parametros.Add(new Parameters { nameValue = "@apellidos", Valor = apellidos });
            Parametros.Add(new Parameters { nameValue = "@Direccion", Valor = direccion });
            Parametros.Add(new Parameters { nameValue = "@Email", Valor = email });
            Parametros.Add(new Parameters { nameValue = "@Telefono1", Valor = tlf1 });
            Parametros.Add(new Parameters { nameValue = "@Telefono2", Valor = tlf2 });
            Parametros.Add(new Parameters { nameValue = "@Telefono3", Valor = tlf3 });
            Parametros.Add(new Parameters { nameValue = "@FechaNacimiento", Valor = fnac });
            Parametros.Add(new Parameters { nameValue = "@Agregado_Por", Valor = Globales.usr.nick });
            Parametros.Add(new Parameters { nameValue = "@CodigoPais", Valor = Convert.ToInt32(codigopais) });
            Parametros.Add(new Parameters { nameValue = "@CodigoEstado", Valor = Convert.ToInt32(codigoestado) });
            Parametros.Add(new Parameters { nameValue = "@CodigoCiudad", Valor = Convert.ToInt32(codigociudad) });
            Parametros.Add(new Parameters { nameValue = "@CodigoOcupacion", Valor = 5 });
            Parametros.Add(new Parameters { nameValue = "@CodigoProfesion", Valor = Convert.ToInt32(codigoprofesion) });
            Parametros.Add(new Parameters { nameValue = "@ZonaPostal", Valor = "0101" });
            Parametros.Add(new Parameters { nameValue = "@CodigoOficina", Valor = Convert.ToInt32(Globales.gCodigoOficina) });
            Parametros.Add(new Parameters { nameValue = "@Nacionalidad", Valor = nac });
            Parametros.Add(new Parameters { nameValue = "@RIF", Valor = rif });
            Parametros.Add(new Parameters { nameValue = "@Twitter", Valor = twitter });
            Parametros.Add(new Parameters { nameValue = "@Instagram", Valor = instagram });

            Globales.BD.ejecutar_consulta("Insertar_Cliente",CommandType.StoredProcedure,Parametros);

        }

        public void modificar_cliente()
        {

            List<Parameters> Parametros = new List<Parameters>();
            Parametros.Add(new Parameters { nameValue = "@cedula_rif", Valor = cedulapas });
            Parametros.Add(new Parameters { nameValue = "@nombres", Valor = nombres });
            Parametros.Add(new Parameters { nameValue = "@apellidos", Valor = apellidos });
            Parametros.Add(new Parameters { nameValue = "@Direccion", Valor = direccion });
            Parametros.Add(new Parameters { nameValue = "@Email", Valor = email });
            Parametros.Add(new Parameters { nameValue = "@Telefono1", Valor = tlf1 });
            Parametros.Add(new Parameters { nameValue = "@Telefono2", Valor = tlf2 });
            Parametros.Add(new Parameters { nameValue = "@Telefono3", Valor = tlf3 });
            Parametros.Add(new Parameters { nameValue = "@FechaNacimiento", Valor = fnac });
            Parametros.Add(new Parameters { nameValue = "@Modificado_Por", Valor = Globales.usr.nick });
            Parametros.Add(new Parameters { nameValue = "@CodigoPais", Valor = Convert.ToInt32(codigopais) });
            Parametros.Add(new Parameters { nameValue = "@id", Valor = Convert.ToInt32(idcliente) });
            Parametros.Add(new Parameters { nameValue = "@CodigoEstado", Valor = Convert.ToInt32(codigoestado) });
            Parametros.Add(new Parameters { nameValue = "@CodigoCiudad", Valor = Convert.ToInt32(codigociudad) });
            Parametros.Add(new Parameters { nameValue = "@CodigoOcupacion", Valor = 5 });
            Parametros.Add(new Parameters { nameValue = "@CodigoProfesion", Valor = Convert.ToInt32(codigoprofesion) });
            Parametros.Add(new Parameters { nameValue = "@ZonaPostal", Valor = "0101" });
            Parametros.Add(new Parameters { nameValue = "@CodigoOficina", Valor = Convert.ToInt32(Globales.gCodigoOficina) });
            Parametros.Add(new Parameters { nameValue = "@Nacionalidad", Valor = nac });
            Parametros.Add(new Parameters { nameValue = "@RIF", Valor = rif });
            Parametros.Add(new Parameters { nameValue = "@Twitter", Valor = twitter });
            Parametros.Add(new Parameters { nameValue = "@Instagram", Valor = instagram });

            Globales.BD.ejecutar_consulta("Modificar_Cliente", CommandType.StoredProcedure, Parametros);

            

            foreach (DataRow rw in Globales.BD.dtt.Rows)
            {
                Globales.BD.ejecutar_consulta("UPDATE Contratos SET Cedula='" + cedulapas + "' WHERE Cedula='" + Convert.ToString(rw["cedula_rif"]).TrimEnd(' ') + "'",CommandType.Text,new List<Parameters>());
                Globales.BD.ejecutar_consulta("UPDATE RelacionPuntosPorAnio SET Cedula='" + cedulapas + "' WHERE Cedula='" + Convert.ToString(rw["cedula_rif"]).TrimEnd(' ') + "'", CommandType.Text, new List<Parameters>());
                Globales.BD.ejecutar_consulta("UPDATE Domiciliaciones SET Cedula='" + cedulapas + "' WHERE Cedula='" + Convert.ToString(rw["cedula_rif"]).TrimEnd(' ') + "'", CommandType.Text, new List<Parameters>());
                Globales.BD.ejecutar_consulta("UPDATE Giros SET Cedula='" + cedulapas + "' WHERE Cedula='" + Convert.ToString(rw["cedula_rif"]).TrimEnd(' ') + "'", CommandType.Text, new List<Parameters>());
            }



        }

        #endregion

    }
}
