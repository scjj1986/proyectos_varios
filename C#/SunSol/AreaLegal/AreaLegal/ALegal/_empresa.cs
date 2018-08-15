namespace ALegal
{

    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using ALegal;
    using System.ComponentModel;
    using System.Text;
    using System.Security.Cryptography;
    public class _empresa
    {
        public basededatos bd = new basededatos();
        public int id { get; set; }

        public string nombre { get; set; }

        public string tiporif { get; set; }

        public string rif { get; set; }

        public string rifcompleto { get; set; }

        public Double cap_actual { get; set; }

        public string ueea { get; set; }

        public DateTime fecha_rm { get; set; }

        public string nr_rm { get; set; }

        public string tomo_rm { get; set; }

        public string dom_fisc { get; set; }

        public string sucursal { get; set; }

        public string ag_com { get; set; }

        public void guardar_editar()
        {
            bd = new basededatos();
            List<parametros> lparams = new List<parametros>();
            lparams.Add(new parametros { nombre = "@id", Valor = id });
            lparams.Add(new parametros { nombre = "@nom", Valor = nombre });
            lparams.Add(new parametros { nombre = "@trif", Valor = tiporif });
            lparams.Add(new parametros { nombre = "@rif", Valor = rif });
            lparams.Add(new parametros { nombre = "@capactual", Valor = cap_actual });
            lparams.Add(new parametros { nombre = "@ueea", Valor = ueea });
            lparams.Add(new parametros { nombre = "@fecharm", Valor = fecha_rm });
            lparams.Add(new parametros { nombre = "@nrrm", Valor = nr_rm });
            lparams.Add(new parametros { nombre = "@tomorm", Valor = tomo_rm });
            lparams.Add(new parametros { nombre = "@domfisc", Valor = dom_fisc });
            lparams.Add(new parametros { nombre = "@suc", Valor = sucursal });
            lparams.Add(new parametros { nombre = "@agcom", Valor = ag_com });
            bd.ejecutar_consulta("sp_guardareditar_Empresa", CommandType.StoredProcedure, lparams);
        }

        public bool existe_rif()
        {
            bd = new basededatos();
            List<parametros> lparams = new List<parametros>();
            lparams.Add(new parametros { nombre = "@trif", Valor = tiporif });
            lparams.Add(new parametros { nombre = "@rif", Valor = rif });
            lparams.Add(new parametros { nombre = "@id", Valor = id });
            DataTable resultado = bd.generar_datatable("_sp_existeRif_Empresa", CommandType.StoredProcedure, lparams);
            return resultado.Rows.Count == 0 ? false : true;
        }

        public bool existe_nombre()
        {
            bd = new basededatos();
            List<parametros> lparams = new List<parametros>();
            lparams.Add(new parametros { nombre = "@nom", Valor = nombre });
            lparams.Add(new parametros { nombre = "@id", Valor = id });
            DataTable resultado = bd.generar_datatable("_sp_existeNombre_Empresa", CommandType.StoredProcedure, lparams);
            return resultado.Rows.Count == 0 ? false : true;
        }
    }
}
