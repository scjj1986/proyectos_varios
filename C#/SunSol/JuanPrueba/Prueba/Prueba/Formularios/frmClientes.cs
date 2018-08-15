using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Contratos.Formularios
{
    public partial class frmClientes : Form, intCli
    {
        public frmClientes()
        {
            InitializeComponent();
        }



        public bool load_cmb = false;

        public string evento = "";

        public bool esguardar;
        public bool esmodificar;
        public int lindex;
        public bool lsinfoto;

        public int indexcli = -1;

        public string idcli = "-1";

        public void LoadFormClientes()
        {
            tabControl1.TabIndex = 0;
            btnAgregar.Enabled = true;
            btnAgregar.Text = "Agregar";
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
            btnModificar.Text = "Editar";
            esguardar = false;
            esmodificar = false;
            lindex = 0;
            lsinfoto = false;
            this.deshabilitarformcliente(true);
            this.limpiarformcliente();
            dtgrContratos.DataSource = null;
            dtgAsociados.DataSource = null;
            if (Globales.fVerificarAcceso(Globales.valor_perfil("ContratoReportes")))
            {


            }

            chkConsultarSeniat.Checked = Globales.EsConsultarSeniat == "1" ? true : false;
            chkUsarProxy.Checked = Globales.EsConProxy == "1" ? true : false;

            if (this.AccesoInternet())
            {

                lblSinInternet.Visible = false;
            }

        }

        private void frmClientes_Load(object sender, EventArgs e)
        {

            this.LoadFormClientes();
        }


        #region PESTAÑA CLIENTES

        #region Procedimiento para determinar el index (posición de la tabla 'Clientes' en el DataSet global), a partir de un id pasado por parámetro
        public void getindexclibyid(string idc)
        {

            int i = -1;
            foreach (DataRow pRow in Globales.BD.dsGlobal.Tables["Clientes"].Rows)
            {

                i++;
                if (Convert.ToString(pRow["id"]) == idc)
                {

                    this.indexcli=i;
                }
            }
        }

        #endregion

        #region Procedimiento para bloquear/desbloquear los atributos (botones,textbox,combobox, etc) de la pestaña cliente

        public void deshabilitarformcliente(bool param)
        {

            txtCedula.ReadOnly = param;
            txtRIF.ReadOnly = param;
            txtNombres.ReadOnly = param;
            txtApellidos.ReadOnly = param;
            txtDireccion.ReadOnly = param;
            txtEmail.ReadOnly = param;
            txtTwitter.ReadOnly = param;
            txtInstagram.ReadOnly = param;
            cmbCedPas.Enabled = !param;
            dtpFechaNacimiento.Enabled = !param;
            cmbPais.Enabled = !param;
            cmbEstado.Enabled = !param;
            cmbCiudad.Enabled = !param;
            cmbProfesion.Enabled = !param;
            btnAgregarPais.Enabled = !param;
            btnModificarPais.Enabled = !param;
            btnAgregarEstado.Enabled = !param;
            btnModificarEstado.Enabled = !param;
            btnAgregarCuidad.Enabled = !param;
            btnModificarCuidad.Enabled = !param;
            btnAgregarProfesion.Enabled = !param;
            btnModificarProfesion.Enabled = !param;
            chkConsultarSeniat.Enabled = !param;
            chkUsarProxy.Enabled = !param;
            btnBuscarSeniat.Enabled = !param;
            //btnEdoCta.Enabled = !param;
            txtTlfOficina.ReadOnly = param;
            txtTlfHab.ReadOnly = param;
            txtFax.ReadOnly = param;
        }

        #endregion

        #region Procedimiento para cargar datos del formulario de clientes (Dependiendo de los botones que clique el usuario, sea 1ero, ant., sig y últ)
        public void cargarDatosCliente(DataRow rw)
        {

            this.idcli = Convert.ToString(rw["Id"]);
            Console.WriteLine(Convert.ToString(rw["Nacionalidad"]));
            cmbCedPas.Text = Convert.ToString(rw["Nacionalidad"]).TrimEnd(' ');
            txtCedula.Text = Convert.ToString(rw["cedula_rif"]).TrimEnd(' ');
            txtRIF.Text = rw["rif"] != DBNull.Value ? Convert.ToString(rw["rif"]).TrimEnd(' ') : "";
            txtNombres.Text = Convert.ToString(rw["Nombres"]).TrimEnd(' ');
            txtApellidos.Text = rw["Apellidos"] != DBNull.Value ? Convert.ToString(rw["Apellidos"]).TrimEnd(' ') : "";
            txtDireccion.Text = rw["Direccion"] != DBNull.Value ? Convert.ToString(rw["Direccion"]).TrimEnd(' ') : "";
            txtEmail.Text = rw["Email"] != DBNull.Value ? Convert.ToString(rw["Email"]).TrimEnd(' ') : "";
            txtTwitter.Text = rw["Twitter"] != DBNull.Value ? Convert.ToString(rw["Twitter"]).TrimEnd(' ') : "";
            txtInstagram.Text = rw["Instagram"] != DBNull.Value ? Convert.ToString(rw["Instagram"]).TrimEnd(' ') : "";





            if (rw["FechaNacimiento"] != DBNull.Value)
            {

                dtpFechaNacimiento.Value = Convert.ToDateTime(rw["FechaNacimiento"]);
                dtpFechaNacimiento.Visible = true;
            }
            else
            {

                dtpFechaNacimiento.Visible = false;
            }

            string txtSQL = "Select * from Paises Order By Descripcion";

            this.cargar_cmbPais_Cliente(txtSQL);

            cmbPais.SelectedValue = Convert.ToString(rw["CodigoPais"]);

            txtSQL = "Select * from Estados where CodigoPais=" + Convert.ToString(rw["CodigoPais"]) + " Order By Descripcion";

            this.cargar_cmbEstado_Cliente(txtSQL);

            cmbEstado.SelectedValue = Convert.ToString(rw["CodigoEstado"]);

            txtSQL = "Select * from Ciudades where CodigoEstado=" + Convert.ToString(rw["CodigoEstado"]) + " Order By Descripcion";

            this.cargar_cmbCuidad_Cliente(txtSQL);

            cmbCiudad.SelectedValue = Convert.ToString(rw["CodigoCiudad"]);

            txtSQL = "Select * from Profesiones where Codigo=" + Convert.ToString(rw["CodigoProfesion"]) + " Order By Descripcion";
            this.cargar_cmbProfesion_Cliente(txtSQL);

            txtTlfOficina.Text = rw["Telefono1"] != DBNull.Value ? Convert.ToString(rw["Telefono1"]).TrimEnd(' ') : "";
            txtTlfHab.Text = rw["Telefono2"] != DBNull.Value ? Convert.ToString(rw["Telefono2"]).TrimEnd(' ') : "";
            txtFax.Text = rw["Telefono3"] != DBNull.Value ? Convert.ToString(rw["Telefono3"]).TrimEnd(' ') : "";

            lblPuntosDisponibles.Text = rw["PuntosDisponibles"] != DBNull.Value ? Convert.ToString(Convert.ToInt32(rw["PuntosDisponibles"])) : "0";

            btnModificar.Enabled = true;

            
        }

        #endregion

        #region Procedimiento para inicializar campos del formulario de la pestaña clientes

        public void limpiarformcliente()
        {

            this.indexcli = -1;
            this.idcli = "-1";
            cmbCedPas.Text = "V";
            txtCedula.Text = "";
            txtRIF.Text = "";
            txtNombres.Text = "";
            txtApellidos.Text = "";
            txtDireccion.Text = "";
            txtEmail.Text = "";
            txtTwitter.Text = "";
            txtInstagram.Text = "";
            dtpFechaNacimiento.Value = DateTime.Now;
            dtpFechaNacimiento.Visible = true;
            this.load_cmb = true;
            string txtSQL = "Select * From Paises Order By Descripcion";
            this.cargar_cmbPais_Cliente(txtSQL);
            cmbPais.SelectedValue = 1;
            txtSQL = "Select * From Estados Where CodigoPais=" + cmbPais.SelectedValue.ToString() + " Order By Descripcion";
            this.cargar_cmbEstado_Cliente(txtSQL);
            cmbEstado.SelectedValue = 34; //Estado AMAZONAS
            txtSQL = "Select * From Ciudades Where CodigoEstado=" + cmbEstado.SelectedValue.ToString() + " Order By Descripcion";
            this.cargar_cmbCuidad_Cliente(txtSQL);
            txtSQL = "Select * From Profesiones Order By Descripcion";
            this.cargar_cmbProfesion_Cliente(txtSQL);
            cmbProfesion.SelectedValue = 8;
            this.load_cmb = false;
            txtTlfHab.Text = "";
            txtTlfOficina.Text = "";
            txtFax.Text = "";
            lblPuntosDisponibles.Text = "";

        }


        #endregion

        #region Procedimientos para cargar combobox's país, estado, ciudad y profesión

        public void cargar_cmbPais_Cliente(string txtSQL)
        {
            this.load_cmb = true;
            cmbPais.DataSource = null;

            Globales.BD.dtt = Globales.BD.generar_datatable(txtSQL, CommandType.Text, new List<Clases.Parameters>());
            cmbPais.DataSource = Globales.BD.dtt;
            cmbPais.ValueMember = "Codigo";
            cmbPais.DisplayMember = "Descripcion";
            this.load_cmb = false;
        }

        public void cargar_cmbEstado_Cliente(string txtSQL)
        {
            this.load_cmb = true;
            cmbEstado.DataSource = null;
            Globales.BD.dtt = Globales.BD.generar_datatable(txtSQL, CommandType.Text, new List<Clases.Parameters>());
            cmbEstado.DataSource = Globales.BD.dtt;
            cmbEstado.ValueMember = "Codigo";
            cmbEstado.DisplayMember = "Descripcion";
            cmbEstado.SelectedIndex = 0;
            this.load_cmb = false;
           
        }

        public void cargar_cmbCuidad_Cliente(string txtSQL)
        {
            this.load_cmb = true;
            cmbCiudad.DataSource = null;
            Globales.BD.dtt = Globales.BD.generar_datatable(txtSQL, CommandType.Text, new List<Clases.Parameters>());
            cmbCiudad.DataSource = Globales.BD.dtt;
            cmbCiudad.ValueMember = "Codigo";
            cmbCiudad.DisplayMember = "Descripcion";
            cmbCiudad.SelectedIndex = 0;
            this.load_cmb = false;


        }

        public void cargar_cmbProfesion_Cliente(string txtSQL)
        {
            cmbProfesion.DataSource = null;
            Globales.BD.dtt = Globales.BD.generar_datatable(txtSQL, CommandType.Text, new List<Clases.Parameters>());
            cmbProfesion.DataSource = Globales.BD.dtt;
            cmbProfesion.ValueMember = "Codigo";
            cmbProfesion.DisplayMember = "Descripcion";
            
        }

        #endregion

        #region Eventos para la consulta del primer, anterior, siguiente y último cliente
        private void btn1erCli_Click(object sender, EventArgs e)
        {
            this.indexcli = 0;
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;
            this.esguardar = false;
            this.esmodificar = false;
            DataRow rw = Globales.BD.dsGlobal.Tables["Clientes"].Rows[this.indexcli];
            btnAgregar.Text = "Agregar";
            btnModificar.Text = "Editar";
            this.deshabilitarformcliente(true);
            this.cargarDatosCliente(rw);
            this.cargar_dtgrContratos(0);
        }

        private void btnUltCli_Click(object sender, EventArgs e)
        {
            this.indexcli = Globales.BD.dsGlobal.Tables["Clientes"].Rows.Count - 1;
            DataRow rw = Globales.BD.dsGlobal.Tables["Clientes"].Rows[this.indexcli];

            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;
            this.esguardar = false;
            this.esmodificar = false;
            btnAgregar.Text = "Agregar";
            btnModificar.Text = "Editar";

            this.deshabilitarformcliente(true);
            this.cargarDatosCliente(rw);
            this.cargar_dtgrContratos(0);


        }

        private void btnAntCli_Click(object sender, EventArgs e)
        {
            if (this.indexcli > 0)
            {
                btnModificar.Enabled = true;
                btnEliminar.Enabled = true;
                this.indexcli--;
                DataRow rw = Globales.BD.dsGlobal.Tables["Clientes"].Rows[this.indexcli];
                btnModificar.Enabled = true;
                btnEliminar.Enabled = true;
                this.esguardar = false;
                this.esmodificar = false;
                btnAgregar.Text = "Agregar";
                btnModificar.Text = "Editar";
                this.deshabilitarformcliente(true);
                this.cargarDatosCliente(rw);
                this.cargar_dtgrContratos(0);
            }
        }

        private void btnSigCli_Click(object sender, EventArgs e)
        {

            if (this.indexcli + 1 < Globales.BD.dsGlobal.Tables["Clientes"].Rows.Count)
            {
                this.indexcli++;
                btnModificar.Enabled = true;
                btnEliminar.Enabled = true;
                DataRow rw = Globales.BD.dsGlobal.Tables["Clientes"].Rows[this.indexcli];
                btnModificar.Enabled = true;
                btnEliminar.Enabled = true;
                this.esguardar = false;
                this.esmodificar = false;
                btnAgregar.Text = "Agregar";
                btnModificar.Text = "Editar";
                this.deshabilitarformcliente(true);
                this.cargarDatosCliente(rw);
                this.cargar_dtgrContratos(0);
            }
        }

        #endregion

        #region Evento para el botón Agregar/Guardar (Pestaña Clientes)
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            btnConsultar.Enabled = false;
            if (!Globales.fVerificarAcceso(Globales.valor_perfil("ClientesAgregar")))
                MessageBox.Show("No cuenta con los permisos para realizar esta acción", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {

                this.Text = "";
                this.indexcli = -1;
                this.idcli = "-1";
                if (!esguardar)//Condición para un nuevo cliente (preparar el formulario para la inserción)
                {
                    btnAgregar.Text = "Guardar";
                    this.esguardar = true;
                    dtgrContratos.DataSource = null;

                    this.limpiarformcliente();
                    this.deshabilitarformcliente(false);
                }
                else//Condición para guardar el cliente
                {

                    bool seguir=true;
                    switch (this.validarformcliente())//Validaciones del formulario
                    {

                        case -1: 
                            MessageBox.Show("Campo Cédula vacío", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case -2:
                            MessageBox.Show("Campo Nombres vacío", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        
                        case -4:
                            MessageBox.Show("Debe agregar por lo menos 2 números telefónicos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case 0:

                            if (txtApellidos.Text == "")
                            {
                                var result = MessageBox.Show("¿Desea agregar este cliente sin Apellido?", "Campo Dirección vacío", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (result == DialogResult.No)
                                {
                                    seguir = false;
                                }
                            }
                            if ((seguir) && txtDireccion.Text == "")
                            {
                                var result = MessageBox.Show("¿Desea agregar este cliente sin Dirección?", "Campo Dirección vacío",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                                if (result == DialogResult.No)
                                {
                                    seguir = false;
                                }
                            }
                            if ((seguir) && txtEmail.Text == "")
                            {
                                var result = MessageBox.Show("¿Desea agregar este cliente sin Correo Electrónico?", "Campo Correo Electrónico vacío", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (result == DialogResult.No)
                                {
                                    seguir = false;
                                }

                            }
                            if ((seguir) && txtTwitter.Text == "")
                            {
                                var result = MessageBox.Show("¿Desea agregar este cliente sin Twitter?", "Campo Twitter vacío", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (result == DialogResult.No)
                                {
                                    seguir = false;
                                }

                            }
                            if ((seguir) && txtInstagram.Text == "")
                            {
                                var result = MessageBox.Show("¿Desea agregar este cliente sin Instagram?", "Campo Instagram vacío", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (result == DialogResult.No)
                                {
                                    seguir = false;
                                }

                            }

                            if (seguir)
                            {

                                string txtSQL = "SELECT * FROM Clientes WHERE (Nacionalidad='"+cmbCedPas.Text+"' AND cedula_rif='" + txtCedula.Text + "') OR RIF='" + txtRIF.Text + "'";

                                if (Globales.BD.nregistros(txtSQL) > 0)
                                {
                                    MessageBox.Show("Ya existe un cliente con una cédula y/o RIF", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else {
                                    this.CopiarDataFormCliente();
                                    Globales.cli.registrar_cliente();

                                    //------------------ Bitácora ----------------//
                                    Clases.Bitacora Bit = new Clases.Bitacora("----------","");
                                    Bit.evento = Bit.desc_ins_cli();
                                    Bit.registrar_suceso();
                                    //---------------------------------------------//

                                    
                                    txtSQL = "Select * from Clientes Where Estado ='activo' Order by Nombres";
                                    Globales.BD.eliminartabladsglobal("Clientes");
                                    Globales.BD.llenardsglobal(txtSQL,"Clientes");

                                    MessageBox.Show("Cliente agregado satisfactoriamente", "Finalizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                  
                                    btnAgregar.Text = "Agregar";
                                    this.esguardar = false;
                                    this.limpiarformcliente();
                                    this.deshabilitarformcliente(true);
                                    btnConsultar.Enabled = true;
                                
                                }
                            } 
                            break;


                    }

                }
                
                


            }

        }

        public int validarformcliente()
        {
            if (txtCedula.Text == "")
            {
                return -1;

            }
            else if (txtNombres.Text == "")
            {

                return -2;
            }
            
            else
            {

                int i = 0;

                if (txtTlfHab.Text != "")
                {
                    i++;
                }
                if (txtTlfOficina.Text != "")
                {
                    i++;
                }
                if (txtFax.Text != "")
                {
                    i++;
                }
                if (i<2) return -4;

                return 0;
            }

        }

        #endregion

        #region Evento para el botón Editar/Modificar (Pestaña Clientes)

        private void btnModificar_Click(object sender, EventArgs e)
        {

            if (!Globales.fVerificarAcceso(Globales.valor_perfil("ClientesAgregar")))
                MessageBox.Show("No cuenta con los permisos para realizar esta acción", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (this.idcli != "-1")
            {


                this.btnAgregar.Enabled = false;
                this.btnEliminar.Enabled = false;
                this.btnConsultar.Enabled = false; 
                if (!this.esmodificar)//Cuando se clica el botón con el texto "Editar"
                {

                    this.deshabilitarformcliente(false);
                    this.esmodificar = true;
                    btnModificar.Text = "Modificar";
                }
                else//Cuando hay que modificar el cliente en la base de datos
                {
                    bool seguir = true;
                    switch (this.validarformcliente())//Validaciones del formulario
                    {

                        case -1:
                            MessageBox.Show("Campo Cédula vacío", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case -2:
                            MessageBox.Show("Campo Nombres vacío", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case -4:
                            MessageBox.Show("Debe agregar por lo menos 2 números telefónicos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case 0:
                            if (txtApellidos.Text == "")
                            {
                                var result = MessageBox.Show("¿Desea agregar este cliente sin Apellido?", "Campo Dirección vacío", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (result == DialogResult.No)
                                {
                                    seguir = false;
                                }
                            }
                            if ((seguir) && txtDireccion.Text == "")
                            {
                                var result = MessageBox.Show("¿Desea agregar este cliente sin Dirección?", "Campo Dirección vacío",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                                if (result == DialogResult.No)
                                {
                                    seguir = false;
                                }
                            }
                            if ((seguir) && txtEmail.Text == "")
                            {
                                var result = MessageBox.Show("¿Desea modificar este cliente sin Correo Electrónico?", "Campo Correo Electrónico vacío", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (result == DialogResult.No)
                                {
                                    seguir = false;
                                }

                            }
                            if ((seguir) && txtTwitter.Text == "")
                            {
                                var result = MessageBox.Show("¿Desea modificar este cliente sin Twitter?", "Campo Twitter vacío", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (result == DialogResult.No)
                                {
                                    seguir = false;
                                }

                            }
                            if ((seguir) && txtInstagram.Text == "")
                            {
                                var result = MessageBox.Show("¿Desea modificar este cliente sin Instagram?", "Campo Instagram vacío", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (result == DialogResult.No)
                                {
                                    seguir = false;
                                }

                            }

                            if (seguir)
                            {

                                string txtSQL = "SELECT * FROM Clientes WHERE  (Nacionalidad='" + cmbCedPas.Text + "' AND cedula_rif='" + txtCedula.Text + "' AND id<>" + this.idcli + ") OR (RIF is not null AND RIF<>'' AND RIF='" + txtRIF.Text + "' and id<>" + this.idcli+")";

                                if (Globales.BD.nregistros(txtSQL) > 0)
                                {
                                    MessageBox.Show("Ya existe otro cliente con una cédula y/o RIF igual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    this.CopiarDataFormCliente();

                                    //------------------ Bitácora ----------------//
                                    //Clases.Bitacora Bit = new Clases.Bitacora();
                                    txtSQL = "SELECT * FROM Clientes where id=" + Globales.cli.idcliente;
                                    Globales.BD.dtt = Globales.BD.generar_datatable(txtSQL, CommandType.Text, new List<Clases.Parameters>());

                                    /*
                                    if (Bit.campos_distintos_cliente())
                                    {
                                        Bit.usuario = Globales.usr.nick.ToUpper();
                                        Bit.contrato = "<------>";
                                        Bit.registrar_suceso();
                                    }*/
                                    //---------------------------------------------//

                                    



                                    Globales.cli.modificar_cliente();  
                                    /*string evento = "SE MODIFICÓ EL CLIENTE DE ID = " + this.idcli + ", NOMBRE = " + txtNombres.Text.ToUpper().TrimEnd(' ') + " " + txtApellidos.Text.ToUpper().TrimEnd(' ') + ", CÉDULA/PASAPORTE = " + cmbCedPas.Text + "-" + txtRIF.Text.ToUpper().TrimEnd(' ');
                                    Globales.registrar_suceso(evento);*/
                                    txtSQL = "Select * from Clientes Where Estado ='activo' Order by Nombres";
                                    Globales.BD.eliminartabladsglobal("Clientes");
                                    Globales.BD.llenardsglobal(txtSQL, "Clientes");

                                    txtCedula.Text = txtCedula.Text.ToUpper().TrimEnd(' ');
                                    txtNombres.Text = txtNombres.Text.ToUpper().TrimEnd(' ');
                                    txtApellidos.Text = txtApellidos.Text.ToUpper().TrimEnd(' ');
                                    txtDireccion.Text = txtDireccion.Text.ToUpper().TrimEnd(' ');
                                    MessageBox.Show("Cliente modificado satisfactoriamente", "Finalizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    btnModificar.Text = "Editar";
                                    this.esmodificar = false;
                                    this.deshabilitarformcliente(true);
                                    this.btnAgregar.Enabled = true;
                                    this.btnEliminar.Enabled = true;
                                    this.btnConsultar.Enabled = true; 

                                }


                            }


                            break;


                    }

                }
            }
        }

        #endregion

        private void btnAgregarContrato_Click(object sender, EventArgs e)
        {

            if (!Globales.fVerificarAcceso(Globales.valor_perfil("ContratoAgregar")))
                MessageBox.Show("No tiene permiso para realizar esta acción", "Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (idcli == "-1")
                MessageBox.Show("Debe elegir un cliente", "Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                frmContratos frmc = new frmContratos();
                frmc.Text = "NUEVO CONTRATO PARA " + txtNombres.Text + " " + txtApellidos.Text;
                frmc.accion = "AGREGAR";
                frmc.ShowDialog();
            }
        }

        #region Función que verifica si hay conexion a internet
        public bool AccesoInternet()
        {

            try
            {
                System.Net.IPHostEntry host = System.Net.Dns.GetHostEntry("www.google.com");


                return true;

            }
            catch (Exception es)
            {

                return false;
            }

        }

        #endregion


        private void dtgrContratos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        #region eventos para gestionar llenado de combobox país, estado y cuidad 

        private void cmbPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.load_cmb)
            {
                string txtSQL = "SELECT * FROM Estados WHERE CodigoPais=" + cmbPais.SelectedValue.ToString();
                this.cargar_cmbEstado_Cliente(txtSQL);
                txtSQL = "SELECT * FROM Ciudades WHERE CodigoEstado=" + cmbEstado.SelectedValue.ToString();
                this.cargar_cmbCuidad_Cliente(txtSQL);

            }
        }

        

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (!this.load_cmb)
            {
                string txtSQL = "SELECT * FROM Ciudades WHERE CodigoEstado=" + cmbEstado.SelectedValue.ToString();
                this.cargar_cmbCuidad_Cliente(txtSQL);

            }

        }

        #endregion

        #region Evento para el control cédula (búsqueda de rif)
        private void txtCedula_Leave(object sender, EventArgs e)
        {

            if (this.esguardar && chkConsultarSeniat.Checked)
            {

                if (txtCedula.Text != "")
                {

                    this.BuscarCliente();
                }


            }
            if (this.esguardar && chkConsultarSeniat.Checked)
            {
                lblSinInternet.Visible = false;


            }
        }

        #endregion

        #region funciones y procedimientos para buscar datos de un cliente (pág. web del seniat y Base de Datos)

        //Procedimiento matriz para buscar datos de un cliente (pag web y Base de Datos de ser necesario)
        public void BuscarCliente()
        {
            if (!this.AccesoInternet())
            {
                lblSinInternet.Visible = true;
                this.BuscaClienteBD();
            }
            else//Si hay acceso a internet...
            {
                lblSinInternet.Visible = false;
                string cadced = "http://contribuyente.seniat.gob.ve/getContribuyente/getrif?rif=" + cmbCedPas.Text + txtCedula.Text;
                int i = 0;
                bool encontrado = false;
                while (i <= 9 && !encontrado)//Se empieza la búsqueda del rif (concatenando al final de la cédula del cliente , del 0 al 9)
                {
                    if (BuscaNombreRIF(cadced + Convert.ToString(i)) != "")//Si hay cioncidencia
                    {
                        encontrado = true;
                        XmlDocument xdoc = new XmlDocument();
                        xdoc.LoadXml(BuscaNombreRIF(cadced + Convert.ToString(i)));
                        XmlElement root = xdoc.DocumentElement;
                        if (root.HasAttribute("rif:numeroRif"))
                        {
                            txtRIF.Text = root.GetAttribute("rif:numeroRif");
                        }
                        XmlNodeList personas = xdoc.GetElementsByTagName("rif:Rif");
                        foreach (XmlElement nodo in personas)
                        {
                            txtNombres.Text = nodo.GetElementsByTagName("rif:Nombre")[0].InnerText;//Se lee el xml de la respuesta y se copia el nombre en su campo correspondiente
                        }
                    }
                    i++;
                }
                if (!encontrado)//De no haber coincidencia, se busca en la base de datos
                {

                    this.BuscaClienteBD();
                }

            }
        }


        //Función que devuelve los datos de un cliente (modo xml) en pág. web del seniat, pasando por parámetro su rif
        public static string BuscaNombreRIF(string address)
        {
            
                string strWebPage = "";
           try{
                // create request
                WebRequest objRequest = HttpWebRequest.Create(address);
                // get response
                HttpWebResponse objResponse;
                objResponse = (HttpWebResponse)objRequest.GetResponse();
                // get correct charset and encoding from the server's header
                string Charset = objResponse.CharacterSet;
                Encoding encoding = Encoding.GetEncoding(Charset);

                // read response into memory stream
                MemoryStream memoryStream;
                using (Stream responseStream = objResponse.GetResponseStream())
                {
                    memoryStream = new MemoryStream();

                    byte[] buffer = new byte[1024];
                    int byteCount;
                    do
                    {
                        byteCount = responseStream.Read(buffer, 0, buffer.Length);
                        memoryStream.Write(buffer, 0, byteCount);
                    } while (byteCount > 0);
                }

                // set stream position to beginning
                memoryStream.Seek(0, SeekOrigin.Begin);

                StreamReader sr = new StreamReader(memoryStream, encoding);
                strWebPage = sr.ReadToEnd();

                // Check real charset meta-tag in HTML
                int CharsetStart = strWebPage.IndexOf("charset=");
                if (CharsetStart > 0)
                {
                    CharsetStart += 8;
                    int CharsetEnd = strWebPage.IndexOfAny(new[] { ' ', '\"', ';' }, CharsetStart);
                    string RealCharset =
                           strWebPage.Substring(CharsetStart, CharsetEnd - CharsetStart);

                    // real charset meta-tag in HTML differs from supplied server header???
                    if (RealCharset != Charset)
                    {
                        // get correct encoding
                        Encoding CorrectEncoding = Encoding.GetEncoding(RealCharset);

                        // reset stream position to beginning
                        memoryStream.Seek(0, SeekOrigin.Begin);

                        // reread response stream with the correct encoding
                        StreamReader sr2 = new StreamReader(memoryStream, CorrectEncoding);

                        strWebPage = sr2.ReadToEnd();
                        // Close and clean up the StreamReader
                        sr2.Close();
                    }
                }

                // dispose the first stream reader object
                sr.Close();
            }
            catch (WebException e) {

                return "";
            
            }

            return strWebPage;
        }

        //Procedimiento para buscar datos de un cliente en Base de Datos
        public void BuscaClienteBD()
        {

            string txtSQL = "Select * from Clientes where Cedula_rif='" + txtCedula.Text + "'";
            if (Globales.BD.nregistros(txtSQL) > 0)
            {
                Globales.BD.dtt = Globales.BD.generar_datatable(txtSQL, CommandType.Text, new List<Clases.Parameters>());

                foreach (DataRow pRow in Globales.BD.dtt.Rows)
                {
                    this.cargarDatosCliente(pRow);
                    this.cargar_dtgrContratos(0);
                }

            }
            else if (txtCedula.Text!="")
            {

                txtRIF.Text = cmbCedPas.Text + txtCedula.Text;
            }
        }



        
        #endregion

        #region Procedimiento que copia los datos del formulario de clientes a una clase (inserción y modificación)
        public void CopiarDataFormCliente()
        {

            if (esmodificar)
            {
                Globales.cli.idcliente = this.idcli;

            }
            
            Globales.cli.nac = cmbCedPas.Text.ToUpper();
            Globales.cli.cedulapas = txtCedula.Text.ToUpper();
            Globales.cli.rif = txtRIF.Text.ToUpper();
            Globales.cli.nombres = txtNombres.Text.ToUpper();
            Globales.cli.apellidos = txtApellidos.Text.ToUpper();
            Globales.cli.direccion = txtDireccion.Text.ToUpper();
            Globales.cli.email = txtEmail.Text;
            Globales.cli.twitter = txtTwitter.Text;
            Globales.cli.instagram = txtInstagram.Text;
            Globales.cli.fnac = dtpFechaNacimiento.Value;
            Globales.cli.codigopais = cmbPais.SelectedValue.ToString();
            Globales.cli.codigoestado = cmbEstado.SelectedValue.ToString();
            Globales.cli.codigociudad = cmbCiudad.SelectedValue.ToString();
            Globales.cli.codigoprofesion = cmbProfesion.SelectedValue.ToString();
            Globales.cli.tlf1 = txtTlfOficina.Text;
            Globales.cli.tlf2 = txtTlfHab.Text;
            Globales.cli.tlf3 = txtFax.Text; 
        }

        #endregion

        #region Evento para Generar el Estado de Cuenta de un Cliente específico 

        private void btnEdoCta_Click(object sender, EventArgs e)
        {
            if (this.idcli != "-1")
            {

                string txtSQL = "SELECT * FROM GIROS WHERE CEDULA='" + this.txtCedula.Text +"' And Estatus IN ('PENDIENTE','CANCELADO') ORDER BY NROCONTRATO,FechaCuota";

                if (Globales.BD.nregistros(txtSQL) == 0)
                {

                    MessageBox.Show("Este cliente no posee estado de cuenta", "Finalizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                    frmClienteEdoCta frmec = new frmClienteEdoCta();
                    frmec.Owner = this;
                    frmec.cedcli = this.txtCedula.Text;
                    frmec.nombrecompleto = txtNombres.Text + " " + txtApellidos.Text;
                    frmec.ShowDialog();
                } 

            }
        }


        #endregion

        #region Evento para llamar el formulario para buscar Clientes

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            frmConsultarCliente frmConCli = new frmConsultarCliente();
            frmConCli.ShowDialog(this);
        }

        #endregion

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (!Globales.fVerificarAcceso(Globales.valor_perfil("ClientesEliminar")))
                MessageBox.Show("No posee los permisos para esta acción", "Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {

                var result = MessageBox.Show("¿Seguro que desea ELIMINAR EL CLIENTE " + txtNombres.Text + " " + txtApellidos.Text + "?", "Campo Dirección vacío", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {

                    string txtSQL = "Select nrocontrato from Contratos where Cedula='" + txtCedula.Text + "'";
                    if (Globales.BD.nregistros(txtSQL) > 0)
                    {

                        MessageBox.Show("No se puede eliminar el cliente porque ya tiene al menos un contrato", "Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        txtSQL = "Delete from clientes WHERE cedula_RIF='" + txtCedula.Text + "'";
                        Globales.BD.ejecutar_consulta(txtSQL, CommandType.Text, new List<Clases.Parameters>());
                        MessageBox.Show("Cliente eliminado satisfactoriamente", "Finalizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        string evento = "Se Eliminó el cliente " + txtNombres.Text.TrimEnd(' ') + " " + txtApellidos.Text.TrimEnd(' ') + " Con Cedula: " + cmbCedPas.Text.TrimEnd(' ') + "-" + txtCedula.Text.TrimEnd(' ');

                        Clases.Bitacora bit = new Clases.Bitacora("-------",evento);
                        bit.registrar_suceso();
                        Globales.BD.eliminartabladsglobal("Clientes");
                        Globales.BD.llenardsglobal(txtSQL, "Clientes");
                        this.LoadFormClientes();


                    }
                }



            }

        }

        private void btnResetear_Click(object sender, EventArgs e)
        {
            if (this.esguardar)
            {
                var result = MessageBox.Show("Al inicializar, se cancelará la inserción del cliente, desea continuar?", "Campo Twitter vacío", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    this.LoadFormClientes();
                }

            }
            else if (this.esmodificar)
            {
                var result = MessageBox.Show("Al inicializar, se cancelará la modificación del cliente, desea continuar?", "Campo Twitter vacío", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    this.LoadFormClientes();
                }

            }

        }

        private void btnLista_Click(object sender, EventArgs e)
        {
            frmListadoClientes frmlc = new frmListadoClientes();
            frmlc.ShowDialog();
        }

        #endregion

        private void label22_Click(object sender, EventArgs e)
        {

        }

        #region PESTAÑA CONTRATOS

        #region Procedimiento para cargar dtgrcontratos (Pestaña Contratos), llamada a los procedimientos que cargan dtgrAsociados y la data en la pestaña 'Cobranzas'
        public void cargar_dtgrContratos(int posic)
        {

            dtgrContratos.DataSource = null;
            string txtSQL = "Select * from Contratos where id=" + this.idcli + " order by NroContrato";
            if (Globales.BD.nregistros(txtSQL) > 0)
            {
                Globales.BD.eliminartabladscontratos("Contratos");
                Globales.BD.llenardscontratos(txtSQL, "Contratos");
                dtgrContratos.DataSource = Globales.BD.dsContratos.Tables["Contratos"];
                dtgrContratos.Rows[posic].Selected = true;
                dtgrContratos.CurrentCell = dtgrContratos.Rows[posic].Cells[0];
                this.cargar_dtgrAsociados(dtgrContratos.Rows[posic].Cells[0].Value.ToString());
                this.cargar_cobranzas(dtgrContratos.Rows[posic].Cells[0].Value.ToString());
            }
            this.Text = dtgrContratos.Rows.Count > 0 ? "Módulo Clientes. " + txtNombres.Text + " " + txtApellidos.Text + "(" + dtgrContratos.Rows[posic].Cells[0].Value.ToString() + ")" : "Módulo Clientes. " + txtNombres.Text + " " + txtApellidos.Text;

        }

        #endregion

        #region Evento para elegir una fila del datagrid (Pestaña Contratos)

        private void dtgrContratos_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            this.Text = "Módulo Clientes. " + txtNombres.Text + " " + txtApellidos.Text + "(" + dtgrContratos.Rows[e.RowIndex].Cells[0].Value.ToString() + ")";
            this.cargar_cobranzas(dtgrContratos.Rows[e.RowIndex].Cells[0].Value.ToString());
        }

        #endregion

        #endregion

        #region PESTAÑA CO-PROPIETARIOS

        #region Procedimiento para cargar dtgrAsociados (Pestaña Co-Propietarios)
        public void cargar_dtgrAsociados(string ncontrato)
        {
            dtgAsociados.DataSource = null;
            string txtSQL = "Select Cedula,Nombres,Apellidos,Parentesco,id from Asociados where IDCliente=" + this.idcli + " And NroContrato='" + ncontrato + "' And estado='ACTIVO'";
            if (Globales.BD.nregistros(txtSQL) > 0)
            {
                Globales.BD.eliminartabladscontratos("Asociados");
                Globales.BD.llenardscontratos(txtSQL, "Asociados");
                dtgAsociados.DataSource = Globales.BD.dsContratos.Tables["Asociados"];
                dtgAsociados.Columns[3].Visible = false;

                Console.WriteLine(dtgAsociados.Rows[0].Cells[4].Value.ToString());
            }
        }
        #endregion

        #endregion

        #region PESTAÑA COBRANZAS

        public void cargar_cmbBanco_Cobranzas(string txtSQL)
        {
            Globales.BD.dtt = Globales.BD.generar_datatable(txtSQL, CommandType.Text, new List<Clases.Parameters>());
            cmbBcoCobranzas.DataSource = Globales.BD.dtt;
            cmbPais.ValueMember = "Codigo";
            cmbPais.DisplayMember = "Descripcion";
        }



        public void cargar_cobranzas(string ncontrato) {
            dtgCCanceladas.DataSource = null;
            dtgCPendientes.DataSource = null;
            txtTotCanCobranzas.Text = "";
            txtGLCobranzas.Text = "";
            txtICCobranzas.Text = "";
            txtGICobranzas.Text = "";
            txtFECobranzas.Text = "";
            txtTGCobranzas.Text = "";
            txtObsCobranzas.Text = "";
            double TC,GL,IC,GI,FE,TG;
            TC=GL=IC=GI=FE=TG=0;
            lblNContratoCobranzas.Text = "Contrato N° " + ncontrato;
            string txtSQL = "Select TipoCuota,NroCuota,TotalCuotas,MontoCuota,FechaCuota from Giros where NroContrato='" + ncontrato + "' and Estatus='PENDIENTE' Order by FechaCuota,TotalCuotas";
            if (Globales.BD.nregistros(txtSQL) > 0)
            {
                Globales.BD.dtt = Globales.BD.generar_datatable(txtSQL, CommandType.Text, new List<Clases.Parameters>());
                dtgCPendientes.DataSource = Globales.BD.dtt;
                //dtgCPendientes.Columns[4].Visible = false;
                foreach (DataRow row in Globales.BD.dtt.Rows)
                {

                    if (row["TipoCuota"] != DBNull.Value) {

                        if (Convert.ToString(row["TipoCuota"]) == "GIRO")
                        {

                            GI += Convert.ToDouble(row["MontoCuota"]);
                        }

                        else if (Convert.ToString(row["TipoCuota"]) == "COMPLEMENTARIA")
                        {

                            IC += Convert.ToDouble(row["MontoCuota"]);
                        }
                        else if (Convert.ToString(row["TipoCuota"]) == "GASTOSLEGALES")
                        {

                            GL += Convert.ToDouble(row["MontoCuota"]);
                        }
                        else if (Convert.ToString(row["TipoCuota"]).Length > 21)
                        {


                            if (Convert.ToString(row["TipoCuota"]).Substring(0, 21) == "FINANCIAMIENTOESPECIAL")
                            {

                                FE += Convert.ToDouble(row["MontoCuota"]);
                            }
                        }
                    
                    }
                    TG += Convert.ToDouble(row["MontoCuota"]); 
                      
                }
                txtGLCobranzas.Text = GL.ToString("N2")+" Bs.";
                txtICCobranzas.Text = IC.ToString("N2")+ " Bs.";
                txtGICobranzas.Text = GI.ToString("N2")+ " Bs.";
                txtFECobranzas.Text = FE.ToString("N2")+ " Bs.";
                txtTGCobranzas.Text = TG.ToString("N2")+ " Bs.";
            }

            txtSQL = "Select TipoCuota,NroCuota,TotalCuotas,MontoCuota,FechaCancelado from Giros where NroContrato='" + ncontrato + "' and Estatus='CANCELADO' Order by FechaCuota,TotalCuotas";
            if (Globales.BD.nregistros(txtSQL) > 0)
            {
                Globales.BD.dtt = Globales.BD.generar_datatable(txtSQL, CommandType.Text, new List<Clases.Parameters>());
                dtgCCanceladas.DataSource = Globales.BD.dtt;
                //dtgCCanceladas.Columns[4].Visible = false;

                foreach (DataRow row in Globales.BD.dtt.Rows)
                    TC += Convert.ToDouble(row["MontoCuota"]);
                txtTotCanCobranzas.Text = TC.ToString("N2") + " Bs.";
            }
        }

        #endregion
    }
}
