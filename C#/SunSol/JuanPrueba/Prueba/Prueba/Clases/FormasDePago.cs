using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contratos.Clases
{
    public class FormasDePago
    {

        public string nrocontrato;
        public string codFDP;
        public string monto;
        public int tpago;
        public string fvenc;
        public string nrdoc;
        public string codban;
        public string estatus;
        
        public FormasDePago(DataGridViewRow rw,int tp,string estts,string nctto)
        {
            
            codFDP = Convert.ToString(rw.Cells[1].Value);
            monto = Convert.ToString(rw.Cells[5].Value);
            tpago = tp;
            fvenc = Convert.ToString(rw.Cells[6].Value);
            nrdoc = Convert.ToString(rw.Cells[4].Value);
            codban = Convert.ToString(rw.Cells[3].Value);
            estatus = estts;
            nrocontrato = nctto;
            
            
        }

        public void guardarformapagocontrato()
        {
            List<Parameters> Parametros = new List<Parameters>();
            Parametros.Add(new Parameters { nameValue = "@NroContrato", Valor = nrocontrato });
            Parametros.Add(new Parameters { nameValue = "@CodigoFP", Valor = Convert.ToInt32(codFDP) });
            Parametros.Add(new Parameters { nameValue = "@TipoPago", Valor = Convert.ToInt32(tpago)});
            Parametros.Add(new Parameters { nameValue = "@Monto", Valor = Globales.txt_a_double(monto) });
            Parametros.Add(new Parameters { nameValue = "@Vencimiento", Valor = Globales.str_a_fecha(fvenc) });
            Parametros.Add(new Parameters { nameValue = "@NroDocumento", Valor = nrdoc });
            Parametros.Add(new Parameters { nameValue = "@CodigoBanco", Valor = Convert.ToInt32(codban) });
            Parametros.Add(new Parameters { nameValue = "@Estatus", Valor = estatus });
            Globales.BD.ejecutar_consulta("Insertar_FormaPagoContrato", CommandType.StoredProcedure, Parametros);
            
        } 
    }
}
