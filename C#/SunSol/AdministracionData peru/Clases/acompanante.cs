using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    class acompanante
    {

        public int id_acompanante { get; set; }
        public Nullable<int> id_td { get; set; }
        public string documento_identidad { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string telefono { get; set; }        
        public Nullable<int> id_status { get; set; }        
        public string correo { get; set; }
        public string profesion { get; set; }
        public Nullable<int> id_cliente { get; set; }
       
    }
}
