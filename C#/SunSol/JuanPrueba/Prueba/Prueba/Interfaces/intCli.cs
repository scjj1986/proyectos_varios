using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Contratos
{
    public interface intCli
    {
        void cargarDatosCliente(DataRow rw);

        void cargar_dtgrContratos(int posic);

        void getindexclibyid(string idc);
    }
}
