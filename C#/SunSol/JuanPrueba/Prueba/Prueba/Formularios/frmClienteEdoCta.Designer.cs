namespace Contratos
{
    partial class frmClienteEdoCta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClienteEdoCta));
            this.rpvwClienteEdoCta = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rpvwClienteEdoCta
            // 
            this.rpvwClienteEdoCta.Location = new System.Drawing.Point(12, 23);
            this.rpvwClienteEdoCta.Name = "rpvwClienteEdoCta";
            this.rpvwClienteEdoCta.Size = new System.Drawing.Size(952, 772);
            this.rpvwClienteEdoCta.TabIndex = 0;
            // 
            // frmClienteEdoCta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 807);
            this.Controls.Add(this.rpvwClienteEdoCta);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmClienteEdoCta";
            this.Text = "Estado de Cuenta";
            this.Load += new System.EventHandler(this.frmClienteEdoCta_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvwClienteEdoCta;
    }
}