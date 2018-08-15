using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Contratos
{
    public partial class frmSeleccionarEmpresa : Form
    {
        public frmSeleccionarEmpresa()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection();

        LEmpresa lemp = new LEmpresa();
        Empresa nodo = new Empresa();


        #region procedimiento para cargar el archivo "Empresas.txt" y copiarlos en un combobox y en un objeto
        public void cargar_cmbEmpresa()
        {

            int counter = 1;
            string line;
            cmbEmpresa.Items.Clear();
            System.IO.StreamReader file = new System.IO.StreamReader("Empresas.txt");
            while ((line = file.ReadLine()) != null)
            {
                if (counter == 1)
                {
                    nodo = new Empresa();
                    nodo.nombre = line;
                }
                else if (counter == 2)
                {
                    nodo.conexion = line;
                }
                else
                {
                    nodo.codigo = line;
                    lemp.insertar(nodo);
                    counter = 0;
                    cmbEmpresa.Items.Add(nodo.nombre);
                }
                counter++;
            }
            cmbEmpresa.SelectedIndex = 0;
            file.Close();
        }

        #endregion
        private void frmSeleccionarEmpresa_Load(object sender, EventArgs e)
        {
            this.cargar_cmbEmpresa();
        }

        

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            frmLogin frmlgn = new frmLogin();
            this.itemempresaselected();
            frmlgn.ShowDialog();
            /*
            if (frmlgn.DialogResult == DialogResult.OK)
            {
                frmSeleccionarEmpresa frmse = new frmSeleccionarEmpresa();
                frmse.Show();
                this.Close();
            }*/
        }
        #region Procedimiento para guardar los datos de la empresa seleccionada en el combobox
        public void itemempresaselected() {

            int i = 0;
            Empresa aux = lemp.l;

            while (aux != null)
            {

                if (i == cmbEmpresa.SelectedIndex) {

                    Globales.emp = aux;
                
                }
                i++;
                aux = aux.sig;
            }

                   
        }

        #endregion

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
