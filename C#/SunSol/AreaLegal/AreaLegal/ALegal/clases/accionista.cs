using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ALegal;
using System.ComponentModel;
using System.Text;

namespace ALegal
{
    public class accionista
    {
        public int id { get; set; }
        public int id_empresa { get; set; }

        public string tced { get; set; }

        public string cedula { get; set; }

        public string cedulacompleta { get; set; }

        public string trif { get; set; }

        public string rif { get; set; }

        public string rifcompleto { get; set; }

        public string nombre { get; set; }

        public string duracion { get; set; }

        public string facultades { get; set; }


    }
}
