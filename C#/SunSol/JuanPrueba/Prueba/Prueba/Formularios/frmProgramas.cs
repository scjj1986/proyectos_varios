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
    public partial class frmProgramas : Form
    {

        public string accion;
        public frmProgramas()
        {
            InitializeComponent();
        }

        #region método para carga del datagrid
        public void cargar_dgrProgramas()
        {
            dgProgramas.DataSource = null;
            string txtSQL = "Select Codigo,Descripcion from Programas order by Codigo";
            Globales.BD.dtt = Globales.BD.generar_datatable(txtSQL, CommandType.Text, new List<Clases.Parameters>());
            dgProgramas.DataSource = Globales.BD.dtt;
        }

        #endregion

        #region método para bloquear/desbloquear form

        public void habilitarform(bool param)
        {

            txtNombre.Enabled = param;
        }

        #endregion

        #region método para limpiar el form

        public void limpiarform()
        {

            txtNombre.Text = "";
            txtCodigo.Text = "";
        }

        #endregion

        #region evento click botón Nuevo (inserción)

        private void btnNuevo_Click(object sender, EventArgs e)
        {

            habilitarform(true);
            limpiarform();
            accion = "INSERTAR";
            btnGuardar.Text = "Guardar";

        }

        #endregion

        #region evento carga de la página

        private void frmProgramas_Load(object sender, EventArgs e)
        {
            habilitarform(false);
            cargar_dgrProgramas();
        }

        #endregion

        #region evento dobleclick de una fila del datagrid (editar)
        private void dgProgramas_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtCodigo.Text = dgProgramas.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtNombre.Text = dgProgramas.Rows[e.RowIndex].Cells[1].Value.ToString();
            accion = "EDITAR";
            btnGuardar.Text = "Actualizar";
            habilitarform(true);
        }

        #endregion

        #region evento click botón Guardar (inserción y modificación)

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                MessageBox.Show("Campo descripción obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string txtSQL = "";
                if (accion == "INSERTAR")
                {
                    txtSQL = "SELECT * FROM Programas WHERE Descripcion='" + txtNombre.Text.ToUpper() + "'";
                    if (Globales.BD.nregistros(txtSQL) > 0)
                    {
                        MessageBox.Show("Existe un programa con ese nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        txtSQL = "INSERT INTO Programas (Descripcion) VALUES ('" + txtNombre.Text.ToUpper() + "')";
                        Globales.BD.ejecutar_consulta(txtSQL, CommandType.Text, new List<Clases.Parameters>());
                        MessageBox.Show("Datos guardados satisfactoriamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargar_dgrProgramas();
                        limpiarform();
                    }
                }
                else
                {
                    txtSQL = "SELECT * FROM Programas WHERE Descripcion='" + txtNombre.Text.ToUpper() + "' and codigo<>" + txtCodigo.Text;
                    if (Globales.BD.nregistros(txtSQL) > 0)
                    {
                        MessageBox.Show("Existe otro programa con ese nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        txtSQL = "UPDATE Programas SET Descripcion='" + txtNombre.Text.ToUpper() + "' WHERE codigo=" + txtCodigo.Text;
                        Globales.BD.ejecutar_consulta(txtSQL, CommandType.Text, new List<Clases.Parameters>());
                        MessageBox.Show("Datos modificados satisfactoriamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargar_dgrProgramas();
                    }
                }
            }
        }

        #endregion

        
    }
}
