using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contratos.Clases
{
    public class Impresora
    {
        public string descripcion;
        public Impresora sig;

        public Impresora()
        {
            this.descripcion = "";
            this.sig = null;

        }
    }
}
