namespace Contratos
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lbl3 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textLetras1 = new Contratos.TextLetras();
            this.txtDecimal = new Contratos.TextBoxDecimal();
            this.textBoxNumeric1 = new Contratos.TextBoxNumeric();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Location = new System.Drawing.Point(95, 58);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(52, 13);
            this.lbl3.TabIndex = 0;
            this.lbl3.Text = "Numérico";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(102, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Decimal";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(110, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Letras";
            // 
            // textLetras1
            // 
            this.textLetras1.Location = new System.Drawing.Point(150, 122);
            this.textLetras1.Name = "textLetras1";
            this.textLetras1.Size = new System.Drawing.Size(100, 20);
            this.textLetras1.TabIndex = 4;
            // 
            // txtDecimal
            // 
            this.txtDecimal.Location = new System.Drawing.Point(150, 95);
            this.txtDecimal.Name = "txtDecimal";
            this.txtDecimal.Size = new System.Drawing.Size(100, 20);
            this.txtDecimal.TabIndex = 3;
            // 
            // textBoxNumeric1
            // 
            this.textBoxNumeric1.Location = new System.Drawing.Point(150, 58);
            this.textBoxNumeric1.Name = "textBoxNumeric1";
            this.textBoxNumeric1.Size = new System.Drawing.Size(100, 20);
            this.textBoxNumeric1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(47, 347);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 41);
            this.button1.TabIndex = 6;
            this.button1.Text = "Guardar Registro";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(495, 427);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textLetras1);
            this.Controls.Add(this.txtDecimal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxNumeric1);
            this.Controls.Add(this.lbl3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Formulario de Contratos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBoxNumeric txtNumeric;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl3;
        private TextBoxNumeric textBoxNumeric1;
        private System.Windows.Forms.Label label3;
        private TextBoxDecimal txtDecimal;
        private TextLetras textLetras1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;

      
    }
}

