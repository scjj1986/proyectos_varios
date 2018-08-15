using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
//using Microsoft.VisualBasic;


using Microsoft.Win32;



namespace Contratos
{
    public partial class frmLogin : Form
    {
        
       
        public frmLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

            txtNick.Text = Contratos.Clases.Stting.leer("Sistema Contratos", "Login", "Usuario");
            Globales.cargar_parametros();
            Globales.cargartablasdsglobal();
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            string pass = "";
            using (MD5 md5Hash = MD5.Create())//Codificiación MD5 para la contraseña
            {
                pass = Globales.usr.GetMd5Hash(md5Hash, txtPass.Text);
            }
            string txtSQL = "Select * from usuarios Where Login='" + txtNick.Text.ToUpper() + "' And Clave='" + pass + "'";
            if (txtNick.Text == "" || txtPass.Text == "")
            {
                MessageBox.Show("No pueden haber campos vacíos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (Globales.BD.nregistros(txtSQL) == 0)
            {

                    MessageBox.Show("Usuario y/o contraseña incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

           }else{

                    txtSQL = "Select * from usuarios Where Login='" + txtNick.Text.ToUpper() + "' And Clave='" + pass + "' And Activo=1";
                    if (Globales.BD.nregistros(txtSQL) == 0)
                    {
                        MessageBox.Show("Usuario inactivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        Globales.BD.llenardsglobal(txtSQL, "usuarios");//Carga del usuario coincidente al dataset

                        foreach (DataRow pRow in Globales.BD.dsGlobal.Tables["usuarios"].Rows)
                        {
                            
                            Globales.usr.codigoperfil = Convert.ToInt32(pRow["CodigoPerfil"]);
                            Globales.usr.nombrecompleto = Convert.ToString(pRow["Nombres"]);
                            if (pRow["Apellidos"] != null) Globales.usr.nombrecompleto += " " + Convert.ToString(pRow["Apellidos"]);
                        }

                        Globales.usr.nick = txtNick.Text.ToUpper();
                        Globales.usr.passMD5 = pass;

                        txtSQL = "Select * from Perfiles where Codigo=" + Convert.ToString(Globales.usr.codigoperfil);

                        Globales.BD.llenardsglobal(txtSQL, "Perfiles");//Carga del perfil del usuario en el dataset
                   
                        frmMain frmn = new frmMain();

                        Contratos.Clases.Stting.guardar("Sistema Contratos", "Login", "Usuario", txtNick.Text.ToLower());


                        this.DialogResult = DialogResult.OK;

                        //------------------ Bitácora ----------------//
                        Clases.Bitacora Bit = new Clases.Bitacora("<-------->","INICIO DE SESIÓN DEL USUARIO");
                        Bit.registrar_suceso();
                        //---------------------------------------------//



                        frmn.ShowDialog();
                        this.Close();
                        
                    }

                    
                }
            
            
            
        }

        



        
    }
}
