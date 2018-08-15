using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Reflection;
using System.Diagnostics;





namespace Contratos
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
           
            InitializeComponent();
        }

        Clases.LImpresora limp = new Clases.LImpresora(); 


        public void VerificarBotonesPrincipales() {

            foreach (DataRow pRow in Globales.BD.dsGlobal.Tables["Perfiles"].Rows)
            {

                tlstrContratosReservas.Enabled = Convert.ToInt32(pRow["ContratoConsultar"]) == 1? true : false;
                tlstrTemporadas.Enabled = Convert.ToInt32(pRow["TemporadasConsultar"]) == 1 ? true : false;
                tlstrComisiones.Enabled = Convert.ToInt32(pRow["Comisiones"]) == 1 ? true : false;
                tlstrReservaciones.Enabled = Convert.ToInt32(pRow["reservaciones"]) == 1 ? true : false;
                tlstrPPF.Enabled = Convert.ToInt32(pRow["ppf"]) == 1 ? true : false;
                tlstrReportes.Enabled = Convert.ToInt32(pRow["Reportes"]) == 1 ? true : false;
                tlstrCambiarProcesable.Enabled = Convert.ToInt32(pRow["FormularioActualizarContratos"]) == 1 ? true : false;
                tlstrReportesFinancieros.Enabled = Convert.ToInt32(pRow["ReportesFinancieros"]) == 1 ? true : false;
              
            }
        
        
        
        }



        private void frmMain_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Usuario: " + Globales.usr.nombrecompleto + " (" + Globales.usr.nick + ")";

            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            //Console.WriteLine(Dns.GetHostName());

            Globales.nombrehost = Dns.GetHostName();
            
            this.VerificarBotonesPrincipales();

            this.limp.cargar_impresoras();

            //Globales.registrar_suceso("INICIO DE SESIÓN DEL USUARIO");

            //frmMain

            this.Text = "Sistema de Contratos Versión " + Assembly.GetExecutingAssembly().GetName().Version.Major + "." + Assembly.GetExecutingAssembly().GetName().Version.Minor + "." + Assembly.GetExecutingAssembly().GetName().Version.Revision + " Oficina: " + Globales.gNombreEmpresa;

            //Console.WriteLine(Assembly.GetExecutingAssembly().GetName().Version.Major);

            
            


        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void tstrCerrarSesion_Click(object sender, EventArgs e)
        {

            var result = MessageBox.Show("¿Está seguro que desea cerrar sesión?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Globales.reset();
                //frmSeleccionarEmpresa frmslc = new frmSeleccionarEmpresa();
                //frmslc.Show();
                this.Close();
            }
        }

        private void tlstrContratosReservas_Click(object sender, EventArgs e)
        {
            Formularios.frmClientes frcl = new Formularios.frmClientes();
            frcl.ShowDialog();
        }

        private void bancosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBancos frmB = new frmBancos();
            frmB.ShowDialog();
        }

        private void instrumentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInstrumentos frmI = new frmInstrumentos();
            frmI.ShowDialog();
        }

        private void programasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProgramas frmP = new frmProgramas();
            frmP.ShowDialog();
        }

        private void reporteDeVolumenOPCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVolOPC frmVOPC = new frmVolOPC();
            frmVOPC.ShowDialog();
        }

        private void locacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLocacion frmL = new frmLocacion();
            frmL.ShowDialog();
        }

        private void volumenYCierreCloserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPorcCloser frmPC = new frmPorcCloser();
            frmPC.ShowDialog();
        }

        private void volumenYCierreLinerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPorcLiner frmPL = new frmPorcLiner();
            frmPL.ShowDialog();
        }

        private void reporteDeVolumenOPCDetalladoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVolOPCDet frmVOPCD = new frmVolOPCDet();
            frmVOPCD.ShowDialog();
        }

        private void reporteEficienciaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ProcessStartInfo info = new ProcessStartInfo();
            string txtSQL = "Select RutaEficiencia from Oficinas Where Codigo ='" + Globales.emp.codigo + "'";
            Globales.BD.dtt = Globales.BD.generar_datatable(txtSQL, CommandType.Text, new List<Clases.Parameters>());
            string refi = "";
            foreach (DataRow pRow in Globales.BD.dtt.Rows)
            {

                refi = Convert.ToString(pRow["RutaEficiencia"]);
            }
            info.UseShellExecute = true;
            info.FileName = "Reportes.exe";
            info.WorkingDirectory = @"\" + @"\"+refi;
            Process.Start(info);
        }



        private void reporteParaHostessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRepHostess frmRepHos = new frmRepHostess();
            frmRepHos.ShowDialog();
        }

        private void volumenCloserToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void reservasContratosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReporteResCon frmRC = new frmReporteResCon();
            frmRC.ShowDialog();
        }

        private void toolStripButtonCerrarApp_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("¿Está seguro que desea cerrar la aplicación?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                Application.Exit();
        }
    }
}
