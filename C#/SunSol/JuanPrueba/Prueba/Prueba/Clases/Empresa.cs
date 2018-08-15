using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contratos
{
    public class Empresa
    {
        public string nombre;
        public string conexion;
        public string codigo;
        public Empresa sig;

        public Empresa() {

            this.codigo = "";
            this.nombre = "";
            this.conexion = "";
            this.sig = null;
        
        }

    }
}
