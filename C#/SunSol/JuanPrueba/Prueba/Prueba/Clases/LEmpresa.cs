using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contratos
{
    public class LEmpresa
    {

        public Empresa l;

        public LEmpresa()
        {

            this.l = null;
        }

        public void insertar(Empresa nodo) {

            if (l == null) {

                l = nodo;
            }
            else
            {

                Empresa aux = l;
                while (aux.sig != null) { 
                
                    aux=aux.sig;
                }
                aux.sig = nodo;
            }
        
        }


    }
}
