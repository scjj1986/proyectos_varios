using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contratos
{
    public partial class frmReporteResCon : Form
    {
        public frmReporteResCon()
        {
            InitializeComponent();
        }

        public string loficinas = "";
        public string ldescoficinas = "";
        public string lppf = "";
        public string lpvb;
        public string txtSQL;

        private void frmReporteResCon_Load(object sender, EventArgs e)
        {
            rdReservas.Checked = true;
            txtSQL = "Select * from Oficinas order by Descripcion";
            cargar_clbOficina();
        }

        public void cargar_clbOficina()
        {

            Globales.BD.dtt = Globales.BD.generar_datatable(txtSQL, CommandType.Text, new List<Clases.Parameters>());
            clbOficinas.DataSource = Globales.BD.dtt;
            clbOficinas.ValueMember = "Codigo";
            clbOficinas.DisplayMember = "Descripcion";

            
        }

        public void preparar_strings_oficinas(){

            foreach (DataRowView item in clbOficinas.CheckedItems)
            {

                loficinas += "'" + item.Row.ItemArray[0] + "',";
                ldescoficinas += "'" + item.Row.ItemArray[1] + "', ";
            }

            loficinas = loficinas.Remove(loficinas.Length - 1);
            ldescoficinas = ldescoficinas.Remove(ldescoficinas.Length - 2);

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (dtpFechaDesde.Value == null || dtpFechaDesde.Value == null)
            {
                MessageBox.Show("Las fechas no deben estar vacías", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (dtpFechaDesde.Value > dtpFechaHasta.Value)
            {
                MessageBox.Show("La fecha inicial no puede ser mayor que la fecha final", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (clbOficinas.CheckedItems.Count == 0)
            {

                MessageBox.Show("Debe seleccionar por lo menos una oficina", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            preparar_strings_oficinas();


            if (!chkPPF.Checked)
            {
                lppf = " And CodigoCobrador <> 'PPF' ";
            }

            if (!chkPVB.Checked)
            {
                lpvb = " And CodigoCobrador <> 'PVB' ";
            }



            if (rdReservas.Checked)
            {
                txtSQL = "select * From V_Contratos Where SUBSTRING(Estatus,1,7) IN ('RESERVA','CONVERT')  AND FechaCREACION between '" + Globales.yyyy_mm_dd(Convert.ToDateTime(dtpFechaDesde.Value)) + "' and '" + Globales.yyyy_mm_dd(Convert.ToDateTime(dtpFechaHasta.Value)) + "' AND  Estado IN ('ACTIVO','CONVERTIDO') " + lppf + lpvb + " ORDER BY FechaCreacion";
            }
            else
            {
                txtSQL = "select * From V_Contratos Where SUBSTRING(Estatus,1,7) IN ('PENDING','PROCESA') AND FechaCREACION between '" + Globales.yyyy_mm_dd(Convert.ToDateTime(dtpFechaDesde.Value)) + "' and '" + Globales.yyyy_mm_dd(Convert.ToDateTime(dtpFechaHasta.Value)) + "' AND  Estado = 'ACTIVO' " + lppf + lpvb + " And CodigoOficina in (" + loficinas + ") ORDER BY FechaCreacion";
            }






            


        }
    }
}
