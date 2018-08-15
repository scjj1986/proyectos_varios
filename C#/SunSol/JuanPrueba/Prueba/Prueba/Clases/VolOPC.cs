using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;using System.Data.SqlClient;

namespace Contratos
{
    public class VolOPC
    {

        public string codigo { get; set; }
        public string nombre { get; set; }

        public int q { get; set; }

        public int nq { get; set; }

        public int nt { get; set; }

        public int total { get; set; }

        public int procs { get; set; }

        public int pend { get; set; }

        public double volumen { get; set; }



        public List<VolOPC> Listado(SqlDataReader dr)
        {

            List<VolOPC> list = new List<VolOPC>();
            
                while (dr.Read())
                {
                    VolOPC vopc = new VolOPC();
                    vopc.codigo = dr.GetString(0).Trim(new char[] { ' ' });
                    vopc.nombre = dr.GetString(1).Trim(new char[] { ' ' });
                    vopc.q = dr.GetInt32(2);
                    vopc.nq = dr.GetInt32(3);
                    vopc.nt = dr.GetInt32(4);
                    vopc.total = dr.GetInt32(5);
                    vopc.procs = dr.GetInt32(8);
                    vopc.pend = dr.GetInt32(9);
                    vopc.volumen = dr.GetDouble(10);
                    list.Add(vopc);
                }
            

            return list;

        }



    }
}
