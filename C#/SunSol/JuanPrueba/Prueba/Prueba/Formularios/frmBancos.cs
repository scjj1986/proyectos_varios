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
    public partial class frmBancos : Form
    {

        public string accion;
        public frmBancos()
        {
            InitializeComponent();
        }

        #region método para carga del datagrid
        public void cargar_dgrBancos()
        {
            dgBancos.DataSource = null;
            string txtSQL = "Select Codigo,Descripcion, CASE Activo WHEN 1 THEN 'SI' ELSE 'NO' END AS Activo from Bancos order by Codigo";
            Globales.BD.dtt = Globales.BD.generar_datatable(txtSQL, CommandType.Text, new List<Clases.Parameters>());
            dgBancos.DataSource = Globales.BD.dtt;
        }

        #endregion

        #region método para bloquear/desbloquear form

        public void habilitarform(bool param)
        {

            txtNombre.Enabled = param;
            chkActivo.Enabled = param;
        }

        #endregion

        #region método para limpiar el form

        public void limpiarform()
        {

            txtNombre.Text = "";
            chkActivo.Checked = false;
            txtCodigo.Text = "";
        }

        #endregion

        #region evento carga de la página

        private void frmBancos_Load(object sender, EventArgs e)
        {
            habilitarform(false);
            cargar_dgrBancos();

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

        #region evento click botón Guardar (inserción y modificación)

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (txtNombre.Text == "")
            {
                MessageBox.Show("Campo descripción obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                string act = chkActivo.Checked ? "1" : "0";
                string txtSQL = "";
                if (accion == "INSERTAR")
                {

                    txtSQL = "SELECT * FROM Bancos WHERE Descripcion='" + txtNombre.Text.ToUpper() + "'";

                    if (Globales.BD.nregistros(txtSQL)>0)
                    {
                        MessageBox.Show("Existe un banco con ese nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        txtSQL = "INSERT INTO BANCOS (Descripcion,Activo) VALUES ('" + txtNombre.Text.ToUpper() + "'," + act + ")";
                        Globales.BD.ejecutar_consulta(txtSQL, CommandType.Text, new List<Clases.Parameters>());
                        MessageBox.Show("Datos guardados satisfactoriamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargar_dgrBancos();
                        limpiarform();
                    }
                }
                else
                {
                    txtSQL = "SELECT * FROM Bancos WHERE Descripcion='" + txtNombre.Text.ToUpper() + "' and codigo<>"+txtCodigo.Text;

                    if (Globales.BD.nregistros(txtSQL) > 0)
                    {
                        MessageBox.Show("Existe otro banco con ese nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        txtSQL = "UPDATE BANCOS SET Descripcion='" + txtNombre.Text.ToUpper() + "',Activo=" + act + " WHERE codigo=" + txtCodigo.Text;
                        Globales.BD.ejecutar_consulta(txtSQL, CommandType.Text, new List<Clases.Parameters>());
                        MessageBox.Show("Datos modificados satisfactoriamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargar_dgrBancos();
                    }  
                }
            }
        }

        #endregion

        #region evento dobleclick a una fila del datagrid (Editar)

        private void dgBancos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtCodigo.Text = dgBancos.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtNombre.Text = dgBancos.Rows[e.RowIndex].Cells[1].Value.ToString();
            chkActivo.Checked = dgBancos.Rows[e.RowIndex].Cells[2].Value.ToString()=="SI"?true:false;
            accion = "EDITAR";
            btnGuardar.Text = "Actualizar";
            habilitarform(true);
        }

        #endregion
    }
}
