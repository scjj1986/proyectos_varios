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
    public partial class frmLocacion : Form
    {
        public frmLocacion()
        {
            InitializeComponent();
        }

        public string accion;


        #region método para carga del datagrid
        public void cargar_dgrLocacion()
        {
            dgLocacion.DataSource = null;
            string txtSQL = "Select Locacion.Codigo,Locacion.Descripcion,Programas.Descripcion AS Programa FROM Locacion LEFT outer JOIN Programas ON Locacion.CodigoProg=Programas.Codigo  order by Locacion.Codigo";
            Globales.BD.dtt = Globales.BD.generar_datatable(txtSQL, CommandType.Text, new List<Clases.Parameters>());
            dgLocacion.DataSource = Globales.BD.dtt;
        }

        #endregion

        #region método para bloquear/desbloquear form

        public void habilitarform(bool param)
        {

            txtNombre.Enabled = param;
            cmbPrograma.Enabled = param;
        }

        #endregion


        #region método para carga del combobox
        public void cargar_cmbLocacion()
        {
            cmbPrograma.DataSource = null;
            string txtSQL = "Select Codigo,Descripcion from Programas order by Codigo";
            Globales.BD.dtt = Globales.BD.generar_datatable(txtSQL, CommandType.Text, new List<Clases.Parameters>());
            cmbPrograma.DataSource = Globales.BD.dtt;
            cmbPrograma.ValueMember = "Codigo";
            cmbPrograma.DisplayMember = "Descripcion";
        }

        #endregion

        #region evento dobleclick de una fila del datagrid (editar)
        private void dgLocacion_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtCodigo.Text = dgLocacion.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtNombre.Text = dgLocacion.Rows[e.RowIndex].Cells[1].Value.ToString();
            cmbPrograma.Text = dgLocacion.Rows[e.RowIndex].Cells[2].Value.ToString();
            accion = "EDITAR";
            btnGuardar.Text = "Actualizar";
            habilitarform(true);
        }

        #endregion

        private void frmLocacion_Load(object sender, EventArgs e)
        {
            cargar_dgrLocacion();
            cargar_cmbLocacion();
            habilitarform(false);
        }

        #region método para limpiar el form

        public void limpiarform()
        {

            txtNombre.Text = "";
            txtCodigo.Text = "";
            cmbPrograma.SelectedIndex = -1;
        }

        #endregion

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                MessageBox.Show("Campo descripción obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cmbPrograma.Text == "" || cmbPrograma.SelectedIndex < 0)
            {
                MessageBox.Show("Código de Programa incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } 
            else
            {
                string txtSQL = "";
                if (accion == "INSERTAR")
                {
                    txtSQL = "SELECT * FROM Locacion WHERE Descripcion='" + txtNombre.Text.ToUpper() + "' AND CodigoProg=" + cmbPrograma.SelectedValue.ToString();
                    if (Globales.BD.nregistros(txtSQL) > 0)
                    {
                        MessageBox.Show("Existe una locación con ese nombre y con el mismo programa", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        txtSQL = "INSERT INTO Locacion (CodigoProg,Descripcion) VALUES ("+cmbPrograma.SelectedValue.ToString()+",'" + txtNombre.Text.ToUpper() + "')";
                        Globales.BD.ejecutar_consulta(txtSQL, CommandType.Text, new List<Clases.Parameters>());
                        MessageBox.Show("Datos guardados satisfactoriamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargar_dgrLocacion();
                        limpiarform();
                    }
                }
                else
                {
                    txtSQL = "SELECT * FROM Locacion WHERE Descripcion='" + txtNombre.Text.ToUpper() + "' AND codigo<>" + txtCodigo.Text + " AND CodigoProg=" + cmbPrograma.SelectedValue.ToString();
                    if (Globales.BD.nregistros(txtSQL) > 0)
                    {
                        MessageBox.Show("Existe otra locacion con ese nombre  y con el mismo programa", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        txtSQL = "UPDATE Locacion SET Descripcion='" + txtNombre.Text.ToUpper() + "',CodigoProg="+cmbPrograma.SelectedValue+" WHERE codigo=" + txtCodigo.Text;
                        Globales.BD.ejecutar_consulta(txtSQL, CommandType.Text, new List<Clases.Parameters>());
                        MessageBox.Show("Datos modificados satisfactoriamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargar_dgrLocacion();
                    }
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            habilitarform(true);
            limpiarform();
            accion = "INSERTAR";
            btnGuardar.Text = "Guardar";
        }
    }
}
