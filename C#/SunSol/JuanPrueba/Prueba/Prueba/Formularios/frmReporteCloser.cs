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
    public partial class frmReporteCloser : Form
    {
        public frmReporteCloser()
        {
            InitializeComponent();
        }

        private void frmReporteCloser_Load(object sender, EventArgs e)
        {
            string txtSQL = "Select * from Oficinas order by Descripcion";
            cargar_cmbOficina(txtSQL);
        }

        public void cargar_cmbOficina(string txtSQL)
        {
            cmbOficina.DataSource = null;
            Globales.BD.dtt = Globales.BD.generar_datatable(txtSQL, CommandType.Text, new List<Clases.Parameters>());
            cmbOficina.DataSource = Globales.BD.dtt;
            cmbOficina.ValueMember = "Codigo";
            cmbOficina.DisplayMember = "Descripcion";
            if (cmbOficina.Items.Count > 0)
                cmbOficina.SelectedIndex = 0;
        }

    }
}
