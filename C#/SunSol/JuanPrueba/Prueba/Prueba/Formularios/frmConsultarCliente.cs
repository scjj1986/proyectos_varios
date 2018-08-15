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
    public partial class frmConsultarCliente : Form
    {

        
        public frmConsultarCliente()
        {
            InitializeComponent();
        }

        public string idc;

        private void frmConsultarCliente_Load(object sender, EventArgs e)
        {
            this.cmbBuscarCliente.Text = "Por Cédula";
        }

        private void btnConsultarCliente_Click(object sender, EventArgs e)
        {
            string txtSQL = "SELECT a.Nombres,a.Apellidos,a.Cedula_Rif AS Cedula, b.NroContrato,a.id FROM Clientes a LEFT JOIN contratos b on a.id=b.id WHERE ";

            if (this.cmbBuscarCliente.Text == "Por Cédula")
                txtSQL += " cedula_Rif like '%" + txtArgumento.Text + "%'";
            else if (this.cmbBuscarCliente.Text == "Por N. Contrato")
                txtSQL += " b.Nrocontrato like '%" + txtArgumento.Text + "%'";
            else if (this.cmbBuscarCliente.Text == "Por Nombre")
                txtSQL += " nombres like '%" + txtArgumento.Text + "%'";
            else
                txtSQL += " apellidos like '%" + txtArgumento.Text + "%'";


            txtSQL += " and a.estado ='ACTIVO' Order by cedula_Rif";
            dtgClientes.DataSource = null;
            if (Globales.BD.nregistros(txtSQL) == 0)
            {

                MessageBox.Show("No hubo coincidencias con los parámetros establecidos", "Finalizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Globales.BD.dtt = Globales.BD.generar_datatable(txtSQL, CommandType.Text, new List<Clases.Parameters>());
                dtgClientes.DataSource = Globales.BD.dtt;

            }

        }

        private void dtgClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
        

        
 

        private void dtgClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            this.idc = dtgClientes.Rows[e.RowIndex].Cells[4].Value.ToString();

            string txtSQL = "SELECT * FROM clientes where id=" + idc;

            if (Globales.BD.nregistros(txtSQL) > 0)
            {

                Globales.BD.dtt = Globales.BD.generar_datatable(txtSQL, CommandType.Text, new List<Clases.Parameters>());
                intCli formInterface = this.Owner as intCli;
                formInterface.getindexclibyid(idc);
                formInterface.cargarDatosCliente(Globales.BD.dtt.Rows[0]);
                formInterface.cargar_dtgrContratos(e.RowIndex);
                
            }
            
        }



        
    }
}
