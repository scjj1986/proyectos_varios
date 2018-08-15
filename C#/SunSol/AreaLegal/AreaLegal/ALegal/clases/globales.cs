using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ALegal;
using System.ComponentModel;
using System.Text;

namespace ALegal
{
    public static class globales
    {

        public static List<_empresa> lemp = new List<_empresa>();
        //public _empresa emp = new _empresa();
        public static int idemp;

        public static List<_empresa> cargar_lemp()
        {
            basededatos bd = new basededatos();
            List<_empresa> l = new List<_empresa>();
            _empresa n;
            DataTable resultado = bd.generar_datatable("SELECT * FROM Empresa", CommandType.Text, new List<parametros>());
            foreach (DataRow rw in resultado.Rows)
            {
                n = new _empresa();
                n.id = Convert.ToInt32(rw["id"]);
                n.nombre = Convert.ToString(rw["nombre"]);
                n.tiporif = Convert.ToString(rw["tiporif"]);
                n.rif = Convert.ToString(rw["rif"]);
                n.rifcompleto = n.tiporif + "-" + n.rif;
                n.cap_actual = Convert.ToDouble(rw["cap_actual"]);
                n.ueea = Convert.ToString(rw["ueea"]);
                n.fecha_rm = Convert.ToDateTime(rw["fecha_rm"]);
                n.nr_rm = Convert.ToString(rw["nr_rm"]);
                n.tomo_rm = Convert.ToString(rw["tomo_rm"]);
                n.dom_fisc = Convert.ToString(rw["dom_fisc"]);
                n.sucursal = Convert.ToString(rw["sucursal"]);
                n.ag_com = Convert.ToString(rw["ag_com"]);
                l.Add(n);
            }
            return l;

        }


        public static double txt_a_double(string txt)
        {

            double nr;
            if (!Double.TryParse(txt.Replace(".", ","), out nr))
                return -1;
            else
                return nr;
        }
    }
}
