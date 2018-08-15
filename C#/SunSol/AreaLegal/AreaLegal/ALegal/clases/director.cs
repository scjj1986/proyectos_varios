using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ALegal;
using System.ComponentModel;
using System.Text;

namespace ALegal
{
    public class director
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

        public string acciones { get; set; }

        public double valornominal { get; set; }

        public double aportebs { get; set; }

        public double porcaporte { get; set; }

        public double porcacc { get; set; }
    }
}
