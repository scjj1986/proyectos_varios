﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Contratos
{
    public partial class frmVolOPC : Form
    {
        public frmVolOPC()
        {
            InitializeComponent();
            load_cmb = false;
        }

        public bool load_cmb;

        private void frmVolOPC_Load(object sender, EventArgs e)
        {
            string txtSQL = "Select Codigo,Descripcion from Programas order by Codigo";
            cargar_cmbPrograma(txtSQL);
            txtSQL = "Select * from Locacion where CodigoProg="+cmbPrograma.SelectedValue.ToString();
            this.rpvwVolOPC.RefreshReport();
        }

        public void cargar_cmbLocacion(string txtSQL)
        {
            load_cmb = true;
            cmbLocacion.DataSource = null;
            Globales.BD.dtt = Globales.BD.generar_datatable(txtSQL, CommandType.Text, new List<Clases.Parameters>());
            cmbLocacion.DataSource = Globales.BD.dtt;
            cmbLocacion.ValueMember = "Codigo";
            cmbLocacion.DisplayMember = "Descripcion";
            if (cmbLocacion.Items.Count>0)cmbLocacion.SelectedIndex = 0;
            load_cmb = false;

        }

        public void cargar_cmbPrograma(string txtSQL)
        {
            load_cmb = true;
            cmbPrograma.DataSource = null;
            Globales.BD.dtt = Globales.BD.generar_datatable(txtSQL, CommandType.Text, new List<Clases.Parameters>());
            cmbPrograma.DataSource = Globales.BD.dtt;
            cmbPrograma.ValueMember = "Codigo";
            cmbPrograma.DisplayMember = "Descripcion";
            cmbPrograma.SelectedIndex = 0;
            load_cmb = false;

        }

        private void cmbPrograma_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!load_cmb)
            {
                string txtSQL = "Select * from Locacion where CodigoProg=" + cmbPrograma.SelectedValue.ToString();
                cargar_cmbLocacion(txtSQL);

            }

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (dtpFechaDesde.Value > dtpFechaHasta.Value)
            {
                MessageBox.Show("La fecha inicial no puede ser mayor que la fecha final", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int prog = -1;
            string cadprog = "";
            int loc = -1;

            if (cmbPrograma.SelectedIndex >= 0)
            {
                prog = Convert.ToInt32(cmbPrograma.SelectedValue);
                cadprog = cmbPrograma.Text;

            }
            if (cmbLocacion.SelectedIndex >= 0)
            {

                loc = Convert.ToInt32(cmbLocacion.SelectedValue);
            }

            if (prog == -1)
            {

                MessageBox.Show("Nombre de programa incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Globales.BD.sp_reporte_vol_opc(dtpFechaDesde.Value,dtpFechaHasta.Value,prog,cadprog,loc);
            if (Globales.BD.dtt.Rows.Count == 0)
            {
                MessageBox.Show("No hubo coincidencias con los parámetros establecidos", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string lc = loc == -1 ? " " : cmbLocacion.Text;
                string dir = Application.StartupPath.Replace("\\bin\\Debug", "");
                rpvwVolOPC.LocalReport.ReportPath =  dir + "\\Reportes\\rptVolOPC.rdlc";
                rpvwVolOPC.LocalReport.DataSources.Clear();
                rpvwVolOPC.LocalReport.DataSources.Add(new ReportDataSource("dsVOPC", Globales.BD.dtt));//Conjunto de Datos (Ver Datos de Informe en el archivo .rdlc)
                rpvwVolOPC.LocalReport.DataSources.Add(new ReportDataSource("dsSumVOPC", Globales.BD.dtt_aux));//Conjunto de Datos (Ver Datos de Informe en el archivo .rdlc)
                ReportParameter[] parVolOPC = new ReportParameter[5];
                parVolOPC[0] = new ReportParameter("FechaInicio", dtpFechaDesde.Value.ToShortDateString());
                parVolOPC[1] = new ReportParameter("FechaFin", dtpFechaHasta.Value.ToShortDateString());
                parVolOPC[2] = new ReportParameter("Programa",cmbPrograma.Text);
                parVolOPC[3] = new ReportParameter("Locacion",lc);
                parVolOPC[4] = new ReportParameter("Fecha", DateTime.Now.ToShortDateString());
                rpvwVolOPC.LocalReport.SetParameters(parVolOPC);
                rpvwVolOPC.RefreshReport();
            }
            
        }
    }
}
