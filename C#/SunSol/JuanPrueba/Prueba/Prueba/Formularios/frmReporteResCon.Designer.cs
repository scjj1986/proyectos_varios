namespace Contratos
{
    partial class frmReporteResCon
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReporteResCon));
            this.rpvwRepConRes = new Microsoft.Reporting.WinForms.ReportViewer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.clbOficinas = new System.Windows.Forms.CheckedListBox();
            this.rdContratos = new System.Windows.Forms.RadioButton();
            this.rdReservas = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.chkPPF = new System.Windows.Forms.CheckBox();
            this.chkPVB = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rpvwRepConRes
            // 
            this.rpvwRepConRes.Location = new System.Drawing.Point(221, 12);
            this.rpvwRepConRes.Name = "rpvwRepConRes";
            this.rpvwRepConRes.Size = new System.Drawing.Size(739, 479);
            this.rpvwRepConRes.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkPVB);
            this.groupBox1.Controls.Add(this.chkPPF);
            this.groupBox1.Controls.Add(this.clbOficinas);
            this.groupBox1.Controls.Add(this.rdContratos);
            this.groupBox1.Controls.Add(this.rdReservas);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnConsultar);
            this.groupBox1.Controls.Add(this.dtpFechaHasta);
            this.groupBox1.Controls.Add(this.dtpFechaDesde);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(186, 479);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Opciones:";
            // 
            // clbOficinas
            // 
            this.clbOficinas.FormattingEnabled = true;
            this.clbOficinas.Location = new System.Drawing.Point(8, 134);
            this.clbOficinas.Name = "clbOficinas";
            this.clbOficinas.Size = new System.Drawing.Size(115, 139);
            this.clbOficinas.TabIndex = 10;
            // 
            // rdContratos
            // 
            this.rdContratos.AutoSize = true;
            this.rdContratos.Location = new System.Drawing.Point(10, 87);
            this.rdContratos.Name = "rdContratos";
            this.rdContratos.Size = new System.Drawing.Size(70, 17);
            this.rdContratos.TabIndex = 9;
            this.rdContratos.TabStop = true;
            this.rdContratos.Text = "Contratos";
            this.rdContratos.UseVisualStyleBackColor = true;
            // 
            // rdReservas
            // 
            this.rdReservas.AutoSize = true;
            this.rdReservas.Location = new System.Drawing.Point(10, 69);
            this.rdReservas.Name = "rdReservas";
            this.rdReservas.Size = new System.Drawing.Size(70, 17);
            this.rdReservas.TabIndex = 8;
            this.rdReservas.TabStop = true;
            this.rdReservas.Text = "Reservas";
            this.rdReservas.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 340);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Fecha Hasta:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 288);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Fecha Desde:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Hotel:";
            // 
            // btnConsultar
            // 
            this.btnConsultar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultar.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultar.Image")));
            this.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConsultar.Location = new System.Drawing.Point(30, 393);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(113, 67);
            this.btnConsultar.TabIndex = 1;
            this.btnConsultar.Text = "     Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.Location = new System.Drawing.Point(14, 356);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(154, 20);
            this.dtpFechaHasta.TabIndex = 3;
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.Location = new System.Drawing.Point(14, 304);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(154, 20);
            this.dtpFechaDesde.TabIndex = 1;
            // 
            // chkPPF
            // 
            this.chkPPF.AutoSize = true;
            this.chkPPF.Checked = true;
            this.chkPPF.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPPF.Location = new System.Drawing.Point(10, 21);
            this.chkPPF.Name = "chkPPF";
            this.chkPPF.Size = new System.Drawing.Size(84, 17);
            this.chkPPF.TabIndex = 11;
            this.chkPPF.Text = "Mostrar PPF";
            this.chkPPF.UseVisualStyleBackColor = true;
            // 
            // chkPVB
            // 
            this.chkPVB.AutoSize = true;
            this.chkPVB.Checked = true;
            this.chkPVB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPVB.Location = new System.Drawing.Point(10, 40);
            this.chkPVB.Name = "chkPVB";
            this.chkPVB.Size = new System.Drawing.Size(85, 17);
            this.chkPVB.TabIndex = 12;
            this.chkPVB.Text = "Mostrar PVB";
            this.chkPVB.UseVisualStyleBackColor = true;
            // 
            // frmReporteResCon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 501);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rpvwRepConRes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmReporteResCon";
            this.Text = "Reporte Reserva/Contrato";
            this.Load += new System.EventHandler(this.frmReporteResCon_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvwRepConRes;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdContratos;
        private System.Windows.Forms.RadioButton rdReservas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.DateTimePicker dtpFechaHasta;
        private System.Windows.Forms.DateTimePicker dtpFechaDesde;
        private System.Windows.Forms.CheckedListBox clbOficinas;
        private System.Windows.Forms.CheckBox chkPVB;
        private System.Windows.Forms.CheckBox chkPPF;
    }
}