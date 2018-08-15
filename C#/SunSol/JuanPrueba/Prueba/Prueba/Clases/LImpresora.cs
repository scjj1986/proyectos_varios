using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Contratos.Clases
{
    public class LImpresora
    {
        public Impresora l;
        public LImpresora() {

            this.l = null;
        
        }

        public void cargar_impresoras()
        {
            foreach (String strPrinter in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {

                Impresora nuevo = new Impresora();
                nuevo.descripcion = strPrinter;
                this.insertar_final(nuevo);
            }


        }

        public void insertar_final(Impresora nuevo)
        {

            if (this.l == null)
            {

                l = nuevo;
            }
            else {

                Impresora aux = l;
                while (aux.sig!=null){

                    aux=aux.sig;
                }
                aux.sig=nuevo;
            }


        }
    }
}
